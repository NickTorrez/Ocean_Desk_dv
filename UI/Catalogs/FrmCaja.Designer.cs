namespace Ocean_Desk_dv.UI.Catalogs
{
    partial class FrmCaja
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
            pnlEstadoCaja = new Panel();
            lblDetalleCaja = new Label();
            lblEstadoCaja = new Label();
            lblEstadoTitulo = new Label();
            pnlResumen = new Panel();
            tlpResumen = new TableLayoutPanel();
            pnlResumenApertura = new Panel();
            pnlResumenIngresos = new Panel();
            pnlResumenEgresos = new Panel();
            pnlResumenEsperado = new Panel();
            lblTituloApertura = new Label();
            lblValorApertura = new Label();
            lblTituloIngresos = new Label();
            lblTituloEgresos = new Label();
            lblTituloEsperado = new Label();
            lblValorIngresos = new Label();
            lblValorEgresos = new Label();
            lblValorEsperado = new Label();
            pnlMovimientos = new Panel();
            dgvMovimientosCaja = new DataGridView();
            pnlAcciones = new Panel();
            btnAbrirCaja = new Button();
            btnRegistrarIngreso = new Button();
            btnRegistrarEgreso = new Button();
            btnCerrarCaja = new Button();
            tlpButtons = new TableLayoutPanel();
            pnlCerrar = new Panel();
            pnlEstadoCaja.SuspendLayout();
            pnlResumen.SuspendLayout();
            tlpResumen.SuspendLayout();
            pnlResumenApertura.SuspendLayout();
            pnlResumenIngresos.SuspendLayout();
            pnlResumenEgresos.SuspendLayout();
            pnlResumenEsperado.SuspendLayout();
            pnlMovimientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientosCaja).BeginInit();
            pnlAcciones.SuspendLayout();
            tlpButtons.SuspendLayout();
            pnlCerrar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEstadoCaja
            // 
            pnlEstadoCaja.BackColor = Color.White;
            pnlEstadoCaja.Controls.Add(lblDetalleCaja);
            pnlEstadoCaja.Controls.Add(lblEstadoCaja);
            pnlEstadoCaja.Controls.Add(lblEstadoTitulo);
            pnlEstadoCaja.Dock = DockStyle.Top;
            pnlEstadoCaja.Location = new Point(0, 0);
            pnlEstadoCaja.Margin = new Padding(0);
            pnlEstadoCaja.Name = "pnlEstadoCaja";
            pnlEstadoCaja.Padding = new Padding(15, 10, 15, 10);
            pnlEstadoCaja.Size = new Size(940, 70);
            pnlEstadoCaja.TabIndex = 0;
            // 
            // lblDetalleCaja
            // 
            lblDetalleCaja.Dock = DockStyle.Fill;
            lblDetalleCaja.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDetalleCaja.ForeColor = Color.FromArgb(111, 119, 128);
            lblDetalleCaja.Location = new Point(225, 10);
            lblDetalleCaja.Name = "lblDetalleCaja";
            lblDetalleCaja.Size = new Size(700, 50);
            lblDetalleCaja.TabIndex = 2;
            lblDetalleCaja.Text = "Apertura: 26/08/2026 08:00 a. m.";
            lblDetalleCaja.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEstadoCaja
            // 
            lblEstadoCaja.BackColor = Color.White;
            lblEstadoCaja.Dock = DockStyle.Left;
            lblEstadoCaja.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstadoCaja.ForeColor = Color.Black;
            lblEstadoCaja.Location = new Point(135, 10);
            lblEstadoCaja.Name = "lblEstadoCaja";
            lblEstadoCaja.Size = new Size(90, 50);
            lblEstadoCaja.TabIndex = 1;
            lblEstadoCaja.Text = "ABIERTA";
            lblEstadoCaja.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEstadoTitulo
            // 
            lblEstadoTitulo.Dock = DockStyle.Left;
            lblEstadoTitulo.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstadoTitulo.ForeColor = Color.FromArgb(8, 31, 63);
            lblEstadoTitulo.Location = new Point(15, 10);
            lblEstadoTitulo.Name = "lblEstadoTitulo";
            lblEstadoTitulo.Size = new Size(120, 50);
            lblEstadoTitulo.TabIndex = 0;
            lblEstadoTitulo.Text = "Caja Actual:";
            lblEstadoTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlResumen
            // 
            pnlResumen.BackColor = Color.Transparent;
            pnlResumen.Controls.Add(tlpResumen);
            pnlResumen.Dock = DockStyle.Top;
            pnlResumen.Location = new Point(0, 70);
            pnlResumen.Name = "pnlResumen";
            pnlResumen.Padding = new Padding(0, 10, 0, 10);
            pnlResumen.Size = new Size(940, 105);
            pnlResumen.TabIndex = 1;
            // 
            // tlpResumen
            // 
            tlpResumen.ColumnCount = 4;
            tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpResumen.Controls.Add(pnlResumenApertura, 0, 0);
            tlpResumen.Controls.Add(pnlResumenIngresos, 1, 0);
            tlpResumen.Controls.Add(pnlResumenEgresos, 2, 0);
            tlpResumen.Controls.Add(pnlResumenEsperado, 3, 0);
            tlpResumen.Dock = DockStyle.Fill;
            tlpResumen.Location = new Point(0, 10);
            tlpResumen.Name = "tlpResumen";
            tlpResumen.RowCount = 1;
            tlpResumen.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpResumen.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpResumen.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpResumen.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpResumen.Size = new Size(940, 85);
            tlpResumen.TabIndex = 0;
            // 
            // pnlResumenApertura
            // 
            pnlResumenApertura.BackColor = Color.White;
            pnlResumenApertura.Controls.Add(lblValorApertura);
            pnlResumenApertura.Controls.Add(lblTituloApertura);
            pnlResumenApertura.Dock = DockStyle.Fill;
            pnlResumenApertura.Location = new Point(5, 5);
            pnlResumenApertura.Margin = new Padding(5);
            pnlResumenApertura.Name = "pnlResumenApertura";
            pnlResumenApertura.Padding = new Padding(12);
            pnlResumenApertura.Size = new Size(225, 75);
            pnlResumenApertura.TabIndex = 0;
            // 
            // pnlResumenIngresos
            // 
            pnlResumenIngresos.BackColor = Color.White;
            pnlResumenIngresos.Controls.Add(lblValorIngresos);
            pnlResumenIngresos.Controls.Add(lblTituloIngresos);
            pnlResumenIngresos.Dock = DockStyle.Fill;
            pnlResumenIngresos.Location = new Point(240, 5);
            pnlResumenIngresos.Margin = new Padding(5);
            pnlResumenIngresos.Name = "pnlResumenIngresos";
            pnlResumenIngresos.Padding = new Padding(12);
            pnlResumenIngresos.Size = new Size(225, 75);
            pnlResumenIngresos.TabIndex = 1;
            // 
            // pnlResumenEgresos
            // 
            pnlResumenEgresos.BackColor = Color.White;
            pnlResumenEgresos.Controls.Add(lblValorEgresos);
            pnlResumenEgresos.Controls.Add(lblTituloEgresos);
            pnlResumenEgresos.Dock = DockStyle.Fill;
            pnlResumenEgresos.Location = new Point(475, 5);
            pnlResumenEgresos.Margin = new Padding(5);
            pnlResumenEgresos.Name = "pnlResumenEgresos";
            pnlResumenEgresos.Padding = new Padding(12);
            pnlResumenEgresos.Size = new Size(225, 75);
            pnlResumenEgresos.TabIndex = 2;
            // 
            // pnlResumenEsperado
            // 
            pnlResumenEsperado.BackColor = Color.White;
            pnlResumenEsperado.Controls.Add(lblValorEsperado);
            pnlResumenEsperado.Controls.Add(lblTituloEsperado);
            pnlResumenEsperado.Dock = DockStyle.Fill;
            pnlResumenEsperado.Location = new Point(710, 5);
            pnlResumenEsperado.Margin = new Padding(5);
            pnlResumenEsperado.Name = "pnlResumenEsperado";
            pnlResumenEsperado.Padding = new Padding(12);
            pnlResumenEsperado.Size = new Size(225, 75);
            pnlResumenEsperado.TabIndex = 3;
            // 
            // lblTituloApertura
            // 
            lblTituloApertura.Dock = DockStyle.Top;
            lblTituloApertura.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloApertura.ForeColor = Color.FromArgb(111, 119, 128);
            lblTituloApertura.Location = new Point(12, 12);
            lblTituloApertura.Name = "lblTituloApertura";
            lblTituloApertura.Size = new Size(201, 20);
            lblTituloApertura.TabIndex = 0;
            lblTituloApertura.Text = "Apertura";
            // 
            // lblValorApertura
            // 
            lblValorApertura.Dock = DockStyle.Fill;
            lblValorApertura.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValorApertura.ForeColor = Color.FromArgb(8, 31, 63);
            lblValorApertura.Location = new Point(12, 32);
            lblValorApertura.Name = "lblValorApertura";
            lblValorApertura.Size = new Size(201, 31);
            lblValorApertura.TabIndex = 1;
            lblValorApertura.Text = "C$ 0.00";
            // 
            // lblTituloIngresos
            // 
            lblTituloIngresos.Dock = DockStyle.Top;
            lblTituloIngresos.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloIngresos.ForeColor = Color.FromArgb(111, 119, 128);
            lblTituloIngresos.Location = new Point(12, 12);
            lblTituloIngresos.Name = "lblTituloIngresos";
            lblTituloIngresos.Size = new Size(201, 20);
            lblTituloIngresos.TabIndex = 2;
            lblTituloIngresos.Text = "Ingresos";
            // 
            // lblTituloEgresos
            // 
            lblTituloEgresos.Dock = DockStyle.Top;
            lblTituloEgresos.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloEgresos.ForeColor = Color.FromArgb(111, 119, 128);
            lblTituloEgresos.Location = new Point(12, 12);
            lblTituloEgresos.Name = "lblTituloEgresos";
            lblTituloEgresos.Size = new Size(201, 20);
            lblTituloEgresos.TabIndex = 3;
            lblTituloEgresos.Text = "Egresos";
            // 
            // lblTituloEsperado
            // 
            lblTituloEsperado.Dock = DockStyle.Top;
            lblTituloEsperado.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloEsperado.ForeColor = Color.FromArgb(111, 119, 128);
            lblTituloEsperado.Location = new Point(12, 12);
            lblTituloEsperado.Name = "lblTituloEsperado";
            lblTituloEsperado.Size = new Size(201, 20);
            lblTituloEsperado.TabIndex = 4;
            lblTituloEsperado.Text = "Esperado";
            // 
            // lblValorIngresos
            // 
            lblValorIngresos.Dock = DockStyle.Fill;
            lblValorIngresos.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValorIngresos.ForeColor = Color.FromArgb(42, 122, 82);
            lblValorIngresos.Location = new Point(12, 32);
            lblValorIngresos.Name = "lblValorIngresos";
            lblValorIngresos.Size = new Size(201, 31);
            lblValorIngresos.TabIndex = 2;
            lblValorIngresos.Text = "C$ 0.00";
            // 
            // lblValorEgresos
            // 
            lblValorEgresos.Dock = DockStyle.Fill;
            lblValorEgresos.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValorEgresos.ForeColor = Color.FromArgb(163, 61, 61);
            lblValorEgresos.Location = new Point(12, 32);
            lblValorEgresos.Name = "lblValorEgresos";
            lblValorEgresos.Size = new Size(201, 31);
            lblValorEgresos.TabIndex = 3;
            lblValorEgresos.Text = "C$ 0.00";
            // 
            // lblValorEsperado
            // 
            lblValorEsperado.Dock = DockStyle.Fill;
            lblValorEsperado.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValorEsperado.ForeColor = Color.FromArgb(8, 126, 164);
            lblValorEsperado.Location = new Point(12, 32);
            lblValorEsperado.Name = "lblValorEsperado";
            lblValorEsperado.Size = new Size(201, 31);
            lblValorEsperado.TabIndex = 4;
            lblValorEsperado.Text = "C$ 0.00";
            // 
            // pnlMovimientos
            // 
            pnlMovimientos.BackColor = Color.Transparent;
            pnlMovimientos.Controls.Add(dgvMovimientosCaja);
            pnlMovimientos.Controls.Add(pnlAcciones);
            pnlMovimientos.Dock = DockStyle.Fill;
            pnlMovimientos.Location = new Point(0, 175);
            pnlMovimientos.Name = "pnlMovimientos";
            pnlMovimientos.Padding = new Padding(0, 0, 0, 10);
            pnlMovimientos.Size = new Size(940, 655);
            pnlMovimientos.TabIndex = 2;
            // 
            // dgvMovimientosCaja
            // 
            dgvMovimientosCaja.AllowUserToAddRows = false;
            dgvMovimientosCaja.AllowUserToDeleteRows = false;
            dgvMovimientosCaja.AllowUserToResizeRows = false;
            dgvMovimientosCaja.BackgroundColor = Color.White;
            dgvMovimientosCaja.BorderStyle = BorderStyle.None;
            dgvMovimientosCaja.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimientosCaja.Dock = DockStyle.Fill;
            dgvMovimientosCaja.EnableHeadersVisualStyles = false;
            dgvMovimientosCaja.Location = new Point(0, 0);
            dgvMovimientosCaja.MultiSelect = false;
            dgvMovimientosCaja.Name = "dgvMovimientosCaja";
            dgvMovimientosCaja.ReadOnly = true;
            dgvMovimientosCaja.RowHeadersVisible = false;
            dgvMovimientosCaja.RowHeadersWidth = 51;
            dgvMovimientosCaja.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientosCaja.Size = new Size(940, 580);
            dgvMovimientosCaja.TabIndex = 0;
            // 
            // pnlAcciones
            // 
            pnlAcciones.BackColor = Color.White;
            pnlAcciones.Controls.Add(pnlCerrar);
            pnlAcciones.Controls.Add(tlpButtons);
            pnlAcciones.Dock = DockStyle.Bottom;
            pnlAcciones.Location = new Point(0, 580);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Padding = new Padding(15, 6, 15, 6);
            pnlAcciones.Size = new Size(940, 65);
            pnlAcciones.TabIndex = 1;
            // 
            // btnAbrirCaja
            // 
            btnAbrirCaja.BackColor = Color.FromArgb(238, 243, 247);
            btnAbrirCaja.Dock = DockStyle.Fill;
            btnAbrirCaja.FlatAppearance.BorderSize = 0;
            btnAbrirCaja.FlatStyle = FlatStyle.Flat;
            btnAbrirCaja.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAbrirCaja.ForeColor = Color.FromArgb(8, 31, 63);
            btnAbrirCaja.Location = new Point(3, 3);
            btnAbrirCaja.Name = "btnAbrirCaja";
            btnAbrirCaja.Size = new Size(127, 47);
            btnAbrirCaja.TabIndex = 0;
            btnAbrirCaja.Text = "ABRIR CAJA";
            btnAbrirCaja.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarIngreso
            // 
            btnRegistrarIngreso.BackColor = Color.FromArgb(238, 243, 247);
            btnRegistrarIngreso.Dock = DockStyle.Fill;
            btnRegistrarIngreso.FlatAppearance.BorderSize = 0;
            btnRegistrarIngreso.FlatStyle = FlatStyle.Flat;
            btnRegistrarIngreso.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrarIngreso.ForeColor = Color.FromArgb(8, 31, 63);
            btnRegistrarIngreso.Location = new Point(136, 3);
            btnRegistrarIngreso.Name = "btnRegistrarIngreso";
            btnRegistrarIngreso.Size = new Size(127, 47);
            btnRegistrarIngreso.TabIndex = 1;
            btnRegistrarIngreso.Text = "INGRESO";
            btnRegistrarIngreso.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarEgreso
            // 
            btnRegistrarEgreso.BackColor = Color.FromArgb(238, 243, 247);
            btnRegistrarEgreso.Dock = DockStyle.Fill;
            btnRegistrarEgreso.FlatAppearance.BorderSize = 0;
            btnRegistrarEgreso.FlatStyle = FlatStyle.Flat;
            btnRegistrarEgreso.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrarEgreso.ForeColor = Color.FromArgb(8, 31, 63);
            btnRegistrarEgreso.Location = new Point(269, 3);
            btnRegistrarEgreso.Name = "btnRegistrarEgreso";
            btnRegistrarEgreso.Size = new Size(128, 47);
            btnRegistrarEgreso.TabIndex = 2;
            btnRegistrarEgreso.Text = "EGRESO";
            btnRegistrarEgreso.UseVisualStyleBackColor = false;
            // 
            // btnCerrarCaja
            // 
            btnCerrarCaja.BackColor = Color.FromArgb(8, 126, 164);
            btnCerrarCaja.Dock = DockStyle.Fill;
            btnCerrarCaja.FlatAppearance.BorderSize = 0;
            btnCerrarCaja.FlatStyle = FlatStyle.Flat;
            btnCerrarCaja.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrarCaja.ForeColor = Color.White;
            btnCerrarCaja.Location = new Point(0, 0);
            btnCerrarCaja.Name = "btnCerrarCaja";
            btnCerrarCaja.Size = new Size(150, 53);
            btnCerrarCaja.TabIndex = 3;
            btnCerrarCaja.Text = "CERRAR CAJA";
            btnCerrarCaja.UseVisualStyleBackColor = false;
            // 
            // tlpButtons
            // 
            tlpButtons.ColumnCount = 3;
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpButtons.Controls.Add(btnAbrirCaja, 0, 0);
            tlpButtons.Controls.Add(btnRegistrarEgreso, 2, 0);
            tlpButtons.Controls.Add(btnRegistrarIngreso, 1, 0);
            tlpButtons.Dock = DockStyle.Left;
            tlpButtons.Location = new Point(15, 6);
            tlpButtons.Margin = new Padding(5, 3, 3, 3);
            tlpButtons.Name = "tlpButtons";
            tlpButtons.RowCount = 1;
            tlpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpButtons.Size = new Size(400, 53);
            tlpButtons.TabIndex = 4;
            // 
            // pnlCerrar
            // 
            pnlCerrar.Controls.Add(btnCerrarCaja);
            pnlCerrar.Dock = DockStyle.Right;
            pnlCerrar.Location = new Point(775, 6);
            pnlCerrar.Name = "pnlCerrar";
            pnlCerrar.Size = new Size(150, 53);
            pnlCerrar.TabIndex = 5;
            // 
            // FrmCaja
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(pnlMovimientos);
            Controls.Add(pnlResumen);
            Controls.Add(pnlEstadoCaja);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmCaja";
            Text = "FrmCaja";
            pnlEstadoCaja.ResumeLayout(false);
            pnlResumen.ResumeLayout(false);
            tlpResumen.ResumeLayout(false);
            pnlResumenApertura.ResumeLayout(false);
            pnlResumenIngresos.ResumeLayout(false);
            pnlResumenEgresos.ResumeLayout(false);
            pnlResumenEsperado.ResumeLayout(false);
            pnlMovimientos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMovimientosCaja).EndInit();
            pnlAcciones.ResumeLayout(false);
            tlpButtons.ResumeLayout(false);
            pnlCerrar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlEstadoCaja;
        private Label lblDetalleCaja;
        private Label lblEstadoCaja;
        private Label lblEstadoTitulo;
        private Panel pnlResumen;
        private TableLayoutPanel tlpResumen;
        private Panel pnlResumenApertura;
        private Panel pnlResumenIngresos;
        private Label lblValorApertura;
        private Label lblTituloApertura;
        private Panel pnlResumenEgresos;
        private Panel pnlResumenEsperado;
        private Label lblValorIngresos;
        private Label lblTituloIngresos;
        private Label lblValorEgresos;
        private Label lblTituloEgresos;
        private Label lblValorEsperado;
        private Label lblTituloEsperado;
        private Panel pnlMovimientos;
        private DataGridView dgvMovimientosCaja;
        private Panel pnlAcciones;
        private Button btnRegistrarEgreso;
        private Button btnRegistrarIngreso;
        private Button btnAbrirCaja;
        private Button btnCerrarCaja;
        private TableLayoutPanel tlpButtons;
        private Panel pnlCerrar;
    }
}