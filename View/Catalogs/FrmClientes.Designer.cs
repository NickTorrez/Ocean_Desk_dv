namespace Ocean_Desk_dv.UI.Catalogs
{
    partial class FrmClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            DataGridViewCellStyle stCliAlterno = new DataGridViewCellStyle();
            DataGridViewCellStyle stCliEncabezado = new DataGridViewCellStyle();
            DataGridViewCellStyle stCliCelda = new DataGridViewCellStyle();
            DataGridViewCellStyle stCliFilas = new DataGridViewCellStyle();
            DataGridViewCellStyle stCliCentro = new DataGridViewCellStyle();
            DataGridViewCellStyle stHisAlterno = new DataGridViewCellStyle();
            DataGridViewCellStyle stHisEncabezado = new DataGridViewCellStyle();
            DataGridViewCellStyle stHisCelda = new DataGridViewCellStyle();
            DataGridViewCellStyle stHisFilas = new DataGridViewCellStyle();
            DataGridViewCellStyle stHisCentro = new DataGridViewCellStyle();
            DataGridViewCellStyle stHisFecha = new DataGridViewCellStyle();
            pnlLista = new Panel();
            dgvClientes = new DataGridView();
            colNombre = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colCorreo = new DataGridViewTextBoxColumn();
            colCompras = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            pnlDetalle = new Panel();
            dgvHistorial = new DataGridView();
            colHFecha = new DataGridViewTextBoxColumn();
            colHFactura = new DataGridViewTextBoxColumn();
            colHTotal = new DataGridViewTextBoxColumn();
            lblTituloHistorial = new Label();
            pnlInfoCliente = new Panel();
            lblInfoFidelizacion = new Label();
            lblInfoCompras = new Label();
            tlpCampos = new TableLayoutPanel();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            chkActivo = new CheckBox();
            lblTituloDetalle = new Label();
            pnlAcciones = new Panel();
            tlpButtons = new TableLayoutPanel();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnCambiarEstado = new Button();
            btnCancelar = new Button();
            pnlResumen = new Panel();
            tlpResumen = new TableLayoutPanel();
            pnlCardTotal = new Panel();
            lblValorTotal = new Label();
            lblTituloTotal = new Label();
            pnlCardActivos = new Panel();
            lblValorActivos = new Label();
            lblTituloActivos = new Label();
            pnlCardFrecuentes = new Panel();
            lblValorFrecuentes = new Label();
            lblTituloFrecuentes = new Label();
            pnlBusqueda = new Panel();
            btnBuscar = new Button();
            chkSoloActivos = new CheckBox();
            txtBuscar = new TextBox();
            pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            pnlInfoCliente.SuspendLayout();
            tlpCampos.SuspendLayout();
            pnlAcciones.SuspendLayout();
            tlpButtons.SuspendLayout();
            pnlResumen.SuspendLayout();
            tlpResumen.SuspendLayout();
            pnlCardTotal.SuspendLayout();
            pnlCardActivos.SuspendLayout();
            pnlCardFrecuentes.SuspendLayout();
            pnlBusqueda.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLista
            // 
            pnlLista.BackColor = Color.Transparent;
            pnlLista.Controls.Add(dgvClientes);
            pnlLista.Dock = DockStyle.Fill;
            pnlLista.Location = new Point(0, 160);
            pnlLista.Name = "pnlLista";
            pnlLista.Padding = new Padding(3, 10, 10, 10);
            pnlLista.Size = new Size(610, 605);
            pnlLista.TabIndex = 0;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AllowUserToResizeRows = false;
            stCliAlterno.BackColor = Color.FromArgb(248, 250, 252);
            stCliAlterno.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stCliAlterno.ForeColor = Color.FromArgb(8, 31, 63);
            stCliAlterno.SelectionBackColor = Color.LightCyan;
            stCliAlterno.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dgvClientes.AlternatingRowsDefaultCellStyle = stCliAlterno;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            stCliEncabezado.Alignment = DataGridViewContentAlignment.MiddleLeft;
            stCliEncabezado.BackColor = Color.FromArgb(8, 31, 63);
            stCliEncabezado.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stCliEncabezado.ForeColor = Color.White;
            stCliEncabezado.Padding = new Padding(6, 0, 0, 0);
            stCliEncabezado.SelectionBackColor = Color.FromArgb(8, 31, 63);
            stCliEncabezado.SelectionForeColor = Color.White;
            stCliEncabezado.WrapMode = DataGridViewTriState.True;
            dgvClientes.ColumnHeadersDefaultCellStyle = stCliEncabezado;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { colNombre, colTelefono, colCorreo, colCompras, colEstado });
            stCliCelda.Alignment = DataGridViewContentAlignment.MiddleLeft;
            stCliCelda.BackColor = Color.White;
            stCliCelda.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stCliCelda.ForeColor = Color.FromArgb(8, 31, 63);
            stCliCelda.SelectionBackColor = Color.FromArgb(224, 234, 240);
            stCliCelda.SelectionForeColor = Color.FromArgb(8, 31, 63);
            stCliCelda.WrapMode = DataGridViewTriState.False;
            dgvClientes.DefaultCellStyle = stCliCelda;
            dgvClientes.Dock = DockStyle.Fill;
            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.GridColor = Color.FromArgb(230, 234, 238);
            dgvClientes.Location = new Point(3, 10);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.RowHeadersWidth = 51;
            stCliFilas.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvClientes.RowsDefaultCellStyle = stCliFilas;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(597, 585);
            dgvClientes.TabIndex = 0;
            dgvClientes.CellFormatting += dgvClientes_CellFormatting;
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;
            // 
            // colNombre
            // 
            colNombre.DataPropertyName = "NombreCompleto";
            colNombre.FillWeight = 32F;
            colNombre.HeaderText = "Cliente";
            colNombre.MinimumWidth = 6;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colTelefono
            // 
            colTelefono.DataPropertyName = "Telefono";
            stCliCentro.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTelefono.DefaultCellStyle = stCliCentro;
            colTelefono.FillWeight = 17F;
            colTelefono.HeaderText = "Teléfono";
            colTelefono.MinimumWidth = 6;
            colTelefono.Name = "colTelefono";
            colTelefono.ReadOnly = true;
            // 
            // colCorreo
            // 
            colCorreo.DataPropertyName = "Correo";
            colCorreo.FillWeight = 29F;
            colCorreo.HeaderText = "Correo";
            colCorreo.MinimumWidth = 6;
            colCorreo.Name = "colCorreo";
            colCorreo.ReadOnly = true;
            // 
            // colCompras
            // 
            colCompras.DataPropertyName = "TotalCompras";
            colCompras.DefaultCellStyle = stCliCentro;
            colCompras.FillWeight = 10F;
            colCompras.HeaderText = "Compras";
            colCompras.MinimumWidth = 6;
            colCompras.Name = "colCompras";
            colCompras.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.DataPropertyName = "EstadoTexto";
            colEstado.DefaultCellStyle = stCliCentro;
            colEstado.FillWeight = 12F;
            colEstado.HeaderText = "Estado";
            colEstado.MinimumWidth = 6;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // pnlDetalle
            // 
            pnlDetalle.BackColor = Color.White;
            pnlDetalle.Controls.Add(dgvHistorial);
            pnlDetalle.Controls.Add(lblTituloHistorial);
            pnlDetalle.Controls.Add(pnlInfoCliente);
            pnlDetalle.Controls.Add(tlpCampos);
            pnlDetalle.Controls.Add(lblTituloDetalle);
            pnlDetalle.Dock = DockStyle.Right;
            pnlDetalle.Location = new Point(610, 160);
            pnlDetalle.Name = "pnlDetalle";
            pnlDetalle.Padding = new Padding(15, 12, 15, 12);
            pnlDetalle.Size = new Size(330, 605);
            pnlDetalle.TabIndex = 1;
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.AllowUserToResizeRows = false;
            stHisAlterno.BackColor = Color.FromArgb(248, 250, 252);
            stHisAlterno.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stHisAlterno.ForeColor = Color.FromArgb(8, 31, 63);
            stHisAlterno.SelectionBackColor = Color.LightCyan;
            stHisAlterno.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dgvHistorial.AlternatingRowsDefaultCellStyle = stHisAlterno;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.BackgroundColor = Color.White;
            dgvHistorial.BorderStyle = BorderStyle.None;
            dgvHistorial.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            stHisEncabezado.Alignment = DataGridViewContentAlignment.MiddleLeft;
            stHisEncabezado.BackColor = Color.FromArgb(8, 31, 63);
            stHisEncabezado.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stHisEncabezado.ForeColor = Color.White;
            stHisEncabezado.Padding = new Padding(6, 0, 0, 0);
            stHisEncabezado.SelectionBackColor = Color.FromArgb(8, 31, 63);
            stHisEncabezado.SelectionForeColor = Color.White;
            stHisEncabezado.WrapMode = DataGridViewTriState.True;
            dgvHistorial.ColumnHeadersDefaultCellStyle = stHisEncabezado;
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Columns.AddRange(new DataGridViewColumn[] { colHFecha, colHFactura, colHTotal });
            stHisCelda.Alignment = DataGridViewContentAlignment.MiddleLeft;
            stHisCelda.BackColor = Color.White;
            stHisCelda.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stHisCelda.ForeColor = Color.FromArgb(8, 31, 63);
            stHisCelda.SelectionBackColor = Color.FromArgb(224, 234, 240);
            stHisCelda.SelectionForeColor = Color.FromArgb(8, 31, 63);
            stHisCelda.WrapMode = DataGridViewTriState.False;
            dgvHistorial.DefaultCellStyle = stHisCelda;
            dgvHistorial.Dock = DockStyle.Fill;
            dgvHistorial.EnableHeadersVisualStyles = false;
            dgvHistorial.GridColor = Color.FromArgb(230, 234, 238);
            dgvHistorial.Location = new Point(15, 413);
            dgvHistorial.MultiSelect = false;
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.RowHeadersWidth = 51;
            stHisFilas.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvHistorial.RowsDefaultCellStyle = stHisFilas;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(300, 180);
            dgvHistorial.TabIndex = 4;
            dgvHistorial.CellFormatting += dgvHistorial_CellFormatting;
            // 
            // colHFecha
            // 
            colHFecha.DataPropertyName = "Fecha";
            stHisFecha.Alignment = DataGridViewContentAlignment.MiddleCenter;
            stHisFecha.Format = "d";
            stHisFecha.NullValue = null;
            colHFecha.DefaultCellStyle = stHisFecha;
            colHFecha.FillWeight = 30F;
            colHFecha.HeaderText = "Fecha";
            colHFecha.MinimumWidth = 6;
            colHFecha.Name = "colHFecha";
            colHFecha.ReadOnly = true;
            // 
            // colHFactura
            // 
            colHFactura.DataPropertyName = "Factura";
            stHisCentro.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colHFactura.DefaultCellStyle = stHisCentro;
            colHFactura.FillWeight = 34F;
            colHFactura.HeaderText = "Factura";
            colHFactura.MinimumWidth = 6;
            colHFactura.Name = "colHFactura";
            colHFactura.ReadOnly = true;
            // 
            // colHTotal
            // 
            colHTotal.DataPropertyName = "Total";
            colHTotal.DefaultCellStyle = stHisCentro;
            colHTotal.FillWeight = 36F;
            colHTotal.HeaderText = "Total";
            colHTotal.MinimumWidth = 6;
            colHTotal.Name = "colHTotal";
            colHTotal.ReadOnly = true;
            // 
            // lblTituloHistorial
            // 
            lblTituloHistorial.Dock = DockStyle.Top;
            lblTituloHistorial.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloHistorial.ForeColor = Color.FromArgb(8, 31, 63);
            lblTituloHistorial.Location = new Point(15, 385);
            lblTituloHistorial.Name = "lblTituloHistorial";
            lblTituloHistorial.Size = new Size(300, 28);
            lblTituloHistorial.TabIndex = 3;
            lblTituloHistorial.Text = "Historial de compras";
            lblTituloHistorial.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlInfoCliente
            // 
            pnlInfoCliente.Controls.Add(lblInfoFidelizacion);
            pnlInfoCliente.Controls.Add(lblInfoCompras);
            pnlInfoCliente.Dock = DockStyle.Top;
            pnlInfoCliente.Location = new Point(15, 329);
            pnlInfoCliente.Name = "pnlInfoCliente";
            pnlInfoCliente.Size = new Size(300, 56);
            pnlInfoCliente.TabIndex = 2;
            // 
            // lblInfoFidelizacion
            // 
            lblInfoFidelizacion.Dock = DockStyle.Top;
            lblInfoFidelizacion.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoFidelizacion.ForeColor = Color.FromArgb(8, 126, 164);
            lblInfoFidelizacion.Location = new Point(0, 24);
            lblInfoFidelizacion.Name = "lblInfoFidelizacion";
            lblInfoFidelizacion.Size = new Size(300, 24);
            lblInfoFidelizacion.TabIndex = 1;
            lblInfoFidelizacion.Text = "Fidelización: -";
            lblInfoFidelizacion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInfoCompras
            // 
            lblInfoCompras.Dock = DockStyle.Top;
            lblInfoCompras.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoCompras.ForeColor = Color.FromArgb(111, 119, 128);
            lblInfoCompras.Location = new Point(0, 0);
            lblInfoCompras.Name = "lblInfoCompras";
            lblInfoCompras.Size = new Size(300, 24);
            lblInfoCompras.TabIndex = 0;
            lblInfoCompras.Text = "Compras: 0  |  Total: C$ 0.00";
            lblInfoCompras.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tlpCampos
            // 
            tlpCampos.ColumnCount = 1;
            tlpCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpCampos.Controls.Add(lblNombre, 0, 0);
            tlpCampos.Controls.Add(txtNombre, 0, 1);
            tlpCampos.Controls.Add(lblApellido, 0, 2);
            tlpCampos.Controls.Add(txtApellido, 0, 3);
            tlpCampos.Controls.Add(lblTelefono, 0, 4);
            tlpCampos.Controls.Add(txtTelefono, 0, 5);
            tlpCampos.Controls.Add(lblCorreo, 0, 6);
            tlpCampos.Controls.Add(txtCorreo, 0, 7);
            tlpCampos.Controls.Add(lblDireccion, 0, 8);
            tlpCampos.Controls.Add(txtDireccion, 0, 9);
            tlpCampos.Controls.Add(chkActivo, 0, 10);
            tlpCampos.Dock = DockStyle.Top;
            tlpCampos.Location = new Point(15, 42);
            tlpCampos.Name = "tlpCampos";
            tlpCampos.RowCount = 11;
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpCampos.Size = new Size(300, 287);
            tlpCampos.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.Dock = DockStyle.Fill;
            lblNombre.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = Color.FromArgb(111, 119, 128);
            lblNombre.Margin = new Padding(0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(300, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre *";
            lblNombre.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.ForeColor = Color.FromArgb(8, 31, 63);
            txtNombre.Margin = new Padding(0, 0, 0, 4);
            txtNombre.MaxLength = 80;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 26);
            txtNombre.TabIndex = 0;
            // 
            // lblApellido
            // 
            lblApellido.Dock = DockStyle.Fill;
            lblApellido.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblApellido.ForeColor = Color.FromArgb(111, 119, 128);
            lblApellido.Margin = new Padding(0);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(300, 20);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido *";
            lblApellido.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtApellido
            // 
            txtApellido.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.ForeColor = Color.FromArgb(8, 31, 63);
            txtApellido.Margin = new Padding(0, 0, 0, 4);
            txtApellido.MaxLength = 80;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(300, 26);
            txtApellido.TabIndex = 1;
            // 
            // lblTelefono
            // 
            lblTelefono.Dock = DockStyle.Fill;
            lblTelefono.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTelefono.ForeColor = Color.FromArgb(111, 119, 128);
            lblTelefono.Margin = new Padding(0);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(300, 20);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Teléfono";
            lblTelefono.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtTelefono
            // 
            txtTelefono.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.ForeColor = Color.FromArgb(8, 31, 63);
            txtTelefono.Margin = new Padding(0, 0, 0, 4);
            txtTelefono.MaxLength = 20;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(300, 26);
            txtTelefono.TabIndex = 2;
            // 
            // lblCorreo
            // 
            lblCorreo.Dock = DockStyle.Fill;
            lblCorreo.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCorreo.ForeColor = Color.FromArgb(111, 119, 128);
            lblCorreo.Margin = new Padding(0);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(300, 20);
            lblCorreo.TabIndex = 6;
            lblCorreo.Text = "Correo electrónico";
            lblCorreo.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtCorreo
            // 
            txtCorreo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtCorreo.BorderStyle = BorderStyle.FixedSingle;
            txtCorreo.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCorreo.ForeColor = Color.FromArgb(8, 31, 63);
            txtCorreo.Margin = new Padding(0, 0, 0, 4);
            txtCorreo.MaxLength = 150;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(300, 26);
            txtCorreo.TabIndex = 3;
            // 
            // lblDireccion
            // 
            lblDireccion.Dock = DockStyle.Fill;
            lblDireccion.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDireccion.ForeColor = Color.FromArgb(111, 119, 128);
            lblDireccion.Margin = new Padding(0);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(300, 20);
            lblDireccion.TabIndex = 8;
            lblDireccion.Text = "Dirección";
            lblDireccion.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtDireccion
            // 
            txtDireccion.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDireccion.BorderStyle = BorderStyle.FixedSingle;
            txtDireccion.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDireccion.ForeColor = Color.FromArgb(8, 31, 63);
            txtDireccion.Margin = new Padding(0, 0, 0, 4);
            txtDireccion.MaxLength = 250;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(300, 26);
            txtDireccion.TabIndex = 4;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Enabled = false;
            chkActivo.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkActivo.ForeColor = Color.FromArgb(8, 31, 63);
            chkActivo.Margin = new Padding(0, 6, 0, 0);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(120, 24);
            chkActivo.TabIndex = 5;
            chkActivo.TabStop = false;
            chkActivo.Text = "Cliente activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // lblTituloDetalle
            // 
            lblTituloDetalle.Dock = DockStyle.Top;
            lblTituloDetalle.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloDetalle.ForeColor = Color.FromArgb(8, 31, 63);
            lblTituloDetalle.Location = new Point(15, 12);
            lblTituloDetalle.Name = "lblTituloDetalle";
            lblTituloDetalle.Size = new Size(300, 30);
            lblTituloDetalle.TabIndex = 0;
            lblTituloDetalle.Text = "Nuevo cliente";
            lblTituloDetalle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlAcciones
            // 
            pnlAcciones.BackColor = Color.White;
            pnlAcciones.Controls.Add(tlpButtons);
            pnlAcciones.Dock = DockStyle.Bottom;
            pnlAcciones.Location = new Point(0, 765);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Padding = new Padding(15, 6, 15, 8);
            pnlAcciones.Size = new Size(940, 65);
            pnlAcciones.TabIndex = 2;
            // 
            // tlpButtons
            // 
            tlpButtons.ColumnCount = 4;
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpButtons.Controls.Add(btnNuevo, 0, 0);
            tlpButtons.Controls.Add(btnGuardar, 1, 0);
            tlpButtons.Controls.Add(btnCambiarEstado, 2, 0);
            tlpButtons.Controls.Add(btnCancelar, 3, 0);
            tlpButtons.Dock = DockStyle.Fill;
            tlpButtons.Location = new Point(15, 6);
            tlpButtons.Margin = new Padding(0);
            tlpButtons.Name = "tlpButtons";
            tlpButtons.RowCount = 1;
            tlpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpButtons.Size = new Size(910, 51);
            tlpButtons.TabIndex = 0;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.LightSkyBlue;
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Dock = DockStyle.Fill;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = Color.FromArgb(8, 31, 63);
            btnNuevo.Location = new Point(3, 3);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(221, 45);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(8, 126, 164);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Dock = DockStyle.Fill;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(230, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(221, 45);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCambiarEstado
            // 
            btnCambiarEstado.BackColor = Color.FromArgb(238, 243, 247);
            btnCambiarEstado.Cursor = Cursors.Hand;
            btnCambiarEstado.Dock = DockStyle.Fill;
            btnCambiarEstado.FlatAppearance.BorderSize = 0;
            btnCambiarEstado.FlatStyle = FlatStyle.Flat;
            btnCambiarEstado.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCambiarEstado.ForeColor = Color.FromArgb(8, 31, 63);
            btnCambiarEstado.Location = new Point(457, 3);
            btnCambiarEstado.Name = "btnCambiarEstado";
            btnCambiarEstado.Size = new Size(221, 45);
            btnCambiarEstado.TabIndex = 2;
            btnCambiarEstado.Text = "DESACTIVAR";
            btnCambiarEstado.UseVisualStyleBackColor = false;
            btnCambiarEstado.Click += btnCambiarEstado_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(238, 243, 247);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Dock = DockStyle.Fill;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.FromArgb(8, 31, 63);
            btnCancelar.Location = new Point(684, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(223, 45);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pnlResumen
            // 
            pnlResumen.BackColor = Color.Transparent;
            pnlResumen.Controls.Add(tlpResumen);
            pnlResumen.Dock = DockStyle.Top;
            pnlResumen.Location = new Point(0, 70);
            pnlResumen.Name = "pnlResumen";
            pnlResumen.Size = new Size(940, 90);
            pnlResumen.TabIndex = 3;
            // 
            // tlpResumen
            // 
            tlpResumen.ColumnCount = 3;
            tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpResumen.Controls.Add(pnlCardTotal, 0, 0);
            tlpResumen.Controls.Add(pnlCardActivos, 1, 0);
            tlpResumen.Controls.Add(pnlCardFrecuentes, 2, 0);
            tlpResumen.Dock = DockStyle.Fill;
            tlpResumen.Location = new Point(0, 0);
            tlpResumen.Margin = new Padding(0);
            tlpResumen.Name = "tlpResumen";
            tlpResumen.RowCount = 1;
            tlpResumen.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpResumen.Size = new Size(940, 90);
            tlpResumen.TabIndex = 0;
            // 
            // pnlCardTotal
            // 
            pnlCardTotal.BackColor = Color.White;
            pnlCardTotal.Controls.Add(lblValorTotal);
            pnlCardTotal.Controls.Add(lblTituloTotal);
            pnlCardTotal.Dock = DockStyle.Fill;
            pnlCardTotal.Margin = new Padding(0, 10, 10, 0);
            pnlCardTotal.Name = "pnlCardTotal";
            pnlCardTotal.Padding = new Padding(15, 8, 15, 8);
            pnlCardTotal.Size = new Size(303, 80);
            pnlCardTotal.TabIndex = 0;
            // 
            // lblValorTotal
            // 
            lblValorTotal.Dock = DockStyle.Fill;
            lblValorTotal.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValorTotal.ForeColor = Color.FromArgb(8, 31, 63);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(273, 40);
            lblValorTotal.TabIndex = 1;
            lblValorTotal.Text = "0";
            lblValorTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTituloTotal
            // 
            lblTituloTotal.Dock = DockStyle.Top;
            lblTituloTotal.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloTotal.ForeColor = Color.FromArgb(111, 119, 128);
            lblTituloTotal.Name = "lblTituloTotal";
            lblTituloTotal.Size = new Size(273, 24);
            lblTituloTotal.TabIndex = 0;
            lblTituloTotal.Text = "Clientes registrados";
            // 
            // pnlCardActivos
            // 
            pnlCardActivos.BackColor = Color.White;
            pnlCardActivos.Controls.Add(lblValorActivos);
            pnlCardActivos.Controls.Add(lblTituloActivos);
            pnlCardActivos.Dock = DockStyle.Fill;
            pnlCardActivos.Margin = new Padding(0, 10, 10, 0);
            pnlCardActivos.Name = "pnlCardActivos";
            pnlCardActivos.Padding = new Padding(15, 8, 15, 8);
            pnlCardActivos.Size = new Size(303, 80);
            pnlCardActivos.TabIndex = 1;
            // 
            // lblValorActivos
            // 
            lblValorActivos.Dock = DockStyle.Fill;
            lblValorActivos.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValorActivos.ForeColor = Color.FromArgb(8, 31, 63);
            lblValorActivos.Name = "lblValorActivos";
            lblValorActivos.Size = new Size(273, 40);
            lblValorActivos.TabIndex = 1;
            lblValorActivos.Text = "0";
            lblValorActivos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTituloActivos
            // 
            lblTituloActivos.Dock = DockStyle.Top;
            lblTituloActivos.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloActivos.ForeColor = Color.FromArgb(111, 119, 128);
            lblTituloActivos.Name = "lblTituloActivos";
            lblTituloActivos.Size = new Size(273, 24);
            lblTituloActivos.TabIndex = 0;
            lblTituloActivos.Text = "Clientes activos";
            // 
            // pnlCardFrecuentes
            // 
            pnlCardFrecuentes.BackColor = Color.White;
            pnlCardFrecuentes.Controls.Add(lblValorFrecuentes);
            pnlCardFrecuentes.Controls.Add(lblTituloFrecuentes);
            pnlCardFrecuentes.Dock = DockStyle.Fill;
            pnlCardFrecuentes.Margin = new Padding(0, 10, 0, 0);
            pnlCardFrecuentes.Name = "pnlCardFrecuentes";
            pnlCardFrecuentes.Padding = new Padding(15, 8, 15, 8);
            pnlCardFrecuentes.Size = new Size(314, 80);
            pnlCardFrecuentes.TabIndex = 2;
            // 
            // lblValorFrecuentes
            // 
            lblValorFrecuentes.Dock = DockStyle.Fill;
            lblValorFrecuentes.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValorFrecuentes.ForeColor = Color.FromArgb(8, 31, 63);
            lblValorFrecuentes.Name = "lblValorFrecuentes";
            lblValorFrecuentes.Size = new Size(284, 40);
            lblValorFrecuentes.TabIndex = 1;
            lblValorFrecuentes.Text = "0";
            lblValorFrecuentes.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTituloFrecuentes
            // 
            lblTituloFrecuentes.Dock = DockStyle.Top;
            lblTituloFrecuentes.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloFrecuentes.ForeColor = Color.FromArgb(111, 119, 128);
            lblTituloFrecuentes.Name = "lblTituloFrecuentes";
            lblTituloFrecuentes.Size = new Size(284, 24);
            lblTituloFrecuentes.TabIndex = 0;
            lblTituloFrecuentes.Text = "Clientes frecuentes";
            // 
            // pnlBusqueda
            // 
            pnlBusqueda.BackColor = Color.White;
            pnlBusqueda.Controls.Add(btnBuscar);
            pnlBusqueda.Controls.Add(chkSoloActivos);
            pnlBusqueda.Controls.Add(txtBuscar);
            pnlBusqueda.Dock = DockStyle.Top;
            pnlBusqueda.Location = new Point(0, 0);
            pnlBusqueda.Margin = new Padding(0);
            pnlBusqueda.Name = "pnlBusqueda";
            pnlBusqueda.Padding = new Padding(15, 10, 15, 10);
            pnlBusqueda.Size = new Size(940, 70);
            pnlBusqueda.TabIndex = 4;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.BackColor = Color.FromArgb(8, 126, 164);
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(795, 15);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(130, 40);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // chkSoloActivos
            // 
            chkSoloActivos.AutoSize = true;
            chkSoloActivos.Checked = true;
            chkSoloActivos.CheckState = CheckState.Checked;
            chkSoloActivos.Cursor = Cursors.Hand;
            chkSoloActivos.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkSoloActivos.ForeColor = Color.FromArgb(8, 31, 63);
            chkSoloActivos.Location = new Point(455, 23);
            chkSoloActivos.Name = "chkSoloActivos";
            chkSoloActivos.Size = new Size(121, 24);
            chkSoloActivos.TabIndex = 1;
            chkSoloActivos.Text = "Solo activos";
            chkSoloActivos.UseVisualStyleBackColor = true;
            chkSoloActivos.CheckedChanged += chkSoloActivos_CheckedChanged;
            // 
            // txtBuscar
            // 
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.ForeColor = Color.FromArgb(8, 31, 63);
            txtBuscar.Location = new Point(15, 22);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por nombre, teléfono o correo";
            txtBuscar.Size = new Size(420, 26);
            txtBuscar.TabIndex = 0;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(pnlLista);
            Controls.Add(pnlDetalle);
            Controls.Add(pnlAcciones);
            Controls.Add(pnlResumen);
            Controls.Add(pnlBusqueda);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmClientes";
            Text = "FrmClientes";
            FormClosed += FrmClientes_FormClosed;
            pnlLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            pnlInfoCliente.ResumeLayout(false);
            tlpCampos.ResumeLayout(false);
            tlpCampos.PerformLayout();
            pnlAcciones.ResumeLayout(false);
            tlpButtons.ResumeLayout(false);
            pnlResumen.ResumeLayout(false);
            tlpResumen.ResumeLayout(false);
            pnlCardTotal.ResumeLayout(false);
            pnlCardActivos.ResumeLayout(false);
            pnlCardFrecuentes.ResumeLayout(false);
            pnlBusqueda.ResumeLayout(false);
            pnlBusqueda.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLista;
        private DataGridView dgvClientes;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colTelefono;
        private DataGridViewTextBoxColumn colCorreo;
        private DataGridViewTextBoxColumn colCompras;
        private DataGridViewTextBoxColumn colEstado;
        private Panel pnlDetalle;
        private DataGridView dgvHistorial;
        private DataGridViewTextBoxColumn colHFecha;
        private DataGridViewTextBoxColumn colHFactura;
        private DataGridViewTextBoxColumn colHTotal;
        private Label lblTituloHistorial;
        private Panel pnlInfoCliente;
        private Label lblInfoFidelizacion;
        private Label lblInfoCompras;
        private TableLayoutPanel tlpCampos;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Label lblDireccion;
        private TextBox txtDireccion;
        private CheckBox chkActivo;
        private Label lblTituloDetalle;
        private Panel pnlAcciones;
        private TableLayoutPanel tlpButtons;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnCambiarEstado;
        private Button btnCancelar;
        private Panel pnlResumen;
        private TableLayoutPanel tlpResumen;
        private Panel pnlCardTotal;
        private Label lblValorTotal;
        private Label lblTituloTotal;
        private Panel pnlCardActivos;
        private Label lblValorActivos;
        private Label lblTituloActivos;
        private Panel pnlCardFrecuentes;
        private Label lblValorFrecuentes;
        private Label lblTituloFrecuentes;
        private Panel pnlBusqueda;
        private Button btnBuscar;
        private CheckBox chkSoloActivos;
        private TextBox txtBuscar;
    }
}
