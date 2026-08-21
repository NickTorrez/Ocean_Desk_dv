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
            panel2 = new Panel();
            txtBuscarProducto = new TextBox();
            pnlProducts = new Panel();
            pnlOrder = new Panel();
            btnBuscar = new Button();
            lblCliente = new Label();
            comboBox1 = new ComboBox();
            pnlCategories = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnCatMariscos = new Button();
            btnCatEntradas = new Button();
            btnCatBebidas = new Button();
            btnCatExtras = new Button();
            button1 = new Button();
            flpProducts = new FlowLayoutPanel();
            pnlOrderHeader = new Panel();
            lblOrderTitle = new Label();
            flpOrderItems = new FlowLayoutPanel();
            pnlOrderFooter = new Panel();
            pnlTop.SuspendLayout();
            pnlProducts.SuspendLayout();
            pnlOrder.SuspendLayout();
            pnlCategories.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlOrderHeader.SuspendLayout();
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
            txtBuscarProducto.BorderStyle = BorderStyle.FixedSingle;
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
            // pnlOrder
            // 
            pnlOrder.BackColor = Color.White;
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
            // pnlCategories
            // 
            pnlCategories.BackColor = Color.Transparent;
            pnlCategories.Controls.Add(tableLayoutPanel1);
            pnlCategories.Dock = DockStyle.Top;
            pnlCategories.Location = new Point(15, 15);
            pnlCategories.Name = "pnlCategories";
            pnlCategories.Size = new Size(530, 50);
            pnlCategories.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(btnCatExtras, 4, 0);
            tableLayoutPanel1.Controls.Add(btnCatBebidas, 3, 0);
            tableLayoutPanel1.Controls.Add(btnCatEntradas, 2, 0);
            tableLayoutPanel1.Controls.Add(button1, 0, 0);
            tableLayoutPanel1.Controls.Add(btnCatMariscos, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(2, 6, 2, 6);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(530, 50);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCatMariscos
            // 
            btnCatMariscos.Cursor = Cursors.Hand;
            btnCatMariscos.FlatAppearance.BorderSize = 0;
            btnCatMariscos.FlatStyle = FlatStyle.Flat;
            btnCatMariscos.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCatMariscos.Location = new Point(110, 9);
            btnCatMariscos.Name = "btnCatMariscos";
            btnCatMariscos.Size = new Size(94, 32);
            btnCatMariscos.TabIndex = 1;
            btnCatMariscos.Text = "Mariscos";
            btnCatMariscos.UseVisualStyleBackColor = true;
            // 
            // btnCatEntradas
            // 
            btnCatEntradas.Cursor = Cursors.Hand;
            btnCatEntradas.FlatAppearance.BorderSize = 0;
            btnCatEntradas.FlatStyle = FlatStyle.Flat;
            btnCatEntradas.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCatEntradas.Location = new Point(215, 9);
            btnCatEntradas.Name = "btnCatEntradas";
            btnCatEntradas.Size = new Size(94, 32);
            btnCatEntradas.TabIndex = 2;
            btnCatEntradas.Text = "Entradas";
            btnCatEntradas.UseVisualStyleBackColor = true;
            // 
            // btnCatBebidas
            // 
            btnCatBebidas.Cursor = Cursors.Hand;
            btnCatBebidas.FlatAppearance.BorderSize = 0;
            btnCatBebidas.FlatStyle = FlatStyle.Flat;
            btnCatBebidas.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCatBebidas.Location = new Point(320, 9);
            btnCatBebidas.Name = "btnCatBebidas";
            btnCatBebidas.Size = new Size(94, 32);
            btnCatBebidas.TabIndex = 3;
            btnCatBebidas.Text = "Bebidas";
            btnCatBebidas.UseVisualStyleBackColor = true;
            // 
            // btnCatExtras
            // 
            btnCatExtras.Cursor = Cursors.Hand;
            btnCatExtras.FlatAppearance.BorderSize = 0;
            btnCatExtras.FlatStyle = FlatStyle.Flat;
            btnCatExtras.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCatExtras.Location = new Point(425, 9);
            btnCatExtras.Name = "btnCatExtras";
            btnCatExtras.Size = new Size(94, 32);
            btnCatExtras.TabIndex = 4;
            btnCatExtras.Text = "Extras";
            btnCatExtras.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(5, 9);
            button1.Name = "button1";
            button1.Size = new Size(94, 32);
            button1.TabIndex = 5;
            button1.Text = "Ceviches";
            button1.UseVisualStyleBackColor = true;
            // 
            // flpProducts
            // 
            flpProducts.AutoScroll = true;
            flpProducts.BackColor = Color.Transparent;
            flpProducts.Dock = DockStyle.Fill;
            flpProducts.Location = new Point(15, 65);
            flpProducts.Name = "flpProducts";
            flpProducts.Padding = new Padding(5);
            flpProducts.Size = new Size(530, 680);
            flpProducts.TabIndex = 2;
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
            lblOrderTitle.AutoSize = true;
            lblOrderTitle.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrderTitle.Location = new Point(87, 14);
            lblOrderTitle.Name = "lblOrderTitle";
            lblOrderTitle.Size = new Size(176, 27);
            lblOrderTitle.TabIndex = 0;
            lblOrderTitle.Text = "Pedido Actual";
            // 
            // flpOrderItems
            // 
            flpOrderItems.AutoScroll = true;
            flpOrderItems.BackColor = Color.Transparent;
            flpOrderItems.Dock = DockStyle.Fill;
            flpOrderItems.Location = new Point(15, 70);
            flpOrderItems.Name = "flpOrderItems";
            flpOrderItems.Padding = new Padding(5);
            flpOrderItems.Size = new Size(350, 495);
            flpOrderItems.TabIndex = 1;
            // 
            // pnlOrderFooter
            // 
            pnlOrderFooter.BackColor = Color.Transparent;
            pnlOrderFooter.Dock = DockStyle.Bottom;
            pnlOrderFooter.Location = new Point(15, 565);
            pnlOrderFooter.Name = "pnlOrderFooter";
            pnlOrderFooter.Size = new Size(350, 180);
            pnlOrderFooter.TabIndex = 2;
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
            pnlOrder.ResumeLayout(false);
            pnlCategories.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            pnlOrderHeader.ResumeLayout(false);
            pnlOrderHeader.PerformLayout();
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
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnCatExtras;
        private Button btnCatBebidas;
        private Button btnCatEntradas;
        private Button btnCatMariscos;
        private FlowLayoutPanel flpProducts;
        private Button button1;
        private Panel pnlOrderHeader;
        private Label lblOrderTitle;
        private FlowLayoutPanel flpOrderItems;
        private Panel pnlOrderFooter;
    }
}