namespace GUI
{
    partial class GUI_LogIn
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.btn_logIn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.pbx_Exit = new System.Windows.Forms.PictureBox();
            this.pbx_logo = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.txt_username);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(58, 413);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Size = new System.Drawing.Size(590, 96);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tên đăng nhập";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel1.Location = new System.Drawing.Point(40, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 1);
            this.panel1.TabIndex = 1;
            // 
            // txt_username
            // 
            this.txt_username.BackColor = System.Drawing.SystemColors.Menu;
            this.txt_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.Location = new System.Drawing.Point(41, 33);
            this.txt_username.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(513, 37);
            this.txt_username.TabIndex = 0;
            // 
            // btn_logIn
            // 
            this.btn_logIn.Location = new System.Drawing.Point(199, 788);
            this.btn_logIn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_logIn.Name = "btn_logIn";
            this.btn_logIn.Size = new System.Drawing.Size(307, 73);
            this.btn_logIn.TabIndex = 2;
            this.btn_logIn.Text = "Đăng nhập\r\n";
            this.btn_logIn.UseVisualStyleBackColor = true;
            this.btn_logIn.Click += new System.EventHandler(this.btn_logIn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.txt_password);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(58, 560);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Size = new System.Drawing.Size(590, 96);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mật khẩu";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel2.Location = new System.Drawing.Point(40, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(512, 1);
            this.panel2.TabIndex = 1;
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.SystemColors.Menu;
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(41, 33);
            this.txt_password.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(513, 37);
            this.txt_password.TabIndex = 1;
            // 
            // pbx_Exit
            // 
            this.pbx_Exit.Image = global::GUI.Properties.Resources.x_mark;
            this.pbx_Exit.Location = new System.Drawing.Point(613, 70);
            this.pbx_Exit.Name = "pbx_Exit";
            this.pbx_Exit.Size = new System.Drawing.Size(54, 52);
            this.pbx_Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_Exit.TabIndex = 10;
            this.pbx_Exit.TabStop = false;
            // 
            // pbx_logo
            // 
            this.pbx_logo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbx_logo.Image = global::GUI.Properties.Resources.logo;
            this.pbx_logo.Location = new System.Drawing.Point(287, 163);
            this.pbx_logo.Name = "pbx_logo";
            this.pbx_logo.Size = new System.Drawing.Size(153, 138);
            this.pbx_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_logo.TabIndex = 9;
            this.pbx_logo.TabStop = false;
            // 
            // GUI_LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 962);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_logIn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pbx_Exit);
            this.Controls.Add(this.pbx_logo);
            this.Name = "GUI_LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GUI_LogIn";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Button btn_logIn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.PictureBox pbx_Exit;
        private System.Windows.Forms.PictureBox pbx_logo;
    }
}