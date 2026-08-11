namespace Ocean_Desk_dv.UI
{
    partial class FrmMainMenu
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
            pnlSidebar = new Panel();
            pnlMenu = new Panel();
            btnReportes = new Button();
            btnProveedores = new Button();
            btnFacturacion = new Button();
            btnVentas = new Button();
            btnCompras = new Button();
            btnInventario = new Button();
            btnProductos = new Button();
            btnClientes = new Button();
            btnUsuarios = new Button();
            btnInicio = new Button();
            pictureBox1 = new PictureBox();
            pnlSidebarHeader = new Panel();
            lblAppName = new Label();
            pbLogo = new PictureBox();
            pnlHeader = new Panel();
            pnlContent = new Panel();
            btnCerrarSesion = new Button();
            pnlSidebar.SuspendLayout();
            pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlSidebarHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(8, 31, 63);
            pnlSidebar.Controls.Add(pnlMenu);
            pnlSidebar.Controls.Add(pictureBox1);
            pnlSidebar.Controls.Add(pnlSidebarHeader);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(230, 800);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(btnCerrarSesion);
            pnlMenu.Controls.Add(btnReportes);
            pnlMenu.Controls.Add(btnProveedores);
            pnlMenu.Controls.Add(btnFacturacion);
            pnlMenu.Controls.Add(btnVentas);
            pnlMenu.Controls.Add(btnCompras);
            pnlMenu.Controls.Add(btnInventario);
            pnlMenu.Controls.Add(btnProductos);
            pnlMenu.Controls.Add(btnClientes);
            pnlMenu.Controls.Add(btnUsuarios);
            pnlMenu.Controls.Add(btnInicio);
            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.Location = new Point(0, 130);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Padding = new Padding(8, 10, 8, 10);
            pnlMenu.Size = new Size(230, 670);
            pnlMenu.TabIndex = 2;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.Transparent;
            btnReportes.Cursor = Cursors.Hand;
            btnReportes.Dock = DockStyle.Top;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Century Gothic", 10.2F);
            btnReportes.ForeColor = Color.White;
            btnReportes.Location = new Point(8, 415);
            btnReportes.Name = "btnReportes";
            btnReportes.Padding = new Padding(15, 0, 0, 0);
            btnReportes.Size = new Size(214, 45);
            btnReportes.TabIndex = 9;
            btnReportes.Text = "Reportes";
            btnReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnReportes.UseVisualStyleBackColor = false;
            // 
            // btnProveedores
            // 
            btnProveedores.BackColor = Color.Transparent;
            btnProveedores.Cursor = Cursors.Hand;
            btnProveedores.Dock = DockStyle.Top;
            btnProveedores.FlatAppearance.BorderSize = 0;
            btnProveedores.FlatStyle = FlatStyle.Flat;
            btnProveedores.Font = new Font("Century Gothic", 10.2F);
            btnProveedores.ForeColor = Color.White;
            btnProveedores.Location = new Point(8, 370);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Padding = new Padding(15, 0, 0, 0);
            btnProveedores.Size = new Size(214, 45);
            btnProveedores.TabIndex = 8;
            btnProveedores.Text = "Proveedores";
            btnProveedores.TextAlign = ContentAlignment.MiddleLeft;
            btnProveedores.UseVisualStyleBackColor = false;
            // 
            // btnFacturacion
            // 
            btnFacturacion.BackColor = Color.Transparent;
            btnFacturacion.Cursor = Cursors.Hand;
            btnFacturacion.Dock = DockStyle.Top;
            btnFacturacion.FlatAppearance.BorderSize = 0;
            btnFacturacion.FlatStyle = FlatStyle.Flat;
            btnFacturacion.Font = new Font("Century Gothic", 10.2F);
            btnFacturacion.ForeColor = Color.White;
            btnFacturacion.Location = new Point(8, 325);
            btnFacturacion.Name = "btnFacturacion";
            btnFacturacion.Padding = new Padding(15, 0, 0, 0);
            btnFacturacion.Size = new Size(214, 45);
            btnFacturacion.TabIndex = 7;
            btnFacturacion.Text = "Facturación";
            btnFacturacion.TextAlign = ContentAlignment.MiddleLeft;
            btnFacturacion.UseVisualStyleBackColor = false;
            // 
            // btnVentas
            // 
            btnVentas.BackColor = Color.Transparent;
            btnVentas.Cursor = Cursors.Hand;
            btnVentas.Dock = DockStyle.Top;
            btnVentas.FlatAppearance.BorderSize = 0;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Century Gothic", 10.2F);
            btnVentas.ForeColor = Color.White;
            btnVentas.Location = new Point(8, 280);
            btnVentas.Name = "btnVentas";
            btnVentas.Padding = new Padding(15, 0, 0, 0);
            btnVentas.Size = new Size(214, 45);
            btnVentas.TabIndex = 6;
            btnVentas.Text = "Ventas";
            btnVentas.TextAlign = ContentAlignment.MiddleLeft;
            btnVentas.UseVisualStyleBackColor = false;
            // 
            // btnCompras
            // 
            btnCompras.BackColor = Color.Transparent;
            btnCompras.Cursor = Cursors.Hand;
            btnCompras.Dock = DockStyle.Top;
            btnCompras.FlatAppearance.BorderSize = 0;
            btnCompras.FlatStyle = FlatStyle.Flat;
            btnCompras.Font = new Font("Century Gothic", 10.2F);
            btnCompras.ForeColor = Color.White;
            btnCompras.Location = new Point(8, 235);
            btnCompras.Name = "btnCompras";
            btnCompras.Padding = new Padding(15, 0, 0, 0);
            btnCompras.Size = new Size(214, 45);
            btnCompras.TabIndex = 5;
            btnCompras.Text = "Compras";
            btnCompras.TextAlign = ContentAlignment.MiddleLeft;
            btnCompras.UseVisualStyleBackColor = false;
            // 
            // btnInventario
            // 
            btnInventario.BackColor = Color.Transparent;
            btnInventario.Cursor = Cursors.Hand;
            btnInventario.Dock = DockStyle.Top;
            btnInventario.FlatAppearance.BorderSize = 0;
            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.Font = new Font("Century Gothic", 10.2F);
            btnInventario.ForeColor = Color.White;
            btnInventario.Location = new Point(8, 190);
            btnInventario.Name = "btnInventario";
            btnInventario.Padding = new Padding(15, 0, 0, 0);
            btnInventario.Size = new Size(214, 45);
            btnInventario.TabIndex = 4;
            btnInventario.Text = "Inventario";
            btnInventario.TextAlign = ContentAlignment.MiddleLeft;
            btnInventario.UseVisualStyleBackColor = false;
            // 
            // btnProductos
            // 
            btnProductos.BackColor = Color.Transparent;
            btnProductos.Cursor = Cursors.Hand;
            btnProductos.Dock = DockStyle.Top;
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Century Gothic", 10.2F);
            btnProductos.ForeColor = Color.White;
            btnProductos.Location = new Point(8, 145);
            btnProductos.Name = "btnProductos";
            btnProductos.Padding = new Padding(15, 0, 0, 0);
            btnProductos.Size = new Size(214, 45);
            btnProductos.TabIndex = 3;
            btnProductos.Text = "Productos";
            btnProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnProductos.UseVisualStyleBackColor = false;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.Transparent;
            btnClientes.Cursor = Cursors.Hand;
            btnClientes.Dock = DockStyle.Top;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Century Gothic", 10.2F);
            btnClientes.ForeColor = Color.White;
            btnClientes.Location = new Point(8, 100);
            btnClientes.Name = "btnClientes";
            btnClientes.Padding = new Padding(15, 0, 0, 0);
            btnClientes.Size = new Size(214, 45);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.TextAlign = ContentAlignment.MiddleLeft;
            btnClientes.UseVisualStyleBackColor = false;
            // 
            // btnUsuarios
            // 
            btnUsuarios.BackColor = Color.Transparent;
            btnUsuarios.Cursor = Cursors.Hand;
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Century Gothic", 10.2F);
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.Location = new Point(8, 55);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(15, 0, 0, 0);
            btnUsuarios.Size = new Size(214, 45);
            btnUsuarios.TabIndex = 1;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.UseVisualStyleBackColor = false;
            // 
            // btnInicio
            // 
            btnInicio.BackColor = Color.Transparent;
            btnInicio.Cursor = Cursors.Hand;
            btnInicio.Dock = DockStyle.Top;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInicio.ForeColor = Color.White;
            btnInicio.Image = Properties.Resources.house;
            btnInicio.ImageAlign = ContentAlignment.MiddleLeft;
            btnInicio.Location = new Point(8, 10);
            btnInicio.Name = "btnInicio";
            btnInicio.Padding = new Padding(12, 0, 0, 0);
            btnInicio.Size = new Size(214, 45);
            btnInicio.TabIndex = 0;
            btnInicio.Text = "Inicio";
            btnInicio.TextAlign = ContentAlignment.MiddleLeft;
            btnInicio.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInicio.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.LOGO;
            pictureBox1.Location = new Point(0, 65);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(230, 65);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnlSidebarHeader
            // 
            pnlSidebarHeader.BackColor = Color.White;
            pnlSidebarHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlSidebarHeader.Controls.Add(lblAppName);
            pnlSidebarHeader.Controls.Add(pbLogo);
            pnlSidebarHeader.Dock = DockStyle.Top;
            pnlSidebarHeader.Location = new Point(0, 0);
            pnlSidebarHeader.Name = "pnlSidebarHeader";
            pnlSidebarHeader.Size = new Size(230, 65);
            pnlSidebarHeader.TabIndex = 1;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.FromArgb(8, 31, 63);
            lblAppName.Location = new Point(93, 22);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(120, 22);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "Ocean Desk";
            // 
            // pbLogo
            // 
            pbLogo.Image = Properties.Resources.Icon_Ocean_Desk;
            pbLogo.Location = new Point(3, -18);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(103, 110);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 1;
            pbLogo.TabStop = false;
            // 
            // pnlHeader
            // 
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(230, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(752, 65);
            pnlHeader.TabIndex = 1;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(245, 247, 250);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(230, 65);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(20);
            pnlContent.Size = new Size(752, 735);
            pnlContent.TabIndex = 2;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Cursor = Cursors.Hand;
            btnCerrarSesion.Dock = DockStyle.Bottom;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(8, 615);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Padding = new Padding(15, 0, 0, 0);
            btnCerrarSesion.Size = new Size(214, 45);
            btnCerrarSesion.TabIndex = 10;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.TextAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // FrmMainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(982, 800);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMainMenu";
            Text = "FrmMainMenu";
            WindowState = FormWindowState.Maximized;
            pnlSidebar.ResumeLayout(false);
            pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlSidebarHeader.ResumeLayout(false);
            pnlSidebarHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlHeader;
        private Panel pnlContent;
        private PictureBox pictureBox1;
        private PictureBox pbLogo;
        private Label lblAppName;
        private Panel pnlSidebarHeader;
        private Panel pnlMenu;
        private Button btnInicio;
        private Button btnCompras;
        private Button btnInventario;
        private Button btnProductos;
        private Button btnClientes;
        private Button btnUsuarios;
        private Button btnReportes;
        private Button btnProveedores;
        private Button btnFacturacion;
        private Button btnVentas;
        private Button btnCerrarSesion;
    }
}