using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.View.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Presenters
{
    public class PuntoVentaPresenter : IDisposable
    {
        private readonly IPuntoVentaView _view;
        private readonly OceanDeskDbContext _context;
        private readonly int _usuarioId;

        private static readonly Dictionary<string, string> PaymentMethods =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "Efectivo", "Cash" },
                { "Tarjeta", "Card" },
                { "Transferencia", "Transfer" }
            };

        public PuntoVentaPresenter(
            IPuntoVentaView view,
            OceanDeskDbContext context,
            int usuarioId)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _usuarioId = usuarioId;

            _view.PagarYRegistrarOrden += RegistrarOrden;
            _view.GuardarNuevoCliente += RegistrarNuevoCliente;

            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            CargarCatalogo();
            CargarClientes();
            CargarMesasDisponibles();
        }

        private void CargarCatalogo()
        {
            var productos = _context.Products
                .AsNoTracking()
                .Include(p => p.ProductCategory)
                .Where(p => p.IsActive && p.IsAvailable)
                .OrderBy(p => p.ProductCategory.CategoryName)
                .ThenBy(p => p.ProductName)
                .ToList();

            _view.MostrarProductos(productos);
        }

        private void CargarClientes()
        {
            var clientes = _context.Customers
                .AsNoTracking()
                .Where(c => c.IsActive)
                .OrderBy(c => c.FirstName)
                .ThenBy(c => c.LastName)
                .ToList();

            _view.MostrarClientes(clientes);
        }

        private void CargarMesasDisponibles()
        {
            var mesas = _context.TableRestaurants
                .AsNoTracking()
                .Where(t => t.IsActive && t.Status == "Available")
                .OrderBy(t => t.TableNumber)
                .ToList();

            _view.MostrarMesas(mesas);
        }

        private void RegistrarNuevoCliente(object? sender, EventArgs e)
        {
            string nombreCompleto = _view.NuevoClienteNombre.Trim();
            string telefono = _view.NuevoClienteTelefono.Trim();

            if (string.IsNullOrWhiteSpace(nombreCompleto))
            {
                _view.MostrarMensaje(
                    "Ingrese el nombre completo del cliente.",
                    "Cliente requerido",
                    true);
                return;
            }

            if (string.IsNullOrWhiteSpace(telefono))
            {
                _view.MostrarMensaje(
                    "Ingrese el número de teléfono del cliente.",
                    "Teléfono requerido",
                    true);
                return;
            }

            if (telefono.Length < 8 || telefono.Length > 20)
            {
                _view.MostrarMensaje(
                    "El teléfono debe contener entre 8 y 20 caracteres.",
                    "Teléfono inválido",
                    true);
                return;
            }

            var partes = nombreCompleto
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (partes.Length < 2)
            {
                _view.MostrarMensaje(
                    "Ingrese al menos nombre y apellido del cliente.",
                    "Nombre incompleto",
                    true);
                return;
            }

            string firstName = partes[0];
            string lastName = string.Join(" ", partes.Skip(1));

            bool telefonoExiste = _context.Customers.Any(c =>
                c.IsActive &&
                c.Phone != null &&
                c.Phone == telefono);

            if (telefonoExiste)
            {
                _view.MostrarMensaje(
                    "Ya existe un cliente activo registrado con ese teléfono.",
                    "Cliente existente",
                    true);
                return;
            }

            try
            {
                var nuevoCliente = new Customer
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Phone = telefono,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };

                _context.Customers.Add(nuevoCliente);
                _context.SaveChanges();

                CargarClientes();
                _view.SeleccionarCliente(nuevoCliente.CustomerId);
                _view.CerrarPanelNuevoCliente();

                _view.MostrarMensaje(
                    $"El cliente {nuevoCliente.FirstName} {nuevoCliente.LastName} fue registrado correctamente.",
                    "Cliente registrado");
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible guardar el cliente en la base de datos.\n\n{ex.InnerException?.Message ?? ex.Message}",
                    "Error de base de datos",
                    true);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    $"Ocurrió un error inesperado al registrar el cliente.\n\n{ex.Message}",
                    "Error",
                    true);
            }
        }

        /// <summary>
        /// Handles the event of registering a sale order, validating the input data, creating the sale, payment, and kitchen order records, and saving them to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrarOrden(object? sender, EventArgs e)
        {
            if (_usuarioId <= 0)
            {
                _view.MostrarMensaje(
                    "No se ha identificado un usuario válido para registrar la venta.",
                    "Usuario inválido",
                    true);
                return;
            }

            if (_view.DetallesVenta == null || _view.DetallesVenta.Count == 0)
            {
                _view.MostrarMensaje(
                    "El pedido está vacío.",
                    "Venta vacía",
                    true);
                return;
            }

            string tipoOrden = _view.TipoOrden.Trim();

            if (tipoOrden != "Local" && tipoOrden != "Delivery")
            {
                _view.MostrarMensaje(
                    "Seleccione un tipo de orden válido.",
                    "Tipo de orden inválido",
                    true);
                return;
            }

            int? mesaId = _view.MesaIdSeleccionada;

            if (tipoOrden == "Local" && !mesaId.HasValue)
            {
                _view.MostrarMensaje(
                    "Seleccione una mesa para una orden local.",
                    "Mesa requerida",
                    true);
                return;
            }

            if (tipoOrden == "Delivery")
            {
                mesaId = null;
            }

            string metodoPagoVista = _view.MetodoPago?.Trim() ?? string.Empty;

            if (!PaymentMethods.TryGetValue(metodoPagoVista, out string metodoPagoBD))
            {
                _view.MostrarMensaje(
                    "Seleccione un método de pago válido.",
                    "Método de pago inválido",
                    true);
                return;
            }

            try
            {
                var detalles = _view.DetallesVenta
                    .GroupBy(d => d.ProductoId)
                    .Select(g => new PuntoVentaDetalle
                    {
                        ProductoId = g.Key,
                        Cantidad = g.Sum(x => x.Cantidad)
                    })
                    .ToList();

                if (detalles.Any(d => d.ProductoId <= 0 || d.Cantidad <= 0))
                {
                    _view.MostrarMensaje(
                        "El pedido contiene productos o cantidades inválidas.",
                        "Datos inválidos",
                        true);
                    return;
                }

                var productoIds = detalles.Select(d => d.ProductoId).ToList();

                var productos = _context.Products
                    .Include(p => p.ProductCategory)
                    .Where(p => productoIds.Contains(p.ProductId))
                    .ToList();

                if (productos.Count != productoIds.Count)
                {
                    _view.MostrarMensaje(
                        "Uno o más productos del pedido ya no existen en la base de datos.",
                        "Producto no disponible",
                        true);
                    return;
                }

                var productosNoDisponibles = productos
                    .Where(p => !p.IsActive || !p.IsAvailable)
                    .Select(p => p.ProductName)
                    .ToList();

                if (productosNoDisponibles.Any())
                {
                    _view.MostrarMensaje(
                        "Los siguientes productos ya no están disponibles:\n\n" +
                        string.Join("\n", productosNoDisponibles),
                        "Producto no disponible",
                        true);
                    return;
                }

                if (_view.ClienteIdSeleccionado.HasValue)
                {
                    bool clienteValido = _context.Customers.Any(c =>
                        c.CustomerId == _view.ClienteIdSeleccionado.Value &&
                        c.IsActive);

                    if (!clienteValido)
                    {
                        _view.MostrarMensaje(
                            "El cliente seleccionado no está disponible.",
                            "Cliente inválido",
                            true);
                        return;
                    }
                }

                TableRestaurant? mesa = null;

                if (mesaId.HasValue)
                {
                    mesa = _context.TableRestaurants
                        .FirstOrDefault(t =>
                            t.TableId == mesaId.Value &&
                            t.IsActive);

                    if (mesa == null)
                    {
                        _view.MostrarMensaje(
                            "La mesa seleccionada no existe o está inactiva.",
                            "Mesa inválida",
                            true);
                        return;
                    }

                    if (mesa.Status != "Available")
                    {
                        _view.MostrarMensaje(
                            "La mesa seleccionada ya no está disponible.",
                            "Mesa ocupada",
                            true);
                        CargarMesasDisponibles();
                        return;
                    }
                }

                decimal subtotal = 0m;
                var saleDetails = new List<SaleDetail>();

                foreach (var detalleVista in detalles)
                {
                    var producto = productos.First(p => p.ProductId == detalleVista.ProductoId);
                    decimal subtotalLinea = producto.UnitPrice * detalleVista.Cantidad;

                    var saleDetail = new SaleDetail
                    {
                        ProductId = producto.ProductId,
                        Quantity = detalleVista.Cantidad,
                        UnitPrice = producto.UnitPrice,
                        Discount = 0m,
                        Subtotal = subtotalLinea
                    };

                    saleDetails.Add(saleDetail);
                    subtotal += subtotalLinea;
                }

                decimal descuento = 0m;
                CultureInfo cultura = CultureInfo.GetCultureInfo("es-NI");
                decimal total = subtotal - descuento;

                if (total <= 0)
                {
                    _view.MostrarMensaje(
                        "El total de la venta debe ser mayor que cero.",
                        "Total inválido",
                        true);
                    return;
                }

                using var transaction = _context.Database.BeginTransaction();

                var nuevaVenta = new Sale
                {
                    SaleDateTime = DateTime.Now,
                    UserId = _usuarioId,
                    CustomerId = _view.ClienteIdSeleccionado,
                    OrderType = tipoOrden,
                    TableId = mesaId,
                    Subtotal = subtotal,
                    Discount = descuento,
                    Total = total,
                    Status = "Completed",
                    Notes = null,
                    SaleDetails = saleDetails
                };

                var pago = new SalePayment
                {
                    Sale = nuevaVenta,
                    PaymentMethod = metodoPagoBD,
                    Amount = total,
                    PaymentDateTime = DateTime.Now
                };

                var ordenCocina = new KitchenOrder
                {
                    Sale = nuevaVenta,
                    ReceptionDateTime = DateTime.Now,
                    PreparationStartDateTime = null,
                    ReadyDateTime = null,
                    DeliveredDateTime = null,
                    Status = "Pending",
                    Priority = "Normal",
                    Notes = "Orden enviada desde Punto de Venta"
                };

                foreach (var saleDetail in saleDetails)
                {
                    var cocinaDetalle = new KitchenOrderDetail
                    {
                        KitchenOrder = ordenCocina,
                        SaleDetail = saleDetail,
                        ProductId = saleDetail.ProductId,
                        Quantity = saleDetail.Quantity,
                        Notes = saleDetail.Notes
                    };

                    ordenCocina.KitchenOrderDetails.Add(cocinaDetalle);
                }

                _context.Sales.Add(nuevaVenta);
                _context.SalePayments.Add(pago);
                _context.KitchenOrders.Add(ordenCocina);

                if (mesa != null)
                {
                    mesa.Status = "Occupied";
                }

                _context.SaveChanges();
                transaction.Commit();

                _view.MostrarMensaje(
                    "La venta fue registrada correctamente.\n\n" +
                    $"Total: C$ {total.ToString("N2", cultura)}\n" +
                    $"Pago: {metodoPagoVista}\n" +
                    "La orden fue enviada a Cocina.",
                    "Venta registrada");

                _view.LimpiarCarrito();
                CargarMesasDisponibles();
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    "No fue posible registrar la venta en la base de datos.\n\n" +
                    (ex.InnerException?.Message ?? ex.Message),
                    "Error de base de datos",
                    true);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    "Ocurrió un error inesperado al registrar la venta.\n\n" +
                    ex.Message,
                    "Error",
                    true);
            }
        }

        /// <summary>
        /// Disposes of the resources used by the presenter, unsubscribing from view events and disposing of the database context.
        /// </summary>
        public void Dispose()
        {
            _view.PagarYRegistrarOrden -= RegistrarOrden;
            _view.GuardarNuevoCliente -= RegistrarNuevoCliente;
            _context.Dispose();
        }
    }
}
