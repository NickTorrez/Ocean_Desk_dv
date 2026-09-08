using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.Entities;
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
        private readonly OceanDeskDbContext _context;
        private CashRegister? _cajaActual;
        private bool _disposed;

        /// <summary>
        /// Inicializa una nueva instancia del Presenter de Caja.
        /// </summary>
        /// <param name="view">Vista que implementa ICajaView.</param>
        public CajaPresenter(ICajaView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _context = new OceanDeskDbContext();

            _view.AbrirCajaClicked += OnAbrirCajaClicked;
            _view.CerrarCajaClicked += OnCerrarCajaClicked;
            _view.RegistrarIngresoClicked += OnRegistrarIngresoClicked;
            _view.RegistrarEgresoClicked += OnRegistrarEgresoClicked;
        }

        #region Inicialización

        /// <summary>
        /// Carga la caja abierta actualmente y sus movimientos.
        /// </summary>
        public void Inicializar()
        {
            try
            {
                _cajaActual = _context.CashRegisters
                    .OrderByDescending(c => c.OpeningDateTime)
                    .FirstOrDefault(c => c.Status == "Open");

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
        #endregion

        #region Último Cierre

        /// <summary>
        /// Consulta y muestra el cierre de caja más reciente.
        /// </summary>
        private void CargarUltimoCierre()
        {
            CashRegister? ultimoCierre = _context.CashRegisters
                .AsNoTracking()
                .Where(c => c.Status == "Closed")
                .OrderByDescending(c => c.ClosingDateTime)
                .FirstOrDefault();

            if (ultimoCierre == null)
            {
                _view.MostrarUltimoCierre(
                    null,
                    null,
                    null,
                    null,
                    string.Empty);

                return;
            }

            _view.MostrarUltimoCierre(
                ultimoCierre.ClosingDateTime,
                ultimoCierre.ExpectedCash,
                ultimoCierre.ActualCash,
                ultimoCierre.Difference,
                ultimoCierre.ClosingUserId?.ToString() ?? "-");
        }

        #endregion

        #region Apertura de Caja

        /// <summary>
        /// Abre una nueva caja después de validar que no exista otra abierta.
        /// </summary>
        private void OnAbrirCajaClicked(object? sender, EventArgs e)
        {
            try
            {
                CashRegister? cajaAbierta = _context.CashRegisters
                    .FirstOrDefault(c => c.Status == "Open");

                if (cajaAbierta != null)
                {
                    _cajaActual = cajaAbierta;
                    ActualizarVista();

                    _view.MostrarMensaje(
                        "Ya existe una caja abierta. No es posible abrir otra caja al mismo tiempo.",
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

                _cajaActual = new CashRegister
                {
                    OpeningUserId = _view.UsuarioId,
                    OpeningDateTime = DateTime.Now,
                    OpeningAmount = montoApertura.Value,
                    Status = "Open"
                };

                _context.CashRegisters.Add(_cajaActual);
                _context.SaveChanges();

                SincronizarVentasCompletadas();
                ActualizarVista();

                _view.MostrarMensaje(
                    "La caja ha sido abierta correctamente.",
                    MessageType.Information);
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible abrir la caja.\n\n{ex.InnerException?.Message ?? ex.Message}",
                    MessageType.Error);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }
        #endregion

        #region Movimientos Manuales

        /// <summary>
        /// Registra un ingreso manual en efectivo.
        /// </summary>
        private void OnRegistrarIngresoClicked(object? sender, EventArgs e)
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
                var movimiento = new CashMovement
                {
                    CashRegisterId = _cajaActual!.CashRegisterId,
                    UserId = _view.UsuarioId,
                    MovementType = "Income",
                    PaymentMethod = "Cash",
                    Concept = concepto.Trim(),
                    Amount = monto.Value,
                    MovementDateTime = DateTime.Now
                };

                _context.CashMovements.Add(movimiento);
                _context.SaveChanges();

                ActualizarVista();

                _view.MostrarMensaje(
                    "El ingreso ha sido registrado correctamente.",
                    MessageType.Information);
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible registrar el ingreso.\n\n{ex.InnerException?.Message ?? ex.Message}",
                    MessageType.Error);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        /// <summary>
        /// Registra un egreso manual en efectivo y valida el disponible esperado.
        /// </summary>
        private void OnRegistrarEgresoClicked(object? sender, EventArgs e)
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

            decimal efectivoEsperado = ObtenerEfectivoEsperado();

            if (monto.Value > efectivoEsperado)
            {
                _view.MostrarMensaje(
                    "El monto del egreso supera el efectivo disponible esperado en caja.",
                    MessageType.Warning);
                return;
            }

            try
            {
                var movimiento = new CashMovement
                {
                    CashRegisterId = _cajaActual!.CashRegisterId,
                    UserId = _view.UsuarioId,
                    MovementType = "Expense",
                    PaymentMethod = "Cash",
                    Concept = concepto.Trim(),
                    Amount = monto.Value,
                    MovementDateTime = DateTime.Now
                };

                _context.CashMovements.Add(movimiento);
                _context.SaveChanges();

                ActualizarVista();

                _view.MostrarMensaje(
                    "El egreso ha sido registrado correctamente.",
                    MessageType.Information);
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible registrar el egreso.\n\n{ex.InnerException?.Message ?? ex.Message}",
                    MessageType.Error);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }
        #endregion

        #region Cierre de Caja

        /// <summary>
        /// Solicita el conteo físico y prepara el cierre de caja.
        /// </summary>
        private void OnCerrarCajaClicked(object? sender, EventArgs e)
        {
            if (!ValidarCajaAbierta())
                return;

            try
            {
                SincronizarVentasCompletadas();

                decimal efectivoEsperado = ObtenerEfectivoEsperado();

                decimal? efectivoReal = _view.SolicitarMonto(
                    $"Efectivo esperado: {FormatearMoneda(efectivoEsperado)}\n\n" +
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

                decimal diferencia = efectivoReal.Value - efectivoEsperado;

                _view.MostrarConfirmacion(
                    $"Efectivo esperado: {FormatearMoneda(efectivoEsperado)}\n" +
                    $"Efectivo contado: {FormatearMoneda(efectivoReal.Value)}\n" +
                    $"Diferencia: {FormatearMoneda(diferencia)}\n\n" +
                    "¿Desea confirmar el cierre de caja?",
                    "Resumen de cierre",
                    () => FinalizarCierre(efectivoEsperado, efectivoReal.Value, diferencia));
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        /// <summary>
        /// Guarda los valores finales y cambia el estado de la caja a Closed.
        /// </summary>
        private void FinalizarCierre(decimal efectivoEsperado, decimal efectivoReal, decimal diferencia)
        {
            try
            {
                if (_cajaActual == null)
                    return;

                _cajaActual.ClosingDateTime = DateTime.Now;
                _cajaActual.ExpectedCash = efectivoEsperado;
                _cajaActual.ActualCash = efectivoReal;
                _cajaActual.Difference = diferencia;
                _cajaActual.ClosingUserId = _view.UsuarioId;
                _cajaActual.Status = "Closed";

                _context.SaveChanges();

                DateTime fechaCierre = _cajaActual.ClosingDateTime ?? DateTime.Now;
                _cajaActual = null;

                ActualizarVista();

                CargarUltimoCierre();

                _view.MostrarMensaje(
                    $"La caja ha sido cerrada correctamente.\n\n" +
                    $"Fecha de cierre: {fechaCierre:dd/MM/yyyy HH:mm}\n" +
                    $"Diferencia: {FormatearMoneda(diferencia)}",
                    MessageType.Information);
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible cerrar la caja.\n\n{ex.InnerException?.Message ?? ex.Message}",
                    MessageType.Error);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }
        #endregion

        #region Sincronización con Ventas

        /// <summary>
        /// Registra en la caja actual los pagos de ventas completadas que aún no tengan
        /// movimientos asociados dentro de esta caja.
        /// </summary>
        private void SincronizarVentasCompletadas()
        {
            if (_cajaActual == null)
                return;

            List<Sale> ventas = _context.Sales
                .AsNoTracking()
                .Where(s =>
                    s.Status == "Completed" &&
                    s.SaleDateTime >= _cajaActual.OpeningDateTime)
                .OrderBy(s => s.SaleDateTime)
                .ToList();

            foreach (Sale venta in ventas)
            {
                List<SalePayment> pagos = _context.SalePayments
                    .AsNoTracking()
                    .Where(p => p.SaleId == venta.SaleId)
                    .ToList();

                decimal totalPagos = pagos.Sum(p => p.Amount);

                decimal totalMovimientos = _context.CashMovements
                    .Where(m =>
                        m.CashRegisterId == _cajaActual.CashRegisterId &&
                        m.SaleId == venta.SaleId &&
                        m.MovementType == "Sale")
                    .Sum(m => m.Amount);

                if (totalMovimientos >= totalPagos)
                    continue;

                decimal diferenciaPendiente = totalPagos - totalMovimientos;

                foreach (SalePayment pago in pagos)
                {
                    if (diferenciaPendiente <= 0)
                        break;

                    decimal restantePago = pago.Amount;

                    if (restantePago <= 0)
                        continue;

                    decimal montoRegistrar = Math.Min(restantePago, diferenciaPendiente);

                    var movimiento = new CashMovement
                    {
                        CashRegisterId = _cajaActual.CashRegisterId,
                        SaleId = venta.SaleId,
                        UserId = venta.UserId,
                        MovementType = "Sale",
                        PaymentMethod = pago.PaymentMethod,
                        Concept = $"Venta #{venta.SaleId:0000}",
                        Amount = montoRegistrar,
                        MovementDateTime = pago.PaymentDateTime,
                        Reference = pago.Reference,
                        Notes = "Movimiento sincronizado desde Punto de Venta."
                    };

                    _context.CashMovements.Add(movimiento);
                    diferenciaPendiente -= montoRegistrar;
                }
            }

            _context.SaveChanges();
        }
        #endregion

        #region Consultas y Cálculos

        /// <summary>
        /// Actualiza toda la información que muestra la vista.
        /// </summary>
        private void ActualizarVista()
        {
            if (_cajaActual == null)
            {
                _view.MostrarEstadoCaja(false, null);
                _view.MostrarMovimientos(new List<MovimientoCajaPrueba>());
                _view.MostrarResumen(0, 0, 0, 0);
                return;
            }

            List<CashMovement> movimientosDb = _context.CashMovements
                .AsNoTracking()
                .Where(m => m.CashRegisterId == _cajaActual.CashRegisterId)
                .OrderByDescending(m => m.MovementDateTime)
                .ToList();

            List<MovimientoCajaPrueba> movimientos = movimientosDb
                .Select(MapearMovimiento)
                .ToList();

            decimal ingresos = movimientosDb
                .Where(m => m.MovementType == "Sale" || m.MovementType == "Income")
                .Sum(m => m.Amount);

            decimal egresos = movimientosDb
                .Where(m => m.MovementType == "Expense")
                .Sum(m => m.Amount);

            decimal esperado = ObtenerEfectivoEsperado();

            _view.MostrarEstadoCaja(true, _cajaActual.OpeningDateTime);
            _view.MostrarMovimientos(movimientos);
            _view.MostrarResumen(
                _cajaActual.OpeningAmount,
                ingresos,
                egresos,
                esperado);
        }

        /// <summary>
        /// Calcula el efectivo físico esperado, considerando únicamente operaciones en efectivo.
        /// </summary>
        private decimal ObtenerEfectivoEsperado()
        {
            if (_cajaActual == null)
                return 0;

            decimal ingresosEfectivo = _context.CashMovements
                .Where(m =>
                    m.CashRegisterId == _cajaActual.CashRegisterId &&
                    (m.MovementType == "Sale" || m.MovementType == "Income") &&
                    m.PaymentMethod == "Cash")
                .Sum(m => m.Amount);

            decimal egresosEfectivo = _context.CashMovements
                .Where(m =>
                    m.CashRegisterId == _cajaActual.CashRegisterId &&
                    m.MovementType == "Expense" &&
                    m.PaymentMethod == "Cash")
                .Sum(m => m.Amount);

            return _cajaActual.OpeningAmount
                + ingresosEfectivo
                - egresosEfectivo;
        }

        /// <summary>
        /// Convierte una entidad CashMovement al modelo de presentación utilizado por la tabla.
        /// </summary>
        private static MovimientoCajaPrueba MapearMovimiento(CashMovement movimiento)
        {
            string tipo = movimiento.MovementType switch
            {
                "Sale" => "Venta",
                "Income" => "Ingreso",
                "Expense" => "Egreso",
                "Adjustment" => "Ajuste",
                _ => movimiento.MovementType
            };

            string metodo = movimiento.PaymentMethod switch
            {
                "Cash" => "Efectivo",
                "Card" => "Tarjeta",
                "Transfer" => "Transferencia",
                _ => string.IsNullOrWhiteSpace(movimiento.PaymentMethod)
                    ? "-"
                    : movimiento.PaymentMethod
            };

            return new MovimientoCajaPrueba
            {
                Fecha = movimiento.MovementDateTime,
                Tipo = tipo,
                Concepto = movimiento.Concept,
                MetodoPago = metodo,
                Monto = movimiento.Amount,
                Usuario = movimiento.UserId.ToString()
            };
        }
        #endregion

        #region Validaciones y Utilidades

        /// <summary>
        /// Verifica que exista una caja abierta para la operación solicitada.
        /// </summary>
        private bool ValidarCajaAbierta()
        {
            if (_cajaActual != null)
                return true;

            _view.MostrarMensaje(
                "La caja se encuentra cerrada. Abra la caja antes de realizar esta operación.",
                MessageType.Warning);
            return false;
        }

        /// <summary>
        /// Formatea un monto utilizando la cultura de Nicaragua.
        /// </summary>
        private static string FormatearMoneda(decimal monto)
        {
            return "C$ " + monto.ToString("N2", CultureInfo.GetCultureInfo("es-NI"));
        }

        /// <summary>
        /// Muestra errores inesperados utilizando el sistema de mensajes del proyecto.
        /// </summary>
        private void MostrarError(Exception ex)
        {
            _view.MostrarMensaje(
                $"Ocurrió un error inesperado.\n\n{ex.Message}",
                MessageType.Error);
        }
        #endregion

        #region Liberación de Recursos

        /// <summary>
        /// Libera la suscripción a eventos y el contexto de Entity Framework.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
                return;

            _view.AbrirCajaClicked -= OnAbrirCajaClicked;
            _view.CerrarCajaClicked -= OnCerrarCajaClicked;
            _view.RegistrarIngresoClicked -= OnRegistrarIngresoClicked;
            _view.RegistrarEgresoClicked -= OnRegistrarEgresoClicked;

            _context.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
