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
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
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
            chkActivo = new CheckBox();
            chkDisponible = new CheckBox();
            nudStockMinimo = new NumericUpDown();
            lblStockMinimo = new Label();
            cmbUnidad = new ComboBox();
            lblUnidad = new Label();
            nudPrecio = new NumericUpDown();
            lblPrecio = new Label();
            txtDescripcion = new TextBox();
            lblDescripcion = new Label();
            cmbCategoria = new ComboBox();
            lblCategoria = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtCodigo = new TextBox();
            lblCodigo = new Label();
            pnlAccionesProducto = new Panel();
            btnGuardarProducto = new Button();
            btnLimpiarProducto = new Button();
            Tcproductos = new TabControl();
            tpReceta = new TabPage();
            dgvReceta = new DataGridView();
            colIngrediente = new DataGridViewTextBoxColumn();
            colUnidadReceta = new DataGridViewTextBoxColumn();
            colCantidadReceta = new DataGridViewTextBoxColumn();
            pnlSeleccionReceta = new Panel();
            cmbProductoReceta = new ComboBox();
            pnlAccionesReceta = new Panel();
            btnGuardarReceta = new Button();
            btnQuitarIngrediente = new Button();
            btnEditarIngrediente = new Button();
            btnAgregarIngrediente = new Button();
            tpCatalogo = new TabPage();
            dgvProductos = new DataGridView();
            colCodigo = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colDisponible = new DataGridViewTextBoxColumn();
            colActivo = new DataGridViewTextBoxColumn();
            pnlBarraSuperior.SuspendLayout();
            tlpBarraSuperior.SuspendLayout();
            pnlContenido.SuspendLayout();
            tlpPrincipal.SuspendLayout();
            pnlDatosProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            pnlAccionesProducto.SuspendLayout();
            Tcproductos.SuspendLayout();
            tpReceta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReceta).BeginInit();
            pnlSeleccionReceta.SuspendLayout();
            pnlAccionesReceta.SuspendLayout();
            tpCatalogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
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
            tlpBarraSuperior.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            tlpBarraSuperior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpBarraSuperior.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpBarraSuperior.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpBarraSuperior.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 165F));
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
            btnCambiarEstado.FlatAppearance.BorderSize = 0;
            btnCambiarEstado.FlatStyle = FlatStyle.Flat;
            btnCambiarEstado.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCambiarEstado.ForeColor = Color.White;
            btnCambiarEstado.Location = new Point(736, 3);
            btnCambiarEstado.Name = "btnCambiarEstado";
            btnCambiarEstado.Size = new Size(159, 56);
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
            lblBuscar.Size = new Size(79, 62);
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
            btnNuevoProducto.FlatAppearance.BorderSize = 0;
            btnNuevoProducto.FlatStyle = FlatStyle.Flat;
            btnNuevoProducto.Font = new Font("Century Gothic", 9F);
            btnNuevoProducto.ForeColor = Color.White;
            btnNuevoProducto.Location = new Point(496, 3);
            btnNuevoProducto.Name = "btnNuevoProducto";
            btnNuevoProducto.Size = new Size(114, 56);
            btnNuevoProducto.TabIndex = 2;
            btnNuevoProducto.Text = "Nuevo";
            btnNuevoProducto.UseVisualStyleBackColor = false;
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBuscarProducto.BackColor = Color.FromArgb(238, 243, 247);
            txtBuscarProducto.BorderStyle = BorderStyle.None;
            txtBuscarProducto.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarProducto.Location = new Point(85, 20);
            txtBuscarProducto.Margin = new Padding(0);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(408, 21);
            txtBuscarProducto.TabIndex = 1;
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;
            // 
            // btnEditarProducto
            // 
            btnEditarProducto.BackColor = Color.FromArgb(238, 243, 247);
            btnEditarProducto.Cursor = Cursors.Hand;
            btnEditarProducto.Dock = DockStyle.Fill;
            btnEditarProducto.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btnEditarProducto.FlatAppearance.BorderSize = 0;
            btnEditarProducto.FlatStyle = FlatStyle.Flat;
            btnEditarProducto.Font = new Font("Century Gothic", 9F);
            btnEditarProducto.ForeColor = Color.FromArgb(8, 31, 63);
            btnEditarProducto.Location = new Point(616, 3);
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
            pnlContenido.Location = new Point(0, 78);
            pnlContenido.Margin = new Padding(3, 12, 3, 10);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(922, 705);
            pnlContenido.TabIndex = 1;
            // 
            // tlpPrincipal
            // 
            tlpPrincipal.ColumnCount = 2;
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64F));
            tlpPrincipal.Controls.Add(pnlDatosProducto, 0, 0);
            tlpPrincipal.Controls.Add(Tcproductos, 1, 0);
            tlpPrincipal.Dock = DockStyle.Fill;
            tlpPrincipal.Location = new Point(0, 0);
            tlpPrincipal.Name = "tlpPrincipal";
            tlpPrincipal.RowCount = 1;
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPrincipal.Size = new Size(922, 705);
            tlpPrincipal.TabIndex = 0;
            // 
            // pnlDatosProducto
            // 
            pnlDatosProducto.BackColor = Color.White;
            pnlDatosProducto.Controls.Add(chkActivo);
            pnlDatosProducto.Controls.Add(chkDisponible);
            pnlDatosProducto.Controls.Add(nudStockMinimo);
            pnlDatosProducto.Controls.Add(lblStockMinimo);
            pnlDatosProducto.Controls.Add(cmbUnidad);
            pnlDatosProducto.Controls.Add(lblUnidad);
            pnlDatosProducto.Controls.Add(nudPrecio);
            pnlDatosProducto.Controls.Add(lblPrecio);
            pnlDatosProducto.Controls.Add(txtDescripcion);
            pnlDatosProducto.Controls.Add(lblDescripcion);
            pnlDatosProducto.Controls.Add(cmbCategoria);
            pnlDatosProducto.Controls.Add(lblCategoria);
            pnlDatosProducto.Controls.Add(txtNombre);
            pnlDatosProducto.Controls.Add(lblNombre);
            pnlDatosProducto.Controls.Add(txtCodigo);
            pnlDatosProducto.Controls.Add(lblCodigo);
            pnlDatosProducto.Controls.Add(pnlAccionesProducto);
            pnlDatosProducto.Dock = DockStyle.Top;
            pnlDatosProducto.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlDatosProducto.Location = new Point(18, 18);
            pnlDatosProducto.Margin = new Padding(18);
            pnlDatosProducto.Name = "pnlDatosProducto";
            pnlDatosProducto.Padding = new Padding(15, 50, 15, 60);
            pnlDatosProducto.Size = new Size(295, 669);
            pnlDatosProducto.TabIndex = 0;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Dock = DockStyle.Top;
            chkActivo.Location = new Point(15, 404);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(265, 24);
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
            chkDisponible.Location = new Point(15, 380);
            chkDisponible.Name = "chkDisponible";
            chkDisponible.Size = new Size(265, 24);
            chkDisponible.TabIndex = 2;
            chkDisponible.Text = "Disponible ";
            chkDisponible.UseVisualStyleBackColor = true;
            // 
            // nudStockMinimo
            // 
            nudStockMinimo.DecimalPlaces = 2;
            nudStockMinimo.Dock = DockStyle.Top;
            nudStockMinimo.Location = new Point(15, 354);
            nudStockMinimo.Name = "nudStockMinimo";
            nudStockMinimo.Size = new Size(265, 26);
            nudStockMinimo.TabIndex = 0;
            // 
            // lblStockMinimo
            // 
            lblStockMinimo.Dock = DockStyle.Top;
            lblStockMinimo.Location = new Point(15, 334);
            lblStockMinimo.Name = "lblStockMinimo";
            lblStockMinimo.Size = new Size(265, 20);
            lblStockMinimo.TabIndex = 3;
            lblStockMinimo.Text = "Stock Minimo";
            // 
            // cmbUnidad
            // 
            cmbUnidad.Dock = DockStyle.Top;
            cmbUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnidad.FormattingEnabled = true;
            cmbUnidad.Location = new Point(15, 306);
            cmbUnidad.Name = "cmbUnidad";
            cmbUnidad.Size = new Size(265, 28);
            cmbUnidad.TabIndex = 4;
            // 
            // lblUnidad
            // 
            lblUnidad.Dock = DockStyle.Top;
            lblUnidad.ForeColor = Color.FromArgb(111, 119, 128);
            lblUnidad.Location = new Point(15, 286);
            lblUnidad.Name = "lblUnidad";
            lblUnidad.Size = new Size(265, 20);
            lblUnidad.TabIndex = 5;
            lblUnidad.Text = "Unidad de medida";
            // 
            // nudPrecio
            // 
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Dock = DockStyle.Top;
            nudPrecio.Increment = new decimal(new int[] { 50, 0, 0, 131072 });
            nudPrecio.Location = new Point(15, 260);
            nudPrecio.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(265, 26);
            nudPrecio.TabIndex = 6;
            // 
            // lblPrecio
            // 
            lblPrecio.Dock = DockStyle.Top;
            lblPrecio.Location = new Point(15, 240);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(265, 20);
            lblPrecio.TabIndex = 7;
            lblPrecio.Text = "Precio";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Dock = DockStyle.Top;
            txtDescripcion.Location = new Point(15, 210);
            txtDescripcion.MaxLength = 300;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(265, 30);
            txtDescripcion.TabIndex = 8;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Dock = DockStyle.Top;
            lblDescripcion.ForeColor = Color.FromArgb(111, 119, 128);
            lblDescripcion.Location = new Point(15, 190);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(265, 20);
            lblDescripcion.TabIndex = 16;
            lblDescripcion.Text = "Descripcion ";
            // 
            // cmbCategoria
            // 
            cmbCategoria.Dock = DockStyle.Top;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(15, 162);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(265, 28);
            cmbCategoria.TabIndex = 10;
            // 
            // lblCategoria
            // 
            lblCategoria.Dock = DockStyle.Top;
            lblCategoria.Location = new Point(15, 142);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(265, 20);
            lblCategoria.TabIndex = 11;
            lblCategoria.Text = "Categoria";
            // 
            // txtNombre
            // 
            txtNombre.Dock = DockStyle.Top;
            txtNombre.Location = new Point(15, 116);
            txtNombre.MaxLength = 150;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(265, 26);
            txtNombre.TabIndex = 14;
            // 
            // lblNombre
            // 
            lblNombre.Dock = DockStyle.Top;
            lblNombre.Location = new Point(15, 96);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(265, 20);
            lblNombre.TabIndex = 15;
            lblNombre.Text = "Nombre,";
            // 
            // txtCodigo
            // 
            txtCodigo.BorderStyle = BorderStyle.FixedSingle;
            txtCodigo.Dock = DockStyle.Top;
            txtCodigo.Location = new Point(15, 70);
            txtCodigo.MaxLength = 30;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(265, 26);
            txtCodigo.TabIndex = 12;
            // 
            // lblCodigo
            // 
            lblCodigo.Dock = DockStyle.Top;
            lblCodigo.Location = new Point(15, 50);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(265, 20);
            lblCodigo.TabIndex = 13;
            lblCodigo.Text = "Código";
            // 
            // pnlAccionesProducto
            // 
            pnlAccionesProducto.Controls.Add(btnGuardarProducto);
            pnlAccionesProducto.Controls.Add(btnLimpiarProducto);
            pnlAccionesProducto.Dock = DockStyle.Bottom;
            pnlAccionesProducto.Location = new Point(15, 551);
            pnlAccionesProducto.Name = "pnlAccionesProducto";
            pnlAccionesProducto.Size = new Size(265, 58);
            pnlAccionesProducto.TabIndex = 0;
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.BackColor = Color.FromArgb(8, 126, 164);
            btnGuardarProducto.Dock = DockStyle.Right;
            btnGuardarProducto.FlatAppearance.BorderSize = 0;
            btnGuardarProducto.FlatStyle = FlatStyle.Flat;
            btnGuardarProducto.ForeColor = Color.White;
            btnGuardarProducto.Location = new Point(140, 0);
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
            Tcproductos.Location = new Point(334, 3);
            Tcproductos.Name = "Tcproductos";
            Tcproductos.Padding = new Point(14, 10);
            Tcproductos.SelectedIndex = 0;
            Tcproductos.Size = new Size(585, 699);
            Tcproductos.TabIndex = 1;
            // 
            // tpReceta
            // 
            tpReceta.BackColor = Color.FromArgb(14, 158, 45, 18);
            tpReceta.Controls.Add(dgvReceta);
            tpReceta.Controls.Add(pnlSeleccionReceta);
            tpReceta.Controls.Add(pnlAccionesReceta);
            tpReceta.Location = new Point(4, 43);
            tpReceta.Name = "tpReceta";
            tpReceta.Padding = new Padding(3);
            tpReceta.Size = new Size(577, 652);
            tpReceta.TabIndex = 1;
            tpReceta.Text = "Receta";
            // 
            // dgvReceta
            // 
            dgvReceta.AllowUserToAddRows = false;
            dgvReceta.AllowUserToDeleteRows = false;
            dgvReceta.AllowUserToOrderColumns = true;
            dgvReceta.AllowUserToResizeColumns = false;
            dgvReceta.AllowUserToResizeRows = false;
            dgvReceta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReceta.BorderStyle = BorderStyle.None;
            dgvReceta.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReceta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReceta.Columns.AddRange(new DataGridViewColumn[] { colIngrediente, colUnidadReceta, colCantidadReceta });
            dgvReceta.Dock = DockStyle.Fill;
            dgvReceta.EnableHeadersVisualStyles = false;
            dgvReceta.GridColor = Color.FromArgb(230, 234, 238);
            dgvReceta.Location = new Point(3, 48);
            dgvReceta.MultiSelect = false;
            dgvReceta.Name = "dgvReceta";
            dgvReceta.ReadOnly = true;
            dgvReceta.RowHeadersVisible = false;
            dgvReceta.RowHeadersWidth = 51;
            dgvReceta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReceta.Size = new Size(571, 543);
            dgvReceta.TabIndex = 2;
            // 
            // colIngrediente
            // 
            colIngrediente.DataPropertyName = "IngredientName";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colIngrediente.DefaultCellStyle = dataGridViewCellStyle10;
            colIngrediente.FillWeight = 210F;
            colIngrediente.HeaderText = "Ingrediente";
            colIngrediente.MinimumWidth = 6;
            colIngrediente.Name = "colIngrediente";
            colIngrediente.ReadOnly = true;
            // 
            // colUnidadReceta
            // 
            colUnidadReceta.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colUnidadReceta.DataPropertyName = "UnitName";
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colUnidadReceta.DefaultCellStyle = dataGridViewCellStyle11;
            colUnidadReceta.FillWeight = 90F;
            colUnidadReceta.HeaderText = "Unidad";
            colUnidadReceta.MinimumWidth = 6;
            colUnidadReceta.Name = "colUnidadReceta";
            colUnidadReceta.ReadOnly = true;
            colUnidadReceta.Width = 125;
            // 
            // colCantidadReceta
            // 
            colCantidadReceta.DataPropertyName = "Quantity";
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "#,##0.00";
            colCantidadReceta.DefaultCellStyle = dataGridViewCellStyle12;
            colCantidadReceta.HeaderText = "Cantidad";
            colCantidadReceta.MinimumWidth = 6;
            colCantidadReceta.Name = "colCantidadReceta";
            colCantidadReceta.ReadOnly = true;
            // 
            // pnlSeleccionReceta
            // 
            pnlSeleccionReceta.BackColor = Color.White;
            pnlSeleccionReceta.Controls.Add(cmbProductoReceta);
            pnlSeleccionReceta.Dock = DockStyle.Top;
            pnlSeleccionReceta.Location = new Point(3, 3);
            pnlSeleccionReceta.Name = "pnlSeleccionReceta";
            pnlSeleccionReceta.Padding = new Padding(10, 8, 10, 8);
            pnlSeleccionReceta.Size = new Size(571, 45);
            pnlSeleccionReceta.TabIndex = 0;
            // 
            // cmbProductoReceta
            // 
            cmbProductoReceta.Dock = DockStyle.Top;
            cmbProductoReceta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductoReceta.FormattingEnabled = true;
            cmbProductoReceta.Location = new Point(10, 8);
            cmbProductoReceta.Name = "cmbProductoReceta";
            cmbProductoReceta.Size = new Size(551, 28);
            cmbProductoReceta.TabIndex = 0;
            // 
            // pnlAccionesReceta
            // 
            pnlAccionesReceta.BackColor = Color.White;
            pnlAccionesReceta.Controls.Add(btnGuardarReceta);
            pnlAccionesReceta.Controls.Add(btnQuitarIngrediente);
            pnlAccionesReceta.Controls.Add(btnEditarIngrediente);
            pnlAccionesReceta.Controls.Add(btnAgregarIngrediente);
            pnlAccionesReceta.Dock = DockStyle.Bottom;
            pnlAccionesReceta.Location = new Point(3, 591);
            pnlAccionesReceta.Name = "pnlAccionesReceta";
            pnlAccionesReceta.Size = new Size(571, 58);
            pnlAccionesReceta.TabIndex = 1;
            // 
            // btnGuardarReceta
            // 
            btnGuardarReceta.Dock = DockStyle.Right;
            btnGuardarReceta.FlatAppearance.BorderSize = 0;
            btnGuardarReceta.FlatStyle = FlatStyle.Flat;
            btnGuardarReceta.ForeColor = Color.FromArgb(64, 64, 64);
            btnGuardarReceta.Location = new Point(421, 0);
            btnGuardarReceta.Name = "btnGuardarReceta";
            btnGuardarReceta.Size = new Size(150, 58);
            btnGuardarReceta.TabIndex = 0;
            btnGuardarReceta.Text = "Guardar receta";
            btnGuardarReceta.UseVisualStyleBackColor = true;
            // 
            // btnQuitarIngrediente
            // 
            btnQuitarIngrediente.BackColor = Color.IndianRed;
            btnQuitarIngrediente.Dock = DockStyle.Left;
            btnQuitarIngrediente.FlatAppearance.BorderSize = 0;
            btnQuitarIngrediente.FlatStyle = FlatStyle.Flat;
            btnQuitarIngrediente.ForeColor = Color.White;
            btnQuitarIngrediente.Location = new Point(240, 0);
            btnQuitarIngrediente.Name = "btnQuitarIngrediente";
            btnQuitarIngrediente.Size = new Size(120, 58);
            btnQuitarIngrediente.TabIndex = 1;
            btnQuitarIngrediente.Text = "Quitar";
            btnQuitarIngrediente.UseVisualStyleBackColor = false;
            // 
            // btnEditarIngrediente
            // 
            btnEditarIngrediente.BackColor = Color.FromArgb(14, 51, 77, 175);
            btnEditarIngrediente.Dock = DockStyle.Left;
            btnEditarIngrediente.FlatAppearance.BorderSize = 0;
            btnEditarIngrediente.FlatStyle = FlatStyle.Flat;
            btnEditarIngrediente.ForeColor = Color.FromArgb(0, 1, 68, 219);
            btnEditarIngrediente.Location = new Point(120, 0);
            btnEditarIngrediente.Name = "btnEditarIngrediente";
            btnEditarIngrediente.Size = new Size(120, 58);
            btnEditarIngrediente.TabIndex = 2;
            btnEditarIngrediente.Text = "Editar";
            btnEditarIngrediente.UseVisualStyleBackColor = false;
            // 
            // btnAgregarIngrediente
            // 
            btnAgregarIngrediente.BackColor = Color.FromArgb(14, 51, 77, 175);
            btnAgregarIngrediente.Dock = DockStyle.Left;
            btnAgregarIngrediente.FlatAppearance.BorderSize = 0;
            btnAgregarIngrediente.FlatStyle = FlatStyle.Flat;
            btnAgregarIngrediente.ForeColor = Color.FromArgb(0, 1, 68, 219);
            btnAgregarIngrediente.Location = new Point(0, 0);
            btnAgregarIngrediente.Name = "btnAgregarIngrediente";
            btnAgregarIngrediente.Size = new Size(120, 58);
            btnAgregarIngrediente.TabIndex = 3;
            btnAgregarIngrediente.Text = "Agregar";
            btnAgregarIngrediente.UseVisualStyleBackColor = false;
            // 
            // tpCatalogo
            // 
            tpCatalogo.Controls.Add(dgvProductos);
            tpCatalogo.Location = new Point(4, 43);
            tpCatalogo.Name = "tpCatalogo";
            tpCatalogo.Padding = new Padding(3);
            tpCatalogo.Size = new Size(577, 652);
            tpCatalogo.TabIndex = 0;
            tpCatalogo.Text = "Catalogo";
            tpCatalogo.UseVisualStyleBackColor = true;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { colCodigo, colNombre, colCategoria, colPrecio, colDisponible, colActivo });
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.Location = new Point(3, 3);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.RowTemplate.Height = 38;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(571, 646);
            dgvProductos.TabIndex = 0;
            dgvProductos.CellFormatting += dgvProductos_CellFormatting;
            // 
            // colCodigo
            // 
            colCodigo.DataPropertyName = "ProductCode";
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCodigo.DefaultCellStyle = dataGridViewCellStyle13;
            colCodigo.HeaderText = "Código";
            colCodigo.MinimumWidth = 6;
            colCodigo.Name = "colCodigo";
            colCodigo.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.DataPropertyName = "ProductName";
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colNombre.DefaultCellStyle = dataGridViewCellStyle14;
            colNombre.HeaderText = "Producto";
            colNombre.MinimumWidth = 6;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colCategoria
            // 
            colCategoria.DataPropertyName = "CategoryName";
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colCategoria.DefaultCellStyle = dataGridViewCellStyle15;
            colCategoria.HeaderText = "Categoría";
            colCategoria.MinimumWidth = 6;
            colCategoria.Name = "colCategoria";
            colCategoria.ReadOnly = true;
            // 
            // colPrecio
            // 
            colPrecio.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "\"C$ \"#,##0.00";
            colPrecio.DefaultCellStyle = dataGridViewCellStyle16;
            colPrecio.HeaderText = "Precio";
            colPrecio.MinimumWidth = 6;
            colPrecio.Name = "colPrecio";
            colPrecio.ReadOnly = true;
            // 
            // colDisponible
            // 
            colDisponible.DataPropertyName = "IsAvailable";
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDisponible.DefaultCellStyle = dataGridViewCellStyle17;
            colDisponible.HeaderText = "Disponible";
            colDisponible.MinimumWidth = 6;
            colDisponible.Name = "colDisponible";
            colDisponible.ReadOnly = true;
            // 
            // colActivo
            // 
            colActivo.DataPropertyName = "IsActive";
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colActivo.DefaultCellStyle = dataGridViewCellStyle18;
            colActivo.HeaderText = "Estado";
            colActivo.MinimumWidth = 6;
            colActivo.Name = "colActivo";
            colActivo.ReadOnly = true;
            // 
            // FrmProductos
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(922, 783);
            Controls.Add(pnlContenido);
            Controls.Add(pnlBarraSuperior);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmProductos";
            StartPosition = FormStartPosition.CenterParent;
            Text = " ";
            pnlBarraSuperior.ResumeLayout(false);
            tlpBarraSuperior.ResumeLayout(false);
            tlpBarraSuperior.PerformLayout();
            pnlContenido.ResumeLayout(false);
            tlpPrincipal.ResumeLayout(false);
            pnlDatosProducto.ResumeLayout(false);
            pnlDatosProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            pnlAccionesProducto.ResumeLayout(false);
            Tcproductos.ResumeLayout(false);
            tpReceta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReceta).EndInit();
            pnlSeleccionReceta.ResumeLayout(false);
            pnlAccionesReceta.ResumeLayout(false);
            tpCatalogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
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
        private DataGridView dgvProductos;
        private Panel pnlSeleccionReceta;
        private ComboBox cmbProductoReceta;
        private Panel pnlAccionesReceta;
        private Button btnQuitarIngrediente;
        private Button btnGuardarReceta;
        private Button btnEditarIngrediente;
        private Button btnAgregarIngrediente;
        private DataGridView dgvReceta;
        private DataGridViewTextBoxColumn colIngrediente;
        private DataGridViewTextBoxColumn colUnidadReceta;
        private DataGridViewTextBoxColumn colCantidadReceta;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colDisponible;
        private DataGridViewTextBoxColumn colActivo;
    }
}