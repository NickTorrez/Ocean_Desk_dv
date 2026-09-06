using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.UI.Catalogs;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.View.Interfaces
{
    /// <summary>
    /// Define el contrato entre FrmFacturacion y FacturacionPresenter.
    /// La vista expone eventos y operaciones necesarias para consultar,
    /// visualizar y anular facturas sin acceder directamente a la BD.
    /// </summary>
    public interface IFacturacionView
    {
        /// <summary>
        /// Obtiene el número de factura seleccionado en la vista.
        /// </summary>
        string NumeroFacturaSeleccionada { get; }

        /// <summary>
        /// Obtiene el ID del usuario que está operando el módulo.
        /// </summary>
        int UsuarioId { get; }

        /// <summary>
        /// Carga en la vista las facturas obtenidas desde la base de datos.
        /// </summary>
        void MostrarFacturas(List<FacturaPrueba> facturas);

        /// <summary>
        /// Muestra el detalle de una factura.
        /// </summary>
        void MostrarDetalleFactura(FacturaPrueba factura);

        /// <summary>
        /// Muestra un mensaje al usuario.
        /// </summary>
        void MostrarMensaje(string mensaje, string titulo, MessageType tipo);

        /// <summary>
        /// Refresca la lista de facturas después de una operación.
        /// </summary>
        void RefrescarFacturas();

        /// <summary>
        /// Evento para consultar el detalle de la factura seleccionada.
        /// </summary>
        event EventHandler VerDetalleClicked;

        /// <summary>
        /// Evento para anular la factura seleccionada.
        /// </summary>
        event EventHandler AnularFacturaClicked;
    }
}
