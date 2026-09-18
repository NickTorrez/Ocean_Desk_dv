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
        private const string EstadoEntregado = "Delivered";
        private const string EstadoCancelado = "Cancelled";
        private const string RolAdministrador = "Administrator";
        private const string RolPersonalCocina = "Kitchen Personnel";

        private readonly ICocinaView _view;
        private readonly OceanDeskDbContext _context;
        private readonly int? _usuarioId;
        private readonly string? _rolUsuario;

        // Queue<T> representa el orden FIFO de las órdenes activas de cocina.
        // Mantiene las órdenes Pending, InPreparation y Ready.
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
            _view.EntregarPedidoClicked += OnEntregarPedidoClicked;
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
        /// Sincroniza la cola FIFO con las órdenes activas de cocina.
        /// Conserva el orden de llegada y mantiene dentro de la cola
        /// las órdenes Pending, InPreparation y Ready.
        /// </summary>
        private void SincronizarCola(IReadOnlyList<CocinaPedidoResumen> pedidos)
        {
            var pedidosActivos = pedidos
                .Where(p =>
                    p.Estado == EstadoPendiente ||
                    p.Estado == EstadoPreparacion ||
                    p.Estado == EstadoListo)
                .OrderBy(p => p.Hora)
                .Select(p => p.KitchenOrderId)
                .ToList();

            // Conservamos únicamente los pedidos que siguen activos
            // y respetamos el orden que ya tenía la cola.
            var colaActual = _colaPedidosPendientes
                .Where(pedidosActivos.Contains)
                .ToList();

            // Agregamos al final únicamente los pedidos nuevos.
            foreach (int pedidoId in pedidosActivos)
            {
                if (!colaActual.Contains(pedidoId))
                {
                    colaActual.Add(pedidoId);
                }
            }

            _colaPedidosPendientes.Clear();

            foreach (int pedidoId in colaActual)
            {
                _colaPedidosPendientes.Enqueue(pedidoId);
            }
        }

        /// <summary>
        /// Indica si no existen pedidos activos en la cola.
        /// </summary>
        private bool ColaEstaVacia()
        {
            return _colaPedidosPendientes.Count == 0;
        }

        /// <summary>
        /// Obtiene el pedido que se encuentra al frente de la cola
        /// sin retirarlo.
        /// </summary>
        private int? ObtenerPedidoFrente()
        {
            if (ColaEstaVacia())
                return null;

            return _colaPedidosPendientes.Peek();
        }

        /// <summary>
        /// Comprueba si el pedido indicado se encuentra al frente de la cola.
        /// </summary>
        private bool EsPedidoAlFrente(int pedidoId)
        {
            int? pedidoFrente = ObtenerPedidoFrente();

            return pedidoFrente.HasValue &&
                   pedidoFrente.Value == pedidoId;
        }

        /// <summary>
        /// Retira de la cola el pedido que se encuentra al frente.
        /// </summary>
        private void DesencolarPedidoEntregado(int pedidoId)
        {
            if (ColaEstaVacia())
                return;

            if (_colaPedidosPendientes.Peek() == pedidoId)
            {
                _colaPedidosPendientes.Dequeue();
            }
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
        /// Implementación de Cola.
        /// </summary>
        private void OnIniciarPreparacionClicked(object? sender, EventArgs e)
        {
            int? pedidoId = _view.PedidoIdSeleccionado;

            if (!pedidoId.HasValue)
            {
                _view.MostrarMensaje(
                    "Seleccione un pedido para iniciar su preparación.",
                    "Pedido requerido",
                    true);
                return;
            }

            if (ColaEstaVacia())
            {
                _view.MostrarMensaje(
                    "No existen pedidos pendientes en la cola de cocina.",
                    "Cola vacía",
                    true);
                return;
            }

            int? pedidoFrente = ObtenerPedidoFrente();

            if (!pedidoFrente.HasValue)
                return;

            if (pedidoFrente.Value != pedidoId.Value)
            {
                _view.MostrarMensaje(
                    $"La orden #{pedidoId.Value:000} no puede iniciar su preparación todavía.\n\n" +
                    $"La siguiente orden en la cola es la #{pedidoFrente.Value:000}.",
                    "Orden fuera de turno",
                    true);
                return;
            }

            CambiarEstadoSeleccionado(EstadoPendiente,EstadoPreparacion);
        }

        /// <summary>
        /// Cambia una orden InPreparation a Ready.
        /// </summary>
        private void OnMarcarListoClicked(object? sender, EventArgs e)
        {
            CambiarEstadoSeleccionado( EstadoPreparacion, EstadoListo);
        }

        /// <summary>
        /// Cambia una orden Ready a Delivered.
        /// </summary>
        private void OnEntregarPedidoClicked(object? sender, EventArgs e)
        {
            int? pedidoId = _view.PedidoIdSeleccionado;

            if (!pedidoId.HasValue)
            {
                _view.MostrarMensaje(
                    "Seleccione un pedido para entregar.",
                    "Pedido requerido",
                    true);

                return;
            }

            if (!EsPedidoAlFrente(pedidoId.Value))
            {
                int? pedidoFrente = ObtenerPedidoFrente();

                if (!pedidoFrente.HasValue)
                {
                    _view.MostrarMensaje(
                        "No existen pedidos en la cola de cocina.",
                        "Cola vacía",
                        true);

                    return;
                }

                _view.MostrarMensaje(
                    $"La orden #{pedidoId.Value:000} no puede entregarse todavía.\n\n" +
                    $"La orden que ocupa el frente de la cola es " +
                    $"la #{pedidoFrente.Value:000}.",
                    "Orden fuera de turno",
                    true);

                return;
            }

            bool actualizado = CambiarEstadoSeleccionado( EstadoListo, EstadoEntregado);

            if (actualizado)
            {
                DesencolarPedidoEntregado(pedidoId.Value);
            }
        }

        /// <summary>
        /// Valida y ejecuta una transición de estado.
        /// Las fechas de preparación y listo se actualizan junto con el estado.
        /// El trigger de base de datos existente se encarga de la auditoría automática.
        /// </summary>
        private bool CambiarEstadoSeleccionado(
            string estadoEsperado,
            string nuevoEstado)
        {
            int? pedidoId = _view.PedidoIdSeleccionado;

            if (!pedidoId.HasValue)
            {
                _view.MostrarMensaje(
                    "Seleccione un pedido.",
                    "Pedido requerido",
                    true);

                return false;
            }

            try
            {
                KitchenOrder? pedido = _context.KitchenOrders
                    .FirstOrDefault(k => k.KitchenOrderId == pedidoId.Value);

                if (pedido == null)
                {
                    _view.MostrarMensaje(
                        "No se encontró el pedido seleccionado.",
                        "Pedido no encontrado",
                        true);

                    return false;
                }

                if (pedido.Status != estadoEsperado)
                {
                    _view.MostrarMensaje(
                        $"El pedido no puede pasar a '{nuevoEstado}' " +
                        $"porque su estado actual es '{pedido.Status}'.",
                        "Cambio de estado no válido",
                        true);

                    return false;
                }

                pedido.Status = nuevoEstado;

                if (nuevoEstado == EstadoPreparacion)
                {
                    pedido.PreparationStartDateTime = DateTime.Now;
                }
                else if (nuevoEstado == EstadoListo)
                {
                    pedido.ReadyDateTime = DateTime.Now;
                }
                else if (nuevoEstado == EstadoEntregado)
                {
                    pedido.DeliveredDateTime = DateTime.Now;
                }

                _context.SaveChanges();

                CargarPedidos();

                return true;
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    $"Ocurrió un error al cambiar el estado del pedido.\n\n" +
                    $"{ex.Message}",
                    "Error",
                    true);

                return false;
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
            _view.EntregarPedidoClicked -= OnEntregarPedidoClicked;
            _view.CancelarPedidoClicked -= OnCancelarPedidoClicked;
            _view.LimpiarClicked -= OnLimpiarClicked;

            _context.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
