using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace std4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void data_Btn_Click(object sender, EventArgs e)
        {
            var form2 = new Form2(this);            //자식폼한테 내 주소 알려줌
            form2.Show();                           //입력받을 자식폼 띄우기
        }

        public void Data(string data)               //자식폼에게 입력받은거 띄울 함수
            //매개변수 data로 자식폼에서 값 받아옴
        {
            data_label.Text = data;
        }

        /// //////////////////////////////////////////////////

        private void a_Btn_Click(object sender, EventArgs e)    //1부터 100까지
        {
            label_.Clear(); //초기화먼저
            int a = 0;      //더할 숫자 변수 만들기

            for (int i = 1; i <= 100; i++)   //for문 돌면서 변수에 1부터 100까지 숫자 더하기
            {
                a += i;                 //a에 계속해서 증가하는 숫자 더하기
            }

            label_.Text = a.ToString(); //텍스트박스에 출력하기 위해 string으로 변환
        }

        private void b_Btn_Click(object sender, EventArgs e)    //1부터 100까지 짝수
        {
            label_.Clear(); //초기화먼저
            int b = 0;      //더할 숫자 변수 만들기

            for (int i = 1; i <= 100; i++)   //for문 돌면서 변수에 1부터 100까지 숫자 더하기
                //이거말고 그냥 i를 2씩 더하는 방법도 있음
            {
                if (i % 2 == 0)               //if문 걸어서 i가 2(짝수)로 나눴을때 0이면 더하도록
                {
                    b += i;                 //a에 계속해서 증가하는 숫자 더하기
                }
            }

            label_.Text = b.ToString(); //텍스트박스에 출력하기 위해 string으로 변환
        }

        private void c_Btn_Click(object sender, EventArgs e)
        {
            label_.Clear();       // 라벨 텍스트 싹 비움
            int num = 1;          // 첫 번째 숫자 시작 = 1

            for (int i = 0; i < 5; i++)     // 총 5줄
            {
                if (i % 2 == 0)   // i가 짝수줄(0,2,4) -> 왼쪽에서 오른쪽
                {
                    for (int j = 0; j < 5; j++)     // j는 칸(5칸)
                    {
                        label_.Text += num.ToString().PadLeft(3);
                        //num을 문자열로 바꿔서 왼쪽에 여백(3칸) 주고 붙임

                        num++;    // 다음 숫자로 이동
                    }
                }
                else              // i가 홀수줄(1,3) -> 오른쪽에서 왼쪽
                {
                    int numb = num + 4;     //위에 한바퀴 돌고와서 2부터 시작
                    //num이 6이면 -> numb = 10으로 해서 10부터 역순으로 찍음

                    for (int j = 0; j < 5; j++)     // j는 칸(5칸)
                    {
                        label_.Text += numb.ToString().PadLeft(3);
                        numb--;      // 오른->왼이니까 숫자를 감소시키면서 찍음
                    }

                    num += 5; // 다음줄 시작할 num 조정해주기
                }

                label_.Text += "\r\n";   // 줄바꿈
            }
        }

    }
}
