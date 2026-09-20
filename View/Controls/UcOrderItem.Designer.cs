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
            pnlTop = new Panel();
            lblObservación = new Label();
            txtObservacion = new TextBox();
            pnlObservacion = new Panel();
            pnlBottom.SuspendLayout();
            pnlTop.SuspendLayout();
            pnlObservacion.SuspendLayout();
            SuspendLayout();
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoEllipsis = true;
            lblNombreProducto.Dock = DockStyle.Left;
            lblNombreProducto.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreProducto.ForeColor = Color.FromArgb(8, 31, 63);
            lblNombreProducto.Location = new Point(0, 0);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(221, 30);
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
            btnEliminar.Location = new Point(290, 0);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(30, 30);
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
            lblPrecioUnitario.Location = new Point(10, 40);
            lblPrecioUnitario.Name = "lblPrecioUnitario";
            lblPrecioUnitario.Size = new Size(320, 22);
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
            btnDisminuir.Location = new Point(20, 10);
            btnDisminuir.Name = "btnDisminuir";
            btnDisminuir.Size = new Size(28, 28);
            btnDisminuir.TabIndex = 3;
            btnDisminuir.Text = "─";
            btnDisminuir.UseVisualStyleBackColor = true;
            // 
            // lblCantidad
            // 
            lblCantidad.Dock = DockStyle.Fill;
            lblCantidad.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidad.Location = new Point(48, 10);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(104, 28);
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
            btnAumentar.Location = new Point(152, 10);
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
            pnlBottom.Dock = DockStyle.Left;
            pnlBottom.Location = new Point(10, 137);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(20, 10, 20, 5);
            pnlBottom.Size = new Size(200, 43);
            pnlBottom.TabIndex = 6;
            // 
            // lblSubtotal
            // 
            lblSubtotal.Dock = DockStyle.Fill;
            lblSubtotal.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtotal.ForeColor = Color.FromArgb(11, 120, 166);
            lblSubtotal.Location = new Point(210, 137);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Padding = new Padding(0, 10, 0, 0);
            lblSubtotal.Size = new Size(120, 43);
            lblSubtotal.TabIndex = 7;
            lblSubtotal.Text = "C$ 0.00";
            lblSubtotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(lblNombreProducto);
            pnlTop.Controls.Add(btnEliminar);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(10, 10);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(320, 30);
            pnlTop.TabIndex = 8;
            // 
            // lblObservación
            // 
            lblObservación.Dock = DockStyle.Top;
            lblObservación.Font = new Font("Century Gothic", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblObservación.Location = new Point(0, 0);
            lblObservación.Name = "lblObservación";
            lblObservación.Size = new Size(320, 35);
            lblObservación.TabIndex = 9;
            lblObservación.Text = "Observación";
            lblObservación.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtObservacion
            // 
            txtObservacion.Dock = DockStyle.Fill;
            txtObservacion.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtObservacion.Location = new Point(0, 35);
            txtObservacion.MaxLength = 255;
            txtObservacion.Multiline = true;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.ScrollBars = ScrollBars.Vertical;
            txtObservacion.Size = new Size(320, 40);
            txtObservacion.TabIndex = 10;
            // 
            // pnlObservacion
            // 
            pnlObservacion.Controls.Add(txtObservacion);
            pnlObservacion.Controls.Add(lblObservación);
            pnlObservacion.Dock = DockStyle.Top;
            pnlObservacion.Location = new Point(10, 62);
            pnlObservacion.Name = "pnlObservacion";
            pnlObservacion.Size = new Size(320, 75);
            pnlObservacion.TabIndex = 11;
            // 
            // UcOrderItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblSubtotal);
            Controls.Add(pnlBottom);
            Controls.Add(pnlObservacion);
            Controls.Add(lblPrecioUnitario);
            Controls.Add(pnlTop);
            ForeColor = Color.FromArgb(111, 119, 128);
            Margin = new Padding(0, 0, 0, 8);
            Name = "UcOrderItem";
            Padding = new Padding(10);
            Size = new Size(340, 190);
            pnlBottom.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlObservacion.ResumeLayout(false);
            pnlObservacion.PerformLayout();
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
        private Panel pnlTop;
        private Label lblObservación;
        private TextBox txtObservacion;
        private Panel pnlObservacion;
    }
}
