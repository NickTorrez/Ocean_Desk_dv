namespace Ocean_Desk_dv.UI.Catalogs
{
    partial class FrmMesasReservas
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            tlpMain = new TableLayoutPanel();
            pnlMesas = new Panel();
            flpMesas = new FlowLayoutPanel();
            lblSubtituloMesas = new Label();
            lblTituloMesas = new Label();
            pnlContenidoReservas = new Panel();
            pnlReservas = new Panel();
            dgvReservas = new DataGridView();
            colReservaCliente = new DataGridViewTextBoxColumn();
            colReservaFecha = new DataGridViewTextBoxColumn();
            colReservaHora = new DataGridViewTextBoxColumn();
            colReservaPersonas = new DataGridViewTextBoxColumn();
            colReservaMesa = new DataGridViewTextBoxColumn();
            colReservaEstado = new DataGridViewTextBoxColumn();
            pnlAccionesReserva = new Panel();
            tlpAsignacionMesa = new TableLayoutPanel();
            btnAsignarMesa = new Button();
            tlpGestionReservas = new TableLayoutPanel();
            btnCancelarReserva = new Button();
            btnEditarReserva = new Button();
            btnNuevaReserva = new Button();
            pnlFiltrosReservas = new Panel();
            tlpFiltrosReservas = new TableLayoutPanel();
            pnlBuscarReserva = new Panel();
            pnlSearchInput = new Panel();
            pnlLine = new Panel();
            txtBuscarReserva = new TextBox();
            lblGhost = new Label();
            picSearchReserva = new PictureBox();
            pnlFechaReserva = new Panel();
            dtpFechaReserva = new DateTimePicker();
            lblScondGhost = new Label();
            label1 = new Label();
            pnlEstadoReserva = new Panel();
            cmbEstadoReserva = new ComboBox();
            lblThirdGhost = new Label();
            label2 = new Label();
            lblSubtituloReservas = new Label();
            lblTituloReservas = new Label();
            pnlNuevaReservaContainer = new Panel();
            pnlNuevaReserva = new Panel();
            pnlDatosNuevaReserva = new Panel();
            tlpNuevaReserva = new TableLayoutPanel();
            lblCliente = new Label();
            lblFechaReserva = new Label();
            lblHoraReserva = new Label();
            lblPersonasReserva = new Label();
            lblMesaReserva = new Label();
            txtClienteReserva = new TextBox();
            dtpFechaNuevaReserva = new DateTimePicker();
            dtpHoraNuevaReserva = new DateTimePicker();
            nudPersonas = new NumericUpDown();
            cmbMesaReserva = new ComboBox();
            pnlAccionesNuevaReserva = new Panel();
            tlpButtons = new TableLayoutPanel();
            btnCancelarNuevaReserva = new Button();
            btnGuardarNuevaReserva = new Button();
            lblTituloNuevaReserva = new Label();
            tlpMain.SuspendLayout();
            pnlMesas.SuspendLayout();
            pnlContenidoReservas.SuspendLayout();
            pnlReservas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            pnlAccionesReserva.SuspendLayout();
            tlpAsignacionMesa.SuspendLayout();
            tlpGestionReservas.SuspendLayout();
            pnlFiltrosReservas.SuspendLayout();
            tlpFiltrosReservas.SuspendLayout();
            pnlBuscarReserva.SuspendLayout();
            pnlSearchInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSearchReserva).BeginInit();
            pnlFechaReserva.SuspendLayout();
            pnlEstadoReserva.SuspendLayout();
            pnlNuevaReservaContainer.SuspendLayout();
            pnlNuevaReserva.SuspendLayout();
            pnlDatosNuevaReserva.SuspendLayout();
            tlpNuevaReserva.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPersonas).BeginInit();
            pnlAccionesNuevaReserva.SuspendLayout();
            tlpButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(pnlMesas, 0, 0);
            tlpMain.Controls.Add(pnlContenidoReservas, 0, 1);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Margin = new Padding(0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 2;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpMain.Size = new Size(940, 830);
            tlpMain.TabIndex = 0;
            // 
            // pnlMesas
            // 
            pnlMesas.BackColor = Color.White;
            pnlMesas.Controls.Add(flpMesas);
            pnlMesas.Controls.Add(lblSubtituloMesas);
            pnlMesas.Controls.Add(lblTituloMesas);
            pnlMesas.Dock = DockStyle.Fill;
            pnlMesas.Location = new Point(0, 0);
            pnlMesas.Margin = new Padding(0, 0, 0, 8);
            pnlMesas.Name = "pnlMesas";
            pnlMesas.Padding = new Padding(15, 10, 15, 10);
            pnlMesas.Size = new Size(940, 324);
            pnlMesas.TabIndex = 0;
            // 
            // flpMesas
            // 
            flpMesas.AutoScroll = true;
            flpMesas.BackColor = Color.Transparent;
            flpMesas.Dock = DockStyle.Fill;
            flpMesas.Location = new Point(15, 60);
            flpMesas.Name = "flpMesas";
            flpMesas.Padding = new Padding(5);
            flpMesas.Size = new Size(910, 254);
            flpMesas.TabIndex = 2;
            // 
            // lblSubtituloMesas
            // 
            lblSubtituloMesas.Dock = DockStyle.Top;
            lblSubtituloMesas.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtituloMesas.ForeColor = Color.FromArgb(111, 119, 128);
            lblSubtituloMesas.Location = new Point(15, 38);
            lblSubtituloMesas.Margin = new Padding(3, 0, 3, 3);
            lblSubtituloMesas.Name = "lblSubtituloMesas";
            lblSubtituloMesas.Size = new Size(910, 22);
            lblSubtituloMesas.TabIndex = 1;
            lblSubtituloMesas.Text = "Estado y disponibilidad de las mesas";
            // 
            // lblTituloMesas
            // 
            lblTituloMesas.Dock = DockStyle.Top;
            lblTituloMesas.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloMesas.ForeColor = Color.FromArgb(8, 31, 63);
            lblTituloMesas.Location = new Point(15, 10);
            lblTituloMesas.Name = "lblTituloMesas";
            lblTituloMesas.Size = new Size(910, 28);
            lblTituloMesas.TabIndex = 0;
            lblTituloMesas.Text = "Mesas";
            lblTituloMesas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlContenidoReservas
            // 
            pnlContenidoReservas.Controls.Add(pnlReservas);
            pnlContenidoReservas.Controls.Add(pnlNuevaReservaContainer);
            pnlContenidoReservas.Dock = DockStyle.Fill;
            pnlContenidoReservas.Location = new Point(0, 332);
            pnlContenidoReservas.Margin = new Padding(0);
            pnlContenidoReservas.Name = "pnlContenidoReservas";
            pnlContenidoReservas.Padding = new Padding(0, 5, 0, 0);
            pnlContenidoReservas.Size = new Size(940, 498);
            pnlContenidoReservas.TabIndex = 1;
            // 
            // pnlReservas
            // 
            pnlReservas.BackColor = Color.White;
            pnlReservas.Controls.Add(dgvReservas);
            pnlReservas.Controls.Add(pnlAccionesReserva);
            pnlReservas.Controls.Add(pnlFiltrosReservas);
            pnlReservas.Controls.Add(lblSubtituloReservas);
            pnlReservas.Controls.Add(lblTituloReservas);
            pnlReservas.Dock = DockStyle.Fill;
            pnlReservas.Location = new Point(0, 5);
            pnlReservas.Margin = new Padding(0);
            pnlReservas.Name = "pnlReservas";
            pnlReservas.Padding = new Padding(15, 10, 15, 10);
            pnlReservas.Size = new Size(940, 493);
            pnlReservas.TabIndex = 1;
            // 
            // dgvReservas
            // 
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AllowUserToDeleteRows = false;
            dgvReservas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dgvReservas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservas.BorderStyle = BorderStyle.None;
            dgvReservas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Navy;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvReservas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservas.Columns.AddRange(new DataGridViewColumn[] { colReservaCliente, colReservaFecha, colReservaHora, colReservaPersonas, colReservaMesa, colReservaEstado });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Window;
            dataGridViewCellStyle9.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgvReservas.DefaultCellStyle = dataGridViewCellStyle9;
            dgvReservas.Dock = DockStyle.Fill;
            dgvReservas.EnableHeadersVisualStyles = false;
            dgvReservas.GridColor = Color.FromArgb(230, 234, 238);
            dgvReservas.Location = new Point(15, 120);
            dgvReservas.MultiSelect = false;
            dgvReservas.Name = "dgvReservas";
            dgvReservas.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle10.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dgvReservas.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dgvReservas.RowHeadersVisible = false;
            dgvReservas.RowHeadersWidth = 51;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.Size = new Size(910, 303);
            dgvReservas.TabIndex = 3;
            dgvReservas.CellFormatting += dgvReservas_CellFormatting;
            dgvReservas.SelectionChanged += dgvReservas_SelectionChanged;
            // 
            // colReservaCliente
            // 
            colReservaCliente.DataPropertyName = "Cliente";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colReservaCliente.DefaultCellStyle = dataGridViewCellStyle3;
            colReservaCliente.FillWeight = 30F;
            colReservaCliente.HeaderText = "Cliente";
            colReservaCliente.MinimumWidth = 6;
            colReservaCliente.Name = "colReservaCliente";
            colReservaCliente.ReadOnly = true;
            // 
            // colReservaFecha
            // 
            colReservaFecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            colReservaFecha.DefaultCellStyle = dataGridViewCellStyle4;
            colReservaFecha.FillWeight = 15F;
            colReservaFecha.HeaderText = "Fecha";
            colReservaFecha.MinimumWidth = 6;
            colReservaFecha.Name = "colReservaFecha";
            colReservaFecha.ReadOnly = true;
            // 
            // colReservaHora
            // 
            colReservaHora.DataPropertyName = "Hora";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "t";
            dataGridViewCellStyle5.NullValue = null;
            colReservaHora.DefaultCellStyle = dataGridViewCellStyle5;
            colReservaHora.FillWeight = 10F;
            colReservaHora.HeaderText = "Hora";
            colReservaHora.MinimumWidth = 6;
            colReservaHora.Name = "colReservaHora";
            colReservaHora.ReadOnly = true;
            // 
            // colReservaPersonas
            // 
            colReservaPersonas.DataPropertyName = "Personas";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colReservaPersonas.DefaultCellStyle = dataGridViewCellStyle6;
            colReservaPersonas.FillWeight = 10F;
            colReservaPersonas.HeaderText = "Personas";
            colReservaPersonas.MinimumWidth = 6;
            colReservaPersonas.Name = "colReservaPersonas";
            colReservaPersonas.ReadOnly = true;
            // 
            // colReservaMesa
            // 
            colReservaMesa.DataPropertyName = "Mesa";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colReservaMesa.DefaultCellStyle = dataGridViewCellStyle7;
            colReservaMesa.FillWeight = 10F;
            colReservaMesa.HeaderText = "Mesa";
            colReservaMesa.MinimumWidth = 6;
            colReservaMesa.Name = "colReservaMesa";
            colReservaMesa.ReadOnly = true;
            // 
            // colReservaEstado
            // 
            colReservaEstado.DataPropertyName = "Estado";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colReservaEstado.DefaultCellStyle = dataGridViewCellStyle8;
            colReservaEstado.FillWeight = 25F;
            colReservaEstado.HeaderText = "Estado";
            colReservaEstado.MinimumWidth = 6;
            colReservaEstado.Name = "colReservaEstado";
            colReservaEstado.ReadOnly = true;
            // 
            // pnlAccionesReserva
            // 
            pnlAccionesReserva.Controls.Add(tlpAsignacionMesa);
            pnlAccionesReserva.Controls.Add(tlpGestionReservas);
            pnlAccionesReserva.Dock = DockStyle.Bottom;
            pnlAccionesReserva.Location = new Point(15, 423);
            pnlAccionesReserva.Name = "pnlAccionesReserva";
            pnlAccionesReserva.Padding = new Padding(15, 7, 15, 7);
            pnlAccionesReserva.Size = new Size(910, 60);
            pnlAccionesReserva.TabIndex = 4;
            // 
            // tlpAsignacionMesa
            // 
            tlpAsignacionMesa.ColumnCount = 1;
            tlpAsignacionMesa.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpAsignacionMesa.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpAsignacionMesa.Controls.Add(btnAsignarMesa, 0, 0);
            tlpAsignacionMesa.Dock = DockStyle.Right;
            tlpAsignacionMesa.Location = new Point(695, 7);
            tlpAsignacionMesa.Name = "tlpAsignacionMesa";
            tlpAsignacionMesa.RowCount = 1;
            tlpAsignacionMesa.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpAsignacionMesa.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpAsignacionMesa.Size = new Size(200, 46);
            tlpAsignacionMesa.TabIndex = 5;
            // 
            // btnAsignarMesa
            // 
            btnAsignarMesa.BackColor = Color.FromArgb(238, 243, 247);
            btnAsignarMesa.Cursor = Cursors.Hand;
            btnAsignarMesa.Dock = DockStyle.Fill;
            btnAsignarMesa.FlatAppearance.BorderSize = 0;
            btnAsignarMesa.FlatStyle = FlatStyle.Flat;
            btnAsignarMesa.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAsignarMesa.ForeColor = Color.FromArgb(8, 31, 63);
            btnAsignarMesa.Location = new Point(3, 3);
            btnAsignarMesa.Name = "btnAsignarMesa";
            btnAsignarMesa.Size = new Size(194, 40);
            btnAsignarMesa.TabIndex = 3;
            btnAsignarMesa.Text = "ASIGNAR MESA";
            btnAsignarMesa.UseVisualStyleBackColor = false;
            btnAsignarMesa.Click += btnAsignarMesa_Click;
            // 
            // tlpGestionReservas
            // 
            tlpGestionReservas.ColumnCount = 3;
            tlpGestionReservas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpGestionReservas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlpGestionReservas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlpGestionReservas.Controls.Add(btnCancelarReserva, 2, 0);
            tlpGestionReservas.Controls.Add(btnEditarReserva, 1, 0);
            tlpGestionReservas.Controls.Add(btnNuevaReserva, 0, 0);
            tlpGestionReservas.Dock = DockStyle.Left;
            tlpGestionReservas.Location = new Point(15, 7);
            tlpGestionReservas.Name = "tlpGestionReservas";
            tlpGestionReservas.RowCount = 1;
            tlpGestionReservas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpGestionReservas.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpGestionReservas.Size = new Size(450, 46);
            tlpGestionReservas.TabIndex = 4;
            // 
            // btnCancelarReserva
            // 
            btnCancelarReserva.BackColor = Color.FromArgb(248, 234, 234);
            btnCancelarReserva.Cursor = Cursors.Hand;
            btnCancelarReserva.Dock = DockStyle.Fill;
            btnCancelarReserva.FlatAppearance.BorderSize = 0;
            btnCancelarReserva.FlatStyle = FlatStyle.Flat;
            btnCancelarReserva.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelarReserva.ForeColor = Color.FromArgb(163, 61, 61);
            btnCancelarReserva.Location = new Point(318, 3);
            btnCancelarReserva.Name = "btnCancelarReserva";
            btnCancelarReserva.Size = new Size(129, 40);
            btnCancelarReserva.TabIndex = 2;
            btnCancelarReserva.Text = "CANCELAR";
            btnCancelarReserva.UseVisualStyleBackColor = false;
            btnCancelarReserva.Click += btnCancelarReserva_Click;
            // 
            // btnEditarReserva
            // 
            btnEditarReserva.BackColor = Color.FromArgb(238, 243, 247);
            btnEditarReserva.Cursor = Cursors.Hand;
            btnEditarReserva.Dock = DockStyle.Fill;
            btnEditarReserva.FlatAppearance.BorderSize = 0;
            btnEditarReserva.FlatStyle = FlatStyle.Flat;
            btnEditarReserva.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditarReserva.ForeColor = Color.FromArgb(8, 31, 63);
            btnEditarReserva.Location = new Point(183, 3);
            btnEditarReserva.Name = "btnEditarReserva";
            btnEditarReserva.Size = new Size(129, 40);
            btnEditarReserva.TabIndex = 1;
            btnEditarReserva.Text = "EDITAR";
            btnEditarReserva.UseVisualStyleBackColor = false;
            btnEditarReserva.Click += btnEditarReserva_Click;
            // 
            // btnNuevaReserva
            // 
            btnNuevaReserva.BackColor = Color.FromArgb(8, 126, 164);
            btnNuevaReserva.Cursor = Cursors.Hand;
            btnNuevaReserva.Dock = DockStyle.Fill;
            btnNuevaReserva.FlatAppearance.BorderSize = 0;
            btnNuevaReserva.FlatStyle = FlatStyle.Flat;
            btnNuevaReserva.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevaReserva.ForeColor = Color.White;
            btnNuevaReserva.Location = new Point(3, 3);
            btnNuevaReserva.Name = "btnNuevaReserva";
            btnNuevaReserva.Size = new Size(174, 40);
            btnNuevaReserva.TabIndex = 0;
            btnNuevaReserva.Text = "NUEVA RESERVA";
            btnNuevaReserva.UseVisualStyleBackColor = false;
            btnNuevaReserva.Click += btnNuevaReserva_Click;
            // 
            // pnlFiltrosReservas
            // 
            pnlFiltrosReservas.BackColor = Color.FromArgb(245, 247, 250);
            pnlFiltrosReservas.Controls.Add(tlpFiltrosReservas);
            pnlFiltrosReservas.Dock = DockStyle.Top;
            pnlFiltrosReservas.Location = new Point(15, 60);
            pnlFiltrosReservas.Margin = new Padding(0, 8, 0, 8);
            pnlFiltrosReservas.Name = "pnlFiltrosReservas";
            pnlFiltrosReservas.Padding = new Padding(10);
            pnlFiltrosReservas.Size = new Size(910, 60);
            pnlFiltrosReservas.TabIndex = 2;
            // 
            // tlpFiltrosReservas
            // 
            tlpFiltrosReservas.ColumnCount = 3;
            tlpFiltrosReservas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tlpFiltrosReservas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpFiltrosReservas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlpFiltrosReservas.Controls.Add(pnlBuscarReserva, 0, 0);
            tlpFiltrosReservas.Controls.Add(pnlFechaReserva, 1, 0);
            tlpFiltrosReservas.Controls.Add(pnlEstadoReserva, 2, 0);
            tlpFiltrosReservas.Dock = DockStyle.Fill;
            tlpFiltrosReservas.Location = new Point(10, 10);
            tlpFiltrosReservas.Name = "tlpFiltrosReservas";
            tlpFiltrosReservas.RowCount = 1;
            tlpFiltrosReservas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpFiltrosReservas.Size = new Size(890, 40);
            tlpFiltrosReservas.TabIndex = 0;
            // 
            // pnlBuscarReserva
            // 
            pnlBuscarReserva.Controls.Add(pnlSearchInput);
            pnlBuscarReserva.Controls.Add(lblGhost);
            pnlBuscarReserva.Controls.Add(picSearchReserva);
            pnlBuscarReserva.Dock = DockStyle.Fill;
            pnlBuscarReserva.Location = new Point(3, 3);
            pnlBuscarReserva.Name = "pnlBuscarReserva";
            pnlBuscarReserva.Size = new Size(394, 34);
            pnlBuscarReserva.TabIndex = 0;
            // 
            // pnlSearchInput
            // 
            pnlSearchInput.BackColor = Color.White;
            pnlSearchInput.Controls.Add(pnlLine);
            pnlSearchInput.Controls.Add(txtBuscarReserva);
            pnlSearchInput.Dock = DockStyle.Top;
            pnlSearchInput.Location = new Point(35, 5);
            pnlSearchInput.Margin = new Padding(5, 0, 0, 0);
            pnlSearchInput.Name = "pnlSearchInput";
            pnlSearchInput.Size = new Size(359, 25);
            pnlSearchInput.TabIndex = 4;
            // 
            // pnlLine
            // 
            pnlLine.BackColor = Color.MidnightBlue;
            pnlLine.Dock = DockStyle.Bottom;
            pnlLine.Location = new Point(0, 23);
            pnlLine.Margin = new Padding(0);
            pnlLine.Name = "pnlLine";
            pnlLine.Size = new Size(359, 2);
            pnlLine.TabIndex = 2;
            // 
            // txtBuscarReserva
            // 
            txtBuscarReserva.BorderStyle = BorderStyle.None;
            txtBuscarReserva.Dock = DockStyle.Fill;
            txtBuscarReserva.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarReserva.ForeColor = Color.FromArgb(8, 31, 63);
            txtBuscarReserva.Location = new Point(0, 0);
            txtBuscarReserva.Margin = new Padding(0);
            txtBuscarReserva.Name = "txtBuscarReserva";
            txtBuscarReserva.PlaceholderText = "Buscar Reserva...";
            txtBuscarReserva.Size = new Size(359, 21);
            txtBuscarReserva.TabIndex = 1;
            // 
            // lblGhost
            // 
            lblGhost.Dock = DockStyle.Top;
            lblGhost.ForeColor = Color.FromArgb(245, 247, 250);
            lblGhost.Location = new Point(35, 0);
            lblGhost.Name = "lblGhost";
            lblGhost.Size = new Size(359, 5);
            lblGhost.TabIndex = 3;
            lblGhost.Text = "label1";
            // 
            // picSearchReserva
            // 
            picSearchReserva.Dock = DockStyle.Left;
            picSearchReserva.Image = Properties.Resources.magnifier;
            picSearchReserva.Location = new Point(0, 0);
            picSearchReserva.Margin = new Padding(0);
            picSearchReserva.Name = "picSearchReserva";
            picSearchReserva.Size = new Size(35, 34);
            picSearchReserva.SizeMode = PictureBoxSizeMode.CenterImage;
            picSearchReserva.TabIndex = 3;
            picSearchReserva.TabStop = false;
            // 
            // pnlFechaReserva
            // 
            pnlFechaReserva.Controls.Add(dtpFechaReserva);
            pnlFechaReserva.Controls.Add(lblScondGhost);
            pnlFechaReserva.Controls.Add(label1);
            pnlFechaReserva.Location = new Point(403, 3);
            pnlFechaReserva.Name = "pnlFechaReserva";
            pnlFechaReserva.Size = new Size(216, 34);
            pnlFechaReserva.TabIndex = 1;
            // 
            // dtpFechaReserva
            // 
            dtpFechaReserva.Dock = DockStyle.Fill;
            dtpFechaReserva.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaReserva.Format = DateTimePickerFormat.Short;
            dtpFechaReserva.Location = new Point(59, 5);
            dtpFechaReserva.Name = "dtpFechaReserva";
            dtpFechaReserva.Size = new Size(157, 26);
            dtpFechaReserva.TabIndex = 4;
            // 
            // lblScondGhost
            // 
            lblScondGhost.Dock = DockStyle.Top;
            lblScondGhost.ForeColor = Color.FromArgb(245, 247, 250);
            lblScondGhost.Location = new Point(59, 0);
            lblScondGhost.Name = "lblScondGhost";
            lblScondGhost.Size = new Size(157, 5);
            lblScondGhost.TabIndex = 5;
            lblScondGhost.Text = "label2";
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(95, 104, 114);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(59, 34);
            label1.TabIndex = 3;
            label1.Text = "Fecha:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlEstadoReserva
            // 
            pnlEstadoReserva.Controls.Add(cmbEstadoReserva);
            pnlEstadoReserva.Controls.Add(lblThirdGhost);
            pnlEstadoReserva.Controls.Add(label2);
            pnlEstadoReserva.Dock = DockStyle.Fill;
            pnlEstadoReserva.Location = new Point(625, 3);
            pnlEstadoReserva.Name = "pnlEstadoReserva";
            pnlEstadoReserva.Size = new Size(262, 34);
            pnlEstadoReserva.TabIndex = 2;
            // 
            // cmbEstadoReserva
            // 
            cmbEstadoReserva.Dock = DockStyle.Fill;
            cmbEstadoReserva.FormattingEnabled = true;
            cmbEstadoReserva.Location = new Point(62, 4);
            cmbEstadoReserva.Name = "cmbEstadoReserva";
            cmbEstadoReserva.Size = new Size(200, 28);
            cmbEstadoReserva.TabIndex = 1;
            // 
            // lblThirdGhost
            // 
            lblThirdGhost.Dock = DockStyle.Top;
            lblThirdGhost.ForeColor = Color.FromArgb(245, 247, 250);
            lblThirdGhost.Location = new Point(62, 0);
            lblThirdGhost.Name = "lblThirdGhost";
            lblThirdGhost.Size = new Size(200, 4);
            lblThirdGhost.TabIndex = 2;
            lblThirdGhost.Text = "label3";
            // 
            // label2
            // 
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(95, 104, 114);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(62, 34);
            label2.TabIndex = 0;
            label2.Text = "Estado:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSubtituloReservas
            // 
            lblSubtituloReservas.Dock = DockStyle.Top;
            lblSubtituloReservas.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtituloReservas.ForeColor = Color.FromArgb(111, 119, 128);
            lblSubtituloReservas.Location = new Point(15, 38);
            lblSubtituloReservas.Name = "lblSubtituloReservas";
            lblSubtituloReservas.Size = new Size(910, 22);
            lblSubtituloReservas.TabIndex = 1;
            lblSubtituloReservas.Text = "Administración y seguimiento de reservas";
            // 
            // lblTituloReservas
            // 
            lblTituloReservas.Dock = DockStyle.Top;
            lblTituloReservas.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloReservas.ForeColor = Color.FromArgb(8, 31, 63);
            lblTituloReservas.Location = new Point(15, 10);
            lblTituloReservas.Name = "lblTituloReservas";
            lblTituloReservas.Size = new Size(910, 28);
            lblTituloReservas.TabIndex = 0;
            lblTituloReservas.Text = "Reservas";
            // 
            // pnlNuevaReservaContainer
            // 
            pnlNuevaReservaContainer.BackColor = Color.WhiteSmoke;
            pnlNuevaReservaContainer.Controls.Add(pnlNuevaReserva);
            pnlNuevaReservaContainer.Dock = DockStyle.Fill;
            pnlNuevaReservaContainer.Location = new Point(0, 5);
            pnlNuevaReservaContainer.Name = "pnlNuevaReservaContainer";
            pnlNuevaReservaContainer.Padding = new Padding(170, 50, 170, 50);
            pnlNuevaReservaContainer.Size = new Size(940, 493);
            pnlNuevaReservaContainer.TabIndex = 2;
            pnlNuevaReservaContainer.Visible = false;
            // 
            // pnlNuevaReserva
            // 
            pnlNuevaReserva.Anchor = AnchorStyles.None;
            pnlNuevaReserva.BackColor = Color.White;
            pnlNuevaReserva.Controls.Add(pnlDatosNuevaReserva);
            pnlNuevaReserva.Controls.Add(pnlAccionesNuevaReserva);
            pnlNuevaReserva.Controls.Add(lblTituloNuevaReserva);
            pnlNuevaReserva.Location = new Point(170, 50);
            pnlNuevaReserva.Name = "pnlNuevaReserva";
            pnlNuevaReserva.Padding = new Padding(20);
            pnlNuevaReserva.Size = new Size(600, 393);
            pnlNuevaReserva.TabIndex = 0;
            // 
            // pnlDatosNuevaReserva
            // 
            pnlDatosNuevaReserva.Controls.Add(tlpNuevaReserva);
            pnlDatosNuevaReserva.Dock = DockStyle.Fill;
            pnlDatosNuevaReserva.Location = new Point(20, 68);
            pnlDatosNuevaReserva.Margin = new Padding(0);
            pnlDatosNuevaReserva.Name = "pnlDatosNuevaReserva";
            pnlDatosNuevaReserva.Padding = new Padding(20);
            pnlDatosNuevaReserva.Size = new Size(560, 237);
            pnlDatosNuevaReserva.TabIndex = 2;
            // 
            // tlpNuevaReserva
            // 
            tlpNuevaReserva.BackColor = Color.Transparent;
            tlpNuevaReserva.ColumnCount = 2;
            tlpNuevaReserva.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            tlpNuevaReserva.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 78F));
            tlpNuevaReserva.Controls.Add(lblCliente, 0, 0);
            tlpNuevaReserva.Controls.Add(lblFechaReserva, 0, 1);
            tlpNuevaReserva.Controls.Add(lblHoraReserva, 0, 2);
            tlpNuevaReserva.Controls.Add(lblPersonasReserva, 0, 3);
            tlpNuevaReserva.Controls.Add(lblMesaReserva, 0, 4);
            tlpNuevaReserva.Controls.Add(txtClienteReserva, 1, 0);
            tlpNuevaReserva.Controls.Add(dtpFechaNuevaReserva, 1, 1);
            tlpNuevaReserva.Controls.Add(dtpHoraNuevaReserva, 1, 2);
            tlpNuevaReserva.Controls.Add(nudPersonas, 1, 3);
            tlpNuevaReserva.Controls.Add(cmbMesaReserva, 1, 4);
            tlpNuevaReserva.Dock = DockStyle.Left;
            tlpNuevaReserva.Location = new Point(20, 20);
            tlpNuevaReserva.Name = "tlpNuevaReserva";
            tlpNuevaReserva.Padding = new Padding(10, 0, 0, 0);
            tlpNuevaReserva.RowCount = 5;
            tlpNuevaReserva.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpNuevaReserva.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpNuevaReserva.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpNuevaReserva.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpNuevaReserva.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpNuevaReserva.Size = new Size(519, 197);
            tlpNuevaReserva.TabIndex = 0;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Dock = DockStyle.Fill;
            lblCliente.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCliente.Location = new Point(13, 0);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(105, 39);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Cliente";
            lblCliente.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFechaReserva
            // 
            lblFechaReserva.AutoSize = true;
            lblFechaReserva.Dock = DockStyle.Fill;
            lblFechaReserva.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechaReserva.Location = new Point(13, 39);
            lblFechaReserva.Name = "lblFechaReserva";
            lblFechaReserva.Size = new Size(105, 39);
            lblFechaReserva.TabIndex = 2;
            lblFechaReserva.Text = "Fecha";
            lblFechaReserva.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHoraReserva
            // 
            lblHoraReserva.AutoSize = true;
            lblHoraReserva.Dock = DockStyle.Fill;
            lblHoraReserva.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHoraReserva.Location = new Point(13, 78);
            lblHoraReserva.Name = "lblHoraReserva";
            lblHoraReserva.Size = new Size(105, 39);
            lblHoraReserva.TabIndex = 3;
            lblHoraReserva.Text = "Hora";
            lblHoraReserva.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPersonasReserva
            // 
            lblPersonasReserva.AutoSize = true;
            lblPersonasReserva.Dock = DockStyle.Fill;
            lblPersonasReserva.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPersonasReserva.Location = new Point(13, 117);
            lblPersonasReserva.Name = "lblPersonasReserva";
            lblPersonasReserva.Size = new Size(105, 39);
            lblPersonasReserva.TabIndex = 7;
            lblPersonasReserva.Text = "Personas";
            lblPersonasReserva.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMesaReserva
            // 
            lblMesaReserva.AutoSize = true;
            lblMesaReserva.Dock = DockStyle.Top;
            lblMesaReserva.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMesaReserva.Location = new Point(13, 156);
            lblMesaReserva.Name = "lblMesaReserva";
            lblMesaReserva.Size = new Size(105, 23);
            lblMesaReserva.TabIndex = 9;
            lblMesaReserva.Text = "N° Mesa";
            lblMesaReserva.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtClienteReserva
            // 
            txtClienteReserva.BorderStyle = BorderStyle.FixedSingle;
            txtClienteReserva.Dock = DockStyle.Fill;
            txtClienteReserva.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtClienteReserva.Location = new Point(124, 3);
            txtClienteReserva.Name = "txtClienteReserva";
            txtClienteReserva.Size = new Size(392, 26);
            txtClienteReserva.TabIndex = 4;
            // 
            // dtpFechaNuevaReserva
            // 
            dtpFechaNuevaReserva.Dock = DockStyle.Fill;
            dtpFechaNuevaReserva.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaNuevaReserva.Format = DateTimePickerFormat.Short;
            dtpFechaNuevaReserva.Location = new Point(124, 42);
            dtpFechaNuevaReserva.Name = "dtpFechaNuevaReserva";
            dtpFechaNuevaReserva.RightToLeft = RightToLeft.Yes;
            dtpFechaNuevaReserva.Size = new Size(392, 26);
            dtpFechaNuevaReserva.TabIndex = 5;
            // 
            // dtpHoraNuevaReserva
            // 
            dtpHoraNuevaReserva.CustomFormat = "HH:mm ";
            dtpHoraNuevaReserva.Dock = DockStyle.Fill;
            dtpHoraNuevaReserva.DropDownAlign = LeftRightAlignment.Right;
            dtpHoraNuevaReserva.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpHoraNuevaReserva.Format = DateTimePickerFormat.Custom;
            dtpHoraNuevaReserva.Location = new Point(124, 81);
            dtpHoraNuevaReserva.Name = "dtpHoraNuevaReserva";
            dtpHoraNuevaReserva.ShowUpDown = true;
            dtpHoraNuevaReserva.Size = new Size(392, 26);
            dtpHoraNuevaReserva.TabIndex = 6;
            // 
            // nudPersonas
            // 
            nudPersonas.Dock = DockStyle.Fill;
            nudPersonas.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudPersonas.Location = new Point(124, 120);
            nudPersonas.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudPersonas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPersonas.Name = "nudPersonas";
            nudPersonas.Size = new Size(392, 26);
            nudPersonas.TabIndex = 8;
            nudPersonas.TextAlign = HorizontalAlignment.Center;
            nudPersonas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbMesaReserva
            // 
            cmbMesaReserva.Dock = DockStyle.Fill;
            cmbMesaReserva.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMesaReserva.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMesaReserva.FormattingEnabled = true;
            cmbMesaReserva.Location = new Point(124, 159);
            cmbMesaReserva.Name = "cmbMesaReserva";
            cmbMesaReserva.Size = new Size(392, 28);
            cmbMesaReserva.TabIndex = 10;
            // 
            // pnlAccionesNuevaReserva
            // 
            pnlAccionesNuevaReserva.BackColor = Color.White;
            pnlAccionesNuevaReserva.Controls.Add(tlpButtons);
            pnlAccionesNuevaReserva.Dock = DockStyle.Bottom;
            pnlAccionesNuevaReserva.ForeColor = Color.FromArgb(8, 31, 63);
            pnlAccionesNuevaReserva.Location = new Point(20, 305);
            pnlAccionesNuevaReserva.Name = "pnlAccionesNuevaReserva";
            pnlAccionesNuevaReserva.Padding = new Padding(0, 8, 15, 8);
            pnlAccionesNuevaReserva.Size = new Size(560, 68);
            pnlAccionesNuevaReserva.TabIndex = 1;
            // 
            // tlpButtons
            // 
            tlpButtons.ColumnCount = 2;
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tlpButtons.Controls.Add(btnCancelarNuevaReserva, 0, 0);
            tlpButtons.Controls.Add(btnGuardarNuevaReserva, 1, 0);
            tlpButtons.Dock = DockStyle.Right;
            tlpButtons.Location = new Point(245, 8);
            tlpButtons.Name = "tlpButtons";
            tlpButtons.RowCount = 1;
            tlpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpButtons.Size = new Size(300, 52);
            tlpButtons.TabIndex = 2;
            // 
            // btnCancelarNuevaReserva
            // 
            btnCancelarNuevaReserva.BackColor = Color.FromArgb(238, 243, 247);
            btnCancelarNuevaReserva.Cursor = Cursors.Hand;
            btnCancelarNuevaReserva.Dock = DockStyle.Fill;
            btnCancelarNuevaReserva.FlatAppearance.BorderSize = 0;
            btnCancelarNuevaReserva.FlatStyle = FlatStyle.Flat;
            btnCancelarNuevaReserva.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelarNuevaReserva.Location = new Point(3, 3);
            btnCancelarNuevaReserva.Name = "btnCancelarNuevaReserva";
            btnCancelarNuevaReserva.Size = new Size(129, 46);
            btnCancelarNuevaReserva.TabIndex = 0;
            btnCancelarNuevaReserva.Text = "CANCELAR";
            btnCancelarNuevaReserva.UseVisualStyleBackColor = false;
            btnCancelarNuevaReserva.Click += btnCancelarNuevaReserva_Click;
            // 
            // btnGuardarNuevaReserva
            // 
            btnGuardarNuevaReserva.BackColor = Color.FromArgb(8, 126, 164);
            btnGuardarNuevaReserva.Dock = DockStyle.Fill;
            btnGuardarNuevaReserva.FlatAppearance.BorderSize = 0;
            btnGuardarNuevaReserva.FlatStyle = FlatStyle.Flat;
            btnGuardarNuevaReserva.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarNuevaReserva.ForeColor = Color.White;
            btnGuardarNuevaReserva.Location = new Point(138, 3);
            btnGuardarNuevaReserva.Name = "btnGuardarNuevaReserva";
            btnGuardarNuevaReserva.Size = new Size(159, 46);
            btnGuardarNuevaReserva.TabIndex = 1;
            btnGuardarNuevaReserva.Text = "GUARDAR RESERVA";
            btnGuardarNuevaReserva.UseVisualStyleBackColor = false;
            btnGuardarNuevaReserva.Click += btnGuardarNuevaReserva_Click;
            // 
            // lblTituloNuevaReserva
            // 
            lblTituloNuevaReserva.Dock = DockStyle.Top;
            lblTituloNuevaReserva.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloNuevaReserva.ForeColor = Color.FromArgb(8, 31, 63);
            lblTituloNuevaReserva.Location = new Point(20, 20);
            lblTituloNuevaReserva.Margin = new Padding(3, 0, 3, 5);
            lblTituloNuevaReserva.Name = "lblTituloNuevaReserva";
            lblTituloNuevaReserva.Size = new Size(560, 48);
            lblTituloNuevaReserva.TabIndex = 0;
            lblTituloNuevaReserva.Text = "Nueva Reserva";
            lblTituloNuevaReserva.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmMesasReservas
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(tlpMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmMesasReservas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmMesasReservas";
            tlpMain.ResumeLayout(false);
            pnlMesas.ResumeLayout(false);
            pnlContenidoReservas.ResumeLayout(false);
            pnlReservas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            pnlAccionesReserva.ResumeLayout(false);
            tlpAsignacionMesa.ResumeLayout(false);
            tlpGestionReservas.ResumeLayout(false);
            pnlFiltrosReservas.ResumeLayout(false);
            tlpFiltrosReservas.ResumeLayout(false);
            pnlBuscarReserva.ResumeLayout(false);
            pnlSearchInput.ResumeLayout(false);
            pnlSearchInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSearchReserva).EndInit();
            pnlFechaReserva.ResumeLayout(false);
            pnlEstadoReserva.ResumeLayout(false);
            pnlNuevaReservaContainer.ResumeLayout(false);
            pnlNuevaReserva.ResumeLayout(false);
            pnlDatosNuevaReserva.ResumeLayout(false);
            tlpNuevaReserva.ResumeLayout(false);
            tlpNuevaReserva.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPersonas).EndInit();
            pnlAccionesNuevaReserva.ResumeLayout(false);
            tlpButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Panel pnlMesas;
        private Label lblTituloMesas;
        private Label lblSubtituloMesas;
        private FlowLayoutPanel flpMesas;
        private Panel pnlReservas;
        private Panel pnlFiltrosReservas;
        private Label lblSubtituloReservas;
        private Label lblTituloReservas;
        private TableLayoutPanel tlpFiltrosReservas;
        private Panel pnlBuscarReserva;
        private Panel pnlSearchInput;
        private Panel pnlLine;
        private TextBox txtBuscarReserva;
        private Label lblGhost;
        private PictureBox picSearchReserva;
        private Panel pnlFechaReserva;
        private Label label1;
        private DateTimePicker dtpFechaReserva;
        private Label lblScondGhost;
        private Panel pnlEstadoReserva;
        private Label lblThirdGhost;
        private ComboBox cmbEstadoReserva;
        private Label label2;
        private DataGridView dgvReservas;
        private Panel pnlAccionesReserva;
        private Button btnNuevaReserva;
        private Button btnEditarReserva;
        private Button btnAsignarMesa;
        private Button btnCancelarReserva;
        private TableLayoutPanel tlpGestionReservas;
        private TableLayoutPanel tlpAsignacionMesa;
        private Panel pnlNuevaReserva;
        private TableLayoutPanel tlpNuevaReserva;
        private Label lblTituloNuevaReserva;
        private Label lblCliente;
        private Label lblFechaReserva;
        private Label lblHoraReserva;
        private TextBox txtClienteReserva;
        private DateTimePicker dtpFechaNuevaReserva;
        private DateTimePicker dtpHoraNuevaReserva;
        private Label lblMesaReserva;
        private ComboBox cmbMesaReserva;
        private Label lblPersonasReserva;
        private NumericUpDown nudPersonas;
        private Panel pnlAccionesNuevaReserva;
        private Button btnGuardarNuevaReserva;
        private Button btnCancelarNuevaReserva;
        private Panel pnlContenidoReservas;
        private TableLayoutPanel tlpButtons;
        private Panel pnlDatosNuevaReserva;
        private Panel pnlNuevaReservaContainer;
        private DataGridViewTextBoxColumn colReservaCliente;
        private DataGridViewTextBoxColumn colReservaFecha;
        private DataGridViewTextBoxColumn colReservaHora;
        private DataGridViewTextBoxColumn colReservaPersonas;
        private DataGridViewTextBoxColumn colReservaMesa;
        private DataGridViewTextBoxColumn colReservaEstado;
    }
}