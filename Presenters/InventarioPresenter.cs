using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Services.Interfaces_Services;
using Ocean_Desk_dv.View.Interfaces;
using Ocean_Desk_dv.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Presenters
{
    /// <summary>
    /// Coordina los eventos de FrmInventario con las operaciones del repositorio.
    /// No accede directamente a controles WinForms ni a SQL Server.
    /// </summary>
    public sealed class InventarioPresenter:IDisposable
    {
        private readonly IInventarioView _view;
        private readonly IInventarioRepository _repository;
        private bool _disposed;

        /// <summary>
        /// Crea el Presenter y conecta los eventos de la vista.
        /// </summary>
        public InventarioPresenter(
            IInventarioView view,
            IInventarioRepository repository)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));

            SuscribirEventos();
        }

        /// <summary>
        /// Carga los datos iniciales del inventario.
        /// </summary>
        public void Inicializar()
        {
            EjecutarSeguro(() =>
            {
                _view.MostrarCategoriasInventario(
                    _repository.ObtenerCategoriasInventario());

                ActualizarDatos();
            });
        }

        /// <summary>
        /// Conecta los eventos definidos por el contrato de la vista.
        /// </summary>
        private void SuscribirEventos()
        {
            _view.FiltrosExistenciasCambiados +=
                AlCambiarFiltrosExistencias;

            _view.FiltrosMovimientosCambiados +=
                AlCambiarFiltrosMovimientos;

            _view.RefrescarInventarioSolicitado +=
                AlSolicitarRefrescar;

            _view.EntradaInventarioSolicitada +=
                AlSolicitarEntrada;

            _view.SalidaInventarioSolicitada +=
                AlSolicitarSalida;

            _view.AjusteInventarioSolicitado +=
                AlSolicitarAjuste;

            _view.PerdidaInventarioSolicitada +=
                AlSolicitarPerdida;
        }

        /// <summary>
        /// Actualiza las existencias y el historial conforme a los filtros vigentes.
        /// </summary>
        private void ActualizarDatos()
        {
            _view.MostrarExistencias(
                _repository.ObtenerExistencias(
                    _view.FiltroExistenciasActual));

            _view.MostrarMovimientos(
                _repository.ObtenerMovimientos(
                    _view.FiltroMovimientosActual));
        }

        /// <summary>
        /// Actualiza la tabla cuando cambian los filtros de existencias.
        /// </summary>
        private void AlCambiarFiltrosExistencias(
            object? sender,
            EventArgs e)
        {
            EjecutarSeguro(() =>
            {
                _view.MostrarExistencias(
                    _repository.ObtenerExistencias(
                        _view.FiltroExistenciasActual));
            });
        }

        /// <summary>
        /// Actualiza el historial cuando cambian el intervalo o el tipo de movimiento.
        /// </summary>
        private void AlCambiarFiltrosMovimientos(
            object? sender,
            EventArgs e)
        {
            EjecutarSeguro(() =>
            {
                _view.MostrarMovimientos(
                    _repository.ObtenerMovimientos(
                        _view.FiltroMovimientosActual));
            });
        }

        /// <summary>
        /// Recarga las categorías, las existencias y los movimientos.
        /// </summary>
        private void AlSolicitarRefrescar(
            object? sender,
            EventArgs e)
        {
            Inicializar();
        }

        private void AlSolicitarEntrada(object? sender, EventArgs e) =>
            RegistrarEntradaIngrediente();

        private void AlSolicitarSalida(object? sender, EventArgs e) =>
            SolicitarMovimiento(TiposMovimientoInventario.Salida);

        private void AlSolicitarAjuste(object? sender, EventArgs e) =>
            SolicitarMovimiento(TiposMovimientoInventario.Ajuste);

        private void AlSolicitarPerdida(object? sender, EventArgs e) =>
            SolicitarMovimiento(TiposMovimientoInventario.Perdida);

        /// <summary>
        /// Gestiona el flujo independiente de entrada de ingredientes.
        /// </summary>
        private void RegistrarEntradaIngrediente()
        {
            EjecutarSeguro(() =>
            {
                IReadOnlyList<UnidadMedidaDto> unidades =
                    _repository.ObtenerUnidadesMedidaActivas();

                if (unidades.Count == 0)
                {
                    _view.MostrarMensaje(
                        "No hay unidades de medida activas disponibles.",
                        "Unidades no disponibles",
                        true);

                    return;
                }

                IReadOnlyList<IngredienteSelectorDto> ingredientes =
                    _repository.ObtenerIngredientesParaEntrada();

                string? codigoPropuesto =
                    _repository.ObtenerSiguienteCodigoIngrediente();

                SolicitudEntradaIngredienteDto? captura =
                    _view.SolicitarEntradaIngrediente(
                        ingredientes,
                        unidades,
                        codigoPropuesto);

                if (captura is null)
                    return;

                ResultadoEntradaIngredienteDto resultado =
                    _repository.RegistrarEntradaIngrediente(captura);

                _view.MostrarMensaje(
                    resultado.Mensaje,
                    resultado.Exito
                        ? "Entrada de inventario registrada"
                        : "No se pudo registrar la entrada",
                    !resultado.Exito);

                if (resultado.Exito)
                    ActualizarDatos();
            });
        }

        /// <summary>
        /// Solicita al usuario un movimiento sobre el ingrediente seleccionado,
        /// comprueba que pueda recibir movimientos y registra la operación.
        /// </summary>
        private void SolicitarMovimiento(string tipoMovimiento)
        {
            EjecutarSeguro(() =>
            {
                // La operación se realiza sobre la fila seleccionada en existencias.
                ExistenciaInventarioDto? producto =
                    _view.ExistenciaSeleccionada;

                // No se permiten movimientos manuales sobre ingredientes que
                // carecen de una unidad de medida activa.
                if (producto is not null)
                {
                    bool ingredienteHabilitado =
                        _repository
                            .ObtenerIngredientesActivosParaMovimiento()
                            .Any(p => p.ProductId == producto.ProductId);

                    if (!ingredienteHabilitado)
                    {
                        _view.MostrarMensaje(
                            "El ingrediente seleccionado no tiene una unidad " +
                            "de medida activa. Revise su configuración antes " +
                            "de registrar movimientos.",
                            "Ingrediente no disponible",
                            true);

                        return;
                    }
                }

                // La vista advierte al usuario si no seleccionó una fila.
                SolicitudMovimientoInventarioDto? captura =
                    _view.SolicitarMovimiento(tipoMovimiento, producto);

                // Cerrar o cancelar el diálogo no modifica las existencias.
                if (captura is null)
                    return;

                // El tipo se determina a partir del botón que originó la operación.
                var solicitud = new SolicitudMovimientoInventarioDto
                {
                    ProductId = captura.ProductId,
                    MovementType = tipoMovimiento,
                    Quantity = captura.Quantity,
                    LotCode = captura.LotCode,
                    ExpirationDate = captura.ExpirationDate,
                    Notes = captura.Notes
                };

                ResultadoOperacionDto resultado =
                    _repository.RegistrarMovimiento(solicitud);

                _view.MostrarMensaje(
                    resultado.Mensaje,
                    resultado.Exito
                        ? "Inventario actualizado"
                        : "No se pudo registrar el movimiento",
                    !resultado.Exito);

                // Las tablas se recargan solamente tras un registro exitoso.
                if (resultado.Exito)
                    ActualizarDatos();
            });
        }

        /// <summary>
        /// Ejecuta una acción y presenta sus errores sin interrumpir la aplicación.
        /// </summary>
        private void EjecutarSeguro(Action accion)
        {
            try
            {
                accion();
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    $"No se pudo completar la operación. Detalle: {ex.Message}",
                    "Error en Inventario",
                    true);
            }
        }

        /// <summary>
        /// Desconecta los eventos y libera el repositorio.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
                return;

            _view.FiltrosExistenciasCambiados -=
                AlCambiarFiltrosExistencias;

            _view.FiltrosMovimientosCambiados -=
                AlCambiarFiltrosMovimientos;

            _view.RefrescarInventarioSolicitado -=
                AlSolicitarRefrescar;

            _view.EntradaInventarioSolicitada -=
                AlSolicitarEntrada;

            _view.SalidaInventarioSolicitada -=
                AlSolicitarSalida;

            _view.AjusteInventarioSolicitado -=
                AlSolicitarAjuste;

            _view.PerdidaInventarioSolicitada -=
                AlSolicitarPerdida;

            _repository.Dispose();
            _disposed = true;
        }
    }
}
