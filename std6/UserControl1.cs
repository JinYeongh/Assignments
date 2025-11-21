using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace std6
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();

            InitKeyTags();  //  버튼 Tag 달기
            all_Btn();   //  모든 버튼 하나로 묶어주기
        }

        private void InitKeyTags()  //버튼 tag값으로 묶기
        {
            button1.Tag = "7";
            button2.Tag = "8";
            button3.Tag = "9";
            button4.Tag = "BK";
            button5.Tag = "6";
            button6.Tag = "5";
            button7.Tag = "4";
            button8.Tag = "3";
            button9.Tag = "2";
            button10.Tag = "1";
            button11.Tag = "ENT";
            button13.Tag = "0";
        }

        //모든 버튼의 이벤트를 같은 함수로 묶기
        private void all_Btn()
        {
            foreach (var b in this.Controls.OfType<Button>())   //모든 ui중에서 버튼인것만 골라서
                b.Click += Btn_Click;               //버튼들 다 함수로 연결
        }

        bool reset_ = false;     // bool값으로 새로쓸지 안쓸지 false면 뒤에 이어붙이게하는 변수

        private void Btn_Click(object sender, EventArgs e)      //버튼 클릭
        {
            var key = (sender as Button)?.Tag?.ToString();      //sender = 누가 클릭햇는지 정보를 가져와서 tag에서 값 가져옴
            if (string.IsNullOrEmpty(key)) return;      //빈문자열이면 리턴

            //길이가 1인지 숫자인지 판별
            if (key.Length == 1 && char.IsDigit(key[0]))
            {
                InputNumber(key); //숫자니까 key값 전달
                return;
            }

            switch (key)
            {
                case "BK":   // 한 글자 지우기
                    Backspace(); //키값이 bk일때 여기 함수로
                    break;

                case "ENT":  // 엔터키
                    reset_ = true; // 다음 입력에 새로 쓰게 true로 변경
                    break;
            }
        }

        private void InputNumber(string digit)              //숫자버튼
        {
            if (reset_ || string.IsNullOrEmpty(textBox1.Text))  //새로 입력해야하는상황일때 조건 들어감
            {
                textBox1.Text = digit;      //엔터키를 누르면 새로 들어가야하니까 지웠다가 다시 텍스트박스에 출력
                reset_ = false;             //계속 이어쓰기
                return;
            }
            textBox1.Text += digit;     //그 조건이 아니면 그냥 원래 숫자에 이어서 작성
        }

        private void Backspace()        //지우기버튼
        {
            if (reset_)         //엔터하거나 새로시작해야하는 상태인 조건일때 true일때
            {
                textBox1.Text = string.Empty;   //새로시작해야하니까 빈 문자열 넣기 전체지우기
                reset_ = false;                 //새로시작 false
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text)) return;    //아무것도 지울게 없으니까 return시키기

            if (textBox1.Text.Length > 1)                   //글이 2글자 이상일때 글자길이 하나 지우기
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);      //(substring 인덱스 0부터 전체 길이에서 -1)
            else
                textBox1.Text = string.Empty;       //글자가 딱 한개일때는 전체가 비워져야하니까 빈문자열 넣기
        }
    }
}