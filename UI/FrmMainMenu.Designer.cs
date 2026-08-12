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
            btnBitacoras = new Button();
            btnCocina = new Button();
            btnMesas = new Button();
            btnCerrarSesion = new Button();
            btnEmpleados = new Button();
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
            pnlSidebar.Size = new Size(230, 900);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(btnBitacoras);
            pnlMenu.Controls.Add(btnCocina);
            pnlMenu.Controls.Add(btnMesas);
            pnlMenu.Controls.Add(btnCerrarSesion);
            pnlMenu.Controls.Add(btnEmpleados);
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
            pnlMenu.Size = new Size(230, 770);
            pnlMenu.TabIndex = 2;
            // 
            // btnBitacoras
            // 
            btnBitacoras.Dock = DockStyle.Top;
            btnBitacoras.FlatAppearance.BorderSize = 0;
            btnBitacoras.FlatStyle = FlatStyle.Flat;
            btnBitacoras.Font = new Font("Century Gothic", 10.2F);
            btnBitacoras.ForeColor = Color.White;
            btnBitacoras.Image = Properties.Resources.manual;
            btnBitacoras.ImageAlign = ContentAlignment.MiddleLeft;
            btnBitacoras.Location = new Point(8, 595);
            btnBitacoras.Name = "btnBitacoras";
            btnBitacoras.Padding = new Padding(15, 0, 0, 0);
            btnBitacoras.Size = new Size(214, 45);
            btnBitacoras.TabIndex = 14;
            btnBitacoras.Text = "Bítacoras";
            btnBitacoras.TextAlign = ContentAlignment.MiddleLeft;
            btnBitacoras.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBitacoras.UseVisualStyleBackColor = true;
            // 
            // btnCocina
            // 
            btnCocina.Dock = DockStyle.Top;
            btnCocina.FlatAppearance.BorderSize = 0;
            btnCocina.FlatStyle = FlatStyle.Flat;
            btnCocina.Font = new Font("Century Gothic", 10.2F);
            btnCocina.ForeColor = Color.White;
            btnCocina.Image = Properties.Resources.mobile_app;
            btnCocina.ImageAlign = ContentAlignment.MiddleLeft;
            btnCocina.Location = new Point(8, 550);
            btnCocina.Name = "btnCocina";
            btnCocina.Padding = new Padding(15, 0, 0, 0);
            btnCocina.Size = new Size(214, 45);
            btnCocina.TabIndex = 12;
            btnCocina.Text = "Cocina";
            btnCocina.TextAlign = ContentAlignment.MiddleLeft;
            btnCocina.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCocina.UseVisualStyleBackColor = true;
            // 
            // btnMesas
            // 
            btnMesas.Dock = DockStyle.Top;
            btnMesas.FlatAppearance.BorderSize = 0;
            btnMesas.FlatStyle = FlatStyle.Flat;
            btnMesas.Font = new Font("Century Gothic", 10.2F);
            btnMesas.ForeColor = Color.White;
            btnMesas.Image = Properties.Resources.table;
            btnMesas.ImageAlign = ContentAlignment.MiddleLeft;
            btnMesas.Location = new Point(8, 505);
            btnMesas.Name = "btnMesas";
            btnMesas.Padding = new Padding(15, 0, 0, 0);
            btnMesas.Size = new Size(214, 45);
            btnMesas.TabIndex = 12;
            btnMesas.Text = "Mesas";
            btnMesas.TextAlign = ContentAlignment.MiddleLeft;
            btnMesas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMesas.UseVisualStyleBackColor = true;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.Red;
            btnCerrarSesion.Cursor = Cursors.Hand;
            btnCerrarSesion.Dock = DockStyle.Bottom;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Image = Properties.Resources.out_log_icon_255959;
            btnCerrarSesion.ImageAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.Location = new Point(8, 715);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Padding = new Padding(15, 0, 0, 0);
            btnCerrarSesion.Size = new Size(214, 45);
            btnCerrarSesion.TabIndex = 10;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.TextAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnEmpleados
            // 
            btnEmpleados.Dock = DockStyle.Top;
            btnEmpleados.FlatAppearance.BorderSize = 0;
            btnEmpleados.FlatStyle = FlatStyle.Flat;
            btnEmpleados.Font = new Font("Century Gothic", 10.2F);
            btnEmpleados.ForeColor = Color.White;
            btnEmpleados.Image = Properties.Resources.manager;
            btnEmpleados.ImageAlign = ContentAlignment.MiddleLeft;
            btnEmpleados.Location = new Point(8, 460);
            btnEmpleados.Name = "btnEmpleados";
            btnEmpleados.Padding = new Padding(15, 0, 0, 0);
            btnEmpleados.Size = new Size(214, 45);
            btnEmpleados.TabIndex = 11;
            btnEmpleados.Text = "Empleados";
            btnEmpleados.TextAlign = ContentAlignment.MiddleLeft;
            btnEmpleados.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEmpleados.UseVisualStyleBackColor = true;
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
            btnReportes.Image = Properties.Resources.statisctics;
            btnReportes.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes.Location = new Point(8, 415);
            btnReportes.Name = "btnReportes";
            btnReportes.Padding = new Padding(15, 0, 0, 0);
            btnReportes.Size = new Size(214, 45);
            btnReportes.TabIndex = 9;
            btnReportes.Text = "Reportes";
            btnReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnReportes.TextImageRelation = TextImageRelation.ImageBeforeText;
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
            btnProveedores.Image = Properties.Resources.value_chain;
            btnProveedores.ImageAlign = ContentAlignment.MiddleLeft;
            btnProveedores.Location = new Point(8, 370);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Padding = new Padding(15, 0, 0, 0);
            btnProveedores.Size = new Size(214, 45);
            btnProveedores.TabIndex = 8;
            btnProveedores.Text = "Proveedores";
            btnProveedores.TextAlign = ContentAlignment.MiddleLeft;
            btnProveedores.TextImageRelation = TextImageRelation.ImageBeforeText;
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
            btnFacturacion.Image = Properties.Resources.payment;
            btnFacturacion.ImageAlign = ContentAlignment.MiddleLeft;
            btnFacturacion.Location = new Point(8, 325);
            btnFacturacion.Name = "btnFacturacion";
            btnFacturacion.Padding = new Padding(15, 0, 0, 0);
            btnFacturacion.Size = new Size(214, 45);
            btnFacturacion.TabIndex = 7;
            btnFacturacion.Text = "Facturación";
            btnFacturacion.TextAlign = ContentAlignment.MiddleLeft;
            btnFacturacion.TextImageRelation = TextImageRelation.ImageBeforeText;
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
            btnVentas.Image = Properties.Resources.point_of_sale;
            btnVentas.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas.Location = new Point(8, 280);
            btnVentas.Name = "btnVentas";
            btnVentas.Padding = new Padding(15, 0, 0, 0);
            btnVentas.Size = new Size(214, 45);
            btnVentas.TabIndex = 6;
            btnVentas.Text = "Punto de Venta";
            btnVentas.TextAlign = ContentAlignment.MiddleLeft;
            btnVentas.TextImageRelation = TextImageRelation.ImageBeforeText;
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
            btnCompras.Image = Properties.Resources.money_bag;
            btnCompras.ImageAlign = ContentAlignment.MiddleLeft;
            btnCompras.Location = new Point(8, 235);
            btnCompras.Name = "btnCompras";
            btnCompras.Padding = new Padding(15, 0, 0, 0);
            btnCompras.Size = new Size(214, 45);
            btnCompras.TabIndex = 5;
            btnCompras.Text = "Compras";
            btnCompras.TextAlign = ContentAlignment.MiddleLeft;
            btnCompras.TextImageRelation = TextImageRelation.ImageBeforeText;
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
            btnInventario.Image = Properties.Resources.inventory;
            btnInventario.ImageAlign = ContentAlignment.MiddleLeft;
            btnInventario.Location = new Point(8, 190);
            btnInventario.Name = "btnInventario";
            btnInventario.Padding = new Padding(15, 0, 0, 0);
            btnInventario.Size = new Size(214, 45);
            btnInventario.TabIndex = 4;
            btnInventario.Text = "Inventario";
            btnInventario.TextAlign = ContentAlignment.MiddleLeft;
            btnInventario.TextImageRelation = TextImageRelation.ImageBeforeText;
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
            btnProductos.Image = Properties.Resources.products;
            btnProductos.ImageAlign = ContentAlignment.MiddleLeft;
            btnProductos.Location = new Point(8, 145);
            btnProductos.Name = "btnProductos";
            btnProductos.Padding = new Padding(15, 0, 0, 0);
            btnProductos.Size = new Size(214, 45);
            btnProductos.TabIndex = 3;
            btnProductos.Text = "Productos";
            btnProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnProductos.TextImageRelation = TextImageRelation.ImageBeforeText;
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
            btnClientes.Image = Properties.Resources.customer_review;
            btnClientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnClientes.Location = new Point(8, 100);
            btnClientes.Name = "btnClientes";
            btnClientes.Padding = new Padding(15, 0, 0, 0);
            btnClientes.Size = new Size(214, 45);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.TextAlign = ContentAlignment.MiddleLeft;
            btnClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
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
            btnUsuarios.Image = Properties.Resources.group;
            btnUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.Location = new Point(8, 55);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(15, 0, 0, 0);
            btnUsuarios.Size = new Size(214, 45);
            btnUsuarios.TabIndex = 1;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
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
            pnlHeader.Size = new Size(770, 65);
            pnlHeader.TabIndex = 1;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(245, 247, 250);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(230, 65);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(20);
            pnlContent.Size = new Size(770, 835);
            pnlContent.TabIndex = 2;
            // 
            // FrmMainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 900);
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
        private Button btnMesas;
        private Button btnEmpleados;
        private Button btnBitacoras;
        private Button btnCocina;
    }
}