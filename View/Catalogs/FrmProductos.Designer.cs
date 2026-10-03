namespace Ocean_Desk_dv.View.Catalogs
{
    partial class FrmProductos
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
            pnlBarraSuperior = new Panel();
            tlpBarraSuperior = new TableLayoutPanel();
            pnlContenido = new Panel();
            tlpPrincipal = new TableLayoutPanel();
            pnlDatosProducto = new Panel();
            Tcproductos = new TabControl();
            tpCatalogo = new TabPage();
            tpReceta = new TabPage();
            lblBuscar = new Label();
            txtBuscarProducto = new TextBox();
            btnNuevoProducto = new Button();
            btnEditarProducto = new Button();
            btnCambiarEstado = new Button();
            pnlAccionesProducto = new Panel();
            btnLimpiarProducto = new Button();
            btnGuardarProducto = new Button();
            chkActivo = new CheckBox();
            chkDisponible = new CheckBox();
            nudStockMinimo = new NumericUpDown();
            label1lblStockMinimo = new Label();
            pnlBarraSuperior.SuspendLayout();
            tlpBarraSuperior.SuspendLayout();
            pnlContenido.SuspendLayout();
            tlpPrincipal.SuspendLayout();
            pnlDatosProducto.SuspendLayout();
            Tcproductos.SuspendLayout();
            pnlAccionesProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).BeginInit();
            SuspendLayout();
            // 
            // pnlBarraSuperior
            // 
            pnlBarraSuperior.BackColor = Color.White;
            pnlBarraSuperior.Controls.Add(tlpBarraSuperior);
            pnlBarraSuperior.Dock = DockStyle.Top;
            pnlBarraSuperior.Location = new Point(0, 0);
            pnlBarraSuperior.Name = "pnlBarraSuperior";
            pnlBarraSuperior.Padding = new Padding(12, 8, 12, 8);
            pnlBarraSuperior.Size = new Size(1489, 78);
            pnlBarraSuperior.TabIndex = 0;
            // 
            // tlpBarraSuperior
            // 
            tlpBarraSuperior.ColumnCount = 5;
            tlpBarraSuperior.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tlpBarraSuperior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpBarraSuperior.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpBarraSuperior.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpBarraSuperior.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tlpBarraSuperior.Controls.Add(btnCambiarEstado, 4, 0);
            tlpBarraSuperior.Controls.Add(lblBuscar, 0, 0);
            tlpBarraSuperior.Controls.Add(btnNuevoProducto, 2, 0);
            tlpBarraSuperior.Controls.Add(txtBuscarProducto, 1, 0);
            tlpBarraSuperior.Controls.Add(btnEditarProducto, 3, 0);
            tlpBarraSuperior.Dock = DockStyle.Fill;
            tlpBarraSuperior.Location = new Point(12, 8);
            tlpBarraSuperior.Margin = new Padding(0, 0, 0, 0);
            tlpBarraSuperior.Name = "tlpBarraSuperior";
            tlpBarraSuperior.RowCount = 1;
            tlpBarraSuperior.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBarraSuperior.Size = new Size(1465, 62);
            tlpBarraSuperior.TabIndex = 0;
            tlpBarraSuperior.Paint += tlpBarraSuperior_Paint;
            // 
            // pnlContenido
            // 
            pnlContenido.BackColor = Color.Transparent;
            pnlContenido.Controls.Add(tlpPrincipal);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 0);
            pnlContenido.Margin = new Padding(3, 12, 3, 10);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(1489, 866);
            pnlContenido.TabIndex = 1;
            // 
            // tlpPrincipal
            // 
            tlpPrincipal.ColumnCount = 2;
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.622406F));
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.377594F));
            tlpPrincipal.Controls.Add(pnlDatosProducto, 1, 0);
            tlpPrincipal.Controls.Add(Tcproductos, 0, 0);
            tlpPrincipal.Dock = DockStyle.Fill;
            tlpPrincipal.Location = new Point(0, 0);
            tlpPrincipal.Name = "tlpPrincipal";
            tlpPrincipal.RowCount = 1;
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpPrincipal.Size = new Size(1489, 866);
            tlpPrincipal.TabIndex = 0;
            // 
            // pnlDatosProducto
            // 
            pnlDatosProducto.BackColor = Color.White;
            pnlDatosProducto.Controls.Add(label1lblStockMinimo);
            pnlDatosProducto.Controls.Add(nudStockMinimo);
            pnlDatosProducto.Controls.Add(chkDisponible);
            pnlDatosProducto.Controls.Add(chkActivo);
            pnlDatosProducto.Controls.Add(pnlAccionesProducto);
            pnlDatosProducto.Dock = DockStyle.Top;
            pnlDatosProducto.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlDatosProducto.Location = new Point(771, 18);
            pnlDatosProducto.Margin = new Padding(18);
            pnlDatosProducto.Name = "pnlDatosProducto";
            pnlDatosProducto.Size = new Size(700, 758);
            pnlDatosProducto.TabIndex = 0;
            // 
            // Tcproductos
            // 
            Tcproductos.Controls.Add(tpCatalogo);
            Tcproductos.Controls.Add(tpReceta);
            Tcproductos.Dock = DockStyle.Fill;
            Tcproductos.Location = new Point(3, 3);
            Tcproductos.Name = "Tcproductos";
            Tcproductos.SelectedIndex = 0;
            Tcproductos.Size = new Size(747, 860);
            Tcproductos.TabIndex = 1;
            // 
            // tpCatalogo
            // 
            tpCatalogo.Location = new Point(4, 29);
            tpCatalogo.Name = "tpCatalogo";
            tpCatalogo.Padding = new Padding(3);
            tpCatalogo.Size = new Size(709, 755);
            tpCatalogo.TabIndex = 0;
            tpCatalogo.Text = "tabPage1";
            tpCatalogo.UseVisualStyleBackColor = true;
            // 
            // tpReceta
            // 
            tpReceta.Location = new Point(4, 29);
            tpReceta.Name = "tpReceta";
            tpReceta.Padding = new Padding(3);
            tpReceta.Size = new Size(739, 827);
            tpReceta.TabIndex = 1;
            tpReceta.Text = "tabPage2";
            tpReceta.UseVisualStyleBackColor = true;
            // 
            // lblBuscar
            // 
            lblBuscar.Dock = DockStyle.Fill;
            lblBuscar.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBuscar.ForeColor = Color.FromArgb(111, 119, 128);
            lblBuscar.Location = new Point(3, 0);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(54, 62);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar";
            lblBuscar.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBuscarProducto.BackColor = Color.White;
            txtBuscarProducto.BorderStyle = BorderStyle.None;
            txtBuscarProducto.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarProducto.Location = new Point(60, 20);
            txtBuscarProducto.Margin = new Padding(0, 0, 0, 0);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(1025, 21);
            txtBuscarProducto.TabIndex = 1;
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;
            // 
            // btnNuevoProducto
            // 
            btnNuevoProducto.BackColor = Color.FromArgb(8, 126, 164);
            btnNuevoProducto.Cursor = Cursors.Hand;
            btnNuevoProducto.Dock = DockStyle.Fill;
            btnNuevoProducto.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btnNuevoProducto.FlatStyle = FlatStyle.Flat;
            btnNuevoProducto.Font = new Font("Century Gothic", 9F);
            btnNuevoProducto.ForeColor = Color.White;
            btnNuevoProducto.Location = new Point(1088, 3);
            btnNuevoProducto.Name = "btnNuevoProducto";
            btnNuevoProducto.Size = new Size(114, 56);
            btnNuevoProducto.TabIndex = 2;
            btnNuevoProducto.Text = "Nuevo";
            btnNuevoProducto.UseVisualStyleBackColor = false;
            // 
            // btnEditarProducto
            // 
            btnEditarProducto.BackColor = Color.FromArgb(238, 243, 247);
            btnEditarProducto.Cursor = Cursors.Hand;
            btnEditarProducto.Dock = DockStyle.Fill;
            btnEditarProducto.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btnEditarProducto.FlatStyle = FlatStyle.Flat;
            btnEditarProducto.Font = new Font("Century Gothic", 9F);
            btnEditarProducto.ForeColor = Color.FromArgb(8, 31, 63);
            btnEditarProducto.Location = new Point(1208, 3);
            btnEditarProducto.Name = "btnEditarProducto";
            btnEditarProducto.Size = new Size(114, 56);
            btnEditarProducto.TabIndex = 3;
            btnEditarProducto.Text = "Editar";
            btnEditarProducto.UseVisualStyleBackColor = false;
            // 
            // btnCambiarEstado
            // 
            btnCambiarEstado.BackColor = Color.FromArgb(163, 61, 61);
            btnCambiarEstado.Dock = DockStyle.Fill;
            btnCambiarEstado.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btnCambiarEstado.FlatStyle = FlatStyle.Flat;
            btnCambiarEstado.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCambiarEstado.ForeColor = Color.White;
            btnCambiarEstado.Location = new Point(1328, 3);
            btnCambiarEstado.Name = "btnCambiarEstado";
            btnCambiarEstado.Size = new Size(134, 56);
            btnCambiarEstado.TabIndex = 0;
            btnCambiarEstado.Text = "Cambiar estado";
            btnCambiarEstado.UseVisualStyleBackColor = false;
            // 
            // pnlAccionesProducto
            // 
            pnlAccionesProducto.Controls.Add(btnGuardarProducto);
            pnlAccionesProducto.Controls.Add(btnLimpiarProducto);
            pnlAccionesProducto.Dock = DockStyle.Bottom;
            pnlAccionesProducto.Location = new Point(0, 700);
            pnlAccionesProducto.Name = "pnlAccionesProducto";
            pnlAccionesProducto.Size = new Size(700, 58);
            pnlAccionesProducto.TabIndex = 0;
            // 
            // btnLimpiarProducto
            // 
            btnLimpiarProducto.BackColor = Color.FromArgb(238, 243, 247);
            btnLimpiarProducto.Dock = DockStyle.Left;
            btnLimpiarProducto.FlatAppearance.BorderSize = 0;
            btnLimpiarProducto.FlatStyle = FlatStyle.Flat;
            btnLimpiarProducto.ForeColor = Color.FromArgb(8, 31, 63);
            btnLimpiarProducto.Location = new Point(0, 0);
            btnLimpiarProducto.Name = "btnLimpiarProducto";
            btnLimpiarProducto.Size = new Size(110, 58);
            btnLimpiarProducto.TabIndex = 1;
            btnLimpiarProducto.Text = "Limpiar";
            btnLimpiarProducto.UseVisualStyleBackColor = false;
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.BackColor = Color.FromArgb(8, 126, 164);
            btnGuardarProducto.Dock = DockStyle.Right;
            btnGuardarProducto.FlatAppearance.BorderSize = 0;
            btnGuardarProducto.FlatStyle = FlatStyle.Flat;
            btnGuardarProducto.ForeColor = Color.White;
            btnGuardarProducto.Location = new Point(575, 0);
            btnGuardarProducto.Name = "btnGuardarProducto";
            btnGuardarProducto.Size = new Size(125, 58);
            btnGuardarProducto.TabIndex = 1;
            btnGuardarProducto.Text = "Guardar";
            btnGuardarProducto.UseVisualStyleBackColor = false;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Dock = DockStyle.Top;
            chkActivo.Location = new Point(0, 0);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(700, 24);
            chkActivo.TabIndex = 1;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // chkDisponible
            // 
            chkDisponible.AutoSize = true;
            chkDisponible.Checked = true;
            chkDisponible.CheckState = CheckState.Checked;
            chkDisponible.Dock = DockStyle.Top;
            chkDisponible.Location = new Point(0, 24);
            chkDisponible.Name = "chkDisponible";
            chkDisponible.Size = new Size(700, 24);
            chkDisponible.TabIndex = 2;
            chkDisponible.Text = "Disponible ";
            chkDisponible.UseVisualStyleBackColor = true;
            // 
            // nudStockMinimo
            // 
            nudStockMinimo.DecimalPlaces = 2;
            nudStockMinimo.Dock = DockStyle.Top;
            nudStockMinimo.Location = new Point(0, 48);
            nudStockMinimo.Name = "nudStockMinimo";
            nudStockMinimo.Size = new Size(700, 26);
            nudStockMinimo.TabIndex = 0;
            // 
            // label1lblStockMinimo
            // 
            label1lblStockMinimo.Dock = DockStyle.Top;
            label1lblStockMinimo.Location = new Point(0, 74);
            label1lblStockMinimo.Name = "label1lblStockMinimo";
            label1lblStockMinimo.Size = new Size(700, 20);
            label1lblStockMinimo.TabIndex = 3;
            label1lblStockMinimo.Text = "label1";
            // 
            // FrmProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1489, 866);
            Controls.Add(pnlBarraSuperior);
            Controls.Add(pnlContenido);
            Name = "FrmProductos";
            Text = "FrmProductos";
            pnlBarraSuperior.ResumeLayout(false);
            tlpBarraSuperior.ResumeLayout(false);
            tlpBarraSuperior.PerformLayout();
            pnlContenido.ResumeLayout(false);
            tlpPrincipal.ResumeLayout(false);
            pnlDatosProducto.ResumeLayout(false);
            pnlDatosProducto.PerformLayout();
            Tcproductos.ResumeLayout(false);
            pnlAccionesProducto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBarraSuperior;
        private TableLayoutPanel tlpBarraSuperior;
        private Panel pnlContenido;
        private TableLayoutPanel tlpPrincipal;
        private Panel pnlDatosProducto;
        private TabControl Tcproductos;
        private TabPage tpCatalogo;
        private TabPage tpReceta;
        private Label lblBuscar;
        private TextBox txtBuscarProducto;
        private Button btnNuevoProducto;
        private Button btnEditarProducto;
        private Button btnCambiarEstado;
        private Panel pnlAccionesProducto;
        private Button btnLimpiarProducto;
        private Button btnGuardarProducto;
        private CheckBox chkActivo;
        private CheckBox chkDisponible;
        private NumericUpDown nudStockMinimo;
        private Label label1lblStockMinimo;
    }
}