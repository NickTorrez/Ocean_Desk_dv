namespace Ocean_Desk_dv.UI.Controls
{
    partial class UcOrderItem
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            lblNombreProducto = new Label();
            btnEliminar = new Button();
            lblPrecioUnitario = new Label();
            btnDisminuir = new Button();
            lblCantidad = new Label();
            btnAumentar = new Button();
            pnlBottom = new Panel();
            lblSubtotal = new Label();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoEllipsis = true;
            lblNombreProducto.Dock = DockStyle.Top;
            lblNombreProducto.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreProducto.ForeColor = Color.FromArgb(8, 31, 63);
            lblNombreProducto.Location = new Point(10, 10);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(290, 25);
            lblNombreProducto.TabIndex = 0;
            lblNombreProducto.Text = "Producto";
            lblNombreProducto.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Transparent;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Dock = DockStyle.Right;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.FromArgb(111, 119, 128);
            btnEliminar.Location = new Point(300, 10);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(30, 75);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "X";
            btnEliminar.TextAlign = ContentAlignment.TopCenter;
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // lblPrecioUnitario
            // 
            lblPrecioUnitario.Dock = DockStyle.Top;
            lblPrecioUnitario.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrecioUnitario.ForeColor = Color.FromArgb(111, 119, 128);
            lblPrecioUnitario.Location = new Point(10, 35);
            lblPrecioUnitario.Name = "lblPrecioUnitario";
            lblPrecioUnitario.Size = new Size(290, 22);
            lblPrecioUnitario.TabIndex = 2;
            lblPrecioUnitario.Text = "C$ 0.00";
            lblPrecioUnitario.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnDisminuir
            // 
            btnDisminuir.Cursor = Cursors.Hand;
            btnDisminuir.Dock = DockStyle.Left;
            btnDisminuir.FlatAppearance.BorderSize = 0;
            btnDisminuir.FlatStyle = FlatStyle.Flat;
            btnDisminuir.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDisminuir.Location = new Point(20, 0);
            btnDisminuir.Name = "btnDisminuir";
            btnDisminuir.Size = new Size(28, 28);
            btnDisminuir.TabIndex = 3;
            btnDisminuir.Text = "─";
            btnDisminuir.UseVisualStyleBackColor = true;
            // 
            // lblCantidad
            // 
            lblCantidad.Dock = DockStyle.Fill;
            lblCantidad.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidad.Location = new Point(48, 0);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(95, 28);
            lblCantidad.TabIndex = 4;
            lblCantidad.Text = "1";
            lblCantidad.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAumentar
            // 
            btnAumentar.Cursor = Cursors.Hand;
            btnAumentar.Dock = DockStyle.Right;
            btnAumentar.FlatAppearance.BorderSize = 0;
            btnAumentar.FlatStyle = FlatStyle.Flat;
            btnAumentar.Font = new Font("Century Gothic", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnAumentar.Location = new Point(143, 0);
            btnAumentar.Name = "btnAumentar";
            btnAumentar.Size = new Size(28, 28);
            btnAumentar.TabIndex = 5;
            btnAumentar.Text = "+";
            btnAumentar.UseVisualStyleBackColor = true;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.Transparent;
            pnlBottom.Controls.Add(lblCantidad);
            pnlBottom.Controls.Add(btnAumentar);
            pnlBottom.Controls.Add(btnDisminuir);
            pnlBottom.Dock = DockStyle.Fill;
            pnlBottom.Location = new Point(10, 57);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(20, 0, 20, 0);
            pnlBottom.Size = new Size(191, 28);
            pnlBottom.TabIndex = 6;
            // 
            // lblSubtotal
            // 
            lblSubtotal.Dock = DockStyle.Right;
            lblSubtotal.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtotal.ForeColor = Color.FromArgb(11, 120, 166);
            lblSubtotal.Location = new Point(201, 57);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(99, 28);
            lblSubtotal.TabIndex = 7;
            lblSubtotal.Text = "C$ 0.00";
            lblSubtotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // UcOrderItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlBottom);
            Controls.Add(lblSubtotal);
            Controls.Add(lblPrecioUnitario);
            Controls.Add(lblNombreProducto);
            Controls.Add(btnEliminar);
            Margin = new Padding(0, 0, 0, 8);
            Name = "UcOrderItem";
            Padding = new Padding(10);
            Size = new Size(340, 95);
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblNombreProducto;
        private Button btnEliminar;
        private Label lblPrecioUnitario;
        private Button btnDisminuir;
        private Label lblCantidad;
        private Button btnAumentar;
        private Panel pnlBottom;
        private Label lblSubtotal;
    }
}
