namespace Ocean_Desk_dv.View.Catalogs
{
    partial class FrmCocinaPedidos
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
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
            dgvPedido = new DataGridView();
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
            pnlLimpiar = new Panel();
            btnLimpiar = new Button();
            pnlActualizar = new Panel();
            btnActualizar = new Button();
            pnlCancelar = new Panel();
            btnCancelar = new Button();
            pnMarcarListo = new Panel();
            btnMarcarListo = new Button();
            pnlIniciar = new Panel();
            btnIniciarPreparacion = new Button();
            TimerActualizacion = new System.Windows.Forms.Timer(components);
            pnlResumen.SuspendLayout();
            tlpResumenTarjetas.SuspendLayout();
            pnlPendientes.SuspendLayout();
            pnlPreparación.SuspendLayout();
            pnlListos.SuspendLayout();
            pnlPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedido).BeginInit();
            pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetallePedido).BeginInit();
            pnlEstadoPedido.SuspendLayout();
            tlpEstadoPrioridadPedido.SuspendLayout();
            pnlDatosPedido.SuspendLayout();
            tlpDetallePedido.SuspendLayout();
            pnlButtons.SuspendLayout();
            tlpActions.SuspendLayout();
            pnlLimpiar.SuspendLayout();
            pnlActualizar.SuspendLayout();
            pnlCancelar.SuspendLayout();
            pnMarcarListo.SuspendLayout();
            pnlIniciar.SuspendLayout();
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
            pnlPedidos.Controls.Add(dgvPedido);
            pnlPedidos.Controls.Add(lblTituloPedidos);
            pnlPedidos.Dock = DockStyle.Top;
            pnlPedidos.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlPedidos.Location = new Point(0, 130);
            pnlPedidos.Name = "pnlPedidos";
            pnlPedidos.Padding = new Padding(0, 10, 0, 0);
            pnlPedidos.Size = new Size(940, 260);
            pnlPedidos.TabIndex = 1;
            // 
            // dgvPedido
            // 
            dgvPedido.AllowUserToAddRows = false;
            dgvPedido.AllowUserToDeleteRows = false;
            dgvPedido.AllowUserToResizeColumns = false;
            dgvPedido.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(247, 249, 251);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(51, 51, 51);
            dgvPedido.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedido.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPedido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPedido.ColumnHeadersHeight = 38;
            dgvPedido.Columns.AddRange(new DataGridViewColumn[] { colOrden, colMesa, colTipoOrden, colHora, colPrioridad, colEstado });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(51, 51, 51);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvPedido.DefaultCellStyle = dataGridViewCellStyle4;
            dgvPedido.Dock = DockStyle.Fill;
            dgvPedido.EnableHeadersVisualStyles = false;
            dgvPedido.GridColor = Color.FromArgb(230, 234, 238);
            dgvPedido.Location = new Point(0, 60);
            dgvPedido.MultiSelect = false;
            dgvPedido.Name = "dgvPedido";
            dgvPedido.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvPedido.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvPedido.RowHeadersVisible = false;
            dgvPedido.RowHeadersWidth = 51;
            dgvPedido.RowTemplate.Height = 35;
            dgvPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedido.Size = new Size(940, 200);
            dgvPedido.TabIndex = 1;
            // 
            // colOrden
            // 
            colOrden.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.ForeColor = Color.Black;
            colOrden.DefaultCellStyle = dataGridViewCellStyle3;
            colOrden.HeaderText = "Orden";
            colOrden.MinimumWidth = 6;
            colOrden.Name = "colOrden";
            colOrden.ReadOnly = true;
            // 
            // colMesa
            // 
            colMesa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMesa.HeaderText = "Mesa";
            colMesa.MinimumWidth = 6;
            colMesa.Name = "colMesa";
            colMesa.ReadOnly = true;
            // 
            // colTipoOrden
            // 
            colTipoOrden.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTipoOrden.HeaderText = "Tipo";
            colTipoOrden.MinimumWidth = 6;
            colTipoOrden.Name = "colTipoOrden";
            colTipoOrden.ReadOnly = true;
            // 
            // colHora
            // 
            colHora.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colHora.HeaderText = "Hora";
            colHora.MinimumWidth = 6;
            colHora.Name = "colHora";
            colHora.ReadOnly = true;
            // 
            // colPrioridad
            // 
            colPrioridad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPrioridad.HeaderText = "Prioridad";
            colPrioridad.MinimumWidth = 6;
            colPrioridad.Name = "colPrioridad";
            colPrioridad.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            dgvDetallePedido.AllowUserToResizeColumns = false;
            dgvDetallePedido.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(247, 249, 251);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(51, 51, 51);
            dgvDetallePedido.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvDetallePedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetallePedido.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle7.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgvDetallePedido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvDetallePedido.ColumnHeadersHeight = 38;
            dgvDetallePedido.Columns.AddRange(new DataGridViewColumn[] { colCantidad, colProductos, colObservaciones });
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = Color.White;
            dataGridViewCellStyle11.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = Color.FromArgb(51, 51, 51);
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle11.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dgvDetallePedido.DefaultCellStyle = dataGridViewCellStyle11;
            dgvDetallePedido.Dock = DockStyle.Fill;
            dgvDetallePedido.EnableHeadersVisualStyles = false;
            dgvDetallePedido.GridColor = Color.FromArgb(230, 234, 238);
            dgvDetallePedido.Location = new Point(0, 150);
            dgvDetallePedido.MultiSelect = false;
            dgvDetallePedido.Name = "dgvDetallePedido";
            dgvDetallePedido.ReadOnly = true;
            dgvDetallePedido.RowHeadersVisible = false;
            dgvDetallePedido.RowHeadersWidth = 51;
            dgvDetallePedido.RowTemplate.Height = 35;
            dgvDetallePedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetallePedido.Size = new Size(940, 210);
            dgvDetallePedido.TabIndex = 5;
            // 
            // colCantidad
            // 
            colCantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCantidad.DefaultCellStyle = dataGridViewCellStyle8;
            colCantidad.FillWeight = 24.613863F;
            colCantidad.HeaderText = "Cantidad";
            colCantidad.MinimumWidth = 6;
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            // 
            // colProductos
            // 
            colProductos.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colProductos.DefaultCellStyle = dataGridViewCellStyle9;
            colProductos.FillWeight = 77.1910553F;
            colProductos.HeaderText = "Productos";
            colProductos.MinimumWidth = 6;
            colProductos.Name = "colProductos";
            colProductos.ReadOnly = true;
            // 
            // colObservaciones
            // 
            colObservaciones.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            colObservaciones.DefaultCellStyle = dataGridViewCellStyle10;
            colObservaciones.FillWeight = 77.1910553F;
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
            lblPrioridad.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblEstado
            // 
            lblEstado.Dock = DockStyle.Fill;
            lblEstado.Location = new Point(3, 0);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(314, 40);
            lblEstado.TabIndex = 0;
            lblEstado.Text = "Estado: EN PREPARACIÓN";
            lblEstado.TextAlign = ContentAlignment.TopCenter;
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
            tlpActions.ColumnCount = 5;
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpActions.Controls.Add(pnlLimpiar, 4, 0);
            tlpActions.Controls.Add(pnlActualizar, 0, 0);
            tlpActions.Controls.Add(pnlCancelar, 3, 0);
            tlpActions.Controls.Add(pnMarcarListo, 2, 0);
            tlpActions.Controls.Add(pnlIniciar, 1, 0);
            tlpActions.Dock = DockStyle.Fill;
            tlpActions.Location = new Point(30, 10);
            tlpActions.Name = "tlpActions";
            tlpActions.RowCount = 1;
            tlpActions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpActions.Size = new Size(880, 60);
            tlpActions.TabIndex = 0;
            // 
            // pnlLimpiar
            // 
            pnlLimpiar.Controls.Add(btnLimpiar);
            pnlLimpiar.Dock = DockStyle.Fill;
            pnlLimpiar.Location = new Point(707, 3);
            pnlLimpiar.Name = "pnlLimpiar";
            pnlLimpiar.Padding = new Padding(5);
            pnlLimpiar.Size = new Size(170, 54);
            pnlLimpiar.TabIndex = 4;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(100, 116, 139);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.Dock = DockStyle.Fill;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(5, 5);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(160, 44);
            btnLimpiar.TabIndex = 0;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // pnlActualizar
            // 
            pnlActualizar.Controls.Add(btnActualizar);
            pnlActualizar.Dock = DockStyle.Fill;
            pnlActualizar.Location = new Point(3, 3);
            pnlActualizar.Name = "pnlActualizar";
            pnlActualizar.Padding = new Padding(5);
            pnlActualizar.Size = new Size(170, 54);
            pnlActualizar.TabIndex = 3;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(8, 31, 63);
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.Dock = DockStyle.Fill;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(5, 5);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(160, 44);
            btnActualizar.TabIndex = 0;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = false;
            // 
            // pnlCancelar
            // 
            pnlCancelar.Controls.Add(btnCancelar);
            pnlCancelar.Dock = DockStyle.Fill;
            pnlCancelar.Location = new Point(531, 3);
            pnlCancelar.Name = "pnlCancelar";
            pnlCancelar.Padding = new Padding(5);
            pnlCancelar.Size = new Size(170, 54);
            pnlCancelar.TabIndex = 4;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(185, 28, 28);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Dock = DockStyle.Fill;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(5, 5);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(160, 44);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // pnMarcarListo
            // 
            pnMarcarListo.Controls.Add(btnMarcarListo);
            pnMarcarListo.Dock = DockStyle.Fill;
            pnMarcarListo.Location = new Point(355, 3);
            pnMarcarListo.Name = "pnMarcarListo";
            pnMarcarListo.Padding = new Padding(5);
            pnMarcarListo.Size = new Size(170, 54);
            pnMarcarListo.TabIndex = 1;
            // 
            // btnMarcarListo
            // 
            btnMarcarListo.BackColor = Color.FromArgb(21, 128, 61);
            btnMarcarListo.Cursor = Cursors.Hand;
            btnMarcarListo.Dock = DockStyle.Fill;
            btnMarcarListo.FlatAppearance.BorderSize = 0;
            btnMarcarListo.FlatStyle = FlatStyle.Flat;
            btnMarcarListo.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            btnMarcarListo.ForeColor = Color.White;
            btnMarcarListo.Location = new Point(5, 5);
            btnMarcarListo.Name = "btnMarcarListo";
            btnMarcarListo.Size = new Size(160, 44);
            btnMarcarListo.TabIndex = 0;
            btnMarcarListo.Text = "LISTO";
            btnMarcarListo.UseVisualStyleBackColor = false;
            // 
            // pnlIniciar
            // 
            pnlIniciar.Controls.Add(btnIniciarPreparacion);
            pnlIniciar.Dock = DockStyle.Fill;
            pnlIniciar.Location = new Point(179, 3);
            pnlIniciar.Name = "pnlIniciar";
            pnlIniciar.Padding = new Padding(5);
            pnlIniciar.Size = new Size(170, 54);
            pnlIniciar.TabIndex = 0;
            // 
            // btnIniciarPreparacion
            // 
            btnIniciarPreparacion.BackColor = Color.FromArgb(217, 119, 6);
            btnIniciarPreparacion.Cursor = Cursors.Hand;
            btnIniciarPreparacion.Dock = DockStyle.Fill;
            btnIniciarPreparacion.FlatAppearance.BorderSize = 0;
            btnIniciarPreparacion.FlatStyle = FlatStyle.Flat;
            btnIniciarPreparacion.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            btnIniciarPreparacion.ForeColor = Color.White;
            btnIniciarPreparacion.Location = new Point(5, 5);
            btnIniciarPreparacion.Name = "btnIniciarPreparacion";
            btnIniciarPreparacion.Size = new Size(160, 44);
            btnIniciarPreparacion.TabIndex = 0;
            btnIniciarPreparacion.Text = "INICIAR";
            btnIniciarPreparacion.UseVisualStyleBackColor = false;
            // 
            // TimerActualizacion
            // 
            TimerActualizacion.Enabled = false;
            TimerActualizacion.Interval = 1500;
            TimerActualizacion.Tick += TimerActualizacion_Tick;
            // 
            // FrmCocinaPedidos
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
            Name = "FrmCocinaPedidos";
            Padding = new Padding(0, 10, 0, 0);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmCocinaPedidoscs";
            pnlResumen.ResumeLayout(false);
            tlpResumenTarjetas.ResumeLayout(false);
            pnlPendientes.ResumeLayout(false);
            pnlPreparación.ResumeLayout(false);
            pnlListos.ResumeLayout(false);
            pnlPedidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPedido).EndInit();
            pnlDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetallePedido).EndInit();
            pnlEstadoPedido.ResumeLayout(false);
            tlpEstadoPrioridadPedido.ResumeLayout(false);
            pnlDatosPedido.ResumeLayout(false);
            tlpDetallePedido.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            tlpActions.ResumeLayout(false);
            pnlLimpiar.ResumeLayout(false);
            pnlActualizar.ResumeLayout(false);
            pnlCancelar.ResumeLayout(false);
            pnMarcarListo.ResumeLayout(false);
            pnlIniciar.ResumeLayout(false);
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
        private Panel pnlCancelar;
        private Button btnCancelar;
        private DataGridView dgvPedido;
        private DataGridViewTextBoxColumn colOrden;
        private DataGridViewTextBoxColumn colMesa;
        private DataGridViewTextBoxColumn colTipoOrden;
        private DataGridViewTextBoxColumn colHora;
        private DataGridViewTextBoxColumn colPrioridad;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colProductos;
        private DataGridViewTextBoxColumn colObservaciones;
        private System.Windows.Forms.Timer TimerActualizacion;
    }
}