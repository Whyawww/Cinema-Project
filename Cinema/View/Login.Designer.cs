namespace Cinema.View
{
    partial class Login
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
            this.linkLblDaftar = new System.Windows.Forms.LinkLabel();
            this.lblBlmPnyaAkun = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassLogin = new System.Windows.Forms.TextBox();
            this.txtUsrnameLgn = new System.Windows.Forms.TextBox();
            this.lblPasswordLogin = new System.Windows.Forms.Label();
            this.lblUsernameLogin = new System.Windows.Forms.Label();
            this.lblHalLogin = new System.Windows.Forms.Label();
            this.lblMakerLogin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // linkLblDaftar
            // 
            this.linkLblDaftar.AutoSize = true;
            this.linkLblDaftar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLblDaftar.Location = new System.Drawing.Point(435, 362);
            this.linkLblDaftar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLblDaftar.Name = "linkLblDaftar";
            this.linkLblDaftar.Size = new System.Drawing.Size(69, 17);
            this.linkLblDaftar.TabIndex = 18;
            this.linkLblDaftar.TabStop = true;
            this.linkLblDaftar.Text = "DAFTAR";
            this.linkLblDaftar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblDaftar_LinkClicked);
            // 
            // lblBlmPnyaAkun
            // 
            this.lblBlmPnyaAkun.AutoSize = true;
            this.lblBlmPnyaAkun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlmPnyaAkun.ForeColor = System.Drawing.Color.Gray;
            this.lblBlmPnyaAkun.Location = new System.Drawing.Point(305, 362);
            this.lblBlmPnyaAkun.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBlmPnyaAkun.Name = "lblBlmPnyaAkun";
            this.lblBlmPnyaAkun.Size = new System.Drawing.Size(152, 17);
            this.lblBlmPnyaAkun.TabIndex = 17;
            this.lblBlmPnyaAkun.Text = "Belum Punya Akun?";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Gray;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Maroon;
            this.btnLogin.Location = new System.Drawing.Point(347, 314);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(98, 33);
            this.btnLogin.TabIndex = 16;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassLogin
            // 
            this.txtPassLogin.Location = new System.Drawing.Point(306, 240);
            this.txtPassLogin.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassLogin.Multiline = true;
            this.txtPassLogin.Name = "txtPassLogin";
            this.txtPassLogin.Size = new System.Drawing.Size(208, 30);
            this.txtPassLogin.TabIndex = 15;
            // 
            // txtUsrnameLgn
            // 
            this.txtUsrnameLgn.Location = new System.Drawing.Point(306, 170);
            this.txtUsrnameLgn.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsrnameLgn.Multiline = true;
            this.txtUsrnameLgn.Name = "txtUsrnameLgn";
            this.txtUsrnameLgn.Size = new System.Drawing.Size(208, 30);
            this.txtUsrnameLgn.TabIndex = 14;
            // 
            // lblPasswordLogin
            // 
            this.lblPasswordLogin.AutoSize = true;
            this.lblPasswordLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordLogin.ForeColor = System.Drawing.Color.Gray;
            this.lblPasswordLogin.Location = new System.Drawing.Point(305, 222);
            this.lblPasswordLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPasswordLogin.Name = "lblPasswordLogin";
            this.lblPasswordLogin.Size = new System.Drawing.Size(69, 17);
            this.lblPasswordLogin.TabIndex = 13;
            this.lblPasswordLogin.Text = "Password";
            // 
            // lblUsernameLogin
            // 
            this.lblUsernameLogin.AutoSize = true;
            this.lblUsernameLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameLogin.ForeColor = System.Drawing.Color.Gray;
            this.lblUsernameLogin.Location = new System.Drawing.Point(305, 151);
            this.lblUsernameLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsernameLogin.Name = "lblUsernameLogin";
            this.lblUsernameLogin.Size = new System.Drawing.Size(73, 17);
            this.lblUsernameLogin.TabIndex = 12;
            this.lblUsernameLogin.Text = "Username";
            // 
            // lblHalLogin
            // 
            this.lblHalLogin.AutoSize = true;
            this.lblHalLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalLogin.ForeColor = System.Drawing.Color.Gray;
            this.lblHalLogin.Location = new System.Drawing.Point(357, 104);
            this.lblHalLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHalLogin.Name = "lblHalLogin";
            this.lblHalLogin.Size = new System.Drawing.Size(72, 24);
            this.lblHalLogin.TabIndex = 11;
            this.lblHalLogin.Text = "LOGIN";
            // 
            // lblMakerLogin
            // 
            this.lblMakerLogin.AutoSize = true;
            this.lblMakerLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMakerLogin.ForeColor = System.Drawing.Color.Gray;
            this.lblMakerLogin.Location = new System.Drawing.Point(303, 42);
            this.lblMakerLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMakerLogin.Name = "lblMakerLogin";
            this.lblMakerLogin.Size = new System.Drawing.Size(189, 31);
            this.lblMakerLogin.TabIndex = 10;
            this.lblMakerLogin.Text = "FILM MAKER";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLblDaftar);
            this.Controls.Add(this.lblBlmPnyaAkun);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassLogin);
            this.Controls.Add(this.txtUsrnameLgn);
            this.Controls.Add(this.lblPasswordLogin);
            this.Controls.Add(this.lblUsernameLogin);
            this.Controls.Add(this.lblHalLogin);
            this.Controls.Add(this.lblMakerLogin);
            this.Name = "Login";
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLblDaftar;
        private System.Windows.Forms.Label lblBlmPnyaAkun;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassLogin;
        private System.Windows.Forms.TextBox txtUsrnameLgn;
        private System.Windows.Forms.Label lblPasswordLogin;
        private System.Windows.Forms.Label lblUsernameLogin;
        private System.Windows.Forms.Label lblHalLogin;
        private System.Windows.Forms.Label lblMakerLogin;
    }
}