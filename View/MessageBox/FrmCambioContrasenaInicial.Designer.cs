namespace Ocean_Desk_dv.View.MessageBox
{
    partial class FrmCambioContrasenaInicial
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
            btnClose = new Button();
            this.picIcono = new PictureBox();
            lblSubtitulo = new Label();
            pnlContenido = new Panel();
            pnlFooter = new Panel();
            pnlButtons = new Panel();
            this.btnGuardar = new Button();
            btnCancelar = new Button();
            lblInstruccion = new Label();
            lblNombreUsuario = new Label();
            lblNuevaContrasena = new Label();
            txtNuevaContrasena = new TextBox();
            pnlLinea = new Panel();
            btnMostrarContrasena = new Button();
            lblConfirmarContrasena = new Label();
            txtConfirmarContrasena = new TextBox();
            pnlLine = new Panel();
            btnMostrarConfirmacion = new Button();
            lblRequisitosTitulo = new Label();
            lblRequisitosSubtitulo = new Label();
            pnlRequisitos = new Panel();
            lblRequisitosOne = new Label();
            lblRequisitosTwo = new Label();
            lblRequisitosThree = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.picIcono).BeginInit();
            pnlContenido.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlRequisitos.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(8, 31, 63);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(this.picIcono);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(12, 5, 12, 0);
            pnlHeader.Size = new Size(550, 88);
            pnlHeader.TabIndex = 1;
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
            lblTitulo.Text = "Cambio de Contraseña";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
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
            // picIcono
            // 
            this.picIcono.BackColor = Color.Transparent;
            this.picIcono.Dock = DockStyle.Left;
            this.picIcono.Image = Properties.Resources.crime_finger_fingerprint_identity_internet_print_security_icon_127061;
            this.picIcono.Location = new Point(12, 5);
            this.picIcono.Margin = new Padding(0, 12, 8, 12);
            this.picIcono.Name = "picIcono";
            this.picIcono.Size = new Size(35, 44);
            this.picIcono.SizeMode = PictureBoxSizeMode.Zoom;
            this.picIcono.TabIndex = 0;
            this.picIcono.TabStop = false;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Dock = DockStyle.Bottom;
            lblSubtitulo.ForeColor = Color.White;
            lblSubtitulo.Location = new Point(12, 49);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(494, 39);
            lblSubtitulo.TabIndex = 2;
            lblSubtitulo.Text = "Proteja su cuenta de Ocean Desk";
            // 
            // pnlContenido
            // 
            pnlContenido.AutoSize = true;
            pnlContenido.BackColor = Color.White;
            pnlContenido.Controls.Add(pnlRequisitos);
            pnlContenido.Controls.Add(lblRequisitosSubtitulo);
            pnlContenido.Controls.Add(lblRequisitosTitulo);
            pnlContenido.Controls.Add(pnlLine);
            pnlContenido.Controls.Add(btnMostrarConfirmacion);
            pnlContenido.Controls.Add(txtConfirmarContrasena);
            pnlContenido.Controls.Add(lblConfirmarContrasena);
            pnlContenido.Controls.Add(pnlLinea);
            pnlContenido.Controls.Add(btnMostrarContrasena);
            pnlContenido.Controls.Add(txtNuevaContrasena);
            pnlContenido.Controls.Add(lblNuevaContrasena);
            pnlContenido.Controls.Add(lblNombreUsuario);
            pnlContenido.Controls.Add(lblInstruccion);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 88);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Padding = new Padding(20, 10, 20, 10);
            pnlContenido.Size = new Size(550, 462);
            pnlContenido.TabIndex = 2;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(245, 247, 250);
            pnlFooter.Controls.Add(pnlButtons);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 490);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(10, 10, 15, 10);
            pnlFooter.Size = new Size(550, 60);
            pnlFooter.TabIndex = 3;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(this.btnGuardar);
            pnlButtons.Controls.Add(btnCancelar);
            pnlButtons.Dock = DockStyle.Right;
            pnlButtons.Location = new Point(184, 10);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(351, 40);
            pnlButtons.TabIndex = 2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = Color.FromArgb(8, 126, 164);
            this.btnGuardar.Cursor = Cursors.Hand;
            this.btnGuardar.Dock = DockStyle.Right;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = FlatStyle.Flat;
            this.btnGuardar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnGuardar.ForeColor = Color.White;
            this.btnGuardar.Location = new Point(134, 0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(217, 40);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "✓ GUARDAR CONTRASEÑA";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Dock = DockStyle.Left;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(0, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(115, 40);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "✕ CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // lblInstruccion
            // 
            lblInstruccion.Dock = DockStyle.Top;
            lblInstruccion.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInstruccion.Location = new Point(20, 10);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Size = new Size(510, 25);
            lblInstruccion.TabIndex = 0;
            lblInstruccion.Text = "Establezca su contraseña";
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Dock = DockStyle.Top;
            lblNombreUsuario.Location = new Point(20, 35);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(474, 40);
            lblNombreUsuario.TabIndex = 1;
            lblNombreUsuario.Text = "Hola, Nick. Por seguridad, debe crear una contraseña personal \r\npara continuar.";
            // 
            // lblNuevaContrasena
            // 
            lblNuevaContrasena.AutoSize = true;
            lblNuevaContrasena.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNuevaContrasena.Location = new Point(20, 99);
            lblNuevaContrasena.Name = "lblNuevaContrasena";
            lblNuevaContrasena.Size = new Size(143, 18);
            lblNuevaContrasena.TabIndex = 2;
            lblNuevaContrasena.Text = "Nueva contraseña";
            // 
            // txtNuevaContrasena
            // 
            txtNuevaContrasena.BorderStyle = BorderStyle.None;
            txtNuevaContrasena.Location = new Point(20, 131);
            txtNuevaContrasena.Name = "txtNuevaContrasena";
            txtNuevaContrasena.PlaceholderText = "Ingrese su Nueva Contraseña...";
            txtNuevaContrasena.Size = new Size(474, 19);
            txtNuevaContrasena.TabIndex = 3;
            txtNuevaContrasena.UseSystemPasswordChar = true;
            // 
            // pnlLinea
            // 
            pnlLinea.BackColor = Color.MidnightBlue;
            pnlLinea.Location = new Point(21, 154);
            pnlLinea.Name = "pnlLinea";
            pnlLinea.Size = new Size(474, 2);
            pnlLinea.TabIndex = 5;
            // 
            // btnMostrarContrasena
            // 
            btnMostrarContrasena.BackColor = Color.Transparent;
            btnMostrarContrasena.Cursor = Cursors.Hand;
            btnMostrarContrasena.FlatAppearance.BorderSize = 0;
            btnMostrarContrasena.FlatStyle = FlatStyle.Flat;
            btnMostrarContrasena.Location = new Point(459, 126);
            btnMostrarContrasena.Name = "btnMostrarContrasena";
            btnMostrarContrasena.Size = new Size(40, 29);
            btnMostrarContrasena.TabIndex = 6;
            btnMostrarContrasena.TabStop = false;
            btnMostrarContrasena.Text = "👁";
            btnMostrarContrasena.UseVisualStyleBackColor = false;
            // 
            // lblConfirmarContrasena
            // 
            lblConfirmarContrasena.AutoSize = true;
            lblConfirmarContrasena.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConfirmarContrasena.Location = new Point(20, 182);
            lblConfirmarContrasena.Name = "lblConfirmarContrasena";
            lblConfirmarContrasena.Size = new Size(218, 18);
            lblConfirmarContrasena.TabIndex = 7;
            lblConfirmarContrasena.Text = "Confirmar nueva contraseña";
            // 
            // txtConfirmarContrasena
            // 
            txtConfirmarContrasena.BorderStyle = BorderStyle.None;
            txtConfirmarContrasena.Location = new Point(21, 216);
            txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            txtConfirmarContrasena.PlaceholderText = "Confirme la Nueva Contraseña...";
            txtConfirmarContrasena.Size = new Size(474, 19);
            txtConfirmarContrasena.TabIndex = 8;
            // 
            // pnlLine
            // 
            pnlLine.BackColor = Color.MidnightBlue;
            pnlLine.Location = new Point(20, 239);
            pnlLine.Name = "pnlLine";
            pnlLine.Size = new Size(474, 2);
            pnlLine.TabIndex = 6;
            // 
            // btnMostrarConfirmacion
            // 
            btnMostrarConfirmacion.BackColor = Color.Transparent;
            btnMostrarConfirmacion.Cursor = Cursors.Hand;
            btnMostrarConfirmacion.FlatAppearance.BorderSize = 0;
            btnMostrarConfirmacion.FlatStyle = FlatStyle.Flat;
            btnMostrarConfirmacion.Location = new Point(459, 213);
            btnMostrarConfirmacion.Name = "btnMostrarConfirmacion";
            btnMostrarConfirmacion.Size = new Size(40, 29);
            btnMostrarConfirmacion.TabIndex = 9;
            btnMostrarConfirmacion.TabStop = false;
            btnMostrarConfirmacion.Text = "👁";
            btnMostrarConfirmacion.UseVisualStyleBackColor = false;
            // 
            // lblRequisitosTitulo
            // 
            lblRequisitosTitulo.AutoSize = true;
            lblRequisitosTitulo.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRequisitosTitulo.Location = new Point(20, 267);
            lblRequisitosTitulo.Name = "lblRequisitosTitulo";
            lblRequisitosTitulo.Size = new Size(242, 23);
            lblRequisitosTitulo.TabIndex = 10;
            lblRequisitosTitulo.Text = "Requisitos de seguridad";
            // 
            // lblRequisitosSubtitulo
            // 
            lblRequisitosSubtitulo.AutoSize = true;
            lblRequisitosSubtitulo.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRequisitosSubtitulo.Location = new Point(23, 293);
            lblRequisitosSubtitulo.Name = "lblRequisitosSubtitulo";
            lblRequisitosSubtitulo.Size = new Size(363, 17);
            lblRequisitosSubtitulo.TabIndex = 11;
            lblRequisitosSubtitulo.Text = "La contraseña debe cumplir las siguientes condiciones:";
            // 
            // pnlRequisitos
            // 
            pnlRequisitos.Controls.Add(lblRequisitosThree);
            pnlRequisitos.Controls.Add(lblRequisitosTwo);
            pnlRequisitos.Controls.Add(lblRequisitosOne);
            pnlRequisitos.ForeColor = Color.FromArgb(8, 31, 63);
            pnlRequisitos.Location = new Point(23, 313);
            pnlRequisitos.Name = "pnlRequisitos";
            pnlRequisitos.Padding = new Padding(5);
            pnlRequisitos.Size = new Size(471, 83);
            pnlRequisitos.TabIndex = 12;
            // 
            // lblRequisitosOne
            // 
            lblRequisitosOne.Dock = DockStyle.Top;
            lblRequisitosOne.Location = new Point(5, 5);
            lblRequisitosOne.Name = "lblRequisitosOne";
            lblRequisitosOne.Size = new Size(461, 22);
            lblRequisitosOne.TabIndex = 0;
            lblRequisitosOne.Text = "🗹 Entre 12 y 128 caracteres\r\n";
            lblRequisitosOne.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRequisitosTwo
            // 
            lblRequisitosTwo.Dock = DockStyle.Top;
            lblRequisitosTwo.Location = new Point(5, 27);
            lblRequisitosTwo.Name = "lblRequisitosTwo";
            lblRequisitosTwo.Size = new Size(461, 25);
            lblRequisitosTwo.TabIndex = 1;
            lblRequisitosTwo.Text = "🗹 Mayúsculas y minúsculas";
            lblRequisitosTwo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRequisitosThree
            // 
            lblRequisitosThree.Dock = DockStyle.Top;
            lblRequisitosThree.Location = new Point(5, 52);
            lblRequisitosThree.Name = "lblRequisitosThree";
            lblRequisitosThree.Size = new Size(461, 25);
            lblRequisitosThree.TabIndex = 2;
            lblRequisitosThree.Text = "🗹 Al menos un número y un símbolo";
            lblRequisitosThree.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmCambioContrasenaInicial
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(550, 550);
            Controls.Add(pnlFooter);
            Controls.Add(pnlContenido);
            Controls.Add(pnlHeader);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmCambioContrasenaInicial";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmCambioContrasenaInicial";
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.picIcono).EndInit();
            pnlContenido.ResumeLayout(false);
            pnlContenido.PerformLayout();
            pnlFooter.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            pnlRequisitos.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitulo;
        private Button btnClose;
        private PictureBox picIcon;
        private Label lblSubtitulo;
        private Panel pnlContenido;
        private Label lblMessage;
        private Panel pnlFooter;
        private Panel pnlButtons;
        private Button btnAccept;
        private Button btnCancelar;
        private Label lblNombreUsuario;
        private Label lblInstruccion;
        private Label lblNuevaContrasena;
        private TextBox txtNuevaContrasena;
        private Panel pnlLinea;
        private Button btnMostrarContrasena;
        private Label lblConfirmarContrasena;
        private TextBox txtConfirmarContrasena;
        private Label lblRequisitosTitulo;
        private Panel pnlLine;
        private Button btnMostrarConfirmacion;
        private Panel pnlRequisitos;
        private Label lblRequisitosOne;
        private Label lblRequisitosSubtitulo;
        private Label lblRequisitosThree;
        private Label lblRequisitosTwo;
    }
}