namespace Ocean_Desk_dv.UI.Catalogs
{
    partial class FrmPuntoVenta
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
            pnlTop = new Panel();
            tlpTop = new TableLayoutPanel();
            pnlCliente = new Panel();
            comboBox1 = new ComboBox();
            lblCliente = new Label();
            pnlMesa = new Panel();
            cmbMesa = new ComboBox();
            lblMesa = new Label();
            pnlTipoOrden = new Panel();
            cmbTipoOrden = new ComboBox();
            lblTipoOrden = new Label();
            pnlBusqueda = new Panel();
            pnlSearchInput = new Panel();
            txtBuscarProducto = new TextBox();
            pnlRayita = new Panel();
            lblGhost = new Label();
            pictureBox1 = new PictureBox();
            pnlProducts = new Panel();
            flpProducts = new FlowLayoutPanel();
            pnlCategories = new Panel();
            tlpCategories = new TableLayoutPanel();
            btnCatTodos = new Button();
            btnCatExtras = new Button();
            btnCatBebidas = new Button();
            btnCatEntradas = new Button();
            btnCatMariscos = new Button();
            btnCatCeviche = new Button();
            pnlOrder = new Panel();
            flpOrderItems = new FlowLayoutPanel();
            pnlOrderFooter = new Panel();
            pnlAcciones = new Panel();
            btnCobrar = new Button();
            btnCancelarVenta = new Button();
            tlpTotal = new TableLayoutPanel();
            lblTotalTexto = new Label();
            lblTotal = new Label();
            pnlSeparador = new Panel();
            tlpOrderFooter = new TableLayoutPanel();
            lblSubtotalTexto = new Label();
            lblSubtotal = new Label();
            lblDescuentoTexto = new Label();
            lblDescuento = new Label();
            pnlOrderHeader = new Panel();
            lblOrderTitle = new Label();
            pnlTop.SuspendLayout();
            tlpTop.SuspendLayout();
            pnlCliente.SuspendLayout();
            pnlMesa.SuspendLayout();
            pnlTipoOrden.SuspendLayout();
            pnlBusqueda.SuspendLayout();
            pnlSearchInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlProducts.SuspendLayout();
            pnlCategories.SuspendLayout();
            tlpCategories.SuspendLayout();
            pnlOrder.SuspendLayout();
            pnlOrderFooter.SuspendLayout();
            pnlAcciones.SuspendLayout();
            tlpTotal.SuspendLayout();
            tlpOrderFooter.SuspendLayout();
            pnlOrderHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(tlpTop);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(10, 8, 10, 8);
            pnlTop.Size = new Size(940, 75);
            pnlTop.TabIndex = 0;
            // 
            // tlpTop
            // 
            tlpTop.ColumnCount = 4;
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTop.Controls.Add(pnlCliente, 3, 0);
            tlpTop.Controls.Add(pnlMesa, 2, 0);
            tlpTop.Controls.Add(pnlTipoOrden, 1, 0);
            tlpTop.Controls.Add(pnlBusqueda, 0, 0);
            tlpTop.Dock = DockStyle.Fill;
            tlpTop.Location = new Point(10, 8);
            tlpTop.Margin = new Padding(0);
            tlpTop.Name = "tlpTop";
            tlpTop.Padding = new Padding(0, 3, 0, 3);
            tlpTop.RowCount = 1;
            tlpTop.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTop.Size = new Size(920, 59);
            tlpTop.TabIndex = 0;
            // 
            // pnlCliente
            // 
            pnlCliente.Controls.Add(comboBox1);
            pnlCliente.Controls.Add(lblCliente);
            pnlCliente.Dock = DockStyle.Fill;
            pnlCliente.Location = new Point(690, 3);
            pnlCliente.Margin = new Padding(0, 0, 10, 0);
            pnlCliente.Name = "pnlCliente";
            pnlCliente.Padding = new Padding(0, 3, 0, 3);
            pnlCliente.Size = new Size(220, 53);
            pnlCliente.TabIndex = 7;
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(0, 23);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(220, 29);
            comboBox1.TabIndex = 8;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Dock = DockStyle.Top;
            lblCliente.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCliente.ForeColor = Color.FromArgb(95, 104, 114);
            lblCliente.Location = new Point(0, 3);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(65, 20);
            lblCliente.TabIndex = 7;
            lblCliente.Text = "Cliente:";
            // 
            // pnlMesa
            // 
            pnlMesa.Controls.Add(cmbMesa);
            pnlMesa.Controls.Add(lblMesa);
            pnlMesa.Dock = DockStyle.Fill;
            pnlMesa.Location = new Point(506, 3);
            pnlMesa.Margin = new Padding(0, 0, 10, 0);
            pnlMesa.Name = "pnlMesa";
            pnlMesa.Padding = new Padding(0, 3, 0, 3);
            pnlMesa.Size = new Size(174, 53);
            pnlMesa.TabIndex = 7;
            // 
            // cmbMesa
            // 
            cmbMesa.Dock = DockStyle.Fill;
            cmbMesa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMesa.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMesa.FormattingEnabled = true;
            cmbMesa.Items.AddRange(new object[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10" });
            cmbMesa.Location = new Point(0, 23);
            cmbMesa.Name = "cmbMesa";
            cmbMesa.Size = new Size(174, 29);
            cmbMesa.TabIndex = 12;
            // 
            // lblMesa
            // 
            lblMesa.AutoSize = true;
            lblMesa.Dock = DockStyle.Top;
            lblMesa.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMesa.ForeColor = Color.FromArgb(95, 104, 114);
            lblMesa.Location = new Point(0, 3);
            lblMesa.Name = "lblMesa";
            lblMesa.Size = new Size(54, 20);
            lblMesa.TabIndex = 11;
            lblMesa.Text = "Mesa:";
            // 
            // pnlTipoOrden
            // 
            pnlTipoOrden.Controls.Add(cmbTipoOrden);
            pnlTipoOrden.Controls.Add(lblTipoOrden);
            pnlTipoOrden.Dock = DockStyle.Fill;
            pnlTipoOrden.Location = new Point(322, 3);
            pnlTipoOrden.Margin = new Padding(0, 0, 10, 0);
            pnlTipoOrden.Name = "pnlTipoOrden";
            pnlTipoOrden.Padding = new Padding(0, 3, 0, 3);
            pnlTipoOrden.Size = new Size(174, 53);
            pnlTipoOrden.TabIndex = 11;
            // 
            // cmbTipoOrden
            // 
            cmbTipoOrden.Dock = DockStyle.Fill;
            cmbTipoOrden.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoOrden.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTipoOrden.FormattingEnabled = true;
            cmbTipoOrden.Location = new Point(0, 23);
            cmbTipoOrden.Name = "cmbTipoOrden";
            cmbTipoOrden.RightToLeft = RightToLeft.No;
            cmbTipoOrden.Size = new Size(174, 29);
            cmbTipoOrden.TabIndex = 10;
            cmbTipoOrden.SelectedIndexChanged += cmbTipoOrden_SelectedIndexChanged;
            // 
            // lblTipoOrden
            // 
            lblTipoOrden.Dock = DockStyle.Top;
            lblTipoOrden.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTipoOrden.ForeColor = Color.FromArgb(95, 104, 114);
            lblTipoOrden.Location = new Point(0, 3);
            lblTipoOrden.Name = "lblTipoOrden";
            lblTipoOrden.Size = new Size(174, 20);
            lblTipoOrden.TabIndex = 9;
            lblTipoOrden.Text = "Tipo de orden:";
            lblTipoOrden.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlBusqueda
            // 
            pnlBusqueda.BackColor = Color.FromArgb(245, 247, 250);
            pnlBusqueda.Controls.Add(pnlSearchInput);
            pnlBusqueda.Controls.Add(lblGhost);
            pnlBusqueda.Controls.Add(pictureBox1);
            pnlBusqueda.Dock = DockStyle.Fill;
            pnlBusqueda.Location = new Point(0, 3);
            pnlBusqueda.Margin = new Padding(0, 0, 10, 0);
            pnlBusqueda.Name = "pnlBusqueda";
            pnlBusqueda.Padding = new Padding(3, 3, 5, 3);
            pnlBusqueda.Size = new Size(312, 53);
            pnlBusqueda.TabIndex = 13;
            // 
            // pnlSearchInput
            // 
            pnlSearchInput.BackColor = Color.White;
            pnlSearchInput.Controls.Add(txtBuscarProducto);
            pnlSearchInput.Controls.Add(pnlRayita);
            pnlSearchInput.Dock = DockStyle.Top;
            pnlSearchInput.Location = new Point(38, 13);
            pnlSearchInput.Name = "pnlSearchInput";
            pnlSearchInput.Size = new Size(269, 30);
            pnlSearchInput.TabIndex = 0;
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.BorderStyle = BorderStyle.None;
            txtBuscarProducto.Dock = DockStyle.Top;
            txtBuscarProducto.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarProducto.Location = new Point(0, 0);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.PlaceholderText = "Buscar Producto...";
            txtBuscarProducto.Size = new Size(269, 21);
            txtBuscarProducto.TabIndex = 0;
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;
            // 
            // pnlRayita
            // 
            pnlRayita.BackColor = Color.MidnightBlue;
            pnlRayita.Dock = DockStyle.Bottom;
            pnlRayita.Location = new Point(0, 28);
            pnlRayita.Name = "pnlRayita";
            pnlRayita.Size = new Size(269, 2);
            pnlRayita.TabIndex = 5;
            // 
            // lblGhost
            // 
            lblGhost.Dock = DockStyle.Top;
            lblGhost.ForeColor = Color.FromArgb(245, 247, 250);
            lblGhost.Location = new Point(38, 3);
            lblGhost.Name = "lblGhost";
            lblGhost.Size = new Size(269, 10);
            lblGhost.TabIndex = 2;
            lblGhost.Text = "label1";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.magnifier;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 47);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pnlProducts
            // 
            pnlProducts.Controls.Add(flpProducts);
            pnlProducts.Controls.Add(pnlCategories);
            pnlProducts.Dock = DockStyle.Fill;
            pnlProducts.Location = new Point(0, 75);
            pnlProducts.Name = "pnlProducts";
            pnlProducts.Padding = new Padding(15);
            pnlProducts.Size = new Size(560, 755);
            pnlProducts.TabIndex = 1;
            // 
            // flpProducts
            // 
            flpProducts.AutoScroll = true;
            flpProducts.BackColor = Color.Transparent;
            flpProducts.Dock = DockStyle.Fill;
            flpProducts.Location = new Point(15, 80);
            flpProducts.Margin = new Padding(0);
            flpProducts.Name = "flpProducts";
            flpProducts.Padding = new Padding(5);
            flpProducts.Size = new Size(530, 660);
            flpProducts.TabIndex = 2;
            // 
            // pnlCategories
            // 
            pnlCategories.BackColor = Color.Transparent;
            pnlCategories.Controls.Add(tlpCategories);
            pnlCategories.Dock = DockStyle.Top;
            pnlCategories.Location = new Point(15, 15);
            pnlCategories.Name = "pnlCategories";
            pnlCategories.Padding = new Padding(0, 5, 0, 5);
            pnlCategories.Size = new Size(530, 65);
            pnlCategories.TabIndex = 1;
            // 
            // tlpCategories
            // 
            tlpCategories.ColumnCount = 6;
            tlpCategories.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tlpCategories.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tlpCategories.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tlpCategories.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tlpCategories.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tlpCategories.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tlpCategories.Controls.Add(btnCatTodos, 0, 0);
            tlpCategories.Controls.Add(btnCatExtras, 5, 0);
            tlpCategories.Controls.Add(btnCatBebidas, 4, 0);
            tlpCategories.Controls.Add(btnCatEntradas, 3, 0);
            tlpCategories.Controls.Add(btnCatMariscos, 2, 0);
            tlpCategories.Controls.Add(btnCatCeviche, 1, 0);
            tlpCategories.Dock = DockStyle.Fill;
            tlpCategories.Location = new Point(0, 5);
            tlpCategories.Name = "tlpCategories";
            tlpCategories.RowCount = 1;
            tlpCategories.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpCategories.Size = new Size(530, 55);
            tlpCategories.TabIndex = 0;
            // 
            // btnCatTodos
            // 
            btnCatTodos.BackColor = Color.FromArgb(8, 31, 63);
            btnCatTodos.Cursor = Cursors.Hand;
            btnCatTodos.Dock = DockStyle.Fill;
            btnCatTodos.FlatAppearance.BorderSize = 0;
            btnCatTodos.FlatStyle = FlatStyle.Flat;
            btnCatTodos.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCatTodos.ForeColor = Color.White;
            btnCatTodos.Location = new Point(4, 3);
            btnCatTodos.Margin = new Padding(4, 3, 4, 3);
            btnCatTodos.Name = "btnCatTodos";
            btnCatTodos.Size = new Size(80, 49);
            btnCatTodos.TabIndex = 5;
            btnCatTodos.TabStop = false;
            btnCatTodos.Text = "Todos";
            btnCatTodos.UseVisualStyleBackColor = false;
            // 
            // btnCatExtras
            // 
            btnCatExtras.BackColor = Color.FromArgb(8, 31, 63);
            btnCatExtras.Cursor = Cursors.Hand;
            btnCatExtras.Dock = DockStyle.Fill;
            btnCatExtras.FlatAppearance.BorderSize = 0;
            btnCatExtras.FlatStyle = FlatStyle.Flat;
            btnCatExtras.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCatExtras.ForeColor = Color.White;
            btnCatExtras.Location = new Point(444, 3);
            btnCatExtras.Margin = new Padding(4, 3, 4, 3);
            btnCatExtras.Name = "btnCatExtras";
            btnCatExtras.Size = new Size(82, 49);
            btnCatExtras.TabIndex = 4;
            btnCatExtras.TabStop = false;
            btnCatExtras.Text = "Extras";
            btnCatExtras.UseVisualStyleBackColor = false;
            // 
            // btnCatBebidas
            // 
            btnCatBebidas.BackColor = Color.FromArgb(8, 31, 63);
            btnCatBebidas.Cursor = Cursors.Hand;
            btnCatBebidas.Dock = DockStyle.Fill;
            btnCatBebidas.FlatAppearance.BorderSize = 0;
            btnCatBebidas.FlatStyle = FlatStyle.Flat;
            btnCatBebidas.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCatBebidas.ForeColor = Color.White;
            btnCatBebidas.Location = new Point(356, 3);
            btnCatBebidas.Margin = new Padding(4, 3, 4, 3);
            btnCatBebidas.Name = "btnCatBebidas";
            btnCatBebidas.Size = new Size(80, 49);
            btnCatBebidas.TabIndex = 3;
            btnCatBebidas.TabStop = false;
            btnCatBebidas.Text = "Bebidas";
            btnCatBebidas.UseVisualStyleBackColor = false;
            // 
            // btnCatEntradas
            // 
            btnCatEntradas.BackColor = Color.FromArgb(8, 31, 63);
            btnCatEntradas.Cursor = Cursors.Hand;
            btnCatEntradas.Dock = DockStyle.Fill;
            btnCatEntradas.FlatAppearance.BorderSize = 0;
            btnCatEntradas.FlatStyle = FlatStyle.Flat;
            btnCatEntradas.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCatEntradas.ForeColor = Color.White;
            btnCatEntradas.Location = new Point(268, 3);
            btnCatEntradas.Margin = new Padding(4, 3, 4, 3);
            btnCatEntradas.Name = "btnCatEntradas";
            btnCatEntradas.Size = new Size(80, 49);
            btnCatEntradas.TabIndex = 2;
            btnCatEntradas.TabStop = false;
            btnCatEntradas.Text = "Entradas";
            btnCatEntradas.UseVisualStyleBackColor = false;
            // 
            // btnCatMariscos
            // 
            btnCatMariscos.BackColor = Color.FromArgb(8, 31, 63);
            btnCatMariscos.Cursor = Cursors.Hand;
            btnCatMariscos.Dock = DockStyle.Fill;
            btnCatMariscos.FlatAppearance.BorderSize = 0;
            btnCatMariscos.FlatStyle = FlatStyle.Flat;
            btnCatMariscos.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCatMariscos.ForeColor = Color.White;
            btnCatMariscos.Location = new Point(180, 3);
            btnCatMariscos.Margin = new Padding(4, 3, 4, 3);
            btnCatMariscos.Name = "btnCatMariscos";
            btnCatMariscos.Size = new Size(80, 49);
            btnCatMariscos.TabIndex = 1;
            btnCatMariscos.TabStop = false;
            btnCatMariscos.Text = "Mariscos";
            btnCatMariscos.UseVisualStyleBackColor = false;
            // 
            // btnCatCeviche
            // 
            btnCatCeviche.BackColor = Color.FromArgb(8, 31, 63);
            btnCatCeviche.Cursor = Cursors.Hand;
            btnCatCeviche.Dock = DockStyle.Fill;
            btnCatCeviche.FlatAppearance.BorderSize = 0;
            btnCatCeviche.FlatStyle = FlatStyle.Flat;
            btnCatCeviche.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCatCeviche.ForeColor = Color.White;
            btnCatCeviche.Location = new Point(92, 3);
            btnCatCeviche.Margin = new Padding(4, 3, 4, 3);
            btnCatCeviche.Name = "btnCatCeviche";
            btnCatCeviche.Size = new Size(80, 49);
            btnCatCeviche.TabIndex = 5;
            btnCatCeviche.TabStop = false;
            btnCatCeviche.Text = "Ceviches";
            btnCatCeviche.UseVisualStyleBackColor = false;
            // 
            // pnlOrder
            // 
            pnlOrder.BackColor = Color.FromArgb(8, 31, 63);
            pnlOrder.Controls.Add(flpOrderItems);
            pnlOrder.Controls.Add(pnlOrderFooter);
            pnlOrder.Controls.Add(pnlOrderHeader);
            pnlOrder.Dock = DockStyle.Right;
            pnlOrder.Location = new Point(560, 75);
            pnlOrder.Name = "pnlOrder";
            pnlOrder.Padding = new Padding(15);
            pnlOrder.Size = new Size(380, 755);
            pnlOrder.TabIndex = 0;
            // 
            // flpOrderItems
            // 
            flpOrderItems.AutoScroll = true;
            flpOrderItems.BackColor = Color.FromArgb(245, 247, 250);
            flpOrderItems.BorderStyle = BorderStyle.FixedSingle;
            flpOrderItems.Dock = DockStyle.Fill;
            flpOrderItems.FlowDirection = FlowDirection.TopDown;
            flpOrderItems.Location = new Point(15, 70);
            flpOrderItems.Name = "flpOrderItems";
            flpOrderItems.Padding = new Padding(5);
            flpOrderItems.Size = new Size(350, 490);
            flpOrderItems.TabIndex = 1;
            flpOrderItems.WrapContents = false;
            // 
            // pnlOrderFooter
            // 
            pnlOrderFooter.BackColor = Color.Transparent;
            pnlOrderFooter.Controls.Add(pnlAcciones);
            pnlOrderFooter.Controls.Add(tlpTotal);
            pnlOrderFooter.Controls.Add(pnlSeparador);
            pnlOrderFooter.Controls.Add(tlpOrderFooter);
            pnlOrderFooter.Dock = DockStyle.Bottom;
            pnlOrderFooter.Location = new Point(15, 560);
            pnlOrderFooter.Name = "pnlOrderFooter";
            pnlOrderFooter.Padding = new Padding(10, 10, 5, 5);
            pnlOrderFooter.Size = new Size(350, 180);
            pnlOrderFooter.TabIndex = 2;
            // 
            // pnlAcciones
            // 
            pnlAcciones.Controls.Add(btnCobrar);
            pnlAcciones.Controls.Add(btnCancelarVenta);
            pnlAcciones.Dock = DockStyle.Bottom;
            pnlAcciones.Location = new Point(10, 125);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Size = new Size(335, 50);
            pnlAcciones.TabIndex = 9;
            // 
            // btnCobrar
            // 
            btnCobrar.BackColor = Color.FromArgb(8, 126, 164);
            btnCobrar.Cursor = Cursors.Hand;
            btnCobrar.Dock = DockStyle.Right;
            btnCobrar.FlatAppearance.BorderSize = 0;
            btnCobrar.FlatStyle = FlatStyle.Flat;
            btnCobrar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCobrar.ForeColor = Color.White;
            btnCobrar.Location = new Point(155, 0);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(180, 50);
            btnCobrar.TabIndex = 10;
            btnCobrar.Text = "COBRAR";
            btnCobrar.UseVisualStyleBackColor = false;
            btnCobrar.Click += btnCobrar_Click;
            btnCobrar.MouseEnter += btnCobrar_MouseEnter;
            btnCobrar.MouseLeave += btnCobrar_MouseLeave;
            // 
            // btnCancelarVenta
            // 
            btnCancelarVenta.BackColor = Color.FromArgb(238, 243, 247);
            btnCancelarVenta.Cursor = Cursors.Hand;
            btnCancelarVenta.Dock = DockStyle.Left;
            btnCancelarVenta.FlatAppearance.BorderSize = 0;
            btnCancelarVenta.FlatStyle = FlatStyle.Flat;
            btnCancelarVenta.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelarVenta.ForeColor = Color.FromArgb(8, 31, 63);
            btnCancelarVenta.Location = new Point(0, 0);
            btnCancelarVenta.Name = "btnCancelarVenta";
            btnCancelarVenta.Size = new Size(130, 50);
            btnCancelarVenta.TabIndex = 9;
            btnCancelarVenta.Text = "CANCELAR";
            btnCancelarVenta.UseVisualStyleBackColor = false;
            btnCancelarVenta.Click += btnCancelarVenta_Click;
            btnCancelarVenta.MouseEnter += btnCancelarVenta_MouseEnter;
            btnCancelarVenta.MouseLeave += btnCancelarVenta_MouseLeave;
            // 
            // tlpTotal
            // 
            tlpTotal.ColumnCount = 2;
            tlpTotal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpTotal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpTotal.Controls.Add(lblTotalTexto, 0, 0);
            tlpTotal.Controls.Add(lblTotal, 1, 0);
            tlpTotal.Dock = DockStyle.Top;
            tlpTotal.Location = new Point(10, 83);
            tlpTotal.Name = "tlpTotal";
            tlpTotal.RowCount = 1;
            tlpTotal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTotal.Size = new Size(335, 29);
            tlpTotal.TabIndex = 8;
            // 
            // lblTotalTexto
            // 
            lblTotalTexto.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalTexto.ForeColor = Color.WhiteSmoke;
            lblTotalTexto.Location = new Point(3, 0);
            lblTotalTexto.Name = "lblTotalTexto";
            lblTotalTexto.Size = new Size(120, 28);
            lblTotalTexto.TabIndex = 6;
            lblTotalTexto.Text = "TOTAL:";
            lblTotalTexto.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.Gainsboro;
            lblTotal.Location = new Point(137, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(190, 28);
            lblTotal.TabIndex = 7;
            lblTotal.Text = "C$  0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlSeparador
            // 
            pnlSeparador.BackColor = Color.FromArgb(225, 230, 235);
            pnlSeparador.Dock = DockStyle.Top;
            pnlSeparador.Location = new Point(10, 80);
            pnlSeparador.Name = "pnlSeparador";
            pnlSeparador.Size = new Size(335, 3);
            pnlSeparador.TabIndex = 5;
            // 
            // tlpOrderFooter
            // 
            tlpOrderFooter.ColumnCount = 2;
            tlpOrderFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpOrderFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpOrderFooter.Controls.Add(lblSubtotalTexto, 0, 0);
            tlpOrderFooter.Controls.Add(lblSubtotal, 1, 0);
            tlpOrderFooter.Controls.Add(lblDescuentoTexto, 0, 1);
            tlpOrderFooter.Controls.Add(lblDescuento, 1, 1);
            tlpOrderFooter.Dock = DockStyle.Top;
            tlpOrderFooter.Location = new Point(10, 10);
            tlpOrderFooter.Name = "tlpOrderFooter";
            tlpOrderFooter.RowCount = 2;
            tlpOrderFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpOrderFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpOrderFooter.Size = new Size(335, 70);
            tlpOrderFooter.TabIndex = 4;
            // 
            // lblSubtotalTexto
            // 
            lblSubtotalTexto.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtotalTexto.ForeColor = Color.Gainsboro;
            lblSubtotalTexto.Location = new Point(3, 0);
            lblSubtotalTexto.Name = "lblSubtotalTexto";
            lblSubtotalTexto.Size = new Size(120, 28);
            lblSubtotalTexto.TabIndex = 0;
            lblSubtotalTexto.Text = "Subtotal:";
            lblSubtotalTexto.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSubtotal
            // 
            lblSubtotal.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtotal.ForeColor = Color.WhiteSmoke;
            lblSubtotal.Location = new Point(137, 0);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(190, 28);
            lblSubtotal.TabIndex = 1;
            lblSubtotal.Text = "C$  0.00";
            lblSubtotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDescuentoTexto
            // 
            lblDescuentoTexto.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescuentoTexto.ForeColor = Color.Gainsboro;
            lblDescuentoTexto.Location = new Point(3, 35);
            lblDescuentoTexto.Name = "lblDescuentoTexto";
            lblDescuentoTexto.Size = new Size(120, 28);
            lblDescuentoTexto.TabIndex = 2;
            lblDescuentoTexto.Text = "Descuento:";
            lblDescuentoTexto.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDescuento
            // 
            lblDescuento.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescuento.ForeColor = Color.WhiteSmoke;
            lblDescuento.Location = new Point(137, 35);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(190, 28);
            lblDescuento.TabIndex = 3;
            lblDescuento.Text = "C$  0.00";
            lblDescuento.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlOrderHeader
            // 
            pnlOrderHeader.BackColor = Color.Transparent;
            pnlOrderHeader.Controls.Add(lblOrderTitle);
            pnlOrderHeader.Dock = DockStyle.Top;
            pnlOrderHeader.Location = new Point(15, 15);
            pnlOrderHeader.Name = "pnlOrderHeader";
            pnlOrderHeader.Size = new Size(350, 55);
            pnlOrderHeader.TabIndex = 0;
            // 
            // lblOrderTitle
            // 
            lblOrderTitle.Dock = DockStyle.Fill;
            lblOrderTitle.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrderTitle.ForeColor = Color.White;
            lblOrderTitle.Location = new Point(0, 0);
            lblOrderTitle.Name = "lblOrderTitle";
            lblOrderTitle.Size = new Size(350, 55);
            lblOrderTitle.TabIndex = 0;
            lblOrderTitle.Text = "Pedido Actual";
            lblOrderTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmPuntoVenta
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(pnlProducts);
            Controls.Add(pnlOrder);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmPuntoVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmPuntoVenta";
            pnlTop.ResumeLayout(false);
            tlpTop.ResumeLayout(false);
            pnlCliente.ResumeLayout(false);
            pnlCliente.PerformLayout();
            pnlMesa.ResumeLayout(false);
            pnlMesa.PerformLayout();
            pnlTipoOrden.ResumeLayout(false);
            pnlBusqueda.ResumeLayout(false);
            pnlSearchInput.ResumeLayout(false);
            pnlSearchInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlProducts.ResumeLayout(false);
            pnlCategories.ResumeLayout(false);
            tlpCategories.ResumeLayout(false);
            pnlOrder.ResumeLayout(false);
            pnlOrderFooter.ResumeLayout(false);
            pnlAcciones.ResumeLayout(false);
            tlpTotal.ResumeLayout(false);
            tlpOrderFooter.ResumeLayout(false);
            pnlOrderHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Panel pnlProducts;
        private Panel pnlOrder;
        private TextBox txtBuscarProducto;
        private Panel pnlRayita;
        private ComboBox comboBox1;
        private Label lblCliente;
        private Panel pnlCategories;
        private Button btnCatExtras;
        private Button btnCatBebidas;
        private Button btnCatEntradas;
        private Button btnCatMariscos;
        private FlowLayoutPanel flpProducts;
        private Button btnCatCeviche;
        private Panel pnlOrderHeader;
        private FlowLayoutPanel flpOrderItems;
        private Panel pnlOrderFooter;
        private Label lblOrderTitle;
        private Label lblDescuentoTexto;
        private Label lblSubtotal;
        private Label lblSubtotalTexto;
        private Label lblDescuento;
        private Panel pnlSeparador;
        private Label lblTotal;
        private Label lblTotalTexto;
        private TableLayoutPanel tlpTotal;
        private Button btnCancelarVenta;
        private Button btnCobrar;
        private Panel pnlAcciones;
        public TableLayoutPanel tlpOrderFooter;
        private ComboBox cmbTipoOrden;
        private Label lblTipoOrden;
        private ComboBox cmbMesa;
        private Label lblMesa;
        private Panel pnlBusqueda;
        private Panel pnlCliente;
        private Panel pnlTipoOrden;
        private Panel pnlMesa;
        private TableLayoutPanel tlpTop;
        private TableLayoutPanel tlpCategories;
        private Button btnCatTodos;
        private Panel pnlSearchInput;
        private PictureBox pictureBox1;
        private Label lblGhost;
    }
}