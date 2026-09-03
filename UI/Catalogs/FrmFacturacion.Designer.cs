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
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
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
            pnlDetalleFacturaContainer = new Panel();
            pnlDetalleFactura = new Panel();
            btnCerrarDetalle = new Button();
            lblEstadoDetalle = new Label();
            lblEstadoTit = new Label();
            lblTotalFactura = new Label();
            lblTotal = new Label();
            lblTipoOrdenDetalle = new Label();
            lblTipoOrden = new Label();
            lblClienteDetalle = new Label();
            lblCliente = new Label();
            lblFechaDetalle = new Label();
            lblFecha = new Label();
            lblNumeroFacturaDetalle = new Label();
            lblFactura = new Label();
            lblTituloDetalle = new Label();
            pnlActions = new Panel();
            tlpAnular = new TableLayoutPanel();
            btnAnular = new Button();
            tlpButtonsAction = new TableLayoutPanel();
            btnVerDetalle = new Button();
            btnImprimir = new Button();
            tlpFacturaFecha = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblMesa = new Label();
            lblMesaDetalle = new Label();
            dataGridView1 = new DataGridView();
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
            pnlDetalleFacturaContainer.SuspendLayout();
            pnlDetalleFactura.SuspendLayout();
            pnlActions.SuspendLayout();
            tlpAnular.SuspendLayout();
            tlpButtonsAction.SuspendLayout();
            tlpFacturaFecha.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            dataGridViewCellStyle12.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle12.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.ForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle12.SelectionBackColor = Color.LightCyan;
            dataGridViewCellStyle12.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dgvFacturas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturas.BackgroundColor = Color.White;
            dgvFacturas.BorderStyle = BorderStyle.None;
            dgvFacturas.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle13.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle13.ForeColor = Color.White;
            dataGridViewCellStyle13.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle13.SelectionBackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle13.SelectionForeColor = Color.White;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            dgvFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Columns.AddRange(new DataGridViewColumn[] { colFactura, colFecha, colCliente, colTipo, colTotal, colEstado });
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = Color.White;
            dataGridViewCellStyle20.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle20.ForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle20.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle20.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle20.WrapMode = DataGridViewTriState.False;
            dgvFacturas.DefaultCellStyle = dataGridViewCellStyle20;
            dgvFacturas.Dock = DockStyle.Fill;
            dgvFacturas.EnableHeadersVisualStyles = false;
            dgvFacturas.GridColor = Color.FromArgb(230, 234, 238);
            dgvFacturas.Location = new Point(3, 12);
            dgvFacturas.MultiSelect = false;
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.ReadOnly = true;
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = Color.White;
            dataGridViewCellStyle21.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle21.ForeColor = Color.Black;
            dataGridViewCellStyle21.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle21.SelectionForeColor = Color.Black;
            dataGridViewCellStyle21.WrapMode = DataGridViewTriState.True;
            dgvFacturas.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            dgvFacturas.RowHeadersVisible = false;
            dgvFacturas.RowHeadersWidth = 51;
            dataGridViewCellStyle22.BackColor = Color.White;
            dataGridViewCellStyle22.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle22.ForeColor = Color.Black;
            dataGridViewCellStyle22.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle22.SelectionForeColor = Color.Black;
            dgvFacturas.RowsDefaultCellStyle = dataGridViewCellStyle22;
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
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colFactura.DefaultCellStyle = dataGridViewCellStyle14;
            colFactura.FillWeight = 15F;
            colFactura.HeaderText = "Factura";
            colFactura.MinimumWidth = 6;
            colFactura.Name = "colFactura";
            colFactura.ReadOnly = true;
            // 
            // colFecha
            // 
            colFecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Format = "d";
            dataGridViewCellStyle15.NullValue = null;
            colFecha.DefaultCellStyle = dataGridViewCellStyle15;
            colFecha.FillWeight = 15F;
            colFecha.HeaderText = "Fecha";
            colFecha.MinimumWidth = 6;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colCliente
            // 
            colCliente.DataPropertyName = "Cliente";
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colCliente.DefaultCellStyle = dataGridViewCellStyle16;
            colCliente.FillWeight = 30F;
            colCliente.HeaderText = "Cliente";
            colCliente.MinimumWidth = 6;
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            // 
            // colTipo
            // 
            colTipo.DataPropertyName = "TipoOrden";
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTipo.DefaultCellStyle = dataGridViewCellStyle17;
            colTipo.FillWeight = 15F;
            colTipo.HeaderText = "Tipo";
            colTipo.MinimumWidth = 6;
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            // 
            // colTotal
            // 
            colTotal.DataPropertyName = "Total";
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "C2";
            dataGridViewCellStyle18.NullValue = null;
            colTotal.DefaultCellStyle = dataGridViewCellStyle18;
            colTotal.FillWeight = 15F;
            colTotal.HeaderText = "Total";
            colTotal.MinimumWidth = 6;
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.DataPropertyName = "Estado";
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEstado.DefaultCellStyle = dataGridViewCellStyle19;
            colEstado.FillWeight = 10F;
            colEstado.HeaderText = "Estado";
            colEstado.MinimumWidth = 6;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // pnlDetalleFacturaContainer
            // 
            pnlDetalleFacturaContainer.Controls.Add(pnlDetalleFactura);
            pnlDetalleFacturaContainer.Dock = DockStyle.Fill;
            pnlDetalleFacturaContainer.Location = new Point(0, 78);
            pnlDetalleFacturaContainer.Name = "pnlDetalleFacturaContainer";
            pnlDetalleFacturaContainer.Padding = new Padding(25);
            pnlDetalleFacturaContainer.Size = new Size(940, 687);
            pnlDetalleFacturaContainer.TabIndex = 1;
            pnlDetalleFacturaContainer.Visible = false;
            // 
            // pnlDetalleFactura
            // 
            pnlDetalleFactura.BackColor = Color.White;
            pnlDetalleFactura.Controls.Add(dataGridView1);
            pnlDetalleFactura.Controls.Add(lblTotalFactura);
            pnlDetalleFactura.Controls.Add(tableLayoutPanel2);
            pnlDetalleFactura.Controls.Add(lblTotal);
            pnlDetalleFactura.Controls.Add(tableLayoutPanel1);
            pnlDetalleFactura.Controls.Add(tlpFacturaFecha);
            pnlDetalleFactura.Controls.Add(btnCerrarDetalle);
            pnlDetalleFactura.Controls.Add(lblTituloDetalle);
            pnlDetalleFactura.Location = new Point(94, 28);
            pnlDetalleFactura.Name = "pnlDetalleFactura";
            pnlDetalleFactura.Padding = new Padding(25, 20, 25, 20);
            pnlDetalleFactura.Size = new Size(650, 622);
            pnlDetalleFactura.TabIndex = 2;
            // 
            // btnCerrarDetalle
            // 
            btnCerrarDetalle.BackColor = Color.FromArgb(238, 243, 247);
            btnCerrarDetalle.FlatAppearance.BorderSize = 0;
            btnCerrarDetalle.FlatStyle = FlatStyle.Flat;
            btnCerrarDetalle.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrarDetalle.Location = new Point(399, 543);
            btnCerrarDetalle.Name = "btnCerrarDetalle";
            btnCerrarDetalle.Size = new Size(129, 42);
            btnCerrarDetalle.TabIndex = 13;
            btnCerrarDetalle.Text = "CERRAR";
            btnCerrarDetalle.UseVisualStyleBackColor = false;
            btnCerrarDetalle.Click += btnCerrarDetalle_Click;
            // 
            // lblEstadoDetalle
            // 
            lblEstadoDetalle.BackColor = Color.White;
            lblEstadoDetalle.Dock = DockStyle.Fill;
            lblEstadoDetalle.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstadoDetalle.Location = new Point(453, 0);
            lblEstadoDetalle.Name = "lblEstadoDetalle";
            lblEstadoDetalle.Size = new Size(144, 42);
            lblEstadoDetalle.TabIndex = 12;
            lblEstadoDetalle.Text = "Anulada";
            lblEstadoDetalle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblEstadoTit
            // 
            lblEstadoTit.BackColor = Color.White;
            lblEstadoTit.Dock = DockStyle.Fill;
            lblEstadoTit.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstadoTit.Location = new Point(303, 0);
            lblEstadoTit.Name = "lblEstadoTit";
            lblEstadoTit.Size = new Size(144, 42);
            lblEstadoTit.TabIndex = 11;
            lblEstadoTit.Text = "Estado:";
            lblEstadoTit.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalFactura
            // 
            lblTotalFactura.BackColor = Color.FromArgb(224, 234, 240);
            lblTotalFactura.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalFactura.Location = new Point(316, 472);
            lblTotalFactura.Name = "lblTotalFactura";
            lblTotalFactura.Size = new Size(200, 42);
            lblTotalFactura.TabIndex = 10;
            lblTotalFactura.Text = "C$ 0.00";
            lblTotalFactura.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            lblTotal.BackColor = Color.FromArgb(224, 234, 240);
            lblTotal.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(132, 509);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(93, 42);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "Total:";
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTipoOrdenDetalle
            // 
            lblTipoOrdenDetalle.BackColor = Color.White;
            lblTipoOrdenDetalle.Dock = DockStyle.Fill;
            lblTipoOrdenDetalle.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTipoOrdenDetalle.Location = new Point(453, 0);
            lblTipoOrdenDetalle.Name = "lblTipoOrdenDetalle";
            lblTipoOrdenDetalle.Size = new Size(144, 42);
            lblTipoOrdenDetalle.TabIndex = 8;
            lblTipoOrdenDetalle.Text = "Local";
            lblTipoOrdenDetalle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTipoOrden
            // 
            lblTipoOrden.BackColor = Color.White;
            lblTipoOrden.Dock = DockStyle.Fill;
            lblTipoOrden.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTipoOrden.Location = new Point(303, 0);
            lblTipoOrden.Name = "lblTipoOrden";
            lblTipoOrden.Size = new Size(144, 42);
            lblTipoOrden.TabIndex = 7;
            lblTipoOrden.Text = "Tipo de Orden:";
            lblTipoOrden.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblClienteDetalle
            // 
            lblClienteDetalle.BackColor = Color.White;
            lblClienteDetalle.Dock = DockStyle.Fill;
            lblClienteDetalle.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblClienteDetalle.Location = new Point(153, 0);
            lblClienteDetalle.Name = "lblClienteDetalle";
            lblClienteDetalle.Size = new Size(144, 42);
            lblClienteDetalle.TabIndex = 6;
            lblClienteDetalle.Text = "Carlos Putin";
            lblClienteDetalle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCliente
            // 
            lblCliente.BackColor = Color.White;
            lblCliente.Dock = DockStyle.Fill;
            lblCliente.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCliente.Location = new Point(3, 0);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(144, 42);
            lblCliente.TabIndex = 5;
            lblCliente.Text = "Cliente:";
            lblCliente.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFechaDetalle
            // 
            lblFechaDetalle.BackColor = Color.White;
            lblFechaDetalle.Dock = DockStyle.Fill;
            lblFechaDetalle.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFechaDetalle.Location = new Point(453, 0);
            lblFechaDetalle.Name = "lblFechaDetalle";
            lblFechaDetalle.Size = new Size(144, 42);
            lblFechaDetalle.TabIndex = 4;
            lblFechaDetalle.Text = "03/09/2026";
            lblFechaDetalle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFecha
            // 
            lblFecha.BackColor = Color.White;
            lblFecha.Dock = DockStyle.Fill;
            lblFecha.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(303, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(144, 42);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "Fecha:";
            lblFecha.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNumeroFacturaDetalle
            // 
            lblNumeroFacturaDetalle.BackColor = Color.White;
            lblNumeroFacturaDetalle.Dock = DockStyle.Fill;
            lblNumeroFacturaDetalle.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNumeroFacturaDetalle.Location = new Point(153, 0);
            lblNumeroFacturaDetalle.Name = "lblNumeroFacturaDetalle";
            lblNumeroFacturaDetalle.Size = new Size(144, 42);
            lblNumeroFacturaDetalle.TabIndex = 2;
            lblNumeroFacturaDetalle.Text = "F001-0001 ";
            lblNumeroFacturaDetalle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFactura
            // 
            lblFactura.BackColor = Color.White;
            lblFactura.Dock = DockStyle.Fill;
            lblFactura.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFactura.Location = new Point(3, 0);
            lblFactura.Name = "lblFactura";
            lblFactura.Size = new Size(144, 42);
            lblFactura.TabIndex = 1;
            lblFactura.Text = "Factura:";
            lblFactura.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTituloDetalle
            // 
            lblTituloDetalle.Dock = DockStyle.Top;
            lblTituloDetalle.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloDetalle.Location = new Point(25, 20);
            lblTituloDetalle.Name = "lblTituloDetalle";
            lblTituloDetalle.Size = new Size(600, 56);
            lblTituloDetalle.TabIndex = 0;
            lblTituloDetalle.Text = "DETALLE DE FACTURA";
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
            // tlpFacturaFecha
            // 
            tlpFacturaFecha.ColumnCount = 4;
            tlpFacturaFecha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpFacturaFecha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpFacturaFecha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpFacturaFecha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpFacturaFecha.Controls.Add(lblFecha, 2, 0);
            tlpFacturaFecha.Controls.Add(lblFechaDetalle, 3, 0);
            tlpFacturaFecha.Controls.Add(lblFactura, 0, 0);
            tlpFacturaFecha.Controls.Add(lblNumeroFacturaDetalle, 1, 0);
            tlpFacturaFecha.Dock = DockStyle.Top;
            tlpFacturaFecha.Location = new Point(25, 76);
            tlpFacturaFecha.Name = "tlpFacturaFecha";
            tlpFacturaFecha.RowCount = 1;
            tlpFacturaFecha.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpFacturaFecha.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpFacturaFecha.Size = new Size(600, 42);
            tlpFacturaFecha.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(lblTipoOrden, 2, 0);
            tableLayoutPanel1.Controls.Add(lblClienteDetalle, 1, 0);
            tableLayoutPanel1.Controls.Add(lblCliente, 0, 0);
            tableLayoutPanel1.Controls.Add(lblTipoOrdenDetalle, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(25, 118);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(600, 42);
            tableLayoutPanel1.TabIndex = 20;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(lblMesaDetalle, 1, 0);
            tableLayoutPanel2.Controls.Add(lblMesa, 0, 0);
            tableLayoutPanel2.Controls.Add(lblEstadoDetalle, 3, 0);
            tableLayoutPanel2.Controls.Add(lblEstadoTit, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(25, 160);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(600, 42);
            tableLayoutPanel2.TabIndex = 21;
            // 
            // lblMesa
            // 
            lblMesa.BackColor = Color.White;
            lblMesa.Dock = DockStyle.Fill;
            lblMesa.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMesa.Location = new Point(3, 0);
            lblMesa.Name = "lblMesa";
            lblMesa.Size = new Size(144, 42);
            lblMesa.TabIndex = 13;
            lblMesa.Text = "Mesa:";
            lblMesa.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMesaDetalle
            // 
            lblMesaDetalle.BackColor = Color.White;
            lblMesaDetalle.Dock = DockStyle.Fill;
            lblMesaDetalle.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMesaDetalle.Location = new Point(153, 0);
            lblMesaDetalle.Name = "lblMesaDetalle";
            lblMesaDetalle.Size = new Size(144, 42);
            lblMesaDetalle.TabIndex = 14;
            lblMesaDetalle.Text = "05";
            lblMesaDetalle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(234, 258);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(300, 188);
            dataGridView1.TabIndex = 22;
            // 
            // FrmFacturacion
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(pnlDetalleFacturaContainer);
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
            pnlDetalleFacturaContainer.ResumeLayout(false);
            pnlDetalleFactura.ResumeLayout(false);
            pnlActions.ResumeLayout(false);
            tlpAnular.ResumeLayout(false);
            tlpButtonsAction.ResumeLayout(false);
            tlpFacturaFecha.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private Panel pnlDetalleFacturaContainer;
        private Label lblTituloDetalle;
        private Label lblFactura;
        private Panel pnlDetalleFactura;
        private Label lblNumeroFacturaDetalle;
        private Label lblFechaDetalle;
        private Label lblFecha;
        private Button btnCerrarDetalle;
        private Label lblEstadoDetalle;
        private Label lblEstadoTit;
        private Label label2;
        private Label lblTotal;
        private Label lblTipoOrdenDetalle;
        private Label lblTipoOrden;
        private Label lblClienteDetalle;
        private Label lblCliente;
        private Label lblTotalFactura;
        private TableLayoutPanel tlpFacturaFecha;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblMesa;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblMesaDetalle;
        private DataGridView dataGridView1;
    }
}