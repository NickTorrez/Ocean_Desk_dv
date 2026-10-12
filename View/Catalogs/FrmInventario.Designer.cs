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
            DataGridViewCellStyle dataGridViewCellStyle43 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle44 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle53 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle45 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle46 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle47 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle48 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle49 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle50 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle51 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle52 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle54 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle55 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle63 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle56 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle57 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle58 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle59 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle60 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle61 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle62 = new DataGridViewCellStyle();
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
            btnRegistrarPerdida = new Button();
            btnRegistrarAjuste = new Button();
            btnRegistrarSalida = new Button();
            btnRegistrarEntrada = new Button();
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
            pnlFiltros.SuspendLayout();
            tlpFiltros.SuspendLayout();
            tcInventario.SuspendLayout();
            tcExistencias.SuspendLayout();
            pnlAcccionesInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExistencias).BeginInit();
            tpMovimientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            pnlFriltrosMovimientos.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.White;
            pnlFiltros.Controls.Add(tlpFiltros);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 0);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(12, 8, 12, 8);
            pnlFiltros.Size = new Size(940, 78);
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
            tlpFiltros.Size = new Size(916, 62);
            tlpFiltros.TabIndex = 0;
            // 
            // txtBuscarInventario
            // 
            txtBuscarInventario.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBuscarInventario.Font = new Font("Century Gothic", 10.2F);
            txtBuscarInventario.Location = new Point(3, 17);
            txtBuscarInventario.MaxLength = 150;
            txtBuscarInventario.Name = "txtBuscarInventario";
            txtBuscarInventario.Size = new Size(268, 28);
            txtBuscarInventario.TabIndex = 0;
            // 
            // cmbCategoriaInventario
            // 
            cmbCategoriaInventario.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbCategoriaInventario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoriaInventario.FormattingEnabled = true;
            cmbCategoriaInventario.Location = new Point(277, 17);
            cmbCategoriaInventario.Name = "cmbCategoriaInventario";
            cmbCategoriaInventario.Size = new Size(158, 28);
            cmbCategoriaInventario.TabIndex = 1;
            // 
            // cmbEstadoStock
            // 
            cmbEstadoStock.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbEstadoStock.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoStock.FormattingEnabled = true;
            cmbEstadoStock.Items.AddRange(new object[] { "Todos", "Normal", "Bajo", "Agotado" });
            cmbEstadoStock.Location = new Point(441, 17);
            cmbEstadoStock.Name = "cmbEstadoStock";
            cmbEstadoStock.Size = new Size(158, 28);
            cmbEstadoStock.TabIndex = 2;
            // 
            // cmbVencimiento
            // 
            cmbVencimiento.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbVencimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVencimiento.FormattingEnabled = true;
            cmbVencimiento.Items.AddRange(new object[] { "Todos", "Próximos a vencer ", "Vencidos" });
            cmbVencimiento.Location = new Point(605, 17);
            cmbVencimiento.Name = "cmbVencimiento";
            cmbVencimiento.Size = new Size(158, 28);
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
            btnRefrescarInventario.Location = new Point(769, 3);
            btnRefrescarInventario.Name = "btnRefrescarInventario";
            btnRefrescarInventario.Size = new Size(144, 56);
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
            tcInventario.Location = new Point(0, 78);
            tcInventario.Name = "tcInventario";
            tcInventario.SelectedIndex = 0;
            tcInventario.Size = new Size(940, 752);
            tcInventario.TabIndex = 1;
            // 
            // tcExistencias
            // 
            tcExistencias.Controls.Add(pnlAcccionesInventario);
            tcExistencias.Controls.Add(dgvExistencias);
            tcExistencias.Location = new Point(4, 30);
            tcExistencias.Name = "tcExistencias";
            tcExistencias.Padding = new Padding(3);
            tcExistencias.Size = new Size(932, 718);
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
            pnlAcccionesInventario.Location = new Point(3, 657);
            pnlAcccionesInventario.Name = "pnlAcccionesInventario";
            pnlAcccionesInventario.Padding = new Padding(10, 8, 10, 8);
            pnlAcccionesInventario.Size = new Size(926, 58);
            pnlAcccionesInventario.TabIndex = 0;
            // 
            // btnRegistrarPerdida
            // 
            btnRegistrarPerdida.BackColor = Color.FromArgb(163, 61, 61);
            btnRegistrarPerdida.Dock = DockStyle.Left;
            btnRegistrarPerdida.FlatStyle = FlatStyle.Flat;
            btnRegistrarPerdida.ForeColor = Color.White;
            btnRegistrarPerdida.Location = new Point(10, 8);
            btnRegistrarPerdida.Name = "btnRegistrarPerdida";
            btnRegistrarPerdida.Size = new Size(145, 42);
            btnRegistrarPerdida.TabIndex = 3;
            btnRegistrarPerdida.Text = "Pérdida/Dañado";
            btnRegistrarPerdida.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarAjuste
            // 
            btnRegistrarAjuste.BackColor = Color.FromArgb(238, 243, 247);
            btnRegistrarAjuste.Dock = DockStyle.Left;
            btnRegistrarAjuste.FlatStyle = FlatStyle.Flat;
            btnRegistrarAjuste.ForeColor = Color.FromArgb(8, 31, 63);
            btnRegistrarAjuste.Location = new Point(155, 8);
            btnRegistrarAjuste.Name = "btnRegistrarAjuste";
            btnRegistrarAjuste.Size = new Size(135, 42);
            btnRegistrarAjuste.TabIndex = 2;
            btnRegistrarAjuste.Text = "Ajuste";
            btnRegistrarAjuste.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarSalida
            // 
            btnRegistrarSalida.BackColor = Color.FromArgb(238, 243, 247);
            btnRegistrarSalida.Dock = DockStyle.Left;
            btnRegistrarSalida.FlatStyle = FlatStyle.Flat;
            btnRegistrarSalida.ForeColor = Color.FromArgb(8, 31, 63);
            btnRegistrarSalida.Location = new Point(290, 8);
            btnRegistrarSalida.Name = "btnRegistrarSalida";
            btnRegistrarSalida.Size = new Size(135, 42);
            btnRegistrarSalida.TabIndex = 1;
            btnRegistrarSalida.Text = "Salida";
            btnRegistrarSalida.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarEntrada
            // 
            btnRegistrarEntrada.BackColor = Color.FromArgb(8, 126, 164);
            btnRegistrarEntrada.Dock = DockStyle.Left;
            btnRegistrarEntrada.FlatStyle = FlatStyle.Flat;
            btnRegistrarEntrada.Font = new Font("Century Gothic", 9.75F);
            btnRegistrarEntrada.ForeColor = Color.White;
            btnRegistrarEntrada.Location = new Point(425, 8);
            btnRegistrarEntrada.Name = "btnRegistrarEntrada";
            btnRegistrarEntrada.Size = new Size(135, 42);
            btnRegistrarEntrada.TabIndex = 0;
            btnRegistrarEntrada.Text = "Entrada";
            btnRegistrarEntrada.UseVisualStyleBackColor = false;
            // 
            // dgvExistencias
            // 
            dgvExistencias.AllowUserToAddRows = false;
            dgvExistencias.AllowUserToDeleteRows = false;
            dgvExistencias.AllowUserToOrderColumns = true;
            dgvExistencias.AllowUserToResizeColumns = false;
            dgvExistencias.AllowUserToResizeRows = false;
            dataGridViewCellStyle43.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle43.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvExistencias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle43;
            dgvExistencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExistencias.BackgroundColor = Color.FromArgb(230, 234, 238);
            dgvExistencias.BorderStyle = BorderStyle.None;
            dgvExistencias.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle44.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle44.BackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle44.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle44.ForeColor = Color.White;
            dataGridViewCellStyle44.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle44.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle44.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle44.WrapMode = DataGridViewTriState.True;
            dgvExistencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle44;
            dgvExistencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExistencias.Columns.AddRange(new DataGridViewColumn[] { colCodigoInv, colProductoInv, colCategoriaInv, colUnidadInv, colStockActual, colStockMinimo, colEstadoStock, colVencimiento });
            dataGridViewCellStyle53.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle53.BackColor = Color.White;
            dataGridViewCellStyle53.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle53.ForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle53.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle53.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle53.WrapMode = DataGridViewTriState.False;
            dgvExistencias.DefaultCellStyle = dataGridViewCellStyle53;
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
            dgvExistencias.Size = new Size(926, 712);
            dgvExistencias.TabIndex = 1;
            dgvExistencias.CellContentClick += dgvExistencias_CellContentClick;
            // 
            // colCodigoInv
            // 
            colCodigoInv.DataPropertyName = "ProductCode";
            dataGridViewCellStyle45.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCodigoInv.DefaultCellStyle = dataGridViewCellStyle45;
            colCodigoInv.FillWeight = 85F;
            colCodigoInv.HeaderText = "Código";
            colCodigoInv.MinimumWidth = 6;
            colCodigoInv.Name = "colCodigoInv";
            colCodigoInv.ReadOnly = true;
            // 
            // colProductoInv
            // 
            colProductoInv.DataPropertyName = "ProductName";
            dataGridViewCellStyle46.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colProductoInv.DefaultCellStyle = dataGridViewCellStyle46;
            colProductoInv.FillWeight = 180F;
            colProductoInv.HeaderText = "Producto";
            colProductoInv.MinimumWidth = 6;
            colProductoInv.Name = "colProductoInv";
            colProductoInv.ReadOnly = true;
            // 
            // colCategoriaInv
            // 
            colCategoriaInv.DataPropertyName = "CategoryName";
            dataGridViewCellStyle47.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colCategoriaInv.DefaultCellStyle = dataGridViewCellStyle47;
            colCategoriaInv.FillWeight = 110F;
            colCategoriaInv.HeaderText = "Categoria";
            colCategoriaInv.MinimumWidth = 6;
            colCategoriaInv.Name = "colCategoriaInv";
            colCategoriaInv.ReadOnly = true;
            // 
            // colUnidadInv
            // 
            colUnidadInv.DataPropertyName = "UnitName";
            dataGridViewCellStyle48.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colUnidadInv.DefaultCellStyle = dataGridViewCellStyle48;
            colUnidadInv.FillWeight = 80F;
            colUnidadInv.HeaderText = "Unidad";
            colUnidadInv.MinimumWidth = 6;
            colUnidadInv.Name = "colUnidadInv";
            colUnidadInv.ReadOnly = true;
            // 
            // colStockActual
            // 
            colStockActual.DataPropertyName = "CurrentStock";
            dataGridViewCellStyle49.Alignment = DataGridViewContentAlignment.MiddleRight;
            colStockActual.DefaultCellStyle = dataGridViewCellStyle49;
            colStockActual.HeaderText = "StockActual";
            colStockActual.MinimumWidth = 6;
            colStockActual.Name = "colStockActual";
            colStockActual.ReadOnly = true;
            // 
            // colStockMinimo
            // 
            colStockMinimo.DataPropertyName = "MinimumStock";
            dataGridViewCellStyle50.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle50.NullValue = null;
            colStockMinimo.DefaultCellStyle = dataGridViewCellStyle50;
            colStockMinimo.HeaderText = "Stock Minimo";
            colStockMinimo.MinimumWidth = 6;
            colStockMinimo.Name = "colStockMinimo";
            colStockMinimo.ReadOnly = true;
            // 
            // colEstadoStock
            // 
            colEstadoStock.DataPropertyName = "StockStatus";
            dataGridViewCellStyle51.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEstadoStock.DefaultCellStyle = dataGridViewCellStyle51;
            colEstadoStock.FillWeight = 95F;
            colEstadoStock.HeaderText = "Estado ";
            colEstadoStock.MinimumWidth = 6;
            colEstadoStock.Name = "colEstadoStock";
            colEstadoStock.ReadOnly = true;
            // 
            // colVencimiento
            // 
            colVencimiento.DataPropertyName = "ExpirationDate";
            dataGridViewCellStyle52.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle52.Format = "d";
            dataGridViewCellStyle52.NullValue = null;
            colVencimiento.DefaultCellStyle = dataGridViewCellStyle52;
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
            dataGridViewCellStyle54.BackColor = Color.FromArgb(248, 250, 252);
            dgvMovimientos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle54;
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimientos.BackgroundColor = Color.FromArgb(230, 234, 238);
            dgvMovimientos.BorderStyle = BorderStyle.None;
            dgvMovimientos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle55.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle55.BackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle55.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle55.ForeColor = Color.White;
            dataGridViewCellStyle55.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle55.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle55.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle55.WrapMode = DataGridViewTriState.True;
            dgvMovimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle55;
            dgvMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimientos.Columns.AddRange(new DataGridViewColumn[] { colFechaMov, colTipoMov, colProductoMov, colCantidadMov, colUnidadMov, colOrigenMov, colObservacionesMov });
            dataGridViewCellStyle63.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle63.BackColor = Color.White;
            dataGridViewCellStyle63.Font = new Font("Century Gothic", 9F);
            dataGridViewCellStyle63.ForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle63.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle63.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle63.WrapMode = DataGridViewTriState.False;
            dgvMovimientos.DefaultCellStyle = dataGridViewCellStyle63;
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
            dataGridViewCellStyle56.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle56.Format = "g";
            dataGridViewCellStyle56.NullValue = null;
            colFechaMov.DefaultCellStyle = dataGridViewCellStyle56;
            colFechaMov.FillWeight = 105F;
            colFechaMov.HeaderText = "Fecha";
            colFechaMov.MinimumWidth = 6;
            colFechaMov.Name = "colFechaMov";
            colFechaMov.ReadOnly = true;
            // 
            // colTipoMov
            // 
            colTipoMov.DataPropertyName = "MovementType";
            dataGridViewCellStyle57.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTipoMov.DefaultCellStyle = dataGridViewCellStyle57;
            colTipoMov.FillWeight = 110F;
            colTipoMov.HeaderText = "Tipo";
            colTipoMov.MinimumWidth = 6;
            colTipoMov.Name = "colTipoMov";
            colTipoMov.ReadOnly = true;
            // 
            // colProductoMov
            // 
            colProductoMov.DataPropertyName = "ProductName";
            dataGridViewCellStyle58.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colProductoMov.DefaultCellStyle = dataGridViewCellStyle58;
            colProductoMov.FillWeight = 180F;
            colProductoMov.HeaderText = "Producto";
            colProductoMov.MinimumWidth = 6;
            colProductoMov.Name = "colProductoMov";
            colProductoMov.ReadOnly = true;
            // 
            // colCantidadMov
            // 
            colCantidadMov.DataPropertyName = "Quantity";
            dataGridViewCellStyle59.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle59.NullValue = null;
            colCantidadMov.DefaultCellStyle = dataGridViewCellStyle59;
            colCantidadMov.HeaderText = "Cantidad";
            colCantidadMov.MinimumWidth = 6;
            colCantidadMov.Name = "colCantidadMov";
            colCantidadMov.ReadOnly = true;
            // 
            // colUnidadMov
            // 
            colUnidadMov.DataPropertyName = "UnitName";
            dataGridViewCellStyle60.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colUnidadMov.DefaultCellStyle = dataGridViewCellStyle60;
            colUnidadMov.FillWeight = 80F;
            colUnidadMov.HeaderText = "Unidad";
            colUnidadMov.MinimumWidth = 6;
            colUnidadMov.Name = "colUnidadMov";
            colUnidadMov.ReadOnly = true;
            // 
            // colOrigenMov
            // 
            colOrigenMov.DataPropertyName = "Source";
            dataGridViewCellStyle61.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colOrigenMov.DefaultCellStyle = dataGridViewCellStyle61;
            colOrigenMov.FillWeight = 120F;
            colOrigenMov.HeaderText = "Origen";
            colOrigenMov.MinimumWidth = 6;
            colOrigenMov.Name = "colOrigenMov";
            colOrigenMov.ReadOnly = true;
            // 
            // colObservacionesMov
            // 
            colObservacionesMov.DataPropertyName = "Notes";
            dataGridViewCellStyle62.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colObservacionesMov.DefaultCellStyle = dataGridViewCellStyle62;
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
            // FrmInventario
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(tcInventario);
            Controls.Add(pnlFiltros);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmInventario";
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
    }
}