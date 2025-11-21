namespace std4
{
    partial class Form2
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.yes_Btn = new System.Windows.Forms.Button();
            this.de_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(220, 21);
            this.textBox1.TabIndex = 0;
            // 
            // yes_Btn
            // 
            this.yes_Btn.Location = new System.Drawing.Point(17, 49);
            this.yes_Btn.Name = "yes_Btn";
            this.yes_Btn.Size = new System.Drawing.Size(98, 25);
            this.yes_Btn.TabIndex = 0;
            this.yes_Btn.Text = "입력";
            this.yes_Btn.UseVisualStyleBackColor = true;
            this.yes_Btn.Click += new System.EventHandler(this.yes_Btn_Click);
            // 
            // de_Btn
            // 
            this.de_Btn.Location = new System.Drawing.Point(139, 49);
            this.de_Btn.Name = "de_Btn";
            this.de_Btn.Size = new System.Drawing.Size(98, 25);
            this.de_Btn.TabIndex = 1;
            this.de_Btn.Text = "취소";
            this.de_Btn.UseVisualStyleBackColor = true;
            this.de_Btn.Click += new System.EventHandler(this.de_Btn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 86);
            this.Controls.Add(this.de_Btn);
            this.Controls.Add(this.yes_Btn);
            this.Controls.Add(this.textBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button yes_Btn;
        private System.Windows.Forms.Button de_Btn;
    }
}