using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;                      //메일
using System.Net;
using System.Configuration;


namespace serial_con
{
    public partial class user_mail : Form
    {
        private readonly string _all_text;

        public user_mail(string all_text)   //부모에서 받은 값 전달받
        {
            InitializeComponent();
            _all_text = all_text;
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string mail = umail_label.Text + "@" + mail_combo.Text;          //입력받은 메일 변수에 저장

                // 메일 발송
                string smtpHost = "smtp.gmail.com";     // Gmail SMTP 서버
                int smtpPort = 587;                     // 포트번호
                bool enableSsl = true;                  // SSL 사용 (STARTTLS)
                string smtpUser = ConfigurationManager.AppSettings["smtpUser"];
                string smtpPass = ConfigurationManager.AppSettings["smtpPass"];
                string fromDisplayName = "쿼티시스템 과제";   // 발신자명

                string subject = "시리얼";                    //메일 제목
                string body = $"읽은 시리얼은 \r\n{_all_text} 입니다.";        //메일 본문 부모폼에서 시리얼 읽은 데이터 가져와서 보내주기

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; //보안 프로토콜 강제 설정 요즘은 일정버전 이상해야해서

                using (var msg = new MailMessage())                             //메일 편지 내용 담는 객체
                using (var client = new SmtpClient(smtpHost, smtpPort))         //메일 서버로 실제 전송하는 객체
                {
                    // 한글 깨짐 방지 utf-8
                    msg.From = new MailAddress(smtpUser, fromDisplayName, Encoding.UTF8);       //보내는 사람 설정 아이디 이름 등
                    msg.To.Add(new MailAddress(mail));         //받는사람 메일
                    msg.Subject = subject;                      //제목
                    msg.Body = body;                            //본문
                    msg.IsBodyHtml = false;                     //html형식이 아니라 텍스트 형식으로 보내서 false
                    msg.SubjectEncoding = Encoding.UTF8;
                    msg.BodyEncoding = Encoding.UTF8;
                    msg.HeadersEncoding = Encoding.UTF8;

                    client.DeliveryMethod = SmtpDeliveryMethod.Network;       //인터넷 서버를 이용해서 보내라
                    client.EnableSsl = enableSsl;                             // TLS 보안 연결
                    client.UseDefaultCredentials = false;                     //직접 로그인 아이디로 로그인 하겠다는거
                    client.Credentials = new NetworkCredential(smtpUser, smtpPass);        //계정 로그인
                    client.Timeout = 20000;                                   //시간제한 설정 서버에서 응답없으면 20초만 기다리고 끊음

                    await client.SendMailAsync(msg);                          // 메일 전송
                }

                MessageBox.Show(this.Owner ?? this, "시리얼 번호를 이메일로 발송했습니다.");
                this.Close();
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
