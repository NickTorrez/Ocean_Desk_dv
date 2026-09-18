using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.UI.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.View.Interfaces
{
    /// <summary>
    /// Contrato entre FrmCocinaPedidos y CocinaPresenter.
    ///
    /// La interfaz evita que el Presenter dependa directamente de los controles
    /// concretos del formulario. La Vista se encarga de mostrar información y
    /// capturar acciones; el Presenter concentra la lógica de negocio.
    /// </summary>
    public interface ICocinaView
    {
        /// <summary>
        /// Identificador de la orden actualmente seleccionada en dgvPedido.
        /// </summary>
        int? PedidoIdSeleccionado { get; }

        /// <summary>
        /// Notifica al Presenter que el usuario seleccionó una orden.
        /// </summary>
        event EventHandler<int> PedidoSeleccionado;

        /// <summary>
        /// Solicita volver a consultar las órdenes de cocina.
        /// </summary>
        event EventHandler ActualizarPedidosClicked;

        /// <summary>
        /// Solicita iniciar la preparación de la orden seleccionada.
        /// </summary>
        event EventHandler IniciarPreparacionClicked;

        /// <summary>
        /// Solicita marcar como lista la orden que se encuentra en preparación.
        /// </summary>
        event EventHandler MarcarListoClicked;

        /// <summary>
        /// Solicita marcar como entregado el pedido que se encuentra listo.
        /// </summary>
        event EventHandler EntregarPedidoClicked;

        /// <summary>
        /// Solicita cancelar la orden seleccionada.
        /// </summary>
        event EventHandler CancelarPedidoClicked;

        /// <summary>
        /// Solicita limpiar la selección y el detalle mostrado.
        /// </summary>
        event EventHandler LimpiarClicked;

        /// <summary>
        /// Muestra la lista de órdenes activas en el DataGridView principal.
        /// </summary>
        void MostrarPedidos(IReadOnlyList<CocinaPedidoResumen> pedidos);

        /// <summary>
        /// Muestra el detalle y los datos principales de una orden seleccionada.
        /// </summary>
        void MostrarDetallePedido(
            CocinaPedidoSeleccionado? pedido,
            IReadOnlyList<CocinaPedidoDetalle> detalles);

        /// <summary>
        /// Actualiza las tarjetas de indicadores del módulo.
        /// </summary>
        void MostrarIndicadores(int pendientes, int enPreparacion, int listos);

        /// <summary>
        /// Actualiza el estado habilitado/deshabilitado de los botones.
        /// </summary>
        void ActualizarBotones(string estado, bool puedeCancelar);

        /// <summary>
        /// Selecciona una fila concreta del DataGridView de pedidos.
        /// </summary>
        void SeleccionarPedido(int pedidoId);

        /// <summary>
        /// Limpia la información del pedido seleccionado y su detalle.
        /// </summary>
        void LimpiarSeleccion();

        /// <summary>
        /// Solicita el motivo obligatorio de una cancelación.
        /// Devuelve null si el usuario cancela la entrada.
        /// </summary>
        string? SolicitarMotivoCancelacion();

        /// <summary>
        /// Muestra una confirmación antes de ejecutar una operación crítica.
        /// </summary>
        System.Windows.Forms.DialogResult ConfirmarAccion(string titulo, string mensaje);

        /// <summary>
        /// Muestra información, advertencias o errores al usuario.
        /// </summary>
        void MostrarMensaje(string mensaje, string titulo = "Cocina", bool esError = false);
    }

    /// <summary>
    /// Modelo de presentación utilizado para representar una fila de dgvPedido.
    /// No representa una tabla de SQL Server; únicamente transporta información hacia la Vista.
    /// </summary>
    public sealed class CocinaPedidoResumen
    {
        public int KitchenOrderId { get; init; }
        public int SaleId { get; init; }
        public string Mesa { get; init; } = string.Empty;
        public string TipoOrden { get; init; } = string.Empty;
        public DateTime Hora { get; init; }
        public string Prioridad { get; init; } = string.Empty;
        public string Estado { get; init; } = string.Empty;
    }

    /// <summary>
    /// Modelo de presentación utilizado para mostrar la información principal
    /// del pedido seleccionado.
    /// </summary>
    public sealed class CocinaPedidoSeleccionado
    {
        public int KitchenOrderId { get; init; }
        public string Mesa { get; init; } = string.Empty;
        public string TipoOrden { get; init; } = string.Empty;
        public DateTime Hora { get; init; }
        public string Prioridad { get; init; } = string.Empty;
        public string Estado { get; init; } = string.Empty;
    }

    /// <summary>
    /// Modelo de presentación para una línea de dgvDetallePedido.
    /// </summary>
    public sealed class CocinaPedidoDetalle
    {
        public decimal Cantidad { get; init; }
        public string Producto { get; init; } = string.Empty;
        public string Observaciones { get; init; } = string.Empty;
    }
}
