using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Presenters
{
    /// <summary>
    /// Presenter responsable de la lógica de consulta y presentación
    /// del módulo de Reportes.
    ///
    /// El módulo no posee una tabla propia en la base de datos. Los reportes
    /// se construyen a partir de la información existente en Sales,
    /// SaleDetails y Products.
    /// </summary>
    public class ReportesPresenter : IDisposable
    {
        private readonly IReportesView _view;
        private readonly OceanDeskDbContext _context;
        private bool _disposed;

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia del Presenter de Reportes.
        /// </summary>
        /// <param name="view">Vista que implementa IReportesView.</param>
        public ReportesPresenter(IReportesView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _context = new OceanDeskDbContext();

            _view.PeriodoChanged += OnPeriodoChanged;
            _view.ActualizarClicked += OnActualizarClicked;
        }
        #endregion

        #region Inicialización
        /// <summary>
        /// Configura el período inicial y carga los datos reales
        /// disponibles en la base de datos.
        /// </summary>
        public void Inicializar()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_view.PeriodoSeleccionado))
                    _view.PeriodoSeleccionado = "Hoy";

                AplicarPeriodoSeleccionado();
                ActualizarReportes();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }
        #endregion

        #region Eventos de la Vista
        /// <summary>
        /// Recalcula las fechas del filtro cuando el usuario cambia el período.
        /// </summary>
        private void OnPeriodoChanged(object? sender, EventArgs e)
        {
            try
            {
                AplicarPeriodoSeleccionado();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        /// <summary>
        /// Ejecuta nuevamente las consultas cuando el usuario pulsa Actualizar.
        /// </summary>
        private void OnActualizarClicked(object? sender, EventArgs e)
        {
            try
            {
                ValidarRangoFechas();
                ActualizarReportes();
            }
            catch (ArgumentException ex)
            {
                _view.MostrarMensaje(ex.Message, "Rango de fechas", true);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }
        #endregion

        #region Filtros
        /// <summary>
        /// Establece Desde y Hasta de acuerdo con el período seleccionado.
        /// </summary>
        private void AplicarPeriodoSeleccionado()
        {
            DateTime hoy = DateTime.Today;

            switch (_view.PeriodoSeleccionado)
            {
                case "Hoy":
                    _view.FechaDesde = hoy;
                    _view.FechaHasta = hoy;
                    break;

                case "Últimos 7 días":
                    _view.FechaDesde = hoy.AddDays(-6);
                    _view.FechaHasta = hoy;
                    break;

                case "Este mes":
                    _view.FechaDesde = new DateTime(hoy.Year, hoy.Month, 1);
                    _view.FechaHasta = hoy;
                    break;

                case "Este año":
                    _view.FechaDesde = new DateTime(hoy.Year, 1, 1);
                    _view.FechaHasta = hoy;
                    break;

                case "Personalizado":
                    // En este caso el usuario controla directamente las fechas.
                    break;

                default:
                    _view.PeriodoSeleccionado = "Hoy";
                    _view.FechaDesde = hoy;
                    _view.FechaHasta = hoy;
                    break;
            }
        }

        /// <summary>
        /// Valida que el rango de fechas seleccionado sea coherente.
        /// </summary>
        private void ValidarRangoFechas()
        {
            if (_view.FechaDesde.Date > _view.FechaHasta.Date)
            {
                throw new ArgumentException(
                    "La fecha Desde no puede ser posterior a la fecha Hasta.");
            }
        }
        #endregion

        #region Actualización General
        /// <summary>
        /// Ejecuta todas las consultas necesarias para refrescar el formulario.
        /// </summary>
        private void ActualizarReportes()
        {
            ValidarRangoFechas();

            MostrarIndicadores();
            MostrarGraficos();
        }
        #endregion

        #region Indicadores
        /// <summary>
        /// Consulta y muestra los indicadores superiores del reporte.
        /// </summary>
        private void MostrarIndicadores()
        {
            DateTime desde = _view.FechaDesde.Date;
            DateTime hastaExclusivo = _view.FechaHasta.Date.AddDays(1);

            var ventasPeriodo = _context.Sales
                .AsNoTracking()
                .Where(s =>
                    s.Status == "Completed" &&
                    s.SaleDateTime >= desde &&
                    s.SaleDateTime < hastaExclusivo);

            int cantidadVentas = ventasPeriodo.Count();
            decimal ingresos = ventasPeriodo.Sum(s => (decimal?)s.Total) ?? 0m;

            int productosRegistrados = _context.Products
                .AsNoTracking()
                .Count(p => p.IsActive);

            bool esHoy = desde.Date == DateTime.Today && hastaExclusivo.Date == DateTime.Today.AddDays(1);

            _view.MostrarVentas(cantidadVentas, esHoy);
            _view.MostrarIngresos(ingresos);
            _view.MostrarProductosRegistrados(productosRegistrados);

            // El modelo actual de Product no contiene una cantidad de existencias,
            // por lo que todavía no es posible calcular Stock bajo sin inventar datos.
            _view.MostrarStockBajoNoDisponible();
        }
        #endregion

        #region Gráficos
        /// <summary>
        /// Consulta los datos necesarios para ambos gráficos.
        /// </summary>
        private void MostrarGraficos()
        {
            DateTime desde = _view.FechaDesde.Date;
            DateTime hastaExclusivo = _view.FechaHasta.Date.AddDays(1);

            var ventas = _context.Sales
                .AsNoTracking()
                .Where(s =>
                    s.Status == "Completed" &&
                    s.SaleDateTime >= desde &&
                    s.SaleDateTime < hastaExclusivo);

            var evolucionVentas = ventas
                .GroupBy(s => s.SaleDateTime.Date)
                .Select(g => new EvolucionVentaReporte
                {
                    Fecha = g.Key,
                    Total = g.Sum(s => s.Total)
                })
                .OrderBy(x => x.Fecha)
                .ToList();

            var productosMasVendidos = _context.SaleDetails
                .AsNoTracking()
                .Where(d =>
                    d.Sale.Status == "Completed" &&
                    d.Sale.SaleDateTime >= desde &&
                    d.Sale.SaleDateTime < hastaExclusivo)
                .GroupBy(d => new
                {
                    d.ProductId,
                    d.Product.ProductName
                })
                .Select(g => new ProductoVendidoReporte
                {
                    Producto = g.Key.ProductName,
                    Cantidad = g.Sum(d => d.Quantity)
                })
                .OrderByDescending(x => x.Cantidad)
                .ThenBy(x => x.Producto)
                .Take(5)
                .ToList();

            _view.MostrarEvolucionVentas(evolucionVentas);
            _view.MostrarProductosMasVendidos(productosMasVendidos);
        }
        #endregion

        #region Manejo de Errores
        /// <summary>
        /// Muestra un error de operación al usuario sin exponer información innecesaria.
        /// </summary>
        private void MostrarError(Exception ex)
        {
            _view.MostrarMensaje(
                "No fue posible cargar los reportes.\n\n" + ex.Message,
                "Error",
                true);
        }
        #endregion

        #region Liberación de Recursos
        /// <summary>
        /// Libera las suscripciones a eventos y el contexto de datos.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
                return;

            _view.PeriodoChanged -= OnPeriodoChanged;
            _view.ActualizarClicked -= OnActualizarClicked;
            _context.Dispose();

            _disposed = true;
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
