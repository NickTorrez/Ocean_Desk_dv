namespace Ocean_Desk_dv
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            pnlBrand = new Panel();
            lblCopyright = new Label();
            lblDescription = new Label();
            lblAppName = new Label();
            picLogo = new PictureBox();
            pnlLogin = new Panel();
            btnCancel = new Button();
            lblPassword = new Label();
            btnClose = new Button();
            lnkForgotPassword = new LinkLabel();
            lblUsername = new Label();
            chkRemember = new CheckBox();
            btnLogin = new Button();
            pnlUsername = new Panel();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            txtUsername = new TextBox();
            lblLoginDescription = new Label();
            lblWelcome = new Label();
            pnlPassword = new Panel();
            panel1 = new Panel();
            btnShowPassword = new Button();
            pictureBox2 = new PictureBox();
            txtPassword = new TextBox();
            pictureBox3 = new PictureBox();
            pnlBrand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlLogin.SuspendLayout();
            pnlUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pnlBrand
            // 
            pnlBrand.BackgroundImage = (Image)resources.GetObject("pnlBrand.BackgroundImage");
            pnlBrand.Controls.Add(lblCopyright);
            pnlBrand.Controls.Add(lblDescription);
            pnlBrand.Controls.Add(lblAppName);
            pnlBrand.Controls.Add(picLogo);
            pnlBrand.Dock = DockStyle.Left;
            pnlBrand.Location = new Point(0, 0);
            pnlBrand.Name = "pnlBrand";
            pnlBrand.Size = new Size(400, 553);
            pnlBrand.TabIndex = 0;
            // 
            // lblCopyright
            // 
            lblCopyright.AutoSize = true;
            lblCopyright.BackColor = Color.Transparent;
            lblCopyright.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCopyright.ForeColor = SystemColors.AppWorkspace;
            lblCopyright.Location = new Point(25, 527);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(247, 17);
            lblCopyright.TabIndex = 9;
            lblCopyright.Text = "©2026 OceanDesk. All rights reserved.";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.BackColor = Color.Transparent;
            lblDescription.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.ForeColor = Color.White;
            lblDescription.Location = new Point(39, 358);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(324, 21);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Gestión inteligente para tu negocio";
            // 
            // lblAppName
            // 
            lblAppName.BackColor = Color.Transparent;
            lblAppName.Font = new Font("Century Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(25, 295);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(350, 45);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "Ocean Desk";
            lblAppName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = Properties.Resources.LOGO;
            picLogo.Location = new Point(28, 119);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(345, 192);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // pnlLogin
            // 
            pnlLogin.Controls.Add(btnCancel);
            pnlLogin.Controls.Add(lblPassword);
            pnlLogin.Controls.Add(btnClose);
            pnlLogin.Controls.Add(lnkForgotPassword);
            pnlLogin.Controls.Add(lblUsername);
            pnlLogin.Controls.Add(chkRemember);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(pnlUsername);
            pnlLogin.Controls.Add(lblLoginDescription);
            pnlLogin.Controls.Add(lblWelcome);
            pnlLogin.Controls.Add(pnlPassword);
            pnlLogin.Controls.Add(pictureBox3);
            pnlLogin.Dock = DockStyle.Fill;
            pnlLogin.Location = new Point(400, 0);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(582, 553);
            pnlLogin.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(498, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(35, 40);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "―";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(150, 257);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(109, 21);
            lblPassword.TabIndex = 0;
            lblPassword.Text = "Contraseña";
            // 
            // btnClose
            // 
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(539, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 40);
            btnClose.TabIndex = 7;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lnkForgotPassword
            // 
            lnkForgotPassword.AutoSize = true;
            lnkForgotPassword.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnkForgotPassword.Location = new Point(191, 485);
            lnkForgotPassword.Name = "lnkForgotPassword";
            lnkForgotPassword.Size = new Size(234, 21);
            lnkForgotPassword.TabIndex = 6;
            lnkForgotPassword.TabStop = true;
            lnkForgotPassword.Text = "¿Olvidaste tu contraseña?";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(154, 158);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(70, 21);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Usuario";
            // 
            // chkRemember
            // 
            chkRemember.AutoSize = true;
            chkRemember.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkRemember.Location = new Point(240, 438);
            chkRemember.Name = "chkRemember";
            chkRemember.Size = new Size(135, 25);
            chkRemember.TabIndex = 5;
            chkRemember.Text = "Recordarme";
            chkRemember.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.DarkBlue;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(103, 364);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(400, 50);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // pnlUsername
            // 
            pnlUsername.BackColor = Color.White;
            pnlUsername.BorderStyle = BorderStyle.FixedSingle;
            pnlUsername.Controls.Add(panel2);
            pnlUsername.Controls.Add(pictureBox1);
            pnlUsername.Controls.Add(txtUsername);
            pnlUsername.Location = new Point(103, 170);
            pnlUsername.Name = "pnlUsername";
            pnlUsername.Size = new Size(400, 55);
            pnlUsername.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Cyan;
            panel2.Location = new Point(61, 41);
            panel2.Name = "panel2";
            panel2.Size = new Size(318, 5);
            panel2.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources.user_84308;
            pictureBox1.Location = new Point(16, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.AcceptsReturn = true;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(61, 17);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Ingrese su usuario";
            txtUsername.Size = new Size(318, 23);
            txtUsername.TabIndex = 1;
            // 
            // lblLoginDescription
            // 
            lblLoginDescription.AutoSize = true;
            lblLoginDescription.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLoginDescription.Location = new Point(103, 111);
            lblLoginDescription.Name = "lblLoginDescription";
            lblLoginDescription.Size = new Size(248, 21);
            lblLoginDescription.TabIndex = 1;
            lblLoginDescription.Text = "Inicia sesión para continuar";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(92, 47);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(259, 47);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "¡Bienvenido!";
            // 
            // pnlPassword
            // 
            pnlPassword.BackColor = Color.White;
            pnlPassword.BorderStyle = BorderStyle.FixedSingle;
            pnlPassword.Controls.Add(panel1);
            pnlPassword.Controls.Add(btnShowPassword);
            pnlPassword.Controls.Add(pictureBox2);
            pnlPassword.Controls.Add(txtPassword);
            pnlPassword.Location = new Point(103, 268);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Size = new Size(400, 55);
            pnlPassword.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Cyan;
            panel1.Location = new Point(62, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(318, 5);
            panel1.TabIndex = 3;
            // 
            // btnShowPassword
            // 
            btnShowPassword.BackColor = Color.Transparent;
            btnShowPassword.Cursor = Cursors.Hand;
            btnShowPassword.FlatAppearance.BorderSize = 0;
            btnShowPassword.FlatStyle = FlatStyle.Flat;
            btnShowPassword.Location = new Point(340, 12);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.Size = new Size(40, 30);
            btnShowPassword.TabIndex = 4;
            btnShowPassword.TabStop = false;
            btnShowPassword.Text = "👁";
            btnShowPassword.UseVisualStyleBackColor = false;
            btnShowPassword.Click += btnShowPassword_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = Properties.Resources.protection_password_safe_lock_icon_229455;
            pictureBox2.Location = new Point(17, 13);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(62, 17);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Ingrese su contraseña";
            txtPassword.Size = new Size(318, 23);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = Properties.Resources.Icon_Ocean_Desk;
            pictureBox3.Location = new Point(328, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(122, 151);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(982, 553);
            Controls.Add(pnlLogin);
            Controls.Add(pnlBrand);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ocean Desk - Inicio de Sesión";
            pnlBrand.ResumeLayout(false);
            pnlBrand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            pnlUsername.ResumeLayout(false);
            pnlUsername.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlPassword.ResumeLayout(false);
            pnlPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBrand;
        private PictureBox picLogo;
        private Label lblAppName;
        private Label lblDescription;
        private Panel pnlLogin;
        private Label lblLoginDescription;
        private Label lblWelcome;
        private Panel pnlUsername;
        private TextBox txtUsername;
        private Label lblUsername;
        private Panel pnlPassword;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private LinkLabel lnkForgotPassword;
        private CheckBox chkRemember;
        private Button btnClose;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panel1;
        private Button btnCancel;
        private Button btnShowPassword;
        private Label lblCopyright;
        private Panel panel2;
        private PictureBox pictureBox3;
    }
}
