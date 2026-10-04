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
            btnCambiarEstado = new Button();
            lblBuscar = new Label();
            btnNuevoProducto = new Button();
            txtBuscarProducto = new TextBox();
            btnEditarProducto = new Button();
            pnlContenido = new Panel();
            tlpPrincipal = new TableLayoutPanel();
            pnlDatosProducto = new Panel();
            txtDescripcion = new TextBox();
            lblPrecio = new Label();
            lblUnidad = new Label();
            cmbUnidad = new ComboBox();
            lblStockMinimo = new Label();
            nudStockMinimo = new NumericUpDown();
            chkDisponible = new CheckBox();
            chkActivo = new CheckBox();
            pnlAccionesProducto = new Panel();
            btnGuardarProducto = new Button();
            btnLimpiarProducto = new Button();
            Tcproductos = new TabControl();
            tpReceta = new TabPage();
            tpCatalogo = new TabPage();
            cmbCategoria = new ComboBox();
            lblCategoria = new Label();
            txtCodigo = new TextBox();
            lblCodigo = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            nudPrecio = new NumericUpDown();
            lblDescripcion = new Label();
            pnlBarraSuperior.SuspendLayout();
            tlpBarraSuperior.SuspendLayout();
            pnlContenido.SuspendLayout();
            tlpPrincipal.SuspendLayout();
            pnlDatosProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).BeginInit();
            pnlAccionesProducto.SuspendLayout();
            Tcproductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
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
            pnlBarraSuperior.Size = new Size(922, 78);
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
            tlpBarraSuperior.Margin = new Padding(0);
            tlpBarraSuperior.Name = "tlpBarraSuperior";
            tlpBarraSuperior.RowCount = 1;
            tlpBarraSuperior.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBarraSuperior.Size = new Size(898, 62);
            tlpBarraSuperior.TabIndex = 0;
            tlpBarraSuperior.Paint += tlpBarraSuperior_Paint;
            // 
            // btnCambiarEstado
            // 
            btnCambiarEstado.BackColor = Color.FromArgb(163, 61, 61);
            btnCambiarEstado.Dock = DockStyle.Fill;
            btnCambiarEstado.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btnCambiarEstado.FlatStyle = FlatStyle.Flat;
            btnCambiarEstado.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCambiarEstado.ForeColor = Color.White;
            btnCambiarEstado.Location = new Point(761, 3);
            btnCambiarEstado.Name = "btnCambiarEstado";
            btnCambiarEstado.Size = new Size(134, 56);
            btnCambiarEstado.TabIndex = 0;
            btnCambiarEstado.Text = "Cambiar estado";
            btnCambiarEstado.UseVisualStyleBackColor = false;
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
            // btnNuevoProducto
            // 
            btnNuevoProducto.BackColor = Color.FromArgb(8, 126, 164);
            btnNuevoProducto.Cursor = Cursors.Hand;
            btnNuevoProducto.Dock = DockStyle.Fill;
            btnNuevoProducto.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btnNuevoProducto.FlatStyle = FlatStyle.Flat;
            btnNuevoProducto.Font = new Font("Century Gothic", 9F);
            btnNuevoProducto.ForeColor = Color.White;
            btnNuevoProducto.Location = new Point(521, 3);
            btnNuevoProducto.Name = "btnNuevoProducto";
            btnNuevoProducto.Size = new Size(114, 56);
            btnNuevoProducto.TabIndex = 2;
            btnNuevoProducto.Text = "Nuevo";
            btnNuevoProducto.UseVisualStyleBackColor = false;
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBuscarProducto.BackColor = Color.White;
            txtBuscarProducto.BorderStyle = BorderStyle.None;
            txtBuscarProducto.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarProducto.Location = new Point(60, 20);
            txtBuscarProducto.Margin = new Padding(0);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(458, 21);
            txtBuscarProducto.TabIndex = 1;
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;
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
            btnEditarProducto.Location = new Point(641, 3);
            btnEditarProducto.Name = "btnEditarProducto";
            btnEditarProducto.Size = new Size(114, 56);
            btnEditarProducto.TabIndex = 3;
            btnEditarProducto.Text = "Editar";
            btnEditarProducto.UseVisualStyleBackColor = false;
            // 
            // pnlContenido
            // 
            pnlContenido.BackColor = Color.Transparent;
            pnlContenido.Controls.Add(tlpPrincipal);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 0);
            pnlContenido.Margin = new Padding(3, 12, 3, 10);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(922, 783);
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
            tlpPrincipal.Size = new Size(922, 783);
            tlpPrincipal.TabIndex = 0;
            // 
            // pnlDatosProducto
            // 
            pnlDatosProducto.BackColor = Color.White;
            pnlDatosProducto.Controls.Add(lblCodigo);
            pnlDatosProducto.Controls.Add(txtCodigo);
            pnlDatosProducto.Controls.Add(lblNombre);
            pnlDatosProducto.Controls.Add(txtNombre);
            pnlDatosProducto.Controls.Add(lblCategoria);
            pnlDatosProducto.Controls.Add(cmbCategoria);
            pnlDatosProducto.Controls.Add(lblDescripcion);
            pnlDatosProducto.Controls.Add(txtDescripcion);
            pnlDatosProducto.Controls.Add(lblPrecio);
            pnlDatosProducto.Controls.Add(nudPrecio);
            pnlDatosProducto.Controls.Add(lblUnidad);
            pnlDatosProducto.Controls.Add(cmbUnidad);
            pnlDatosProducto.Controls.Add(lblStockMinimo);
            pnlDatosProducto.Controls.Add(nudStockMinimo);
            pnlDatosProducto.Controls.Add(chkDisponible);
            pnlDatosProducto.Controls.Add(chkActivo);
            pnlDatosProducto.Controls.Add(pnlAccionesProducto);
            pnlDatosProducto.Dock = DockStyle.Top;
            pnlDatosProducto.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlDatosProducto.Location = new Point(484, 18);
            pnlDatosProducto.Margin = new Padding(18);
            pnlDatosProducto.Name = "pnlDatosProducto";
            pnlDatosProducto.Size = new Size(420, 717);
            pnlDatosProducto.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Dock = DockStyle.Top;
            txtDescripcion.Location = new Point(0, 188);
            txtDescripcion.MaxLength = 300;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(420, 30);
            txtDescripcion.TabIndex = 8;
            // 
            // lblPrecio
            // 
            lblPrecio.Dock = DockStyle.Top;
            lblPrecio.Location = new Point(0, 168);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(420, 20);
            lblPrecio.TabIndex = 7;
            lblPrecio.Text = "Precio";
            // 
            // lblUnidad
            // 
            lblUnidad.Dock = DockStyle.Top;
            lblUnidad.ForeColor = Color.FromArgb(111, 119, 128);
            lblUnidad.Location = new Point(0, 122);
            lblUnidad.Name = "lblUnidad";
            lblUnidad.Size = new Size(420, 20);
            lblUnidad.TabIndex = 5;
            lblUnidad.Text = "Unidad de medida";
            // 
            // cmbUnidad
            // 
            cmbUnidad.Dock = DockStyle.Top;
            cmbUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnidad.FormattingEnabled = true;
            cmbUnidad.Location = new Point(0, 94);
            cmbUnidad.Name = "cmbUnidad";
            cmbUnidad.Size = new Size(420, 28);
            cmbUnidad.TabIndex = 4;
            // 
            // lblStockMinimo
            // 
            lblStockMinimo.Dock = DockStyle.Top;
            lblStockMinimo.Location = new Point(0, 74);
            lblStockMinimo.Name = "lblStockMinimo";
            lblStockMinimo.Size = new Size(420, 20);
            lblStockMinimo.TabIndex = 3;
            lblStockMinimo.Text = "Stock Minimo";
            // 
            // nudStockMinimo
            // 
            nudStockMinimo.DecimalPlaces = 2;
            nudStockMinimo.Dock = DockStyle.Top;
            nudStockMinimo.Location = new Point(0, 48);
            nudStockMinimo.Name = "nudStockMinimo";
            nudStockMinimo.Size = new Size(420, 26);
            nudStockMinimo.TabIndex = 0;
            // 
            // chkDisponible
            // 
            chkDisponible.AutoSize = true;
            chkDisponible.Checked = true;
            chkDisponible.CheckState = CheckState.Checked;
            chkDisponible.Dock = DockStyle.Top;
            chkDisponible.Location = new Point(0, 24);
            chkDisponible.Name = "chkDisponible";
            chkDisponible.Size = new Size(420, 24);
            chkDisponible.TabIndex = 2;
            chkDisponible.Text = "Disponible ";
            chkDisponible.UseVisualStyleBackColor = true;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Dock = DockStyle.Top;
            chkActivo.Location = new Point(0, 0);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(420, 24);
            chkActivo.TabIndex = 1;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // pnlAccionesProducto
            // 
            pnlAccionesProducto.Controls.Add(btnGuardarProducto);
            pnlAccionesProducto.Controls.Add(btnLimpiarProducto);
            pnlAccionesProducto.Dock = DockStyle.Bottom;
            pnlAccionesProducto.Location = new Point(0, 659);
            pnlAccionesProducto.Name = "pnlAccionesProducto";
            pnlAccionesProducto.Size = new Size(420, 58);
            pnlAccionesProducto.TabIndex = 0;
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.BackColor = Color.FromArgb(8, 126, 164);
            btnGuardarProducto.Dock = DockStyle.Right;
            btnGuardarProducto.FlatAppearance.BorderSize = 0;
            btnGuardarProducto.FlatStyle = FlatStyle.Flat;
            btnGuardarProducto.ForeColor = Color.White;
            btnGuardarProducto.Location = new Point(295, 0);
            btnGuardarProducto.Name = "btnGuardarProducto";
            btnGuardarProducto.Size = new Size(125, 58);
            btnGuardarProducto.TabIndex = 1;
            btnGuardarProducto.Text = "Guardar";
            btnGuardarProducto.UseVisualStyleBackColor = false;
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
            // Tcproductos
            // 
            Tcproductos.Controls.Add(tpReceta);
            Tcproductos.Controls.Add(tpCatalogo);
            Tcproductos.Dock = DockStyle.Fill;
            Tcproductos.Location = new Point(3, 3);
            Tcproductos.Name = "Tcproductos";
            Tcproductos.SelectedIndex = 0;
            Tcproductos.Size = new Size(460, 777);
            Tcproductos.TabIndex = 1;
            // 
            // tpReceta
            // 
            tpReceta.Location = new Point(4, 29);
            tpReceta.Name = "tpReceta";
            tpReceta.Padding = new Padding(3);
            tpReceta.Size = new Size(452, 744);
            tpReceta.TabIndex = 1;
            tpReceta.Text = "tabPage2";
            tpReceta.UseVisualStyleBackColor = true;
            // 
            // tpCatalogo
            // 
            tpCatalogo.Location = new Point(4, 29);
            tpCatalogo.Name = "tpCatalogo";
            tpCatalogo.Padding = new Padding(3);
            tpCatalogo.Size = new Size(452, 744);
            tpCatalogo.TabIndex = 0;
            tpCatalogo.Text = "tabPage1";
            tpCatalogo.UseVisualStyleBackColor = true;
            // 
            // cmbCategoria
            // 
            cmbCategoria.Dock = DockStyle.Top;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(0, 238);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(420, 28);
            cmbCategoria.TabIndex = 10;
            // 
            // lblCategoria
            // 
            lblCategoria.Dock = DockStyle.Top;
            lblCategoria.Location = new Point(0, 266);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(420, 20);
            lblCategoria.TabIndex = 11;
            lblCategoria.Text = "Categoria";
            // 
            // txtCodigo
            // 
            txtCodigo.BorderStyle = BorderStyle.FixedSingle;
            txtCodigo.Dock = DockStyle.Top;
            txtCodigo.Location = new Point(0, 332);
            txtCodigo.MaxLength = 30;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(420, 26);
            txtCodigo.TabIndex = 12;
            // 
            // lblCodigo
            // 
            lblCodigo.Dock = DockStyle.Top;
            lblCodigo.Location = new Point(0, 358);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(420, 20);
            lblCodigo.TabIndex = 13;
            lblCodigo.Text = "Código";
            // 
            // txtNombre
            // 
            txtNombre.Dock = DockStyle.Top;
            txtNombre.Location = new Point(0, 286);
            txtNombre.MaxLength = 150;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(420, 26);
            txtNombre.TabIndex = 14;
            // 
            // lblNombre
            // 
            lblNombre.Dock = DockStyle.Top;
            lblNombre.Location = new Point(0, 312);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(420, 20);
            lblNombre.TabIndex = 15;
            lblNombre.Text = "Nombre,";
            // 
            // nudPrecio
            // 
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Dock = DockStyle.Top;
            nudPrecio.Increment = new decimal(new int[] { 50, 0, 0, 131072 });
            nudPrecio.Location = new Point(0, 142);
            nudPrecio.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(420, 26);
            nudPrecio.TabIndex = 6;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Dock = DockStyle.Top;
            lblDescripcion.ForeColor = Color.FromArgb(111, 119, 128);
            lblDescripcion.Location = new Point(0, 218);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(420, 20);
            lblDescripcion.TabIndex = 16;
            lblDescripcion.Text = "Descripcion ";
            // 
            // FrmProductos
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(922, 783);
            Controls.Add(pnlBarraSuperior);
            Controls.Add(pnlContenido);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmProductos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmProductos";
            pnlBarraSuperior.ResumeLayout(false);
            tlpBarraSuperior.ResumeLayout(false);
            tlpBarraSuperior.PerformLayout();
            pnlContenido.ResumeLayout(false);
            tlpPrincipal.ResumeLayout(false);
            pnlDatosProducto.ResumeLayout(false);
            pnlDatosProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).EndInit();
            pnlAccionesProducto.ResumeLayout(false);
            Tcproductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
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
        private Label lblStockMinimo;
        private ComboBox cmbUnidad;
        private Label lblUnidad;
        private Label lblPrecio;
        private TextBox txtDescripcion;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private Label lblNombre;
        private Label lblDescripcion;
        private NumericUpDown nudPrecio;
    }
}