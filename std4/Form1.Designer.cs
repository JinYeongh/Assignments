namespace std4
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_ = new System.Windows.Forms.TextBox();
            this.a_Btn = new System.Windows.Forms.Button();
            this.b_Btn = new System.Windows.Forms.Button();
            this.c_Btn = new System.Windows.Forms.Button();
            this.data_label = new System.Windows.Forms.Label();
            this.data_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_
            // 
            this.label_.Font = new System.Drawing.Font("굴림", 15F);
            this.label_.Location = new System.Drawing.Point(12, 12);
            this.label_.Multiline = true;
            this.label_.Name = "label_";
            this.label_.Size = new System.Drawing.Size(374, 226);
            this.label_.TabIndex = 0;
            // 
            // a_Btn
            // 
            this.a_Btn.Location = new System.Drawing.Point(12, 253);
            this.a_Btn.Name = "a_Btn";
            this.a_Btn.Size = new System.Drawing.Size(75, 23);
            this.a_Btn.TabIndex = 1;
            this.a_Btn.Text = "누적총합";
            this.a_Btn.UseVisualStyleBackColor = true;
            this.a_Btn.Click += new System.EventHandler(this.a_Btn_Click);
            // 
            // b_Btn
            // 
            this.b_Btn.Location = new System.Drawing.Point(102, 253);
            this.b_Btn.Name = "b_Btn";
            this.b_Btn.Size = new System.Drawing.Size(75, 23);
            this.b_Btn.TabIndex = 2;
            this.b_Btn.Text = "짝수총합";
            this.b_Btn.UseVisualStyleBackColor = true;
            this.b_Btn.Click += new System.EventHandler(this.b_Btn_Click);
            // 
            // c_Btn
            // 
            this.c_Btn.Location = new System.Drawing.Point(193, 253);
            this.c_Btn.Name = "c_Btn";
            this.c_Btn.Size = new System.Drawing.Size(75, 23);
            this.c_Btn.TabIndex = 3;
            this.c_Btn.Text = "배열표시";
            this.c_Btn.UseVisualStyleBackColor = true;
            this.c_Btn.Click += new System.EventHandler(this.c_Btn_Click);
            // 
            // data_label
            // 
            this.data_label.AutoSize = true;
            this.data_label.Location = new System.Drawing.Point(14, 379);
            this.data_label.Name = "data_label";
            this.data_label.Size = new System.Drawing.Size(97, 12);
            this.data_label.TabIndex = 4;
            this.data_label.Text = "입력 데이터 표시";
            // 
            // data_Btn
            // 
            this.data_Btn.Location = new System.Drawing.Point(11, 401);
            this.data_Btn.Name = "data_Btn";
            this.data_Btn.Size = new System.Drawing.Size(118, 55);
            this.data_Btn.TabIndex = 5;
            this.data_Btn.Text = "데이터 가져오기";
            this.data_Btn.UseVisualStyleBackColor = true;
            this.data_Btn.Click += new System.EventHandler(this.data_Btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 468);
            this.Controls.Add(this.data_Btn);
            this.Controls.Add(this.data_label);
            this.Controls.Add(this.c_Btn);
            this.Controls.Add(this.b_Btn);
            this.Controls.Add(this.a_Btn);
            this.Controls.Add(this.label_);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox label_;
        private System.Windows.Forms.Button a_Btn;
        private System.Windows.Forms.Button b_Btn;
        private System.Windows.Forms.Button c_Btn;
        private System.Windows.Forms.Label data_label;
        private System.Windows.Forms.Button data_Btn;
    }
}

