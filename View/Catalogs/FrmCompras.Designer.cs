namespace Ocean_Desk_dv.View.Catalogs
{
    partial class FrmCompras
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            pnlBarraCompras = new Panel();
            tlpBarraCompras = new TableLayoutPanel();
            txtBuscarCompra = new TextBox();
            dtpFechaCompraFiltro = new DateTimePicker();
            cmbEstadoCompra = new ComboBox();
            btnNuevaCompra = new Button();
            splCompras = new SplitContainer();
            dgvCompras = new DataGridView();
            colIdCompra = new DataGridViewTextBoxColumn();
            colFechaCompra = new DataGridViewTextBoxColumn();
            colProveedorCompra = new DataGridViewTextBoxColumn();
            colTotalCompra = new DataGridViewTextBoxColumn();
            colEstadoCompra = new DataGridViewTextBoxColumn();
            colRecibidaCompra = new DataGridViewTextBoxColumn();
            dgvDetalleCompra = new DataGridView();
            colProductoCompra = new DataGridViewTextBoxColumn();
            colUnidadCompra = new DataGridViewTextBoxColumn();
            colCantidadCompra = new DataGridViewTextBoxColumn();
            colCostoCompra = new DataGridViewTextBoxColumn();
            colSubtotalCompra = new DataGridViewTextBoxColumn();
            colRecepcionCompra = new DataGridViewTextBoxColumn();
            colObservacionCompra = new DataGridViewTextBoxColumn();
            pnlAccionesDetalle = new Panel();
            btnRegistrarRecepcion = new Button();
            btnAgregarProducto = new Button();
            pnlDatosCompra = new Panel();
            txtNotasCompra = new TextBox();
            lblNotasCompra = new Label();
            txtDocumentoCompra = new TextBox();
            lblDocumentoCompra = new Label();
            dtpFechaCompra = new DateTimePicker();
            lblFechaCompra = new Label();
            cmbProveedorCompra = new ComboBox();
            lblProveedorCompra = new Label();
            pnlResumenCompra = new Panel();
            btnGuardarCompra = new Button();
            btnCancelarCompra = new Button();
            lblTotalCompra = new Label();
            lblSubtotalCompra = new Label();
            pnlContenido = new Panel();
            pnlBarraCompras.SuspendLayout();
            tlpBarraCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splCompras).BeginInit();
            splCompras.Panel1.SuspendLayout();
            splCompras.Panel2.SuspendLayout();
            splCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleCompra).BeginInit();
            pnlAccionesDetalle.SuspendLayout();
            pnlDatosCompra.SuspendLayout();
            pnlResumenCompra.SuspendLayout();
            pnlContenido.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBarraCompras
            // 
            pnlBarraCompras.Controls.Add(tlpBarraCompras);
            pnlBarraCompras.Dock = DockStyle.Top;
            pnlBarraCompras.Location = new Point(0, 0);
            pnlBarraCompras.Name = "pnlBarraCompras";
            pnlBarraCompras.Padding = new Padding(12, 8, 12, 8);
            pnlBarraCompras.Size = new Size(940, 78);
            pnlBarraCompras.TabIndex = 3;
            // 
            // tlpBarraCompras
            // 
            tlpBarraCompras.ColumnCount = 4;
            tlpBarraCompras.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpBarraCompras.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpBarraCompras.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpBarraCompras.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135F));
            tlpBarraCompras.Controls.Add(txtBuscarCompra, 0, 0);
            tlpBarraCompras.Controls.Add(dtpFechaCompraFiltro, 1, 0);
            tlpBarraCompras.Controls.Add(cmbEstadoCompra, 2, 0);
            tlpBarraCompras.Controls.Add(btnNuevaCompra, 3, 0);
            tlpBarraCompras.Dock = DockStyle.Fill;
            tlpBarraCompras.Location = new Point(12, 8);
            tlpBarraCompras.Margin = new Padding(0);
            tlpBarraCompras.Name = "tlpBarraCompras";
            tlpBarraCompras.RowCount = 1;
            tlpBarraCompras.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBarraCompras.Size = new Size(916, 62);
            tlpBarraCompras.TabIndex = 1;
            // 
            // txtBuscarCompra
            // 
            txtBuscarCompra.BorderStyle = BorderStyle.None;
            txtBuscarCompra.CausesValidation = false;
            txtBuscarCompra.Dock = DockStyle.Fill;
            txtBuscarCompra.Font = new Font("Century Gothic", 10.2F);
            txtBuscarCompra.Location = new Point(3, 3);
            txtBuscarCompra.Name = "txtBuscarCompra";
            txtBuscarCompra.Size = new Size(475, 21);
            txtBuscarCompra.TabIndex = 0;
            // 
            // dtpFechaCompraFiltro
            // 
            dtpFechaCompraFiltro.Font = new Font("Century Gothic", 9F);
            dtpFechaCompraFiltro.Format = DateTimePickerFormat.Short;
            dtpFechaCompraFiltro.Location = new Point(484, 3);
            dtpFechaCompraFiltro.Name = "dtpFechaCompraFiltro";
            dtpFechaCompraFiltro.Size = new Size(144, 26);
            dtpFechaCompraFiltro.TabIndex = 1;
            // 
            // cmbEstadoCompra
            // 
            cmbEstadoCompra.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoCompra.Font = new Font("Century Gothic", 10.2F);
            cmbEstadoCompra.FormattingEnabled = true;
            cmbEstadoCompra.Items.AddRange(new object[] { "Todos,", "Pendiente, ", "Recibida, ", "Anulada." });
            cmbEstadoCompra.Location = new Point(634, 3);
            cmbEstadoCompra.Name = "cmbEstadoCompra";
            cmbEstadoCompra.Size = new Size(144, 29);
            cmbEstadoCompra.TabIndex = 0;
            // 
            // btnNuevaCompra
            // 
            btnNuevaCompra.BackColor = Color.FromArgb(8, 126, 164);
            btnNuevaCompra.FlatAppearance.BorderSize = 0;
            btnNuevaCompra.FlatStyle = FlatStyle.Flat;
            btnNuevaCompra.ForeColor = Color.White;
            btnNuevaCompra.Location = new Point(784, 3);
            btnNuevaCompra.Name = "btnNuevaCompra";
            btnNuevaCompra.Size = new Size(129, 25);
            btnNuevaCompra.TabIndex = 2;
            btnNuevaCompra.Text = "Nueva compra";
            btnNuevaCompra.UseVisualStyleBackColor = false;
            btnNuevaCompra.Click += btnNuevaCompra_Click;
            // 
            // splCompras
            // 
            splCompras.Dock = DockStyle.Fill;
            splCompras.Location = new Point(3, 12);
            splCompras.Name = "splCompras";
            // 
            // splCompras.Panel1
            // 
            splCompras.Panel1.Controls.Add(dgvCompras);
            // 
            // splCompras.Panel2
            // 
            splCompras.Panel2.BackColor = Color.FromArgb(14, 158, 45, 18);
            splCompras.Panel2.Controls.Add(dgvDetalleCompra);
            splCompras.Panel2.Controls.Add(pnlAccionesDetalle);
            splCompras.Panel2.Controls.Add(pnlDatosCompra);
            splCompras.Panel2.Controls.Add(pnlResumenCompra);
            splCompras.Size = new Size(934, 808);
            splCompras.SplitterDistance = 450;
            splCompras.TabIndex = 0;
            // 
            // dgvCompras
            // 
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(14, 203, 255, 140);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 9.8F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(0, 1, 68, 219);
            dgvCompras.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompras.BackgroundColor = Color.White;
            dgvCompras.BorderStyle = BorderStyle.None;
            dgvCompras.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 8.25F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompras.Columns.AddRange(new DataGridViewColumn[] { colIdCompra, colFechaCompra, colProveedorCompra, colTotalCompra, colEstadoCompra, colRecibidaCompra });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Century Gothic", 8.25F);
            dataGridViewCellStyle9.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgvCompras.DefaultCellStyle = dataGridViewCellStyle9;
            dgvCompras.Dock = DockStyle.Fill;
            dgvCompras.EnableHeadersVisualStyles = false;
            dgvCompras.GridColor = SystemColors.Menu;
            dgvCompras.Location = new Point(0, 0);
            dgvCompras.MultiSelect = false;
            dgvCompras.Name = "dgvCompras";
            dgvCompras.ReadOnly = true;
            dgvCompras.RowHeadersVisible = false;
            dgvCompras.RowHeadersWidth = 51;
            dgvCompras.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(15, 54, 226, 215);
            dgvCompras.RowTemplate.DefaultCellStyle.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvCompras.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(0, 1, 68, 219);
            dgvCompras.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(13, 93, 139, 0);
            dgvCompras.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 1, 68, 219);
            dgvCompras.RowTemplate.Height = 38;
            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.Size = new Size(450, 808);
            dgvCompras.TabIndex = 0;
            // 
            // colIdCompra
            // 
            colIdCompra.DataPropertyName = "PurchaseId";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colIdCompra.DefaultCellStyle = dataGridViewCellStyle3;
            colIdCompra.FillWeight = 65F;
            colIdCompra.HeaderText = "\tN.º";
            colIdCompra.MinimumWidth = 6;
            colIdCompra.Name = "colIdCompra";
            colIdCompra.ReadOnly = true;
            // 
            // colFechaCompra
            // 
            colFechaCompra.DataPropertyName = "PurchaseDate";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            colFechaCompra.DefaultCellStyle = dataGridViewCellStyle4;
            colFechaCompra.FillWeight = 105F;
            colFechaCompra.HeaderText = "Fecha";
            colFechaCompra.MinimumWidth = 6;
            colFechaCompra.Name = "colFechaCompra";
            colFechaCompra.ReadOnly = true;
            // 
            // colProveedorCompra
            // 
            colProveedorCompra.DataPropertyName = "SupplierName";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colProveedorCompra.DefaultCellStyle = dataGridViewCellStyle5;
            colProveedorCompra.FillWeight = 180F;
            colProveedorCompra.HeaderText = "Proveedor";
            colProveedorCompra.MinimumWidth = 6;
            colProveedorCompra.Name = "colProveedorCompra";
            colProveedorCompra.ReadOnly = true;
            // 
            // colTotalCompra
            // 
            colTotalCompra.DataPropertyName = "Total";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C$ #,##0.00";
            colTotalCompra.DefaultCellStyle = dataGridViewCellStyle6;
            colTotalCompra.FillWeight = 105F;
            colTotalCompra.HeaderText = "Total";
            colTotalCompra.MinimumWidth = 6;
            colTotalCompra.Name = "colTotalCompra";
            colTotalCompra.ReadOnly = true;
            // 
            // colEstadoCompra
            // 
            colEstadoCompra.DataPropertyName = "Status";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEstadoCompra.DefaultCellStyle = dataGridViewCellStyle7;
            colEstadoCompra.FillWeight = 105F;
            colEstadoCompra.HeaderText = "Estado";
            colEstadoCompra.MinimumWidth = 6;
            colEstadoCompra.Name = "colEstadoCompra";
            colEstadoCompra.ReadOnly = true;
            // 
            // colRecibidaCompra
            // 
            colRecibidaCompra.DataPropertyName = "ReceivedDate";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "dd/MM/yyyy";
            colRecibidaCompra.DefaultCellStyle = dataGridViewCellStyle8;
            colRecibidaCompra.FillWeight = 110F;
            colRecibidaCompra.HeaderText = "Recepción";
            colRecibidaCompra.MinimumWidth = 6;
            colRecibidaCompra.Name = "colRecibidaCompra";
            colRecibidaCompra.ReadOnly = true;
            // 
            // dgvDetalleCompra
            // 
            dgvDetalleCompra.AllowUserToDeleteRows = false;
            dgvDetalleCompra.AllowUserToResizeColumns = false;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle10.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.FromArgb(8, 31, 63);
            dgvDetalleCompra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dgvDetalleCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleCompra.BackgroundColor = Color.White;
            dgvDetalleCompra.BorderStyle = BorderStyle.None;
            dgvDetalleCompra.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle11.Font = new Font("Century Gothic", 8.25F);
            dataGridViewCellStyle11.ForeColor = Color.White;
            dataGridViewCellStyle11.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle11.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            dgvDetalleCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dgvDetalleCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleCompra.Columns.AddRange(new DataGridViewColumn[] { colProductoCompra, colUnidadCompra, colCantidadCompra, colCostoCompra, colSubtotalCompra, colRecepcionCompra, colObservacionCompra });
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.White;
            dataGridViewCellStyle12.Font = new Font("Century Gothic", 8.25F);
            dataGridViewCellStyle12.ForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            dgvDetalleCompra.DefaultCellStyle = dataGridViewCellStyle12;
            dgvDetalleCompra.Dock = DockStyle.Fill;
            dgvDetalleCompra.EnableHeadersVisualStyles = false;
            dgvDetalleCompra.GridColor = Color.FromArgb(230, 234, 238);
            dgvDetalleCompra.Location = new Point(0, 298);
            dgvDetalleCompra.MultiSelect = false;
            dgvDetalleCompra.Name = "dgvDetalleCompra";
            dgvDetalleCompra.ReadOnly = true;
            dgvDetalleCompra.RightToLeft = RightToLeft.No;
            dgvDetalleCompra.RowHeadersVisible = false;
            dgvDetalleCompra.RowHeadersWidth = 51;
            dgvDetalleCompra.RowTemplate.Height = 38;
            dgvDetalleCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleCompra.Size = new Size(480, 397);
            dgvDetalleCompra.TabIndex = 94;
            // 
            // colProductoCompra
            // 
            colProductoCompra.DataPropertyName = "ProductName";
            colProductoCompra.FillWeight = 200F;
            colProductoCompra.HeaderText = "Producto";
            colProductoCompra.MinimumWidth = 6;
            colProductoCompra.Name = "colProductoCompra";
            colProductoCompra.ReadOnly = true;
            // 
            // colUnidadCompra
            // 
            colUnidadCompra.DataPropertyName = "UnitName";
            colUnidadCompra.FillWeight = 80F;
            colUnidadCompra.HeaderText = "Unidad";
            colUnidadCompra.MinimumWidth = 6;
            colUnidadCompra.Name = "colUnidadCompra";
            colUnidadCompra.ReadOnly = true;
            // 
            // colCantidadCompra
            // 
            colCantidadCompra.DataPropertyName = "Quantity";
            colCantidadCompra.FillWeight = 95F;
            colCantidadCompra.HeaderText = "Cantidad";
            colCantidadCompra.MinimumWidth = 6;
            colCantidadCompra.Name = "colCantidadCompra";
            colCantidadCompra.ReadOnly = true;
            // 
            // colCostoCompra
            // 
            colCostoCompra.DataPropertyName = "UnitCost";
            colCostoCompra.FillWeight = 105F;
            colCostoCompra.HeaderText = "Costo unit.";
            colCostoCompra.MinimumWidth = 6;
            colCostoCompra.Name = "colCostoCompra";
            colCostoCompra.ReadOnly = true;
            // 
            // colSubtotalCompra
            // 
            colSubtotalCompra.DataPropertyName = "Subtotal";
            colSubtotalCompra.FillWeight = 110F;
            colSubtotalCompra.HeaderText = "Subtotal";
            colSubtotalCompra.MinimumWidth = 6;
            colSubtotalCompra.Name = "colSubtotalCompra";
            colSubtotalCompra.ReadOnly = true;
            // 
            // colRecepcionCompra
            // 
            colRecepcionCompra.DataPropertyName = "ReceivedQuantity";
            colRecepcionCompra.FillWeight = 95F;
            colRecepcionCompra.HeaderText = "ReceivedQuantity";
            colRecepcionCompra.MinimumWidth = 6;
            colRecepcionCompra.Name = "colRecepcionCompra";
            colRecepcionCompra.ReadOnly = true;
            // 
            // colObservacionCompra
            // 
            colObservacionCompra.DataPropertyName = "Notes";
            colObservacionCompra.FillWeight = 170F;
            colObservacionCompra.HeaderText = "Observación";
            colObservacionCompra.MinimumWidth = 6;
            colObservacionCompra.Name = "colObservacionCompra";
            colObservacionCompra.ReadOnly = true;
            // 
            // pnlAccionesDetalle
            // 
            pnlAccionesDetalle.BackColor = Color.White;
            pnlAccionesDetalle.Controls.Add(btnRegistrarRecepcion);
            pnlAccionesDetalle.Controls.Add(btnAgregarProducto);
            pnlAccionesDetalle.Dock = DockStyle.Top;
            pnlAccionesDetalle.Location = new Point(0, 240);
            pnlAccionesDetalle.Name = "pnlAccionesDetalle";
            pnlAccionesDetalle.Padding = new Padding(10, 8, 10, 8);
            pnlAccionesDetalle.Size = new Size(480, 58);
            pnlAccionesDetalle.TabIndex = 96;
            // 
            // btnRegistrarRecepcion
            // 
            btnRegistrarRecepcion.BackColor = Color.FromArgb(238, 243, 247);
            btnRegistrarRecepcion.Dock = DockStyle.Right;
            btnRegistrarRecepcion.ForeColor = Color.FromArgb(8, 31, 63);
            btnRegistrarRecepcion.Location = new Point(300, 8);
            btnRegistrarRecepcion.Name = "btnRegistrarRecepcion";
            btnRegistrarRecepcion.Size = new Size(170, 42);
            btnRegistrarRecepcion.TabIndex = 1;
            btnRegistrarRecepcion.Text = "Registrar recepción";
            btnRegistrarRecepcion.UseVisualStyleBackColor = false;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.BackColor = Color.FromArgb(238, 243, 247);
            btnAgregarProducto.Dock = DockStyle.Left;
            btnAgregarProducto.FlatAppearance.BorderSize = 0;
            btnAgregarProducto.FlatStyle = FlatStyle.Flat;
            btnAgregarProducto.Font = new Font("Century Gothic", 9F);
            btnAgregarProducto.ForeColor = Color.FromArgb(8, 31, 63);
            btnAgregarProducto.Location = new Point(10, 8);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(150, 42);
            btnAgregarProducto.TabIndex = 0;
            btnAgregarProducto.Text = "Agregar producto";
            btnAgregarProducto.UseVisualStyleBackColor = false;
            // 
            // pnlDatosCompra
            // 
            pnlDatosCompra.BackColor = Color.White;
            pnlDatosCompra.Controls.Add(txtNotasCompra);
            pnlDatosCompra.Controls.Add(lblNotasCompra);
            pnlDatosCompra.Controls.Add(txtDocumentoCompra);
            pnlDatosCompra.Controls.Add(lblDocumentoCompra);
            pnlDatosCompra.Controls.Add(dtpFechaCompra);
            pnlDatosCompra.Controls.Add(lblFechaCompra);
            pnlDatosCompra.Controls.Add(cmbProveedorCompra);
            pnlDatosCompra.Controls.Add(lblProveedorCompra);
            pnlDatosCompra.Dock = DockStyle.Top;
            pnlDatosCompra.Location = new Point(0, 0);
            pnlDatosCompra.Name = "pnlDatosCompra";
            pnlDatosCompra.Padding = new Padding(12);
            pnlDatosCompra.Size = new Size(480, 240);
            pnlDatosCompra.TabIndex = 0;
            // 
            // txtNotasCompra
            // 
            txtNotasCompra.Dock = DockStyle.Top;
            txtNotasCompra.Location = new Point(12, 180);
            txtNotasCompra.MaxLength = 250;
            txtNotasCompra.Multiline = true;
            txtNotasCompra.Name = "txtNotasCompra";
            txtNotasCompra.Size = new Size(456, 55);
            txtNotasCompra.TabIndex = 7;
            // 
            // lblNotasCompra
            // 
            lblNotasCompra.AutoSize = true;
            lblNotasCompra.Dock = DockStyle.Top;
            lblNotasCompra.ForeColor = Color.FromArgb(111, 119, 128);
            lblNotasCompra.Location = new Point(12, 161);
            lblNotasCompra.Name = "lblNotasCompra";
            lblNotasCompra.Size = new Size(48, 19);
            lblNotasCompra.TabIndex = 6;
            lblNotasCompra.Text = "Notas";
            // 
            // txtDocumentoCompra
            // 
            txtDocumentoCompra.Dock = DockStyle.Top;
            txtDocumentoCompra.Font = new Font("Century Gothic", 9F);
            txtDocumentoCompra.Location = new Point(12, 135);
            txtDocumentoCompra.MaxLength = 50;
            txtDocumentoCompra.Name = "txtDocumentoCompra";
            txtDocumentoCompra.Size = new Size(456, 26);
            txtDocumentoCompra.TabIndex = 5;
            // 
            // lblDocumentoCompra
            // 
            lblDocumentoCompra.Dock = DockStyle.Top;
            lblDocumentoCompra.ForeColor = Color.FromArgb(111, 119, 128);
            lblDocumentoCompra.Location = new Point(12, 105);
            lblDocumentoCompra.Name = "lblDocumentoCompra";
            lblDocumentoCompra.Size = new Size(456, 30);
            lblDocumentoCompra.TabIndex = 4;
            lblDocumentoCompra.Text = "Documento/Factura del proveedor";
            lblDocumentoCompra.Click += label1_Click;
            // 
            // dtpFechaCompra
            // 
            dtpFechaCompra.Dock = DockStyle.Top;
            dtpFechaCompra.Font = new Font("Century Gothic", 9F);
            dtpFechaCompra.Format = DateTimePickerFormat.Short;
            dtpFechaCompra.Location = new Point(12, 79);
            dtpFechaCompra.Name = "dtpFechaCompra";
            dtpFechaCompra.Size = new Size(456, 26);
            dtpFechaCompra.TabIndex = 3;
            // 
            // lblFechaCompra
            // 
            lblFechaCompra.Dock = DockStyle.Top;
            lblFechaCompra.ForeColor = Color.FromArgb(111, 119, 128);
            lblFechaCompra.Location = new Point(12, 59);
            lblFechaCompra.Name = "lblFechaCompra";
            lblFechaCompra.Size = new Size(456, 20);
            lblFechaCompra.TabIndex = 2;
            lblFechaCompra.Text = "Fecha de compra";
            // 
            // cmbProveedorCompra
            // 
            cmbProveedorCompra.Dock = DockStyle.Top;
            cmbProveedorCompra.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedorCompra.FormattingEnabled = true;
            cmbProveedorCompra.Location = new Point(12, 32);
            cmbProveedorCompra.Name = "cmbProveedorCompra";
            cmbProveedorCompra.Size = new Size(456, 27);
            cmbProveedorCompra.TabIndex = 1;
            // 
            // lblProveedorCompra
            // 
            lblProveedorCompra.Dock = DockStyle.Top;
            lblProveedorCompra.ForeColor = Color.FromArgb(111, 119, 128);
            lblProveedorCompra.Location = new Point(12, 12);
            lblProveedorCompra.Name = "lblProveedorCompra";
            lblProveedorCompra.Size = new Size(456, 20);
            lblProveedorCompra.TabIndex = 0;
            lblProveedorCompra.Text = "Proveedor";
            // 
            // pnlResumenCompra
            // 
            pnlResumenCompra.BackColor = Color.White;
            pnlResumenCompra.Controls.Add(btnGuardarCompra);
            pnlResumenCompra.Controls.Add(btnCancelarCompra);
            pnlResumenCompra.Controls.Add(lblTotalCompra);
            pnlResumenCompra.Controls.Add(lblSubtotalCompra);
            pnlResumenCompra.Dock = DockStyle.Bottom;
            pnlResumenCompra.Location = new Point(0, 695);
            pnlResumenCompra.Name = "pnlResumenCompra";
            pnlResumenCompra.Padding = new Padding(10, 8, 10, 8);
            pnlResumenCompra.Size = new Size(480, 113);
            pnlResumenCompra.TabIndex = 92;
            // 
            // btnGuardarCompra
            // 
            btnGuardarCompra.BackColor = Color.FromArgb(8, 126, 164);
            btnGuardarCompra.Dock = DockStyle.Right;
            btnGuardarCompra.FlatAppearance.BorderSize = 0;
            btnGuardarCompra.FlatStyle = FlatStyle.Flat;
            btnGuardarCompra.Font = new Font("Century Gothic", 9F);
            btnGuardarCompra.ForeColor = Color.White;
            btnGuardarCompra.Location = new Point(330, 63);
            btnGuardarCompra.Name = "btnGuardarCompra";
            btnGuardarCompra.Size = new Size(140, 42);
            btnGuardarCompra.TabIndex = 3;
            btnGuardarCompra.Text = "Guardar Compra";
            btnGuardarCompra.UseVisualStyleBackColor = false;
            // 
            // btnCancelarCompra
            // 
            btnCancelarCompra.BackColor = Color.FromArgb(238, 243, 247);
            btnCancelarCompra.Dock = DockStyle.Left;
            btnCancelarCompra.FlatAppearance.BorderSize = 0;
            btnCancelarCompra.FlatStyle = FlatStyle.Flat;
            btnCancelarCompra.Font = new Font("Century Gothic", 9F);
            btnCancelarCompra.ForeColor = Color.FromArgb(8, 31, 63);
            btnCancelarCompra.Location = new Point(10, 63);
            btnCancelarCompra.Name = "btnCancelarCompra";
            btnCancelarCompra.Size = new Size(120, 42);
            btnCancelarCompra.TabIndex = 2;
            btnCancelarCompra.Text = "Cancelar";
            btnCancelarCompra.UseVisualStyleBackColor = false;
            // 
            // lblTotalCompra
            // 
            lblTotalCompra.Dock = DockStyle.Top;
            lblTotalCompra.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalCompra.ForeColor = Color.FromArgb(8, 126, 164);
            lblTotalCompra.Location = new Point(10, 33);
            lblTotalCompra.Name = "lblTotalCompra";
            lblTotalCompra.Size = new Size(460, 30);
            lblTotalCompra.TabIndex = 1;
            lblTotalCompra.Text = "Total: C$ 0.00";
            lblTotalCompra.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSubtotalCompra
            // 
            lblSubtotalCompra.Dock = DockStyle.Top;
            lblSubtotalCompra.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtotalCompra.ForeColor = Color.FromArgb(8, 31, 63);
            lblSubtotalCompra.Location = new Point(10, 8);
            lblSubtotalCompra.Name = "lblSubtotalCompra";
            lblSubtotalCompra.Size = new Size(460, 25);
            lblSubtotalCompra.TabIndex = 0;
            lblSubtotalCompra.Text = "Subtotal: C$ 0.00";
            lblSubtotalCompra.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlContenido
            // 
            pnlContenido.BackColor = Color.Transparent;
            pnlContenido.Controls.Add(splCompras);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 0);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Padding = new Padding(3, 12, 3, 10);
            pnlContenido.Size = new Size(940, 830);
            pnlContenido.TabIndex = 1;
            // 
            // FrmCompras
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(940, 830);
            Controls.Add(pnlBarraCompras);
            Controls.Add(pnlContenido);
            Font = new Font("Century Gothic", 8.25F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmCompras";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmCompras";
            pnlBarraCompras.ResumeLayout(false);
            tlpBarraCompras.ResumeLayout(false);
            tlpBarraCompras.PerformLayout();
            splCompras.Panel1.ResumeLayout(false);
            splCompras.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splCompras).EndInit();
            splCompras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleCompra).EndInit();
            pnlAccionesDetalle.ResumeLayout(false);
            pnlDatosCompra.ResumeLayout(false);
            pnlDatosCompra.PerformLayout();
            pnlResumenCompra.ResumeLayout(false);
            pnlContenido.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBarraCompras;
        private SplitContainer splCompras;
        private Panel pnlContenido;
        private DataGridView dgvCompras;
        private DataGridViewTextBoxColumn colIdCompra;
        private DataGridViewTextBoxColumn colFechaCompra;
        private DataGridViewTextBoxColumn colProveedorCompra;
        private DataGridViewTextBoxColumn colTotalCompra;
        private DataGridViewTextBoxColumn colEstadoCompra;
        private DataGridViewTextBoxColumn colRecibidaCompra;
        private Panel pnlDatosCompra;
        private Label lblProveedorCompra;
        private DateTimePicker dtpFechaCompra;
        private Label lblFechaCompra;
        private ComboBox cmbProveedorCompra;
        private Label lblDocumentoCompra;
        private TextBox txtNotasCompra;
        private Label lblNotasCompra;
        private TextBox txtDocumentoCompra;
        private TableLayoutPanel tlpBarraCompras;
        private TextBox txtBuscarCompra;
        private DateTimePicker dtpFechaCompraFiltro;
        private ComboBox cmbEstadoCompra;
        private Button btnNuevaCompra;
        private Panel pnlResumenCompra;
        private DataGridView dgvDetalleCompra;
        private DataGridViewTextBoxColumn colProductoCompra;
        private DataGridViewTextBoxColumn colUnidadCompra;
        private DataGridViewTextBoxColumn colCantidadCompra;
        private DataGridViewTextBoxColumn colCostoCompra;
        private DataGridViewTextBoxColumn colSubtotalCompra;
        private DataGridViewTextBoxColumn colRecepcionCompra;
        private DataGridViewTextBoxColumn colObservacionCompra;
        private Label lblTotalCompra;
        private Label lblSubtotalCompra;
        private Button btnCancelarCompra;
        private Button btnGuardarCompra;
        private Panel pnlAccionesDetalle;
        private Button btnAgregarProducto;
        private Button btnRegistrarRecepcion;
    }
}