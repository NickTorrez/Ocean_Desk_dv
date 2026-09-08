namespace Ocean_Desk_dv.View.MessageBox
{
    partial class FrmInputBox
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
            pnlHeaderInput = new Panel();
            lblTitulo = new Label();
            lblMensaje = new Label();
            nudValor = new NumericUpDown();
            btnCancelar = new Button();
            btnAceptar = new Button();
            pnlHeaderInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudValor).BeginInit();
            SuspendLayout();
            // 
            // pnlHeaderInput
            // 
            pnlHeaderInput.BackColor = Color.FromArgb(8, 31, 63);
            pnlHeaderInput.Controls.Add(lblTitulo);
            pnlHeaderInput.Dock = DockStyle.Top;
            pnlHeaderInput.Location = new Point(0, 0);
            pnlHeaderInput.Name = "pnlHeaderInput";
            pnlHeaderInput.Size = new Size(520, 55);
            pnlHeaderInput.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(18, 17);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(161, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Entrada de Datos";
            // 
            // lblMensaje
            // 
            lblMensaje.ForeColor = Color.FromArgb(8, 31, 63);
            lblMensaje.Location = new Point(25, 80);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(470, 40);
            lblMensaje.TabIndex = 1;
            lblMensaje.Text = "Ingrese el valor:";
            // 
            // nudValor
            // 
            nudValor.DecimalPlaces = 2;
            nudValor.Location = new Point(25, 125);
            nudValor.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudValor.Name = "nudValor";
            nudValor.Size = new Size(470, 28);
            nudValor.TabIndex = 2;
            nudValor.ThousandsSeparator = true;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(254, 195);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 40);
            btnCancelar.TabIndex = 3;
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
            btnAceptar.Location = new Point(388, 195);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(120, 40);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FrmInputBox
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(520, 260);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(nudValor);
            Controls.Add(lblMensaje);
            Controls.Add(pnlHeaderInput);
            Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmInputBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Entrada de Datos";
            pnlHeaderInput.ResumeLayout(false);
            pnlHeaderInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudValor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeaderInput;
        private Label lblTitulo;
        private Label lblMensaje;
        private NumericUpDown nudValor;
        private Button btnCancelar;
        private Button btnAceptar;
    }
}