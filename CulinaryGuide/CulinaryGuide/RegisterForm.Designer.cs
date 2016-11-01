namespace CulinaryGuide
{
    partial class RegisterForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.registrationBtn = new System.Windows.Forms.Button();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.loginTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordConfimTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(68, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 19);
            this.label2.TabIndex = 29;
            this.label2.Text = "Пароль:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(66, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.TabIndex = 28;
            this.label1.Text = "Логин:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // registrationBtn
            // 
            this.registrationBtn.BackColor = System.Drawing.Color.SeaGreen;
            this.registrationBtn.FlatAppearance.BorderSize = 0;
            this.registrationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registrationBtn.ForeColor = System.Drawing.Color.PaleGreen;
            this.registrationBtn.Location = new System.Drawing.Point(16, 111);
            this.registrationBtn.Name = "registrationBtn";
            this.registrationBtn.Size = new System.Drawing.Size(241, 20);
            this.registrationBtn.TabIndex = 27;
            this.registrationBtn.Text = "Регистрация";
            this.registrationBtn.UseVisualStyleBackColor = false;
            this.registrationBtn.Click += new System.EventHandler(this.registrationBtn_Click);
            // 
            // passwordTxt
            // 
            this.passwordTxt.BackColor = System.Drawing.Color.White;
            this.passwordTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTxt.ForeColor = System.Drawing.Color.SeaGreen;
            this.passwordTxt.Location = new System.Drawing.Point(138, 33);
            this.passwordTxt.MinimumSize = new System.Drawing.Size(2, 20);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = '*';
            this.passwordTxt.Size = new System.Drawing.Size(119, 20);
            this.passwordTxt.TabIndex = 25;
            // 
            // loginTxt
            // 
            this.loginTxt.BackColor = System.Drawing.Color.White;
            this.loginTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginTxt.ForeColor = System.Drawing.Color.SeaGreen;
            this.loginTxt.Location = new System.Drawing.Point(119, 9);
            this.loginTxt.MinimumSize = new System.Drawing.Size(2, 20);
            this.loginTxt.Name = "loginTxt";
            this.loginTxt.Size = new System.Drawing.Size(139, 20);
            this.loginTxt.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 19);
            this.label3.TabIndex = 32;
            this.label3.Text = "Пароль еще раз:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // passwordConfimTxt
            // 
            this.passwordConfimTxt.BackColor = System.Drawing.Color.White;
            this.passwordConfimTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordConfimTxt.ForeColor = System.Drawing.Color.SeaGreen;
            this.passwordConfimTxt.Location = new System.Drawing.Point(138, 59);
            this.passwordConfimTxt.MinimumSize = new System.Drawing.Size(2, 20);
            this.passwordConfimTxt.Name = "passwordConfimTxt";
            this.passwordConfimTxt.PasswordChar = '*';
            this.passwordConfimTxt.Size = new System.Drawing.Size(119, 20);
            this.passwordConfimTxt.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(74, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 19);
            this.label4.TabIndex = 34;
            this.label4.Text = "Имя:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nameTxt
            // 
            this.nameTxt.BackColor = System.Drawing.Color.White;
            this.nameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTxt.ForeColor = System.Drawing.Color.SeaGreen;
            this.nameTxt.Location = new System.Drawing.Point(118, 85);
            this.nameTxt.MinimumSize = new System.Drawing.Size(2, 20);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(139, 20);
            this.nameTxt.TabIndex = 33;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(274, 145);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passwordConfimTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.registrationBtn);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.loginTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RegisterForm";
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button registrationBtn;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.TextBox loginTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordConfimTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameTxt;
    }
}