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
            comboBox1 = new ComboBox();
            lblCliente = new Label();
            btnBuscar = new Button();
            panel2 = new Panel();
            txtBuscarProducto = new TextBox();
            pnlProducts = new Panel();
            flpProducts = new FlowLayoutPanel();
            pnlCategories = new Panel();
            tlpCategories = new TableLayoutPanel();
            btnCatExtras = new Button();
            btnCatBebidas = new Button();
            btnCatEntradas = new Button();
            button1 = new Button();
            btnCatMariscos = new Button();
            pnlOrder = new Panel();
            flpOrderItems = new FlowLayoutPanel();
            pnlOrderFooter = new Panel();
            pnlOrderHeader = new Panel();
            lblOrderTitle = new Label();
            lblSubtotalTexto = new Label();
            lblSubtotal = new Label();
            lblDescuentoTexto = new Label();
            lblDescuento = new Label();
            tlpOrderFooter = new TableLayoutPanel();
            pnlSeparador = new Panel();
            pnlTop.SuspendLayout();
            pnlProducts.SuspendLayout();
            pnlCategories.SuspendLayout();
            tlpCategories.SuspendLayout();
            pnlOrder.SuspendLayout();
            pnlOrderFooter.SuspendLayout();
            pnlOrderHeader.SuspendLayout();
            tlpOrderFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(comboBox1);
            pnlTop.Controls.Add(lblCliente);
            pnlTop.Controls.Add(btnBuscar);
            pnlTop.Controls.Add(panel2);
            pnlTop.Controls.Add(txtBuscarProducto);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(15, 10, 15, 10);
            pnlTop.Size = new Size(940, 70);
            pnlTop.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(487, 21);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(200, 29);
            comboBox1.TabIndex = 8;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCliente.Location = new Point(407, 25);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(74, 21);
            lblCliente.TabIndex = 7;
            lblCliente.Text = "Cliente:";
            // 
            // btnBuscar
            // 
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Image = Properties.Resources.magnifier;
            btnBuscar.Location = new Point(338, 14);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(40, 35);
            btnBuscar.TabIndex = 6;
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MidnightBlue;
            panel2.Location = new Point(32, 42);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 2);
            panel2.TabIndex = 5;
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.BorderStyle = BorderStyle.None;
            txtBuscarProducto.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarProducto.Location = new Point(32, 18);
            txtBuscarProducto.Multiline = true;
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.PlaceholderText = "Buscar Producto...";
            txtBuscarProducto.Size = new Size(300, 35);
            txtBuscarProducto.TabIndex = 0;
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
            flpProducts.Location = new Point(15, 65);
            flpProducts.Margin = new Padding(0);
            flpProducts.Name = "flpProducts";
            flpProducts.Padding = new Padding(5);
            flpProducts.Size = new Size(530, 680);
            flpProducts.TabIndex = 2;
            // 
            // pnlCategories
            // 
            pnlCategories.BackColor = Color.Transparent;
            pnlCategories.Controls.Add(tlpCategories);
            pnlCategories.Dock = DockStyle.Top;
            pnlCategories.Location = new Point(15, 15);
            pnlCategories.Name = "pnlCategories";
            pnlCategories.Size = new Size(530, 50);
            pnlCategories.TabIndex = 1;
            // 
            // tlpCategories
            // 
            tlpCategories.ColumnCount = 5;
            tlpCategories.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpCategories.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpCategories.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpCategories.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpCategories.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpCategories.Controls.Add(btnCatExtras, 4, 0);
            tlpCategories.Controls.Add(btnCatBebidas, 3, 0);
            tlpCategories.Controls.Add(btnCatEntradas, 2, 0);
            tlpCategories.Controls.Add(button1, 0, 0);
            tlpCategories.Controls.Add(btnCatMariscos, 1, 0);
            tlpCategories.Dock = DockStyle.Top;
            tlpCategories.Location = new Point(0, 0);
            tlpCategories.Name = "tlpCategories";
            tlpCategories.Padding = new Padding(2, 6, 2, 6);
            tlpCategories.RowCount = 1;
            tlpCategories.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpCategories.Size = new Size(530, 50);
            tlpCategories.TabIndex = 0;
            // 
            // btnCatExtras
            // 
            btnCatExtras.BackColor = Color.FromArgb(8, 31, 63);
            btnCatExtras.Cursor = Cursors.Hand;
            btnCatExtras.FlatAppearance.BorderSize = 0;
            btnCatExtras.FlatStyle = FlatStyle.Flat;
            btnCatExtras.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCatExtras.ForeColor = Color.White;
            btnCatExtras.Location = new Point(425, 9);
            btnCatExtras.Name = "btnCatExtras";
            btnCatExtras.Size = new Size(94, 32);
            btnCatExtras.TabIndex = 4;
            btnCatExtras.Text = "Extras";
            btnCatExtras.UseVisualStyleBackColor = false;
            // 
            // btnCatBebidas
            // 
            btnCatBebidas.BackColor = Color.FromArgb(8, 31, 63);
            btnCatBebidas.Cursor = Cursors.Hand;
            btnCatBebidas.FlatAppearance.BorderSize = 0;
            btnCatBebidas.FlatStyle = FlatStyle.Flat;
            btnCatBebidas.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCatBebidas.ForeColor = Color.White;
            btnCatBebidas.Location = new Point(320, 9);
            btnCatBebidas.Name = "btnCatBebidas";
            btnCatBebidas.Size = new Size(94, 32);
            btnCatBebidas.TabIndex = 3;
            btnCatBebidas.Text = "Bebidas";
            btnCatBebidas.UseVisualStyleBackColor = false;
            // 
            // btnCatEntradas
            // 
            btnCatEntradas.BackColor = Color.FromArgb(8, 31, 63);
            btnCatEntradas.Cursor = Cursors.Hand;
            btnCatEntradas.FlatAppearance.BorderSize = 0;
            btnCatEntradas.FlatStyle = FlatStyle.Flat;
            btnCatEntradas.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCatEntradas.ForeColor = Color.White;
            btnCatEntradas.Location = new Point(215, 9);
            btnCatEntradas.Name = "btnCatEntradas";
            btnCatEntradas.Size = new Size(94, 32);
            btnCatEntradas.TabIndex = 2;
            btnCatEntradas.Text = "Entradas";
            btnCatEntradas.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(8, 31, 63);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(5, 9);
            button1.Name = "button1";
            button1.Size = new Size(94, 32);
            button1.TabIndex = 5;
            button1.Text = "Ceviches";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnCatMariscos
            // 
            btnCatMariscos.BackColor = Color.FromArgb(8, 31, 63);
            btnCatMariscos.Cursor = Cursors.Hand;
            btnCatMariscos.FlatAppearance.BorderSize = 0;
            btnCatMariscos.FlatStyle = FlatStyle.Flat;
            btnCatMariscos.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCatMariscos.ForeColor = Color.White;
            btnCatMariscos.Location = new Point(110, 9);
            btnCatMariscos.Name = "btnCatMariscos";
            btnCatMariscos.Size = new Size(94, 32);
            btnCatMariscos.TabIndex = 1;
            btnCatMariscos.Text = "Mariscos";
            btnCatMariscos.UseVisualStyleBackColor = false;
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
            pnlOrderFooter.BorderStyle = BorderStyle.FixedSingle;
            pnlOrderFooter.Controls.Add(pnlSeparador);
            pnlOrderFooter.Controls.Add(tlpOrderFooter);
            pnlOrderFooter.Dock = DockStyle.Bottom;
            pnlOrderFooter.Location = new Point(15, 565);
            pnlOrderFooter.Name = "pnlOrderFooter";
            pnlOrderFooter.Padding = new Padding(10, 10, 5, 5);
            pnlOrderFooter.Size = new Size(350, 180);
            pnlOrderFooter.TabIndex = 2;
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
            lblSubtotal.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtotal.ForeColor = Color.WhiteSmoke;
            lblSubtotal.Location = new Point(136, 0);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(100, 28);
            lblSubtotal.TabIndex = 1;
            lblSubtotal.Text = "C$ 0.00";
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
            lblDescuento.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescuento.ForeColor = Color.WhiteSmoke;
            lblDescuento.Location = new Point(136, 35);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(100, 28);
            lblDescuento.TabIndex = 3;
            lblDescuento.Text = "C$ 0.00";
            lblDescuento.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tlpOrderFooter
            // 
            tlpOrderFooter.ColumnCount = 2;
            tlpOrderFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpOrderFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpOrderFooter.Controls.Add(lblSubtotalTexto, 0, 0);
            tlpOrderFooter.Controls.Add(lblDescuento, 1, 1);
            tlpOrderFooter.Controls.Add(lblDescuentoTexto, 0, 1);
            tlpOrderFooter.Controls.Add(lblSubtotal, 1, 0);
            tlpOrderFooter.Dock = DockStyle.Top;
            tlpOrderFooter.Location = new Point(10, 10);
            tlpOrderFooter.Name = "tlpOrderFooter";
            tlpOrderFooter.RowCount = 2;
            tlpOrderFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpOrderFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpOrderFooter.Size = new Size(333, 70);
            tlpOrderFooter.TabIndex = 4;
            // 
            // pnlSeparador
            // 
            pnlSeparador.BackColor = Color.FromArgb(225, 230, 235);
            pnlSeparador.Dock = DockStyle.Top;
            pnlSeparador.Location = new Point(10, 80);
            pnlSeparador.Name = "pnlSeparador";
            pnlSeparador.Size = new Size(333, 3);
            pnlSeparador.TabIndex = 5;
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
            pnlTop.PerformLayout();
            pnlProducts.ResumeLayout(false);
            pnlCategories.ResumeLayout(false);
            tlpCategories.ResumeLayout(false);
            pnlOrder.ResumeLayout(false);
            pnlOrderFooter.ResumeLayout(false);
            pnlOrderHeader.ResumeLayout(false);
            tlpOrderFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Panel pnlProducts;
        private Panel pnlOrder;
        private TextBox txtBuscarProducto;
        private Panel panel2;
        private Button btnBuscar;
        private ComboBox comboBox1;
        private Label lblCliente;
        private Panel pnlCategories;
        private TableLayoutPanel tlpCategories;
        private Button btnCatExtras;
        private Button btnCatBebidas;
        private Button btnCatEntradas;
        private Button btnCatMariscos;
        private FlowLayoutPanel flpProducts;
        private Button button1;
        private Panel pnlOrderHeader;
        private FlowLayoutPanel flpOrderItems;
        private Panel pnlOrderFooter;
        private Label lblOrderTitle;
        private Label lblDescuentoTexto;
        private Label lblSubtotal;
        private Label lblSubtotalTexto;
        private Label lblDescuento;
        private TableLayoutPanel tlpOrderFooter;
        private Panel pnlSeparador;
    }
}