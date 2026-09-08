namespace Ocean_Desk_dv.View.MessageBox
{
    partial class FrmTextInput
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
            pnlHeaderText = new Panel();
            lblTituloText = new Label();
            lblMensajeText = new Label();
            txtTexto = new TextBox();
            pnlLine = new Panel();
            btnCancelar = new Button();
            btnAceptar = new Button();
            pnlHeaderText.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeaderText
            // 
            pnlHeaderText.BackColor = Color.FromArgb(8, 31, 63);
            pnlHeaderText.Controls.Add(lblTituloText);
            pnlHeaderText.Dock = DockStyle.Top;
            pnlHeaderText.Location = new Point(0, 0);
            pnlHeaderText.Name = "pnlHeaderText";
            pnlHeaderText.Size = new Size(520, 55);
            pnlHeaderText.TabIndex = 0;
            // 
            // lblTituloText
            // 
            lblTituloText.AutoSize = true;
            lblTituloText.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloText.ForeColor = Color.White;
            lblTituloText.Location = new Point(18, 17);
            lblTituloText.Name = "lblTituloText";
            lblTituloText.Size = new Size(158, 22);
            lblTituloText.TabIndex = 0;
            lblTituloText.Text = "Entrada de Texto";
            // 
            // lblMensajeText
            // 
            lblMensajeText.ForeColor = Color.FromArgb(8, 31, 63);
            lblMensajeText.Location = new Point(25, 80);
            lblMensajeText.Name = "lblMensajeText";
            lblMensajeText.Size = new Size(470, 40);
            lblMensajeText.TabIndex = 1;
            lblMensajeText.Text = "Ingrese la información:";
            // 
            // txtTexto
            // 
            txtTexto.BorderStyle = BorderStyle.None;
            txtTexto.Location = new Point(25, 130);
            txtTexto.MaxLength = 200;
            txtTexto.Multiline = true;
            txtTexto.Name = "txtTexto";
            txtTexto.PlaceholderText = "Escriba aqui...";
            txtTexto.Size = new Size(470, 35);
            txtTexto.TabIndex = 2;
            // 
            // pnlLine
            // 
            pnlLine.BackColor = Color.MidnightBlue;
            pnlLine.Location = new Point(25, 156);
            pnlLine.Name = "pnlLine";
            pnlLine.Size = new Size(470, 2);
            pnlLine.TabIndex = 5;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(243, 200);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 40);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.FromArgb(8, 126, 164);
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(379, 200);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(120, 40);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FrmTextInput
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(520, 270);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(pnlLine);
            Controls.Add(txtTexto);
            Controls.Add(lblMensajeText);
            Controls.Add(pnlHeaderText);
            Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmTextInput";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmTextInput";
            pnlHeaderText.ResumeLayout(false);
            pnlHeaderText.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeaderText;
        private Label lblTituloText;
        private Label lblMensajeText;
        private TextBox txtTexto;
        private Panel pnlLine;
        private Button btnCancelar;
        private Button btnAceptar;
    }
}