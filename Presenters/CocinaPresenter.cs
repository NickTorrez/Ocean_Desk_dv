using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;
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
        private readonly ICocinaRepository _repository;
        private readonly int? _usuarioId;
        private readonly string? _rolUsuario;

        // Conserva el orden FIFO de los pedidos activos.
        private readonly Queue<int> _colaPedidosPendientes = new();

        private bool _disposed;

        public CocinaPresenter(
            ICocinaView view,
            ICocinaRepository repository,
            int? usuarioId = null,
            string? rolUsuario = null)
        {
            _view = view ??
                throw new ArgumentNullException(nameof(view));

            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));

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

        public void Inicializar()
        {
            CargarPedidos();
        }

        /// <summary>
        /// Consulta los pedidos activos y actualiza los indicadores.
        /// Conserva la selección cuando el pedido continúa activo.
        /// </summary>
        public void CargarPedidos()
        {
            try
            {
                int? pedidoSeleccionadoAntes =
                    _view.PedidoIdSeleccionado;

                List<CocinaPedidoResumen> pedidos = _repository
                    .ObtenerPedidosActivos()
                    .Select(p => new CocinaPedidoResumen
                    {
                        KitchenOrderId = p.KitchenOrderId,
                        SaleId = p.SaleId,
                        Mesa = p.Mesa,
                        TipoOrden = p.TipoOrden,
                        Hora = p.Hora,
                        Prioridad = p.Prioridad,
                        Estado = p.Estado
                    })
                    .ToList();

                SincronizarCola(pedidos);

                _view.MostrarPedidos(pedidos);

                _view.MostrarIndicadores(
                    pedidos.Count(p => p.Estado == EstadoPendiente),
                    pedidos.Count(p => p.Estado == EstadoPreparacion),
                    pedidos.Count(p => p.Estado == EstadoListo));

                if (pedidoSeleccionadoAntes.HasValue &&
                    pedidos.Any(p =>
                        p.KitchenOrderId == pedidoSeleccionadoAntes.Value))
                {
                    _view.SeleccionarPedido(
                        pedidoSeleccionadoAntes.Value);
                }
                else
                {
                    _view.MostrarDetallePedido(
                        null,
                        Array.Empty<CocinaPedidoDetalle>());
                }
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    "No fue posible cargar los pedidos de cocina.\n\n" +
                    ex.Message,
                    "Error al cargar pedidos",
                    true);
            }
        }

        /// <summary>
        /// Mantiene los pedidos activos en la cola, respetando el orden
        /// ya establecido y añadiendo al final los pedidos nuevos.
        /// </summary>
        private void SincronizarCola(
            IReadOnlyList<CocinaPedidoResumen> pedidos)
        {
            List<int> pedidosActivos = pedidos
                .Where(p =>
                    p.Estado == EstadoPendiente ||
                    p.Estado == EstadoPreparacion ||
                    p.Estado == EstadoListo)
                .OrderBy(p => p.Hora)
                .Select(p => p.KitchenOrderId)
                .ToList();

            List<int> colaActual = _colaPedidosPendientes
                .Where(pedidosActivos.Contains)
                .ToList();

            foreach (int pedidoId in pedidosActivos)
            {
                if (!colaActual.Contains(pedidoId))
                    colaActual.Add(pedidoId);
            }

            _colaPedidosPendientes.Clear();

            foreach (int pedidoId in colaActual)
                _colaPedidosPendientes.Enqueue(pedidoId);
        }

        private bool ColaEstaVacia() =>
            _colaPedidosPendientes.Count == 0;

        private int? ObtenerPedidoFrente() =>
            ColaEstaVacia()
                ? null
                : _colaPedidosPendientes.Peek();

        private bool EsPedidoAlFrente(int pedidoId) =>
            ObtenerPedidoFrente() == pedidoId;

        private void DesencolarPedidoEntregado(int pedidoId)
        {
            if (!ColaEstaVacia() &&
                _colaPedidosPendientes.Peek() == pedidoId)
            {
                _colaPedidosPendientes.Dequeue();
            }
        }

        #endregion

        #region Selección y detalle

        private void OnPedidoSeleccionado(
            object? sender,
            int pedidoId)
        {
            try
            {
                CocinaPedidoCompletoDto? consulta =
                    _repository.ObtenerPedido(pedidoId);

                if (consulta is null)
                {
                    _view.MostrarMensaje(
                        "El pedido seleccionado ya no está disponible.",
                        "Pedido no encontrado",
                        true);
                    return;
                }

                CocinaPedidoSeleccionadoDto pedido =
                    consulta.Pedido;

                List<CocinaPedidoDetalle> detalles =
                    consulta.Detalles
                        .Select(d => new CocinaPedidoDetalle
                        {
                            Cantidad = d.Cantidad,
                            Producto = d.Producto,
                            Observaciones = d.Observaciones
                        })
                        .ToList();

                _view.MostrarDetallePedido(
                    new CocinaPedidoSeleccionado
                    {
                        KitchenOrderId = pedido.KitchenOrderId,
                        Mesa = pedido.Mesa,
                        TipoOrden = pedido.TipoOrden,
                        Hora = pedido.Hora,
                        Prioridad = pedido.Prioridad,
                        Estado = pedido.Estado
                    },
                    detalles);

                _view.ActualizarBotones(
                    pedido.Estado,
                    PuedeCancelar(pedido.Estado));
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    "No fue posible cargar el detalle del pedido.\n\n" +
                    ex.Message,
                    "Error de consulta",
                    true);
            }
        }

        #endregion

        #region Cambios de estado

        /// <summary>
        /// Solo permite iniciar la preparación del pedido que está
        /// al frente de la cola FIFO.
        /// </summary>
        private void OnIniciarPreparacionClicked(
            object? sender,
            EventArgs e)
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
                    $"La orden #{pedidoId.Value:000} no puede iniciar " +
                    "su preparación todavía.\n\n" +
                    $"La siguiente orden en la cola es la " +
                    $"#{pedidoFrente.Value:000}.",
                    "Orden fuera de turno",
                    true);
                return;
            }

            CambiarEstadoSeleccionado(
                EstadoPendiente,
                EstadoPreparacion);
        }

        private void OnMarcarListoClicked(
            object? sender,
            EventArgs e)
        {
            CambiarEstadoSeleccionado(
                EstadoPreparacion,
                EstadoListo);
        }

        /// <summary>
        /// Solo permite entregar el pedido que ocupa el frente de la cola.
        /// </summary>
        private void OnEntregarPedidoClicked(
            object? sender,
            EventArgs e)
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
                    $"La orden #{pedidoId.Value:000} no puede entregarse " +
                    "todavía.\n\n" +
                    $"La orden que ocupa el frente de la cola es " +
                    $"la #{pedidoFrente.Value:000}.",
                    "Orden fuera de turno",
                    true);
                return;
            }

            bool actualizado = CambiarEstadoSeleccionado(
                EstadoListo,
                EstadoEntregado);

            if (actualizado)
                DesencolarPedidoEntregado(pedidoId.Value);
        }

        /// <summary>
        /// Solicita al repositorio una transición de estado.
        /// El repositorio valida el estado previo y actualiza las fechas
        /// relacionadas con la preparación, finalización o entrega.
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
                ResultadoOperacionDto resultado =
                    _repository.CambiarEstado(
                        pedidoId.Value,
                        estadoEsperado,
                        nuevoEstado,
                        DateTime.Now);

                if (!resultado.Exito)
                {
                    _view.MostrarMensaje(
                        resultado.Mensaje,
                        "Cambio de estado no válido",
                        true);
                    return false;
                }

                CargarPedidos();
                return true;
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    "Ocurrió un error al cambiar el estado del pedido.\n\n" +
                    ex.Message,
                    "Error",
                    true);
                return false;
            }
        }

        #endregion

        #region Cancelación y permisos

        private void OnCancelarPedidoClicked(
            object? sender,
            EventArgs e)
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
                string? estadoActual =
                    _repository.ObtenerEstadoPedido(pedidoId.Value);

                if (estadoActual is null)
                {
                    _view.MostrarMensaje(
                        "El pedido seleccionado ya no existe.",
                        "Pedido no encontrado",
                        true);

                    CargarPedidos();
                    return;
                }

                if (!PuedeCancelar(estadoActual))
                {
                    string mensaje =
                        estadoActual == EstadoPreparacion &&
                        EsPersonalCocina()
                            ? "Un pedido que ya está en preparación requiere " +
                              "intervención administrativa para ser cancelado."
                            : "No tiene permisos para cancelar este pedido " +
                              "en su estado actual.";

                    _view.MostrarMensaje(
                        mensaje,
                        "Operación no autorizada",
                        true);
                    return;
                }

                string? motivo =
                    _view.SolicitarMotivoCancelacion();

                if (string.IsNullOrWhiteSpace(motivo))
                    return;

                DialogResult confirmacion =
                    _view.ConfirmarAccion(
                        "Cancelar pedido",
                        $"¿Está seguro de cancelar la orden " +
                        $"#{pedidoId.Value:000}?\n\nMotivo: {motivo}");

                if (confirmacion != DialogResult.Yes)
                    return;

                ResultadoOperacionDto resultado =
                    _repository.CancelarPedido(
                        pedidoId.Value,
                        motivo,
                        estadoActual);

                if (!resultado.Exito)
                {
                    _view.MostrarMensaje(
                        resultado.Mensaje,
                        "No se pudo cancelar el pedido",
                        true);

                    CargarPedidos();
                    return;
                }

                CargarPedidos();
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    "No fue posible cancelar el pedido.\n\n" +
                    (ex.InnerException?.Message ?? ex.Message),
                    "Error de base de datos",
                    true);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    "Ocurrió un error al cancelar el pedido.\n\n" +
                    ex.Message,
                    "Error",
                    true);
            }
        }

        /// <summary>
        /// Administrador: puede cancelar Pending e InPreparation.
        /// Personal de cocina: solo puede cancelar Pending.
        /// </summary>
        private bool PuedeCancelar(string estado)
        {
            if (EsAdministrador())
            {
                return estado == EstadoPendiente ||
                       estado == EstadoPreparacion;
            }

            if (EsPersonalCocina())
                return estado == EstadoPendiente;

            // Sin rol autenticado, se bloquea la cancelación.
            return false;
        }

        private bool EsAdministrador() =>
            string.Equals(
                _rolUsuario,
                RolAdministrador,
                StringComparison.OrdinalIgnoreCase);

        private bool EsPersonalCocina() =>
            string.Equals(
                _rolUsuario,
                RolPersonalCocina,
                StringComparison.OrdinalIgnoreCase);

        #endregion

        #region Eventos generales

        private void OnActualizarPedidosClicked(
            object? sender,
            EventArgs e)
        {
            CargarPedidos();
        }

        private void OnLimpiarClicked(
            object? sender,
            EventArgs e)
        {
            _view.LimpiarSeleccion();
        }

        #endregion

        #region Liberación de recursos

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

            _repository.Dispose();
            _disposed = true;

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
