using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace serial_con
{
    public partial class Form1 : Form
    {
        private scanner_con _scanner;                    //시리얼 통신 전담 클래스

        public Form1()
        {
            InitializeComponent();

            _scanner = new scanner_con();                      //시리얼 통신 클래스 생성

            _scanner.DataReceived += Scanner_DataReceived;      //클래스랑 이벤트통신하는 거
        }

        private void Scanner_DataReceived(byte[] chunk)         // 클래스에서 넘어온 데이터 chunk를 폼에서 출력
        {
            try
            {
                string data = Encoding.UTF8.GetString(chunk);   //payload를 문자열로 변환

                // UI 스레드에서 텍스트박스에 출력 (Invoke로 ui스레드 작동시키기)
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        ce_textBox.AppendText(data + Environment.NewLine);  //텍스트박스에 한 줄 출력
                    }));
                }
            }
            catch
            {
                // 필요하면 여기서 로그만 남기고 넘어가도 됨
            }
        }

        private void c_Btn_Click_1(object sender, EventArgs e)      //연결버튼
        {
            try
            {
                string portName = "COM5";              //장치관리자 포트번호

                // 시리얼 통신 클래스에 포트 열기 요청
                _scanner.Connect(portName);

                MessageBox.Show("포트 연결 성공: " + portName, "연결 완료");
            }
            catch (Exception ex)        //클래스에서 throw 여기서 처리
            {
                MessageBox.Show("포트 연결 실패: " + ex.Message, "에러");
            }
        }

        private void Disc_Btn_Click_1(object sender, EventArgs e)   //닫기버튼
        {
            try
            {
                //close쓴 이유 dispose는 메모리까지 정리해서
                //다시 연결하려고할때 새로운 객체를 만들어야해서
                _scanner.Disconnect();      //여기서 포트 닫힘
                MessageBox.Show("포트 연결이 해제되었습니다.", "연결 해제");

                ce_textBox.Clear();         //포트 닫았으니 텍스트박스 클리어
            }
            catch (Exception ex)
            {
                MessageBox.Show("포트 해제 중 오류: " + ex.Message, "에러");
            }
        }

        private void mail_Btn_Click_1(object sender, EventArgs e)       //메일 전송 버튼
        {
            ce_textBox.AppendText("테스트입니다~");
            try
            {
                string all = ce_textBox.Text;             //텍스트박스 누적 내용 변수에 담기

                if (string.IsNullOrWhiteSpace(all))        //빈문자면 메일보낼게 없으니까
                {
                    MessageBox.Show("보낼 데이터 없음", "알림");
                    return;
                }

                user_mail user_Mail = new user_mail(all); //자식폼에 누적값 전달
                user_Mail.ShowDialog(this);               //자식폼 띄우기
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류:\n" + ex.Message, "에러");
            }
        }

        private void newform_Btn_Click_1(object sender, EventArgs e)        //새로운창
        {
            try
            {
                try     //새 폼 띄우기 전에 포트가 연결되어있으면 자동 해제
                {
                    _scanner.Disconnect();    //연결되어있으면 끊기
                }
                catch
                {
                    // 이미 연결 안 되어있거나 오류는 무시
                }

                form2 new_from = new form2();
                new_from.ShowDialog(this);               //자식폼 띄우기
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류:\n" + ex.Message, "에러");
            }
        }

    }
}
