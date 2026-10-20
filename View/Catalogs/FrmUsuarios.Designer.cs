namespace Ocean_Desk_dv.View.Catalogs
{
    partial class FrmUsuarios
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            splitUsuarios = new SplitContainer();
            pnlEditor = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel10 = new Panel();
            btnGuardar = new Button();
            panel11 = new Panel();
            btnCancelar = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel5 = new Panel();
            lblNombreUsuario = new Label();
            panel4 = new Panel();
            txtNombreCompleto = new TextBox();
            panel3 = new Panel();
            lblNombreCompleto = new Label();
            panel6 = new Panel();
            txtNombreUsuario = new TextBox();
            panel7 = new Panel();
            lblRol = new Label();
            panel8 = new Panel();
            cmbRol = new ComboBox();
            panel9 = new Panel();
            chkActivo = new CheckBox();
            pnlGrid = new Panel();
            dgvUsuarios = new DataGridView();
            colUsuarioId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colNombreUsuario = new DataGridViewTextBoxColumn();
            colRol = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colUltimoAcceso = new DataGridViewTextBoxColumn();
            pnlToolbar = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnRestablecer = new Button();
            btnCambiarEstado = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            panel1 = new Panel();
            cmbFiltroEstado = new ComboBox();
            panel2 = new Panel();
            txtBuscar = new TextBox();
            pnlHeader = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            tlpRoot = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitUsuarios).BeginInit();
            splitUsuarios.Panel1.SuspendLayout();
            splitUsuarios.Panel2.SuspendLayout();
            splitUsuarios.SuspendLayout();
            pnlEditor.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            pnlToolbar.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            pnlHeader.SuspendLayout();
            tlpRoot.SuspendLayout();
            SuspendLayout();
            // 
            // splitUsuarios
            // 
            splitUsuarios.Dock = DockStyle.Fill;
            splitUsuarios.Location = new Point(11, 136);
            splitUsuarios.Name = "splitUsuarios";
            // 
            // splitUsuarios.Panel1
            // 
            splitUsuarios.Panel1.Controls.Add(pnlEditor);
            splitUsuarios.Panel1.Paint += splitContainer1_Panel1_Paint_1;
            // 
            // splitUsuarios.Panel2
            // 
            splitUsuarios.Panel2.Controls.Add(pnlGrid);
            splitUsuarios.Size = new Size(918, 683);
            splitUsuarios.SplitterDistance = 369;
            splitUsuarios.TabIndex = 2;
            // 
            // pnlEditor
            // 
            pnlEditor.BackColor = Color.White;
            pnlEditor.Controls.Add(tableLayoutPanel3);
            pnlEditor.Controls.Add(tableLayoutPanel2);
            pnlEditor.Dock = DockStyle.Fill;
            pnlEditor.Location = new Point(0, 0);
            pnlEditor.Name = "pnlEditor";
            pnlEditor.Padding = new Padding(14);
            pnlEditor.Size = new Size(369, 683);
            pnlEditor.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(panel10, 0, 0);
            tableLayoutPanel3.Controls.Add(panel11, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Bottom;
            tableLayoutPanel3.Location = new Point(14, 544);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(341, 125);
            tableLayoutPanel3.TabIndex = 10;
            // 
            // panel10
            // 
            panel10.Controls.Add(btnGuardar);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(3, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(164, 119);
            panel10.TabIndex = 0;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(8, 126, 164);
            btnGuardar.Dock = DockStyle.Fill;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(0, 0);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(164, 119);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // panel11
            // 
            panel11.Controls.Add(btnCancelar);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(173, 3);
            panel11.Name = "panel11";
            panel11.Size = new Size(165, 119);
            panel11.TabIndex = 1;
            // 
            // btnCancelar
            // 
            btnCancelar.Dock = DockStyle.Fill;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.FromArgb(8, 31, 63);
            btnCancelar.Location = new Point(0, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(165, 119);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(panel5, 0, 2);
            tableLayoutPanel2.Controls.Add(panel4, 0, 1);
            tableLayoutPanel2.Controls.Add(panel3, 0, 0);
            tableLayoutPanel2.Controls.Add(panel6, 0, 3);
            tableLayoutPanel2.Controls.Add(panel7, 0, 4);
            tableLayoutPanel2.Controls.Add(panel8, 0, 5);
            tableLayoutPanel2.Controls.Add(panel9, 0, 6);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(14, 14);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 13.1111107F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 15.333333F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel2.Size = new Size(341, 524);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // panel5
            // 
            panel5.Controls.Add(lblNombreUsuario);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 151);
            panel5.Name = "panel5";
            panel5.Size = new Size(335, 68);
            panel5.TabIndex = 7;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.Dock = DockStyle.Fill;
            lblNombreUsuario.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreUsuario.Location = new Point(0, 0);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(335, 68);
            lblNombreUsuario.TabIndex = 1;
            lblNombreUsuario.Text = "Nombre de Usuario";
            lblNombreUsuario.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            panel4.Controls.Add(txtNombreCompleto);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 71);
            panel4.Name = "panel4";
            panel4.Size = new Size(335, 74);
            panel4.TabIndex = 7;
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Dock = DockStyle.Fill;
            txtNombreCompleto.Location = new Point(0, 0);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(335, 27);
            txtNombreCompleto.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblNombreCompleto);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(335, 62);
            panel3.TabIndex = 9;
            // 
            // lblNombreCompleto
            // 
            lblNombreCompleto.Dock = DockStyle.Fill;
            lblNombreCompleto.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreCompleto.ForeColor = Color.Black;
            lblNombreCompleto.Location = new Point(0, 0);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new Size(335, 62);
            lblNombreCompleto.TabIndex = 0;
            lblNombreCompleto.Text = "Nombre Completo";
            lblNombreCompleto.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            panel6.Controls.Add(txtNombreUsuario);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 225);
            panel6.Name = "panel6";
            panel6.Size = new Size(335, 68);
            panel6.TabIndex = 10;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Dock = DockStyle.Fill;
            txtNombreUsuario.Location = new Point(0, 0);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(335, 27);
            txtNombreUsuario.TabIndex = 8;
            // 
            // panel7
            // 
            panel7.Controls.Add(lblRol);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(3, 299);
            panel7.Name = "panel7";
            panel7.Size = new Size(335, 68);
            panel7.TabIndex = 11;
            // 
            // lblRol
            // 
            lblRol.Dock = DockStyle.Fill;
            lblRol.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRol.Location = new Point(0, 0);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(335, 68);
            lblRol.TabIndex = 2;
            lblRol.Text = "Rol Asignado";
            lblRol.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            panel8.Controls.Add(cmbRol);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(3, 373);
            panel8.Name = "panel8";
            panel8.Size = new Size(335, 68);
            panel8.TabIndex = 12;
            // 
            // cmbRol
            // 
            cmbRol.Dock = DockStyle.Fill;
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(0, 0);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(335, 28);
            cmbRol.TabIndex = 3;
            // 
            // panel9
            // 
            panel9.Controls.Add(chkActivo);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(3, 447);
            panel9.Name = "panel9";
            panel9.Size = new Size(335, 74);
            panel9.TabIndex = 13;
            // 
            // chkActivo
            // 
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Dock = DockStyle.Fill;
            chkActivo.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkActivo.Location = new Point(0, 0);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(335, 74);
            chkActivo.TabIndex = 4;
            chkActivo.Text = "Cuenta Activa";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // pnlGrid
            // 
            pnlGrid.BackColor = Color.White;
            pnlGrid.Controls.Add(dgvUsuarios);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(0, 0);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(545, 683);
            pnlGrid.TabIndex = 0;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 246, 250);
            dgvUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { colUsuarioId, colNombre, colNombreUsuario, colRol, colEstado, colUltimoAcceso });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(217, 243, 246);
            dataGridViewCellStyle5.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(18, 53, 107);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(217, 243, 246);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(18, 53, 107);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle5;
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.GridColor = Color.FromArgb(227, 234, 241);
            dgvUsuarios.Location = new Point(0, 0);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(545, 683);
            dgvUsuarios.TabIndex = 0;
            // 
            // colUsuarioId
            // 
            colUsuarioId.DataPropertyName = "UserId";
            colUsuarioId.HeaderText = "ID";
            colUsuarioId.MinimumWidth = 6;
            colUsuarioId.Name = "colUsuarioId";
            colUsuarioId.ReadOnly = true;
            colUsuarioId.Visible = false;
            colUsuarioId.Width = 70;
            // 
            // colNombre
            // 
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNombre.DataPropertyName = "FullName";
            colNombre.FillWeight = 180F;
            colNombre.HeaderText = "Nombre Completo";
            colNombre.MinimumWidth = 6;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colNombreUsuario
            // 
            colNombreUsuario.DataPropertyName = "UserName";
            colNombreUsuario.HeaderText = "Usuario";
            colNombreUsuario.MinimumWidth = 6;
            colNombreUsuario.Name = "colNombreUsuario";
            colNombreUsuario.ReadOnly = true;
            colNombreUsuario.Width = 140;
            // 
            // colRol
            // 
            colRol.DataPropertyName = "RoleName";
            colRol.HeaderText = "Rol";
            colRol.MinimumWidth = 6;
            colRol.Name = "colRol";
            colRol.ReadOnly = true;
            colRol.Width = 140;
            // 
            // colEstado
            // 
            colEstado.DataPropertyName = "StatusText";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEstado.DefaultCellStyle = dataGridViewCellStyle3;
            colEstado.HeaderText = "Estado";
            colEstado.MinimumWidth = 6;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            colEstado.Width = 125;
            // 
            // colUltimoAcceso
            // 
            colUltimoAcceso.DataPropertyName = "LastAccess";
            dataGridViewCellStyle4.Format = "g";
            dataGridViewCellStyle4.NullValue = null;
            colUltimoAcceso.DefaultCellStyle = dataGridViewCellStyle4;
            colUltimoAcceso.HeaderText = "Último Acceso";
            colUltimoAcceso.MinimumWidth = 6;
            colUltimoAcceso.Name = "colUltimoAcceso";
            colUltimoAcceso.ReadOnly = true;
            colUltimoAcceso.Width = 150;
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.White;
            pnlToolbar.Controls.Add(tableLayoutPanel1);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(11, 74);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Padding = new Padding(5);
            pnlToolbar.Size = new Size(918, 56);
            pnlToolbar.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.0769234F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.3846149F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.3846149F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.3846149F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.3846149F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.3846149F));
            tableLayoutPanel1.Controls.Add(btnRestablecer, 5, 0);
            tableLayoutPanel1.Controls.Add(btnCambiarEstado, 4, 0);
            tableLayoutPanel1.Controls.Add(btnEditar, 3, 0);
            tableLayoutPanel1.Controls.Add(btnNuevo, 2, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(5, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(908, 46);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnRestablecer
            // 
            btnRestablecer.Dock = DockStyle.Fill;
            btnRestablecer.FlatStyle = FlatStyle.Flat;
            btnRestablecer.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRestablecer.ForeColor = Color.Black;
            btnRestablecer.Location = new Point(768, 3);
            btnRestablecer.Name = "btnRestablecer";
            btnRestablecer.Size = new Size(137, 40);
            btnRestablecer.TabIndex = 5;
            btnRestablecer.Text = "Restablecer acceso";
            btnRestablecer.UseVisualStyleBackColor = true;
            // 
            // btnCambiarEstado
            // 
            btnCambiarEstado.BackColor = Color.FromArgb(217, 119, 6);
            btnCambiarEstado.Dock = DockStyle.Fill;
            btnCambiarEstado.FlatStyle = FlatStyle.Flat;
            btnCambiarEstado.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCambiarEstado.ForeColor = Color.White;
            btnCambiarEstado.Location = new Point(629, 3);
            btnCambiarEstado.Name = "btnCambiarEstado";
            btnCambiarEstado.Size = new Size(133, 40);
            btnCambiarEstado.TabIndex = 4;
            btnCambiarEstado.Text = "Activar / Desactivar";
            btnCambiarEstado.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.CadetBlue;
            btnEditar.Dock = DockStyle.Fill;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(490, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(133, 40);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(8, 126, 164);
            btnNuevo.Dock = DockStyle.Fill;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(351, 3);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(133, 40);
            btnNuevo.TabIndex = 2;
            btnNuevo.Text = "+ Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbFiltroEstado);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(212, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 5, 0, 0);
            panel1.Size = new Size(133, 40);
            panel1.TabIndex = 6;
            // 
            // cmbFiltroEstado
            // 
            cmbFiltroEstado.Dock = DockStyle.Fill;
            cmbFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroEstado.FormattingEnabled = true;
            cmbFiltroEstado.Items.AddRange(new object[] { "Todos", "Activos ", "Inactivos" });
            cmbFiltroEstado.Location = new Point(0, 5);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.Size = new Size(133, 28);
            cmbFiltroEstado.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtBuscar);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 5, 0, 0);
            panel2.Size = new Size(203, 40);
            panel2.TabIndex = 7;
            // 
            // txtBuscar
            // 
            txtBuscar.Dock = DockStyle.Fill;
            txtBuscar.Font = new Font("Century Gothic", 10.2F);
            txtBuscar.Location = new Point(0, 5);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por nombre o usuario...";
            txtBuscar.Size = new Size(203, 28);
            txtBuscar.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Location = new Point(11, 11);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(918, 57);
            pnlHeader.TabIndex = 0;
            pnlHeader.Paint += pnlHeader_Paint;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Dock = DockStyle.Top;
            lblSubtitulo.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = Color.FromArgb(101, 116, 139);
            lblSubtitulo.Location = new Point(0, 37);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(328, 18);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Gestiona cuentas, roles y acceso al sistema";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(18, 53, 107);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(408, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Administración de Usuarios";
            // 
            // tlpRoot
            // 
            tlpRoot.ColumnCount = 1;
            tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpRoot.Controls.Add(pnlHeader, 0, 0);
            tlpRoot.Controls.Add(pnlToolbar, 0, 1);
            tlpRoot.Controls.Add(splitUsuarios, 0, 2);
            tlpRoot.Dock = DockStyle.Fill;
            tlpRoot.Location = new Point(0, 0);
            tlpRoot.Name = "tlpRoot";
            tlpRoot.Padding = new Padding(8);
            tlpRoot.RowCount = 3;
            tlpRoot.RowStyles.Add(new RowStyle());
            tlpRoot.RowStyles.Add(new RowStyle());
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpRoot.Size = new Size(940, 830);
            tlpRoot.TabIndex = 0;
            tlpRoot.Paint += tlpRott_Paint;
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(tlpRoot);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmUsuarios";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Administración de Usuarios";
            splitUsuarios.Panel1.ResumeLayout(false);
            splitUsuarios.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitUsuarios).EndInit();
            splitUsuarios.ResumeLayout(false);
            pnlEditor.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel11.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel9.ResumeLayout(false);
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            pnlToolbar.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpRoot.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitUsuarios;
        private Panel pnlEditor;
        private TextBox txtNombreUsuario;
        private TextBox txtNombreCompleto;
        private Button btnCancelar;
        private Button btnGuardar;
        private CheckBox chkActivo;
        private ComboBox cmbRol;
        private Label lblRol;
        private Label lblNombreUsuario;
        private Label lblNombreCompleto;
        private Panel pnlGrid;
        private DataGridView dgvUsuarios;
        private DataGridViewTextBoxColumn colUsuarioId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colNombreUsuario;
        private DataGridViewTextBoxColumn colRol;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colUltimoAcceso;
        private Panel pnlToolbar;
        private Button btnRestablecer;
        private Button btnCambiarEstado;
        private Button btnEditar;
        private Button btnNuevo;
        private ComboBox cmbFiltroEstado;
        private TextBox txtBuscar;
        private Panel pnlHeader;
        private Label lblSubtitulo;
        private Label lblTitulo;
        private TableLayoutPanel tlpRoot;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel4;
        private Panel panel3;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel10;
        private Panel panel11;
    }
}