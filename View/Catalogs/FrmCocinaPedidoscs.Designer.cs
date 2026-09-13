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
            tlpDetallePedido = new TableLayoutPanel();
            lblTituloDetalle = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            pnlResumen.SuspendLayout();
            tlpResumenTarjetas.SuspendLayout();
            pnlPendientes.SuspendLayout();
            pnlPreparación.SuspendLayout();
            pnlListos.SuspendLayout();
            pnlPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            pnlDetalle.SuspendLayout();
            tlpDetallePedido.SuspendLayout();
            SuspendLayout();
            // 
            // pnlResumen
            // 
            pnlResumen.Controls.Add(tlpResumenTarjetas);
            pnlResumen.Dock = DockStyle.Top;
            pnlResumen.Location = new Point(0, 0);
            pnlResumen.Name = "pnlResumen";
            pnlResumen.Size = new Size(940, 120);
            pnlResumen.TabIndex = 0;
            // 
            // tlpResumenTarjetas
            // 
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
            pnlPendientes.BackColor = Color.White;
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
            pnlPreparación.BackColor = Color.White;
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
            lblNumeroPreparacion.ForeColor = Color.DarkKhaki;
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
            pnlListos.BackColor = Color.White;
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
            pnlPedidos.Location = new Point(0, 120);
            pnlPedidos.Name = "pnlPedidos";
            pnlPedidos.Size = new Size(940, 300);
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
            dgvPedidos.Location = new Point(0, 50);
            dgvPedidos.MultiSelect = false;
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.ReadOnly = true;
            dgvPedidos.RowHeadersVisible = false;
            dgvPedidos.RowHeadersWidth = 51;
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.Size = new Size(940, 250);
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
            lblTituloPedidos.Dock = DockStyle.Top;
            lblTituloPedidos.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloPedidos.ForeColor = Color.FromArgb(8, 31, 63);
            lblTituloPedidos.Location = new Point(0, 0);
            lblTituloPedidos.Name = "lblTituloPedidos";
            lblTituloPedidos.Size = new Size(940, 50);
            lblTituloPedidos.TabIndex = 0;
            lblTituloPedidos.Text = "Pedidos en Cocina";
            lblTituloPedidos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlDetalle
            // 
            pnlDetalle.Controls.Add(tlpDetallePedido);
            pnlDetalle.Controls.Add(lblTituloDetalle);
            pnlDetalle.Dock = DockStyle.Fill;
            pnlDetalle.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlDetalle.Location = new Point(0, 420);
            pnlDetalle.Name = "pnlDetalle";
            pnlDetalle.Size = new Size(940, 410);
            pnlDetalle.TabIndex = 2;
            // 
            // tlpDetallePedido
            // 
            tlpDetallePedido.ColumnCount = 2;
            tlpDetallePedido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDetallePedido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDetallePedido.Controls.Add(label1, 0, 0);
            tlpDetallePedido.Controls.Add(label2, 0, 1);
            tlpDetallePedido.Controls.Add(label3, 1, 0);
            tlpDetallePedido.Controls.Add(label4, 1, 1);
            tlpDetallePedido.Dock = DockStyle.Top;
            tlpDetallePedido.Location = new Point(0, 50);
            tlpDetallePedido.Name = "tlpDetallePedido";
            tlpDetallePedido.RowCount = 2;
            tlpDetallePedido.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpDetallePedido.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpDetallePedido.Size = new Size(940, 70);
            tlpDetallePedido.TabIndex = 0;
            // 
            // lblTituloDetalle
            // 
            lblTituloDetalle.Dock = DockStyle.Top;
            lblTituloDetalle.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloDetalle.ForeColor = Color.FromArgb(8, 31, 63);
            lblTituloDetalle.Location = new Point(0, 0);
            lblTituloDetalle.Name = "lblTituloDetalle";
            lblTituloDetalle.Size = new Size(940, 50);
            lblTituloDetalle.TabIndex = 1;
            lblTituloDetalle.Text = "Detalle del Pedido";
            lblTituloDetalle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(464, 35);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 35);
            label2.Name = "label2";
            label2.Size = new Size(464, 35);
            label2.TabIndex = 1;
            label2.Text = "label2";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(473, 0);
            label3.Name = "label3";
            label3.Size = new Size(464, 35);
            label3.TabIndex = 2;
            label3.Text = "label3";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(473, 35);
            label4.Name = "label4";
            label4.Size = new Size(464, 35);
            label4.TabIndex = 3;
            label4.Text = "label4";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmCocinaPedidoscs
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(pnlDetalle);
            Controls.Add(pnlPedidos);
            Controls.Add(pnlResumen);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmCocinaPedidoscs";
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
            tlpDetallePedido.ResumeLayout(false);
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}