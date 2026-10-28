using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.UI.Models;
using Ocean_Desk_dv.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Presenters
{
    /// <summary>
    /// Presenter responsable de la lógica de negocio del módulo de Caja.
    /// Administra apertura, movimientos, sincronización de ventas y cierre de caja.
    /// </summary>
    public class CajaPresenter : IDisposable
    {
        private readonly ICajaView _view;
        private readonly ICajaRepository _repository;
        private CashRegisterDto? _cajaActual;
        private bool _disposed;

        public CajaPresenter(ICajaView view, ICajaRepository repository)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));

            _view.AbrirCajaClicked += OnAbrirCajaClicked;
            _view.CerrarCajaClicked += OnCerrarCajaClicked;
            _view.RegistrarIngresoClicked += OnRegistrarIngresoClicked;
            _view.RegistrarEgresoClicked += OnRegistrarEgresoClicked;
        }

        /// <summary>
        /// Carga la caja abierta, sincroniza las ventas pendientes
        /// de registrar en Caja y muestra el último cierre.
        /// </summary>
        public void Inicializar()
        {
            try
            {
                _cajaActual =
                    _repository.ObtenerCajaAbiertaMasReciente();

                if (_cajaActual != null)
                    SincronizarVentasCompletadas();

                ActualizarVista();
                CargarUltimoCierre();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void CargarUltimoCierre()
        {
            CashRegisterDto? cierre =
                _repository.ObtenerUltimoCierre();

            if (cierre == null)
            {
                _view.MostrarUltimoCierre(
                    null, null, null, null, string.Empty);

                return;
            }

            _view.MostrarUltimoCierre(
                cierre.ClosingDateTime,
                cierre.ExpectedCash,
                cierre.ActualCash,
                cierre.Difference,
                cierre.ClosingUserId?.ToString() ?? "-");
        }

        private void OnAbrirCajaClicked(object? sender, EventArgs e)
        {
            try
            {
                if (_repository.ExisteCajaAbierta())
                {
                    _cajaActual =
                        _repository.ObtenerCajaAbiertaMasReciente();

                    ActualizarVista();

                    _view.MostrarMensaje(
                        "Ya existe una caja abierta. No es posible " +
                        "abrir otra caja al mismo tiempo.",
                        MessageType.Warning);

                    return;
                }

                decimal? montoApertura = _view.SolicitarMonto(
                    "Ingrese el monto inicial disponible en caja:",
                    "Apertura de caja");

                if (!montoApertura.HasValue)
                    return;

                if (montoApertura.Value < 0)
                {
                    _view.MostrarMensaje(
                        "El monto de apertura no puede ser negativo.",
                        MessageType.Warning);

                    return;
                }

                CashRegisterDto? caja = _repository.AbrirCaja(
                    _view.UsuarioId,
                    montoApertura.Value,
                    DateTime.Now);

                // El repositorio vuelve a validar la apertura para
                // cubrir el caso de que otra operación abra una caja
                // entre la consulta inicial y el guardado.
                if (caja == null)
                {
                    _cajaActual =
                        _repository.ObtenerCajaAbiertaMasReciente();

                    ActualizarVista();

                    _view.MostrarMensaje(
                        "No se pudo abrir la caja porque ya existe " +
                        "una caja abierta.",
                        MessageType.Warning);

                    return;
                }

                _cajaActual = caja;

                SincronizarVentasCompletadas();
                ActualizarVista();

                _view.MostrarMensaje(
                    "La caja ha sido abierta correctamente.",
                    MessageType.Information);
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    "No fue posible abrir la caja.\n\n" +
                    (ex.InnerException?.Message ?? ex.Message),
                    MessageType.Error);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void OnRegistrarIngresoClicked(
            object? sender,
            EventArgs e)
        {
            if (!ValidarCajaAbierta())
                return;

            string? concepto = _view.SolicitarTexto(
                "Ingrese el concepto del ingreso:",
                "Registrar ingreso");

            if (string.IsNullOrWhiteSpace(concepto))
                return;

            decimal? monto = _view.SolicitarMonto(
                "Ingrese el monto del ingreso:",
                "Registrar ingreso");

            if (!monto.HasValue)
                return;

            if (monto.Value <= 0)
            {
                _view.MostrarMensaje(
                    "El monto debe ser mayor que cero.",
                    MessageType.Warning);

                return;
            }

            try
            {
                _repository.RegistrarMovimiento(
                    _cajaActual!.CashRegisterId,
                    _view.UsuarioId,
                    "Income",
                    "Cash",
                    concepto.Trim(),
                    monto.Value);

                ActualizarVista();

                _view.MostrarMensaje(
                    "El ingreso ha sido registrado correctamente.",
                    MessageType.Information);
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    "No fue posible registrar el ingreso.\n\n" +
                    (ex.InnerException?.Message ?? ex.Message),
                    MessageType.Error);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void OnRegistrarEgresoClicked(
            object? sender,
            EventArgs e)
        {
            if (!ValidarCajaAbierta())
                return;

            string? concepto = _view.SolicitarTexto(
                "Ingrese el concepto del egreso:",
                "Registrar egreso");

            if (string.IsNullOrWhiteSpace(concepto))
                return;

            decimal? monto = _view.SolicitarMonto(
                "Ingrese el monto del egreso:",
                "Registrar egreso");

            if (!monto.HasValue)
                return;

            if (monto.Value <= 0)
            {
                _view.MostrarMensaje(
                    "El monto debe ser mayor que cero.",
                    MessageType.Warning);

                return;
            }

            try
            {
                decimal efectivoEsperado = ObtenerEfectivoEsperado();

                if (monto.Value > efectivoEsperado)
                {
                    _view.MostrarMensaje(
                        "El monto del egreso supera el efectivo " +
                        "disponible esperado en caja.",
                        MessageType.Warning);

                    return;
                }

                _repository.RegistrarMovimiento(
                    _cajaActual!.CashRegisterId,
                    _view.UsuarioId,
                    "Expense",
                    "Cash",
                    concepto.Trim(),
                    monto.Value);

                ActualizarVista();

                _view.MostrarMensaje(
                    "El egreso ha sido registrado correctamente.",
                    MessageType.Information);
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    "No fue posible registrar el egreso.\n\n" +
                    (ex.InnerException?.Message ?? ex.Message),
                    MessageType.Error);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void OnCerrarCajaClicked(
            object? sender,
            EventArgs e)
        {
            if (!ValidarCajaAbierta())
                return;

            try
            {
                SincronizarVentasCompletadas();

                decimal efectivoEsperado = ObtenerEfectivoEsperado();

                decimal? efectivoReal = _view.SolicitarMonto(
                    $"Efectivo esperado: " +
                    $"{FormatearMoneda(efectivoEsperado)}\n\n" +
                    "Ingrese el efectivo contado físicamente:",
                    "Conteo de efectivo");

                if (!efectivoReal.HasValue)
                    return;

                if (efectivoReal.Value < 0)
                {
                    _view.MostrarMensaje(
                        "El efectivo contado no puede ser negativo.",
                        MessageType.Warning);

                    return;
                }

                decimal diferencia =
                    efectivoReal.Value - efectivoEsperado;

                _view.MostrarConfirmacion(
                    $"Efectivo esperado: " +
                    $"{FormatearMoneda(efectivoEsperado)}\n" +
                    $"Efectivo contado: " +
                    $"{FormatearMoneda(efectivoReal.Value)}\n" +
                    $"Diferencia: {FormatearMoneda(diferencia)}\n\n" +
                    "¿Desea confirmar el cierre de caja?",
                    "Resumen de cierre",
                    () => FinalizarCierre(
                        efectivoEsperado,
                        efectivoReal.Value,
                        diferencia));
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void FinalizarCierre(
            decimal efectivoEsperado,
            decimal efectivoReal,
            decimal diferencia)
        {
            try
            {
                if (_cajaActual == null)
                    return;

                DateTime fechaCierre = DateTime.Now;

                _repository.CerrarCaja(
                    _cajaActual.CashRegisterId,
                    _view.UsuarioId,
                    efectivoEsperado,
                    efectivoReal,
                    diferencia,
                    fechaCierre);

                _cajaActual = null;

                ActualizarVista();
                CargarUltimoCierre();

                _view.MostrarMensaje(
                    "La caja ha sido cerrada correctamente.\n\n" +
                    $"Fecha de cierre: {fechaCierre:dd/MM/yyyy HH:mm}\n" +
                    $"Diferencia: {FormatearMoneda(diferencia)}",
                    MessageType.Information);
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    "No fue posible cerrar la caja.\n\n" +
                    (ex.InnerException?.Message ?? ex.Message),
                    MessageType.Error);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void SincronizarVentasCompletadas()
        {
            if (_cajaActual == null)
                return;

            _repository.SincronizarVentasCompletadas(
                _cajaActual.CashRegisterId,
                _cajaActual.OpeningDateTime);
        }

        private void ActualizarVista()
        {
            if (_cajaActual == null)
            {
                _view.MostrarEstadoCaja(false, null);
                _view.MostrarMovimientos(
                    new List<MovimientoCajaPrueba>());

                _view.MostrarResumen(0, 0, 0, 0);
                return;
            }

            ResumenCajaDto resumen = _repository.ObtenerResumen(
                _cajaActual.CashRegisterId,
                _cajaActual.OpeningAmount);

            List<MovimientoCajaPrueba> movimientos =
                resumen.Movimientos
                    .Select(m => new MovimientoCajaPrueba
                    {
                        Fecha = m.Fecha,
                        Tipo = m.Tipo,
                        Concepto = m.Concepto,
                        MetodoPago = m.MetodoPago,
                        Monto = m.Monto,
                        Usuario = m.Usuario
                    })
                    .ToList();

            _view.MostrarEstadoCaja(
                true,
                _cajaActual.OpeningDateTime);

            _view.MostrarMovimientos(movimientos);

            _view.MostrarResumen(
                _cajaActual.OpeningAmount,
                resumen.Ingresos,
                resumen.Egresos,
                resumen.EfectivoEsperado);
        }

        private decimal ObtenerEfectivoEsperado()
        {
            if (_cajaActual == null)
                return 0m;

            return _repository.ObtenerResumen(
                _cajaActual.CashRegisterId,
                _cajaActual.OpeningAmount).EfectivoEsperado;
        }

        private bool ValidarCajaAbierta()
        {
            if (_cajaActual != null)
                return true;

            _view.MostrarMensaje(
                "La caja se encuentra cerrada. Abra la caja " +
                "antes de realizar esta operación.",
                MessageType.Warning);

            return false;
        }

        private static string FormatearMoneda(decimal monto)
        {
            return "C$ " + monto.ToString(
                "N2",
                CultureInfo.GetCultureInfo("es-NI"));
        }

        private void MostrarError(Exception ex)
        {
            _view.MostrarMensaje(
                $"Ocurrió un error inesperado.\n\n{ex.Message}",
                MessageType.Error);
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _view.AbrirCajaClicked -= OnAbrirCajaClicked;
            _view.CerrarCajaClicked -= OnCerrarCajaClicked;
            _view.RegistrarIngresoClicked -= OnRegistrarIngresoClicked;
            _view.RegistrarEgresoClicked -= OnRegistrarEgresoClicked;

            _repository.Dispose();

            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
