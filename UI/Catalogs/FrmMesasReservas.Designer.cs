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
            tlpMain.SuspendLayout();
            pnlMesas.SuspendLayout();
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
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(pnlMesas, 0, 0);
            tlpMain.Controls.Add(pnlReservas, 0, 1);
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
            // pnlReservas
            // 
            pnlReservas.BackColor = Color.White;
            pnlReservas.Controls.Add(dgvReservas);
            pnlReservas.Controls.Add(pnlAccionesReserva);
            pnlReservas.Controls.Add(pnlFiltrosReservas);
            pnlReservas.Controls.Add(lblSubtituloReservas);
            pnlReservas.Controls.Add(lblTituloReservas);
            pnlReservas.Dock = DockStyle.Fill;
            pnlReservas.Location = new Point(0, 332);
            pnlReservas.Margin = new Padding(0);
            pnlReservas.Name = "pnlReservas";
            pnlReservas.Padding = new Padding(15, 10, 15, 10);
            pnlReservas.Size = new Size(940, 498);
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
            dgvReservas.Size = new Size(910, 308);
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
            pnlAccionesReserva.Location = new Point(15, 428);
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
        private DataGridViewTextBoxColumn colReservaCliente;
        private DataGridViewTextBoxColumn colReservaFecha;
        private DataGridViewTextBoxColumn colReservaHora;
        private DataGridViewTextBoxColumn colReservaPersonas;
        private DataGridViewTextBoxColumn colReservaMesa;
        private DataGridViewTextBoxColumn colReservaEstado;
    }
}