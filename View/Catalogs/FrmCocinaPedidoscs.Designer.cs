namespace Ocean_Desk_dv.View.Catalogs
{
    partial class FrmCocinaPedidoscs
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
            pnlResumen = new Panel();
            tlpResumenTarjetas = new TableLayoutPanel();
            pnlPendientes = new Panel();
            lblNumeroPendientes = new Label();
            lblTituloPendiente = new Label();
            pnlPreparación = new Panel();
            lblNumeroPreparacion = new Label();
            lblTituloPreparacion = new Label();
            pnlListos = new Panel();
            lblNumeroListos = new Label();
            lblTituloListos = new Label();
            pnlPedidos = new Panel();
            dgvPedidos = new DataGridView();
            colOrden = new DataGridViewTextBoxColumn();
            colMesa = new DataGridViewTextBoxColumn();
            colTipoOrden = new DataGridViewTextBoxColumn();
            colHora = new DataGridViewTextBoxColumn();
            colPrioridad = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            lblTituloPedidos = new Label();
            pnlDetalle = new Panel();
            dgvDetallePedido = new DataGridView();
            colCantidad = new DataGridViewTextBoxColumn();
            colProductos = new DataGridViewTextBoxColumn();
            colObservaciones = new DataGridViewTextBoxColumn();
            pnlEstadoPedido = new Panel();
            tlpEstadoPrioridadPedido = new TableLayoutPanel();
            lblPrioridad = new Label();
            lblEstado = new Label();
            pnlDatosPedido = new Panel();
            tlpDetallePedido = new TableLayoutPanel();
            lblOrden = new Label();
            lblHora = new Label();
            lblTipoOrden = new Label();
            lblMesa = new Label();
            lblTituloDetalle = new Label();
            pnlButtons = new Panel();
            tlpActions = new TableLayoutPanel();
            pnlIniciar = new Panel();
            btnIniciarPreparacion = new Button();
            pnMarcarListo = new Panel();
            btnMarcarListo = new Button();
            pnlActualizar = new Panel();
            btnActualizar = new Button();
            pnlLimpiar = new Panel();
            btnLimpiar = new Button();
            pnlResumen.SuspendLayout();
            tlpResumenTarjetas.SuspendLayout();
            pnlPendientes.SuspendLayout();
            pnlPreparación.SuspendLayout();
            pnlListos.SuspendLayout();
            pnlPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetallePedido).BeginInit();
            pnlEstadoPedido.SuspendLayout();
            tlpEstadoPrioridadPedido.SuspendLayout();
            pnlDatosPedido.SuspendLayout();
            tlpDetallePedido.SuspendLayout();
            pnlButtons.SuspendLayout();
            tlpActions.SuspendLayout();
            pnlIniciar.SuspendLayout();
            pnMarcarListo.SuspendLayout();
            pnlActualizar.SuspendLayout();
            pnlLimpiar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlResumen
            // 
            pnlResumen.Controls.Add(tlpResumenTarjetas);
            pnlResumen.Dock = DockStyle.Top;
            pnlResumen.Location = new Point(0, 10);
            pnlResumen.Name = "pnlResumen";
            pnlResumen.Size = new Size(940, 120);
            pnlResumen.TabIndex = 0;
            // 
            // tlpResumenTarjetas
            // 
            tlpResumenTarjetas.BackColor = Color.White;
            tlpResumenTarjetas.ColumnCount = 3;
            tlpResumenTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpResumenTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpResumenTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpResumenTarjetas.Controls.Add(pnlPendientes, 0, 0);
            tlpResumenTarjetas.Controls.Add(pnlPreparación, 1, 0);
            tlpResumenTarjetas.Controls.Add(pnlListos, 2, 0);
            tlpResumenTarjetas.Dock = DockStyle.Fill;
            tlpResumenTarjetas.Location = new Point(0, 0);
            tlpResumenTarjetas.Name = "tlpResumenTarjetas";
            tlpResumenTarjetas.Padding = new Padding(5);
            tlpResumenTarjetas.RowCount = 1;
            tlpResumenTarjetas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpResumenTarjetas.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpResumenTarjetas.Size = new Size(940, 120);
            tlpResumenTarjetas.TabIndex = 0;
            // 
            // pnlPendientes
            // 
            pnlPendientes.BackColor = Color.FromArgb(255, 247, 232);
            pnlPendientes.Controls.Add(lblNumeroPendientes);
            pnlPendientes.Controls.Add(lblTituloPendiente);
            pnlPendientes.Dock = DockStyle.Fill;
            pnlPendientes.Font = new Font("Century Gothic", 10.2F);
            pnlPendientes.Location = new Point(8, 8);
            pnlPendientes.Name = "pnlPendientes";
            pnlPendientes.Padding = new Padding(0, 10, 0, 10);
            pnlPendientes.Size = new Size(303, 104);
            pnlPendientes.TabIndex = 0;
            // 
            // lblNumeroPendientes
            // 
            lblNumeroPendientes.Dock = DockStyle.Fill;
            lblNumeroPendientes.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumeroPendientes.ForeColor = Color.Chocolate;
            lblNumeroPendientes.Location = new Point(0, 35);
            lblNumeroPendientes.Name = "lblNumeroPendientes";
            lblNumeroPendientes.Size = new Size(303, 59);
            lblNumeroPendientes.TabIndex = 1;
            lblNumeroPendientes.Text = "0";
            lblNumeroPendientes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloPendiente
            // 
            lblTituloPendiente.Dock = DockStyle.Top;
            lblTituloPendiente.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloPendiente.Location = new Point(0, 10);
            lblTituloPendiente.Name = "lblTituloPendiente";
            lblTituloPendiente.Size = new Size(303, 25);
            lblTituloPendiente.TabIndex = 0;
            lblTituloPendiente.Text = "PEDIDOS PENDIENTES";
            lblTituloPendiente.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlPreparación
            // 
            pnlPreparación.BackColor = Color.FromArgb(238, 247, 241);
            pnlPreparación.Controls.Add(lblNumeroPreparacion);
            pnlPreparación.Controls.Add(lblTituloPreparacion);
            pnlPreparación.Dock = DockStyle.Fill;
            pnlPreparación.Font = new Font("Century Gothic", 10.2F);
            pnlPreparación.Location = new Point(317, 8);
            pnlPreparación.Name = "pnlPreparación";
            pnlPreparación.Padding = new Padding(0, 10, 0, 10);
            pnlPreparación.Size = new Size(303, 104);
            pnlPreparación.TabIndex = 1;
            // 
            // lblNumeroPreparacion
            // 
            lblNumeroPreparacion.Dock = DockStyle.Fill;
            lblNumeroPreparacion.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumeroPreparacion.ForeColor = Color.Olive;
            lblNumeroPreparacion.Location = new Point(0, 35);
            lblNumeroPreparacion.Name = "lblNumeroPreparacion";
            lblNumeroPreparacion.Size = new Size(303, 59);
            lblNumeroPreparacion.TabIndex = 1;
            lblNumeroPreparacion.Text = "0";
            lblNumeroPreparacion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloPreparacion
            // 
            lblTituloPreparacion.Dock = DockStyle.Top;
            lblTituloPreparacion.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloPreparacion.Location = new Point(0, 10);
            lblTituloPreparacion.Name = "lblTituloPreparacion";
            lblTituloPreparacion.Size = new Size(303, 25);
            lblTituloPreparacion.TabIndex = 0;
            lblTituloPreparacion.Text = "EN PREPARACIÓN";
            lblTituloPreparacion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlListos
            // 
            pnlListos.BackColor = Color.FromArgb(238, 246, 248);
            pnlListos.Controls.Add(lblNumeroListos);
            pnlListos.Controls.Add(lblTituloListos);
            pnlListos.Dock = DockStyle.Fill;
            pnlListos.Font = new Font("Century Gothic", 10.2F);
            pnlListos.Location = new Point(626, 8);
            pnlListos.Name = "pnlListos";
            pnlListos.Padding = new Padding(0, 10, 0, 10);
            pnlListos.Size = new Size(306, 104);
            pnlListos.TabIndex = 2;
            // 
            // lblNumeroListos
            // 
            lblNumeroListos.Dock = DockStyle.Fill;
            lblNumeroListos.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumeroListos.ForeColor = Color.FromArgb(8, 126, 164);
            lblNumeroListos.Location = new Point(0, 35);
            lblNumeroListos.Name = "lblNumeroListos";
            lblNumeroListos.Size = new Size(306, 59);
            lblNumeroListos.TabIndex = 1;
            lblNumeroListos.Text = "0";
            lblNumeroListos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloListos
            // 
            lblTituloListos.Dock = DockStyle.Top;
            lblTituloListos.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloListos.Location = new Point(0, 10);
            lblTituloListos.Name = "lblTituloListos";
            lblTituloListos.Size = new Size(306, 25);
            lblTituloListos.TabIndex = 0;
            lblTituloListos.Text = "LISTOS";
            lblTituloListos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlPedidos
            // 
            pnlPedidos.Controls.Add(dgvPedidos);
            pnlPedidos.Controls.Add(lblTituloPedidos);
            pnlPedidos.Dock = DockStyle.Top;
            pnlPedidos.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlPedidos.Location = new Point(0, 130);
            pnlPedidos.Name = "pnlPedidos";
            pnlPedidos.Padding = new Padding(0, 10, 0, 0);
            pnlPedidos.Size = new Size(940, 260);
            pnlPedidos.TabIndex = 1;
            // 
            // dgvPedidos
            // 
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.AllowUserToDeleteRows = false;
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Columns.AddRange(new DataGridViewColumn[] { colOrden, colMesa, colTipoOrden, colHora, colPrioridad, colEstado });
            dgvPedidos.Dock = DockStyle.Fill;
            dgvPedidos.GridColor = Color.FromArgb(230, 234, 238);
            dgvPedidos.Location = new Point(0, 60);
            dgvPedidos.MultiSelect = false;
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.ReadOnly = true;
            dgvPedidos.RowHeadersVisible = false;
            dgvPedidos.RowHeadersWidth = 51;
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.Size = new Size(940, 200);
            dgvPedidos.TabIndex = 1;
            // 
            // colOrden
            // 
            colOrden.HeaderText = "Orden";
            colOrden.MinimumWidth = 6;
            colOrden.Name = "colOrden";
            colOrden.ReadOnly = true;
            // 
            // colMesa
            // 
            colMesa.HeaderText = "Mesa";
            colMesa.MinimumWidth = 6;
            colMesa.Name = "colMesa";
            colMesa.ReadOnly = true;
            // 
            // colTipoOrden
            // 
            colTipoOrden.HeaderText = "Tipo";
            colTipoOrden.MinimumWidth = 6;
            colTipoOrden.Name = "colTipoOrden";
            colTipoOrden.ReadOnly = true;
            // 
            // colHora
            // 
            colHora.HeaderText = "Hora";
            colHora.MinimumWidth = 6;
            colHora.Name = "colHora";
            colHora.ReadOnly = true;
            // 
            // colPrioridad
            // 
            colPrioridad.HeaderText = "Prioridad";
            colPrioridad.MinimumWidth = 6;
            colPrioridad.Name = "colPrioridad";
            colPrioridad.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.HeaderText = "Estado";
            colEstado.MinimumWidth = 6;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // lblTituloPedidos
            // 
            lblTituloPedidos.BackColor = Color.White;
            lblTituloPedidos.Dock = DockStyle.Top;
            lblTituloPedidos.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloPedidos.ForeColor = Color.FromArgb(8, 31, 63);
            lblTituloPedidos.Location = new Point(0, 10);
            lblTituloPedidos.Name = "lblTituloPedidos";
            lblTituloPedidos.Size = new Size(940, 50);
            lblTituloPedidos.TabIndex = 0;
            lblTituloPedidos.Text = "Pedidos en Cocina";
            lblTituloPedidos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlDetalle
            // 
            pnlDetalle.Controls.Add(dgvDetallePedido);
            pnlDetalle.Controls.Add(pnlEstadoPedido);
            pnlDetalle.Controls.Add(pnlDatosPedido);
            pnlDetalle.Controls.Add(lblTituloDetalle);
            pnlDetalle.Dock = DockStyle.Fill;
            pnlDetalle.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlDetalle.Location = new Point(0, 390);
            pnlDetalle.Name = "pnlDetalle";
            pnlDetalle.Padding = new Padding(0, 10, 0, 0);
            pnlDetalle.Size = new Size(940, 360);
            pnlDetalle.TabIndex = 2;
            // 
            // dgvDetallePedido
            // 
            dgvDetallePedido.AllowUserToAddRows = false;
            dgvDetallePedido.AllowUserToDeleteRows = false;
            dgvDetallePedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetallePedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetallePedido.Columns.AddRange(new DataGridViewColumn[] { colCantidad, colProductos, colObservaciones });
            dgvDetallePedido.Dock = DockStyle.Fill;
            dgvDetallePedido.Location = new Point(0, 150);
            dgvDetallePedido.MultiSelect = false;
            dgvDetallePedido.Name = "dgvDetallePedido";
            dgvDetallePedido.ReadOnly = true;
            dgvDetallePedido.RowHeadersVisible = false;
            dgvDetallePedido.RowHeadersWidth = 51;
            dgvDetallePedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetallePedido.Size = new Size(940, 210);
            dgvDetallePedido.TabIndex = 5;
            // 
            // colCantidad
            // 
            colCantidad.HeaderText = "Cantidad";
            colCantidad.MinimumWidth = 6;
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            // 
            // colProductos
            // 
            colProductos.HeaderText = "Productos";
            colProductos.MinimumWidth = 6;
            colProductos.Name = "colProductos";
            colProductos.ReadOnly = true;
            // 
            // colObservaciones
            // 
            colObservaciones.HeaderText = "Observaciones";
            colObservaciones.MinimumWidth = 6;
            colObservaciones.Name = "colObservaciones";
            colObservaciones.ReadOnly = true;
            // 
            // pnlEstadoPedido
            // 
            pnlEstadoPedido.BackColor = Color.White;
            pnlEstadoPedido.Controls.Add(tlpEstadoPrioridadPedido);
            pnlEstadoPedido.Dock = DockStyle.Top;
            pnlEstadoPedido.Location = new Point(0, 110);
            pnlEstadoPedido.Name = "pnlEstadoPedido";
            pnlEstadoPedido.Padding = new Padding(150, 0, 150, 0);
            pnlEstadoPedido.Size = new Size(940, 40);
            pnlEstadoPedido.TabIndex = 3;
            // 
            // tlpEstadoPrioridadPedido
            // 
            tlpEstadoPrioridadPedido.ColumnCount = 2;
            tlpEstadoPrioridadPedido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpEstadoPrioridadPedido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpEstadoPrioridadPedido.Controls.Add(lblPrioridad, 1, 0);
            tlpEstadoPrioridadPedido.Controls.Add(lblEstado, 0, 0);
            tlpEstadoPrioridadPedido.Dock = DockStyle.Fill;
            tlpEstadoPrioridadPedido.Location = new Point(150, 0);
            tlpEstadoPrioridadPedido.Name = "tlpEstadoPrioridadPedido";
            tlpEstadoPrioridadPedido.RowCount = 1;
            tlpEstadoPrioridadPedido.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpEstadoPrioridadPedido.Size = new Size(640, 40);
            tlpEstadoPrioridadPedido.TabIndex = 4;
            // 
            // lblPrioridad
            // 
            lblPrioridad.Dock = DockStyle.Fill;
            lblPrioridad.Location = new Point(323, 0);
            lblPrioridad.Name = "lblPrioridad";
            lblPrioridad.Size = new Size(314, 40);
            lblPrioridad.TabIndex = 0;
            lblPrioridad.Text = "Prioridad: NORMAL";
            lblPrioridad.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEstado
            // 
            lblEstado.Dock = DockStyle.Fill;
            lblEstado.Location = new Point(3, 0);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(314, 40);
            lblEstado.TabIndex = 0;
            lblEstado.Text = "Estado: EN PREPARACIÓN";
            lblEstado.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlDatosPedido
            // 
            pnlDatosPedido.BackColor = Color.White;
            pnlDatosPedido.Controls.Add(tlpDetallePedido);
            pnlDatosPedido.Dock = DockStyle.Top;
            pnlDatosPedido.Location = new Point(0, 60);
            pnlDatosPedido.Name = "pnlDatosPedido";
            pnlDatosPedido.Padding = new Padding(150, 0, 150, 0);
            pnlDatosPedido.Size = new Size(940, 50);
            pnlDatosPedido.TabIndex = 2;
            // 
            // tlpDetallePedido
            // 
            tlpDetallePedido.ColumnCount = 4;
            tlpDetallePedido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpDetallePedido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpDetallePedido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpDetallePedido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpDetallePedido.Controls.Add(lblOrden, 0, 0);
            tlpDetallePedido.Controls.Add(lblHora, 3, 0);
            tlpDetallePedido.Controls.Add(lblTipoOrden, 1, 0);
            tlpDetallePedido.Controls.Add(lblMesa, 2, 0);
            tlpDetallePedido.Dock = DockStyle.Fill;
            tlpDetallePedido.Location = new Point(150, 0);
            tlpDetallePedido.Name = "tlpDetallePedido";
            tlpDetallePedido.RowCount = 1;
            tlpDetallePedido.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpDetallePedido.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpDetallePedido.Size = new Size(640, 50);
            tlpDetallePedido.TabIndex = 0;
            // 
            // lblOrden
            // 
            lblOrden.Dock = DockStyle.Fill;
            lblOrden.Location = new Point(3, 0);
            lblOrden.Name = "lblOrden";
            lblOrden.Size = new Size(154, 50);
            lblOrden.TabIndex = 0;
            lblOrden.Text = "Orden: #000";
            lblOrden.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHora
            // 
            lblHora.Dock = DockStyle.Fill;
            lblHora.Location = new Point(483, 0);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(154, 50);
            lblHora.TabIndex = 3;
            lblHora.Text = "Hora: 00:00";
            lblHora.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTipoOrden
            // 
            lblTipoOrden.Dock = DockStyle.Fill;
            lblTipoOrden.Location = new Point(163, 0);
            lblTipoOrden.Name = "lblTipoOrden";
            lblTipoOrden.Size = new Size(154, 50);
            lblTipoOrden.TabIndex = 1;
            lblTipoOrden.Text = "Tipo: Local";
            lblTipoOrden.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMesa
            // 
            lblMesa.Dock = DockStyle.Fill;
            lblMesa.Location = new Point(323, 0);
            lblMesa.Name = "lblMesa";
            lblMesa.Size = new Size(154, 50);
            lblMesa.TabIndex = 2;
            lblMesa.Text = "Mesa: 00";
            lblMesa.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloDetalle
            // 
            lblTituloDetalle.BackColor = Color.White;
            lblTituloDetalle.Dock = DockStyle.Top;
            lblTituloDetalle.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloDetalle.ForeColor = Color.FromArgb(8, 31, 63);
            lblTituloDetalle.Location = new Point(0, 10);
            lblTituloDetalle.Name = "lblTituloDetalle";
            lblTituloDetalle.Size = new Size(940, 50);
            lblTituloDetalle.TabIndex = 1;
            lblTituloDetalle.Text = "Detalle del Pedido";
            lblTituloDetalle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(tlpActions);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlButtons.Location = new Point(0, 750);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(30, 10, 30, 10);
            pnlButtons.Size = new Size(940, 80);
            pnlButtons.TabIndex = 3;
            // 
            // tlpActions
            // 
            tlpActions.ColumnCount = 4;
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpActions.Controls.Add(pnlIniciar, 0, 0);
            tlpActions.Controls.Add(pnMarcarListo, 1, 0);
            tlpActions.Controls.Add(pnlActualizar, 2, 0);
            tlpActions.Controls.Add(pnlLimpiar, 3, 0);
            tlpActions.Dock = DockStyle.Fill;
            tlpActions.Location = new Point(30, 10);
            tlpActions.Name = "tlpActions";
            tlpActions.RowCount = 1;
            tlpActions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpActions.Size = new Size(880, 60);
            tlpActions.TabIndex = 0;
            // 
            // pnlIniciar
            // 
            pnlIniciar.Controls.Add(btnIniciarPreparacion);
            pnlIniciar.Dock = DockStyle.Fill;
            pnlIniciar.Location = new Point(3, 3);
            pnlIniciar.Name = "pnlIniciar";
            pnlIniciar.Padding = new Padding(5);
            pnlIniciar.Size = new Size(214, 54);
            pnlIniciar.TabIndex = 0;
            // 
            // btnIniciarPreparacion
            // 
            btnIniciarPreparacion.Dock = DockStyle.Fill;
            btnIniciarPreparacion.Location = new Point(5, 5);
            btnIniciarPreparacion.Name = "btnIniciarPreparacion";
            btnIniciarPreparacion.Size = new Size(204, 44);
            btnIniciarPreparacion.TabIndex = 0;
            btnIniciarPreparacion.Text = "INICIAR";
            btnIniciarPreparacion.UseVisualStyleBackColor = true;
            // 
            // pnMarcarListo
            // 
            pnMarcarListo.Controls.Add(btnMarcarListo);
            pnMarcarListo.Dock = DockStyle.Fill;
            pnMarcarListo.Location = new Point(223, 3);
            pnMarcarListo.Name = "pnMarcarListo";
            pnMarcarListo.Padding = new Padding(5);
            pnMarcarListo.Size = new Size(214, 54);
            pnMarcarListo.TabIndex = 1;
            // 
            // btnMarcarListo
            // 
            btnMarcarListo.Dock = DockStyle.Fill;
            btnMarcarListo.Location = new Point(5, 5);
            btnMarcarListo.Name = "btnMarcarListo";
            btnMarcarListo.Size = new Size(204, 44);
            btnMarcarListo.TabIndex = 0;
            btnMarcarListo.Text = "LISTO";
            btnMarcarListo.UseVisualStyleBackColor = true;
            // 
            // pnlActualizar
            // 
            pnlActualizar.Controls.Add(btnActualizar);
            pnlActualizar.Dock = DockStyle.Fill;
            pnlActualizar.Location = new Point(443, 3);
            pnlActualizar.Name = "pnlActualizar";
            pnlActualizar.Padding = new Padding(5);
            pnlActualizar.Size = new Size(214, 54);
            pnlActualizar.TabIndex = 3;
            // 
            // btnActualizar
            // 
            btnActualizar.Dock = DockStyle.Fill;
            btnActualizar.Location = new Point(5, 5);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(204, 44);
            btnActualizar.TabIndex = 0;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // pnlLimpiar
            // 
            pnlLimpiar.Controls.Add(btnLimpiar);
            pnlLimpiar.Dock = DockStyle.Fill;
            pnlLimpiar.Location = new Point(663, 3);
            pnlLimpiar.Name = "pnlLimpiar";
            pnlLimpiar.Padding = new Padding(5);
            pnlLimpiar.Size = new Size(214, 54);
            pnlLimpiar.TabIndex = 4;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Dock = DockStyle.Fill;
            btnLimpiar.Location = new Point(5, 5);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(204, 44);
            btnLimpiar.TabIndex = 0;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // FrmCocinaPedidoscs
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(pnlDetalle);
            Controls.Add(pnlButtons);
            Controls.Add(pnlPedidos);
            Controls.Add(pnlResumen);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmCocinaPedidoscs";
            Padding = new Padding(0, 10, 0, 0);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmCocinaPedidoscs";
            pnlResumen.ResumeLayout(false);
            tlpResumenTarjetas.ResumeLayout(false);
            pnlPendientes.ResumeLayout(false);
            pnlPreparación.ResumeLayout(false);
            pnlListos.ResumeLayout(false);
            pnlPedidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetallePedido).EndInit();
            pnlEstadoPedido.ResumeLayout(false);
            tlpEstadoPrioridadPedido.ResumeLayout(false);
            pnlDatosPedido.ResumeLayout(false);
            tlpDetallePedido.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            tlpActions.ResumeLayout(false);
            pnlIniciar.ResumeLayout(false);
            pnMarcarListo.ResumeLayout(false);
            pnlActualizar.ResumeLayout(false);
            pnlLimpiar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlResumen;
        private TableLayoutPanel tlpResumenTarjetas;
        private Panel pnlPendientes;
        private Panel pnlPreparación;
        private Panel pnlListos;
        private Label lblNumeroPendientes;
        private Label lblTituloPendiente;
        private Label lblNumeroPreparacion;
        private Label lblTituloPreparacion;
        private Label lblNumeroListos;
        private Label lblTituloListos;
        private Panel pnlPedidos;
        private Label lblTituloPedidos;
        private DataGridView dgvPedidos;
        private DataGridViewTextBoxColumn colOrden;
        private DataGridViewTextBoxColumn colMesa;
        private DataGridViewTextBoxColumn colTipoOrden;
        private DataGridViewTextBoxColumn colHora;
        private DataGridViewTextBoxColumn colPrioridad;
        private DataGridViewTextBoxColumn colEstado;
        private Panel pnlDetalle;
        private Label lblTituloDetalle;
        private TableLayoutPanel tlpDetallePedido;
        private Label lblOrden;
        private Label lblTipoOrden;
        private Label lblMesa;
        private Label lblHora;
        private Panel pnlDatosPedido;
        private Panel pnlEstadoPedido;
        private TableLayoutPanel tlpEstadoPrioridadPedido;
        private Label lblPrioridad;
        private Label lblEstado;
        private DataGridView dgvDetallePedido;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colProductos;
        private DataGridViewTextBoxColumn colObservaciones;
        private Panel pnlButtons;
        private TableLayoutPanel tlpActions;
        private Panel pnlIniciar;
        private Button btnIniciarPreparacion;
        private Panel pnMarcarListo;
        private Button btnMarcarListo;
        private Panel pnlActualizar;
        private Button btnActualizar;
        private Panel pnlLimpiar;
        private Button btnLimpiar;
    }
}