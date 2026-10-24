using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Services.Interfaces_Services;
using Ocean_Desk_dv.Services.Repository;
using Ocean_Desk_dv.View.Interfaces;
using Ocean_Desk_dv.View.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        /// Consulta las existencias usando los filtros aplicados.
        /// La búsqueda por nombre se resuelve en la vista para admitir
        /// los nombres traducidos que ve el usuario.
        /// </summary>
        private void ActualizarDatos()
        {
            ActualizarExistencias();

            _view.MostrarMovimientos(
                _repository.ObtenerMovimientos(
                    _view.FiltroMovimientosActual));
        }

        /// <summary>
        /// Consulta las existencias sin filtrar por texto en el repositorio.
        /// La vista aplica después la búsqueda sobre el nombre original
        /// y sobre el nombre traducido que se presenta al usuario.
        /// </summary>
        private void ActualizarExistencias()
        {
            FiltroExistenciasInventarioDto filtros =
                _view.FiltroExistenciasActual;

            var filtrosRepositorio = new FiltroExistenciasInventarioDto
            {
                TextoBusqueda = null,
                Categoria = filtros.Categoria,
                EstadoStock = filtros.EstadoStock,
                EstadoVencimiento = filtros.EstadoVencimiento
            };

            _view.MostrarExistencias(
                _repository.ObtenerExistencias(filtrosRepositorio));
        }

        /// <summary>
        /// Actualiza existencias si otro flujo solicita expresamente
        /// un cambio de filtros.
        /// </summary>
        private void AlCambiarFiltrosExistencias(
            object? sender,
            EventArgs e)
        {
            EjecutarSeguro(ActualizarExistencias);
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

                // Abrir el formulario y recuperar los datos capturados.
                SolicitudEntradaIngredienteDto? captura =
                    _view.SolicitarEntradaIngrediente(
                        ingredientes,
                        unidades,
                        codigoPropuesto);

                // Si el usuario cancela, no se registra ninguna operación.
                if (captura is null)
                    return;

                ResultadoEntradaIngredienteDto resultado =
                    _repository.RegistrarEntradaIngrediente(captura);

                string mensajeResultado = resultado.Mensaje;

                if (resultado.Exito)
                {
                    IngredienteSelectorDto? existente =
                        captura.ProductId.HasValue
                            ? ingredientes.FirstOrDefault(i =>
                                i.ProductId == captura.ProductId.Value)
                            : null;

                    string nombrePresentacion = existente is not null
                        ? CatalogoTraducciones.TraducirIngrediente(
                            existente.ProductCode,
                            existente.ProductName)
                        : captura.ProductId.HasValue
                            ? CatalogoTraducciones.TraducirIngrediente(
                                resultado.ProductCode,
                                captura.ProductName)
                            : captura.ProductName;

                    UnidadMedidaDto? unidad =
                        unidades.FirstOrDefault(u =>
                            u.UnitOfMeasureId == captura.UnitOfMeasureId);

                    string unidadPresentacion = unidad is null
                        ? string.Empty
                        : CatalogoTraducciones.TraducirUnidad(
                            unidad.UnitCode,
                            unidad.UnitName);

                    if (captura.ProductId.HasValue)
                    {
                        mensajeResultado =
                            $"Entrada registrada correctamente para " +
                            $"{nombrePresentacion} ({resultado.ProductCode}).\n" +
                            $"Cantidad añadida: {captura.Quantity:0.####} " +
                            $"\nStock mínimo configurado: " +
                            $"{captura.MinimumStock:0.####} {unidadPresentacion}.";
                    }
                    else
                    {
                        mensajeResultado =
                            $"Ingrediente {nombrePresentacion} registrado " +
                            $"correctamente con código {resultado.ProductCode}.\n" +
                            $"Stock inicial: {captura.Quantity:0.####} " +
                            $"\nStock mínimo configurado: " +
                            $"{captura.MinimumStock:0.####} {unidadPresentacion}.";
                    }
                }

                _view.MostrarMensaje(
                    mensajeResultado,
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
                    MinimumStock = captura.MinimumStock,
                    LotCode = captura.LotCode,
                    ExpirationDate = captura.ExpirationDate,
                    Notes = captura.Notes
                };

                bool ajusteSoloStockMinimo =
                    tipoMovimiento == TiposMovimientoInventario.Ajuste &&
                    producto is not null &&
                    solicitud.Quantity == producto.CurrentStock &&
                    solicitud.MinimumStock.HasValue &&
                    solicitud.MinimumStock.Value != producto.MinimumStock;

                ResultadoOperacionDto resultado =
                    _repository.RegistrarMovimiento(solicitud);

                string mensajeResultado = resultado.Mensaje;


                if (resultado.Exito && producto is not null)
                {
                    string nombrePresentacion =
                        CatalogoTraducciones.TraducirIngrediente(
                            producto.ProductCode,
                            producto.ProductName);

                    string unidadPresentacion =
                        CatalogoTraducciones.TraducirUnidad(
                            null,
                            producto.UnitName);

                    if (ajusteSoloStockMinimo)
                    {
                        mensajeResultado =
                            $"Stock mínimo actualizado correctamente para " +
                            $"{nombrePresentacion} ({producto.ProductCode}).\n" +
                            $"Stock actual: {producto.CurrentStock:0.####} " +
                            $"{unidadPresentacion}.\n" +
                            $"Stock mínimo anterior: " +
                            $"{producto.MinimumStock:0.####} " +
                            $"{unidadPresentacion}.\n" +
                            $"Nuevo stock mínimo: " +
                            $"{solicitud.MinimumStock!.Value:0.####} " +
                            $"{unidadPresentacion}.\n" +
                            "No se modificaron las existencias ni los lotes.";
                    }
                    else
                    {
                        decimal stockPosterior =
                            tipoMovimiento == TiposMovimientoInventario.Ajuste
                                ? solicitud.Quantity
                                : producto.CurrentStock - solicitud.Quantity;

                        string tituloMovimiento = tipoMovimiento switch
                        {
                            TiposMovimientoInventario.Ajuste => "Ajuste",
                            TiposMovimientoInventario.Salida => "Salida",
                            TiposMovimientoInventario.Perdida => "Pérdida o daño",
                            _ => "Movimiento"
                        };

                        mensajeResultado =
                            $"{tituloMovimiento} registrado correctamente para " +
                            $"{nombrePresentacion}.\n" +
                            $"Stock anterior: {producto.CurrentStock:0.####} " +
                            $"{unidadPresentacion}.\n" +
                            $"Stock actual: {stockPosterior:0.####} " +
                            $"{unidadPresentacion}.";

                        if (tipoMovimiento == TiposMovimientoInventario.Ajuste &&
                            solicitud.MinimumStock.HasValue &&
                            solicitud.MinimumStock.Value != producto.MinimumStock)
                        {
                            mensajeResultado +=
                                $"\nStock mínimo actualizado: " +
                                $"{solicitud.MinimumStock.Value:0.####} " +
                                $"{unidadPresentacion}.";
                        }

                        if (tipoMovimiento == TiposMovimientoInventario.Ajuste &&
                            solicitud.Quantity > producto.CurrentStock &&
                            solicitud.ExpirationDate.HasValue)
                        {
                            mensajeResultado +=
                                $"\nEl lote incorporado tiene vencimiento " +
                                $"{solicitud.ExpirationDate.Value:dd/MM/yyyy}.";

                            if (producto.ExpirationDate.HasValue)
                            {
                                mensajeResultado +=
                                    $" El lote anterior conserva el vencimiento " +
                                    $"{producto.ExpirationDate.Value:dd/MM/yyyy}.";
                            }

                            mensajeResultado +=
                                "\nLa tabla muestra el vencimiento más próximo " +
                                "entre los lotes que todavía tienen saldo.";
                        }
                    }
                }


                _view.MostrarMensaje(
                     mensajeResultado,
                     resultado.Exito
                        ? (ajusteSoloStockMinimo
                            ? "Stock mínimo actualizado"
                            : "Inventario actualizado")
                        : "No se registra movimiento",
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

            _view.FiltrosExistenciasCambiados -= AlCambiarFiltrosExistencias;

            _view.FiltrosMovimientosCambiados -= AlCambiarFiltrosMovimientos;

            _view.RefrescarInventarioSolicitado -= AlSolicitarRefrescar;

            _view.EntradaInventarioSolicitada -= AlSolicitarEntrada;

            _view.SalidaInventarioSolicitada -= AlSolicitarSalida;

            _view.AjusteInventarioSolicitado -= AlSolicitarAjuste;

            _view.PerdidaInventarioSolicitada -= AlSolicitarPerdida;

            _repository.Dispose();
            _disposed = true;
        }
    }
}
