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
    public partial class newform : Form
    {
        private readonly string _cs;
        bool isIdChecked = false;   // 아이디 중복확인 했는지
        bool Dcheck = false; // 사용 가능한 아이디인지

        public newform(string cs)
        {
            InitializeComponent();
            _cs = cs;
        }
        
        private void button2_Click(object sender, EventArgs e)      //뒤로가기 버튼
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)      //회원가입 버튼
        {
            //아이디중복확인을 했는지 먼저 검사
            if (!isIdChecked)
            {
                MessageBox.Show("아이디 중복확인을 먼저 해주세요.");
                return;
            }
            if (!Dcheck)
            {
                MessageBox.Show("이미 사용 중인 아이디입니다.");
                return;
            }

            //입력받은거 string으로 변환
            string id = nid_label.Text;
            string pw = npw_label.Text;
            string name = nname_label.Text;

            // 앞부분 아이디와 콤보박스 도메인을 합쳐 최종 이메일 생성
            string emailLocal = nmail_label.Text;                                  // 앞부분
            string emailDomain = (mail_combo.SelectedItem == null) ?                // 도메인
                                 mail_combo.Text : mail_combo.SelectedItem.ToString();
            string email = emailLocal + "@" + emailDomain;                          // 합친 이메일

            //입력받은 값들 중 빈곳이 있는지 확인
            if (string.IsNullOrWhiteSpace(id) ||
                string.IsNullOrWhiteSpace(pw) ||
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(emailLocal) ||
                string.IsNullOrWhiteSpace(emailDomain)
                )
            {
                MessageBox.Show("전체 입력해주세요.");
                return;
            }

            try
            {
                // 비밀번호를 해시로 변환하기 위한 과정
                // salt 생성
                byte[] salt = PasswordHasher.GenerateSalt(16);      //배열 생성
                                                                    // 비밀번호 + salt로 해시 생성
                byte[] hash = PasswordHasher.Hash(pw, salt);        //입력받은거 해쉬로 변환

                using (SqlConnection conn = new SqlConnection(_cs))
                using (SqlCommand cmd = new SqlCommand("dbo.RegisterUser", conn))       //회원가입 프로시저
                {
                    cmd.CommandType = CommandType.StoredProcedure;      //프로시저 실행 모드로 설정

                    //각 라벨에 입력받은 값을 쿼리문에 @로 넣기
                    cmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = nid_label.Text;
                    cmd.Parameters.Add("@hash", SqlDbType.VarBinary, 32).Value = hash;    // 해시값 전달
                    cmd.Parameters.Add("@salt", SqlDbType.VarBinary, 16).Value = salt;    // salt 전달
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = nname_label.Text;
                    cmd.Parameters.Add("@mail", SqlDbType.VarChar, 50).Value = email;     // 합친 이메일 전달

                    //프로시저에서 결과값 가져옴 ok는 0이나 1
                    var pOk = cmd.Parameters.Add("@ok", SqlDbType.Bit);
                    pOk.Direction = ParameterDirection.Output;              //방향 지정해주기
                    //msg는 결과 메세지
                    var pMsg = cmd.Parameters.Add("@message", SqlDbType.NVarChar, 100);
                    pMsg.Direction = ParameterDirection.Output;

                    conn.Open();            // DB 연겨ㅑㄹ
                    cmd.ExecuteNonQuery();  // 프로시저 실행 (중복검사+삽입/메시지)

                    //db에서 받아온값이 빈개 아닌지 그리고 받아온값이 숫자 1인지? 두개가 참이여야함
                    //pOk.Value는 object이니까 Convert.ToInt32로 변환해서 숫자 1이랑 같은지
                    bool ok = (pOk.Value != DBNull.Value) && Convert.ToInt32(pOk.Value) == 1;
                    string msg = Convert.ToString(pMsg.Value);  //db메시지를 문자열 msg에 넣기

                    //ok를 db에서 받아온 값으로 성공이냐 실패냐
                    MessageBox.Show(this.Owner ?? this, string.IsNullOrWhiteSpace(msg) ? (ok ? "회원가입 완료!" : "회원가입 실패") : msg);  //메세지 박스 출력
                    if (ok)
                        this.Close();  // 회원가입 성공 시 창 닫기
                }
            }
            catch (SqlException ex)   //DB 관련 오류
            {
                MessageBox.Show(this.Owner ?? this, $"데이터베이스 오류가 발생했습니다:\n{ex.Message}");
            }
            catch (Exception ex)      //그 외에 오류
            {
                MessageBox.Show(this.Owner ?? this, $"예상치 못한 오류가 발생했습니다:\n{ex.Message}");
            }
        }


        private void button3_Click(object sender, EventArgs e)      //아이디 중복확인 버튼
        {
            string id = nid_label.Text;     //사용자가 입력한 id

            if (id == "")                   //id입력칸이 공백일때
            {
                MessageBox.Show("아이디를 입력하세요.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))                //db에 연결 객체를 conn에 만듬
                using (SqlCommand cmd = new SqlCommand("dbo.CheckUserId", conn))   //중복아이디 프로시저
                {
                    cmd.CommandType = CommandType.StoredProcedure;                 //프로시저 실행 모드로 설정

                    //db에 id 값 전달
                    cmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = id;   //프로시저에 입력한 id값을 넣음

                    //db에서 결과값 가져오기
                    var pAvail = cmd.Parameters.Add("@Dcheck", SqlDbType.Bit);      //db에서 받아온 값을 가져옴
                    pAvail.Direction = ParameterDirection.Output;

                    var pMsg = cmd.Parameters.Add("@message", SqlDbType.NVarChar, 100); //메세지도 가져옴
                    pMsg.Direction = ParameterDirection.Output;

                    conn.Open();                                                   //db오픈
                    cmd.ExecuteNonQuery();                                         //DB가 로직 수행

                    isIdChecked = true;                                            // 중복확인 했음

                    // DB에서 돌려준 결과만 표시
                    bool available = (pAvail.Value != DBNull.Value) && (Convert.ToInt32(pAvail.Value) == 1);
                    string msg = Convert.ToString(pMsg.Value);

                    MessageBox.Show(this.Owner ?? this, msg);//메시지 출력
                    Dcheck = available;
                }
            }
            catch (SqlException ex)     //DB 관련 오류
            {
                MessageBox.Show(this.Owner ?? this, "db오류 :\n" + ex.Message);
            }
            catch (Exception ex)        //그 외 오류들
            {
                MessageBox.Show(this.Owner ?? this, "오류뜸 :\n" + ex.Message);
            }
        }

    }
}
