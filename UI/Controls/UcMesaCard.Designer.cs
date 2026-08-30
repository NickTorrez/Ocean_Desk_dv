namespace Ocean_Desk_dv.UI.Controls
{
    partial class UcMesaCard
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            lblNumeroMesa = new Label();
            lblCapacidad = new Label();
            pnlEstado = new Panel();
            lblEstado = new Label();
            pnlEstado.SuspendLayout();
            SuspendLayout();
            // 
            // lblNumeroMesa
            // 
            lblNumeroMesa.Dock = DockStyle.Top;
            lblNumeroMesa.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumeroMesa.ForeColor = Color.FromArgb(8, 31, 63);
            lblNumeroMesa.Location = new Point(0, 0);
            lblNumeroMesa.Name = "lblNumeroMesa";
            lblNumeroMesa.Size = new Size(155, 32);
            lblNumeroMesa.TabIndex = 0;
            lblNumeroMesa.Text = "MESA 01";
            lblNumeroMesa.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCapacidad
            // 
            lblCapacidad.Dock = DockStyle.Top;
            lblCapacidad.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCapacidad.ForeColor = Color.FromArgb(111, 119, 128);
            lblCapacidad.Location = new Point(0, 32);
            lblCapacidad.Name = "lblCapacidad";
            lblCapacidad.Size = new Size(155, 25);
            lblCapacidad.TabIndex = 1;
            lblCapacidad.Text = "4 personas";
            lblCapacidad.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlEstado
            // 
            pnlEstado.BackColor = Color.Transparent;
            pnlEstado.Controls.Add(lblEstado);
            pnlEstado.Dock = DockStyle.Fill;
            pnlEstado.Location = new Point(0, 57);
            pnlEstado.Name = "pnlEstado";
            pnlEstado.Padding = new Padding(8, 2, 8, 8);
            pnlEstado.Size = new Size(155, 48);
            pnlEstado.TabIndex = 2;
            // 
            // lblEstado
            // 
            lblEstado.Dock = DockStyle.Fill;
            lblEstado.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstado.Location = new Point(8, 2);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(139, 38);
            lblEstado.TabIndex = 0;
            lblEstado.Text = "DISPONIBLE";
            lblEstado.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UcMesaCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlEstado);
            Controls.Add(lblCapacidad);
            Controls.Add(lblNumeroMesa);
            Cursor = Cursors.Hand;
            Margin = new Padding(6);
            Name = "UcMesaCard";
            Size = new Size(155, 105);
            pnlEstado.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblNumeroMesa;
        private Label lblCapacidad;
        private Panel pnlEstado;
        private Label lblEstado;
    }
}
