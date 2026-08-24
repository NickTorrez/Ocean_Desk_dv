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
            pnlBusqueda = new Panel();
            pnlRayita = new Panel();
            btnBuscar = new Button();
            txtBuscarProducto = new TextBox();
            pnlTipoOrden = new Panel();
            lblTipoOrden = new Label();
            cmbTipoOrden = new ComboBox();
            pnlMesa = new Panel();
            cmbMesa = new ComboBox();
            lblMesa = new Label();
            pnlCliente = new Panel();
            comboBox1 = new ComboBox();
            lblCliente = new Label();
            pnlProducts = new Panel();
            flpProducts = new FlowLayoutPanel();
            pnlCategories = new Panel();
            flpCategories = new FlowLayoutPanel();
            btnCatCeviche = new Button();
            btnCatMariscos = new Button();
            btnCatEntradas = new Button();
            btnCatBebidas = new Button();
            btnCatExtras = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
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
            pnlBusqueda.SuspendLayout();
            pnlTipoOrden.SuspendLayout();
            pnlMesa.SuspendLayout();
            pnlCliente.SuspendLayout();
            pnlProducts.SuspendLayout();
            pnlCategories.SuspendLayout();
            flpCategories.SuspendLayout();
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
            pnlTop.Controls.Add(pnlBusqueda);
            pnlTop.Controls.Add(pnlTipoOrden);
            pnlTop.Controls.Add(pnlMesa);
            pnlTop.Controls.Add(pnlCliente);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(10, 8, 10, 8);
            pnlTop.Size = new Size(940, 70);
            pnlTop.TabIndex = 0;
            // 
            // pnlBusqueda
            // 
            pnlBusqueda.Controls.Add(pnlRayita);
            pnlBusqueda.Controls.Add(btnBuscar);
            pnlBusqueda.Controls.Add(txtBuscarProducto);
            pnlBusqueda.Dock = DockStyle.Fill;
            pnlBusqueda.Location = new Point(10, 8);
            pnlBusqueda.Name = "pnlBusqueda";
            pnlBusqueda.Padding = new Padding(0, 5, 10, 5);
            pnlBusqueda.Size = new Size(290, 54);
            pnlBusqueda.TabIndex = 13;
            // 
            // pnlRayita
            // 
            pnlRayita.BackColor = Color.MidnightBlue;
            pnlRayita.Location = new Point(9, 34);
            pnlRayita.Name = "pnlRayita";
            pnlRayita.Size = new Size(230, 2);
            pnlRayita.TabIndex = 5;
            // 
            // btnBuscar
            // 
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Image = Properties.Resources.magnifier;
            btnBuscar.Location = new Point(244, 10);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(40, 35);
            btnBuscar.TabIndex = 6;
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.BorderStyle = BorderStyle.None;
            txtBuscarProducto.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarProducto.Location = new Point(9, 10);
            txtBuscarProducto.Multiline = true;
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.PlaceholderText = "Buscar Producto...";
            txtBuscarProducto.Size = new Size(230, 35);
            txtBuscarProducto.TabIndex = 0;
            // 
            // pnlTipoOrden
            // 
            pnlTipoOrden.Controls.Add(lblTipoOrden);
            pnlTipoOrden.Controls.Add(cmbTipoOrden);
            pnlTipoOrden.Dock = DockStyle.Right;
            pnlTipoOrden.Location = new Point(300, 8);
            pnlTipoOrden.Name = "pnlTipoOrden";
            pnlTipoOrden.Padding = new Padding(0, 5, 10, 5);
            pnlTipoOrden.Size = new Size(240, 54);
            pnlTipoOrden.TabIndex = 11;
            // 
            // lblTipoOrden
            // 
            lblTipoOrden.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTipoOrden.Location = new Point(6, 12);
            lblTipoOrden.Name = "lblTipoOrden";
            lblTipoOrden.Size = new Size(113, 31);
            lblTipoOrden.TabIndex = 9;
            lblTipoOrden.Text = "Tipo de orden:";
            lblTipoOrden.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbTipoOrden
            // 
            cmbTipoOrden.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoOrden.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTipoOrden.FormattingEnabled = true;
            cmbTipoOrden.Location = new Point(119, 13);
            cmbTipoOrden.Name = "cmbTipoOrden";
            cmbTipoOrden.RightToLeft = RightToLeft.No;
            cmbTipoOrden.Size = new Size(115, 29);
            cmbTipoOrden.TabIndex = 10;
            cmbTipoOrden.SelectedIndexChanged += cmbTipoOrden_SelectedIndexChanged;
            // 
            // pnlMesa
            // 
            pnlMesa.Controls.Add(cmbMesa);
            pnlMesa.Controls.Add(lblMesa);
            pnlMesa.Dock = DockStyle.Right;
            pnlMesa.Location = new Point(540, 8);
            pnlMesa.Name = "pnlMesa";
            pnlMesa.Padding = new Padding(0, 5, 10, 5);
            pnlMesa.Size = new Size(170, 54);
            pnlMesa.TabIndex = 7;
            // 
            // cmbMesa
            // 
            cmbMesa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMesa.FormattingEnabled = true;
            cmbMesa.Items.AddRange(new object[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10" });
            cmbMesa.Location = new Point(54, 13);
            cmbMesa.Name = "cmbMesa";
            cmbMesa.Size = new Size(110, 28);
            cmbMesa.TabIndex = 12;
            // 
            // lblMesa
            // 
            lblMesa.AutoSize = true;
            lblMesa.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMesa.Location = new Point(3, 17);
            lblMesa.Name = "lblMesa";
            lblMesa.Size = new Size(54, 20);
            lblMesa.TabIndex = 11;
            lblMesa.Text = "Mesa:";
            // 
            // pnlCliente
            // 
            pnlCliente.Controls.Add(comboBox1);
            pnlCliente.Controls.Add(lblCliente);
            pnlCliente.Dock = DockStyle.Right;
            pnlCliente.Location = new Point(710, 8);
            pnlCliente.Name = "pnlCliente";
            pnlCliente.Padding = new Padding(0, 5, 0, 5);
            pnlCliente.Size = new Size(220, 54);
            pnlCliente.TabIndex = 7;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(70, 13);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(140, 29);
            comboBox1.TabIndex = 8;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCliente.Location = new Point(3, 17);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(65, 20);
            lblCliente.TabIndex = 7;
            lblCliente.Text = "Cliente:";
            // 
            // pnlProducts
            // 
            pnlProducts.Controls.Add(flpProducts);
            pnlProducts.Controls.Add(pnlCategories);
            pnlProducts.Dock = DockStyle.Fill;
            pnlProducts.Location = new Point(0, 70);
            pnlProducts.Name = "pnlProducts";
            pnlProducts.Padding = new Padding(15);
            pnlProducts.Size = new Size(560, 760);
            pnlProducts.TabIndex = 1;
            // 
            // flpProducts
            // 
            flpProducts.AutoScroll = true;
            flpProducts.BackColor = Color.Transparent;
            flpProducts.Dock = DockStyle.Fill;
            flpProducts.Location = new Point(15, 85);
            flpProducts.Margin = new Padding(0);
            flpProducts.Name = "flpProducts";
            flpProducts.Padding = new Padding(5);
            flpProducts.Size = new Size(530, 660);
            flpProducts.TabIndex = 2;
            // 
            // pnlCategories
            // 
            pnlCategories.BackColor = Color.Transparent;
            pnlCategories.Controls.Add(flpCategories);
            pnlCategories.Dock = DockStyle.Top;
            pnlCategories.Location = new Point(15, 15);
            pnlCategories.Name = "pnlCategories";
            pnlCategories.Padding = new Padding(0, 5, 0, 5);
            pnlCategories.Size = new Size(530, 70);
            pnlCategories.TabIndex = 1;
            // 
            // flpCategories
            // 
            flpCategories.AutoScroll = true;
            flpCategories.Controls.Add(btnCatCeviche);
            flpCategories.Controls.Add(btnCatMariscos);
            flpCategories.Controls.Add(btnCatEntradas);
            flpCategories.Controls.Add(btnCatBebidas);
            flpCategories.Controls.Add(btnCatExtras);
            flpCategories.Controls.Add(button1);
            flpCategories.Controls.Add(button2);
            flpCategories.Controls.Add(button3);
            flpCategories.Controls.Add(button4);
            flpCategories.Controls.Add(button5);
            flpCategories.Controls.Add(button6);
            flpCategories.Dock = DockStyle.Fill;
            flpCategories.Location = new Point(0, 5);
            flpCategories.Name = "flpCategories";
            flpCategories.Size = new Size(530, 60);
            flpCategories.TabIndex = 0;
            flpCategories.WrapContents = false;
            // 
            // btnCatCeviche
            // 
            btnCatCeviche.BackColor = Color.FromArgb(8, 31, 63);
            btnCatCeviche.Cursor = Cursors.Hand;
            btnCatCeviche.FlatAppearance.BorderSize = 0;
            btnCatCeviche.FlatStyle = FlatStyle.Flat;
            btnCatCeviche.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCatCeviche.ForeColor = Color.White;
            btnCatCeviche.Location = new Point(4, 2);
            btnCatCeviche.Margin = new Padding(4, 2, 4, 2);
            btnCatCeviche.Name = "btnCatCeviche";
            btnCatCeviche.Size = new Size(110, 38);
            btnCatCeviche.TabIndex = 5;
            btnCatCeviche.TabStop = false;
            btnCatCeviche.Text = "Ceviches";
            btnCatCeviche.UseVisualStyleBackColor = false;
            // 
            // btnCatMariscos
            // 
            btnCatMariscos.BackColor = Color.FromArgb(8, 31, 63);
            btnCatMariscos.Cursor = Cursors.Hand;
            btnCatMariscos.FlatAppearance.BorderSize = 0;
            btnCatMariscos.FlatStyle = FlatStyle.Flat;
            btnCatMariscos.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCatMariscos.ForeColor = Color.White;
            btnCatMariscos.Location = new Point(122, 2);
            btnCatMariscos.Margin = new Padding(4, 2, 4, 2);
            btnCatMariscos.Name = "btnCatMariscos";
            btnCatMariscos.Size = new Size(110, 38);
            btnCatMariscos.TabIndex = 1;
            btnCatMariscos.TabStop = false;
            btnCatMariscos.Text = "Mariscos";
            btnCatMariscos.UseVisualStyleBackColor = false;
            // 
            // btnCatEntradas
            // 
            btnCatEntradas.BackColor = Color.FromArgb(8, 31, 63);
            btnCatEntradas.Cursor = Cursors.Hand;
            btnCatEntradas.FlatAppearance.BorderSize = 0;
            btnCatEntradas.FlatStyle = FlatStyle.Flat;
            btnCatEntradas.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCatEntradas.ForeColor = Color.White;
            btnCatEntradas.Location = new Point(240, 2);
            btnCatEntradas.Margin = new Padding(4, 2, 4, 2);
            btnCatEntradas.Name = "btnCatEntradas";
            btnCatEntradas.Size = new Size(110, 38);
            btnCatEntradas.TabIndex = 2;
            btnCatEntradas.TabStop = false;
            btnCatEntradas.Text = "Entradas";
            btnCatEntradas.UseVisualStyleBackColor = false;
            // 
            // btnCatBebidas
            // 
            btnCatBebidas.BackColor = Color.FromArgb(8, 31, 63);
            btnCatBebidas.Cursor = Cursors.Hand;
            btnCatBebidas.FlatAppearance.BorderSize = 0;
            btnCatBebidas.FlatStyle = FlatStyle.Flat;
            btnCatBebidas.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCatBebidas.ForeColor = Color.White;
            btnCatBebidas.Location = new Point(358, 2);
            btnCatBebidas.Margin = new Padding(4, 2, 4, 2);
            btnCatBebidas.Name = "btnCatBebidas";
            btnCatBebidas.Size = new Size(110, 38);
            btnCatBebidas.TabIndex = 3;
            btnCatBebidas.TabStop = false;
            btnCatBebidas.Text = "Bebidas";
            btnCatBebidas.UseVisualStyleBackColor = false;
            // 
            // btnCatExtras
            // 
            btnCatExtras.BackColor = Color.FromArgb(8, 31, 63);
            btnCatExtras.Cursor = Cursors.Hand;
            btnCatExtras.FlatAppearance.BorderSize = 0;
            btnCatExtras.FlatStyle = FlatStyle.Flat;
            btnCatExtras.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCatExtras.ForeColor = Color.White;
            btnCatExtras.Location = new Point(476, 2);
            btnCatExtras.Margin = new Padding(4, 2, 4, 2);
            btnCatExtras.Name = "btnCatExtras";
            btnCatExtras.Size = new Size(110, 38);
            btnCatExtras.TabIndex = 4;
            btnCatExtras.TabStop = false;
            btnCatExtras.Text = "Extras";
            btnCatExtras.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(8, 31, 63);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(594, 2);
            button1.Margin = new Padding(4, 2, 4, 2);
            button1.Name = "button1";
            button1.Size = new Size(110, 38);
            button1.TabIndex = 6;
            button1.TabStop = false;
            button1.Text = "Extras";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(8, 31, 63);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(712, 2);
            button2.Margin = new Padding(4, 2, 4, 2);
            button2.Name = "button2";
            button2.Size = new Size(110, 38);
            button2.TabIndex = 7;
            button2.TabStop = false;
            button2.Text = "Extras";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(8, 31, 63);
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(830, 2);
            button3.Margin = new Padding(4, 2, 4, 2);
            button3.Name = "button3";
            button3.Size = new Size(110, 38);
            button3.TabIndex = 8;
            button3.TabStop = false;
            button3.Text = "Extras";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(8, 31, 63);
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(948, 2);
            button4.Margin = new Padding(4, 2, 4, 2);
            button4.Name = "button4";
            button4.Size = new Size(110, 38);
            button4.TabIndex = 9;
            button4.TabStop = false;
            button4.Text = "Extras";
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(8, 31, 63);
            button5.Cursor = Cursors.Hand;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Location = new Point(1066, 2);
            button5.Margin = new Padding(4, 2, 4, 2);
            button5.Name = "button5";
            button5.Size = new Size(110, 38);
            button5.TabIndex = 10;
            button5.TabStop = false;
            button5.Text = "Extras";
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(8, 31, 63);
            button6.Cursor = Cursors.Hand;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Location = new Point(1184, 2);
            button6.Margin = new Padding(4, 2, 4, 2);
            button6.Name = "button6";
            button6.Size = new Size(110, 38);
            button6.TabIndex = 11;
            button6.TabStop = false;
            button6.Text = "Extras";
            button6.UseVisualStyleBackColor = false;
            // 
            // pnlOrder
            // 
            pnlOrder.BackColor = Color.FromArgb(8, 31, 63);
            pnlOrder.Controls.Add(flpOrderItems);
            pnlOrder.Controls.Add(pnlOrderFooter);
            pnlOrder.Controls.Add(pnlOrderHeader);
            pnlOrder.Dock = DockStyle.Right;
            pnlOrder.Location = new Point(560, 70);
            pnlOrder.Name = "pnlOrder";
            pnlOrder.Padding = new Padding(15);
            pnlOrder.Size = new Size(380, 760);
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
            flpOrderItems.Size = new Size(350, 495);
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
            pnlOrderFooter.Location = new Point(15, 565);
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
            pnlBusqueda.ResumeLayout(false);
            pnlBusqueda.PerformLayout();
            pnlTipoOrden.ResumeLayout(false);
            pnlMesa.ResumeLayout(false);
            pnlMesa.PerformLayout();
            pnlCliente.ResumeLayout(false);
            pnlCliente.PerformLayout();
            pnlProducts.ResumeLayout(false);
            pnlCategories.ResumeLayout(false);
            flpCategories.ResumeLayout(false);
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
        private Button btnBuscar;
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
        private FlowLayoutPanel flpCategories;
        private ComboBox cmbTipoOrden;
        private Label lblTipoOrden;
        private ComboBox cmbMesa;
        private Label lblMesa;
        private Panel pnlBusqueda;
        private Panel pnlCliente;
        private Panel pnlTipoOrden;
        private Panel pnlMesa;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}