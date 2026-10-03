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
            pnlBarraSuperior.SuspendLayout();
            tlpBarraSuperior.SuspendLayout();
            pnlContenido.SuspendLayout();
            tlpPrincipal.SuspendLayout();
            Tcproductos.SuspendLayout();
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
            pnlBarraSuperior.Size = new Size(1446, 78);
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
            tlpBarraSuperior.Size = new Size(1422, 62);
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
            pnlContenido.Size = new Size(1446, 794);
            pnlContenido.TabIndex = 1;
            // 
            // tlpPrincipal
            // 
            tlpPrincipal.ColumnCount = 2;
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.8616867F));
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.1383133F));
            tlpPrincipal.Controls.Add(pnlDatosProducto, 1, 0);
            tlpPrincipal.Controls.Add(Tcproductos, 0, 0);
            tlpPrincipal.Dock = DockStyle.Fill;
            tlpPrincipal.Location = new Point(0, 0);
            tlpPrincipal.Name = "tlpPrincipal";
            tlpPrincipal.RowCount = 1;
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpPrincipal.Size = new Size(1446, 794);
            tlpPrincipal.TabIndex = 0;
            // 
            // pnlDatosProducto
            // 
            pnlDatosProducto.BackColor = Color.White;
            pnlDatosProducto.Dock = DockStyle.Fill;
            pnlDatosProducto.Location = new Point(739, 18);
            pnlDatosProducto.Margin = new Padding(18);
            pnlDatosProducto.Name = "pnlDatosProducto";
            pnlDatosProducto.Size = new Size(689, 758);
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
            Tcproductos.Size = new Size(715, 788);
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
            tpReceta.Size = new Size(707, 755);
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
            txtBuscarProducto.Size = new Size(982, 21);
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
            btnNuevoProducto.Location = new Point(1045, 3);
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
            btnEditarProducto.Location = new Point(1165, 3);
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
            btnCambiarEstado.Location = new Point(1285, 3);
            btnCambiarEstado.Name = "btnCambiarEstado";
            btnCambiarEstado.Size = new Size(134, 56);
            btnCambiarEstado.TabIndex = 0;
            btnCambiarEstado.Text = "Cambiar estado";
            btnCambiarEstado.UseVisualStyleBackColor = false;
            // 
            // FrmProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1446, 794);
            Controls.Add(pnlBarraSuperior);
            Controls.Add(pnlContenido);
            Name = "FrmProductos";
            Text = "FrmProductos";
            pnlBarraSuperior.ResumeLayout(false);
            tlpBarraSuperior.ResumeLayout(false);
            tlpBarraSuperior.PerformLayout();
            pnlContenido.ResumeLayout(false);
            tlpPrincipal.ResumeLayout(false);
            Tcproductos.ResumeLayout(false);
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
    }
}