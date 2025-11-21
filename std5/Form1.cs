using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace std5
{
    public partial class Form1 : Form
    {
        private readonly Queue<string> _queue = new Queue<string>();        //queue상자 만들기 (출력할 문자열 줄 세우는 역할)
        private readonly Timer _timer = new Timer();                        //일정 간격마다 지나갈때 신호줌

        public Form1()
        {
            InitializeComponent();

            _timer.Interval = 500;         //시간 0.5초 멈추기
            _timer.Tick += Timer_Tick;      //설정한 시간이 될때마다 Timer_Tick함수 실행
        }

        private void button1_Click_1(object sender, EventArgs e)        //버튼 클릭했을때
        {
            //텍스트박스의 이름과 번호를 string으로 변환
            string user_name = name_0.Text;
            string user_num = name_1.Text;
            string line = "사원명: " + user_name + "\r\n" + "사원번호: " + user_num + "\r\n";
            //변환한 사원명 번호를 string line 변수에 담기
            _queue.Enqueue(line);   //만든 문자열을 큐에 넣기
            //바로 화면에 안쓰고 대기열에 쌓는역할

            if (!_timer.Enabled)        //타이머가 꺼져있으면 시작 조건
                _timer.Start();
        }
        
        private void Timer_Tick(object sender, EventArgs e)     //지정한 시간마다 실행되는 함수
        {
            if (_queue.Count == 0)      //대기열이 비어있으면 출력할게 없으니 타이머 정지
            {
                _timer.Stop();
                return;                 //여기서 return을 써서 아래는 else를 굳이 쓸 필요 없음.
            }

            string next = _queue.Dequeue();     //큐에 있는 문자열 하나 꺼냄
            user_info.AppendText(next);         //텍스트 박스에 가져온 문자열을 붙여서 보여줌

            if (_queue.Count == 0)      //다 썻으니 대기열 비어있어서 타이머 다시 정지
                _timer.Stop();
        }
    }
}
