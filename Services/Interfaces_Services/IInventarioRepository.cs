using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.Services.Interfaces_Services
{
    /// <summary>
    /// Define las operaciones de acceso a datos del módulo Inventario.
    /// El Presenter depende de este contrato, no de la implementación concreta.
    /// </summary>
    public interface IInventarioRepository : IDisposable
    {
        /// <summary>
        /// Consulta existencias aplicando los filtros solicitados.
        /// </summary>
        IReadOnlyList<ExistenciaInventarioDto> ObtenerExistencias(FiltroExistenciasInventarioDto filtro);

        /// <summary>
        /// Consulta el historial de movimientos dentro del periodo indicado.
        /// </summary>
        IReadOnlyList<MovimientoInventarioDto> ObtenerMovimientos(FiltroMovimientosInventarioDto filtro);

        /// <summary>
        /// Obtiene los nombres de categorías disponibles para filtrar existencias.
        /// </summary>
        IReadOnlyList<string> ObtenerCategoriasInventario();

        /// <summary>
        /// Obtiene los ingredientes activos que pueden recibir movimientos.
        /// </summary>
        IReadOnlyList<ProductoInventarioSelectorDto>ObtenerIngredientesActivosParaMovimiento();

        /// <summary>
        /// Registra una entrada, salida, ajuste o pérdida de inventario.
        /// Debe actualizar el saldo, gestionar los lotes cuando corresponda
        /// y registrar los movimientos dentro de una transacción.
        /// </summary>
        ResultadoOperacionDto RegistrarMovimiento(SolicitudMovimientoInventarioDto solicitud);
    }
}
