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
    /// Define el contrato entre FrmCaja y CajaPresenter.
    /// </summary>
    public interface ICajaView
    {
        /// <summary>
        /// Identificador del usuario que opera la caja.
        /// </summary>
        int UsuarioId { get; }

        event EventHandler AbrirCajaClicked;
        event EventHandler CerrarCajaClicked;
        event EventHandler RegistrarIngresoClicked;
        event EventHandler RegistrarEgresoClicked;

        void MostrarEstadoCaja(bool abierta, DateTime? fechaApertura);
        void MostrarResumen(decimal apertura, decimal ingresos, decimal egresos, decimal efectivoEsperado);
        void MostrarMovimientos(List<MovimientoCajaPrueba> movimientos);
        void MostrarMensaje(string mensaje, MessageType tipo);
        void MostrarConfirmacion(string mensaje, string titulo, Action accionConfirmada);

        decimal? SolicitarMonto(string mensaje, string titulo);
        string? SolicitarTexto(string mensaje, string titulo);
    }
}
