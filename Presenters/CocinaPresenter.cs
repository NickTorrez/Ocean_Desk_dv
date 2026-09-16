using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Presenters
{
    /// <summary>
    /// Presenter del módulo de Control de Cocina y Seguimiento de Pedidos.
    /// Centraliza las consultas, validaciones, cambios de estado y coordinación
    /// entre la Vista y OceanDeskDbContext.
    /// </summary>
    public sealed class CocinaPresenter : IDisposable
    {
        private const string EstadoPendiente = "Pending";
        private const string EstadoPreparacion = "InPreparation";
        private const string EstadoListo = "Ready";
        private const string EstadoCancelado = "Cancelled";

        private const string RolAdministrador = "Administrator";
        private const string RolPersonalCocina = "Kitchen Personnel";

        private readonly ICocinaView _view;
        private readonly OceanDeskDbContext _context;
        private readonly int? _usuarioId;
        private readonly string? _rolUsuario;

        // Queue<T> representa el orden FIFO de las órdenes Pending.
        // No reemplaza la persistencia de SQL Server.
        private readonly Queue<int> _colaPedidosPendientes = new();
        private bool _disposed;

        /// <summary>
        /// Inicializa el Presenter de Cocina.
        /// </summary>
        /// <param name="view">Vista que implementa ICocinaView.</param>
        /// <param name="context">Contexto de acceso a datos.</param>
        /// <param name="usuarioId">Usuario autenticado. Puede ser null durante la etapa actual.</param>
        /// <param name="rolUsuario">Rol del usuario autenticado. Puede ser null durante la etapa actual.</param>
        public CocinaPresenter(
            ICocinaView view,
            OceanDeskDbContext context,
            int? usuarioId = null,
            string? rolUsuario = null)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _usuarioId = usuarioId;
            _rolUsuario = rolUsuario;

            _view.PedidoSeleccionado += OnPedidoSeleccionado;
            _view.ActualizarPedidosClicked += OnActualizarPedidosClicked;
            _view.IniciarPreparacionClicked += OnIniciarPreparacionClicked;
            _view.MarcarListoClicked += OnMarcarListoClicked;
            _view.CancelarPedidoClicked += OnCancelarPedidoClicked;
            _view.LimpiarClicked += OnLimpiarClicked;
        }

        #region Inicialización y consultas

        /// <summary>
        /// Realiza la primera carga del módulo.
        /// </summary>
        public void Inicializar()
        {
            CargarPedidos();
        }

        /// <summary>
        /// Consulta las órdenes activas de cocina y actualiza la Vista.
        /// </summary>
        public void CargarPedidos()
        {
            try
            {
                int? pedidoSeleccionadoAntes = _view.PedidoIdSeleccionado;

                var pedidos = _context.KitchenOrders
                    .AsNoTracking()
                    .Include(k => k.Sale)
                        .ThenInclude(s => s.Table)
                    .Where(k =>
                        k.Status == EstadoPendiente ||
                        k.Status == EstadoPreparacion ||
                        k.Status == EstadoListo)
                    .OrderBy(k => k.ReceptionDateTime)
                    .Select(k => new CocinaPedidoResumen
                    {
                        KitchenOrderId = k.KitchenOrderId,
                        SaleId = k.SaleId,
                        Mesa = k.Sale.Table != null
                            ? k.Sale.Table.TableNumber.ToString("00")
                            : "N/A",
                        TipoOrden = k.Sale.OrderType,
                        Hora = k.ReceptionDateTime,
                        Prioridad = k.Priority,
                        Estado = k.Status
                    })
                    .ToList();

                SincronizarCola(pedidos);

                _view.MostrarPedidos(pedidos);
                _view.MostrarIndicadores(
                    pedidos.Count(p => p.Estado == EstadoPendiente),
                    pedidos.Count(p => p.Estado == EstadoPreparacion),
                    pedidos.Count(p => p.Estado == EstadoListo));

                if (pedidoSeleccionadoAntes.HasValue &&
                    pedidos.Any(p => p.KitchenOrderId == pedidoSeleccionadoAntes.Value))
                {
                    _view.SeleccionarPedido(pedidoSeleccionadoAntes.Value);
                }
                else
                {
                    _view.MostrarDetallePedido(null, Array.Empty<CocinaPedidoDetalle>());
                }
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible cargar los pedidos de cocina.\n\n{ex.Message}",
                    "Error al cargar pedidos",
                    true);
            }
        }

        /// <summary>
        /// Sincroniza la cola FIFO con las órdenes que actualmente están Pending.
        /// </summary>
        private void SincronizarCola(IReadOnlyList<CocinaPedidoResumen> pedidos)
        {
            var pendientes = pedidos
                .Where(p => p.Estado == EstadoPendiente)
                .OrderBy(p => p.Hora)
                .Select(p => p.KitchenOrderId)
                .ToHashSet();

            var colaActual = _colaPedidosPendientes
                .Where(pendientes.Contains)
                .ToList();

            foreach (int pedidoId in pendientes)
            {
                if (!colaActual.Contains(pedidoId))
                    colaActual.Add(pedidoId);
            }

            _colaPedidosPendientes.Clear();

            foreach (int pedidoId in colaActual)
                _colaPedidosPendientes.Enqueue(pedidoId);
        }

        #endregion

        #region Selección y detalle

        /// <summary>
        /// Obtiene el detalle completo de la orden seleccionada.
        /// </summary>
        private void OnPedidoSeleccionado(object? sender, int pedidoId)
        {
            try
            {
                var pedido = _context.KitchenOrders
                    .AsNoTracking()
                    .Include(k => k.Sale)
                        .ThenInclude(s => s.Table)
                    .Include(k => k.KitchenOrderDetails)
                        .ThenInclude(d => d.SaleDetail)
                            .ThenInclude(sd => sd.Product)
                    .FirstOrDefault(k => k.KitchenOrderId == pedidoId);

                if (pedido == null)
                {
                    _view.MostrarMensaje(
                        "El pedido seleccionado ya no está disponible.",
                        "Pedido no encontrado",
                        true);

                    return;
                }

                var detalles = pedido.KitchenOrderDetails
                    .OrderBy(d => d.KitchenOrderDetailId)
                    .Select(d => new CocinaPedidoDetalle
                    {
                        Cantidad = d.Quantity,

                        Producto = d.SaleDetail.Product.ProductName,

                        Observaciones = d.Notes
                            ?? d.SaleDetail.Notes
                            ?? string.Empty
                    })
                    .ToList();

                _view.MostrarDetallePedido(
                    new CocinaPedidoSeleccionado
                    {
                        KitchenOrderId = pedido.KitchenOrderId,

                        Mesa = pedido.Sale.Table != null
                            ? pedido.Sale.Table.TableNumber.ToString("00")
                            : "N/A",

                        TipoOrden = pedido.Sale.OrderType,
                        Hora = pedido.ReceptionDateTime,
                        Prioridad = pedido.Priority,
                        Estado = pedido.Status
                    },
                    detalles);

                _view.ActualizarBotones(
                    pedido.Status,
                    PuedeCancelar(pedido.Status));
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible cargar el detalle del pedido.\n\n{ex.Message}",
                    "Error de consulta",
                    true);
            }
        }

        #endregion

        #region Cambios de estado

        /// <summary>
        /// Cambia una orden Pending a InPreparation.
        /// </summary>
        private void OnIniciarPreparacionClicked(object? sender, EventArgs e)
        {
            CambiarEstadoSeleccionado(
                EstadoPendiente,
                EstadoPreparacion);
        }

        /// <summary>
        /// Cambia una orden InPreparation a Ready.
        /// </summary>
        private void OnMarcarListoClicked(object? sender, EventArgs e)
        {
            CambiarEstadoSeleccionado(
                EstadoPreparacion,
                EstadoListo);
        }

        /// <summary>
        /// Valida y ejecuta una transición de estado.
        /// Las fechas de preparación y listo se actualizan junto con el estado.
        /// El trigger de base de datos existente se encarga de la auditoría automática.
        /// </summary>
        private void CambiarEstadoSeleccionado(
            string estadoEsperado,
            string nuevoEstado)
        {
            int? pedidoId = _view.PedidoIdSeleccionado;

            if (!pedidoId.HasValue)
            {
                _view.MostrarMensaje(
                    "Seleccione un pedido para continuar.",
                    "Pedido requerido",
                    true);
                return;
            }

            try
            {
                var pedido = _context.KitchenOrders
                    .FirstOrDefault(k => k.KitchenOrderId == pedidoId.Value);

                if (pedido == null)
                {
                    _view.MostrarMensaje(
                        "El pedido seleccionado ya no existe en la base de datos.",
                        "Pedido no encontrado",
                        true);
                    CargarPedidos();
                    return;
                }

                if (!string.Equals(pedido.Status, estadoEsperado, StringComparison.OrdinalIgnoreCase))
                {
                    _view.MostrarMensaje(
                        $"El pedido no puede pasar a '{nuevoEstado}' porque su estado actual es '{pedido.Status}'.",
                        "Transición no válida",
                        true);
                    CargarPedidos();
                    return;
                }

                DateTime ahora = DateTime.Now;
                pedido.Status = nuevoEstado;

                if (nuevoEstado == EstadoPreparacion)
                    pedido.PreparationStartDateTime = ahora;
                else if (nuevoEstado == EstadoListo)
                    pedido.ReadyDateTime = ahora;

                _context.SaveChanges();
                CargarPedidos();

                // Refrescar explícitamente el detalle y los botones
                // de la misma orden después de cambiar su estado.
                OnPedidoSeleccionado(this, pedidoId.Value);
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible actualizar el estado del pedido.\n\n{ex.InnerException?.Message ?? ex.Message}",
                    "Error de base de datos",
                    true);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    $"Ocurrió un error al cambiar el estado del pedido.\n\n{ex.Message}",
                    "Error",
                    true);
            }
        }

        #endregion

        #region Cancelación y permisos

        /// <summary>
        /// Cancela una orden sin eliminarla físicamente.
        /// El motivo se conserva en Notes para mantenerlo asociado a la orden y
        /// permitir que el trigger de auditoría registre el cambio de estado.
        /// </summary>
        private void OnCancelarPedidoClicked(object? sender, EventArgs e)
        {
            int? pedidoId = _view.PedidoIdSeleccionado;

            if (!pedidoId.HasValue)
            {
                _view.MostrarMensaje(
                    "Seleccione un pedido para continuar.",
                    "Pedido requerido",
                    true);
                return;
            }

            try
            {
                var pedido = _context.KitchenOrders
                    .FirstOrDefault(k => k.KitchenOrderId == pedidoId.Value);

                if (pedido == null)
                {
                    _view.MostrarMensaje(
                        "El pedido seleccionado ya no existe.",
                        "Pedido no encontrado",
                        true);
                    CargarPedidos();
                    return;
                }

                if (!PuedeCancelar(pedido.Status))
                {
                    string mensaje = pedido.Status == EstadoPreparacion && EsPersonalCocina()
                        ? "Un pedido que ya está en preparación requiere intervención administrativa para ser cancelado."
                        : "No tiene permisos para cancelar este pedido en su estado actual.";

                    _view.MostrarMensaje(
                        mensaje,
                        "Operación no autorizada",
                        true);
                    return;
                }

                string? motivo = _view.SolicitarMotivoCancelacion();

                if (string.IsNullOrWhiteSpace(motivo))
                    return;

                DialogResult confirmacion = _view.ConfirmarAccion(
                    "Cancelar pedido",
                    $"¿Está seguro de cancelar la orden #{pedido.KitchenOrderId:000}?\n\nMotivo: {motivo}");

                if (confirmacion != DialogResult.Yes)
                    return;

                pedido.Status = EstadoCancelado;
                pedido.Notes = AgregarMotivoCancelacion(pedido.Notes, motivo);

                _context.SaveChanges();
                CargarPedidos();
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible cancelar el pedido.\n\n{ex.InnerException?.Message ?? ex.Message}",
                    "Error de base de datos",
                    true);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    $"Ocurrió un error al cancelar el pedido.\n\n{ex.Message}",
                    "Error",
                    true);
            }
        }

        /// <summary>
        /// Administrator puede cancelar Pending e InPreparation.
        /// Kitchen Personnel puede cancelar Pending únicamente.
        /// </summary>
        private bool PuedeCancelar(string estado)
        {
            if (EsAdministrador())
                return estado == EstadoPendiente || estado == EstadoPreparacion;

            if (EsPersonalCocina())
                return estado == EstadoPendiente;

            // Mientras la autenticación todavía no entrega un rol real,
            // se bloquean las cancelaciones para evitar elevar privilegios.
            return false;
        }

        private bool EsAdministrador() =>
            string.Equals(_rolUsuario, RolAdministrador, StringComparison.OrdinalIgnoreCase);

        private bool EsPersonalCocina() =>
            string.Equals(_rolUsuario, RolPersonalCocina, StringComparison.OrdinalIgnoreCase);

        private static string AgregarMotivoCancelacion(string? notasActuales, string motivo)
        {
            string texto = string.IsNullOrWhiteSpace(notasActuales)
                ? string.Empty
                : notasActuales.Trim();

            string nuevaNota = $"[Cancellation reason: {motivo.Trim()}]";

            if (texto.Contains(nuevaNota, StringComparison.OrdinalIgnoreCase))
                return texto;

            return string.IsNullOrWhiteSpace(texto)
                ? nuevaNota
                : $"{texto} {nuevaNota}";
        }

        #endregion

        #region Eventos generales

        private void OnActualizarPedidosClicked(object? sender, EventArgs e)
        {
            CargarPedidos();
        }

        private void OnLimpiarClicked(object? sender, EventArgs e)
        {
            _view.LimpiarSeleccion();
        }

        #endregion

        #region Liberación de recursos

        /// <summary>
        /// Libera las suscripciones de eventos y el contexto de datos.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
                return;

            _view.PedidoSeleccionado -= OnPedidoSeleccionado;
            _view.ActualizarPedidosClicked -= OnActualizarPedidosClicked;
            _view.IniciarPreparacionClicked -= OnIniciarPreparacionClicked;
            _view.MarcarListoClicked -= OnMarcarListoClicked;
            _view.CancelarPedidoClicked -= OnCancelarPedidoClicked;
            _view.LimpiarClicked -= OnLimpiarClicked;

            _context.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
