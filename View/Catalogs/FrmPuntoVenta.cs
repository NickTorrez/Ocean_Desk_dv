using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Presenters;
using Ocean_Desk_dv.UI.Controls;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;


namespace Ocean_Desk_dv.UI.Catalogs
{
    public partial class FrmPuntoVenta : Form, IPuntoVentaView
    {
        /// <summary>
        /// Representa un elemento de cliente en el ComboBox de clientes, conteniendo el ID del cliente y su nombre completo. Esta clase se utiliza 
        /// para mostrar la información del cliente en la interfaz de usuario y facilitar la selección de clientes en el proceso de venta.
        /// </summary>
        private sealed class ClienteItem
        {
            public int ClienteId { get; }
            public string Nombre { get; }

            public ClienteItem(int clienteId, string nombre)
            {
                ClienteId = clienteId;
                Nombre = nombre;
            }

            public override string ToString() => Nombre;
        }

        /// <summary>
        /// Representa un elemento de mesa en el ComboBox de mesas, conteniendo el ID de la mesa y su número. Esta clase se utiliza para mostrar la
        /// información de la mesa en la interfaz de usuario y facilitar la selección de mesas en el proceso de venta, especialmente para órdenes locales.
        /// </summary>
        private sealed class MesaItem
        {
            public int MesaId { get; }
            public int Numero { get; }

            public MesaItem(int mesaId, int numero)
            {
                MesaId = mesaId;
                Numero = numero;
            }

            public override string ToString() => $"{Numero:00}";
        }

        /// <summary>
        /// Obtiene el tipo de orden seleccionado en el ComboBox de tipo de orden. Devuelve "Local" o "Delivery" según la selección del usuario.
        /// </summary>
        public string TipoOrden
        {
            get
            {
                return cmbTipoOrden.SelectedItem?.ToString() ?? string.Empty;
            }
        }

        private readonly List<UcOrderItem> _orderItems = new List<UcOrderItem>();
        private readonly int _usuarioId;
        private PuntoVentaPresenter? _presenter;

        #region Implementación de IPuntoVentaView

        /// <summary>
        /// Obtiene el tipo de orden seleccionado en el ComboBox de tipo de orden.
        /// </summary>
        public int? MesaIdSeleccionada =>
            cmbMesa.SelectedItem is MesaItem mesa
                ? mesa.MesaId
                : null;

        public int? ClienteIdSeleccionado =>
            cmbCliente.SelectedItem is ClienteItem cliente
                ? cliente.ClienteId
                : null;

        public string MetodoPago => cmbMetodoPago.SelectedItem?.ToString() ?? string.Empty;

        public string NuevoClienteNombre => txtNombreCliente.Text.Trim();

        public string NuevoClienteTelefono => txtTelefonoCliente.Text.Trim();

        /// <summary>
        /// Obtiene una lista de detalles de venta basada en los elementos del pedido actual. Cada detalle de venta contiene el ID del producto y la cantidad correspondiente.
        /// </summary>
        public IReadOnlyList<PuntoVentaDetalle> DetallesVenta =>
            _orderItems
                .Select(item => new PuntoVentaDetalle
                {
                    ProductoId = item.ProductoId,
                    Cantidad = item.Cantidad
                })
                .ToList();

        public event EventHandler? PagarYRegistrarOrden;
        public event EventHandler? GuardarNuevoCliente;

        /// <summary>
        /// Muestra una lista de productos en el panel de productos. Cada producto se representa mediante un control UcProductoCard que muestra información como el nombre, precio, categoría, imagen y disponibilidad del producto.
        /// </summary>
        /// <param name="productos"></param>
        public void MostrarProductos(List<Product> productos)
        {
            flpProducts.SuspendLayout();
            flpProducts.Controls.Clear();

            foreach (Product producto in productos)
            {
                Image? imagen = ObtenerImagenProducto(producto.ProductCode);
                string categoria = producto.ProductCategory?.CategoryName ?? string.Empty;

                AgregarProductoCard(
                    producto.ProductId,
                    producto.ProductName,
                    producto.UnitPrice,
                    categoria,
                    imagen,
                    producto.IsAvailable);
            }

            flpProducts.ResumeLayout();
            FiltrarProductos();
        }

