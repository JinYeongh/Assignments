using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serial_con
{
    public partial class form2 : Form
    {
        private scanner_con _scanner;                    //시리얼 통신 전담 클래스

        private readonly Queue<byte> _q = new Queue<byte>();        //수신 바이트 큐
        private readonly List<byte> _buf = new List<byte>();        //바이트 누적 버퍼 (stx~etx)
        private readonly object _lock = new object();               //스레드 충돌 방지용

        private const byte STX = 0x02;                              //시작 stx
        private const byte ETX = 0x03;                              //끝 etx

        private System.Windows.Forms.Timer _queueTimer;             //큐 출력용 타이머
        public form2()
        {
            InitializeComponent();

            _scanner = new scanner_con();                      //시리얼 통신 클래스 생성

            //클래스에서 데이터 chunk 이벤트로 받기
            _scanner.DataReceived += Scanner_DataReceived;      //바이트마다 큐에 쌓는 함수 연결

            //큐에 담긴 데이터를 일정 주기로 텍스트박스에 출력하기 위한 타이머
            _queueTimer = new System.Windows.Forms.Timer();
            _queueTimer.Interval = 30;              //~밀리초마다 동작
            _queueTimer.Tick += queueTimer_Tick;    //시간 지날때마다 queueTimer_Tick 함수 호출
            _queueTimer.Start();                    //타이머 시작
        }
        private void queueTimer_Tick(object sender, EventArgs e)    //타이머 틱마다 큐 처리
        {
            ProcessQueue();     //큐에 담긴 데이터 텍스트박스로 출력
        }

        private void Scanner_DataReceived(byte[] chunk)         // 클래스에서 넘어온 데이터 chunk를 큐에 쌓음
        {
            lock (_lock)
            {
                foreach (var b in chunk)
                {
                    _q.Enqueue(b);          // for문 돌면서 한 바이트씩 큐에 담아짐
                }
            }
        }

        private void ProcessQueue()   //큐 출력용 함수 타이머 틱마다 자동 실행
        {
            while (true)
            {
                byte b;                       //큐에서 담을 그릇 준비

                lock (_lock)                  //스레드 하나씩 입장
                {
                    if (_q.Count == 0)        //큐가 비어있으면 데이터 없는거니 탈출
                        break;

                    b = _q.Dequeue();         //_q에서 한 개씩 꺼내기
                }

                if (b == STX)                 //시작 stx 들어오면
                {
                    _buf.Clear();             //이전에 남아있던 데이터 지우고 새 프레임 시작
                    continue;
                }

                if (b == ETX)                 //끝 etx 들어오면
                {
                    if (_buf.Count > 0)       //stx etx까지 담은 _buf가 끝이 날때까지
                    {
                        string data = Encoding.UTF8.GetString(_buf.ToArray());  //payload를 문자열로 변환
                        ce_textBox.AppendText(data + Environment.NewLine);      //텍스트박스에 한 줄 출력
                    }
                    _buf.Clear();             //프레임 하나 처리 끝났으니 초기화
                    continue;
                }
                _buf.Add(b);                  //payload 누적
            }
        }

        private void c_Btn_Click(object sender, EventArgs e)        //포트연결
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

        private void Disc_Btn_Click(object sender, EventArgs e)     //연결끊기
        {
            try
            {
                // 포트 닫기
                _scanner.Disconnect();      //여기서 포트 닫힘
                MessageBox.Show("포트 연결이 해제되었습니다.", "연결 해제");

                ce_textBox.Clear();         //포트 닫았으니 텍스트박스 클리어

                lock (_lock)                //스레드 하나씩 입장
                {
                    _buf.Clear();           // 버퍼와 큐 초기화
                    _q.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("포트 해제 중 오류: " + ex.Message, "에러");
            }
        }

        private void close_Btn_Click(object sender, EventArgs e)    //창 닫기
        {
            try
            {
                // 포트 닫기
                _scanner.Disconnect();      //여기서 포트 닫힘
                MessageBox.Show("포트 연결이 해제되었습니다.", "연결 해제");

                ce_textBox.Clear();         //포트 닫았으니 텍스트박스 클리어

                this.Close();               //폼 닫기
            }
            catch (Exception ex)
            {
                MessageBox.Show("포트 해제 중 오류: " + ex.Message, "에러");
            }
        }

    }
}
