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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainMenu));
            pnlSidebar = new Panel();
            pnlMenu = new Panel();
            btnBitacoras = new Button();
            lblSeguridad = new Label();
            btnUsuarios = new Button();
            lblAdministracion = new Label();
            btnFidelizacion = new Button();
            btnPromociones = new Button();
            btnClientes = new Button();
            lblGestion = new Label();
            btnProveedores = new Button();
            btnCompras = new Button();
            btnInventario = new Button();
            btnProductos = new Button();
            lblInventario = new Label();
            btnCocina = new Button();
            btnMesas = new Button();
            btnCaja = new Button();
            btnFacturacion = new Button();
            btnVentas = new Button();
            lblOperaciones = new Label();
            btnEmpleados = new Button();
            btnReportes = new Button();
            btnInicio = new Button();
            pnlBottom = new Panel();
            btnCerrarSesion = new Button();
            pbCeviche = new PictureBox();
            pnlAppName = new Panel();
            lblAppName = new Label();
            pbLogo = new PictureBox();
            pnlHeader = new Panel();
            lblFecha = new Label();
            lblHora = new Label();
            lblUser = new Label();
            pictureBox2 = new PictureBox();
            pnlContent = new Panel();
            tmrReloj = new System.Windows.Forms.Timer(components);
            pnlSidebar.SuspendLayout();
            pnlMenu.SuspendLayout();
            pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCeviche).BeginInit();
            pnlAppName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(8, 31, 63);
            pnlSidebar.Controls.Add(pnlMenu);
            pnlSidebar.Controls.Add(pnlBottom);
            pnlSidebar.Controls.Add(pbCeviche);
            pnlSidebar.Controls.Add(pnlAppName);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(260, 900);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlMenu
            // 
            pnlMenu.AutoScroll = true;
            pnlMenu.BackColor = Color.Transparent;
            pnlMenu.Controls.Add(btnBitacoras);
            pnlMenu.Controls.Add(lblSeguridad);
            pnlMenu.Controls.Add(btnUsuarios);
            pnlMenu.Controls.Add(lblAdministracion);
            pnlMenu.Controls.Add(btnFidelizacion);
            pnlMenu.Controls.Add(btnPromociones);
            pnlMenu.Controls.Add(btnClientes);
            pnlMenu.Controls.Add(lblGestion);
            pnlMenu.Controls.Add(btnProveedores);
            pnlMenu.Controls.Add(btnCompras);
            pnlMenu.Controls.Add(btnInventario);
            pnlMenu.Controls.Add(btnProductos);
            pnlMenu.Controls.Add(lblInventario);
            pnlMenu.Controls.Add(btnCocina);
            pnlMenu.Controls.Add(btnMesas);
            pnlMenu.Controls.Add(btnCaja);
            pnlMenu.Controls.Add(btnFacturacion);
            pnlMenu.Controls.Add(btnVentas);
            pnlMenu.Controls.Add(lblOperaciones);
            pnlMenu.Controls.Add(btnEmpleados);
            pnlMenu.Controls.Add(btnReportes);
            pnlMenu.Controls.Add(btnInicio);
            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.Location = new Point(0, 150);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Padding = new Padding(8, 10, 8, 10);
            pnlMenu.Size = new Size(260, 690);
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
            btnBitacoras.Location = new Point(8, 790);
            btnBitacoras.Name = "btnBitacoras";
            btnBitacoras.Padding = new Padding(15, 0, 0, 0);
            btnBitacoras.Size = new Size(243, 45);
            btnBitacoras.TabIndex = 14;
            btnBitacoras.Text = "Auditoria";
            btnBitacoras.TextAlign = ContentAlignment.MiddleLeft;
            btnBitacoras.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBitacoras.UseVisualStyleBackColor = true;
            btnBitacoras.Click += btnBitacoras_Click;
            btnBitacoras.MouseEnter += Boton_MouseEnter;
            btnBitacoras.MouseLeave += Boton_MouseLeave;
            // 
            // lblSeguridad
            // 
            lblSeguridad.Dock = DockStyle.Top;
            lblSeguridad.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSeguridad.ForeColor = Color.White;
            lblSeguridad.Location = new Point(8, 760);
            lblSeguridad.Name = "lblSeguridad";
            lblSeguridad.Padding = new Padding(12, 0, 0, 0);
            lblSeguridad.Size = new Size(243, 30);
            lblSeguridad.TabIndex = 19;
            lblSeguridad.Text = "SEGURIDAD";
            lblSeguridad.TextAlign = ContentAlignment.MiddleCenter;
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
            btnUsuarios.Location = new Point(8, 715);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(15, 0, 0, 0);
            btnUsuarios.Size = new Size(243, 45);
            btnUsuarios.TabIndex = 1;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += btnUsuarios_Click;
            btnUsuarios.MouseEnter += Boton_MouseEnter;
            btnUsuarios.MouseLeave += Boton_MouseLeave;
            // 
            // lblAdministracion
            // 
            lblAdministracion.Dock = DockStyle.Top;
            lblAdministracion.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAdministracion.ForeColor = Color.White;
            lblAdministracion.Location = new Point(8, 685);
            lblAdministracion.Name = "lblAdministracion";
            lblAdministracion.Padding = new Padding(12, 0, 0, 0);
            lblAdministracion.Size = new Size(243, 30);
            lblAdministracion.TabIndex = 18;
            lblAdministracion.Text = "ADMINISTRACIÓN";
            lblAdministracion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnFidelizacion
            // 
            btnFidelizacion.BackColor = Color.Transparent;
            btnFidelizacion.Cursor = Cursors.Hand;
            btnFidelizacion.Dock = DockStyle.Top;
            btnFidelizacion.FlatAppearance.BorderSize = 0;
            btnFidelizacion.FlatStyle = FlatStyle.Flat;
            btnFidelizacion.Font = new Font("Century Gothic", 10.2F);
            btnFidelizacion.ForeColor = Color.White;
            btnFidelizacion.Image = Properties.Resources.loyalty_program;
            btnFidelizacion.ImageAlign = ContentAlignment.MiddleLeft;
            btnFidelizacion.Location = new Point(8, 640);
            btnFidelizacion.Name = "btnFidelizacion";
            btnFidelizacion.Padding = new Padding(15, 0, 0, 0);
            btnFidelizacion.Size = new Size(243, 45);
            btnFidelizacion.TabIndex = 15;
            btnFidelizacion.Text = "Fidelización";
            btnFidelizacion.TextAlign = ContentAlignment.MiddleLeft;
            btnFidelizacion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFidelizacion.UseVisualStyleBackColor = false;
            btnFidelizacion.Click += btnFidelizacion_Click;
            btnFidelizacion.MouseEnter += Boton_MouseEnter;
            btnFidelizacion.MouseLeave += Boton_MouseLeave;
            // 
            // btnPromociones
            // 
            btnPromociones.BackColor = Color.Transparent;
            btnPromociones.Cursor = Cursors.Hand;
            btnPromociones.Dock = DockStyle.Top;
            btnPromociones.FlatAppearance.BorderSize = 0;
            btnPromociones.FlatStyle = FlatStyle.Flat;
            btnPromociones.Font = new Font("Century Gothic", 10.2F);
            btnPromociones.ForeColor = Color.White;
            btnPromociones.Image = Properties.Resources.tag;
            btnPromociones.ImageAlign = ContentAlignment.MiddleLeft;
            btnPromociones.Location = new Point(8, 595);
            btnPromociones.Name = "btnPromociones";
            btnPromociones.Padding = new Padding(15, 0, 0, 0);
            btnPromociones.Size = new Size(243, 45);
            btnPromociones.TabIndex = 15;
            btnPromociones.Text = "Promociones";
            btnPromociones.TextAlign = ContentAlignment.MiddleLeft;
            btnPromociones.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPromociones.UseVisualStyleBackColor = false;
            btnPromociones.Click += btnPromociones_Click;
            btnPromociones.MouseEnter += Boton_MouseEnter;
            btnPromociones.MouseLeave += Boton_MouseLeave;
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
            btnClientes.Location = new Point(8, 550);
            btnClientes.Name = "btnClientes";
            btnClientes.Padding = new Padding(15, 0, 0, 0);
            btnClientes.Size = new Size(243, 45);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.TextAlign = ContentAlignment.MiddleLeft;
            btnClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            btnClientes.MouseEnter += Boton_MouseEnter;
            btnClientes.MouseLeave += Boton_MouseLeave;
            // 
            // lblGestion
            // 
            lblGestion.Dock = DockStyle.Top;
            lblGestion.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGestion.ForeColor = Color.White;
            lblGestion.Location = new Point(8, 520);
            lblGestion.Name = "lblGestion";
            lblGestion.Padding = new Padding(12, 0, 0, 0);
            lblGestion.Size = new Size(243, 30);
            lblGestion.TabIndex = 17;
            lblGestion.Text = "GESTIÓN";
            lblGestion.TextAlign = ContentAlignment.MiddleCenter;
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
            btnProveedores.Location = new Point(8, 475);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Padding = new Padding(15, 0, 0, 0);
            btnProveedores.Size = new Size(243, 45);
            btnProveedores.TabIndex = 8;
            btnProveedores.Text = "Proveedores";
            btnProveedores.TextAlign = ContentAlignment.MiddleLeft;
            btnProveedores.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProveedores.UseVisualStyleBackColor = false;
            btnProveedores.Click += btnProveedores_Click;
            btnProveedores.MouseEnter += Boton_MouseEnter;
            btnProveedores.MouseLeave += Boton_MouseLeave;
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
            btnCompras.Location = new Point(8, 430);
            btnCompras.Name = "btnCompras";
            btnCompras.Padding = new Padding(15, 0, 0, 0);
            btnCompras.Size = new Size(243, 45);
            btnCompras.TabIndex = 5;
            btnCompras.Text = "Compras";
            btnCompras.TextAlign = ContentAlignment.MiddleLeft;
            btnCompras.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCompras.UseVisualStyleBackColor = false;
            btnCompras.Click += btnCompras_Click;
            btnCompras.MouseEnter += Boton_MouseEnter;
            btnCompras.MouseLeave += Boton_MouseLeave;
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
            btnInventario.Location = new Point(8, 385);
            btnInventario.Name = "btnInventario";
            btnInventario.Padding = new Padding(15, 0, 0, 0);
            btnInventario.Size = new Size(243, 45);
            btnInventario.TabIndex = 4;
            btnInventario.Text = "Inventario";
            btnInventario.TextAlign = ContentAlignment.MiddleLeft;
            btnInventario.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInventario.UseVisualStyleBackColor = false;
            btnInventario.Click += btnInventario_Click;
            btnInventario.MouseEnter += Boton_MouseEnter;
            btnInventario.MouseLeave += Boton_MouseLeave;
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
            btnProductos.Location = new Point(8, 340);
            btnProductos.Name = "btnProductos";
            btnProductos.Padding = new Padding(15, 0, 0, 0);
            btnProductos.Size = new Size(243, 45);
            btnProductos.TabIndex = 3;
            btnProductos.Text = "Productos";
            btnProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnProductos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProductos.UseVisualStyleBackColor = false;
            btnProductos.Click += btnProductos_Click;
            btnProductos.MouseEnter += Boton_MouseEnter;
            btnProductos.MouseLeave += Boton_MouseLeave;
            // 
            // lblInventario
            // 
            lblInventario.Dock = DockStyle.Top;
            lblInventario.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInventario.ForeColor = Color.White;
            lblInventario.Location = new Point(8, 310);
            lblInventario.Name = "lblInventario";
            lblInventario.Padding = new Padding(12, 0, 0, 0);
            lblInventario.Size = new Size(243, 30);
            lblInventario.TabIndex = 16;
            lblInventario.Text = "INVENTARIO";
            lblInventario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCocina
            // 
            btnCocina.Cursor = Cursors.Hand;
            btnCocina.Dock = DockStyle.Top;
            btnCocina.FlatAppearance.BorderSize = 0;
            btnCocina.FlatStyle = FlatStyle.Flat;
            btnCocina.Font = new Font("Century Gothic", 10.2F);
            btnCocina.ForeColor = Color.White;
            btnCocina.Image = Properties.Resources.mobile_app;
            btnCocina.ImageAlign = ContentAlignment.MiddleLeft;
            btnCocina.Location = new Point(8, 265);
            btnCocina.Name = "btnCocina";
            btnCocina.Padding = new Padding(15, 0, 0, 0);
            btnCocina.Size = new Size(243, 45);
            btnCocina.TabIndex = 12;
            btnCocina.Text = "Cocina y Pedidos";
            btnCocina.TextAlign = ContentAlignment.MiddleLeft;
            btnCocina.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCocina.UseVisualStyleBackColor = true;
            btnCocina.Click += btnCocina_Click;
            btnCocina.MouseEnter += Boton_MouseEnter;
            btnCocina.MouseLeave += Boton_MouseLeave;
            // 
            // btnMesas
            // 
            btnMesas.Cursor = Cursors.Hand;
            btnMesas.Dock = DockStyle.Top;
            btnMesas.FlatAppearance.BorderSize = 0;
            btnMesas.FlatStyle = FlatStyle.Flat;
            btnMesas.Font = new Font("Century Gothic", 10.2F);
            btnMesas.ForeColor = Color.White;
            btnMesas.Image = Properties.Resources.table;
            btnMesas.ImageAlign = ContentAlignment.MiddleLeft;
            btnMesas.Location = new Point(8, 220);
            btnMesas.Name = "btnMesas";
            btnMesas.Padding = new Padding(15, 0, 0, 0);
            btnMesas.Size = new Size(243, 45);
            btnMesas.TabIndex = 12;
            btnMesas.Text = "Mesas y Reservas";
            btnMesas.TextAlign = ContentAlignment.MiddleLeft;
            btnMesas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMesas.UseVisualStyleBackColor = true;
            btnMesas.Click += btnMesas_Click;
            btnMesas.MouseEnter += Boton_MouseEnter;
            btnMesas.MouseLeave += Boton_MouseLeave;
            // 
            // btnCaja
            // 
            btnCaja.Cursor = Cursors.Hand;
            btnCaja.Dock = DockStyle.Top;
            btnCaja.FlatAppearance.BorderSize = 0;
            btnCaja.FlatStyle = FlatStyle.Flat;
            btnCaja.Font = new Font("Century Gothic", 10.2F);
            btnCaja.ForeColor = Color.White;
            btnCaja.Image = Properties.Resources.wallet;
            btnCaja.ImageAlign = ContentAlignment.MiddleLeft;
            btnCaja.Location = new Point(8, 175);
            btnCaja.Name = "btnCaja";
            btnCaja.Padding = new Padding(15, 0, 0, 0);
            btnCaja.Size = new Size(243, 45);
            btnCaja.TabIndex = 15;
            btnCaja.Text = "Caja";
            btnCaja.TextAlign = ContentAlignment.MiddleLeft;
            btnCaja.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCaja.UseVisualStyleBackColor = true;
            btnCaja.Click += btnCaja_Click;
            btnCaja.MouseEnter += Boton_MouseEnter;
            btnCaja.MouseLeave += Boton_MouseLeave;
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
            btnFacturacion.Location = new Point(8, 130);
            btnFacturacion.Name = "btnFacturacion";
            btnFacturacion.Padding = new Padding(15, 0, 0, 0);
            btnFacturacion.Size = new Size(243, 45);
            btnFacturacion.TabIndex = 7;
            btnFacturacion.Text = "Facturación";
            btnFacturacion.TextAlign = ContentAlignment.MiddleLeft;
            btnFacturacion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFacturacion.UseVisualStyleBackColor = false;
            btnFacturacion.Click += btnFacturacion_Click;
            btnFacturacion.MouseEnter += Boton_MouseEnter;
            btnFacturacion.MouseLeave += Boton_MouseLeave;
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
            btnVentas.Location = new Point(8, 85);
            btnVentas.Name = "btnVentas";
            btnVentas.Padding = new Padding(15, 0, 0, 0);
            btnVentas.Size = new Size(243, 45);
            btnVentas.TabIndex = 6;
            btnVentas.Text = "Punto de Venta";
            btnVentas.TextAlign = ContentAlignment.MiddleLeft;
            btnVentas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVentas.UseVisualStyleBackColor = false;
            btnVentas.Click += btnVentas_Click;
            btnVentas.MouseEnter += Boton_MouseEnter;
            btnVentas.MouseLeave += Boton_MouseLeave;
            // 
            // lblOperaciones
            // 
            lblOperaciones.Dock = DockStyle.Top;
            lblOperaciones.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOperaciones.ForeColor = Color.White;
            lblOperaciones.Location = new Point(8, 55);
            lblOperaciones.Name = "lblOperaciones";
            lblOperaciones.Padding = new Padding(12, 0, 0, 0);
            lblOperaciones.Size = new Size(243, 30);
            lblOperaciones.TabIndex = 0;
            lblOperaciones.Text = "OPERACIONES";
            lblOperaciones.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnEmpleados
            // 
            btnEmpleados.FlatAppearance.BorderSize = 0;
            btnEmpleados.FlatStyle = FlatStyle.Flat;
            btnEmpleados.Font = new Font("Century Gothic", 10.2F);
            btnEmpleados.ForeColor = Color.White;
            btnEmpleados.Image = Properties.Resources.manager;
            btnEmpleados.ImageAlign = ContentAlignment.MiddleLeft;
            btnEmpleados.Location = new Point(25, 432);
            btnEmpleados.Name = "btnEmpleados";
            btnEmpleados.Padding = new Padding(15, 0, 0, 0);
            btnEmpleados.Size = new Size(234, 45);
            btnEmpleados.TabIndex = 11;
            btnEmpleados.Text = "Empleados";
            btnEmpleados.TextAlign = ContentAlignment.MiddleLeft;
            btnEmpleados.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEmpleados.UseVisualStyleBackColor = true;
            btnEmpleados.Click += btnEmpleados_Click;
            btnEmpleados.MouseEnter += Boton_MouseEnter;
            btnEmpleados.MouseLeave += Boton_MouseLeave;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.Transparent;
            btnReportes.Cursor = Cursors.Hand;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Century Gothic", 10.2F);
            btnReportes.ForeColor = Color.White;
            btnReportes.Image = Properties.Resources.statisctics;
            btnReportes.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes.Location = new Point(14, 432);
            btnReportes.Name = "btnReportes";
            btnReportes.Padding = new Padding(15, 0, 0, 0);
            btnReportes.Size = new Size(234, 45);
            btnReportes.TabIndex = 9;
            btnReportes.Text = "Reportes";
            btnReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnReportes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            btnReportes.MouseEnter += Boton_MouseEnter;
            btnReportes.MouseLeave += Boton_MouseLeave;
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
            btnInicio.Image = Properties.Resources.report;
            btnInicio.ImageAlign = ContentAlignment.MiddleLeft;
            btnInicio.Location = new Point(8, 10);
            btnInicio.Name = "btnInicio";
            btnInicio.Padding = new Padding(12, 0, 0, 0);
            btnInicio.Size = new Size(243, 45);
            btnInicio.TabIndex = 0;
            btnInicio.Text = "Reportes";
            btnInicio.TextAlign = ContentAlignment.MiddleLeft;
            btnInicio.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInicio.UseVisualStyleBackColor = false;
            btnInicio.Click += btnInicio_Click;
            btnInicio.MouseEnter += Boton_MouseEnter;
            btnInicio.MouseLeave += Boton_MouseLeave;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.Transparent;
            pnlBottom.Controls.Add(btnCerrarSesion);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 840);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(8, 5, 8, 8);
            pnlBottom.Size = new Size(260, 60);
            pnlBottom.TabIndex = 2;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.Red;
            btnCerrarSesion.Cursor = Cursors.Hand;
            btnCerrarSesion.Dock = DockStyle.Fill;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Image = (Image)resources.GetObject("btnCerrarSesion.Image");
            btnCerrarSesion.ImageAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.Location = new Point(8, 5);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Padding = new Padding(15, 0, 0, 0);
            btnCerrarSesion.Size = new Size(244, 47);
            btnCerrarSesion.TabIndex = 10;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.TextAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // pbCeviche
            // 
            pbCeviche.BorderStyle = BorderStyle.FixedSingle;
            pbCeviche.Dock = DockStyle.Top;
            pbCeviche.Image = Properties.Resources.LOGO;
            pbCeviche.Location = new Point(0, 70);
            pbCeviche.Name = "pbCeviche";
            pbCeviche.Size = new Size(260, 80);
            pbCeviche.SizeMode = PictureBoxSizeMode.Zoom;
            pbCeviche.TabIndex = 0;
            pbCeviche.TabStop = false;
            // 
            // pnlAppName
            // 
            pnlAppName.BackColor = Color.White;
            pnlAppName.BorderStyle = BorderStyle.FixedSingle;
            pnlAppName.Controls.Add(lblAppName);
            pnlAppName.Controls.Add(pbLogo);
            pnlAppName.Dock = DockStyle.Top;
            pnlAppName.Location = new Point(0, 0);
            pnlAppName.Name = "pnlAppName";
            pnlAppName.Size = new Size(260, 70);
            pnlAppName.TabIndex = 1;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.FromArgb(8, 31, 63);
            lblAppName.Location = new Point(94, 24);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(120, 22);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "Ocean Desk";
            // 
            // pbLogo
            // 
            pbLogo.Image = Properties.Resources.Icon_Ocean_Desk;
            pbLogo.Location = new Point(5, -23);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(103, 127);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 1;
            pbLogo.TabStop = false;
            // 
            // pnlHeader
            // 
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlHeader.Controls.Add(lblFecha);
            pnlHeader.Controls.Add(lblHora);
            pnlHeader.Controls.Add(lblUser);
            pnlHeader.Controls.Add(pictureBox2);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(260, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(940, 70);
            pnlHeader.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(24, 31);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(60, 21);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "label3";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHora.Location = new Point(24, 8);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(72, 23);
            lblHora.TabIndex = 2;
            lblHora.Text = "label2";
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.None;
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUser.Location = new Point(658, 25);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(107, 21);
            lblUser.TabIndex = 1;
            lblUser.Text = "Rick Zorquin";
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.Image = Properties.Resources.admin_person_user_man_2839;
            pictureBox2.Location = new Point(856, 7);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(48, 48);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(245, 247, 250);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(260, 70);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(20);
            pnlContent.Size = new Size(940, 830);
            pnlContent.TabIndex = 2;
            pnlContent.Paint += pnlContent_Paint;
            // 
            // tmrReloj
            // 
            tmrReloj.Tick += tmrReloj_Tick;
            // 
            // FrmMainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 900);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(1200, 700);
            Name = "FrmMainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmMainMenu";
            WindowState = FormWindowState.Maximized;
            pnlSidebar.ResumeLayout(false);
            pnlMenu.ResumeLayout(false);
            pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbCeviche).EndInit();
            pnlAppName.ResumeLayout(false);
            pnlAppName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlHeader;
        private Panel pnlContent;
        private PictureBox pbCeviche;
        private PictureBox pbLogo;
        private Label lblAppName;
        private Panel pnlAppName;
        private Panel pnlMenu;
        private Button btnCerrarSesion;
        private PictureBox pictureBox2;
        private Label lblUser;
        private System.Windows.Forms.Timer tmrReloj;
        private Label lblHora;
        private Label lblFecha;
        private Button btnBitacoras;
        private Button btnCompras;
        private Button btnCocina;
        private Button btnInicio;
        private Button btnMesas;
        private Button btnUsuarios;
        private Button btnClientes;
        private Button btnEmpleados;
        private Button btnProductos;
        private Button btnReportes;
        private Button btnInventario;
        private Button btnProveedores;
        private Button btnVentas;
        private Button btnFacturacion;
        private Panel pnlBottom;
        private Label lblOperaciones;
        private Button btnCaja;
        private Label lblInventario;
        private Button btnPromociones;
        private Label lblGestion;
        private Button btnFidelizacion;
        private Label lblSeguridad;
        private Label lblAdministracion;
    }
}