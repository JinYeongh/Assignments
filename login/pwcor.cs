using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace login
{
    public partial class pwcor : Form
    {
        private readonly string _cs;
        public pwcor(string cs)
        {
            InitializeComponent();
            _cs = cs;       // 전달받은 DB 연결문을 내 내부 변수에 저장
        }

        private void button1_Click(object sender, EventArgs e)      //닫기버튼
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)      //확인버튼
        {
            //입력받은거 string으로 변환
            string id = idch_label.Text;
            string old_pw = pwch_label.Text;
            string new_pw = pwchn_label.Text;

            //입력받은 값들 중 빈곳이 있는지 확인
            if (string.IsNullOrWhiteSpace(id) ||
                string.IsNullOrWhiteSpace(old_pw) ||
                string.IsNullOrWhiteSpace(new_pw)
                )
            {
                MessageBox.Show("전체 입력해주세요.");
                return;
            }

            string proc = "GetUserHashSalt";        //비밀번호 검증용 프로시저

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))     //db에 연결 객체를 conn에 만듬
                {
                    conn.Open();   // DB 연결

                    //기존 비밀번호 해시 비교를 위해 salt, hash 불러오기
                    byte[] dbHash = null;
                    byte[] dbSalt = null;

                    using (SqlCommand cmdGet = new SqlCommand(proc, conn))     //GetUserHashSalt 프로시저 실행
                    {
                        cmdGet.CommandType = CommandType.StoredProcedure;      //프로시저 실행 모드로 설정
                        cmdGet.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = id;  //프로시저 @id 에 입력값 연결

                        using (SqlDataReader reader = cmdGet.ExecuteReader())  //쿼리 결과 읽기
                        {
                            if (reader.Read())
                            {
                                dbHash = (byte[])reader["PasswordHash"];   //DB에 저장된 해시
                                dbSalt = (byte[])reader["PasswordSalt"];   //DB에 저장된 salt
                            }
                            else
                            {
                                MessageBox.Show(this.Owner ?? this, "아이디가 존재하지 않습니다.");
                                return;
                            }
                        }
                    }

                    //입력한 기존 비밀번호를 해시로 변환해 검증
                    bool isMatch = PasswordHasher.Verify(old_pw, dbSalt, dbHash);

                    if (!isMatch)
                    {
                        MessageBox.Show(this.Owner ?? this, "아이디 또는 기존 비밀번호가 틀렸습니다.");
                        return;
                    }

                    //새로운 비밀번호 해시 및 salt 생성
                    byte[] newSalt = PasswordHasher.GenerateSalt(16);          // 새 salt
                    byte[] newHash = PasswordHasher.Hash(new_pw, newSalt);     // 새 hash

                    //새 해시, 새 salt를 DB에 반영
                    using (SqlCommand cmdChange = new SqlCommand("dbo.ChangePassword", conn))     //비번 바꾸는 프로시저
                    {
                        cmdChange.CommandType = CommandType.StoredProcedure;

                        // 해당 쿼리문에 사용자가 입력한 값 넣기
                        cmdChange.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = id;
                        cmdChange.Parameters.Add("@oldHash", SqlDbType.VarBinary, 32).Value = dbHash;   // 기존 해시
                        cmdChange.Parameters.Add("@newHash", SqlDbType.VarBinary, 32).Value = newHash;  // 새 해시
                        cmdChange.Parameters.Add("@newSalt", SqlDbType.VarBinary, 16).Value = newSalt;  // 새 salt

                        int result = Convert.ToInt32(cmdChange.ExecuteScalar());   //db조회해서 1이면 성공, 0이면 실패

                        if (result == 1)                                     //1을 반환받았으니 변경완
                        {
                            MessageBox.Show(this.Owner ?? this, "비밀번호 변경 완료!");
                            this.Close();
                        }
                        else
                            MessageBox.Show(this.Owner ?? this, "비밀번호 변경에 실패했습니다.");
                    }
                }
            }
            catch (SqlException ex)     //DB 관련 오류
            {
                MessageBox.Show(this.Owner ?? this, $"db오류 :\n{ex.Message}");
            }
            catch (Exception ex)        //그 외 오류들
            {
                MessageBox.Show(this.Owner ?? this, $"오류뜸 :\n{ex.Message}");
            }
        }
    }
}
