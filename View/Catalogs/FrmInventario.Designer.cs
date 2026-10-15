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
            DataGridViewCellStyle dataGridViewCellStyle85 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle86 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle95 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle96 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle97 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle105 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle98 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle99 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle100 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle101 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle102 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle103 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle104 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle87 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle88 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle89 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle90 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle91 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle92 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle93 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle94 = new DataGridViewCellStyle();
            pnlFiltros = new Panel();
            tlpFiltros = new TableLayoutPanel();
            txtBuscarInventario = new TextBox();
            cmbCategoriaInventario = new ComboBox();
            cmbEstadoStock = new ComboBox();
            cmbVencimiento = new ComboBox();
            btnRefrescarInventario = new Button();
            tcInventario = new TabControl();
            tcExistencias = new TabPage();
            dgvExistencias = new DataGridView();
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
            cmbTipoMovimiento = new ComboBox();
            dtpHasta = new DateTimePicker();
            dtpDesde = new DateTimePicker();
            pnlContainerTab = new Panel();
            colCodigoInv = new DataGridViewTextBoxColumn();
            colProductoInv = new DataGridViewTextBoxColumn();
            colCategoriaInv = new DataGridViewTextBoxColumn();
            colUnidadInv = new DataGridViewTextBoxColumn();
            colStockActual = new DataGridViewTextBoxColumn();
            colStockMinimo = new DataGridViewTextBoxColumn();
            colEstadoStock = new DataGridViewTextBoxColumn();
            colVencimiento = new DataGridViewTextBoxColumn();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlDesde = new Panel();
            pnlHasta = new Panel();
            pnlMovimiento = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            pictureBox1 = new PictureBox();
            pnlFiltros.SuspendLayout();
            tlpFiltros.SuspendLayout();
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
            pnlContainerTab.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlDesde.SuspendLayout();
            pnlHasta.SuspendLayout();
            pnlMovimiento.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.898776F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.6907673F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.3526134F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.3526134F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.3526134F));
            tlpFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.3526134F));
            tlpFiltros.Controls.Add(panel1, 0, 0);
            tlpFiltros.Controls.Add(panel2, 1, 0);
            tlpFiltros.Controls.Add(panel3, 2, 0);
            tlpFiltros.Controls.Add(panel4, 3, 0);
            tlpFiltros.Controls.Add(panel5, 4, 0);
            tlpFiltros.Controls.Add(panel6, 5, 0);
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
            txtBuscarInventario.Location = new Point(239, 251);
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
            cmbCategoriaInventario.Location = new Point(598, 238);
            cmbCategoriaInventario.Name = "cmbCategoriaInventario";
            cmbCategoriaInventario.Size = new Size(157, 27);
            cmbCategoriaInventario.TabIndex = 1;
            // 
            // cmbEstadoStock
            // 
            cmbEstadoStock.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbEstadoStock.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoStock.FormattingEnabled = true;
            cmbEstadoStock.Items.AddRange(new object[] { "Todos", "Normal", "Bajo", "Agotado" });
            cmbEstadoStock.Location = new Point(422, 355);
            cmbEstadoStock.Name = "cmbEstadoStock";
            cmbEstadoStock.Size = new Size(157, 27);
            cmbEstadoStock.TabIndex = 2;
            // 
            // cmbVencimiento
            // 
            cmbVencimiento.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbVencimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVencimiento.FormattingEnabled = true;
            cmbVencimiento.Items.AddRange(new object[] { "Todos", "Próximos a vencer ", "Vencidos" });
            cmbVencimiento.Location = new Point(642, 368);
            cmbVencimiento.Name = "cmbVencimiento";
            cmbVencimiento.Size = new Size(157, 27);
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
            btnRefrescarInventario.Location = new Point(752, 128);
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
            dataGridViewCellStyle85.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle85.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvExistencias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle85;
            dgvExistencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExistencias.BorderStyle = BorderStyle.None;
            dgvExistencias.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle86.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle86.BackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle86.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle86.ForeColor = Color.White;
            dataGridViewCellStyle86.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle86.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle86.SelectionForeColor = Color.White;
            dataGridViewCellStyle86.WrapMode = DataGridViewTriState.True;
            dgvExistencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle86;
            dgvExistencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExistencias.Columns.AddRange(new DataGridViewColumn[] { colCodigoInv, colProductoInv, colCategoriaInv, colUnidadInv, colStockActual, colStockMinimo, colEstadoStock, colVencimiento });
            dataGridViewCellStyle95.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle95.BackColor = Color.White;
            dataGridViewCellStyle95.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle95.ForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle95.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle95.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle95.WrapMode = DataGridViewTriState.False;
            dgvExistencias.DefaultCellStyle = dataGridViewCellStyle95;
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
            pnlSalida.Size = new Size(218, 55);
            pnlSalida.TabIndex = 2;
            // 
            // btnRegistrarSalida
            // 
            btnRegistrarSalida.BackColor = Color.FromArgb(238, 243, 247);
            btnRegistrarSalida.Dock = DockStyle.Fill;
            btnRegistrarSalida.FlatAppearance.BorderSize = 0;
            btnRegistrarSalida.FlatStyle = FlatStyle.Flat;
            btnRegistrarSalida.ForeColor = Color.FromArgb(8, 31, 63);
            btnRegistrarSalida.Location = new Point(0, 0);
            btnRegistrarSalida.Name = "btnRegistrarSalida";
            btnRegistrarSalida.Size = new Size(218, 55);
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
            pnlEntrada.Size = new Size(218, 55);
            pnlEntrada.TabIndex = 3;
            // 
            // btnRegistrarEntrada
            // 
            btnRegistrarEntrada.BackColor = Color.FromArgb(8, 126, 164);
            btnRegistrarEntrada.Dock = DockStyle.Fill;
            btnRegistrarEntrada.FlatAppearance.BorderSize = 0;
            btnRegistrarEntrada.FlatStyle = FlatStyle.Flat;
            btnRegistrarEntrada.Font = new Font("Century Gothic", 9.75F);
            btnRegistrarEntrada.ForeColor = Color.White;
            btnRegistrarEntrada.Location = new Point(0, 0);
            btnRegistrarEntrada.Name = "btnRegistrarEntrada";
            btnRegistrarEntrada.Size = new Size(218, 55);
            btnRegistrarEntrada.TabIndex = 0;
            btnRegistrarEntrada.Text = "Entrada";
            btnRegistrarEntrada.UseVisualStyleBackColor = false;
            // 
            // tpMovimientos
            // 
            tpMovimientos.Controls.Add(btnRefrescarInventario);
            tpMovimientos.Controls.Add(cmbVencimiento);
            tpMovimientos.Controls.Add(cmbEstadoStock);
            tpMovimientos.Controls.Add(cmbCategoriaInventario);
            tpMovimientos.Controls.Add(txtBuscarInventario);
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
            dataGridViewCellStyle96.BackColor = Color.FromArgb(248, 250, 252);
            dgvMovimientos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle96;
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimientos.BackgroundColor = Color.FromArgb(230, 234, 238);
            dgvMovimientos.BorderStyle = BorderStyle.None;
            dgvMovimientos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle97.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle97.BackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle97.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle97.ForeColor = Color.White;
            dataGridViewCellStyle97.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle97.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle97.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle97.WrapMode = DataGridViewTriState.True;
            dgvMovimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle97;
            dgvMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimientos.Columns.AddRange(new DataGridViewColumn[] { colFechaMov, colTipoMov, colProductoMov, colCantidadMov, colUnidadMov, colOrigenMov, colObservacionesMov });
            dataGridViewCellStyle105.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle105.BackColor = Color.White;
            dataGridViewCellStyle105.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle105.ForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle105.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle105.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle105.WrapMode = DataGridViewTriState.False;
            dgvMovimientos.DefaultCellStyle = dataGridViewCellStyle105;
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
            dataGridViewCellStyle98.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle98.Format = "g";
            dataGridViewCellStyle98.NullValue = null;
            colFechaMov.DefaultCellStyle = dataGridViewCellStyle98;
            colFechaMov.FillWeight = 105F;
            colFechaMov.HeaderText = "Fecha";
            colFechaMov.MinimumWidth = 6;
            colFechaMov.Name = "colFechaMov";
            colFechaMov.ReadOnly = true;
            // 
            // colTipoMov
            // 
            colTipoMov.DataPropertyName = "MovementType";
            dataGridViewCellStyle99.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTipoMov.DefaultCellStyle = dataGridViewCellStyle99;
            colTipoMov.FillWeight = 110F;
            colTipoMov.HeaderText = "Tipo";
            colTipoMov.MinimumWidth = 6;
            colTipoMov.Name = "colTipoMov";
            colTipoMov.ReadOnly = true;
            // 
            // colProductoMov
            // 
            colProductoMov.DataPropertyName = "ProductName";
            dataGridViewCellStyle100.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colProductoMov.DefaultCellStyle = dataGridViewCellStyle100;
            colProductoMov.FillWeight = 180F;
            colProductoMov.HeaderText = "Producto";
            colProductoMov.MinimumWidth = 6;
            colProductoMov.Name = "colProductoMov";
            colProductoMov.ReadOnly = true;
            // 
            // colCantidadMov
            // 
            colCantidadMov.DataPropertyName = "Quantity";
            dataGridViewCellStyle101.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle101.NullValue = null;
            colCantidadMov.DefaultCellStyle = dataGridViewCellStyle101;
            colCantidadMov.HeaderText = "Cantidad";
            colCantidadMov.MinimumWidth = 6;
            colCantidadMov.Name = "colCantidadMov";
            colCantidadMov.ReadOnly = true;
            // 
            // colUnidadMov
            // 
            colUnidadMov.DataPropertyName = "UnitName";
            dataGridViewCellStyle102.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colUnidadMov.DefaultCellStyle = dataGridViewCellStyle102;
            colUnidadMov.FillWeight = 80F;
            colUnidadMov.HeaderText = "Unidad";
            colUnidadMov.MinimumWidth = 6;
            colUnidadMov.Name = "colUnidadMov";
            colUnidadMov.ReadOnly = true;
            // 
            // colOrigenMov
            // 
            colOrigenMov.DataPropertyName = "Source";
            dataGridViewCellStyle103.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colOrigenMov.DefaultCellStyle = dataGridViewCellStyle103;
            colOrigenMov.FillWeight = 120F;
            colOrigenMov.HeaderText = "Origen";
            colOrigenMov.MinimumWidth = 6;
            colOrigenMov.Name = "colOrigenMov";
            colOrigenMov.ReadOnly = true;
            // 
            // colObservacionesMov
            // 
            colObservacionesMov.DataPropertyName = "Notes";
            dataGridViewCellStyle104.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colObservacionesMov.DefaultCellStyle = dataGridViewCellStyle104;
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
            // colCodigoInv
            // 
            colCodigoInv.DataPropertyName = "ProductCode";
            dataGridViewCellStyle87.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCodigoInv.DefaultCellStyle = dataGridViewCellStyle87;
            colCodigoInv.FillWeight = 85F;
            colCodigoInv.HeaderText = "Código";
            colCodigoInv.MinimumWidth = 6;
            colCodigoInv.Name = "colCodigoInv";
            colCodigoInv.ReadOnly = true;
            // 
            // colProductoInv
            // 
            colProductoInv.DataPropertyName = "ProductName";
            dataGridViewCellStyle88.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colProductoInv.DefaultCellStyle = dataGridViewCellStyle88;
            colProductoInv.FillWeight = 180F;
            colProductoInv.HeaderText = "Producto";
            colProductoInv.MinimumWidth = 6;
            colProductoInv.Name = "colProductoInv";
            colProductoInv.ReadOnly = true;
            // 
            // colCategoriaInv
            // 
            colCategoriaInv.DataPropertyName = "CategoryName";
            dataGridViewCellStyle89.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colCategoriaInv.DefaultCellStyle = dataGridViewCellStyle89;
            colCategoriaInv.FillWeight = 110F;
            colCategoriaInv.HeaderText = "Categoria";
            colCategoriaInv.MinimumWidth = 6;
            colCategoriaInv.Name = "colCategoriaInv";
            colCategoriaInv.ReadOnly = true;
            // 
            // colUnidadInv
            // 
            colUnidadInv.DataPropertyName = "UnitName";
            dataGridViewCellStyle90.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colUnidadInv.DefaultCellStyle = dataGridViewCellStyle90;
            colUnidadInv.FillWeight = 80F;
            colUnidadInv.HeaderText = "Unidad";
            colUnidadInv.MinimumWidth = 6;
            colUnidadInv.Name = "colUnidadInv";
            colUnidadInv.ReadOnly = true;
            // 
            // colStockActual
            // 
            colStockActual.DataPropertyName = "CurrentStock";
            dataGridViewCellStyle91.Alignment = DataGridViewContentAlignment.MiddleRight;
            colStockActual.DefaultCellStyle = dataGridViewCellStyle91;
            colStockActual.HeaderText = "StockActual";
            colStockActual.MinimumWidth = 6;
            colStockActual.Name = "colStockActual";
            colStockActual.ReadOnly = true;
            // 
            // colStockMinimo
            // 
            colStockMinimo.DataPropertyName = "MinimumStock";
            dataGridViewCellStyle92.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle92.NullValue = null;
            colStockMinimo.DefaultCellStyle = dataGridViewCellStyle92;
            colStockMinimo.HeaderText = "Stock Minimo";
            colStockMinimo.MinimumWidth = 6;
            colStockMinimo.Name = "colStockMinimo";
            colStockMinimo.ReadOnly = true;
            // 
            // colEstadoStock
            // 
            colEstadoStock.DataPropertyName = "StockStatus";
            dataGridViewCellStyle93.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEstadoStock.DefaultCellStyle = dataGridViewCellStyle93;
            colEstadoStock.FillWeight = 95F;
            colEstadoStock.HeaderText = "Estado ";
            colEstadoStock.MinimumWidth = 6;
            colEstadoStock.Name = "colEstadoStock";
            colEstadoStock.ReadOnly = true;
            // 
            // colVencimiento
            // 
            colVencimiento.DataPropertyName = "ExpirationDate";
            dataGridViewCellStyle94.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle94.Format = "d";
            dataGridViewCellStyle94.NullValue = null;
            colVencimiento.DefaultCellStyle = dataGridViewCellStyle94;
            colVencimiento.FillWeight = 110F;
            colVencimiento.HeaderText = "Vencimiento";
            colVencimiento.MinimumWidth = 6;
            colVencimiento.Name = "colVencimiento";
            colVencimiento.ReadOnly = true;
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
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20, 7, 0, 7);
            panel1.Size = new Size(74, 56);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Location = new Point(83, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(190, 56);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Location = new Point(279, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(151, 56);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Location = new Point(436, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(151, 56);
            panel4.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.Location = new Point(593, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(151, 56);
            panel5.TabIndex = 4;
            // 
            // panel6
            // 
            panel6.Location = new Point(750, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(153, 56);
            panel6.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.search_32;
            pictureBox1.Location = new Point(20, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(54, 42);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
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
            tpMovimientos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            pnlFriltrosMovimientos.ResumeLayout(false);
            pnlContainerTab.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            pnlDesde.ResumeLayout(false);
            pnlHasta.ResumeLayout(false);
            pnlMovimiento.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private PictureBox pictureBox1;
    }
}