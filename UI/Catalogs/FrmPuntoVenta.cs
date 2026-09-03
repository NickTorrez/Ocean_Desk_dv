using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.UI.Controls;
using Ocean_Desk_dv.UI.Catalogs;


namespace Ocean_Desk_dv.UI.Catalogs
{
    public partial class FrmPuntoVenta : Form
    {
        private class ClientePrueba
        {
            public int ClienteId { get; set; }
            public string Nombre { get; set; }
            public string Telefono { get; set; }
        }

        private readonly List<ClientePrueba> _clientes = new List<ClientePrueba>();

        private readonly List<UcOrderItem> _orderItems = new List<UcOrderItem>();

        #region Constructor
        public FrmPuntoVenta()
        {
            InitializeComponent();

            ConfigurarTipoOrden(); //Relacion entre cmbTipoOrden y cmbMesa

            CargarProductosPrueba(); //Prueba de Productos

            ActualizarResumenPedido(); //Prueba de Orden a Cobrar

            ConfigurarBotonesCategorias(); //Colores y Efectos de las Categorias

            ConfigurarMetodosPago(); //Configuración del contenido del combobox Metodo de Pago

            ConfigurarClientes();//Configuración del contenido del combobox Cliente

        }
        #endregion

        #region Adicion de Productos (Prueba con UcProductoCard)
        private void CargarProductosPrueba()
        {
            flpProducts.Controls.Clear();
            AgregarProductoCard(
                1,
                "Ceviche Mixto",
                120.50m,
                "Ceviches",
                Properties.Resources.Primer_Ceviche,
                true);

            AgregarProductoCard(
                2,
                "Camarones al Ajillo",
                100.00m,
                "Mariscos",
                Properties.Resources.Coctel_Ceviche,
                true);

            AgregarProductoCard(
                3,
                "Pargo Frito Especial de la Casa con Salsa de Mariscos",
                150.00m,
                "Mariscos",
                null,
                true);

            AgregarProductoCard(
                4,
                "Tostones",
                80.00m,
                "Entradas",
                null,
                false);

            AgregarProductoCard(
               5,
               "Coca Cola",
               18.50m,
               "Bebidas",
               null,
               true);

            AgregarProductoCard(
               6,
               "Limonada",
               28.10m,
               "Bebidas",
               null,
               true);
        }
        #endregion

        #region Metodo de configuración y coordinacion entre cmbTipoOrden, cmbMesa y cmbCliente
        /// <summary>
        /// Configura el ComboBox de tipo de orden y carga las mesas de prueba.
        /// </summary>
        private void ConfigurarTipoOrden()
        {
            cmbTipoOrden.Items.Clear();

            cmbTipoOrden.Items.Add("Local");
            cmbTipoOrden.Items.Add("Delivery");

            cmbTipoOrden.SelectedIndex = 0;

            CargarMesasPrueba();
        }

        /// <summary>
        /// Configura el ComboBox de clientes y agrega opciones de prueba.
        /// </summary>
        private void ConfigurarClientes()
        {
            _clientes.Clear();

            _clientes.Add(new ClientePrueba
            {
                ClienteId = 1,
                Nombre = "Juan Pérez",
                Telefono = "8888-1111"
            });

            _clientes.Add(new ClientePrueba
            {
                ClienteId = 2,
                Nombre = "María López",
                Telefono = "8888-2222"
            });

            _clientes.Add(new ClientePrueba
            {
                ClienteId = 3,
                Nombre = "Carlos Rodríguez",
                Telefono = "8888-3333"
            });

            cmbCliente.Items.Clear();

            cmbCliente.Items.Add("Seleccione cliente...");

            foreach (ClientePrueba cliente in _clientes)
            {
                cmbCliente.Items.Add(cliente.Nombre);
            }

            cmbCliente.Items.Add("+ NUEVO CLIENTE");

            cmbCliente.SelectedIndex = 0;

        }

        /// <summary>
        /// Carga las mesas de prueba en el ComboBox de mesas.
        /// </summary>
        private void CargarMesasPrueba()
        {
            cmbMesa.Items.Clear();

            for (int i = 1; i <= 8; i++)
            {
                cmbMesa.Items.Add(
                    $"{i:00}");
            }

            if (cmbMesa.Items.Count > 0)
                cmbMesa.SelectedIndex = 0;
        }

        /// <summary>
        /// Maneja el evento de cambio de selección en el ComboBox de clientes. Si se selecciona la opción "+ NUEVO CLIENTE", se abre el panel para agregar un nuevo cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedItem?.ToString() == "+ NUEVO CLIENTE")
            {
                AbrirPanelNuevoCliente();
            }
        }

