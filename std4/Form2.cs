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
    public partial class Form2 : Form
    {
        private readonly Form1 _parent;     //부모폼 주소담을 변수 생성

        public Form2(Form1 parent)          //부모폼 주소 받음
        {
            InitializeComponent();
            _parent = parent;               //parent여기에 부모의 주소가 있으니 내부변수로 선언
        }

        private void yes_Btn_Click(object sender, EventArgs e)      //전달버튼
        {
            _parent.Data(textBox1.Text);   //부모 Data() 직접 호출해서 입력한 텍스트 보냄
            this.Close();                  //전달하고 닫아지게
        }

        private void de_Btn_Click(object sender, EventArgs e)       //닫기버튼
        {
            this.Close();
        }
    }

}