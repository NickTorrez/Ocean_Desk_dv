namespace Ocean_Desk_dv.View.Catalogs
{
    partial class FrmProveedores
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
            pnlBarraProveedores = new Panel();
            btnCambiarEstadoProveedor = new Button();
            btnEditarProveedor = new Button();
            btnNuevoProveedor = new Button();
            txtBuscarProveedor = new TextBox();
            pnlContenido = new Panel();
            tlpPrincipalProveedores = new TableLayoutPanel();
            pnlDatosProveedor = new Panel();
            lblTelefonoProveedor = new Label();
            lblNombreProveedor = new Label();
            txtNombreProveedor = new TextBox();
            lblContactoProveedor = new Label();
            txtContactoProveedor = new TextBox();
            txtTelefonoProveedor = new TextBox();
            lblCorreoProveedor = new Label();
            txtCorreoProveedor = new TextBox();
            lblDireccionProveedor = new Label();
            txtDireccionProveedor = new TextBox();
            pnlAccionesProveedor = new Panel();
            btnGuardarProveedor = new Button();
            btnCancelarProveedor = new Button();
            chkActivoProveedor = new CheckBox();
            tcProveedores = new TabControl();
            tpProveedores = new TabPage();
            dgvProveedores = new DataGridView();
            tpComprasAsociadas = new TabPage();
            pnlBarraProveedores.SuspendLayout();
            pnlContenido.SuspendLayout();
            tlpPrincipalProveedores.SuspendLayout();
            pnlDatosProveedor.SuspendLayout();
            pnlAccionesProveedor.SuspendLayout();
            tcProveedores.SuspendLayout();
            tpProveedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            SuspendLayout();
            // 
            // pnlBarraProveedores
            // 
            pnlBarraProveedores.BackColor = Color.FromArgb(245, 247, 250);
            pnlBarraProveedores.Controls.Add(btnCambiarEstadoProveedor);
            pnlBarraProveedores.Controls.Add(btnEditarProveedor);
            pnlBarraProveedores.Controls.Add(btnNuevoProveedor);
            pnlBarraProveedores.Controls.Add(txtBuscarProveedor);
            pnlBarraProveedores.Dock = DockStyle.Top;
            pnlBarraProveedores.Location = new Point(0, 0);
            pnlBarraProveedores.Name = "pnlBarraProveedores";
            pnlBarraProveedores.Padding = new Padding(12, 8, 12, 8);
            pnlBarraProveedores.Size = new Size(940, 78);
            pnlBarraProveedores.TabIndex = 0;
            // 
            // btnCambiarEstadoProveedor
            // 
            btnCambiarEstadoProveedor.BackColor = Color.FromArgb(163, 61, 61);
            btnCambiarEstadoProveedor.FlatAppearance.BorderSize = 0;
            btnCambiarEstadoProveedor.FlatStyle = FlatStyle.Flat;
            btnCambiarEstadoProveedor.Font = new Font("Century Gothic", 9F);
            btnCambiarEstadoProveedor.ForeColor = Color.White;
            btnCambiarEstadoProveedor.Location = new Point(496, 41);
            btnCambiarEstadoProveedor.Name = "btnCambiarEstadoProveedor";
            btnCambiarEstadoProveedor.Size = new Size(135, 29);
            btnCambiarEstadoProveedor.TabIndex = 3;
            btnCambiarEstadoProveedor.Text = "Cambiar Estado";
            btnCambiarEstadoProveedor.UseVisualStyleBackColor = false;
            // 
            // btnEditarProveedor
            // 
            btnEditarProveedor.BackColor = Color.FromArgb(238, 247, 243);
            btnEditarProveedor.FlatStyle = FlatStyle.Flat;
            btnEditarProveedor.Font = new Font("Century Gothic", 9F);
            btnEditarProveedor.ForeColor = Color.FromArgb(8, 31, 63);
            btnEditarProveedor.Location = new Point(308, 42);
            btnEditarProveedor.Name = "btnEditarProveedor";
            btnEditarProveedor.Size = new Size(162, 29);
            btnEditarProveedor.TabIndex = 2;
            btnEditarProveedor.Text = "Editar Proveedor";
            btnEditarProveedor.UseVisualStyleBackColor = false;
            // 
            // btnNuevoProveedor
            // 
            btnNuevoProveedor.BackColor = Color.FromArgb(8, 126, 164);
            btnNuevoProveedor.FlatAppearance.BorderSize = 0;
            btnNuevoProveedor.FlatStyle = FlatStyle.Flat;
            btnNuevoProveedor.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevoProveedor.ForeColor = Color.White;
            btnNuevoProveedor.Location = new Point(125, 42);
            btnNuevoProveedor.Name = "btnNuevoProveedor";
            btnNuevoProveedor.Size = new Size(157, 29);
            btnNuevoProveedor.TabIndex = 1;
            btnNuevoProveedor.Text = "Nuevo Proveedor";
            btnNuevoProveedor.UseVisualStyleBackColor = false;
            btnNuevoProveedor.Click += btnNuevoProveedor_Click;
            // 
            // txtBuscarProveedor
            // 
            txtBuscarProveedor.BorderStyle = BorderStyle.None;
            txtBuscarProveedor.Dock = DockStyle.Fill;
            txtBuscarProveedor.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarProveedor.Location = new Point(12, 8);
            txtBuscarProveedor.MaxLength = 150;
            txtBuscarProveedor.Name = "txtBuscarProveedor";
            txtBuscarProveedor.PlaceholderText = "Buscar proveedor";
            txtBuscarProveedor.Size = new Size(916, 21);
            txtBuscarProveedor.TabIndex = 0;
            // 
            // pnlContenido
            // 
            pnlContenido.Controls.Add(tlpPrincipalProveedores);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 78);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Padding = new Padding(3, 12, 3, 10);
            pnlContenido.Size = new Size(940, 752);
            pnlContenido.TabIndex = 1;
            // 
            // tlpPrincipalProveedores
            // 
            tlpPrincipalProveedores.ColumnCount = 2;
            tlpPrincipalProveedores.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
            tlpPrincipalProveedores.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64F));
            tlpPrincipalProveedores.Controls.Add(tcProveedores, 1, 0);
            tlpPrincipalProveedores.Controls.Add(pnlDatosProveedor, 0, 0);
            tlpPrincipalProveedores.Dock = DockStyle.Fill;
            tlpPrincipalProveedores.Location = new Point(3, 12);
            tlpPrincipalProveedores.Name = "tlpPrincipalProveedores";
            tlpPrincipalProveedores.RowCount = 2;
            tlpPrincipalProveedores.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPrincipalProveedores.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpPrincipalProveedores.Size = new Size(934, 730);
            tlpPrincipalProveedores.TabIndex = 0;
            // 
            // pnlDatosProveedor
            // 
            pnlDatosProveedor.BackColor = Color.White;
            pnlDatosProveedor.Controls.Add(pnlAccionesProveedor);
            pnlDatosProveedor.Controls.Add(chkActivoProveedor);
            pnlDatosProveedor.Controls.Add(txtDireccionProveedor);
            pnlDatosProveedor.Controls.Add(lblDireccionProveedor);
            pnlDatosProveedor.Controls.Add(txtCorreoProveedor);
            pnlDatosProveedor.Controls.Add(lblCorreoProveedor);
            pnlDatosProveedor.Controls.Add(txtTelefonoProveedor);
            pnlDatosProveedor.Controls.Add(lblTelefonoProveedor);
            pnlDatosProveedor.Controls.Add(txtContactoProveedor);
            pnlDatosProveedor.Controls.Add(lblContactoProveedor);
            pnlDatosProveedor.Controls.Add(txtNombreProveedor);
            pnlDatosProveedor.Controls.Add(lblNombreProveedor);
            pnlDatosProveedor.Dock = DockStyle.Fill;
            pnlDatosProveedor.Font = new Font("Century Gothic", 9F);
            pnlDatosProveedor.Location = new Point(3, 3);
            pnlDatosProveedor.Name = "pnlDatosProveedor";
            pnlDatosProveedor.Padding = new Padding(18, 0, 0, 0);
            pnlDatosProveedor.Size = new Size(330, 704);
            pnlDatosProveedor.TabIndex = 0;
            pnlDatosProveedor.Paint += pnlDatosProveedor_Paint;
            // 
            // lblTelefonoProveedor
            // 
            lblTelefonoProveedor.BackColor = Color.White;
            lblTelefonoProveedor.Dock = DockStyle.Top;
            lblTelefonoProveedor.Font = new Font("Century Gothic", 9F);
            lblTelefonoProveedor.ForeColor = Color.FromArgb(111, 119, 128);
            lblTelefonoProveedor.Location = new Point(18, 92);
            lblTelefonoProveedor.Name = "lblTelefonoProveedor";
            lblTelefonoProveedor.Size = new Size(312, 20);
            lblTelefonoProveedor.TabIndex = 7;
            lblTelefonoProveedor.Text = "Teléfono";
            // 
            // lblNombreProveedor
            // 
            lblNombreProveedor.BackColor = Color.White;
            lblNombreProveedor.Dock = DockStyle.Top;
            lblNombreProveedor.Font = new Font("Century Gothic", 9F);
            lblNombreProveedor.ForeColor = Color.FromArgb(111, 119, 128);
            lblNombreProveedor.Location = new Point(18, 0);
            lblNombreProveedor.Name = "lblNombreProveedor";
            lblNombreProveedor.Size = new Size(312, 20);
            lblNombreProveedor.TabIndex = 11;
            lblNombreProveedor.Text = "Nombre";
            // 
            // txtNombreProveedor
            // 
            txtNombreProveedor.Dock = DockStyle.Top;
            txtNombreProveedor.Location = new Point(18, 20);
            txtNombreProveedor.MaxLength = 150;
            txtNombreProveedor.Name = "txtNombreProveedor";
            txtNombreProveedor.Size = new Size(312, 26);
            txtNombreProveedor.TabIndex = 10;
            // 
            // lblContactoProveedor
            // 
            lblContactoProveedor.BackColor = Color.White;
            lblContactoProveedor.Dock = DockStyle.Top;
            lblContactoProveedor.Font = new Font("Century Gothic", 9F);
            lblContactoProveedor.ForeColor = Color.FromArgb(111, 119, 128);
            lblContactoProveedor.Location = new Point(18, 46);
            lblContactoProveedor.Name = "lblContactoProveedor";
            lblContactoProveedor.Size = new Size(312, 20);
            lblContactoProveedor.TabIndex = 9;
            lblContactoProveedor.Text = "Contacto";
            // 
            // txtContactoProveedor
            // 
            txtContactoProveedor.Dock = DockStyle.Top;
            txtContactoProveedor.Location = new Point(18, 66);
            txtContactoProveedor.MaxLength = 100;
            txtContactoProveedor.Name = "txtContactoProveedor";
            txtContactoProveedor.Size = new Size(312, 26);
            txtContactoProveedor.TabIndex = 8;
            // 
            // txtTelefonoProveedor
            // 
            txtTelefonoProveedor.Dock = DockStyle.Top;
            txtTelefonoProveedor.Location = new Point(18, 112);
            txtTelefonoProveedor.MaxLength = 20;
            txtTelefonoProveedor.Name = "txtTelefonoProveedor";
            txtTelefonoProveedor.Size = new Size(312, 26);
            txtTelefonoProveedor.TabIndex = 6;
            // 
            // lblCorreoProveedor
            // 
            lblCorreoProveedor.BackColor = Color.White;
            lblCorreoProveedor.Dock = DockStyle.Top;
            lblCorreoProveedor.Font = new Font("Century Gothic", 9F);
            lblCorreoProveedor.ForeColor = Color.FromArgb(111, 119, 128);
            lblCorreoProveedor.Location = new Point(18, 138);
            lblCorreoProveedor.Name = "lblCorreoProveedor";
            lblCorreoProveedor.Size = new Size(312, 20);
            lblCorreoProveedor.TabIndex = 5;
            lblCorreoProveedor.Text = "Correo";
            // 
            // txtCorreoProveedor
            // 
            txtCorreoProveedor.Dock = DockStyle.Top;
            txtCorreoProveedor.Location = new Point(18, 158);
            txtCorreoProveedor.MaxLength = 150;
            txtCorreoProveedor.Name = "txtCorreoProveedor";
            txtCorreoProveedor.Size = new Size(312, 26);
            txtCorreoProveedor.TabIndex = 4;
            // 
            // lblDireccionProveedor
            // 
            lblDireccionProveedor.BackColor = Color.White;
            lblDireccionProveedor.Dock = DockStyle.Top;
            lblDireccionProveedor.Font = new Font("Century Gothic", 9F);
            lblDireccionProveedor.ForeColor = Color.FromArgb(111, 119, 128);
            lblDireccionProveedor.Location = new Point(18, 184);
            lblDireccionProveedor.Name = "lblDireccionProveedor";
            lblDireccionProveedor.Size = new Size(312, 20);
            lblDireccionProveedor.TabIndex = 3;
            lblDireccionProveedor.Text = "Dirección";
            // 
            // txtDireccionProveedor
            // 
            txtDireccionProveedor.Dock = DockStyle.Top;
            txtDireccionProveedor.Location = new Point(18, 204);
            txtDireccionProveedor.MaxLength = 250;
            txtDireccionProveedor.Multiline = true;
            txtDireccionProveedor.Name = "txtDireccionProveedor";
            txtDireccionProveedor.Size = new Size(312, 60);
            txtDireccionProveedor.TabIndex = 2;
            // 
            // pnlAccionesProveedor
            // 
            pnlAccionesProveedor.Controls.Add(btnGuardarProveedor);
            pnlAccionesProveedor.Controls.Add(btnCancelarProveedor);
            pnlAccionesProveedor.Dock = DockStyle.Bottom;
            pnlAccionesProveedor.ForeColor = Color.White;
            pnlAccionesProveedor.Location = new Point(18, 644);
            pnlAccionesProveedor.Name = "pnlAccionesProveedor";
            pnlAccionesProveedor.Size = new Size(312, 60);
            pnlAccionesProveedor.TabIndex = 1;
            // 
            // btnGuardarProveedor
            // 
            btnGuardarProveedor.BackColor = Color.FromArgb(8, 126, 164);
            btnGuardarProveedor.FlatAppearance.BorderSize = 0;
            btnGuardarProveedor.FlatStyle = FlatStyle.Flat;
            btnGuardarProveedor.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardarProveedor.ForeColor = Color.White;
            btnGuardarProveedor.Location = new Point(10, 0);
            btnGuardarProveedor.Name = "btnGuardarProveedor";
            btnGuardarProveedor.Size = new Size(120, 40);
            btnGuardarProveedor.TabIndex = 1;
            btnGuardarProveedor.Text = "Guardar";
            btnGuardarProveedor.UseVisualStyleBackColor = false;
            // 
            // btnCancelarProveedor
            // 
            btnCancelarProveedor.BackColor = Color.FromArgb(238, 243, 247);
            btnCancelarProveedor.FlatAppearance.BorderSize = 0;
            btnCancelarProveedor.FlatStyle = FlatStyle.Flat;
            btnCancelarProveedor.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelarProveedor.ForeColor = Color.FromArgb(8, 31, 63);
            btnCancelarProveedor.Location = new Point(185, 0);
            btnCancelarProveedor.Name = "btnCancelarProveedor";
            btnCancelarProveedor.Size = new Size(120, 40);
            btnCancelarProveedor.TabIndex = 2;
            btnCancelarProveedor.Text = "Cancelar";
            btnCancelarProveedor.UseVisualStyleBackColor = false;
            // 
            // chkActivoProveedor
            // 
            chkActivoProveedor.AutoSize = true;
            chkActivoProveedor.Checked = true;
            chkActivoProveedor.CheckState = CheckState.Checked;
            chkActivoProveedor.Dock = DockStyle.Top;
            chkActivoProveedor.Location = new Point(18, 264);
            chkActivoProveedor.Name = "chkActivoProveedor";
            chkActivoProveedor.Size = new Size(312, 24);
            chkActivoProveedor.TabIndex = 1;
            chkActivoProveedor.Text = "Activo";
            chkActivoProveedor.UseVisualStyleBackColor = true;
            // 
            // tcProveedores
            // 
            tcProveedores.Controls.Add(tpProveedores);
            tcProveedores.Controls.Add(tpComprasAsociadas);
            tcProveedores.Dock = DockStyle.Fill;
            tcProveedores.Font = new Font("Century Gothic", 9F);
            tcProveedores.Location = new Point(339, 3);
            tcProveedores.Name = "tcProveedores";
            tcProveedores.SelectedIndex = 0;
            tcProveedores.Size = new Size(592, 704);
            tcProveedores.TabIndex = 2;
            // 
            // tpProveedores
            // 
            tpProveedores.AccessibleDescription = "";
            tpProveedores.AccessibleName = "";
            tpProveedores.BackColor = Color.Transparent;
            tpProveedores.Controls.Add(dgvProveedores);
            tpProveedores.Location = new Point(4, 29);
            tpProveedores.Name = "tpProveedores";
            tpProveedores.Padding = new Padding(3);
            tpProveedores.Size = new Size(584, 671);
            tpProveedores.TabIndex = 0;
            tpProveedores.Text = "Proveedores";
            // 
            // dgvProveedores
            // 
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.AllowUserToDeleteRows = false;
            dgvProveedores.AllowUserToResizeColumns = false;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.BackgroundColor = Color.FromArgb(245, 247, 250);
            dgvProveedores.BorderStyle = BorderStyle.None;
            dgvProveedores.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 15, 255, 255);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvProveedores.DefaultCellStyle = dataGridViewCellStyle1;
            dgvProveedores.Dock = DockStyle.Fill;
            dgvProveedores.EnableHeadersVisualStyles = false;
            dgvProveedores.GridColor = Color.FromArgb(230, 234, 238);
            dgvProveedores.Location = new Point(3, 3);
            dgvProveedores.MultiSelect = false;
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.ReadOnly = true;
            dgvProveedores.RowHeadersVisible = false;
            dgvProveedores.RowHeadersWidth = 51;
            dgvProveedores.RowTemplate.Height = 38;
            dgvProveedores.ScrollBars = ScrollBars.None;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.Size = new Size(578, 665);
            dgvProveedores.TabIndex = 0;
            // 
            // tpComprasAsociadas
            // 
            tpComprasAsociadas.Location = new Point(4, 29);
            tpComprasAsociadas.Name = "tpComprasAsociadas";
            tpComprasAsociadas.Padding = new Padding(3);
            tpComprasAsociadas.Size = new Size(322, 671);
            tpComprasAsociadas.TabIndex = 1;
            tpComprasAsociadas.Text = "Compras asociadas";
            tpComprasAsociadas.UseVisualStyleBackColor = true;
            // 
            // FrmProveedores
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(pnlContenido);
            Controls.Add(pnlBarraProveedores);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmProveedores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmProveedores";
            pnlBarraProveedores.ResumeLayout(false);
            pnlBarraProveedores.PerformLayout();
            pnlContenido.ResumeLayout(false);
            tlpPrincipalProveedores.ResumeLayout(false);
            pnlDatosProveedor.ResumeLayout(false);
            pnlDatosProveedor.PerformLayout();
            pnlAccionesProveedor.ResumeLayout(false);
            tcProveedores.ResumeLayout(false);
            tpProveedores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBarraProveedores;
        private Panel pnlContenido;
        private TableLayoutPanel tlpPrincipalProveedores;
        private Panel pnlDatosProveedor;
        private Button btnCambiarEstadoProveedor;
        private Button btnEditarProveedor;
        private Button btnNuevoProveedor;
        private TextBox txt;
        private TextBox txtBuscarProveedor;
        private TextBox txtNombreProveedor;
        private Label lblContactoProveedor;
        private TextBox txtContactoProveedor;
        private Label lblTelefonoProveedor;
        private TextBox txtTelefonoProveedor;
        private Label lblCorreoProveedor;
        private TextBox txtCorreoProveedor;
        private Label lblDireccionProveedor;
        private TextBox txtDireccionProveedor;
        private Panel pnlAccionesProveedor;
        private Button btnCancelarProveedor;
        private Button btnGuardarProveedor;
        private Label lblNombreProveedor;
        private CheckBox chkActivoProveedor;
        private TabControl tcProveedores;
        private TabPage tpProveedores;
        private DataGridView dgvProveedores;
        private TabPage tpComprasAsociadas;
    }
}