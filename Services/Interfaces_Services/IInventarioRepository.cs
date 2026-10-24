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
        /// Obtiene los lotes con saldo que vencen mañana, vencen hoy
        /// o ya han vencido.
        /// </summary>
        IReadOnlyList<AlertaVencimientoInventarioDto> ObtenerAlertasVencimiento();

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
        /// Obtiene las unidades de medida activas para el formulario de entrada.
        /// </summary>
        IReadOnlyList<UnidadMedidaDto> ObtenerUnidadesMedidaActivas();

        /// <summary>
        /// Obtiene los ingredientes existentes que pueden seleccionarse
        /// durante el registro de una entrada.
        /// </summary>
        IReadOnlyList<IngredienteSelectorDto> ObtenerIngredientesParaEntrada();

        /// <summary>
        /// Propone el siguiente código disponible para un ingrediente nuevo.
        /// </summary>
        string? ObtenerSiguienteCodigoIngrediente();

        /// <summary>
        /// Registra una entrada para un ingrediente existente o crea uno nuevo.
        /// </summary>
        ResultadoEntradaIngredienteDto RegistrarEntradaIngrediente(
            SolicitudEntradaIngredienteDto solicitud);


        /// <summary>
        /// Registra una entrada, salida, ajuste o pérdida de inventario.
        /// Debe actualizar el saldo, gestionar los lotes cuando corresponda
        /// y registrar los movimientos dentro de una transacción.
        /// </summary>
        ResultadoOperacionDto RegistrarMovimiento(SolicitudMovimientoInventarioDto solicitud);
    }
}
