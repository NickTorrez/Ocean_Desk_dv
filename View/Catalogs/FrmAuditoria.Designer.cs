namespace Ocean_Desk_dv.UI.Catalogs
{
    partial class FrmAuditoria
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
            DataGridViewCellStyle stAlterno = new DataGridViewCellStyle();
            DataGridViewCellStyle stEncabezado = new DataGridViewCellStyle();
            DataGridViewCellStyle stCelda = new DataGridViewCellStyle();
            DataGridViewCellStyle stFilas = new DataGridViewCellStyle();
            DataGridViewCellStyle stCentro = new DataGridViewCellStyle();
            DataGridViewCellStyle stFecha = new DataGridViewCellStyle();
            pnlGrid = new Panel();
            dgvAuditoria = new DataGridView();
            colAuditId = new DataGridViewTextBoxColumn();
            colFechaHora = new DataGridViewTextBoxColumn();
            colUsuario = new DataGridViewTextBoxColumn();
            colModulo = new DataGridViewTextBoxColumn();
            colAccion = new DataGridViewTextBoxColumn();
            colRegistro = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            lblTotalRegistros = new Label();
            pnlDetalle = new Panel();
            tlpDetalle = new TableLayoutPanel();
            lblAnteriores = new Label();
            lblNuevos = new Label();
            txtAnteriores = new TextBox();
            txtNuevos = new TextBox();
            lblInfoEvento = new Label();
            lblTituloDetalle = new Label();
            pnlFiltros = new Panel();
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            lblModulo = new Label();
            cmbModulo = new ComboBox();
            lblAccion = new Label();
            cmbAccion = new ComboBox();
            lblUsuario = new Label();
            cmbUsuario = new ComboBox();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnFiltrar = new Button();
            btnLimpiar = new Button();
            btnVerDetalle = new Button();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditoria).BeginInit();
            pnlDetalle.SuspendLayout();
            tlpDetalle.SuspendLayout();
            pnlFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // pnlGrid
            // 
            pnlGrid.BackColor = Color.Transparent;
            pnlGrid.Controls.Add(dgvAuditoria);
            pnlGrid.Controls.Add(lblTotalRegistros);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(0, 124);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Padding = new Padding(3, 10, 3, 4);
            pnlGrid.Size = new Size(940, 706);
            pnlGrid.TabIndex = 0;
            // 
            // dgvAuditoria
            // 
            dgvAuditoria.AllowUserToAddRows = false;
            dgvAuditoria.AllowUserToDeleteRows = false;
            dgvAuditoria.AllowUserToOrderColumns = false;
            dgvAuditoria.AllowUserToResizeRows = false;
            stAlterno.BackColor = Color.FromArgb(248, 250, 252);
            stAlterno.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stAlterno.ForeColor = Color.FromArgb(8, 31, 63);
            stAlterno.SelectionBackColor = Color.LightCyan;
            stAlterno.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dgvAuditoria.AlternatingRowsDefaultCellStyle = stAlterno;
            dgvAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditoria.BackgroundColor = Color.White;
            dgvAuditoria.BorderStyle = BorderStyle.None;
            dgvAuditoria.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            stEncabezado.Alignment = DataGridViewContentAlignment.MiddleLeft;
            stEncabezado.BackColor = Color.FromArgb(8, 31, 63);
            stEncabezado.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stEncabezado.ForeColor = Color.White;
            stEncabezado.Padding = new Padding(6, 0, 0, 0);
            stEncabezado.SelectionBackColor = Color.FromArgb(8, 31, 63);
            stEncabezado.SelectionForeColor = Color.White;
            stEncabezado.WrapMode = DataGridViewTriState.True;
            dgvAuditoria.ColumnHeadersDefaultCellStyle = stEncabezado;
            dgvAuditoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditoria.Columns.AddRange(new DataGridViewColumn[] { colAuditId, colFechaHora, colUsuario, colModulo, colAccion, colRegistro, colDescripcion });
            stCelda.Alignment = DataGridViewContentAlignment.MiddleLeft;
            stCelda.BackColor = Color.White;
            stCelda.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stCelda.ForeColor = Color.FromArgb(8, 31, 63);
            stCelda.SelectionBackColor = Color.FromArgb(224, 234, 240);
            stCelda.SelectionForeColor = Color.FromArgb(8, 31, 63);
            stCelda.WrapMode = DataGridViewTriState.False;
            dgvAuditoria.DefaultCellStyle = stCelda;
            dgvAuditoria.Dock = DockStyle.Fill;
            dgvAuditoria.EnableHeadersVisualStyles = false;
            dgvAuditoria.GridColor = Color.FromArgb(230, 234, 238);
            dgvAuditoria.Location = new Point(3, 10);
            dgvAuditoria.MultiSelect = false;
            dgvAuditoria.Name = "dgvAuditoria";
            dgvAuditoria.ReadOnly = true;
            dgvAuditoria.RowHeadersVisible = false;
            dgvAuditoria.RowHeadersWidth = 51;
            stFilas.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvAuditoria.RowsDefaultCellStyle = stFilas;
            dgvAuditoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditoria.Size = new Size(934, 668);
            dgvAuditoria.TabIndex = 0;
            dgvAuditoria.CellFormatting += dgvAuditoria_CellFormatting;
            dgvAuditoria.SelectionChanged += dgvAuditoria_SelectionChanged;
            // 
            // colAuditId
            // 
            colAuditId.DataPropertyName = "AuditId";
            stCentro.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colAuditId.DefaultCellStyle = stCentro;
            colAuditId.FillWeight = 7F;
            colAuditId.HeaderText = "ID";
            colAuditId.MinimumWidth = 6;
            colAuditId.Name = "colAuditId";
            colAuditId.ReadOnly = true;
            // 
            // colFechaHora
            // 
            colFechaHora.DataPropertyName = "FechaHora";
            stFecha.Alignment = DataGridViewContentAlignment.MiddleCenter;
            stFecha.Format = "dd/MM/yyyy HH:mm:ss";
            stFecha.NullValue = null;
            colFechaHora.DefaultCellStyle = stFecha;
            colFechaHora.FillWeight = 17F;
            colFechaHora.HeaderText = "Fecha y hora";
            colFechaHora.MinimumWidth = 6;
            colFechaHora.Name = "colFechaHora";
            colFechaHora.ReadOnly = true;
            // 
            // colUsuario
            // 
            colUsuario.DataPropertyName = "Usuario";
            colUsuario.FillWeight = 14F;
            colUsuario.HeaderText = "Usuario";
            colUsuario.MinimumWidth = 6;
            colUsuario.Name = "colUsuario";
            colUsuario.ReadOnly = true;
            // 
            // colModulo
            // 
            colModulo.DataPropertyName = "Modulo";
            colModulo.FillWeight = 15F;
            colModulo.HeaderText = "Módulo";
            colModulo.MinimumWidth = 6;
            colModulo.Name = "colModulo";
            colModulo.ReadOnly = true;
            // 
            // colAccion
            // 
            colAccion.DataPropertyName = "Accion";
            colAccion.DefaultCellStyle = stCentro;
            colAccion.FillWeight = 13F;
            colAccion.HeaderText = "Acción";
            colAccion.MinimumWidth = 6;
            colAccion.Name = "colAccion";
            colAccion.ReadOnly = true;
            // 
            // colRegistro
            // 
            colRegistro.DataPropertyName = "RegistroId";
            colRegistro.DefaultCellStyle = stCentro;
            colRegistro.FillWeight = 9F;
            colRegistro.HeaderText = "Registro";
            colRegistro.MinimumWidth = 6;
            colRegistro.Name = "colRegistro";
            colRegistro.ReadOnly = true;
            // 
            // colDescripcion
            // 
            colDescripcion.DataPropertyName = "Descripcion";
            colDescripcion.FillWeight = 25F;
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.MinimumWidth = 6;
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            // 
            // lblTotalRegistros
            // 
            lblTotalRegistros.Dock = DockStyle.Bottom;
            lblTotalRegistros.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalRegistros.ForeColor = Color.FromArgb(111, 119, 128);
            lblTotalRegistros.Location = new Point(3, 678);
            lblTotalRegistros.Name = "lblTotalRegistros";
            lblTotalRegistros.Size = new Size(934, 24);
            lblTotalRegistros.TabIndex = 1;
            lblTotalRegistros.Text = "0 registros";
            lblTotalRegistros.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlDetalle
            // 
            pnlDetalle.BackColor = Color.White;
            pnlDetalle.Controls.Add(tlpDetalle);
            pnlDetalle.Controls.Add(lblInfoEvento);
            pnlDetalle.Controls.Add(lblTituloDetalle);
            pnlDetalle.Dock = DockStyle.Bottom;
            pnlDetalle.Location = new Point(0, 630);
            pnlDetalle.Name = "pnlDetalle";
            pnlDetalle.Padding = new Padding(15, 10, 15, 10);
            pnlDetalle.Size = new Size(940, 200);
            pnlDetalle.TabIndex = 1;
            pnlDetalle.Visible = false;
            // 
            // tlpDetalle
            // 
            tlpDetalle.ColumnCount = 2;
            tlpDetalle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDetalle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpDetalle.Controls.Add(lblAnteriores, 0, 0);
            tlpDetalle.Controls.Add(lblNuevos, 1, 0);
            tlpDetalle.Controls.Add(txtAnteriores, 0, 1);
            tlpDetalle.Controls.Add(txtNuevos, 1, 1);
            tlpDetalle.Dock = DockStyle.Fill;
            tlpDetalle.Location = new Point(15, 72);
            tlpDetalle.Margin = new Padding(0);
            tlpDetalle.Name = "tlpDetalle";
            tlpDetalle.RowCount = 2;
            tlpDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlpDetalle.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpDetalle.Size = new Size(910, 118);
            tlpDetalle.TabIndex = 2;
            // 
            // lblAnteriores
            // 
            lblAnteriores.Dock = DockStyle.Fill;
            lblAnteriores.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAnteriores.ForeColor = Color.FromArgb(111, 119, 128);
            lblAnteriores.Margin = new Padding(0);
            lblAnteriores.Name = "lblAnteriores";
            lblAnteriores.Size = new Size(455, 22);
            lblAnteriores.TabIndex = 0;
            lblAnteriores.Text = "Valores anteriores";
            lblAnteriores.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNuevos
            // 
            lblNuevos.Dock = DockStyle.Fill;
            lblNuevos.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNuevos.ForeColor = Color.FromArgb(111, 119, 128);
            lblNuevos.Margin = new Padding(0);
            lblNuevos.Name = "lblNuevos";
            lblNuevos.Size = new Size(455, 22);
            lblNuevos.TabIndex = 1;
            lblNuevos.Text = "Valores nuevos";
            lblNuevos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtAnteriores
            // 
            txtAnteriores.BackColor = Color.FromArgb(248, 250, 252);
            txtAnteriores.BorderStyle = BorderStyle.FixedSingle;
            txtAnteriores.Dock = DockStyle.Fill;
            txtAnteriores.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAnteriores.ForeColor = Color.FromArgb(8, 31, 63);
            txtAnteriores.Margin = new Padding(0, 0, 5, 0);
            txtAnteriores.Multiline = true;
            txtAnteriores.Name = "txtAnteriores";
            txtAnteriores.ReadOnly = true;
            txtAnteriores.ScrollBars = ScrollBars.Vertical;
            txtAnteriores.Size = new Size(450, 96);
            txtAnteriores.TabIndex = 2;
            // 
            // txtNuevos
            // 
            txtNuevos.BackColor = Color.FromArgb(248, 250, 252);
            txtNuevos.BorderStyle = BorderStyle.FixedSingle;
            txtNuevos.Dock = DockStyle.Fill;
            txtNuevos.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNuevos.ForeColor = Color.FromArgb(8, 31, 63);
            txtNuevos.Margin = new Padding(5, 0, 0, 0);
            txtNuevos.Multiline = true;
            txtNuevos.Name = "txtNuevos";
            txtNuevos.ReadOnly = true;
            txtNuevos.ScrollBars = ScrollBars.Vertical;
            txtNuevos.Size = new Size(450, 96);
            txtNuevos.TabIndex = 3;
            // 
            // lblInfoEvento
            // 
            lblInfoEvento.Dock = DockStyle.Top;
            lblInfoEvento.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoEvento.ForeColor = Color.FromArgb(8, 126, 164);
            lblInfoEvento.Location = new Point(15, 48);
            lblInfoEvento.Name = "lblInfoEvento";
            lblInfoEvento.Size = new Size(910, 24);
            lblInfoEvento.TabIndex = 1;
            lblInfoEvento.Text = "-";
            lblInfoEvento.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTituloDetalle
            // 
            lblTituloDetalle.Dock = DockStyle.Top;
            lblTituloDetalle.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloDetalle.ForeColor = Color.FromArgb(8, 31, 63);
            lblTituloDetalle.Location = new Point(15, 10);
            lblTituloDetalle.Name = "lblTituloDetalle";
            lblTituloDetalle.Size = new Size(910, 38);
            lblTituloDetalle.TabIndex = 0;
            lblTituloDetalle.Text = "Detalle del evento (solo lectura)";
            lblTituloDetalle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlFiltros
            // 
            pnlFiltros.BackColor = Color.White;
            pnlFiltros.Controls.Add(lblDesde);
            pnlFiltros.Controls.Add(dtpDesde);
            pnlFiltros.Controls.Add(lblHasta);
            pnlFiltros.Controls.Add(dtpHasta);
            pnlFiltros.Controls.Add(lblModulo);
            pnlFiltros.Controls.Add(cmbModulo);
            pnlFiltros.Controls.Add(lblAccion);
            pnlFiltros.Controls.Add(cmbAccion);
            pnlFiltros.Controls.Add(lblUsuario);
            pnlFiltros.Controls.Add(cmbUsuario);
            pnlFiltros.Controls.Add(lblBuscar);
            pnlFiltros.Controls.Add(txtBuscar);
            pnlFiltros.Controls.Add(btnFiltrar);
            pnlFiltros.Controls.Add(btnLimpiar);
            pnlFiltros.Controls.Add(btnVerDetalle);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 0);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(15, 10, 15, 10);
            pnlFiltros.Size = new Size(940, 124);
            pnlFiltros.TabIndex = 2;
            // 
            // lblDesde
            // 
            lblDesde.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDesde.ForeColor = Color.FromArgb(111, 119, 128);
            lblDesde.Location = new Point(15, 8);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(140, 20);
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde";
            // 
            // dtpDesde
            // 
            dtpDesde.CalendarForeColor = Color.FromArgb(8, 31, 63);
            dtpDesde.Checked = false;
            dtpDesde.CustomFormat = "dd/MM/yyyy";
            dtpDesde.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDesde.Format = DateTimePickerFormat.Custom;
            dtpDesde.Location = new Point(15, 28);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.ShowCheckBox = true;
            dtpDesde.Size = new Size(140, 26);
            dtpDesde.TabIndex = 0;
            // 
            // lblHasta
            // 
            lblHasta.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHasta.ForeColor = Color.FromArgb(111, 119, 128);
            lblHasta.Location = new Point(165, 8);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(140, 20);
            lblHasta.TabIndex = 2;
            lblHasta.Text = "Hasta";
            // 
            // dtpHasta
            // 
            dtpHasta.CalendarForeColor = Color.FromArgb(8, 31, 63);
            dtpHasta.Checked = false;
            dtpHasta.CustomFormat = "dd/MM/yyyy";
            dtpHasta.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpHasta.Format = DateTimePickerFormat.Custom;
            dtpHasta.Location = new Point(165, 28);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.ShowCheckBox = true;
            dtpHasta.Size = new Size(140, 26);
            dtpHasta.TabIndex = 1;
            // 
            // lblModulo
            // 
            lblModulo.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblModulo.ForeColor = Color.FromArgb(111, 119, 128);
            lblModulo.Location = new Point(315, 8);
            lblModulo.Name = "lblModulo";
            lblModulo.Size = new Size(180, 20);
            lblModulo.TabIndex = 4;
            lblModulo.Text = "Módulo";
            // 
            // cmbModulo
            // 
            cmbModulo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModulo.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbModulo.FormattingEnabled = true;
            cmbModulo.Location = new Point(315, 28);
            cmbModulo.Name = "cmbModulo";
            cmbModulo.Size = new Size(180, 28);
            cmbModulo.TabIndex = 2;
            // 
            // lblAccion
            // 
            lblAccion.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAccion.ForeColor = Color.FromArgb(111, 119, 128);
            lblAccion.Location = new Point(505, 8);
            lblAccion.Name = "lblAccion";
            lblAccion.Size = new Size(140, 20);
            lblAccion.TabIndex = 6;
            lblAccion.Text = "Acción";
            // 
            // cmbAccion
            // 
            cmbAccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccion.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbAccion.FormattingEnabled = true;
            cmbAccion.Location = new Point(505, 28);
            cmbAccion.Name = "cmbAccion";
            cmbAccion.Size = new Size(140, 28);
            cmbAccion.TabIndex = 3;
            // 
            // lblUsuario
            // 
            lblUsuario.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.FromArgb(111, 119, 128);
            lblUsuario.Location = new Point(655, 8);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(270, 20);
            lblUsuario.TabIndex = 8;
            lblUsuario.Text = "Usuario";
            // 
            // cmbUsuario
            // 
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbUsuario.FormattingEnabled = true;
            cmbUsuario.Location = new Point(655, 28);
            cmbUsuario.Name = "cmbUsuario";
            cmbUsuario.Size = new Size(270, 28);
            cmbUsuario.TabIndex = 4;
            // 
            // lblBuscar
            // 
            lblBuscar.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBuscar.ForeColor = Color.FromArgb(111, 119, 128);
            lblBuscar.Location = new Point(15, 62);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(490, 20);
            lblBuscar.TabIndex = 10;
            lblBuscar.Text = "Buscar (ID, registro, módulo, usuario o texto)";
            // 
            // txtBuscar
            // 
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.ForeColor = Color.FromArgb(8, 31, 63);
            txtBuscar.Location = new Point(15, 84);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(490, 26);
            txtBuscar.TabIndex = 5;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.FromArgb(8, 126, 164);
            btnFiltrar.Cursor = Cursors.Hand;
            btnFiltrar.FlatAppearance.BorderSize = 0;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(515, 76);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(130, 38);
            btnFiltrar.TabIndex = 6;
            btnFiltrar.Text = "FILTRAR";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(238, 243, 247);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = Color.FromArgb(8, 31, 63);
            btnLimpiar.Location = new Point(655, 76);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(130, 38);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.BackColor = Color.LightSkyBlue;
            btnVerDetalle.Cursor = Cursors.Hand;
            btnVerDetalle.Enabled = false;
            btnVerDetalle.FlatAppearance.BorderSize = 0;
            btnVerDetalle.FlatStyle = FlatStyle.Flat;
            btnVerDetalle.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerDetalle.ForeColor = Color.FromArgb(8, 31, 63);
            btnVerDetalle.Location = new Point(795, 76);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(130, 38);
            btnVerDetalle.TabIndex = 8;
            btnVerDetalle.Text = "VER DETALLE";
            btnVerDetalle.UseVisualStyleBackColor = false;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // FrmAuditoria
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(pnlGrid);
            Controls.Add(pnlDetalle);
            Controls.Add(pnlFiltros);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmAuditoria";
            Text = "FrmAuditoria";
            FormClosed += FrmAuditoria_FormClosed;
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAuditoria).EndInit();
            pnlDetalle.ResumeLayout(false);
            tlpDetalle.ResumeLayout(false);
            tlpDetalle.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlGrid;
        private DataGridView dgvAuditoria;
        private DataGridViewTextBoxColumn colAuditId;
        private DataGridViewTextBoxColumn colFechaHora;
        private DataGridViewTextBoxColumn colUsuario;
        private DataGridViewTextBoxColumn colModulo;
        private DataGridViewTextBoxColumn colAccion;
        private DataGridViewTextBoxColumn colRegistro;
        private DataGridViewTextBoxColumn colDescripcion;
        private Label lblTotalRegistros;
        private Panel pnlDetalle;
        private TableLayoutPanel tlpDetalle;
        private Label lblAnteriores;
        private Label lblNuevos;
        private TextBox txtAnteriores;
        private TextBox txtNuevos;
        private Label lblInfoEvento;
        private Label lblTituloDetalle;
        private Panel pnlFiltros;
        private Label lblDesde;
        private DateTimePicker dtpDesde;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Label lblModulo;
        private ComboBox cmbModulo;
        private Label lblAccion;
        private ComboBox cmbAccion;
        private Label lblUsuario;
        private ComboBox cmbUsuario;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnFiltrar;
        private Button btnLimpiar;
        private Button btnVerDetalle;
    }
}
