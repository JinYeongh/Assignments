namespace serial_con
{
    partial class form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.ce_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.c_Btn = new System.Windows.Forms.Button();
            this.Disc_Btn = new System.Windows.Forms.Button();
            this.close_Btn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.03053F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.96947F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ce_textBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.c_Btn, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.Disc_Btn, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.close_Btn, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.24299F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.75701F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(568, 321);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(191, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "새로운 폼";
            // 
            // ce_textBox
            // 
            this.ce_textBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ce_textBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLayoutPanel1.SetColumnSpan(this.ce_textBox, 2);
            this.ce_textBox.Enabled = false;
            this.ce_textBox.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ce_textBox.Location = new System.Drawing.Point(86, 57);
            this.ce_textBox.Multiline = true;
            this.ce_textBox.Name = "ce_textBox";
            this.ce_textBox.Size = new System.Drawing.Size(369, 134);
            this.ce_textBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(41, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 6;
            // 
            // c_Btn
            // 
            this.c_Btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.c_Btn.Location = new System.Drawing.Point(113, 207);
            this.c_Btn.Name = "c_Btn";
            this.c_Btn.Size = new System.Drawing.Size(126, 28);
            this.c_Btn.TabIndex = 4;
            this.c_Btn.Text = "연결";
            this.c_Btn.UseVisualStyleBackColor = true;
            this.c_Btn.Click += new System.EventHandler(this.c_Btn_Click);
            // 
            // Disc_Btn
            // 
            this.Disc_Btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Disc_Btn.Location = new System.Drawing.Point(303, 207);
            this.Disc_Btn.Name = "Disc_Btn";
            this.Disc_Btn.Size = new System.Drawing.Size(120, 28);
            this.Disc_Btn.TabIndex = 5;
            this.Disc_Btn.Text = "해제";
            this.Disc_Btn.UseVisualStyleBackColor = true;
            this.Disc_Btn.Click += new System.EventHandler(this.Disc_Btn_Click);
            // 
            // close_Btn
            // 
            this.close_Btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.close_Btn, 2);
            this.close_Btn.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.close_Btn.Location = new System.Drawing.Point(199, 255);
            this.close_Btn.Name = "close_Btn";
            this.close_Btn.Size = new System.Drawing.Size(142, 32);
            this.close_Btn.TabIndex = 7;
            this.close_Btn.Text = "닫기";
            this.close_Btn.UseVisualStyleBackColor = true;
            this.close_Btn.Click += new System.EventHandler(this.close_Btn_Click);
            // 
            // form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 321);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "form2";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ce_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button c_Btn;
        private System.Windows.Forms.Button Disc_Btn;
        private System.Windows.Forms.Button close_Btn;
    }
}