        /// <summary>
        /// Muestra una lista de clientes en el ComboBox de clientes. Cada cliente se representa mediante un objeto ClienteItem que contiene el ID del cliente y su nombre completo. Además, se agrega una opción para agregar un nuevo cliente al final de la lista.
        /// </summary>
        /// <param name="clientes"></param>
        public void MostrarClientes(List<Customer> clientes)
        {
            cmbCliente.Items.Clear();
            cmbCliente.Items.Add("Seleccione cliente...");

            foreach (Customer cliente in clientes)
            {
                string nombre = $"{cliente.FirstName} {cliente.LastName}".Trim();
                cmbCliente.Items.Add(new ClienteItem(cliente.CustomerId, nombre));
            }

            cmbCliente.Items.Add("+ NUEVO CLIENTE");
            cmbCliente.SelectedIndex = 0;
        }

        /// <summary>
        /// Muestra una lista de mesas en el ComboBox de mesas. Cada mesa se representa mediante un objeto MesaItem que contiene el ID de la mesa y su número. Además, habilita o deshabilita el ComboBox según el tipo de orden seleccionado (Local o Delivery).
        /// </summary>
        /// <param name="mesas"></param>
        public void MostrarMesas(List<TableRestaurant> mesas)
        {
            cmbMesa.Items.Clear();

            foreach (TableRestaurant mesa in mesas)
            {
                cmbMesa.Items.Add(new MesaItem(mesa.TableId, mesa.TableNumber));
            }

            bool esLocal = TipoOrden == "Local";
            cmbMesa.Enabled = esLocal;

            if (esLocal && cmbMesa.Items.Count > 0)
                cmbMesa.SelectedIndex = 0;
            else
                cmbMesa.SelectedIndex = -1;
        }

        /// <summary>
        /// Muestra un mensaje en una ventana de diálogo.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="titulo"></param>
        /// <param name="esError"></param>
        public void MostrarMensaje(string mensaje, string titulo = "Punto de Venta", bool esError = false)
        {
            FrmMessageBox.Show(
                mensaje,
                titulo,
                esError ? MessageType.Error : MessageType.Information);
        }

        /// <summary>
        /// Selecciona un cliente en el ComboBox de clientes basado en el ID del cliente proporcionado. Si se encuentra un cliente con el ID especificado, se establece como seleccionado en el ComboBox.
        /// </summary>
        /// <param name="customerId"></param>
        public void SeleccionarCliente(int customerId)
        {
            for (int i = 0; i < cmbCliente.Items.Count; i++)
            {
                if (cmbCliente.Items[i] is ClienteItem cliente &&
                    cliente.ClienteId == customerId)
                {
                    cmbCliente.SelectedIndex = i;
                    return;
                }
            }
        }

        /// <summary>
        /// Cierra el panel de nuevo cliente, ocultándolo y limpiando los campos de texto, además de restablecer la selección del ComboBox de clientes a la primera opción.
        /// </summary>
        public void CerrarPanelNuevoCliente()
        {
            pnlNuevoCliente.Visible = false;
            pnlNuevoClienteContainer.Visible = false;
            txtNombreCliente.Clear();
            txtTelefonoCliente.Clear();
        }

