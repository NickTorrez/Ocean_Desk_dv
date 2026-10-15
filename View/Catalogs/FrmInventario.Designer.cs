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
            txtBuscarInventario = new TextBox();
            cmbCategoriaInventario = new ComboBox();
            cmbEstadoStock = new ComboBox();
            cmbVencimiento = new ComboBox();
            btnRefrescarInventario = new Button();
            tcInventario = new TabControl();
            tcExistencias = new TabPage();
            pnlAcccionesInventario = new Panel();
            btnRegistrarEntrada = new Button();
            btnRegistrarSalida = new Button();
            btnRegistrarAjuste = new Button();
            btnRegistrarPerdida = new Button();
            dgvExistencias = new DataGridView();
            colCodigoInv = new DataGridViewTextBoxColumn();
            colProductoInv = new DataGridViewTextBoxColumn();
            colCategoriaInv = new DataGridViewTextBoxColumn();
            colUnidadInv = new DataGridViewTextBoxColumn();
            colStockActual = new DataGridViewTextBoxColumn();
            colStockMinimo = new DataGridViewTextBoxColumn();
            colEstadoStock = new DataGridViewTextBoxColumn();
            colVencimiento = new DataGridViewTextBoxColumn();
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
            cmbTipoMovimiento = new ComboBox();
            dtpHasta = new DateTimePicker();
            dtpDesde = new DateTimePicker();
            panel1 = new Panel();
            pnlFiltros.SuspendLayout();
            tlpFiltros.SuspendLayout();
            tcInventario.SuspendLayout();
            tcExistencias.SuspendLayout();
            pnlAcccionesInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExistencias).BeginInit();
            tpMovimientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            pnlFriltrosMovimientos.SuspendLayout();
            panel1.SuspendLayout();
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
            tlpFiltros.ColumnCount = 5;
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            tlpFiltros.Controls.Add(txtBuscarInventario, 0, 0);
            tlpFiltros.Controls.Add(cmbCategoriaInventario, 1, 0);
            tlpFiltros.Controls.Add(cmbEstadoStock, 2, 0);
            tlpFiltros.Controls.Add(cmbVencimiento, 3, 0);
            tlpFiltros.Controls.Add(btnRefrescarInventario, 4, 0);
            tlpFiltros.Dock = DockStyle.Fill;
            tlpFiltros.Location = new Point(12, 8);
            tlpFiltros.Margin = new Padding(0);
            tlpFiltros.Name = "tlpFiltros";
            tlpFiltros.RowCount = 1;
            tlpFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpFiltros.Size = new Size(906, 62);
            tlpFiltros.TabIndex = 0;
            // 
            // txtBuscarInventario
            // 
            txtBuscarInventario.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBuscarInventario.Font = new Font("Century Gothic", 10.2F);
            txtBuscarInventario.Location = new Point(3, 17);
            txtBuscarInventario.MaxLength = 150;
            txtBuscarInventario.Name = "txtBuscarInventario";
            txtBuscarInventario.Size = new Size(265, 28);
            txtBuscarInventario.TabIndex = 0;
            // 
            // cmbCategoriaInventario
            // 
            cmbCategoriaInventario.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbCategoriaInventario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoriaInventario.FormattingEnabled = true;
            cmbCategoriaInventario.Location = new Point(274, 17);
            cmbCategoriaInventario.Name = "cmbCategoriaInventario";
            cmbCategoriaInventario.Size = new Size(157, 28);
            cmbCategoriaInventario.TabIndex = 1;
            // 
            // cmbEstadoStock
            // 
            cmbEstadoStock.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbEstadoStock.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoStock.FormattingEnabled = true;
            cmbEstadoStock.Items.AddRange(new object[] { "Todos", "Normal", "Bajo", "Agotado" });
            cmbEstadoStock.Location = new Point(437, 17);
            cmbEstadoStock.Name = "cmbEstadoStock";
            cmbEstadoStock.Size = new Size(157, 28);
            cmbEstadoStock.TabIndex = 2;
            // 
            // cmbVencimiento
            // 
            cmbVencimiento.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbVencimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVencimiento.FormattingEnabled = true;
            cmbVencimiento.Items.AddRange(new object[] { "Todos", "Próximos a vencer ", "Vencidos" });
            cmbVencimiento.Location = new Point(600, 17);
            cmbVencimiento.Name = "cmbVencimiento";
            cmbVencimiento.Size = new Size(157, 28);
            cmbVencimiento.TabIndex = 3;
            // 
            // btnRefrescarInventario
            // 
            btnRefrescarInventario.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnRefrescarInventario.BackColor = Color.FromArgb(8, 126, 164);
            btnRefrescarInventario.FlatAppearance.BorderSize = 0;
            btnRefrescarInventario.FlatStyle = FlatStyle.Flat;
            btnRefrescarInventario.Font = new Font("Century Gothic", 9.75F);
            btnRefrescarInventario.ForeColor = Color.White;
            btnRefrescarInventario.Location = new Point(763, 3);
            btnRefrescarInventario.Name = "btnRefrescarInventario";
            btnRefrescarInventario.Size = new Size(140, 56);
            btnRefrescarInventario.TabIndex = 4;
            btnRefrescarInventario.Text = "Refrescar";
            btnRefrescarInventario.UseVisualStyleBackColor = false;
            // 
            // tcInventario
            // 
            tcInventario.Controls.Add(tcExistencias);
            tcInventario.Controls.Add(tpMovimientos);
            tcInventario.Dock = DockStyle.Fill;
            tcInventario.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tcInventario.Location = new Point(0, 7);
            tcInventario.Name = "tcInventario";
            tcInventario.SelectedIndex = 0;
            tcInventario.Size = new Size(930, 735);
            tcInventario.TabIndex = 1;
            // 
            // tcExistencias
            // 
            tcExistencias.Controls.Add(dgvExistencias);
            tcExistencias.Controls.Add(pnlAcccionesInventario);
            tcExistencias.Location = new Point(4, 30);
            tcExistencias.Name = "tcExistencias";
            tcExistencias.Padding = new Padding(3);
            tcExistencias.Size = new Size(922, 701);
            tcExistencias.TabIndex = 0;
            tcExistencias.Text = "Existencias";
            tcExistencias.UseVisualStyleBackColor = true;
            // 
            // pnlAcccionesInventario
            // 
            pnlAcccionesInventario.BackColor = Color.White;
            pnlAcccionesInventario.Controls.Add(btnRegistrarEntrada);
            pnlAcccionesInventario.Controls.Add(btnRegistrarSalida);
            pnlAcccionesInventario.Controls.Add(btnRegistrarAjuste);
            pnlAcccionesInventario.Controls.Add(btnRegistrarPerdida);
            pnlAcccionesInventario.Dock = DockStyle.Bottom;
            pnlAcccionesInventario.Location = new Point(3, 640);
            pnlAcccionesInventario.Name = "pnlAcccionesInventario";
            pnlAcccionesInventario.Padding = new Padding(10, 8, 10, 8);
            pnlAcccionesInventario.Size = new Size(916, 58);
            pnlAcccionesInventario.TabIndex = 0;
            // 
            // btnRegistrarEntrada
            // 
            btnRegistrarEntrada.BackColor = Color.FromArgb(8, 126, 164);
            btnRegistrarEntrada.Dock = DockStyle.Left;
            btnRegistrarEntrada.FlatStyle = FlatStyle.Flat;
            btnRegistrarEntrada.Font = new Font("Century Gothic", 9.75F);
            btnRegistrarEntrada.ForeColor = Color.White;
            btnRegistrarEntrada.Location = new Point(447, 8);
            btnRegistrarEntrada.Name = "btnRegistrarEntrada";
            btnRegistrarEntrada.Size = new Size(135, 42);
            btnRegistrarEntrada.TabIndex = 0;
            btnRegistrarEntrada.Text = "Entrada";
            btnRegistrarEntrada.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarSalida
            // 
            btnRegistrarSalida.BackColor = Color.FromArgb(238, 243, 247);
            btnRegistrarSalida.Dock = DockStyle.Left;
            btnRegistrarSalida.FlatStyle = FlatStyle.Flat;
            btnRegistrarSalida.ForeColor = Color.FromArgb(8, 31, 63);
            btnRegistrarSalida.Location = new Point(312, 8);
            btnRegistrarSalida.Name = "btnRegistrarSalida";
            btnRegistrarSalida.Size = new Size(135, 42);
            btnRegistrarSalida.TabIndex = 1;
            btnRegistrarSalida.Text = "Salida";
            btnRegistrarSalida.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarAjuste
            // 
            btnRegistrarAjuste.BackColor = Color.FromArgb(238, 243, 247);
            btnRegistrarAjuste.Dock = DockStyle.Left;
            btnRegistrarAjuste.FlatStyle = FlatStyle.Flat;
            btnRegistrarAjuste.ForeColor = Color.FromArgb(8, 31, 63);
            btnRegistrarAjuste.Location = new Point(177, 8);
            btnRegistrarAjuste.Name = "btnRegistrarAjuste";
            btnRegistrarAjuste.Size = new Size(135, 42);
            btnRegistrarAjuste.TabIndex = 2;
            btnRegistrarAjuste.Text = "Ajuste";
            btnRegistrarAjuste.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarPerdida
            // 
            btnRegistrarPerdida.BackColor = Color.FromArgb(163, 61, 61);
            btnRegistrarPerdida.Dock = DockStyle.Left;
            btnRegistrarPerdida.FlatStyle = FlatStyle.Flat;
            btnRegistrarPerdida.ForeColor = Color.White;
            btnRegistrarPerdida.Location = new Point(10, 8);
            btnRegistrarPerdida.Name = "btnRegistrarPerdida";
            btnRegistrarPerdida.Size = new Size(167, 42);
            btnRegistrarPerdida.TabIndex = 3;
            btnRegistrarPerdida.Text = "Pérdida/Dañado";
            btnRegistrarPerdida.UseVisualStyleBackColor = false;
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
            dgvExistencias.BackgroundColor = Color.FromArgb(230, 234, 238);
            dgvExistencias.BorderStyle = BorderStyle.None;
            dgvExistencias.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvExistencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvExistencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExistencias.Columns.AddRange(new DataGridViewColumn[] { colCodigoInv, colProductoInv, colCategoriaInv, colUnidadInv, colStockActual, colStockMinimo, colEstadoStock, colVencimiento });
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = Color.White;
            dataGridViewCellStyle11.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle11.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dgvExistencias.DefaultCellStyle = dataGridViewCellStyle11;
            dgvExistencias.Dock = DockStyle.Fill;
            dgvExistencias.EnableHeadersVisualStyles = false;
            dgvExistencias.Location = new Point(3, 3);
            dgvExistencias.MultiSelect = false;
            dgvExistencias.Name = "dgvExistencias";
            dgvExistencias.ReadOnly = true;
            dgvExistencias.RowHeadersVisible = false;
            dgvExistencias.RowHeadersWidth = 51;
            dgvExistencias.RowTemplate.Height = 38;
            dgvExistencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExistencias.Size = new Size(916, 637);
            dgvExistencias.TabIndex = 1;
            dgvExistencias.CellContentClick += dgvExistencias_CellContentClick;
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
            // tpMovimientos
            // 
            tpMovimientos.Controls.Add(dgvMovimientos);
            tpMovimientos.Controls.Add(pnlFriltrosMovimientos);
            tpMovimientos.Location = new Point(4, 30);
            tpMovimientos.Name = "tpMovimientos";
            tpMovimientos.Padding = new Padding(3);
            tpMovimientos.Size = new Size(932, 718);
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
            dataGridViewCellStyle13.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            dataGridViewCellStyle21.Font = new Font("Century Gothic", 9F);
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
            dgvMovimientos.RowHeadersWidth = 51;
            dgvMovimientos.RowTemplate.Height = 38;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.Size = new Size(926, 650);
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
            pnlFriltrosMovimientos.Controls.Add(cmbTipoMovimiento);
            pnlFriltrosMovimientos.Controls.Add(dtpHasta);
            pnlFriltrosMovimientos.Controls.Add(dtpDesde);
            pnlFriltrosMovimientos.Dock = DockStyle.Top;
            pnlFriltrosMovimientos.Location = new Point(3, 3);
            pnlFriltrosMovimientos.Name = "pnlFriltrosMovimientos";
            pnlFriltrosMovimientos.Padding = new Padding(10, 8, 10, 8);
            pnlFriltrosMovimientos.Size = new Size(926, 62);
            pnlFriltrosMovimientos.TabIndex = 0;
            // 
            // cmbTipoMovimiento
            // 
            cmbTipoMovimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoMovimiento.FormattingEnabled = true;
            cmbTipoMovimiento.Items.AddRange(new object[] { "Todos", "", "Entrada", "", "Salida", "", "Ajuste", "", "Pérdida/Dañado", "", "Compra", "", "Venta" });
            cmbTipoMovimiento.Location = new Point(617, 16);
            cmbTipoMovimiento.Name = "cmbTipoMovimiento";
            cmbTipoMovimiento.Size = new Size(151, 29);
            cmbTipoMovimiento.TabIndex = 2;
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(319, 16);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(250, 28);
            dtpHasta.TabIndex = 1;
            // 
            // dtpDesde
            // 
            dtpDesde.Font = new Font("Century Gothic", 9.75F);
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(26, 16);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(250, 27);
            dtpDesde.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(tcInventario);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(5, 83);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 7, 0, 0);
            panel1.Size = new Size(930, 742);
            panel1.TabIndex = 2;
            // 
            // FrmInventario
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(panel1);
            Controls.Add(pnlFiltros);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmInventario";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmInventario";
            pnlFiltros.ResumeLayout(false);
            tlpFiltros.ResumeLayout(false);
            tlpFiltros.PerformLayout();
            tcInventario.ResumeLayout(false);
            tcExistencias.ResumeLayout(false);
            pnlAcccionesInventario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExistencias).EndInit();
            tpMovimientos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            pnlFriltrosMovimientos.ResumeLayout(false);
            panel1.ResumeLayout(false);
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
        private DataGridViewTextBoxColumn colCodigoInv;
        private DataGridViewTextBoxColumn colProductoInv;
        private DataGridViewTextBoxColumn colCategoriaInv;
        private DataGridViewTextBoxColumn colUnidadInv;
        private DataGridViewTextBoxColumn colStockActual;
        private DataGridViewTextBoxColumn colStockMinimo;
        private DataGridViewTextBoxColumn colEstadoStock;
        private DataGridViewTextBoxColumn colVencimiento;
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
        private Panel panel1;
    }
}