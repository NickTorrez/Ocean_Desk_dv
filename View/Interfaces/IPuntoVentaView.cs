using Ocean_Desk_dv.UI.Catalogs;
using System;
using Ocean_Desk_dv.Models.Entities;
using System.Collections.Generic;

namespace Ocean_Desk_dv.View.Interfaces
{
    /// <summary>
    /// Contrato entre el formulario de Punto de Venta y su Presenter.
    /// </summary>
    public interface IPuntoVentaView
    {
        string TipoOrden { get; }
        int? MesaIdSeleccionada { get; }
        int? ClienteIdSeleccionado { get; }
        string MetodoPago { get; }

        string NuevoClienteNombre { get; }
        string NuevoClienteTelefono { get; }

        IReadOnlyList<PuntoVentaDetalle> DetallesVenta { get; }

        void MostrarProductos(List<Product> productos);
        void MostrarClientes(List<Customer> clientes);
        void MostrarMesas(List<TableRestaurant> mesas);

        void MostrarMensaje(string mensaje, string titulo = "Punto de Venta", bool esError = false);
        void LimpiarCarrito();
        void SeleccionarCliente(int customerId);
        void CerrarPanelNuevoCliente();

        event EventHandler? PagarYRegistrarOrden;
        event EventHandler? GuardarNuevoCliente;
    }

    /// <summary>
    /// Datos mínimos de un producto agregado al pedido.
    /// No expone directamente la Entity de SaleDetail a la vista.
    /// </summary>
    public class PuntoVentaDetalle
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
