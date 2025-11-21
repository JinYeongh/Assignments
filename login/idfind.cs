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
    public partial class idfind : Form
    {
        private readonly string _cs;
        public idfind(string cs)
        {
            InitializeComponent();
            _cs = cs;
        }

        private void button1_Click(object sender, EventArgs e)      //닫기버튼
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)      //id찾기 확인버튼
        {
            string name = idlost_label.Text; // 사용자 입력이름 변수에 저장

            if (string.IsNullOrWhiteSpace(name))    //이름을 입력했는지
            {
                MessageBox.Show(this.Owner ?? this, "이름을 입력하세요.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                using (SqlCommand cmd = new SqlCommand("dbo.FindUserId", conn))             //해당 프로시저 실행
                {
                    cmd.CommandType = CommandType.StoredProcedure;                          //프로시저 실행
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;       //프로시저에 name변수값 넣음

                    conn.Open();                                                            // DB 연결
                    object result = cmd.ExecuteScalar();                                    // 해당 아이디 하나 가져옴 object는 모든 데이터 받을 수 있음

                    if (result != null)                                                     //가져온값이 null이 아니면
                    {
                        string foundId = result.ToString();                                 //가져온 값을 변수에 담기
                        MessageBox.Show(this.Owner ?? this, $"아이디: {foundId}");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this.Owner ?? this, "해당 이름으로 등록된 아이디가 없습니다.");
                    }
                }
            }
            catch (SqlException ex)     //DB 관련 오류
            {
                MessageBox.Show(this.Owner ?? this, $"db오류 :\n{ex.Message}");
            }
            catch (Exception ex)        //그 외 오류들
            {
                MessageBox.Show(this.Owner ?? this, $"오류뜸 :\n{ex.Message}");
            }
        }
    }
}
