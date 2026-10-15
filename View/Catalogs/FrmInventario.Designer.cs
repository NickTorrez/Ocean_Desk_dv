namespace Ocean_Desk_dv.View.Catalogs
{
    partial class FrmInventario
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            pnlFiltros = new Panel();
            tlpFiltros = new TableLayoutPanel();
            pnlSearch = new Panel();
            pictureBox1 = new PictureBox();
            pnlInputSearch = new Panel();
            panel2 = new Panel();
            txtBuscarInventario = new TextBox();
            pnlCategoria = new Panel();
            cmbCategoriaInventario = new ComboBox();
            pnlEstado = new Panel();
            cmbEstadoStock = new ComboBox();
            pnlVencimiento = new Panel();
            cmbVencimiento = new ComboBox();
            pnlRefrescar = new Panel();
            btnRefrescarInventario = new Button();
            tcInventario = new TabControl();
            tcExistencias = new TabPage();
            dgvExistencias = new DataGridView();
            colCodigoInv = new DataGridViewTextBoxColumn();
            colProductoInv = new DataGridViewTextBoxColumn();
            colCategoriaInv = new DataGridViewTextBoxColumn();
            colUnidadInv = new DataGridViewTextBoxColumn();
            colStockActual = new DataGridViewTextBoxColumn();
            colStockMinimo = new DataGridViewTextBoxColumn();
            colEstadoStock = new DataGridViewTextBoxColumn();
            colVencimiento = new DataGridViewTextBoxColumn();
            pnlAcccionesInventario = new Panel();
            tlpButonsdgv = new TableLayoutPanel();
            pnlMerma = new Panel();
            btnRegistrarPerdida = new Button();
            pnlAjuste = new Panel();
            btnRegistrarAjuste = new Button();
            pnlSalida = new Panel();
            btnRegistrarSalida = new Button();
            pnlEntrada = new Panel();
            btnRegistrarEntrada = new Button();
            tpMovimientos = new TabPage();
            dgvMovimientos = new DataGridView();
            colFechaMov = new DataGridViewTextBoxColumn();
            colTipoMov = new DataGridViewTextBoxColumn();
            colProductoMov = new DataGridViewTextBoxColumn();
            colCantidadMov = new DataGridViewTextBoxColumn();
            colUnidadMov = new DataGridViewTextBoxColumn();
            colOrigenMov = new DataGridViewTextBoxColumn();
            colObservacionesMov = new DataGridViewTextBoxColumn();
            pnlFriltrosMovimientos = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlDesde = new Panel();
            dtpDesde = new DateTimePicker();
            pnlHasta = new Panel();
            dtpHasta = new DateTimePicker();
            pnlMovimiento = new Panel();
            cmbTipoMovimiento = new ComboBox();
            pnlContainerTab = new Panel();
            pnlFiltros.SuspendLayout();
            tlpFiltros.SuspendLayout();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlInputSearch.SuspendLayout();
            pnlCategoria.SuspendLayout();
            pnlEstado.SuspendLayout();
            pnlVencimiento.SuspendLayout();
            pnlRefrescar.SuspendLayout();
            tcInventario.SuspendLayout();
            tcExistencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExistencias).BeginInit();
            pnlAcccionesInventario.SuspendLayout();
            tlpButonsdgv.SuspendLayout();
            pnlMerma.SuspendLayout();
            pnlAjuste.SuspendLayout();
            pnlSalida.SuspendLayout();
            pnlEntrada.SuspendLayout();
            tpMovimientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            pnlFriltrosMovimientos.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlDesde.SuspendLayout();
            pnlHasta.SuspendLayout();
            pnlMovimiento.SuspendLayout();
            pnlContainerTab.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.White;
            pnlFiltros.Controls.Add(tlpFiltros);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(5, 5);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(12, 8, 12, 8);
            pnlFiltros.Size = new Size(930, 78);
            pnlFiltros.TabIndex = 0;
            // 
            // tlpFiltros
            // 
            tlpFiltros.ColumnCount = 6;
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.202847F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.5707512F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.0565987F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.0565987F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.0565987F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.0565987F));
            tlpFiltros.Controls.Add(pnlSearch, 0, 0);
            tlpFiltros.Controls.Add(pnlInputSearch, 1, 0);
            tlpFiltros.Controls.Add(pnlCategoria, 2, 0);
            tlpFiltros.Controls.Add(pnlEstado, 3, 0);
            tlpFiltros.Controls.Add(pnlVencimiento, 4, 0);
            tlpFiltros.Controls.Add(pnlRefrescar, 5, 0);
            tlpFiltros.Dock = DockStyle.Fill;
            tlpFiltros.Location = new Point(12, 8);
            tlpFiltros.Margin = new Padding(0);
            tlpFiltros.Name = "tlpFiltros";
            tlpFiltros.RowCount = 1;
            tlpFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpFiltros.Size = new Size(906, 62);
            tlpFiltros.TabIndex = 0;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(pictureBox1);
            pnlSearch.Dock = DockStyle.Fill;
            pnlSearch.Location = new Point(3, 3);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Padding = new Padding(5, 9, 0, 9);
            pnlSearch.Size = new Size(41, 56);
            pnlSearch.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.search_32;
            pictureBox1.Location = new Point(5, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(36, 38);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pnlInputSearch
            // 
            pnlInputSearch.Controls.Add(panel2);
            pnlInputSearch.Controls.Add(txtBuscarInventario);
            pnlInputSearch.Dock = DockStyle.Fill;
            pnlInputSearch.Location = new Point(50, 3);
            pnlInputSearch.Name = "pnlInputSearch";
            pnlInputSearch.Padding = new Padding(3, 10, 3, 20);
            pnlInputSearch.Size = new Size(198, 56);
            pnlInputSearch.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MidnightBlue;
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(3, 34);
            panel2.Name = "panel2";
            panel2.Size = new Size(192, 2);
            panel2.TabIndex = 16;
            // 
            // txtBuscarInventario
            // 
            txtBuscarInventario.BorderStyle = BorderStyle.None;
            txtBuscarInventario.Dock = DockStyle.Top;
            txtBuscarInventario.Font = new Font("Century Gothic", 10.2F);
            txtBuscarInventario.Location = new Point(3, 10);
            txtBuscarInventario.MaxLength = 150;
            txtBuscarInventario.Name = "txtBuscarInventario";
            txtBuscarInventario.PlaceholderText = "Buscar insumo...";
            txtBuscarInventario.Size = new Size(192, 21);
            txtBuscarInventario.TabIndex = 0;
            // 
            // pnlCategoria
            // 
            pnlCategoria.Controls.Add(cmbCategoriaInventario);
            pnlCategoria.Dock = DockStyle.Fill;
            pnlCategoria.Location = new Point(254, 3);
            pnlCategoria.Name = "pnlCategoria";
            pnlCategoria.Padding = new Padding(10);
            pnlCategoria.Size = new Size(157, 56);
            pnlCategoria.TabIndex = 2;
            // 
            // cmbCategoriaInventario
            // 
            cmbCategoriaInventario.Dock = DockStyle.Fill;
            cmbCategoriaInventario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoriaInventario.FormattingEnabled = true;
            cmbCategoriaInventario.Location = new Point(10, 10);
            cmbCategoriaInventario.Name = "cmbCategoriaInventario";
            cmbCategoriaInventario.Size = new Size(137, 28);
            cmbCategoriaInventario.TabIndex = 1;
            // 
            // pnlEstado
            // 
            pnlEstado.Controls.Add(cmbEstadoStock);
            pnlEstado.Dock = DockStyle.Fill;
            pnlEstado.Location = new Point(417, 3);
            pnlEstado.Name = "pnlEstado";
            pnlEstado.Padding = new Padding(10);
            pnlEstado.Size = new Size(157, 56);
            pnlEstado.TabIndex = 3;
            // 
            // cmbEstadoStock
            // 
            cmbEstadoStock.Dock = DockStyle.Fill;
            cmbEstadoStock.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoStock.FormattingEnabled = true;
            cmbEstadoStock.Items.AddRange(new object[] { "Todos", "Normal", "Bajo", "Agotado" });
            cmbEstadoStock.Location = new Point(10, 10);
            cmbEstadoStock.Name = "cmbEstadoStock";
            cmbEstadoStock.Size = new Size(137, 28);
            cmbEstadoStock.TabIndex = 2;
            // 
            // pnlVencimiento
            // 
            pnlVencimiento.Controls.Add(cmbVencimiento);
            pnlVencimiento.Dock = DockStyle.Fill;
            pnlVencimiento.Location = new Point(580, 3);
            pnlVencimiento.Name = "pnlVencimiento";
            pnlVencimiento.Padding = new Padding(10);
            pnlVencimiento.Size = new Size(157, 56);
            pnlVencimiento.TabIndex = 4;
            // 
            // cmbVencimiento
            // 
            cmbVencimiento.Dock = DockStyle.Fill;
            cmbVencimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVencimiento.FormattingEnabled = true;
            cmbVencimiento.Items.AddRange(new object[] { "Todos", "Próximos a vencer ", "Vencidos" });
            cmbVencimiento.Location = new Point(10, 10);
            cmbVencimiento.Name = "cmbVencimiento";
            cmbVencimiento.Size = new Size(137, 28);
            cmbVencimiento.TabIndex = 3;
            // 
            // pnlRefrescar
            // 
            pnlRefrescar.Controls.Add(btnRefrescarInventario);
            pnlRefrescar.Dock = DockStyle.Fill;
            pnlRefrescar.Location = new Point(743, 3);
            pnlRefrescar.Name = "pnlRefrescar";
            pnlRefrescar.Padding = new Padding(5);
            pnlRefrescar.Size = new Size(160, 56);
            pnlRefrescar.TabIndex = 5;
            // 
            // btnRefrescarInventario
            // 
            btnRefrescarInventario.BackColor = Color.FromArgb(8, 126, 164);
            btnRefrescarInventario.Dock = DockStyle.Fill;
            btnRefrescarInventario.FlatAppearance.BorderSize = 0;
            btnRefrescarInventario.FlatStyle = FlatStyle.Flat;
            btnRefrescarInventario.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefrescarInventario.ForeColor = Color.White;
            btnRefrescarInventario.Location = new Point(5, 5);
            btnRefrescarInventario.Name = "btnRefrescarInventario";
            btnRefrescarInventario.Size = new Size(150, 46);
            btnRefrescarInventario.TabIndex = 4;
            btnRefrescarInventario.Text = "Refrescar";
            btnRefrescarInventario.UseVisualStyleBackColor = false;
            // 
            // tcInventario
            // 
            tcInventario.Controls.Add(tcExistencias);
            tcInventario.Controls.Add(tpMovimientos);
            tcInventario.Dock = DockStyle.Fill;
            tcInventario.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tcInventario.Location = new Point(0, 7);
            tcInventario.Name = "tcInventario";
            tcInventario.Padding = new Point(12, 8);
            tcInventario.SelectedIndex = 0;
            tcInventario.Size = new Size(930, 735);
            tcInventario.TabIndex = 1;
            // 
            // tcExistencias
            // 
            tcExistencias.Controls.Add(dgvExistencias);
            tcExistencias.Controls.Add(pnlAcccionesInventario);
            tcExistencias.Location = new Point(4, 38);
            tcExistencias.Name = "tcExistencias";
            tcExistencias.Padding = new Padding(3);
            tcExistencias.Size = new Size(922, 693);
            tcExistencias.TabIndex = 0;
            tcExistencias.Text = "Existencias";
            tcExistencias.UseVisualStyleBackColor = true;
            // 
            // dgvExistencias
            // 
            dgvExistencias.AllowUserToAddRows = false;
            dgvExistencias.AllowUserToDeleteRows = false;
            dgvExistencias.AllowUserToOrderColumns = true;
            dgvExistencias.AllowUserToResizeColumns = false;
            dgvExistencias.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvExistencias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvExistencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExistencias.BorderStyle = BorderStyle.None;
            dgvExistencias.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvExistencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvExistencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExistencias.Columns.AddRange(new DataGridViewColumn[] { colCodigoInv, colProductoInv, colCategoriaInv, colUnidadInv, colStockActual, colStockMinimo, colEstadoStock, colVencimiento });
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = Color.White;
            dataGridViewCellStyle11.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle11.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dgvExistencias.DefaultCellStyle = dataGridViewCellStyle11;
            dgvExistencias.Dock = DockStyle.Fill;
            dgvExistencias.EnableHeadersVisualStyles = false;
            dgvExistencias.GridColor = SystemColors.ControlDark;
            dgvExistencias.Location = new Point(3, 3);
            dgvExistencias.MultiSelect = false;
            dgvExistencias.Name = "dgvExistencias";
            dgvExistencias.ReadOnly = true;
            dgvExistencias.RowHeadersVisible = false;
            dgvExistencias.RowHeadersWidth = 51;
            dgvExistencias.RowTemplate.Height = 38;
            dgvExistencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExistencias.Size = new Size(916, 610);
            dgvExistencias.TabIndex = 1;
            // 
            // colCodigoInv
            // 
            colCodigoInv.DataPropertyName = "ProductCode";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCodigoInv.DefaultCellStyle = dataGridViewCellStyle3;
            colCodigoInv.FillWeight = 85F;
            colCodigoInv.HeaderText = "Código";
            colCodigoInv.MinimumWidth = 6;
            colCodigoInv.Name = "colCodigoInv";
            colCodigoInv.ReadOnly = true;
            // 
            // colProductoInv
            // 
            colProductoInv.DataPropertyName = "ProductName";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colProductoInv.DefaultCellStyle = dataGridViewCellStyle4;
            colProductoInv.FillWeight = 180F;
            colProductoInv.HeaderText = "Producto";
            colProductoInv.MinimumWidth = 6;
            colProductoInv.Name = "colProductoInv";
            colProductoInv.ReadOnly = true;
            // 
            // colCategoriaInv
            // 
            colCategoriaInv.DataPropertyName = "CategoryName";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colCategoriaInv.DefaultCellStyle = dataGridViewCellStyle5;
            colCategoriaInv.FillWeight = 110F;
            colCategoriaInv.HeaderText = "Categoria";
            colCategoriaInv.MinimumWidth = 6;
            colCategoriaInv.Name = "colCategoriaInv";
            colCategoriaInv.ReadOnly = true;
            // 
            // colUnidadInv
            // 
            colUnidadInv.DataPropertyName = "UnitName";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colUnidadInv.DefaultCellStyle = dataGridViewCellStyle6;
            colUnidadInv.FillWeight = 80F;
            colUnidadInv.HeaderText = "Unidad";
            colUnidadInv.MinimumWidth = 6;
            colUnidadInv.Name = "colUnidadInv";
            colUnidadInv.ReadOnly = true;
            // 
            // colStockActual
            // 
            colStockActual.DataPropertyName = "CurrentStock";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            colStockActual.DefaultCellStyle = dataGridViewCellStyle7;
            colStockActual.HeaderText = "StockActual";
            colStockActual.MinimumWidth = 6;
            colStockActual.Name = "colStockActual";
            colStockActual.ReadOnly = true;
            // 
            // colStockMinimo
            // 
            colStockMinimo.DataPropertyName = "MinimumStock";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.NullValue = null;
            colStockMinimo.DefaultCellStyle = dataGridViewCellStyle8;
            colStockMinimo.HeaderText = "Stock Minimo";
            colStockMinimo.MinimumWidth = 6;
            colStockMinimo.Name = "colStockMinimo";
            colStockMinimo.ReadOnly = true;
            // 
            // colEstadoStock
            // 
            colEstadoStock.DataPropertyName = "StockStatus";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEstadoStock.DefaultCellStyle = dataGridViewCellStyle9;
            colEstadoStock.FillWeight = 95F;
            colEstadoStock.HeaderText = "Estado ";
            colEstadoStock.MinimumWidth = 6;
            colEstadoStock.Name = "colEstadoStock";
            colEstadoStock.ReadOnly = true;
            // 
            // colVencimiento
            // 
            colVencimiento.DataPropertyName = "ExpirationDate";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "d";
            dataGridViewCellStyle10.NullValue = null;
            colVencimiento.DefaultCellStyle = dataGridViewCellStyle10;
            colVencimiento.FillWeight = 110F;
            colVencimiento.HeaderText = "Vencimiento";
            colVencimiento.MinimumWidth = 6;
            colVencimiento.Name = "colVencimiento";
            colVencimiento.ReadOnly = true;
            // 
            // pnlAcccionesInventario
            // 
            pnlAcccionesInventario.BackColor = Color.White;
            pnlAcccionesInventario.Controls.Add(tlpButonsdgv);
            pnlAcccionesInventario.Dock = DockStyle.Bottom;
            pnlAcccionesInventario.Location = new Point(3, 613);
            pnlAcccionesInventario.Name = "pnlAcccionesInventario";
            pnlAcccionesInventario.Padding = new Padding(10, 8, 10, 8);
            pnlAcccionesInventario.Size = new Size(916, 77);
            pnlAcccionesInventario.TabIndex = 0;
            // 
            // tlpButonsdgv
            // 
            tlpButonsdgv.ColumnCount = 4;
            tlpButonsdgv.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpButonsdgv.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpButonsdgv.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpButonsdgv.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpButonsdgv.Controls.Add(pnlMerma, 0, 0);
            tlpButonsdgv.Controls.Add(pnlAjuste, 1, 0);
            tlpButonsdgv.Controls.Add(pnlSalida, 2, 0);
            tlpButonsdgv.Controls.Add(pnlEntrada, 3, 0);
            tlpButonsdgv.Dock = DockStyle.Fill;
            tlpButonsdgv.Location = new Point(10, 8);
            tlpButonsdgv.Name = "tlpButonsdgv";
            tlpButonsdgv.RowCount = 1;
            tlpButonsdgv.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpButonsdgv.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpButonsdgv.Size = new Size(896, 61);
            tlpButonsdgv.TabIndex = 4;
            // 
            // pnlMerma
            // 
            pnlMerma.Controls.Add(btnRegistrarPerdida);
            pnlMerma.Dock = DockStyle.Fill;
            pnlMerma.Location = new Point(3, 3);
            pnlMerma.Name = "pnlMerma";
            pnlMerma.Padding = new Padding(5);
            pnlMerma.Size = new Size(218, 55);
            pnlMerma.TabIndex = 0;
            // 
            // btnRegistrarPerdida
            // 
            btnRegistrarPerdida.BackColor = Color.FromArgb(163, 61, 61);
            btnRegistrarPerdida.Dock = DockStyle.Fill;
            btnRegistrarPerdida.FlatAppearance.BorderSize = 0;
            btnRegistrarPerdida.FlatStyle = FlatStyle.Flat;
            btnRegistrarPerdida.ForeColor = Color.White;
            btnRegistrarPerdida.Location = new Point(5, 5);
            btnRegistrarPerdida.Name = "btnRegistrarPerdida";
            btnRegistrarPerdida.Size = new Size(208, 45);
            btnRegistrarPerdida.TabIndex = 3;
            btnRegistrarPerdida.Text = "Pérdida/Dañado";
            btnRegistrarPerdida.UseVisualStyleBackColor = false;
            // 
            // pnlAjuste
            // 
            pnlAjuste.Controls.Add(btnRegistrarAjuste);
            pnlAjuste.Dock = DockStyle.Fill;
            pnlAjuste.Location = new Point(227, 3);
            pnlAjuste.Name = "pnlAjuste";
            pnlAjuste.Padding = new Padding(5);
            pnlAjuste.Size = new Size(218, 55);
            pnlAjuste.TabIndex = 1;
            // 
            // btnRegistrarAjuste
            // 
            btnRegistrarAjuste.BackColor = Color.FromArgb(238, 243, 247);
            btnRegistrarAjuste.Dock = DockStyle.Fill;
            btnRegistrarAjuste.FlatAppearance.BorderSize = 0;
            btnRegistrarAjuste.FlatStyle = FlatStyle.Flat;
            btnRegistrarAjuste.ForeColor = Color.FromArgb(8, 31, 63);
            btnRegistrarAjuste.Location = new Point(5, 5);
            btnRegistrarAjuste.Name = "btnRegistrarAjuste";
            btnRegistrarAjuste.Size = new Size(208, 45);
            btnRegistrarAjuste.TabIndex = 2;
            btnRegistrarAjuste.Text = "Ajuste";
            btnRegistrarAjuste.UseVisualStyleBackColor = false;
            // 
            // pnlSalida
            // 
            pnlSalida.Controls.Add(btnRegistrarSalida);
            pnlSalida.Dock = DockStyle.Fill;
            pnlSalida.Location = new Point(451, 3);
            pnlSalida.Name = "pnlSalida";
            pnlSalida.Padding = new Padding(5);
            pnlSalida.Size = new Size(218, 55);
            pnlSalida.TabIndex = 2;
            // 
            // btnRegistrarSalida
            // 
            btnRegistrarSalida.BackColor = Color.FromArgb(217, 119, 6);
            btnRegistrarSalida.Dock = DockStyle.Fill;
            btnRegistrarSalida.FlatAppearance.BorderSize = 0;
            btnRegistrarSalida.FlatStyle = FlatStyle.Flat;
            btnRegistrarSalida.ForeColor = Color.White;
            btnRegistrarSalida.Location = new Point(5, 5);
            btnRegistrarSalida.Name = "btnRegistrarSalida";
            btnRegistrarSalida.Size = new Size(208, 45);
            btnRegistrarSalida.TabIndex = 1;
            btnRegistrarSalida.Text = "Salida";
            btnRegistrarSalida.UseVisualStyleBackColor = false;
            // 
            // pnlEntrada
            // 
            pnlEntrada.Controls.Add(btnRegistrarEntrada);
            pnlEntrada.Dock = DockStyle.Fill;
            pnlEntrada.Location = new Point(675, 3);
            pnlEntrada.Name = "pnlEntrada";
            pnlEntrada.Padding = new Padding(5);
            pnlEntrada.Size = new Size(218, 55);
            pnlEntrada.TabIndex = 3;
            // 
            // btnRegistrarEntrada
            // 
            btnRegistrarEntrada.BackColor = Color.FromArgb(8, 126, 164);
            btnRegistrarEntrada.Dock = DockStyle.Fill;
            btnRegistrarEntrada.FlatAppearance.BorderSize = 0;
            btnRegistrarEntrada.FlatStyle = FlatStyle.Flat;
            btnRegistrarEntrada.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrarEntrada.ForeColor = Color.White;
            btnRegistrarEntrada.Location = new Point(5, 5);
            btnRegistrarEntrada.Name = "btnRegistrarEntrada";
            btnRegistrarEntrada.Size = new Size(208, 45);
            btnRegistrarEntrada.TabIndex = 0;
            btnRegistrarEntrada.Text = "Entrada";
            btnRegistrarEntrada.UseVisualStyleBackColor = false;
            // 
            // tpMovimientos
            // 
            tpMovimientos.Controls.Add(dgvMovimientos);
            tpMovimientos.Controls.Add(pnlFriltrosMovimientos);
            tpMovimientos.Location = new Point(4, 38);
            tpMovimientos.Name = "tpMovimientos";
            tpMovimientos.Padding = new Padding(3);
            tpMovimientos.Size = new Size(922, 693);
            tpMovimientos.TabIndex = 1;
            tpMovimientos.Text = "Movimientos";
            tpMovimientos.UseVisualStyleBackColor = true;
            // 
            // dgvMovimientos
            // 
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.AllowUserToResizeRows = false;
            dataGridViewCellStyle12.BackColor = Color.FromArgb(248, 250, 252);
            dgvMovimientos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimientos.BackgroundColor = Color.FromArgb(230, 234, 238);
            dgvMovimientos.BorderStyle = BorderStyle.None;
            dgvMovimientos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle13.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle13.ForeColor = Color.White;
            dataGridViewCellStyle13.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            dgvMovimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dgvMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimientos.Columns.AddRange(new DataGridViewColumn[] { colFechaMov, colTipoMov, colProductoMov, colCantidadMov, colUnidadMov, colOrigenMov, colObservacionesMov });
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = Color.White;
            dataGridViewCellStyle21.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle21.ForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle21.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle21.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle21.WrapMode = DataGridViewTriState.False;
            dgvMovimientos.DefaultCellStyle = dataGridViewCellStyle21;
            dgvMovimientos.Dock = DockStyle.Fill;
            dgvMovimientos.EnableHeadersVisualStyles = false;
            dgvMovimientos.GridColor = Color.FromArgb(230, 234, 238);
            dgvMovimientos.Location = new Point(3, 65);
            dgvMovimientos.MultiSelect = false;
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.RowHeadersWidth = 51;
            dgvMovimientos.RowTemplate.Height = 38;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.Size = new Size(916, 625);
            dgvMovimientos.TabIndex = 1;
            // 
            // colFechaMov
            // 
            colFechaMov.DataPropertyName = "MovementDataTime";
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Format = "g";
            dataGridViewCellStyle14.NullValue = null;
            colFechaMov.DefaultCellStyle = dataGridViewCellStyle14;
            colFechaMov.FillWeight = 105F;
            colFechaMov.HeaderText = "Fecha";
            colFechaMov.MinimumWidth = 6;
            colFechaMov.Name = "colFechaMov";
            colFechaMov.ReadOnly = true;
            // 
            // colTipoMov
            // 
            colTipoMov.DataPropertyName = "MovementType";
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTipoMov.DefaultCellStyle = dataGridViewCellStyle15;
            colTipoMov.FillWeight = 110F;
            colTipoMov.HeaderText = "Tipo";
            colTipoMov.MinimumWidth = 6;
            colTipoMov.Name = "colTipoMov";
            colTipoMov.ReadOnly = true;
            // 
            // colProductoMov
            // 
            colProductoMov.DataPropertyName = "ProductName";
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colProductoMov.DefaultCellStyle = dataGridViewCellStyle16;
            colProductoMov.FillWeight = 180F;
            colProductoMov.HeaderText = "Producto";
            colProductoMov.MinimumWidth = 6;
            colProductoMov.Name = "colProductoMov";
            colProductoMov.ReadOnly = true;
            // 
            // colCantidadMov
            // 
            colCantidadMov.DataPropertyName = "Quantity";
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.NullValue = null;
            colCantidadMov.DefaultCellStyle = dataGridViewCellStyle17;
            colCantidadMov.HeaderText = "Cantidad";
            colCantidadMov.MinimumWidth = 6;
            colCantidadMov.Name = "colCantidadMov";
            colCantidadMov.ReadOnly = true;
            // 
            // colUnidadMov
            // 
            colUnidadMov.DataPropertyName = "UnitName";
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colUnidadMov.DefaultCellStyle = dataGridViewCellStyle18;
            colUnidadMov.FillWeight = 80F;
            colUnidadMov.HeaderText = "Unidad";
            colUnidadMov.MinimumWidth = 6;
            colUnidadMov.Name = "colUnidadMov";
            colUnidadMov.ReadOnly = true;
            // 
            // colOrigenMov
            // 
            colOrigenMov.DataPropertyName = "Source";
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colOrigenMov.DefaultCellStyle = dataGridViewCellStyle19;
            colOrigenMov.FillWeight = 120F;
            colOrigenMov.HeaderText = "Origen";
            colOrigenMov.MinimumWidth = 6;
            colOrigenMov.Name = "colOrigenMov";
            colOrigenMov.ReadOnly = true;
            // 
            // colObservacionesMov
            // 
            colObservacionesMov.DataPropertyName = "Notes";
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colObservacionesMov.DefaultCellStyle = dataGridViewCellStyle20;
            colObservacionesMov.FillWeight = 220F;
            colObservacionesMov.HeaderText = "Observaciones";
            colObservacionesMov.MinimumWidth = 6;
            colObservacionesMov.Name = "colObservacionesMov";
            colObservacionesMov.ReadOnly = true;
            // 
            // pnlFriltrosMovimientos
            // 
            pnlFriltrosMovimientos.BackColor = Color.White;
            pnlFriltrosMovimientos.Controls.Add(tableLayoutPanel1);
            pnlFriltrosMovimientos.Dock = DockStyle.Top;
            pnlFriltrosMovimientos.Location = new Point(3, 3);
            pnlFriltrosMovimientos.Name = "pnlFriltrosMovimientos";
            pnlFriltrosMovimientos.Padding = new Padding(10, 8, 10, 8);
            pnlFriltrosMovimientos.Size = new Size(916, 62);
            pnlFriltrosMovimientos.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(pnlDesde, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlHasta, 1, 0);
            tableLayoutPanel1.Controls.Add(pnlMovimiento, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(10, 8);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(896, 46);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlDesde
            // 
            pnlDesde.Controls.Add(dtpDesde);
            pnlDesde.Dock = DockStyle.Fill;
            pnlDesde.Location = new Point(3, 3);
            pnlDesde.Name = "pnlDesde";
            pnlDesde.Padding = new Padding(5, 5, 5, 0);
            pnlDesde.Size = new Size(292, 40);
            pnlDesde.TabIndex = 0;
            // 
            // dtpDesde
            // 
            dtpDesde.Dock = DockStyle.Fill;
            dtpDesde.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(5, 5);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(282, 28);
            dtpDesde.TabIndex = 0;
            // 
            // pnlHasta
            // 
            pnlHasta.Controls.Add(dtpHasta);
            pnlHasta.Dock = DockStyle.Fill;
            pnlHasta.Location = new Point(301, 3);
            pnlHasta.Name = "pnlHasta";
            pnlHasta.Padding = new Padding(5, 5, 5, 0);
            pnlHasta.Size = new Size(292, 40);
            pnlHasta.TabIndex = 1;
            // 
            // dtpHasta
            // 
            dtpHasta.Dock = DockStyle.Fill;
            dtpHasta.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(5, 5);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(282, 28);
            dtpHasta.TabIndex = 1;
            // 
            // pnlMovimiento
            // 
            pnlMovimiento.Controls.Add(cmbTipoMovimiento);
            pnlMovimiento.Dock = DockStyle.Fill;
            pnlMovimiento.Location = new Point(599, 3);
            pnlMovimiento.Name = "pnlMovimiento";
            pnlMovimiento.Padding = new Padding(5, 5, 5, 0);
            pnlMovimiento.Size = new Size(294, 40);
            pnlMovimiento.TabIndex = 2;
            // 
            // cmbTipoMovimiento
            // 
            cmbTipoMovimiento.Dock = DockStyle.Fill;
            cmbTipoMovimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoMovimiento.FormattingEnabled = true;
            cmbTipoMovimiento.Items.AddRange(new object[] { "Todos", "", "Entrada", "", "Salida", "", "Ajuste", "", "Pérdida/Dañado", "", "Compra", "", "Venta" });
            cmbTipoMovimiento.Location = new Point(5, 5);
            cmbTipoMovimiento.Name = "cmbTipoMovimiento";
            cmbTipoMovimiento.Size = new Size(284, 27);
            cmbTipoMovimiento.TabIndex = 2;
            // 
            // pnlContainerTab
            // 
            pnlContainerTab.Controls.Add(tcInventario);
            pnlContainerTab.Dock = DockStyle.Fill;
            pnlContainerTab.Location = new Point(5, 83);
            pnlContainerTab.Name = "pnlContainerTab";
            pnlContainerTab.Padding = new Padding(0, 7, 0, 0);
            pnlContainerTab.Size = new Size(930, 742);
            pnlContainerTab.TabIndex = 2;
            // 
            // FrmInventario
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(pnlContainerTab);
            Controls.Add(pnlFiltros);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmInventario";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmInventario";
            pnlFiltros.ResumeLayout(false);
            tlpFiltros.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlInputSearch.ResumeLayout(false);
            pnlInputSearch.PerformLayout();
            pnlCategoria.ResumeLayout(false);
            pnlEstado.ResumeLayout(false);
            pnlVencimiento.ResumeLayout(false);
            pnlRefrescar.ResumeLayout(false);
            tcInventario.ResumeLayout(false);
            tcExistencias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExistencias).EndInit();
            pnlAcccionesInventario.ResumeLayout(false);
            tlpButonsdgv.ResumeLayout(false);
            pnlMerma.ResumeLayout(false);
            pnlAjuste.ResumeLayout(false);
            pnlSalida.ResumeLayout(false);
            pnlEntrada.ResumeLayout(false);
            tpMovimientos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            pnlFriltrosMovimientos.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            pnlDesde.ResumeLayout(false);
            pnlHasta.ResumeLayout(false);
            pnlMovimiento.ResumeLayout(false);
            pnlContainerTab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFiltros;
        private TableLayoutPanel tlpFiltros;
        private TextBox txtBuscarInventario;
        private ComboBox cmbCategoriaInventario;
        private ComboBox cmbEstadoStock;
        private ComboBox cmbVencimiento;
        private Button btnRefrescarInventario;
        private TabControl tcInventario;
        private TabPage tcExistencias;
        private TabPage tpMovimientos;
        private Panel pnlAcccionesInventario;
        private Button btnRegistrarPerdida;
        private Button btnRegistrarAjuste;
        private Button btnRegistrarSalida;
        private Button btnRegistrarEntrada;
        private DataGridView dgvExistencias;
        private Panel pnlFriltrosMovimientos;
        private DateTimePicker dtpHasta;
        private DateTimePicker dtpDesde;
        private ComboBox cmbTipoMovimiento;
        private DataGridView dgvMovimientos;
        private DataGridViewTextBoxColumn colFechaMov;
        private DataGridViewTextBoxColumn colTipoMov;
        private DataGridViewTextBoxColumn colProductoMov;
        private DataGridViewTextBoxColumn colCantidadMov;
        private DataGridViewTextBoxColumn colUnidadMov;
        private DataGridViewTextBoxColumn colOrigenMov;
        private DataGridViewTextBoxColumn colObservacionesMov;
        private Panel pnlContainerTab;
        private TableLayoutPanel tlpButonsdgv;
        private Panel pnlMerma;
        private Panel pnlAjuste;
        private Panel pnlSalida;
        private Panel pnlEntrada;
        private DataGridViewTextBoxColumn colCodigoInv;
        private DataGridViewTextBoxColumn colProductoInv;
        private DataGridViewTextBoxColumn colCategoriaInv;
        private DataGridViewTextBoxColumn colUnidadInv;
        private DataGridViewTextBoxColumn colStockActual;
        private DataGridViewTextBoxColumn colStockMinimo;
        private DataGridViewTextBoxColumn colEstadoStock;
        private DataGridViewTextBoxColumn colVencimiento;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlDesde;
        private Panel pnlHasta;
        private Panel pnlMovimiento;
        private Panel pnlSearch;
        private Panel pnlInputSearch;
        private Panel pnlCategoria;
        private Panel pnlEstado;
        private Panel pnlVencimiento;
        private Panel pnlRefrescar;
        private PictureBox pictureBox1;
        private Panel panel2;
    }
}