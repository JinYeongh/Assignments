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
    public partial class Form1 : Form
    {
        private readonly string _cs;        //폼에서 전역처럼 쓸 수 있도록 변수지정

        public Form1()
        {
            InitializeComponent();
            _cs = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;        //App.config에 있는 db연결문
        }

        private void button4_Click(object sender, EventArgs e)      //로그인버튼
        {
            //id pw 담을 변수 생성
            string id = login_label.Text;
            string pw = pw_label.Text;

            //해당 id pw가 db에 있으면 해당 id의 이름정보를 가져옴
            string proc = "dbo.LoginUser";          //프로시저로 쿼리문 대체 id를 통해 이름, 해시, salt 가져옴

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))     //db에 연결 객체를 conn에 만듬
                using (SqlCommand cmd = new SqlCommand(proc, conn))     //위에서 만든거를 cmd를 통해 conn연결을 통해 실행함 여기서 쿼리문(프로시저) 실행됨
                {
                    cmd.CommandType = CommandType.StoredProcedure;      //프로시저 실행 모드로 설정
                    cmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = id;  //프로시저 @id 에 입력값 연결

                    conn.Open();                                        //db 연결

                    //프로시저에서 USER_NAME, PasswordHash, PasswordSalt 가져오기
                    using (SqlDataReader reader = cmd.ExecuteReader())  //쿼리 결과 읽고 using으로 자동으로 닫히게
                    {
                        if (reader.Read())   //db에서 가져온 값 id가 존재하면
                        {
                            string userName = reader.GetString(0);                //가져온 이름 문자열에 담기
                            byte[] dbHash = (byte[])reader["PasswordHash"];       //DB에 저장된 해시
                            byte[] dbSalt = (byte[])reader["PasswordSalt"];       //DB에 저장된 salt

                            //비밀번호 검증 (입력 pw -> 해시 변환 후 DB해시와 비교)
                            bool isMatch = PasswordHasher.Verify(pw, dbSalt, dbHash);   //같으면 true

                            if (isMatch)
                            {
                                MessageBox.Show(this, userName + "님 안녕하세요");      //로그인 성공
                            }
                            else
                            {
                                MessageBox.Show(this, "아이디 또는 비밀번호가 틀렸습니다.");   //비번 불일치
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "아이디 또는 비밀번호가 틀렸습니다.");   //id 자체가 없을 때
                        }
                    }
                }
            }
            catch (SqlException ex)     //DB 관련 오류
            {
                MessageBox.Show(this, "db오류 :\n" + ex.Message);
            }
            catch (Exception ex)        //그 외 오류들
            {
                MessageBox.Show(this, "오류뜸 :\n" + ex.Message);
            }

        }

        private void newu_Btn_Click(object sender, EventArgs e)     //회원가입 버튼 클릭버튼
        {
            newform signup_pop = new newform(_cs);
            signup_pop.ShowDialog(this);   //회원가입 팝업창 띄우기
        }

        private void idfi_Btn_Click(object sender, EventArgs e)     //ID찾기 버튼
        {
            idfind id_lost = new idfind(_cs);
            id_lost.ShowDialog(this);
        }

        private void pwfi_Btn_Click(object sender, EventArgs e)     //PW찾기 버튼
        {
            pwfind pw_lost = new pwfind(_cs);
            pw_lost.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)      //PW수정 버튼
        {
            pwcor pw_chan = new pwcor(_cs); //pwcor폼 객체 chan에 변수를 담고 _cs(DB연결)을 담아서 보냄
            pw_chan.ShowDialog(this);       //폼띄우기
        }
    }
}
