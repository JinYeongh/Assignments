namespace login
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
            this.label1 = new System.Windows.Forms.Label();
            this.login_label = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pw_label = new System.Windows.Forms.TextBox();
            this.idfi_Btn = new System.Windows.Forms.Button();
            this.pwfi_Btn = new System.Windows.Forms.Button();
            this.newu_Btn = new System.Windows.Forms.Button();
            this.login_Btn = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.panelMain.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(195, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "로그인창";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // login_label
            // 
            this.login_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelMain.SetColumnSpan(this.login_label, 2);
            this.login_label.Font = new System.Drawing.Font("굴림", 15F);
            this.login_label.Location = new System.Drawing.Point(244, 162);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(176, 30);
            this.login_label.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(149, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(134, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "PW";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pw_label
            // 
            this.pw_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelMain.SetColumnSpan(this.pw_label, 2);
            this.pw_label.Font = new System.Drawing.Font("굴림", 15F);
            this.pw_label.Location = new System.Drawing.Point(243, 234);
            this.pw_label.Name = "pw_label";
            this.pw_label.PasswordChar = '*';
            this.pw_label.Size = new System.Drawing.Size(178, 30);
            this.pw_label.TabIndex = 3;
            // 
            // idfi_Btn
            // 
            this.idfi_Btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.idfi_Btn.Font = new System.Drawing.Font("굴림", 15F);
            this.idfi_Btn.Location = new System.Drawing.Point(65, 316);
            this.idfi_Btn.Name = "idfi_Btn";
            this.idfi_Btn.Size = new System.Drawing.Size(118, 38);
            this.idfi_Btn.TabIndex = 5;
            this.idfi_Btn.Text = "ID찾기";
            this.idfi_Btn.UseVisualStyleBackColor = true;
            this.idfi_Btn.Click += new System.EventHandler(this.idfi_Btn_Click);
            // 
            // pwfi_Btn
            // 
            this.pwfi_Btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pwfi_Btn.Font = new System.Drawing.Font("굴림", 15F);
            this.pwfi_Btn.Location = new System.Drawing.Point(201, 316);
            this.pwfi_Btn.Name = "pwfi_Btn";
            this.pwfi_Btn.Size = new System.Drawing.Size(120, 38);
            this.pwfi_Btn.TabIndex = 6;
            this.pwfi_Btn.Text = "PW찾기";
            this.pwfi_Btn.UseVisualStyleBackColor = true;
            this.pwfi_Btn.Click += new System.EventHandler(this.pwfi_Btn_Click);
            // 
            // newu_Btn
            // 
            this.newu_Btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.newu_Btn.Font = new System.Drawing.Font("굴림", 15F);
            this.newu_Btn.Location = new System.Drawing.Point(475, 316);
            this.newu_Btn.Name = "newu_Btn";
            this.newu_Btn.Size = new System.Drawing.Size(100, 38);
            this.newu_Btn.TabIndex = 7;
            this.newu_Btn.Text = "회원가입";
            this.newu_Btn.UseVisualStyleBackColor = true;
            this.newu_Btn.Click += new System.EventHandler(this.newu_Btn_Click);
            // 
            // login_Btn
            // 
            this.login_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.login_Btn.Font = new System.Drawing.Font("굴림", 15.25F, System.Drawing.FontStyle.Bold);
            this.login_Btn.Location = new System.Drawing.Point(475, 186);
            this.login_Btn.Name = "login_Btn";
            this.panelMain.SetRowSpan(this.login_Btn, 2);
            this.login_Btn.Size = new System.Drawing.Size(100, 49);
            this.login_Btn.TabIndex = 8;
            this.login_Btn.Text = "로그인";
            this.login_Btn.UseVisualStyleBackColor = true;
            this.login_Btn.Click += new System.EventHandler(this.button4_Click);
            // 
            // panelMain
            // 
            this.panelMain.ColumnCount = 6;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.81367F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.18633F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.panelMain.Controls.Add(this.login_Btn, 4, 2);
            this.panelMain.Controls.Add(this.pwfi_Btn, 2, 5);
            this.panelMain.Controls.Add(this.idfi_Btn, 1, 5);
            this.panelMain.Controls.Add(this.label1, 2, 0);
            this.panelMain.Controls.Add(this.label2, 1, 2);
            this.panelMain.Controls.Add(this.label3, 1, 3);
            this.panelMain.Controls.Add(this.pw_label, 2, 3);
            this.panelMain.Controls.Add(this.login_label, 2, 2);
            this.panelMain.Controls.Add(this.newu_Btn, 4, 5);
            this.panelMain.Controls.Add(this.button1, 3, 5);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 6;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.45161F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.54839F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.panelMain.Size = new System.Drawing.Size(626, 414);
            this.panelMain.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Font = new System.Drawing.Font("굴림", 15F);
            this.button1.Location = new System.Drawing.Point(341, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 38);
            this.button1.TabIndex = 9;
            this.button1.Text = "PW수정";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 414);
            this.Controls.Add(this.panelMain);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox login_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pw_label;
        private System.Windows.Forms.Button idfi_Btn;
        private System.Windows.Forms.Button pwfi_Btn;
        private System.Windows.Forms.Button newu_Btn;
        private System.Windows.Forms.Button login_Btn;
        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Button button1;
    }
}

