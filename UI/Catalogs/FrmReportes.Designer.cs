namespace Ocean_Desk_dv.UI.Catalogs
{
    partial class FrmReportes
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
            pnlHeaderReportes = new Panel();
            lblTituloReportes = new Label();
            lblSubtituloReportes = new Label();
            pnlIndicadores = new Panel();
            tblIndicadores = new TableLayoutPanel();
            pnlVentasHoy = new Panel();
            lblTituloVentas = new Label();
            lblVentasHoy = new Label();
            lblDetalleVentas = new Label();
            pnlIngresos = new Panel();
            lblDetalleIngresos = new Label();
            lblIngresos = new Label();
            lblTituloIngresos = new Label();
            pnlProductos = new Panel();
            lblDetalleProductos = new Label();
            lblProductos = new Label();
            lblTituloProductos = new Label();
            pnlStockBajo = new Panel();
            lblDetalleStock = new Label();
            lblStockBajo = new Label();
            lblTituloStock = new Label();
            pnlHeaderReportes.SuspendLayout();
            pnlIndicadores.SuspendLayout();
            tblIndicadores.SuspendLayout();
            pnlVentasHoy.SuspendLayout();
            pnlIngresos.SuspendLayout();
            pnlProductos.SuspendLayout();
            pnlStockBajo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeaderReportes
            // 
            pnlHeaderReportes.BackColor = Color.Transparent;
            pnlHeaderReportes.Controls.Add(lblSubtituloReportes);
            pnlHeaderReportes.Controls.Add(lblTituloReportes);
            pnlHeaderReportes.Dock = DockStyle.Top;
            pnlHeaderReportes.Location = new Point(0, 0);
            pnlHeaderReportes.Name = "pnlHeaderReportes";
            pnlHeaderReportes.Size = new Size(940, 70);
            pnlHeaderReportes.TabIndex = 0;
            // 
            // lblTituloReportes
            // 
            lblTituloReportes.AutoSize = true;
            lblTituloReportes.Dock = DockStyle.Top;
            lblTituloReportes.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloReportes.ForeColor = Color.FromArgb(18, 48, 71);
            lblTituloReportes.Location = new Point(0, 0);
            lblTituloReportes.Name = "lblTituloReportes";
            lblTituloReportes.Size = new Size(383, 40);
            lblTituloReportes.TabIndex = 0;
            lblTituloReportes.Text = "Resumen del Negocio";
            // 
            // lblSubtituloReportes
            // 
            lblSubtituloReportes.AutoSize = true;
            lblSubtituloReportes.Dock = DockStyle.Top;
            lblSubtituloReportes.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtituloReportes.ForeColor = Color.FromArgb(107, 124, 135);
            lblSubtituloReportes.Location = new Point(0, 40);
            lblSubtituloReportes.Name = "lblSubtituloReportes";
            lblSubtituloReportes.Size = new Size(305, 20);
            lblSubtituloReportes.TabIndex = 1;
            lblSubtituloReportes.Text = "  Indicadores y comportamiento general";
            // 
            // pnlIndicadores
            // 
            pnlIndicadores.BackColor = Color.Transparent;
            pnlIndicadores.Controls.Add(tblIndicadores);
            pnlIndicadores.Dock = DockStyle.Top;
            pnlIndicadores.Location = new Point(0, 70);
            pnlIndicadores.Name = "pnlIndicadores";
            pnlIndicadores.Size = new Size(940, 125);
            pnlIndicadores.TabIndex = 1;
            // 
            // tblIndicadores
            // 
            tblIndicadores.BackColor = Color.Transparent;
            tblIndicadores.ColumnCount = 4;
            tblIndicadores.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblIndicadores.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblIndicadores.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblIndicadores.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblIndicadores.Controls.Add(pnlStockBajo, 3, 0);
            tblIndicadores.Controls.Add(pnlProductos, 2, 0);
            tblIndicadores.Controls.Add(pnlIngresos, 1, 0);
            tblIndicadores.Controls.Add(pnlVentasHoy, 0, 0);
            tblIndicadores.Dock = DockStyle.Fill;
            tblIndicadores.Location = new Point(0, 0);
            tblIndicadores.Name = "tblIndicadores";
            tblIndicadores.Padding = new Padding(0, 5, 0, 5);
            tblIndicadores.RowCount = 1;
            tblIndicadores.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblIndicadores.Size = new Size(940, 125);
            tblIndicadores.TabIndex = 2;
            // 
            // pnlVentasHoy
            // 
            pnlVentasHoy.BackColor = Color.White;
            pnlVentasHoy.Controls.Add(lblDetalleVentas);
            pnlVentasHoy.Controls.Add(lblVentasHoy);
            pnlVentasHoy.Controls.Add(lblTituloVentas);
            pnlVentasHoy.Dock = DockStyle.Fill;
            pnlVentasHoy.Location = new Point(6, 10);
            pnlVentasHoy.Margin = new Padding(6, 5, 6, 5);
            pnlVentasHoy.Name = "pnlVentasHoy";
            pnlVentasHoy.Padding = new Padding(15);
            pnlVentasHoy.Size = new Size(223, 105);
            pnlVentasHoy.TabIndex = 0;
            // 
            // lblTituloVentas
            // 
            lblTituloVentas.AutoSize = true;
            lblTituloVentas.Dock = DockStyle.Top;
            lblTituloVentas.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloVentas.ForeColor = Color.FromArgb(107, 124, 135);
            lblTituloVentas.Location = new Point(15, 15);
            lblTituloVentas.Name = "lblTituloVentas";
            lblTituloVentas.Size = new Size(133, 21);
            lblTituloVentas.TabIndex = 0;
            lblTituloVentas.Text = "Ventas del día";
            // 
            // lblVentasHoy
            // 
            lblVentasHoy.Dock = DockStyle.Top;
            lblVentasHoy.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVentasHoy.ForeColor = Color.FromArgb(18, 48, 71);
            lblVentasHoy.Location = new Point(15, 36);
            lblVentasHoy.Name = "lblVentasHoy";
            lblVentasHoy.Size = new Size(193, 38);
            lblVentasHoy.TabIndex = 1;
            lblVentasHoy.Text = "C$ 0.00";
            lblVentasHoy.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDetalleVentas
            // 
            lblDetalleVentas.AutoSize = true;
            lblDetalleVentas.Dock = DockStyle.Top;
            lblDetalleVentas.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDetalleVentas.ForeColor = Color.FromArgb(138, 154, 165);
            lblDetalleVentas.Location = new Point(15, 74);
            lblDetalleVentas.Name = "lblDetalleVentas";
            lblDetalleVentas.Size = new Size(135, 17);
            lblDetalleVentas.TabIndex = 2;
            lblDetalleVentas.Text = "Total registrado hoy";
            // 
            // pnlIngresos
            // 
            pnlIngresos.BackColor = Color.White;
            pnlIngresos.Controls.Add(lblDetalleIngresos);
            pnlIngresos.Controls.Add(lblIngresos);
            pnlIngresos.Controls.Add(lblTituloIngresos);
            pnlIngresos.Dock = DockStyle.Fill;
            pnlIngresos.Location = new Point(241, 10);
            pnlIngresos.Margin = new Padding(6, 5, 6, 5);
            pnlIngresos.Name = "pnlIngresos";
            pnlIngresos.Padding = new Padding(15);
            pnlIngresos.Size = new Size(223, 105);
            pnlIngresos.TabIndex = 1;
            // 
            // lblDetalleIngresos
            // 
            lblDetalleIngresos.AutoSize = true;
            lblDetalleIngresos.Dock = DockStyle.Top;
            lblDetalleIngresos.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDetalleIngresos.ForeColor = Color.FromArgb(138, 154, 165);
            lblDetalleIngresos.Location = new Point(15, 74);
            lblDetalleIngresos.Name = "lblDetalleIngresos";
            lblDetalleIngresos.Size = new Size(163, 17);
            lblDetalleIngresos.TabIndex = 2;
            lblDetalleIngresos.Text = "Acumulado del período";
            // 
            // lblIngresos
            // 
            lblIngresos.Dock = DockStyle.Top;
            lblIngresos.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIngresos.ForeColor = Color.FromArgb(8, 126, 164);
            lblIngresos.Location = new Point(15, 36);
            lblIngresos.Name = "lblIngresos";
            lblIngresos.Size = new Size(193, 38);
            lblIngresos.TabIndex = 1;
            lblIngresos.Text = "C$ 0.00";
            lblIngresos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTituloIngresos
            // 
            lblTituloIngresos.AutoSize = true;
            lblTituloIngresos.Dock = DockStyle.Top;
            lblTituloIngresos.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloIngresos.ForeColor = Color.FromArgb(107, 124, 135);
            lblTituloIngresos.Location = new Point(15, 15);
            lblTituloIngresos.Name = "lblTituloIngresos";
            lblTituloIngresos.Size = new Size(77, 21);
            lblTituloIngresos.TabIndex = 0;
            lblTituloIngresos.Text = "Ingresos";
            // 
            // pnlProductos
            // 
            pnlProductos.BackColor = Color.White;
            pnlProductos.Controls.Add(lblDetalleProductos);
            pnlProductos.Controls.Add(lblProductos);
            pnlProductos.Controls.Add(lblTituloProductos);
            pnlProductos.Dock = DockStyle.Fill;
            pnlProductos.Location = new Point(476, 10);
            pnlProductos.Margin = new Padding(6, 5, 6, 5);
            pnlProductos.Name = "pnlProductos";
            pnlProductos.Padding = new Padding(15);
            pnlProductos.Size = new Size(223, 105);
            pnlProductos.TabIndex = 2;
            // 
            // lblDetalleProductos
            // 
            lblDetalleProductos.AutoSize = true;
            lblDetalleProductos.Dock = DockStyle.Top;
            lblDetalleProductos.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDetalleProductos.ForeColor = Color.FromArgb(138, 154, 165);
            lblDetalleProductos.Location = new Point(15, 74);
            lblDetalleProductos.Name = "lblDetalleProductos";
            lblDetalleProductos.Size = new Size(190, 17);
            lblDetalleProductos.TabIndex = 2;
            lblDetalleProductos.Text = "Productos y materias primas";
            // 
            // lblProductos
            // 
            lblProductos.Dock = DockStyle.Top;
            lblProductos.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductos.ForeColor = Color.FromArgb(18, 48, 71);
            lblProductos.Location = new Point(15, 36);
            lblProductos.Name = "lblProductos";
            lblProductos.Size = new Size(193, 38);
            lblProductos.TabIndex = 1;
            lblProductos.Text = "0";
            lblProductos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTituloProductos
            // 
            lblTituloProductos.AutoSize = true;
            lblTituloProductos.Dock = DockStyle.Top;
            lblTituloProductos.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloProductos.ForeColor = Color.FromArgb(107, 124, 135);
            lblTituloProductos.Location = new Point(15, 15);
            lblTituloProductos.Name = "lblTituloProductos";
            lblTituloProductos.Size = new Size(190, 21);
            lblTituloProductos.TabIndex = 0;
            lblTituloProductos.Text = "Productos registrados";
            // 
            // pnlStockBajo
            // 
            pnlStockBajo.BackColor = Color.White;
            pnlStockBajo.Controls.Add(lblDetalleStock);
            pnlStockBajo.Controls.Add(lblStockBajo);
            pnlStockBajo.Controls.Add(lblTituloStock);
            pnlStockBajo.Dock = DockStyle.Fill;
            pnlStockBajo.Location = new Point(711, 10);
            pnlStockBajo.Margin = new Padding(6, 5, 6, 5);
            pnlStockBajo.Name = "pnlStockBajo";
            pnlStockBajo.Padding = new Padding(15);
            pnlStockBajo.Size = new Size(223, 105);
            pnlStockBajo.TabIndex = 3;
            // 
            // lblDetalleStock
            // 
            lblDetalleStock.AutoSize = true;
            lblDetalleStock.Dock = DockStyle.Top;
            lblDetalleStock.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDetalleStock.ForeColor = Color.FromArgb(138, 154, 165);
            lblDetalleStock.Location = new Point(15, 74);
            lblDetalleStock.Name = "lblDetalleStock";
            lblDetalleStock.Size = new Size(140, 17);
            lblDetalleStock.TabIndex = 2;
            lblDetalleStock.Text = "Productos a reponer";
            // 
            // lblStockBajo
            // 
            lblStockBajo.Dock = DockStyle.Top;
            lblStockBajo.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStockBajo.ForeColor = Color.FromArgb(217, 140, 0);
            lblStockBajo.Location = new Point(15, 36);
            lblStockBajo.Name = "lblStockBajo";
            lblStockBajo.Size = new Size(193, 38);
            lblStockBajo.TabIndex = 1;
            lblStockBajo.Text = "0";
            lblStockBajo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTituloStock
            // 
            lblTituloStock.AutoSize = true;
            lblTituloStock.Dock = DockStyle.Top;
            lblTituloStock.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloStock.ForeColor = Color.FromArgb(107, 124, 135);
            lblTituloStock.Location = new Point(15, 15);
            lblTituloStock.Name = "lblTituloStock";
            lblTituloStock.Size = new Size(99, 21);
            lblTituloStock.TabIndex = 0;
            lblTituloStock.Text = "Stock bajo";
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 248, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(pnlIndicadores);
            Controls.Add(pnlHeaderReportes);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmReportes";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmReportes";
            pnlHeaderReportes.ResumeLayout(false);
            pnlHeaderReportes.PerformLayout();
            pnlIndicadores.ResumeLayout(false);
            tblIndicadores.ResumeLayout(false);
            pnlVentasHoy.ResumeLayout(false);
            pnlVentasHoy.PerformLayout();
            pnlIngresos.ResumeLayout(false);
            pnlIngresos.PerformLayout();
            pnlProductos.ResumeLayout(false);
            pnlProductos.PerformLayout();
            pnlStockBajo.ResumeLayout(false);
            pnlStockBajo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeaderReportes;
        private Label lblTituloReportes;
        private Label lblSubtituloReportes;
        private Panel pnlIndicadores;
        private TableLayoutPanel tblIndicadores;
        private Panel pnlVentasHoy;
        private Label lblVentasHoy;
        private Label lblTituloVentas;
        private Label lblDetalleVentas;
        private Panel pnlIngresos;
        private Label lblDetalleIngresos;
        private Label lblIngresos;
        private Label lblTituloIngresos;
        private Panel pnlStockBajo;
        private Label lblDetalleStock;
        private Label lblStockBajo;
        private Label lblTituloStock;
        private Panel pnlProductos;
        private Label lblDetalleProductos;
        private Label lblProductos;
        private Label lblTituloProductos;
    }
}