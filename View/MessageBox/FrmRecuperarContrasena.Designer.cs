namespace Ocean_Desk_dv.View.MessageBox
{
    partial class FrmRecuperarContrasena
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
            pnlHeader = new Panel();
            lblTitulo = new Label();
            picIcono = new PictureBox();
            lblSubtitulo = new Label();
            btnClose = new Button();
            pnlContenido = new Panel();
            pnlSolicitarCodigo = new Panel();
            pnlVerificarCodigo = new Panel();
            lblEtapaUno = new Label();
            lblInstruccionCorreo = new Label();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            pnlLinea = new Panel();
            pictureBox1 = new PictureBox();
            btnEnviarCodigo = new Button();
            lblCodigo = new Label();
            lblInstruccionCodigo = new Label();
            lblEtapaDos = new Label();
            txtCodigo = new TextBox();
            lblLongitd = new Label();
            lblMensajeCodigo = new Label();
            btnVerificarCodigo = new Button();
            btnReenviarCodigo = new Button();
            btnVolverCorreo = new Button();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIcono).BeginInit();
            pnlContenido.SuspendLayout();
            pnlSolicitarCodigo.SuspendLayout();
            pnlVerificarCodigo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(8, 31, 63);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(picIcono);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(12, 5, 12, 0);
            pnlHeader.Size = new Size(550, 88);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(47, 5);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(459, 44);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Recuperación de Cuenta";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // picIcono
            // 
            picIcono.BackColor = Color.Transparent;
            picIcono.Dock = DockStyle.Left;
            picIcono.Image = Properties.Resources.browser_internet_safe_security_shield_web_website_icon_127033;
            picIcono.Location = new Point(12, 5);
            picIcono.Margin = new Padding(0, 12, 8, 12);
            picIcono.Name = "picIcono";
            picIcono.Size = new Size(35, 44);
            picIcono.SizeMode = PictureBoxSizeMode.Zoom;
            picIcono.TabIndex = 0;
            picIcono.TabStop = false;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Dock = DockStyle.Bottom;
            lblSubtitulo.ForeColor = Color.White;
            lblSubtitulo.Location = new Point(12, 49);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(494, 39);
            lblSubtitulo.TabIndex = 2;
            lblSubtitulo.Text = "Ocean Desk · Seguridad de acceso";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(506, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(32, 83);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.TextAlign = ContentAlignment.TopCenter;
            btnClose.UseVisualStyleBackColor = false;
            // 
            // pnlContenido
            // 
            pnlContenido.Controls.Add(pnlVerificarCodigo);
            pnlContenido.Controls.Add(pnlSolicitarCodigo);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 88);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Padding = new Padding(2);
            pnlContenido.Size = new Size(550, 462);
            pnlContenido.TabIndex = 3;
            // 
            // pnlSolicitarCodigo
            // 
            pnlSolicitarCodigo.Controls.Add(btnEnviarCodigo);
            pnlSolicitarCodigo.Controls.Add(pictureBox1);
            pnlSolicitarCodigo.Controls.Add(pnlLinea);
            pnlSolicitarCodigo.Controls.Add(txtCorreo);
            pnlSolicitarCodigo.Controls.Add(lblCorreo);
            pnlSolicitarCodigo.Controls.Add(lblInstruccionCorreo);
            pnlSolicitarCodigo.Controls.Add(lblEtapaUno);
            pnlSolicitarCodigo.Dock = DockStyle.Top;
            pnlSolicitarCodigo.Location = new Point(2, 2);
            pnlSolicitarCodigo.Name = "pnlSolicitarCodigo";
            pnlSolicitarCodigo.Size = new Size(546, 217);
            pnlSolicitarCodigo.TabIndex = 0;
            // 
            // pnlVerificarCodigo
            // 
            pnlVerificarCodigo.Controls.Add(btnVolverCorreo);
            pnlVerificarCodigo.Controls.Add(btnReenviarCodigo);
            pnlVerificarCodigo.Controls.Add(btnVerificarCodigo);
            pnlVerificarCodigo.Controls.Add(lblMensajeCodigo);
            pnlVerificarCodigo.Controls.Add(lblLongitd);
            pnlVerificarCodigo.Controls.Add(txtCodigo);
            pnlVerificarCodigo.Controls.Add(lblCodigo);
            pnlVerificarCodigo.Controls.Add(lblInstruccionCodigo);
            pnlVerificarCodigo.Controls.Add(lblEtapaDos);
            pnlVerificarCodigo.Dock = DockStyle.Fill;
            pnlVerificarCodigo.Location = new Point(2, 219);
            pnlVerificarCodigo.Name = "pnlVerificarCodigo";
            pnlVerificarCodigo.Size = new Size(546, 241);
            pnlVerificarCodigo.TabIndex = 1;
            pnlVerificarCodigo.Visible = false;
            // 
            // lblEtapaUno
            // 
            lblEtapaUno.AutoSize = true;
            lblEtapaUno.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEtapaUno.Location = new Point(10, 14);
            lblEtapaUno.Name = "lblEtapaUno";
            lblEtapaUno.Size = new Size(264, 23);
            lblEtapaUno.TabIndex = 0;
            lblEtapaUno.Text = "¿Olvidaste tu contraseña?";
            // 
            // lblInstruccionCorreo
            // 
            lblInstruccionCorreo.AutoSize = true;
            lblInstruccionCorreo.Location = new Point(10, 47);
            lblInstruccionCorreo.Name = "lblInstruccionCorreo";
            lblInstruccionCorreo.Size = new Size(521, 40);
            lblInstruccionCorreo.TabIndex = 1;
            lblInstruccionCorreo.Text = "Introduce el correo electrónico asociado a tu cuenta. Te enviaremos \r\nun código de recuperación.";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCorreo.Location = new Point(10, 101);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(148, 18);
            lblCorreo.TabIndex = 2;
            lblCorreo.Text = "Correo Electronico";
            // 
            // txtCorreo
            // 
            txtCorreo.BorderStyle = BorderStyle.None;
            txtCorreo.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCorreo.Location = new Point(60, 129);
            txtCorreo.MaxLength = 150;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Ingrese su Correo Eléctronico aqui...";
            txtCorreo.Size = new Size(460, 21);
            txtCorreo.TabIndex = 3;
            // 
            // pnlLinea
            // 
            pnlLinea.BackColor = Color.MidnightBlue;
            pnlLinea.Location = new Point(60, 151);
            pnlLinea.Name = "pnlLinea";
            pnlLinea.Size = new Size(460, 2);
            pnlLinea.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources.mail_black_envelope_symbol_icon_icons_com_56519;
            pictureBox1.Location = new Point(23, 125);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // btnEnviarCodigo
            // 
            btnEnviarCodigo.BackColor = Color.FromArgb(8, 126, 164);
            btnEnviarCodigo.Cursor = Cursors.Hand;
            btnEnviarCodigo.FlatAppearance.BorderSize = 0;
            btnEnviarCodigo.FlatStyle = FlatStyle.Flat;
            btnEnviarCodigo.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEnviarCodigo.ForeColor = Color.White;
            btnEnviarCodigo.Location = new Point(10, 167);
            btnEnviarCodigo.Name = "btnEnviarCodigo";
            btnEnviarCodigo.Size = new Size(526, 40);
            btnEnviarCodigo.TabIndex = 10;
            btnEnviarCodigo.Text = "➤ ENVIAR CÓDIGO";
            btnEnviarCodigo.UseVisualStyleBackColor = false;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCodigo.Location = new Point(10, 84);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(194, 18);
            lblCodigo.TabIndex = 5;
            lblCodigo.Text = "Código de recuperación";
            // 
            // lblInstruccionCodigo
            // 
            lblInstruccionCodigo.AutoSize = true;
            lblInstruccionCodigo.Location = new Point(10, 49);
            lblInstruccionCodigo.Name = "lblInstruccionCodigo";
            lblInstruccionCodigo.Size = new Size(499, 20);
            lblInstruccionCodigo.TabIndex = 4;
            lblInstruccionCodigo.Text = "Introduce el código enviado a tu dirección de correo electrónico.";
            // 
            // lblEtapaDos
            // 
            lblEtapaDos.AutoSize = true;
            lblEtapaDos.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEtapaDos.Location = new Point(10, 16);
            lblEtapaDos.Name = "lblEtapaDos";
            lblEtapaDos.Size = new Size(208, 23);
            lblEtapaDos.TabIndex = 3;
            lblEtapaDos.Text = "Verifica tu identidad";
            // 
            // txtCodigo
            // 
            txtCodigo.BorderStyle = BorderStyle.None;
            txtCodigo.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigo.Location = new Point(20, 115);
            txtCodigo.MaxLength = 8;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.PlaceholderText = "_ _ _ _ _ _ _ _";
            txtCodigo.Size = new Size(500, 29);
            txtCodigo.TabIndex = 6;
            txtCodigo.TextAlign = HorizontalAlignment.Center;
            // 
            // lblLongitd
            // 
            lblLongitd.AutoSize = true;
            lblLongitd.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLongitd.ForeColor = Color.Gray;
            lblLongitd.Location = new Point(10, 156);
            lblLongitd.Name = "lblLongitd";
            lblLongitd.Size = new Size(137, 17);
            lblLongitd.TabIndex = 7;
            lblLongitd.Text = "Código de 8 dígitos";
            lblLongitd.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMensajeCodigo
            // 
            lblMensajeCodigo.AutoSize = true;
            lblMensajeCodigo.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMensajeCodigo.ForeColor = Color.Gray;
            lblMensajeCodigo.Location = new Point(408, 155);
            lblMensajeCodigo.Name = "lblMensajeCodigo";
            lblMensajeCodigo.Size = new Size(123, 17);
            lblMensajeCodigo.TabIndex = 8;
            lblMensajeCodigo.Text = "Vigencia limitada";
            lblMensajeCodigo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnVerificarCodigo
            // 
            btnVerificarCodigo.BackColor = Color.FromArgb(8, 126, 164);
            btnVerificarCodigo.Cursor = Cursors.Hand;
            btnVerificarCodigo.FlatAppearance.BorderSize = 0;
            btnVerificarCodigo.FlatStyle = FlatStyle.Flat;
            btnVerificarCodigo.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerificarCodigo.ForeColor = Color.White;
            btnVerificarCodigo.Location = new Point(10, 187);
            btnVerificarCodigo.Name = "btnVerificarCodigo";
            btnVerificarCodigo.Size = new Size(321, 40);
            btnVerificarCodigo.TabIndex = 11;
            btnVerificarCodigo.Text = "✔ VERIFICAR CÓDIGO";
            btnVerificarCodigo.UseVisualStyleBackColor = false;
            // 
            // btnReenviarCodigo
            // 
            btnReenviarCodigo.Cursor = Cursors.Hand;
            btnReenviarCodigo.FlatAppearance.BorderSize = 0;
            btnReenviarCodigo.FlatStyle = FlatStyle.Flat;
            btnReenviarCodigo.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReenviarCodigo.ForeColor = Color.FromArgb(8, 31, 63);
            btnReenviarCodigo.Location = new Point(336, 187);
            btnReenviarCodigo.Name = "btnReenviarCodigo";
            btnReenviarCodigo.Size = new Size(108, 40);
            btnReenviarCodigo.TabIndex = 12;
            btnReenviarCodigo.Text = "REENVIAR";
            btnReenviarCodigo.UseVisualStyleBackColor = true;
            // 
            // btnVolverCorreo
            // 
            btnVolverCorreo.Cursor = Cursors.Hand;
            btnVolverCorreo.FlatAppearance.BorderSize = 0;
            btnVolverCorreo.FlatStyle = FlatStyle.Flat;
            btnVolverCorreo.Font = new Font("Century Gothic", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolverCorreo.ForeColor = Color.Red;
            btnVolverCorreo.Location = new Point(439, 187);
            btnVolverCorreo.Name = "btnVolverCorreo";
            btnVolverCorreo.Size = new Size(96, 40);
            btnVolverCorreo.TabIndex = 13;
            btnVolverCorreo.Text = "CANCELAR";
            btnVolverCorreo.UseVisualStyleBackColor = true;
            // 
            // FrmRecuperarContrasena
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(550, 550);
            Controls.Add(pnlContenido);
            Controls.Add(pnlHeader);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmRecuperarContrasena";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmRecuperarContrasena";
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIcono).EndInit();
            pnlContenido.ResumeLayout(false);
            pnlSolicitarCodigo.ResumeLayout(false);
            pnlSolicitarCodigo.PerformLayout();
            pnlVerificarCodigo.ResumeLayout(false);
            pnlVerificarCodigo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitulo;
        private PictureBox picIcono;
        private Label lblSubtitulo;
        private Button btnClose;
        private Panel pnlContenido;
        private Panel pnlVerificarCodigo;
        private Panel pnlSolicitarCodigo;
        private Label lblInstruccionCorreo;
        private Label lblEtapaUno;
        private TextBox txtCorreo;
        private Label lblCorreo;
        private Panel pnlLinea;
        private PictureBox pictureBox1;
        private Button btnEnviarCodigo;
        private Label lblCodigo;
        private Label lblInstruccionCodigo;
        private Label lblEtapaDos;
        private TextBox txtCodigo;
        private Button btnVerificarCodigo;
        private Label lblMensajeCodigo;
        private Label lblLongitd;
        private Button btnReenviarCodigo;
        private Button btnVolverCorreo;
    }
}