        /// <summary>
        /// Limpia el carrito de compras, eliminando todos los elementos del pedido actual, restableciendo los ComboBox de método de pago y cliente a sus valores predeterminados, y actualizando el resumen del pedido.
        /// </summary>
        public void LimpiarCarrito()
        {
            foreach (UcOrderItem item in _orderItems)
            {
                item.CantidadCambiada -= OrderItem_CantidadCambiada;
                item.ProductoEliminado -= OrderItem_ProductoEliminado;
                item.Dispose();
            }

            _orderItems.Clear();
            flpOrderItems.Controls.Clear();

            cmbMetodoPago.SelectedIndex = 0;
            cmbCliente.SelectedIndex = 0;

            if (TipoOrden == "Local" && cmbMesa.Items.Count > 0)
                cmbMesa.SelectedIndex = 0;

            txtBuscarProducto.Clear();
            ActualizarResumenPedido();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor por defecto que inicializa el formulario de punto de venta con un identificador de usuario predeterminado (1). Este constructor se utiliza mientras el módulo de autenticación no proporcione el usuario real.
        /// </summary>
        public FrmPuntoVenta() : this(1)
        {
        }

        /// <summary>
        /// Constructor que recibe el identificador del usuario que registra la venta.
        /// Mientras el módulo de autenticación no entregue el usuario real,
        /// el MainMenu continúa utilizando el constructor sin parámetros.
        /// </summary>
        /// 
        public FrmPuntoVenta(int usuarioId)
        {
            if (usuarioId <= 0)
                throw new ArgumentOutOfRangeException(nameof(usuarioId));

            _usuarioId = usuarioId;

            InitializeComponent();

            ConfigurarTipoOrden();
            ConfigurarMetodosPago();
            ConfigurarBotonesCategorias();

            _presenter = new PuntoVentaPresenter(
                this,
                new OceanDeskDbContext(),
                _usuarioId);

            ActualizarResumenPedido();

            FormClosed += FrmPuntoVenta_FormClosed;

        }

        /// <summary>
        /// Maneja el evento de cierre del formulario, liberando los recursos del presentador y estableciendo la referencia a null para evitar fugas de memoria.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPuntoVenta_FormClosed(object? sender, FormClosedEventArgs e)
        {
            _presenter?.Dispose();
            _presenter = null;
        }
        #endregion

        #region Productos (con UcProductoCard)
        /// <summary>
        /// Obtiene la imagen correspondiente a un producto según su código. Si el código coincide con un producto específico, se devuelve la imagen asociada; de lo contrario, se devuelve null.
        /// </summary>
        /// <param name="codigoProducto"></param>
        /// <returns></returns>
        private Image? ObtenerImagenProducto(string codigoProducto)
        {
            return codigoProducto switch
            {
                "PRD-001" => Properties.Resources.Primer_Ceviche,
                "PRD-002" => Properties.Resources.Coctel_Ceviche,
                _ => null
            };
        }

        /// <summary>
        /// Agrega un control UcProductoCard al panel de productos, representando un producto con su información relevante, como nombre, precio, categoría, imagen y disponibilidad. Además, se suscribe al evento ProductoAgregado del control para manejar la adición del producto al pedido.
        /// </summary>
        /// <param name="productoId"></param>
        /// <param name="nombre"></param>
        /// <param name="precio"></param>
        /// <param name="categoria"></param>
        /// <param name="imagen"></param>
        /// <param name="disponible"></param>
        private void AgregarProductoCard(
            int productoId,
            string nombre,
            decimal precio,
            string categoria,
            Image? imagen = null,
            bool disponible = true)
        {
            UcProductoCard card = new UcProductoCard
            {
                ProductoId = productoId,
                NombreProducto = nombre,
                Precio = precio,
                Categoria = categoria,
                ImagenProducto = imagen,
                Disponible = disponible
            };

            card.ProductoAgregado += Card_ProductoAgregado;
            flpProducts.Controls.Add(card);
        }

        /// <summary>
        /// Maneja el evento ProductoAgregado de un control UcProductoCard. Cuando se agrega un producto, se llama a este método para agregar el producto al pedido actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card_ProductoAgregado(object? sender, EventArgs e)
        {
            if (sender is UcProductoCard card)
                AgregarProductoAlPedido(card);
        }

        /// <summary>
        /// Agrega un producto al pedido actual. Si el producto ya existe en el pedido, se incrementa su cantidad; de lo contrario, se crea un nuevo elemento de pedido y se agrega al panel de elementos del pedido. Además, se actualiza el resumen del pedido después de agregar el producto.
        /// </summary>
        /// <param name="card"></param>
        private void AgregarProductoAlPedido(UcProductoCard card)
        {
            UcOrderItem? itemExistente =
                _orderItems.Find(item => item.ProductoId == card.ProductoId);

            if (itemExistente != null)
            {
                itemExistente.Cantidad++;
                ActualizarResumenPedido();
                return;
            }

            UcOrderItem nuevoItem = new UcOrderItem
            {
                ProductoId = card.ProductoId,
                NombreProducto = card.NombreProducto,
                PrecioUnitario = card.Precio,
                Cantidad = 1
            };

            nuevoItem.CantidadCambiada += OrderItem_CantidadCambiada;
            nuevoItem.ProductoEliminado += OrderItem_ProductoEliminado;

            _orderItems.Add(nuevoItem);
            flpOrderItems.Controls.Add(nuevoItem);

            ActualizarResumenPedido();
        }

        /// <summary>
        /// Maneja el evento CantidadCambiada de un control UcOrderItem. Cuando la cantidad de un producto en el pedido cambia, se llama a este método para actualizar el resumen del pedido y reflejar los cambios en los totales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderItem_CantidadCambiada(object? sender, EventArgs e)
        {
            ActualizarResumenPedido();
        }

        /// <summary>
        /// Maneja el evento ProductoEliminado de un control UcOrderItem. Cuando un producto se elimina del pedido, se llama a este método para eliminar el elemento del pedido, actualizar el panel de elementos del pedido y actualizar el resumen del pedido.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderItem_ProductoEliminado(object? sender, EventArgs e)
        {
            if (sender is not UcOrderItem item)
                return;

            _orderItems.Remove(item);
            flpOrderItems.Controls.Remove(item);
            item.CantidadCambiada -= OrderItem_CantidadCambiada;
            item.ProductoEliminado -= OrderItem_ProductoEliminado;
            item.Dispose();

            ActualizarResumenPedido();
        }

        /// <summary>
        /// Actualiza el resumen del pedido, calculando el subtotal, descuento y total de la venta actual. Además, actualiza las etiquetas correspondientes en la interfaz de usuario y habilita o deshabilita el botón de cobro según si hay productos en el pedido.
        /// </summary>
        private void ActualizarResumenPedido()
        {
            decimal subtotal = _orderItems.Sum(item => item.Subtotal);
            decimal descuento = 0m;
            decimal total = subtotal - descuento;

            CultureInfo cultura = CultureInfo.GetCultureInfo("es-NI");

            lblSubtotal.Text = subtotal.ToString("C", cultura);
            lblDescuento.Text = descuento.ToString("C", cultura);
            lblTotal.Text = total.ToString("C", cultura);
            btnCobrar.Text = $"COBRAR {total.ToString("C", cultura)}";

            bool hayProductos = _orderItems.Count > 0;
            btnCobrar.Enabled = hayProductos;
            btnCobrar.BackColor = hayProductos
                ? Color.FromArgb(8, 126, 164)
                : Color.FromArgb(190, 196, 201);
        }

        /// <summary>
        /// Calcula y devuelve el total de la venta actual sumando los subtotales de todos los elementos del pedido. Este método se utiliza para obtener el monto total a cobrar antes de procesar la venta.
        /// </summary>
        /// <returns></returns>
        private decimal ObtenerTotalVenta()
        {
            return _orderItems.Sum(item => item.Subtotal);
        }
        #endregion

        #region Tipo de Orden, Mesas y Clientes
        /// <summary>
        /// Configura el ComboBox de tipo de orden con las opciones "Local" y "Delivery", estableciendo la opción predeterminada como "Local". Este método se llama durante la inicialización del formulario para preparar la selección de tipo de orden para el usuario.
        /// </summary>
        private void ConfigurarTipoOrden()
        {
            cmbTipoOrden.Items.Clear();
            cmbTipoOrden.Items.Add("Local");
            cmbTipoOrden.Items.Add("Delivery");
            cmbTipoOrden.SelectedIndex = 0;
        }

        /// <summary>
        /// Maneja el evento de cambio de selección en el ComboBox de tipo de orden. Dependiendo del tipo de orden seleccionado (Local o Delivery), habilita o deshabilita el ComboBox de mesas y ajusta la selección de mesa según corresponda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTipoOrden_SelectedIndexChanged(object? sender, EventArgs e)
        {
            bool esLocal = TipoOrden == "Local";
            cmbMesa.Enabled = esLocal;

            if (!esLocal)
            {
                cmbMesa.SelectedIndex = -1;
            }
            else if (cmbMesa.Items.Count > 0 && cmbMesa.SelectedIndex < 0)
            {
                cmbMesa.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de selección en el ComboBox de clientes. Si el usuario selecciona la opción "+ NUEVO CLIENTE", se abre el panel para agregar un nuevo cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCliente_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbCliente.SelectedItem?.ToString() == "+ NUEVO CLIENTE")
                AbrirPanelNuevoCliente();
        }
        #endregion

        #region Nuevo Cliente
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
        private void CerrarPanelNuevoClienteVisual()
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
            cmbCliente.SelectedIndex = 0;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de guardar nuevo cliente. Valida los campos de nombre y teléfono, verifica si el cliente ya existe, y si todo es válido, agrega el nuevo cliente a la lista, actualiza el ComboBox de clientes y cierra el panel de nuevo cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarNuevoCliente_Click(object sender, EventArgs e)
        {
            GuardarNuevoCliente?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Cobro y Cancelación de Venta
        /// <summary>
        /// Maneja el evento de clic en el botón de cobrar. Valida que haya productos en el pedido, que se haya seleccionado un método de pago y, si es una orden local, que se haya seleccionado una mesa. Luego, muestra un mensaje de confirmación con el total de la venta y el método de pago seleccionado. Si el usuario confirma, se invoca el evento PagarYRegistrarOrden para procesar la venta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCobrar_Click(object? sender, EventArgs e)
        {
            if (_orderItems.Count == 0)
            {
                FrmMessageBox.Show(
                    "No hay productos en el pedido actual.",
                    "Venta vacía",
                    MessageType.Warning);
                return;
            }

            if (cmbMetodoPago.SelectedIndex < 0)
            {
                FrmMessageBox.Show(
                    "Seleccione un método de pago.",
                    "Método de pago requerido",
                    MessageType.Warning);
                return;
            }

            if (TipoOrden == "Local" && !MesaIdSeleccionada.HasValue)
            {
                FrmMessageBox.Show(
                    "Seleccione una mesa para una orden local.",
                    "Mesa requerida",
                    MessageType.Warning);
                return;
            }

            decimal total = ObtenerTotalVenta();
            CultureInfo cultura = CultureInfo.GetCultureInfo("es-NI");
            string totalFormateado = total.ToString("C", cultura);
            string metodoPago = MetodoPago;

            DialogResult resultado = FrmMessageBox.Show(
                $"¿Desea confirmar la venta por {totalFormateado} mediante {metodoPago}?",
                "Confirmar venta",
                MessageType.Confirmation);

            if (resultado != DialogResult.Yes)
                return;

            PagarYRegistrarOrden?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de cancelar venta. Si hay productos en el pedido, muestra un mensaje de confirmación para cancelar la venta actual. Si el usuario confirma, se llama al método LimpiarCarrito para eliminar todos los elementos del pedido y restablecer la interfaz de usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarVenta_Click(object? sender, EventArgs e)
        {

            if (_orderItems.Count == 0)
                return;

            DialogResult resultado = FrmMessageBox.Show(
                "¿Desea cancelar la venta actual?",
                "Cancelar venta",
                MessageType.Confirmation);

            if (resultado != DialogResult.Yes)
                return;

            LimpiarCarrito();
        }
        #endregion

        #region Metodos de Pago
        /// <summary>
        /// Configura el ComboBox de métodos de pago con las opciones "Efectivo", "Tarjeta" y "Transferencia", estableciendo la opción predeterminada como "Efectivo". Este método se llama durante la inicialización del formulario para preparar la selección de método de pago para el usuario.
        /// </summary>
        private void ConfigurarMetodosPago()
        {
            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Tarjeta");
            cmbMetodoPago.Items.Add("Transferencia");
            cmbMetodoPago.SelectedIndex = 0;
        }
        #endregion

        #region Apariencia Botones de OrderFooter
        private void btnCobrar_MouseEnter(object? sender, EventArgs e)
        {
            btnCobrar.BackColor = Color.FromArgb(6, 105, 138);
        }

        private void btnCobrar_MouseLeave(object? sender, EventArgs e)
        {
            btnCobrar.BackColor = Color.FromArgb(8, 126, 164);
        }

        private void btnCancelarVenta_MouseEnter(object? sender, EventArgs e)
        {
            btnCancelarVenta.BackColor = Color.FromArgb(224, 234, 240);
        }

        private void btnCancelarVenta_MouseLeave(object? sender, EventArgs e)
        {
            btnCancelarVenta.BackColor = Color.FromArgb(238, 243, 247);
        }

        #endregion

        #region Categorias

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

        // Botón actualmente activo
        private Button _categoriaActiva;

        // Categoría actualmente seleccionada
        private string _categoriaSeleccionada = string.Empty;

        /// <summary>
        /// Activa una categoría de producto al cambiar el estado visual del botón correspondiente. Restaura el estado del botón previamente activo 
        /// y actualiza la categoría seleccionada para filtrar los productos mostrados en el panel de productos.
        /// </summary>
        /// <param name="boton"></param>
        private void ActivarCategoria(Button boton)
        {
            if (_categoriaActiva != null)
            {
                _categoriaActiva.BackColor = _colorNormal;
                _categoriaActiva.ForeColor = _colorTextoNormal;
            }

            _categoriaActiva = boton;
            _categoriaActiva.BackColor = _colorActivo;
            _categoriaActiva.ForeColor = _colorTextoActivo;
            _categoriaSeleccionada = boton.Tag?.ToString() ?? string.Empty;

            FiltrarProductos();
        }

        /// <summary>
        /// Maneja el evento de entrada del mouse sobre un botón de categoría. Si el botón no es el actualmente activo,
        /// cambia su color de fondo al color de hover para indicar que está siendo resaltado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Categoria_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is not Button boton || boton == _categoriaActiva)
                return;

            boton.BackColor = _colorHover;
        }

        /// <summary>
        /// Maneja el evento de salida del mouse de un botón de categoría. Si el botón no es el actualmente activo,
        /// restaura su color de fondo al color normal para indicar que ya no está siendo resaltado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Categoria_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is not Button boton || boton == _categoriaActiva)
                return;

            boton.BackColor = _colorNormal;
        }

        /// <summary>
        /// Maneja el evento de clic en un botón de categoría. Cuando se hace clic en un botón, se activa la categoría correspondiente llamando al 
        /// método ActivarCategoria, lo que actualiza la apariencia del botón y filtra los productos mostrados según la categoría seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Categoria_Click(object? sender, EventArgs e)
        {
            if (sender is Button boton)
                ActivarCategoria(boton);
        }

        /// <summary>
        /// Configura los botones de categoría de productos, asignando etiquetas a cada botón para representar la categoría correspondiente. Además, 
        /// se establecen los colores y estilos visuales de los botones, y se suscriben a los eventos de entrada, salida y clic del mouse para manejar la interacción del usuario con las categorías.
        /// </summary>
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

                bool coincideTexto =
                    string.IsNullOrWhiteSpace(textoBusqueda) ||
                    card.NombreProducto.Contains(
                        textoBusqueda,
                        StringComparison.OrdinalIgnoreCase);

                bool coincideCategoria =
                    string.IsNullOrWhiteSpace(_categoriaSeleccionada) ||
                    card.Categoria.Equals(
                        _categoriaSeleccionada,
                        StringComparison.OrdinalIgnoreCase);

                card.Visible = coincideTexto && coincideCategoria;
            }
        }
        #endregion
        
    }
}
