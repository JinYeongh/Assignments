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
using System.Security.Cryptography;         //랜덤숫자
using System.Net.Mail;                      //메일
using System.Net;

namespace login
{
    public partial class pwfind : Form
    {
        private readonly string _cs;
        public pwfind(string cs)
        {
            InitializeComponent();
            _cs = cs;
        }

        private void button1_Click(object sender, EventArgs e)          //닫기버튼
        {
            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)          //찾기버튼
        {
            string id = pwfind_label.Text;                              //입력받은 id
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show(this.Owner ?? this, "아이디를 입력하세요.");
                return;
            }

            try
            {
                //id로 email 조회
                string email = null;
                using (SqlConnection conn = new SqlConnection(_cs))
                using (SqlCommand cmd = new SqlCommand("dbo.GetUserEmail", conn))   //조회하는 프로시저 실행
                {
                    cmd.CommandType = CommandType.StoredProcedure;    // 프로시저 실행 모드로 설정
                    cmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = id;   // 아이디 전달

                    conn.Open();
                    object o = cmd.ExecuteScalar();                   //결과 하나 받아서 변수 o에 저장
                    if (o != null && o != DBNull.Value)               //o가 비어있는지 있다면 조건안에들어감
                        email = Convert.ToString(o);                  //받아온 값을 string으로 변환해서 email에 담음
                }

                // 숫자 5자리 랜덤생성
                Random rand = new Random();
                int v = rand.Next(0, 100000); // 0 ~ 99999 사이의 숫자
                string tempPw = v.ToString("D5"); // 5자리 문자열로 (앞에 0 채움)

                //임시비번을 그대로 저장하지 않고, 해시+salt 로 변환
                byte[] salt = PasswordHasher.GenerateSalt(16);                 // 16바이트 랜덤 salt 생성
                byte[] hash = PasswordHasher.Hash(tempPw, salt);               // 해시생성

                // DB에 임시비번으로 바로 변경
                try
                {
                    using (SqlConnection conn = new SqlConnection(_cs))
                    using (SqlCommand cmd = new SqlCommand("dbo.UpdateUserPassword", conn))     //임시비번 프로시저 실행
                    {
                        cmd.CommandType = CommandType.StoredProcedure;   // 프로시저 실행 모드로 설정

                        cmd.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = id;           // 아이디 전달
                        cmd.Parameters.Add("@hash", SqlDbType.VarBinary, 32).Value = hash;      // 해시 전달
                        cmd.Parameters.Add("@salt", SqlDbType.VarBinary, 16).Value = salt;      // salt 전달

                        conn.Open();  // DB 연결
                        int rows = cmd.ExecuteNonQuery();  // 실행 결과로 영향받은 행 수 반환

                        if (rows == 0) // 업데이트된 행이 없으면 실패
                        {
                            MessageBox.Show(this.Owner ?? this, "비밀번호 변경에 실패했습니다.");
                            return;
                        }
                    }
                }
                catch (SqlException ex)    //DB 관련 오류
                {
                    MessageBox.Show(this.Owner ?? this, $"db오류:\n{ex.Message}");
                }
                catch (Exception ex)       //그 외 오류들
                {
                    MessageBox.Show(this.Owner ?? this, $"그 외 오류:\n{ex.Message}");
                }

                // 메일 발송
                string smtpHost = "smtp.gmail.com";     // Gmail SMTP 서버
                int smtpPort = 587;                     // 포트번호
                bool enableSsl = true;                  // SSL 사용 (STARTTLS)
                string smtpUser = ConfigurationManager.AppSettings["smtpUser"];
                string smtpPass = ConfigurationManager.AppSettings["smtpPass"];
                string fromDisplayName = "쿼티시스템 과제";   // 발신자명

                string subject = "임시 비밀번호 안내";                    //메일 제목
                string body = $"임시 비밀번호는 {tempPw} 입니다.";        //메일 본문

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; //보안 프로토콜 강제 설정 요즘은 일정버전 이상해야해서

                using (var msg = new MailMessage())                             //메일 편지 내용 담는 객체
                using (var client = new SmtpClient(smtpHost, smtpPort))         //메일 서버로 실제 전송하는 객체
                {
                    // 한글 깨짐 방지 utf-8
                    msg.From = new MailAddress(smtpUser, fromDisplayName, Encoding.UTF8);       //보내는 사람 설정 아이디 이름 등
                    msg.To.Add(new MailAddress(email));         //받는사람 메일
                    msg.Subject = subject;                      //제목
                    msg.Body = body;                            //본문
                    msg.IsBodyHtml = false;                     //html형식이 아니라 텍스트 형식으로 보내서 false
                    msg.SubjectEncoding = Encoding.UTF8;
                    msg.BodyEncoding = Encoding.UTF8;
                    msg.HeadersEncoding = Encoding.UTF8;

                    client.DeliveryMethod = SmtpDeliveryMethod.Network;       //인터넷 서버를 이용해서 보내라
                    client.EnableSsl = enableSsl;                             // TLS 보안 연결
                    client.UseDefaultCredentials = false;                     //직접 로그인 아이디로 로그인 하겠다는거
                    client.Credentials = new NetworkCredential(smtpUser, smtpPass); // Gmail 계정 로그인
                    client.Timeout = 20000;                                   //시간제한 설정 서버에서 응답없으면 20초만 기다리고 끊음

                    await client.SendMailAsync(msg);                          // 메일 전송
                }

                MessageBox.Show(this.Owner ?? this, "임시 비밀번호를 이메일로 발송했습니다.");
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this.Owner ?? this, $"데이터베이스 오류:\n{ex.Message}");
            }
            catch (SmtpException ex)
            {
                MessageBox.Show(this.Owner ?? this, $"메일 전송 오류:\n{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Owner ?? this, $"오류:\n{ex.Message}");
            }
        }
    }
}
