namespace Ocean_Desk_dv.UI.Catalogs
{
    partial class FrmFacturacion
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
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            pnlFilters = new Panel();
            tlpFilters = new TableLayoutPanel();
            pnlSearch = new Panel();
            pnlSearchInput = new Panel();
            pnlLine = new Panel();
            txtBuscar = new TextBox();
            lblGhost = new Label();
            picSearch = new PictureBox();
            pnlFechaDesde = new Panel();
            dtpFechaDesde = new DateTimePicker();
            lblFechaDesde = new Label();
            pnlFechaHasta = new Panel();
            dtpFechaHasta = new DateTimePicker();
            lblFechaHasta = new Label();
            pnlEstado = new Panel();
            cmbEstado = new ComboBox();
            lblEstado = new Label();
            pnlListado = new Panel();
            dgvFacturas = new DataGridView();
            colFactura = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            pnlActions = new Panel();
            tlpAnular = new TableLayoutPanel();
            btnAnular = new Button();
            tlpButtonsAction = new TableLayoutPanel();
            btnVerDetalle = new Button();
            btnImprimir = new Button();
            pnlFilters.SuspendLayout();
            tlpFilters.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlSearchInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).BeginInit();
            pnlFechaDesde.SuspendLayout();
            pnlFechaHasta.SuspendLayout();
            pnlEstado.SuspendLayout();
            pnlListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            pnlActions.SuspendLayout();
            tlpAnular.SuspendLayout();
            tlpButtonsAction.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.White;
            pnlFilters.Controls.Add(tlpFilters);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(0, 0);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(12, 8, 12, 8);
            pnlFilters.Size = new Size(940, 78);
            pnlFilters.TabIndex = 0;
            // 
            // tlpFilters
            // 
            tlpFilters.ColumnCount = 4;
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpFilters.Controls.Add(pnlSearch, 0, 0);
            tlpFilters.Controls.Add(pnlFechaDesde, 1, 0);
            tlpFilters.Controls.Add(pnlFechaHasta, 2, 0);
            tlpFilters.Controls.Add(pnlEstado, 3, 0);
            tlpFilters.Dock = DockStyle.Fill;
            tlpFilters.Location = new Point(12, 8);
            tlpFilters.Margin = new Padding(0);
            tlpFilters.Name = "tlpFilters";
            tlpFilters.RowCount = 1;
            tlpFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpFilters.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpFilters.Size = new Size(916, 62);
            tlpFilters.TabIndex = 0;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.FromArgb(245, 247, 250);
            pnlSearch.Controls.Add(pnlSearchInput);
            pnlSearch.Controls.Add(lblGhost);
            pnlSearch.Controls.Add(picSearch);
            pnlSearch.Dock = DockStyle.Fill;
            pnlSearch.Location = new Point(0, 0);
            pnlSearch.Margin = new Padding(0);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Padding = new Padding(8, 5, 8, 5);
            pnlSearch.Size = new Size(366, 62);
            pnlSearch.TabIndex = 0;
            // 
            // pnlSearchInput
            // 
            pnlSearchInput.BackColor = Color.White;
            pnlSearchInput.Controls.Add(pnlLine);
            pnlSearchInput.Controls.Add(txtBuscar);
            pnlSearchInput.Dock = DockStyle.Top;
            pnlSearchInput.Location = new Point(43, 15);
            pnlSearchInput.Margin = new Padding(5, 0, 0, 0);
            pnlSearchInput.Name = "pnlSearchInput";
            pnlSearchInput.Size = new Size(315, 32);
            pnlSearchInput.TabIndex = 2;
            // 
            // pnlLine
            // 
            pnlLine.BackColor = Color.MidnightBlue;
            pnlLine.Dock = DockStyle.Bottom;
            pnlLine.Location = new Point(0, 30);
            pnlLine.Margin = new Padding(0);
            pnlLine.Name = "pnlLine";
            pnlLine.Size = new Size(315, 2);
            pnlLine.TabIndex = 2;
            // 
            // txtBuscar
            // 
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Dock = DockStyle.Fill;
            txtBuscar.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(0, 0);
            txtBuscar.Margin = new Padding(0);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Factura...";
            txtBuscar.Size = new Size(315, 21);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblGhost
            // 
            lblGhost.Dock = DockStyle.Top;
            lblGhost.ForeColor = Color.FromArgb(245, 247, 250);
            lblGhost.Location = new Point(43, 5);
            lblGhost.Name = "lblGhost";
            lblGhost.Size = new Size(315, 10);
            lblGhost.TabIndex = 3;
            lblGhost.Text = "label1";
            // 
            // picSearch
            // 
            picSearch.Dock = DockStyle.Left;
            picSearch.Image = Properties.Resources.magnifier;
            picSearch.Location = new Point(8, 5);
            picSearch.Margin = new Padding(0);
            picSearch.Name = "picSearch";
            picSearch.Size = new Size(35, 52);
            picSearch.SizeMode = PictureBoxSizeMode.CenterImage;
            picSearch.TabIndex = 0;
            picSearch.TabStop = false;
            // 
            // pnlFechaDesde
            // 
            pnlFechaDesde.Controls.Add(dtpFechaDesde);
            pnlFechaDesde.Controls.Add(lblFechaDesde);
            pnlFechaDesde.Dock = DockStyle.Fill;
            pnlFechaDesde.Location = new Point(366, 0);
            pnlFechaDesde.Margin = new Padding(0);
            pnlFechaDesde.Name = "pnlFechaDesde";
            pnlFechaDesde.Padding = new Padding(8, 5, 8, 5);
            pnlFechaDesde.Size = new Size(183, 62);
            pnlFechaDesde.TabIndex = 1;
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Dock = DockStyle.Fill;
            dtpFechaDesde.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(8, 23);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(167, 26);
            dtpFechaDesde.TabIndex = 0;
            dtpFechaDesde.ValueChanged += dtpFechaDesde_ValueChanged;
            // 
            // lblFechaDesde
            // 
            lblFechaDesde.Dock = DockStyle.Top;
            lblFechaDesde.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFechaDesde.ForeColor = Color.FromArgb(95, 104, 114);
            lblFechaDesde.Location = new Point(8, 5);
            lblFechaDesde.Name = "lblFechaDesde";
            lblFechaDesde.Size = new Size(167, 18);
            lblFechaDesde.TabIndex = 1;
            lblFechaDesde.Text = "Desde:";
            lblFechaDesde.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlFechaHasta
            // 
            pnlFechaHasta.Controls.Add(dtpFechaHasta);
            pnlFechaHasta.Controls.Add(lblFechaHasta);
            pnlFechaHasta.Dock = DockStyle.Fill;
            pnlFechaHasta.Location = new Point(549, 0);
            pnlFechaHasta.Margin = new Padding(0);
            pnlFechaHasta.Name = "pnlFechaHasta";
            pnlFechaHasta.Padding = new Padding(8, 5, 8, 5);
            pnlFechaHasta.Size = new Size(183, 62);
            pnlFechaHasta.TabIndex = 2;
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Dock = DockStyle.Fill;
            dtpFechaHasta.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(8, 23);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(167, 26);
            dtpFechaHasta.TabIndex = 0;
            dtpFechaHasta.ValueChanged += dtpFechaHasta_ValueChanged;
            // 
            // lblFechaHasta
            // 
            lblFechaHasta.Dock = DockStyle.Top;
            lblFechaHasta.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFechaHasta.ForeColor = Color.FromArgb(95, 104, 114);
            lblFechaHasta.Location = new Point(8, 5);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(167, 18);
            lblFechaHasta.TabIndex = 1;
            lblFechaHasta.Text = "Hasta:";
            lblFechaHasta.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlEstado
            // 
            pnlEstado.Controls.Add(cmbEstado);
            pnlEstado.Controls.Add(lblEstado);
            pnlEstado.Dock = DockStyle.Fill;
            pnlEstado.Location = new Point(732, 0);
            pnlEstado.Margin = new Padding(0);
            pnlEstado.Name = "pnlEstado";
            pnlEstado.Padding = new Padding(8, 5, 8, 5);
            pnlEstado.Size = new Size(184, 62);
            pnlEstado.TabIndex = 3;
            // 
            // cmbEstado
            // 
            cmbEstado.Dock = DockStyle.Fill;
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(8, 23);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(168, 28);
            cmbEstado.TabIndex = 4;
            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;
            // 
            // lblEstado
            // 
            lblEstado.Dock = DockStyle.Top;
            lblEstado.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstado.ForeColor = Color.FromArgb(95, 104, 114);
            lblEstado.Location = new Point(8, 5);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(168, 18);
            lblEstado.TabIndex = 3;
            lblEstado.Text = "Estado:";
            lblEstado.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlListado
            // 
            pnlListado.BackColor = Color.Transparent;
            pnlListado.Controls.Add(dgvFacturas);
            pnlListado.Dock = DockStyle.Fill;
            pnlListado.Location = new Point(0, 78);
            pnlListado.Name = "pnlListado";
            pnlListado.Padding = new Padding(3, 12, 3, 10);
            pnlListado.Size = new Size(940, 687);
            pnlListado.TabIndex = 1;
            // 
            // dgvFacturas
            // 
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.AllowUserToDeleteRows = false;
            dgvFacturas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle1.SelectionBackColor = Color.LightCyan;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dgvFacturas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturas.BackgroundColor = Color.White;
            dgvFacturas.BorderStyle = BorderStyle.None;
            dgvFacturas.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Columns.AddRange(new DataGridViewColumn[] { colFactura, colFecha, colCliente, colTipo, colTotal, colEstado });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgvFacturas.DefaultCellStyle = dataGridViewCellStyle9;
            dgvFacturas.Dock = DockStyle.Fill;
            dgvFacturas.EnableHeadersVisualStyles = false;
            dgvFacturas.GridColor = Color.FromArgb(230, 234, 238);
            dgvFacturas.Location = new Point(3, 12);
            dgvFacturas.MultiSelect = false;
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle10.SelectionForeColor = Color.Black;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dgvFacturas.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dgvFacturas.RowHeadersVisible = false;
            dgvFacturas.RowHeadersWidth = 51;
            dataGridViewCellStyle11.BackColor = Color.White;
            dataGridViewCellStyle11.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle11.SelectionForeColor = Color.Black;
            dgvFacturas.RowsDefaultCellStyle = dataGridViewCellStyle11;
            dgvFacturas.RowTemplate.Height = 38;
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturas.Size = new Size(934, 665);
            dgvFacturas.TabIndex = 0;
            dgvFacturas.CellFormatting += dgvFacturas_CellFormatting;
            dgvFacturas.SelectionChanged += dgvFacturas_SelectionChanged;
            // 
            // colFactura
            // 
            colFactura.DataPropertyName = "NumeroFactura";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colFactura.DefaultCellStyle = dataGridViewCellStyle3;
            colFactura.FillWeight = 15F;
            colFactura.HeaderText = "Factura";
            colFactura.MinimumWidth = 6;
            colFactura.Name = "colFactura";
            colFactura.ReadOnly = true;
            // 
            // colFecha
            // 
            colFecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            colFecha.DefaultCellStyle = dataGridViewCellStyle4;
            colFecha.FillWeight = 15F;
            colFecha.HeaderText = "Fecha";
            colFecha.MinimumWidth = 6;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colCliente
            // 
            colCliente.DataPropertyName = "Cliente";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colCliente.DefaultCellStyle = dataGridViewCellStyle5;
            colCliente.FillWeight = 30F;
            colCliente.HeaderText = "Cliente";
            colCliente.MinimumWidth = 6;
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            // 
            // colTipo
            // 
            colTipo.DataPropertyName = "TipoOrden";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTipo.DefaultCellStyle = dataGridViewCellStyle6;
            colTipo.FillWeight = 15F;
            colTipo.HeaderText = "Tipo";
            colTipo.MinimumWidth = 6;
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            // 
            // colTotal
            // 
            colTotal.DataPropertyName = "Total";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            colTotal.DefaultCellStyle = dataGridViewCellStyle7;
            colTotal.FillWeight = 15F;
            colTotal.HeaderText = "Total";
            colTotal.MinimumWidth = 6;
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.DataPropertyName = "Estado";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEstado.DefaultCellStyle = dataGridViewCellStyle8;
            colEstado.FillWeight = 10F;
            colEstado.HeaderText = "Estado";
            colEstado.MinimumWidth = 6;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.White;
            pnlActions.Controls.Add(tlpAnular);
            pnlActions.Controls.Add(tlpButtonsAction);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 765);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(15, 6, 15, 6);
            pnlActions.Size = new Size(940, 65);
            pnlActions.TabIndex = 1;
            // 
            // tlpAnular
            // 
            tlpAnular.ColumnCount = 1;
            tlpAnular.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpAnular.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpAnular.Controls.Add(btnAnular, 0, 0);
            tlpAnular.Dock = DockStyle.Right;
            tlpAnular.Location = new Point(725, 6);
            tlpAnular.Margin = new Padding(0);
            tlpAnular.Name = "tlpAnular";
            tlpAnular.RowCount = 1;
            tlpAnular.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpAnular.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpAnular.Size = new Size(200, 53);
            tlpAnular.TabIndex = 4;
            // 
            // btnAnular
            // 
            btnAnular.BackColor = Color.FromArgb(248, 234, 234);
            btnAnular.Cursor = Cursors.Hand;
            btnAnular.Dock = DockStyle.Fill;
            btnAnular.FlatAppearance.BorderSize = 0;
            btnAnular.FlatStyle = FlatStyle.Flat;
            btnAnular.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAnular.ForeColor = Color.FromArgb(163, 61, 61);
            btnAnular.Location = new Point(5, 5);
            btnAnular.Margin = new Padding(5);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(190, 43);
            btnAnular.TabIndex = 2;
            btnAnular.Text = "ANULAR";
            btnAnular.UseVisualStyleBackColor = false;
            btnAnular.Click += btnAnular_Click;
            // 
            // tlpButtonsAction
            // 
            tlpButtonsAction.ColumnCount = 2;
            tlpButtonsAction.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.99999F));
            tlpButtonsAction.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0000076F));
            tlpButtonsAction.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpButtonsAction.Controls.Add(btnVerDetalle, 0, 0);
            tlpButtonsAction.Controls.Add(btnImprimir, 1, 0);
            tlpButtonsAction.Dock = DockStyle.Left;
            tlpButtonsAction.Location = new Point(15, 6);
            tlpButtonsAction.Margin = new Padding(5);
            tlpButtonsAction.Name = "tlpButtonsAction";
            tlpButtonsAction.RowCount = 1;
            tlpButtonsAction.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpButtonsAction.Size = new Size(380, 53);
            tlpButtonsAction.TabIndex = 3;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.BackColor = Color.FromArgb(238, 243, 247);
            btnVerDetalle.Cursor = Cursors.Hand;
            btnVerDetalle.Dock = DockStyle.Fill;
            btnVerDetalle.FlatAppearance.BorderSize = 0;
            btnVerDetalle.FlatStyle = FlatStyle.Flat;
            btnVerDetalle.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerDetalle.ForeColor = Color.FromArgb(8, 31, 63);
            btnVerDetalle.Location = new Point(3, 3);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(183, 47);
            btnVerDetalle.TabIndex = 0;
            btnVerDetalle.Text = "VER DETALLE";
            btnVerDetalle.UseVisualStyleBackColor = false;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.FromArgb(238, 243, 247);
            btnImprimir.Cursor = Cursors.Hand;
            btnImprimir.Dock = DockStyle.Fill;
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImprimir.ForeColor = Color.FromArgb(8, 31, 63);
            btnImprimir.Location = new Point(192, 3);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(185, 47);
            btnImprimir.TabIndex = 1;
            btnImprimir.Text = "IMPRIMIR";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // FrmFacturacion
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(pnlListado);
            Controls.Add(pnlActions);
            Controls.Add(pnlFilters);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmFacturacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFacturacion";
            pnlFilters.ResumeLayout(false);
            tlpFilters.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearchInput.ResumeLayout(false);
            pnlSearchInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).EndInit();
            pnlFechaDesde.ResumeLayout(false);
            pnlFechaHasta.ResumeLayout(false);
            pnlEstado.ResumeLayout(false);
            pnlListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            pnlActions.ResumeLayout(false);
            tlpAnular.ResumeLayout(false);
            tlpButtonsAction.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFilters;
        private TableLayoutPanel tlpFilters;
        private Panel pnlSearch;
        private PictureBox picSearch;
        private TextBox txtBuscar;
        private Panel pnlLine;
        private Panel pnlFechaDesde;
        private Panel pnlFechaHasta;
        private Label lblFechaDesde;
        private DateTimePicker dtpFechaDesde;
        private DateTimePicker dtpFechaHasta;
        private Label lblFechaHasta;
        private Panel pnlEstado;
        private ComboBox cmbEstado;
        private Label lblEstado;
        private Panel pnlListado;
        private DataGridView dgvFacturas;
        private Panel pnlActions;
        private Button btnVerDetalle;
        private Button btnImprimir;
        private TableLayoutPanel tlpButtonsAction;
        private Button btnAnular;
        private TableLayoutPanel tlpAnular;
        private Panel pnlSearchInput;
        private Label lblGhost;
        private DataGridViewTextBoxColumn colFactura;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colEstado;
    }
}