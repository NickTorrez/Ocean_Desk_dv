namespace Ocean_Desk_dv.UI.Controls
{
    partial class UcProductoCard
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
            picProducto = new PictureBox();
            lblNombreProducto = new Label();
            lblPrecio = new Label();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)picProducto).BeginInit();
            SuspendLayout();
            // 
            // picProducto
            // 
            picProducto.BackColor = Color.FromArgb(238, 243, 247);
            picProducto.Dock = DockStyle.Top;
            picProducto.Location = new Point(10, 10);
            picProducto.Name = "picProducto";
            picProducto.Size = new Size(160, 115);
            picProducto.SizeMode = PictureBoxSizeMode.Zoom;
            picProducto.TabIndex = 0;
            picProducto.TabStop = false;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoEllipsis = true;
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Dock = DockStyle.Top;
            lblNombreProducto.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreProducto.ForeColor = Color.FromArgb(8, 31, 63);
            lblNombreProducto.Location = new Point(10, 125);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(128, 19);
            lblNombreProducto.TabIndex = 1;
            lblNombreProducto.Text = "Ceviche Mixto";
            lblNombreProducto.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPrecio
            // 
            lblPrecio.Dock = DockStyle.Top;
            lblPrecio.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrecio.ForeColor = Color.FromArgb(8, 31, 63);
            lblPrecio.Location = new Point(10, 144);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(160, 25);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "C$ 0.00";
            lblPrecio.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(8, 126, 164);
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.Dock = DockStyle.Bottom;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(10, 175);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(160, 35);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // UcProductoCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnAgregar);
            Controls.Add(lblPrecio);
            Controls.Add(lblNombreProducto);
            Controls.Add(picProducto);
            Margin = new Padding(8);
            Name = "UcProductoCard";
            Padding = new Padding(10);
            Size = new Size(180, 220);
            MouseEnter += UcProductoCard_MouseEnter;
            MouseLeave += UcProductoCard_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)picProducto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picProducto;
        private Label lblNombreProducto;
        private Label lblPrecio;
        private Button btnAgregar;
    }
}