        /// <summary>
        /// Centra el panel de nuevo cliente dentro de su contenedor, ajustando su posición horizontal y vertical para que quede centrado.
        /// </summary>
        private void CentrarNuevoCliente()
        {
            pnlNuevoCliente.Left =
                (pnlNuevoClienteContainer.Width -
                 pnlNuevoCliente.Width) / 2;

            pnlNuevoCliente.Top =
                (pnlNuevoClienteContainer.Height -
                 pnlNuevoCliente.Height) / 2;
        }

        /// <summary>
        /// Abre el panel para agregar un nuevo cliente, haciéndolo visible y centrado dentro de su contenedor.
        /// </summary>
        private void AbrirPanelNuevoCliente()
        {
            pnlNuevoClienteContainer.Visible = true;
            pnlNuevoCliente.Visible = true;

            pnlNuevoCliente.BringToFront();

            CentrarNuevoCliente();
        }

        /// <summary>
        /// Cierra el panel de nuevo cliente, ocultándolo y limpiando los campos de texto, además de restablecer la selección del ComboBox de clientes a la primera opción.
        /// </summary>
        private void CerrarPanelNuevoCliente()
        {
            pnlNuevoCliente.Visible = false;
            pnlNuevoClienteContainer.Visible = false;

            txtNombreCliente.Clear();
            txtTelefonoCliente.Clear();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de cancelar nuevo cliente, cerrando el panel de nuevo cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarNuevoCliente_Click(object sender, EventArgs e)
        {
            CerrarPanelNuevoCliente();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de guardar nuevo cliente. Valida los campos de nombre y teléfono, verifica si el cliente ya existe, y si todo es válido, agrega el nuevo cliente a la lista, actualiza el ComboBox de clientes y cierra el panel de nuevo cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarNuevoCliente_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCliente.Text.Trim();

            string telefono = txtTelefonoCliente.Text.Trim();

            // Validar nombre
            if (string.IsNullOrWhiteSpace(nombre))
            {
                FrmMessageBox.Show(
                    "Ingrese el nombre del cliente.",
                    "Nombre requerido",
                    MessageType.Warning);

                txtNombreCliente.Focus();

                return;
            }

            // Validar teléfono
            if (string.IsNullOrWhiteSpace(telefono))
            {
                FrmMessageBox.Show(
                    "Ingrese el número de teléfono del cliente.",
                    "Teléfono requerido",
                    MessageType.Warning);

                txtTelefonoCliente.Focus();

                return;
            }

            // Verificar si ya existe
            bool existeCliente =
                _clientes.Any(c =>
                    c.Nombre.Equals(
                        nombre,
                        StringComparison.OrdinalIgnoreCase));

            if (existeCliente)
            {
                FrmMessageBox.Show(
                    "Ya existe un cliente registrado con ese nombre.",
                    "Cliente existente",
                    MessageType.Warning);

                txtNombreCliente.Focus();

                return;
            }

            // Crear cliente
            ClientePrueba nuevoCliente = new ClientePrueba
            {
                ClienteId =
                    _clientes.Count == 0
                        ? 1
                        : _clientes.Max(c => c.ClienteId) + 1,

                Nombre = nombre,
                Telefono = telefono
            };

            _clientes.Add(nuevoCliente);

            // Actualizar ComboBox
            cmbCliente.Items.Clear();

            cmbCliente.Items.Add("Seleccione cliente...");

            foreach (ClientePrueba cliente in _clientes)
            {
                cmbCliente.Items.Add(cliente.Nombre);
            }

            cmbCliente.Items.Add("+ NUEVO CLIENTE");

            // Seleccionar automáticamente el nuevo cliente
            cmbCliente.SelectedItem = nuevoCliente.Nombre;

            // Cerrar panel
            CerrarPanelNuevoCliente();

            FrmMessageBox.Show(
                $"El cliente {nuevoCliente.Nombre} fue registrado correctamente.",
                "Cliente registrado",
                MessageType.Information);
        }
        #endregion

        #region Metodo de instancia con los campos de UcProductoCard
        private void AgregarProductoCard(
        int productoId,
        string nombre,
        decimal precio,
        string categoria,
        Image imagen = null,
        bool disponible = true)
        {
            UcProductoCard card = new UcProductoCard();

            card.ProductoId = productoId;
            card.NombreProducto = nombre;
            card.Precio = precio;
            card.Categoria = categoria;
            card.ImagenProducto = imagen;
            card.Disponible = disponible;

            card.ProductoAgregado += Card_ProductoAgregado;

            flpProducts.Controls.Add(card);
        }
        #endregion

        #region Metodo de instancia con los campos de UcOrderItem
        private void Card_ProductoAgregado(object sender, EventArgs e)
        {
            if (sender is UcProductoCard card)
            {
                AgregarProductoAlPedido(card);
            }
        }

        private void AgregarProductoAlPedido(UcProductoCard card)
        {
            UcOrderItem itemExistente = _orderItems.Find(item => item.ProductoId == card.ProductoId);

            if (itemExistente != null)
            {
                itemExistente.Cantidad++;

                ActualizarResumenPedido();

                return;
            }

            UcOrderItem nuevoItem = new UcOrderItem();

            nuevoItem.ProductoId = card.ProductoId;

            nuevoItem.NombreProducto = card.NombreProducto;

            nuevoItem.PrecioUnitario = card.Precio;

            nuevoItem.Cantidad = 1;

            nuevoItem.CantidadCambiada += OrderItem_CantidadCambiada;

            nuevoItem.ProductoEliminado += OrderItem_ProductoEliminado;

            _orderItems.Add(nuevoItem);

            flpOrderItems.Controls.Add(nuevoItem);

            ActualizarResumenPedido();
        }

        private void OrderItem_CantidadCambiada(object sender, EventArgs e)
        {
            ActualizarResumenPedido();
        }

        private void ActualizarResumenPedido()
        {
            decimal subtotal = 0;

            foreach (UcOrderItem item in _orderItems)
            {
                subtotal += item.Subtotal;
            }

            decimal descuento = 0;

            decimal total = subtotal - descuento;

            lblSubtotal.Text = subtotal.ToString(
                "C",
                System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            lblDescuento.Text = descuento.ToString(
                "C",
                System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            lblTotal.Text = total.ToString(
                "C",
                System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            btnCobrar.Text = $"COBRAR {total.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-NI"))}";
            btnCobrar.Enabled = _orderItems.Count > 0;

            if (_orderItems.Count > 0)
            {
                btnCobrar.Enabled = true;
                btnCobrar.BackColor = Color.FromArgb(8, 126, 164);
            }
            else
            {
                btnCobrar.Enabled = false;
                btnCobrar.BackColor = Color.FromArgb(190, 196, 201);
            }
        }

        private void OrderItem_ProductoEliminado(object sender, EventArgs e)
        {
            if (sender is UcOrderItem item)
            {
                _orderItems.Remove(item);

                flpOrderItems.Controls.Remove(item);

                item.Dispose();

                ActualizarResumenPedido();
            }
        }
        #endregion

        #region Apariencia y Funcion de Botones de OrderFooter
        private void btnCobrar_MouseEnter(object sender, EventArgs e)
        {
            btnCobrar.BackColor = Color.FromArgb(6, 105, 138);
        }

        private void btnCobrar_MouseLeave(object sender, EventArgs e)
        {
            btnCobrar.BackColor = Color.FromArgb(8, 126, 164);
        }

        private void btnCancelarVenta_MouseEnter(object sender, EventArgs e)
        {
            btnCancelarVenta.BackColor = Color.FromArgb(224, 234, 240);
        }

        private void btnCancelarVenta_MouseLeave(object sender, EventArgs e)
        {
            btnCancelarVenta.BackColor = Color.FromArgb(238, 243, 247);
        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {

            if (_orderItems.Count == 0)
                return;

            DialogResult resultado =
                FrmMessageBox.Show(
                    "¿Desea cancelar la venta actual?",
                    "Cancelar venta",
                    MessageType.Confirmation);


            if (resultado != DialogResult.Yes)
                return;

            _orderItems.Clear();

            flpOrderItems.Controls.Clear();

            cmbMetodoPago.SelectedIndex = -1;

            ActualizarResumenPedido();
        }

        private decimal ObtenerTotalVenta()
        {
            decimal subtotal = 0;

            foreach (UcOrderItem item in _orderItems)
            {
                subtotal += item.Subtotal;
            }

            decimal descuento = 0;

            return subtotal - descuento;
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (_orderItems.Count == 0)
            {
                FrmMessageBox.Show(
                    "No hay productos en el pedido actual.",
                    "Venta vacía",
                    MessageType.Warning);

                return;
            }

            if (cmbMetodoPago.SelectedIndex == -1)
            {
                FrmMessageBox.Show(
                    "Seleccione un método de pago.",
                    "Método de pago requerido",
                    MessageType.Warning);

                return;
            }

            decimal total = ObtenerTotalVenta();

            string totalFormateado = total.ToString(
                "C",
                System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            string metodoPago = cmbMetodoPago.SelectedItem.ToString();

            DialogResult resultado =
                FrmMessageBox.Show(
                    $"¿Desea confirmar la venta por " +
                    $"{totalFormateado} mediante {metodoPago}?",
                    "Confirmar venta",
                    MessageType.Confirmation);

            if (resultado != DialogResult.Yes)
                return;

            FrmMessageBox.Show(
                $"La venta ha sido preparada correctamente.\n\n" +
                $"Total: {totalFormateado}\n" +
                $"Método de pago: {metodoPago}",
                "Venta preparada",
                MessageType.Information);
        }

        private void ConfigurarMetodosPago()
        {
            cmbMetodoPago.Items.Clear();

            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Tarjeta");
            cmbMetodoPago.Items.Add("Transferencia");

            cmbMetodoPago.SelectedIndex = 0;
        }
        #endregion

        #region Relación entre la tipo de orden y disponibilidad de mesa
        private void cmbTipoOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esLocal = cmbTipoOrden.SelectedItem?.ToString() == "Local";

            cmbMesa.Enabled = esLocal;

            if (!esLocal)
            {
                cmbMesa.SelectedIndex = -1;
            }
            else if (cmbMesa.Items.Count > 0)
            {
                cmbMesa.SelectedIndex = 0;
            }
        }
        #endregion

        #region Metodos y Colores para Buttons de Categoria
        // Estado normal
        private readonly Color _colorNormal = Color.FromArgb(8, 31, 63);

        // Hover
        private readonly Color _colorHover = Color.FromArgb(20, 52, 90);

        // Activo
        private readonly Color _colorActivo = Color.FromArgb(8, 126, 164);

        // Texto normal
        private readonly Color _colorTextoNormal = Color.White;

        // Texto activo
        private readonly Color _colorTextoActivo = Color.White;

        private Button _categoriaActiva;

        private string _categoriaSeleccionada = string.Empty;

        private void ActivarCategoria(Button boton)
        {
            // Restaurar botón anteriormente activo
            if (_categoriaActiva != null)
            {
                _categoriaActiva.BackColor = _colorNormal;
                _categoriaActiva.ForeColor = _colorTextoNormal;
            }

            // Activar nuevo botón
            _categoriaActiva = boton;

            _categoriaActiva.BackColor = _colorActivo;
            _categoriaActiva.ForeColor = _colorTextoActivo;

            _categoriaSeleccionada = boton.Tag?.ToString() ?? string.Empty;

            FiltrarProductos();
        }

        private void Categoria_MouseEnter(object sender, EventArgs e)
        {
            if (sender is not Button boton)
                return;

            // Si ya está activo, no modificarlo
            if (boton == _categoriaActiva)
                return;

            boton.BackColor = _colorHover;
        }

        private void Categoria_MouseLeave(object sender, EventArgs e)
        {
            if (sender is not Button boton)
                return;

            // Si está activo, conservar su estado
            if (boton == _categoriaActiva)
                return;

            boton.BackColor = _colorNormal;
        }

        private void Categoria_Click(object sender, EventArgs e)
        {
            if (sender is not Button boton)
                return;

            ActivarCategoria(boton);
        }

        private void ConfigurarBotonesCategorias()
        {
            btnCatTodos.Tag = "";
            btnCatCeviche.Tag = "Ceviches";
            btnCatMariscos.Tag = "Mariscos";
            btnCatEntradas.Tag = "Entradas";
            btnCatBebidas.Tag = "Bebidas";
            btnCatExtras.Tag = "Extras";


            Button[] botones =
            {
                btnCatTodos,
                btnCatCeviche,
                btnCatMariscos,
                btnCatEntradas,
                btnCatBebidas,
                btnCatExtras
            };

            foreach (Button boton in botones)
            {
                boton.BackColor = _colorNormal;
                boton.ForeColor = _colorTextoNormal;

                boton.FlatStyle = FlatStyle.Flat;
                boton.FlatAppearance.BorderSize = 0;
                boton.Cursor = Cursors.Hand;
                boton.UseVisualStyleBackColor = false;

                boton.MouseEnter += Categoria_MouseEnter;
                boton.MouseLeave += Categoria_MouseLeave;
                boton.Click += Categoria_Click;
            }

            ActivarCategoria(btnCatTodos);
        }
        #endregion

        #region Metodo para busqueda + categoria
        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void FiltrarProductos()
        {
            string textoBusqueda = txtBuscarProducto.Text.Trim();

            foreach (Control control in flpProducts.Controls)
            {
                if (control is not UcProductoCard card)
                    continue;

                bool coincideTexto = string.IsNullOrWhiteSpace(textoBusqueda)
                    ||
                    card.NombreProducto.Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase);

                bool coincideCategoria = string.IsNullOrWhiteSpace(_categoriaSeleccionada)
                    ||
                    card.Categoria.Equals(_categoriaSeleccionada, StringComparison.OrdinalIgnoreCase);

                card.Visible = coincideTexto && coincideCategoria;
            }
        }
        #endregion



        
    }
}
