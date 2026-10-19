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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            splitUsuarios = new SplitContainer();
            pnlGrid = new Panel();
            dgvUsuarios = new DataGridView();
            colUltimoAcceso = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colRol = new DataGridViewTextBoxColumn();
            colNombreUsuario = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colUsuarioId = new DataGridViewTextBoxColumn();
            pnlEditor = new Panel();
            lblNombreCompleto = new Label();
            lblNombreUsuario = new Label();
            lblRol = new Label();
            cmbRol = new ComboBox();
            chkActivo = new CheckBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            txtNombreCompleto = new TextBox();
            txtNombreUsuario = new TextBox();
            pnlToolbar = new Panel();
            txtBuscar = new TextBox();
            cmbFiltroEstado = new ComboBox();
            btnNuevo = new Button();
            btnEditar = new Button();
            btnCambiarEstado = new Button();
            btnRestablecer = new Button();
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            tlpRoot = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitUsuarios).BeginInit();
            splitUsuarios.Panel1.SuspendLayout();
            splitUsuarios.Panel2.SuspendLayout();
            splitUsuarios.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            pnlEditor.SuspendLayout();
            pnlToolbar.SuspendLayout();
            pnlHeader.SuspendLayout();
            tlpRoot.SuspendLayout();
            SuspendLayout();
            // 
            // splitUsuarios
            // 
            splitUsuarios.Dock = DockStyle.Fill;
            splitUsuarios.Location = new Point(19, 144);
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
            splitUsuarios.Size = new Size(844, 350);
            splitUsuarios.SplitterDistance = 340;
            splitUsuarios.TabIndex = 2;
            // 
            // pnlGrid
            // 
            pnlGrid.BackColor = Color.White;
            pnlGrid.Controls.Add(dgvUsuarios);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(0, 0);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(500, 350);
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
            dataGridViewCellStyle2.BackColor = Color.FromArgb(18, 53, 107);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { colUsuarioId, colNombre, colNombreUsuario, colRol, colEstado, colUltimoAcceso });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(217, 243, 246);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
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
            dgvUsuarios.Size = new Size(500, 350);
            dgvUsuarios.TabIndex = 0;
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
            // colRol
            // 
            colRol.DataPropertyName = "RoleName";
            colRol.HeaderText = "Rol";
            colRol.MinimumWidth = 6;
            colRol.Name = "colRol";
            colRol.ReadOnly = true;
            colRol.Width = 140;
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
            // pnlEditor
            // 
            pnlEditor.BackColor = Color.White;
            pnlEditor.Controls.Add(txtNombreUsuario);
            pnlEditor.Controls.Add(txtNombreCompleto);
            pnlEditor.Controls.Add(btnCancelar);
            pnlEditor.Controls.Add(btnGuardar);
            pnlEditor.Controls.Add(chkActivo);
            pnlEditor.Controls.Add(cmbRol);
            pnlEditor.Controls.Add(lblRol);
            pnlEditor.Controls.Add(lblNombreUsuario);
            pnlEditor.Controls.Add(lblNombreCompleto);
            pnlEditor.Dock = DockStyle.Fill;
            pnlEditor.Location = new Point(0, 0);
            pnlEditor.Name = "pnlEditor";
            pnlEditor.Padding = new Padding(14);
            pnlEditor.Size = new Size(340, 350);
            pnlEditor.TabIndex = 0;
            // 
            // lblNombreCompleto
            // 
            lblNombreCompleto.AutoSize = true;
            lblNombreCompleto.Location = new Point(19, 16);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new Size(134, 20);
            lblNombreCompleto.TabIndex = 0;
            lblNombreCompleto.Text = "Nombre Completo";
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Location = new Point(16, 83);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(139, 20);
            lblNombreUsuario.TabIndex = 1;
            lblNombreUsuario.Text = "Nombre de Usuario";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(14, 150);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(98, 20);
            lblRol.TabIndex = 2;
            lblRol.Text = "Rol Asignado";
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(14, 173);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(312, 28);
            cmbRol.TabIndex = 3;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Location = new Point(16, 213);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(122, 24);
            chkActivo.TabIndex = 4;
            chkActivo.Text = "Cuenta Activa";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(18, 53, 107);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(19, 254);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(149, 29);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.FromArgb(18, 53, 107);
            btnCancelar.Location = new Point(188, 254);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(138, 29);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Location = new Point(19, 39);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(303, 27);
            txtNombreCompleto.TabIndex = 7;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(16, 106);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(310, 27);
            txtNombreUsuario.TabIndex = 8;
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.White;
            pnlToolbar.Controls.Add(btnRestablecer);
            pnlToolbar.Controls.Add(btnCambiarEstado);
            pnlToolbar.Controls.Add(btnEditar);
            pnlToolbar.Controls.Add(btnNuevo);
            pnlToolbar.Controls.Add(cmbFiltroEstado);
            pnlToolbar.Controls.Add(txtBuscar);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(19, 82);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Padding = new Padding(10);
            pnlToolbar.Size = new Size(844, 56);
            pnlToolbar.TabIndex = 1;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(5, 11);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por nombre o usuario...";
            txtBuscar.Size = new Size(217, 27);
            txtBuscar.TabIndex = 0;
            // 
            // cmbFiltroEstado
            // 
            cmbFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroEstado.FormattingEnabled = true;
            cmbFiltroEstado.Items.AddRange(new object[] { "Todos", "Activos ", "Inactivos" });
            cmbFiltroEstado.Location = new Point(228, 10);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.Size = new Size(124, 28);
            cmbFiltroEstado.TabIndex = 1;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(18, 53, 107);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(359, 6);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(79, 36);
            btnNuevo.TabIndex = 2;
            btnNuevo.Text = "+ Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(18, 175, 196);
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(444, 6);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(83, 36);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnCambiarEstado
            // 
            btnCambiarEstado.BackColor = Color.FromArgb(234, 247, 250);
            btnCambiarEstado.FlatStyle = FlatStyle.Flat;
            btnCambiarEstado.ForeColor = Color.FromArgb(18, 53, 107);
            btnCambiarEstado.Location = new Point(533, 6);
            btnCambiarEstado.Name = "btnCambiarEstado";
            btnCambiarEstado.Size = new Size(151, 36);
            btnCambiarEstado.TabIndex = 4;
            btnCambiarEstado.Text = "Activar / Desactivar";
            btnCambiarEstado.UseVisualStyleBackColor = false;
            // 
            // btnRestablecer
            // 
            btnRestablecer.FlatStyle = FlatStyle.Flat;
            btnRestablecer.ForeColor = Color.FromArgb(18, 53, 107);
            btnRestablecer.Location = new Point(690, 6);
            btnRestablecer.Name = "btnRestablecer";
            btnRestablecer.Size = new Size(146, 36);
            btnRestablecer.TabIndex = 5;
            btnRestablecer.Text = "Restablecer acceso";
            btnRestablecer.UseVisualStyleBackColor = true;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Location = new Point(19, 19);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(844, 57);
            pnlHeader.TabIndex = 0;
            pnlHeader.Paint += pnlHeader_Paint;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(18, 53, 107);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(405, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Administración de Usuarios";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Dock = DockStyle.Top;
            lblSubtitulo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = Color.FromArgb(101, 116, 139);
            lblSubtitulo.Location = new Point(0, 41);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(296, 20);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Gestiona cuentas, roles y acceso al sistema";
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
            tlpRoot.Padding = new Padding(16);
            tlpRoot.RowCount = 3;
            tlpRoot.RowStyles.Add(new RowStyle());
            tlpRoot.RowStyles.Add(new RowStyle());
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpRoot.Size = new Size(882, 513);
            tlpRoot.TabIndex = 0;
            tlpRoot.Paint += tlpRott_Paint;
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 250);
            ClientSize = new Size(882, 513);
            Controls.Add(tlpRoot);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(900, 560);
            Name = "FrmUsuarios";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Administración de Usuarios";
            splitUsuarios.Panel1.ResumeLayout(false);
            splitUsuarios.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitUsuarios).EndInit();
            splitUsuarios.ResumeLayout(false);
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            pnlEditor.ResumeLayout(false);
            pnlEditor.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
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
    }
}