using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;
using Ocean_Desk_dv.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Presenters
{
    public class PuntoVentaPresenter : IDisposable
    {
        private readonly IPuntoVentaView _view;
        private readonly IPuntoVentaRepository _repository;
        private readonly int _usuarioId;
        private bool _disposed;

        private static readonly Dictionary<string, string> PaymentMethods =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "Efectivo", "Cash" },
                { "Tarjeta", "Card" },
                { "Transferencia", "Transfer" }
            };

        public PuntoVentaPresenter(
            IPuntoVentaView view,
            IPuntoVentaRepository repository,
            int usuarioId)
        {
            _view = view ??
                throw new ArgumentNullException(nameof(view));

            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));

            if (usuarioId <= 0)
                throw new ArgumentOutOfRangeException(nameof(usuarioId));

            _usuarioId = usuarioId;

            _view.PagarYRegistrarOrden += RegistrarOrden;
            _view.GuardarNuevoCliente += RegistrarNuevoCliente;
            _view.ClienteSeleccionadoChanged += ClienteSeleccionado;
        }

        /// <summary>
        /// Carga los datos iniciales del módulo.
        /// </summary>
        public void Inicializar()
        {
            try
            {
                CargarCatalogo();
                CargarClientes();
                CargarMesasDisponibles();
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    "No fue posible inicializar el Punto de Venta.\n\n" +
                    ex.Message,
                    "Error de inicialización",
                    true);
            }
        }

        #region Carga de información

        private void CargarCatalogo()
        {
            List<Product> productos = _repository
                .ObtenerCatalogoDisponible()
                .Select(p => new Product
                {
                    ProductId = p.ProductId,
                    ProductCode = p.ProductCode,
                    ProductName = p.ProductName,
                    ProductType = "FinishedProduct",
                    UnitPrice = p.UnitPrice,
                    IsActive = p.IsActive,
                    IsAvailable = p.IsAvailable,

                    // Solo se utiliza para mostrar la categoría en la vista.
                    ProductCategory = new ProductCategory
                    {
                        CategoryName = p.CategoryName
                    }
                })
                .ToList();

            _view.MostrarProductos(productos);
        }

        private void CargarClientes()
        {
            List<Customer> clientes = _repository
                .ObtenerClientesActivos()
                .Select(c => new Customer
                {
                    CustomerId = c.CustomerId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Phone = c.Phone,
                    IsActive = true
                })
                .ToList();

            _view.MostrarClientes(clientes);
        }

        private void CargarMesasDisponibles()
        {
            List<TableRestaurant> mesas = _repository
                .ObtenerMesasDisponibles()
                .Select(m => new TableRestaurant
                {
                    TableId = m.TableId,
                    TableNumber = m.TableNumber,
                    Capacity = checked((byte)m.Capacity),
                    Status = m.Status,
                    IsActive = m.IsActive
                })
                .ToList();

            _view.MostrarMesas(mesas);
        }

        #endregion

        #region Selección de cliente y reservas

        private void ClienteSeleccionado(object? sender, EventArgs e)
        {
            try
            {
                _view.BloquearMesa(false);

                if (!_view.ClienteIdSeleccionado.HasValue)
                    return;

                int clienteId = _view.ClienteIdSeleccionado.Value;

                ReservaOperacionDto? reserva =
                    _repository.ObtenerReservaAtendidaCliente(
                        clienteId,
                        DateOnly.FromDateTime(DateTime.Today));

                if (reserva is null)
                    return;

                // La reserva puede conservar un TableId cuya mesa
                // ya no esté activa. En ese caso no debe seleccionarse.
                if (!reserva.TableId.HasValue ||
                    !reserva.TableNumber.HasValue)
                {
                    _view.MostrarMensaje(
                        "La reserva del cliente tiene una mesa que ya no está disponible.",
                        "Mesa de reserva",
                        true);
                    return;
                }

                _view.SeleccionarMesa(reserva.TableId.Value);
                _view.BloquearMesa(true);

                _view.MostrarMensaje(
                    "Reserva encontrada.\n\n" +
                    $"Mesa asignada: {reserva.TableNumber.Value:00}\n" +
                    $"Hora de reserva: " +
                    $"{reserva.ReservationTime.ToString("HH:mm")}\n\n" +
                    "La mesa ha sido seleccionada automáticamente " +
                    "y no puede modificarse.",
                    "Reserva detectada");
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    "No fue posible verificar la reserva del cliente.\n\n" +
                    ex.Message,
                    "Error",
                    true);
            }
        }

        #endregion

        #region Registro de clientes

        private void RegistrarNuevoCliente(object? sender, EventArgs e)
        {
            string nombreCompleto =
                _view.NuevoClienteNombre.Trim();

            string telefono =
                _view.NuevoClienteTelefono.Trim();

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

            string[] partes = nombreCompleto.Split(
                ' ',
                StringSplitOptions.RemoveEmptyEntries);

            if (partes.Length < 2)
            {
                _view.MostrarMensaje(
                    "Ingrese al menos nombre y apellido del cliente.",
                    "Nombre incompleto",
                    true);
                return;
            }

            string nombre = partes[0];
            string apellido = string.Join(" ", partes.Skip(1));

            try
            {
                if (_repository.ExisteTelefonoClienteActivo(telefono))
                {
                    _view.MostrarMensaje(
                        "Ya existe un cliente activo registrado con ese teléfono.",
                        "Cliente existente",
                        true);
                    return;
                }

                ResultadoOperacionDto resultado =
                    _repository.RegistrarCliente(
                        nombre,
                        apellido,
                        telefono,
                        out int clienteId);

                if (!resultado.Exito)
                {
                    _view.MostrarMensaje(
                        resultado.Mensaje,
                        "No fue posible registrar el cliente",
                        true);
                    return;
                }

                CargarClientes();
                _view.SeleccionarCliente(clienteId);
                _view.CerrarPanelNuevoCliente();

                _view.MostrarMensaje(
                    resultado.Mensaje,
                    "Cliente registrado");
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    "No fue posible guardar el cliente en la base de datos.\n\n" +
                    (ex.InnerException?.Message ?? ex.Message),
                    "Error de base de datos",
                    true);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    "Ocurrió un error inesperado al registrar el cliente.\n\n" +
                    ex.Message,
                    "Error",
                    true);
            }
        }

        #endregion

        #region Registro de ventas

        private void RegistrarOrden(object? sender, EventArgs e)
        {
            ResultadoVentaDto resultado;

            try
            {
                if (_usuarioId <= 0)
                {
                    _view.MostrarMensaje(
                        "No se ha identificado un usuario válido para registrar la venta.",
                        "Usuario inválido",
                        true);
                    return;
                }

                if (!_repository.TieneCajaAbierta(_usuarioId))
                {
                    _view.MostrarMensaje(
                        "No puede registrar la venta porque no existe una caja abierta " +
                        "para el usuario actual.\n\n" +
                        "Realice la apertura de caja antes de continuar.",
                        "Caja requerida",
                        true);
                    return;
                }

                if (_view.DetallesVenta.Count == 0)
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
                    mesaId = null;

                string metodoPagoVista =
                    _view.MetodoPago?.Trim() ?? string.Empty;

                if (!PaymentMethods.TryGetValue(
                    metodoPagoVista,
                    out string metodoPagoBD))
                {
                    _view.MostrarMensaje(
                        "Seleccione un método de pago válido.",
                        "Método de pago inválido",
                        true);
                    return;
                }

                List<PuntoVentaDetalleDto> detalles = _view.DetallesVenta
                    .Select(d => new PuntoVentaDetalleDto
                    {
                        ProductoId = d.ProductoId,
                        Cantidad = d.Cantidad,
                        Observacion = d.Observacion?.Trim() ?? string.Empty
                    })
                    .ToList();

                if (detalles.Any(d =>
                    d.ProductoId <= 0 || d.Cantidad <= 0))
                {
                    _view.MostrarMensaje(
                        "El pedido contiene productos o cantidades inválidas.",
                        "Datos inválidos",
                        true);
                    return;
                }

                if (detalles.Any(d => d.Observacion.Length > 255))
                {
                    _view.MostrarMensaje(
                        "Cada observación de producto debe tener 255 caracteres como máximo.",
                        "Observación demasiado larga",
                        true);
                    return;
                }

                var solicitud = new SolicitudVentaDto
                {
                    UsuarioId = _usuarioId,
                    ClienteId = _view.ClienteIdSeleccionado,
                    MesaId = mesaId,
                    TipoOrden = tipoOrden,
                    MetodoPago = metodoPagoBD,
                    Prioridad = _view.Prioridad,
                    Detalles = detalles
                };

                // El repositorio valida los datos almacenados y registra
                // la venta, el pago y la orden de cocina en una transacción.
                resultado = _repository.RegistrarVenta(solicitud);
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    "No fue posible registrar la venta en la base de datos.\n\n" +
                    (ex.InnerException?.Message ?? ex.Message),
                    "Error de base de datos",
                    true);
                return;
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    "Ocurrió un error inesperado al registrar la venta.\n\n" +
                    ex.Message,
                    "Error",
                    true);
                return;
            }

            if (!resultado.Exito)
            {
                if (resultado.Titulo.Equals(
                    "Mesa ocupada",
                    StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        CargarMesasDisponibles();
                    }
                    catch (Exception ex)
                    {
                        _view.MostrarMensaje(
                            "No fue posible actualizar la lista de mesas.\n\n" +
                            ex.Message,
                            "Error",
                            true);
                    }
                }

                _view.MostrarMensaje(
                    resultado.Mensaje,
                    resultado.Titulo,
                    resultado.EsError);
                return;
            }

            CultureInfo cultura =
                CultureInfo.GetCultureInfo("es-NI");

            _view.MostrarMensaje(
                "La venta fue registrada correctamente.\n\n" +
                $"Total: C$ {resultado.Total.ToString("N2", cultura)}\n" +
                $"Pago: {resultado.MetodoPago}\n" +
                "La orden fue enviada a Cocina.",
                resultado.Titulo);

            _view.LimpiarCarrito();

            try
            {
                CargarMesasDisponibles();
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    "La venta se registró correctamente, pero no fue posible " +
                    "actualizar la lista de mesas.\n\n" + ex.Message,
                    "Venta registrada",
                    true);
            }
        }

        #endregion

        public void Dispose()
        {
            if (_disposed)
                return;

            _view.PagarYRegistrarOrden -= RegistrarOrden;
            _view.GuardarNuevoCliente -= RegistrarNuevoCliente;
            _view.ClienteSeleccionadoChanged -= ClienteSeleccionado;

            _repository.Dispose();
            _disposed = true;
        }
    }
}
