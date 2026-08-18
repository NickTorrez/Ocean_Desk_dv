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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            pnlHeaderReportes = new Panel();
            lblSubtituloReportes = new Label();
            lblTituloReportes = new Label();
            pnlIndicadores = new Panel();
            tblIndicadores = new TableLayoutPanel();
            pnlStockBajo = new Panel();
            lblDetalleStock = new Label();
            lblStockBajo = new Label();
            lblTituloStock = new Label();
            pnlProductos = new Panel();
            lblDetalleProductos = new Label();
            lblProductos = new Label();
            lblTituloProductos = new Label();
            pnlIngresos = new Panel();
            lblDetalleIngresos = new Label();
            lblIngresos = new Label();
            lblTituloIngresos = new Label();
            pnlVentasHoy = new Panel();
            lblDetalleVentas = new Label();
            lblVentasHoy = new Label();
            lblTituloVentas = new Label();
            pnlGraficas = new Panel();
            tblGraficas = new TableLayoutPanel();
            pnlVentasGrafica = new Panel();
            chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            lblSubtituloVentasGrafica = new Label();
            lblTituloVentasGrafica = new Label();
            pnlProductosGrafica = new Panel();
            chartProductos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            lblSubtituloProductosGrafica = new Label();
            lblTituloProductosGrafica = new Label();
            pnlFiltros = new Panel();
            tblFiltros = new TableLayoutPanel();
            btnActualizar = new Button();
            lblPeriodo = new Label();
            dtpHasta = new DateTimePicker();
            comboBox1 = new ComboBox();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            lblDesde = new Label();
            pnlHeaderReportes.SuspendLayout();
            pnlIndicadores.SuspendLayout();
            tblIndicadores.SuspendLayout();
            pnlStockBajo.SuspendLayout();
            pnlProductos.SuspendLayout();
            pnlIngresos.SuspendLayout();
            pnlVentasHoy.SuspendLayout();
            pnlGraficas.SuspendLayout();
            tblGraficas.SuspendLayout();
            pnlVentasGrafica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartVentas).BeginInit();
            pnlProductosGrafica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartProductos).BeginInit();
            pnlFiltros.SuspendLayout();
            tblFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeaderReportes
            // 
            pnlHeaderReportes.BackColor = Color.Transparent;
            pnlHeaderReportes.Controls.Add(lblSubtituloReportes);
            pnlHeaderReportes.Controls.Add(lblTituloReportes);
            pnlHeaderReportes.Dock = DockStyle.Top;
            pnlHeaderReportes.Location = new Point(8, 8);
            pnlHeaderReportes.Name = "pnlHeaderReportes";
            pnlHeaderReportes.Size = new Size(924, 70);
            pnlHeaderReportes.TabIndex = 0;
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
            // pnlIndicadores
            // 
            pnlIndicadores.BackColor = Color.Transparent;
            pnlIndicadores.Controls.Add(tblIndicadores);
            pnlIndicadores.Dock = DockStyle.Top;
            pnlIndicadores.Location = new Point(8, 133);
            pnlIndicadores.Name = "pnlIndicadores";
            pnlIndicadores.Size = new Size(924, 125);
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
            tblIndicadores.Size = new Size(924, 125);
            tblIndicadores.TabIndex = 2;
            // 
            // pnlStockBajo
            // 
            pnlStockBajo.BackColor = Color.White;
            pnlStockBajo.Controls.Add(lblDetalleStock);
            pnlStockBajo.Controls.Add(lblStockBajo);
            pnlStockBajo.Controls.Add(lblTituloStock);
            pnlStockBajo.Dock = DockStyle.Fill;
            pnlStockBajo.Location = new Point(699, 10);
            pnlStockBajo.Margin = new Padding(6, 5, 6, 5);
            pnlStockBajo.Name = "pnlStockBajo";
            pnlStockBajo.Padding = new Padding(15);
            pnlStockBajo.Size = new Size(219, 105);
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
            lblStockBajo.ForeColor = Color.Red;
            lblStockBajo.Location = new Point(15, 36);
            lblStockBajo.Name = "lblStockBajo";
            lblStockBajo.Size = new Size(189, 38);
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
            // pnlProductos
            // 
            pnlProductos.BackColor = Color.White;
            pnlProductos.Controls.Add(lblDetalleProductos);
            pnlProductos.Controls.Add(lblProductos);
            pnlProductos.Controls.Add(lblTituloProductos);
            pnlProductos.Dock = DockStyle.Fill;
            pnlProductos.Location = new Point(468, 10);
            pnlProductos.Margin = new Padding(6, 5, 6, 5);
            pnlProductos.Name = "pnlProductos";
            pnlProductos.Padding = new Padding(15);
            pnlProductos.Size = new Size(219, 105);
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
            lblProductos.Size = new Size(189, 38);
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
            // pnlIngresos
            // 
            pnlIngresos.BackColor = Color.White;
            pnlIngresos.Controls.Add(lblDetalleIngresos);
            pnlIngresos.Controls.Add(lblIngresos);
            pnlIngresos.Controls.Add(lblTituloIngresos);
            pnlIngresos.Dock = DockStyle.Fill;
            pnlIngresos.Location = new Point(237, 10);
            pnlIngresos.Margin = new Padding(6, 5, 6, 5);
            pnlIngresos.Name = "pnlIngresos";
            pnlIngresos.Padding = new Padding(15);
            pnlIngresos.Size = new Size(219, 105);
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
            lblIngresos.ForeColor = Color.YellowGreen;
            lblIngresos.Location = new Point(15, 36);
            lblIngresos.Name = "lblIngresos";
            lblIngresos.Size = new Size(189, 38);
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
            pnlVentasHoy.Size = new Size(219, 105);
            pnlVentasHoy.TabIndex = 0;
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
            // lblVentasHoy
            // 
            lblVentasHoy.Dock = DockStyle.Top;
            lblVentasHoy.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVentasHoy.ForeColor = Color.FromArgb(18, 48, 71);
            lblVentasHoy.Location = new Point(15, 36);
            lblVentasHoy.Name = "lblVentasHoy";
            lblVentasHoy.Size = new Size(189, 38);
            lblVentasHoy.TabIndex = 1;
            lblVentasHoy.Text = "C$ 0.00";
            lblVentasHoy.TextAlign = ContentAlignment.MiddleLeft;
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
            // pnlGraficas
            // 
            pnlGraficas.BackColor = Color.Transparent;
            pnlGraficas.Controls.Add(tblGraficas);
            pnlGraficas.Dock = DockStyle.Fill;
            pnlGraficas.Location = new Point(8, 258);
            pnlGraficas.Name = "pnlGraficas";
            pnlGraficas.Padding = new Padding(0, 10, 0, 10);
            pnlGraficas.Size = new Size(924, 564);
            pnlGraficas.TabIndex = 2;
            // 
            // tblGraficas
            // 
            tblGraficas.ColumnCount = 2;
            tblGraficas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblGraficas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblGraficas.Controls.Add(pnlVentasGrafica, 0, 0);
            tblGraficas.Controls.Add(pnlProductosGrafica, 1, 0);
            tblGraficas.Dock = DockStyle.Fill;
            tblGraficas.Location = new Point(0, 10);
            tblGraficas.Name = "tblGraficas";
            tblGraficas.RowCount = 1;
            tblGraficas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblGraficas.Size = new Size(924, 544);
            tblGraficas.TabIndex = 0;
            // 
            // pnlVentasGrafica
            // 
            pnlVentasGrafica.BackColor = Color.White;
            pnlVentasGrafica.Controls.Add(chartVentas);
            pnlVentasGrafica.Controls.Add(lblSubtituloVentasGrafica);
            pnlVentasGrafica.Controls.Add(lblTituloVentasGrafica);
            pnlVentasGrafica.Dock = DockStyle.Fill;
            pnlVentasGrafica.Location = new Point(6, 5);
            pnlVentasGrafica.Margin = new Padding(6, 5, 6, 5);
            pnlVentasGrafica.Name = "pnlVentasGrafica";
            pnlVentasGrafica.Padding = new Padding(15);
            pnlVentasGrafica.Size = new Size(450, 534);
            pnlVentasGrafica.TabIndex = 0;
            // 
            // chartVentas
            // 
            chartVentas.BorderlineWidth = 0;
            chartArea1.Name = "ChartArea1";
            chartVentas.ChartAreas.Add(chartArea1);
            chartVentas.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartVentas.Legends.Add(legend1);
            chartVentas.Location = new Point(15, 51);
            chartVentas.Name = "chartVentas";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartVentas.Series.Add(series1);
            chartVentas.Size = new Size(420, 468);
            chartVentas.TabIndex = 2;
            chartVentas.Text = "chart1";
            // 
            // lblSubtituloVentasGrafica
            // 
            lblSubtituloVentasGrafica.AutoSize = true;
            lblSubtituloVentasGrafica.Dock = DockStyle.Top;
            lblSubtituloVentasGrafica.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtituloVentasGrafica.ForeColor = Color.FromArgb(138, 154, 165);
            lblSubtituloVentasGrafica.Location = new Point(15, 34);
            lblSubtituloVentasGrafica.Name = "lblSubtituloVentasGrafica";
            lblSubtituloVentasGrafica.Size = new Size(293, 17);
            lblSubtituloVentasGrafica.TabIndex = 1;
            lblSubtituloVentasGrafica.Text = "Comportamiento de las ventas por período";
            // 
            // lblTituloVentasGrafica
            // 
            lblTituloVentasGrafica.AutoSize = true;
            lblTituloVentasGrafica.Dock = DockStyle.Top;
            lblTituloVentasGrafica.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloVentasGrafica.ForeColor = Color.FromArgb(18, 48, 71);
            lblTituloVentasGrafica.Location = new Point(15, 15);
            lblTituloVentasGrafica.Name = "lblTituloVentasGrafica";
            lblTituloVentasGrafica.Size = new Size(175, 19);
            lblTituloVentasGrafica.TabIndex = 0;
            lblTituloVentasGrafica.Text = "Evolución de ventas";
            // 
            // pnlProductosGrafica
            // 
            pnlProductosGrafica.BackColor = Color.White;
            pnlProductosGrafica.Controls.Add(chartProductos);
            pnlProductosGrafica.Controls.Add(lblSubtituloProductosGrafica);
            pnlProductosGrafica.Controls.Add(lblTituloProductosGrafica);
            pnlProductosGrafica.Dock = DockStyle.Fill;
            pnlProductosGrafica.Location = new Point(468, 5);
            pnlProductosGrafica.Margin = new Padding(6, 5, 6, 5);
            pnlProductosGrafica.Name = "pnlProductosGrafica";
            pnlProductosGrafica.Padding = new Padding(15);
            pnlProductosGrafica.Size = new Size(450, 534);
            pnlProductosGrafica.TabIndex = 1;
            // 
            // chartProductos
            // 
            chartProductos.BorderlineWidth = 0;
            chartArea2.Name = "ChartArea1";
            chartProductos.ChartAreas.Add(chartArea2);
            chartProductos.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            chartProductos.Legends.Add(legend2);
            chartProductos.Location = new Point(15, 51);
            chartProductos.Name = "chartProductos";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartProductos.Series.Add(series2);
            chartProductos.Size = new Size(420, 468);
            chartProductos.TabIndex = 3;
            chartProductos.Text = "chart1";
            // 
            // lblSubtituloProductosGrafica
            // 
            lblSubtituloProductosGrafica.AutoSize = true;
            lblSubtituloProductosGrafica.Dock = DockStyle.Top;
            lblSubtituloProductosGrafica.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtituloProductosGrafica.ForeColor = Color.FromArgb(138, 154, 165);
            lblSubtituloProductosGrafica.Location = new Point(15, 34);
            lblSubtituloProductosGrafica.Name = "lblSubtituloProductosGrafica";
            lblSubtituloProductosGrafica.Size = new Size(206, 17);
            lblSubtituloProductosGrafica.TabIndex = 2;
            lblSubtituloProductosGrafica.Text = "Productos con mayor rotación";
            // 
            // lblTituloProductosGrafica
            // 
            lblTituloProductosGrafica.AutoSize = true;
            lblTituloProductosGrafica.Dock = DockStyle.Top;
            lblTituloProductosGrafica.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloProductosGrafica.ForeColor = Color.FromArgb(18, 48, 71);
            lblTituloProductosGrafica.Location = new Point(15, 15);
            lblTituloProductosGrafica.Name = "lblTituloProductosGrafica";
            lblTituloProductosGrafica.Size = new Size(211, 19);
            lblTituloProductosGrafica.TabIndex = 1;
            lblTituloProductosGrafica.Text = "Productos más vendidos";
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.Transparent;
            pnlFiltros.Controls.Add(tblFiltros);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(8, 78);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(0, 5, 0, 5);
            pnlFiltros.Size = new Size(924, 55);
            pnlFiltros.TabIndex = 3;
            // 
            // tblFiltros
            // 
            tblFiltros.ColumnCount = 7;
            tblFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tblFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tblFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tblFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tblFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tblFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tblFiltros.Controls.Add(btnActualizar, 6, 0);
            tblFiltros.Controls.Add(lblPeriodo, 0, 0);
            tblFiltros.Controls.Add(dtpHasta, 5, 0);
            tblFiltros.Controls.Add(comboBox1, 1, 0);
            tblFiltros.Controls.Add(dtpDesde, 3, 0);
            tblFiltros.Controls.Add(lblHasta, 4, 0);
            tblFiltros.Controls.Add(lblDesde, 2, 0);
            tblFiltros.Dock = DockStyle.Fill;
            tblFiltros.Location = new Point(0, 5);
            tblFiltros.Margin = new Padding(0);
            tblFiltros.Name = "tblFiltros";
            tblFiltros.RowCount = 1;
            tblFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblFiltros.Size = new Size(924, 45);
            tblFiltros.TabIndex = 7;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(8, 126, 164);
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.Dock = DockStyle.Fill;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(757, 3);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(164, 39);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            // 
            // lblPeriodo
            // 
            lblPeriodo.AutoSize = true;
            lblPeriodo.Dock = DockStyle.Fill;
            lblPeriodo.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPeriodo.Location = new Point(3, 0);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new Size(86, 45);
            lblPeriodo.TabIndex = 0;
            lblPeriodo.Text = "Período:";
            lblPeriodo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpHasta
            // 
            dtpHasta.Dock = DockStyle.Fill;
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(591, 3);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.RightToLeft = RightToLeft.No;
            dtpHasta.Size = new Size(160, 27);
            dtpHasta.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Hoy", "", "Últimos 7 días", "", "Este mes", "", "Este año", "", "Personalizado" });
            comboBox1.Location = new Point(95, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(178, 28);
            comboBox1.TabIndex = 1;
            // 
            // dtpDesde
            // 
            dtpDesde.Dock = DockStyle.Fill;
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(352, 3);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.RightToLeft = RightToLeft.No;
            dtpDesde.Size = new Size(160, 27);
            dtpDesde.TabIndex = 4;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Dock = DockStyle.Fill;
            lblHasta.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHasta.Location = new Point(518, 0);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(67, 45);
            lblHasta.TabIndex = 3;
            lblHasta.Text = "Hasta:";
            lblHasta.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Dock = DockStyle.Fill;
            lblDesde.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDesde.Location = new Point(279, 0);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(67, 45);
            lblDesde.TabIndex = 2;
            lblDesde.Text = "Desde:";
            lblDesde.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 248, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(pnlGraficas);
            Controls.Add(pnlIndicadores);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlHeaderReportes);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmReportes";
            Padding = new Padding(8);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmReportes";
            Load += FrmReportes_Load;
            pnlHeaderReportes.ResumeLayout(false);
            pnlHeaderReportes.PerformLayout();
            pnlIndicadores.ResumeLayout(false);
            tblIndicadores.ResumeLayout(false);
            pnlStockBajo.ResumeLayout(false);
            pnlStockBajo.PerformLayout();
            pnlProductos.ResumeLayout(false);
            pnlProductos.PerformLayout();
            pnlIngresos.ResumeLayout(false);
            pnlIngresos.PerformLayout();
            pnlVentasHoy.ResumeLayout(false);
            pnlVentasHoy.PerformLayout();
            pnlGraficas.ResumeLayout(false);
            tblGraficas.ResumeLayout(false);
            pnlVentasGrafica.ResumeLayout(false);
            pnlVentasGrafica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartVentas).EndInit();
            pnlProductosGrafica.ResumeLayout(false);
            pnlProductosGrafica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartProductos).EndInit();
            pnlFiltros.ResumeLayout(false);
            tblFiltros.ResumeLayout(false);
            tblFiltros.PerformLayout();
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
        private Panel pnlGraficas;
        private TableLayoutPanel tblGraficas;
        private Panel pnlVentasGrafica;
        private Label lblSubtituloVentasGrafica;
        private Label lblTituloVentasGrafica;
        private Panel pnlProductosGrafica;
        private Label lblTituloProductosGrafica;
        private Label lblSubtituloProductosGrafica;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProductos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentas;
        private Panel pnlFiltros;
        private ComboBox comboBox1;
        private Label lblPeriodo;
        private Button btnActualizar;
        private DateTimePicker dtpHasta;
        private DateTimePicker dtpDesde;
        private Label lblHasta;
        private Label lblDesde;
        private TableLayoutPanel tblFiltros;
    }
}