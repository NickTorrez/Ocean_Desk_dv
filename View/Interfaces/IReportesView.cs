using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.View.Interfaces
{
    public interface IReportesView
    {
        #region Filtros
        /// <summary>
        /// Período seleccionado en el filtro principal.
        /// </summary>
        string PeriodoSeleccionado { get; set; }

        /// <summary>
        /// Fecha inicial del rango de consulta.
        /// </summary>
        DateTime FechaDesde { get; set; }

        /// <summary>
        /// Fecha final del rango de consulta.
        /// </summary>
        DateTime FechaHasta { get; set; }

        /// <summary>
        /// Se dispara cuando el usuario cambia el período.
        /// </summary>
        event EventHandler? PeriodoChanged;

        /// <summary>
        /// Se dispara cuando el usuario solicita actualizar los reportes.
        /// </summary>
        event EventHandler? ActualizarClicked;
        #endregion

        #region Indicadores
        /// <summary>
        /// Muestra la cantidad de ventas completadas del período.
        /// </summary>
        void MostrarVentas(int cantidadVentas, bool esHoy);

        /// <summary>
        /// Muestra el total de ingresos del período.
        /// </summary>
        void MostrarIngresos(decimal ingresos);

        /// <summary>
        /// Muestra la cantidad de productos activos registrados.
        /// </summary>
        void MostrarProductosRegistrados(int cantidadProductos);

        /// <summary>
        /// Muestra el estado del indicador de stock bajo.
        /// Actualmente se muestra como no disponible porque el modelo
        /// de productos todavía no contiene información de existencias.
        /// </summary>
        void MostrarStockBajoNoDisponible();
        #endregion

        #region Gráficos
        /// <summary>
        /// Actualiza los datos del gráfico de evolución de ventas.
        /// </summary>
        void MostrarEvolucionVentas(List<EvolucionVentaReporte> datos);

        /// <summary>
        /// Actualiza los datos del gráfico de productos más vendidos.
        /// </summary>
        void MostrarProductosMasVendidos(List<ProductoVendidoReporte> datos);
        #endregion

        #region Mensajes
        /// <summary>
        /// Muestra un mensaje informativo o de error al usuario.
        /// </summary>
        void MostrarMensaje(string mensaje, string titulo = "Reportes", bool esError = false);
        #endregion
    }

    /// <summary>
    /// Dato utilizado por el gráfico de evolución de ventas.
    /// </summary>
    public class EvolucionVentaReporte
    {
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
    }

    /// <summary>
    /// Dato utilizado por el gráfico de productos más vendidos.
    /// </summary>
    public class ProductoVendidoReporte
    {
        public string Producto { get; set; } = string.Empty;
        public decimal Cantidad { get; set; }
    }
}
