namespace Ocean_Desk_dv.UI.Catalogs
{
    partial class FrmCaja
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
            pnlEstadoCaja = new Panel();
            lblEstadoTitulo = new Label();
            lblEstadoCaja = new Label();
            lblDetalleCaja = new Label();
            pnlEstadoCaja.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEstadoCaja
            // 
            pnlEstadoCaja.Controls.Add(lblDetalleCaja);
            pnlEstadoCaja.Controls.Add(lblEstadoCaja);
            pnlEstadoCaja.Controls.Add(lblEstadoTitulo);
            pnlEstadoCaja.Dock = DockStyle.Top;
            pnlEstadoCaja.Location = new Point(0, 0);
            pnlEstadoCaja.Margin = new Padding(0);
            pnlEstadoCaja.Name = "pnlEstadoCaja";
            pnlEstadoCaja.Padding = new Padding(15, 10, 15, 10);
            pnlEstadoCaja.Size = new Size(940, 70);
            pnlEstadoCaja.TabIndex = 0;
            // 
            // lblEstadoTitulo
            // 
            lblEstadoTitulo.AutoSize = true;
            lblEstadoTitulo.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstadoTitulo.ForeColor = Color.FromArgb(8, 31, 63);
            lblEstadoTitulo.Location = new Point(139, 25);
            lblEstadoTitulo.Name = "lblEstadoTitulo";
            lblEstadoTitulo.Size = new Size(111, 19);
            lblEstadoTitulo.TabIndex = 0;
            lblEstadoTitulo.Text = "Caja Actual:";
            // 
            // lblEstadoCaja
            // 
            lblEstadoCaja.BackColor = Color.FromArgb(232, 244, 238);
            lblEstadoCaja.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstadoCaja.ForeColor = Color.FromArgb(42, 122, 82);
            lblEstadoCaja.Location = new Point(305, 20);
            lblEstadoCaja.Name = "lblEstadoCaja";
            lblEstadoCaja.Size = new Size(90, 30);
            lblEstadoCaja.TabIndex = 1;
            lblEstadoCaja.Text = "ABIERTA:";
            lblEstadoCaja.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDetalleCaja
            // 
            lblDetalleCaja.Location = new Point(473, 19);
            lblDetalleCaja.Name = "lblDetalleCaja";
            lblDetalleCaja.Size = new Size(62, 25);
            lblDetalleCaja.TabIndex = 2;
            lblDetalleCaja.Text = "label3";
            // 
            // FrmCaja
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(pnlEstadoCaja);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmCaja";
            Text = "FrmCaja";
            pnlEstadoCaja.ResumeLayout(false);
            pnlEstadoCaja.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlEstadoCaja;
        private Label lblDetalleCaja;
        private Label lblEstadoCaja;
        private Label lblEstadoTitulo;
    }
}