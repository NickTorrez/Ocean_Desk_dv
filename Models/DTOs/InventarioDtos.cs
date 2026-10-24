using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Models.DTOs
{
    /// <summary>
    /// Identifica los tipos de movimiento almacenados en la base de datos.
    /// Los textos de presentación en español se manejarán por separado.
    /// </summary>
    public static class TiposMovimientoInventario
    {
        public const string Entrada = "Entry";
        public const string Salida = "Exit";
        public const string Ajuste = "Adjustment";
        public const string Perdida = "Loss";
        public const string Compra = "Purchase";
        public const string Venta = "Sale";
    }

    /// <summary>
    /// Filtros utilizados para consultar las existencias de inventario.
    /// </summary>
    public sealed class FiltroExistenciasInventarioDto
    {
        public string? TextoBusqueda { get; init; }
        public string? Categoria { get; init; }
        public string? EstadoStock { get; init; }
        public string? EstadoVencimiento { get; init; }
    }

    /// <summary>
    /// Filtros utilizados para consultar el historial de movimientos.
    /// </summary>
    public sealed class FiltroMovimientosInventarioDto
    {
        public DateTime Desde { get; init; }
        public DateTime Hasta { get; init; }
        public string? TipoMovimiento { get; init; }
        public string? TextoBusqueda { get; init; }
    }

    /// <summary>
    /// Datos de una existencia preparados para mostrarse en la tabla del inventario.
    /// </summary>
    public sealed class ExistenciaInventarioDto
    {
        public int ProductId { get; init; }
        public string ProductCode { get; init; } = string.Empty;
        public string ProductName { get; init; } = string.Empty;
        public string CategoryName { get; init; } = string.Empty;
        public string UnitName { get; init; } = string.Empty;

        public decimal CurrentStock { get; init; }
        public decimal MinimumStock { get; init; }

        /// <summary>
        /// Valores previstos para presentación: Normal, Bajo o Agotado.
        /// </summary>
        public string StockStatus { get; init; } = string.Empty;

        /// <summary>
        /// Vencimiento más próximo entre los lotes activos con saldo.
        /// Es null si no hay una fecha de vencimiento conocida.
        /// </summary>
        public DateOnly? ExpirationDate { get; init; }

        /// <summary>
        /// Valores de presentación: Sin fecha, Normal, Próximo a vencer o Vencido.
        /// </summary>
        public string ExpirationStatus { get; init; } = string.Empty;
    }

    /// <summary>
    /// Producto ingrediente que puede seleccionarse para registrar un movimiento.
    /// </summary>
    public sealed class ProductoInventarioSelectorDto
    {
        public int ProductId { get; init; }
        public string ProductCode { get; init; } = string.Empty;
        public string ProductName { get; init; } = string.Empty;
        public string UnitName { get; init; } = string.Empty;

        public string TextoMostrar =>
            $"{ProductCode} - {ProductName} ({UnitName})";
    }

    /// <summary>
    /// Movimiento de inventario preparado para mostrarse en el historial.
    /// </summary>
    public sealed class MovimientoInventarioDto
    {
        public long InventoryMovementId { get; init; }
        public DateTime MovementDateTime { get; init; }

        /// <summary>
        /// Tipo presentado en español, como Entrada, Salida o Venta.
        /// </summary>
        public string MovementType { get; init; } = string.Empty;

        public string ProductName { get; init; } = string.Empty;
        public decimal Quantity { get; init; }
        public string UnitName { get; init; } = string.Empty;
        public string Source { get; init; } = string.Empty;
        public string? LotCode { get; init; }
        public string? Notes { get; init; }

        public decimal StockBefore { get; init; }
        public decimal StockAfter { get; init; }
    }

    /// <summary>
    /// Solicitud para registrar una operación de inventario.
    /// No representa directamente una entidad de SQL Server.
    /// </summary>
    public sealed class SolicitudMovimientoInventarioDto
    {
        public int ProductId { get; init; }

        /// <summary>
        /// Tipo estable de la operación, definido en TiposMovimientoInventario.
        /// </summary>
        public string MovementType { get; init; } = string.Empty;

        /// <summary>
        /// Para entradas, salidas y pérdidas representa la cantidad del movimiento.
        /// Para un ajuste representa el stock final deseado.
        /// </summary>
        public decimal Quantity { get; init; }

        public decimal? MinimumStock { get; init; }

        public string? LotCode { get; init; }
        public DateOnly? ExpirationDate { get; init; }
        public string? Notes { get; init; }
    }


    /// <summary>
    /// Datos capturados para registrar una entrada de inventario.
    /// ProductId es null cuando se debe crear un ingrediente nuevo.
    /// </summary>
    public sealed class SolicitudEntradaIngredienteDto
    {
        public int? ProductId { get; init; }

        public string ProductName { get; init; } = string.Empty;

        public int UnitOfMeasureId { get; init; }

        public decimal Quantity { get; init; }

        public decimal MinimumStock { get; init; }

        public DateOnly? ExpirationDate { get; init; }

        public string? Notes { get; init; }
    }

    /// <summary>
    /// Resultado de registrar una entrada para un ingrediente nuevo o existente.
    /// </summary>
    public sealed class ResultadoEntradaIngredienteDto
    {
        public bool Exito { get; init; }

        public string Mensaje { get; init; } = string.Empty;

        public int? ProductId { get; init; }

        public string? ProductCode { get; init; }

        public static ResultadoEntradaIngredienteDto Correcto(
            string mensaje,
            int productoId,
            string codigo)
        {
            return new ResultadoEntradaIngredienteDto
            {
                Exito = true,
                Mensaje = mensaje,
                ProductId = productoId,
                ProductCode = codigo
            };
        }

        public static ResultadoEntradaIngredienteDto Fallido(
            string mensaje)
        {
            return new ResultadoEntradaIngredienteDto
            {
                Exito = false,
                Mensaje = mensaje
            };
        }
    }

}
