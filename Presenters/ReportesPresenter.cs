using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.View.Interfaces;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Services.Interfaces_Services;
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
        private readonly IReportesRepository _repository;
        private bool _disposed;

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia del Presenter de Reportes.
        /// </summary>
        /// <param name="view">Vista que implementa IReportesView.</param>
        public ReportesPresenter(IReportesView view, IReportesRepository repository)
        {
            _view = view ??
            throw new ArgumentNullException(nameof(view));

            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));

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
            DateTime hastaExclusivo =
                _view.FechaHasta.Date.AddDays(1);

            ReporteIndicadoresDto indicadores =
                _repository.ObtenerIndicadores(
                    desde,
                    hastaExclusivo);

            bool esHoy =
                desde == DateTime.Today &&
                hastaExclusivo == DateTime.Today.AddDays(1);

            _view.MostrarVentas(
                indicadores.CantidadVentas,
                esHoy);

            _view.MostrarIngresos(indicadores.Ingresos);

            _view.MostrarProductosRegistrados(
                indicadores.ProductosRegistrados);

            // El inventario representa el estado actual, no un
            // valor histórico condicionado por el período de ventas.
            ReporteStockInventarioDto stock =
                _repository.ObtenerResumenStockInventario();

            _view.MostrarStockBajo(
                stock.IngredientesBajoMinimo,
                stock.IngredientesAgotados);

            // La actividad operativa siempre corresponde a hoy,
            // aunque el usuario seleccione otro período de ventas.
            DateTime hoy = DateTime.Today;

            ReporteActividadInventarioDto actividad =
                _repository.ObtenerActividadInventario(
                    hoy,
                    hoy.AddDays(1),
                    5);

            _view.MostrarActividadInventario(actividad);
        }
        #endregion

        #region Gráficos
        /// <summary>
        /// Consulta los datos necesarios para ambos gráficos.
        /// </summary>
        private void MostrarGraficos()
        {
            DateTime desde = _view.FechaDesde.Date;

            DateTime hastaExclusivo =
                _view.FechaHasta.Date.AddDays(1);

            List<EvolucionVentaReporte> evolucionVentas =
                _repository
                    .ObtenerEvolucionVentas(desde, hastaExclusivo)
                    .Select(x => new EvolucionVentaReporte
                    {
                        Fecha = x.Fecha,
                        Total = x.Total
                    })
                    .ToList();

            List<ProductoVendidoReporte> productosMasVendidos =
                _repository
                    .ObtenerProductosMasVendidos(
                        desde,
                        hastaExclusivo,
                        5)
                    .Select(x => new ProductoVendidoReporte
                    {
                        Producto = x.Producto,
                        Cantidad = x.Cantidad
                    })
                    .ToList();

            _view.MostrarEvolucionVentas(evolucionVentas);

            _view.MostrarProductosMasVendidos(
                productosMasVendidos);
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
            _repository.Dispose();

            _disposed = true;
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
