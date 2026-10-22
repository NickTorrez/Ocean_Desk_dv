using Ocean_Desk_dv.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.View.Interfaces
{
    /// <summary>
    /// Contrato entre FrmInventario y InventarioPresenter.
    /// Expone los filtros, los eventos y los métodos de presentación del módulo.
    /// </summary>
    public interface IInventarioView
    {
        /// <summary>
        /// Ingrediente seleccionado en la tabla de existencias.
        /// </summary>
        ExistenciaInventarioDto? ExistenciaSeleccionada { get; }

        /// <summary>Filtros actuales de la tabla de existencias.</summary>
        FiltroExistenciasInventarioDto FiltroExistenciasActual { get; }

        /// <summary>Filtros actuales del historial de movimientos.</summary>
        FiltroMovimientosInventarioDto FiltroMovimientosActual { get; }

        /// <summary>
        /// Muestra las existencias devueltas por el repositorio.
        /// </summary>
        void MostrarExistencias(IReadOnlyList<ExistenciaInventarioDto> existencias);

        /// <summary>
        /// Muestra los movimientos devueltos por el repositorio.
        /// </summary>
        void MostrarMovimientos(IReadOnlyList<MovimientoInventarioDto> movimientos);

        /// <summary>
        /// Llena el filtro de categorías de inventario.
        /// </summary>
        void MostrarCategoriasInventario(IReadOnlyList<string> categorias);

        /// <summary>
        /// Abre el diálogo para registrar un movimiento sobre el ingrediente
        /// seleccionado. Devuelve null cuando no hay selección o se cancela.
        /// </summary>
        SolicitudMovimientoInventarioDto? SolicitarMovimiento(
            string tipoMovimiento,
            ExistenciaInventarioDto? producto);

        /// <summary>
        /// Muestra mensajes de resultado o validación al usuario.
        /// </summary>
        void MostrarMensaje(string mensaje, string titulo = "Inventario", bool esError = false);

        /// <summary>Se produce cuando cambian los filtros de existencias.</summary>
        event EventHandler? FiltrosExistenciasCambiados;

        /// <summary>Se produce cuando cambian los filtros de movimientos.</summary>
        event EventHandler? FiltrosMovimientosCambiados;

        /// <summary>Se produce cuando el usuario solicita refrescar el inventario.</summary>
        event EventHandler? RefrescarInventarioSolicitado;

        /// <summary>Se produce cuando el usuario solicita registrar una entrada.</summary>
        event EventHandler? EntradaInventarioSolicitada;

        /// <summary>Se produce cuando el usuario solicita registrar una salida.</summary>
        event EventHandler? SalidaInventarioSolicitada;

        /// <summary>Se produce cuando el usuario solicita realizar un ajuste.</summary>
        event EventHandler? AjusteInventarioSolicitado;

        /// <summary>Se produce cuando el usuario solicita registrar una pérdida.</summary>
        event EventHandler? PerdidaInventarioSolicitada;
    }
}
