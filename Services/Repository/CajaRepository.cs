using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;
using Ocean_Desk_dv.Services.Offline;

namespace Ocean_Desk_dv.Services.Repository;

/// <summary>
/// Repositorio híbrido del módulo Caja. SQL Server continúa siendo la fuente
/// principal; SQLite se utiliza como caché y como almacenamiento provisional
/// cuando se detecta una caída de conectividad.
/// </summary>
public sealed class CajaRepository : ICajaRepository
{
    private readonly OceanDeskDbContext _context;
    private readonly OfflineCashRegisterStore _offlineStore;

    public CajaRepository(
        OceanDeskDbContext context,
        OfflineCashRegisterStore? offlineStore = null)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _offlineStore = offlineStore ?? new OfflineCashRegisterStore();
    }

    public CashRegisterDto? ObtenerCajaAbiertaMasReciente()
    {
        try
        {
            CashRegister? caja = _context.CashRegisters
                .AsNoTracking()
                .Where(register => register.Status == "Open")
                .OrderByDescending(register => register.OpeningDateTime)
                .FirstOrDefault();

            if (caja is null)
            {
                _offlineStore.MarcarCajasServidorCerradas();
                return _offlineStore.ObtenerCajaAbiertaMasReciente();
            }

            IntentarGuardarSnapshotServidor(caja);
            return MapearCaja(caja);
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            _context.ChangeTracker.Clear();
            return _offlineStore.ObtenerCajaAbiertaMasReciente();
        }
    }

    public CashRegisterDto? ObtenerUltimoCierre()
    {
        try
        {
            CashRegister? caja = _context.CashRegisters
                .AsNoTracking()
                .Where(register => register.Status == "Closed")
                .OrderByDescending(register => register.ClosingDateTime)
                .FirstOrDefault();

            if (caja is null)
                return _offlineStore.ObtenerUltimoCierre();

            IntentarGuardarSnapshotServidor(caja);
            return MapearCaja(caja);
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            _context.ChangeTracker.Clear();
            return _offlineStore.ObtenerUltimoCierre();
        }
    }

    public bool ExisteCajaAbierta()
    {
        try
        {
            CashRegister? caja = _context.CashRegisters
                .AsNoTracking()
                .Where(register => register.Status == "Open")
                .OrderByDescending(register => register.OpeningDateTime)
                .FirstOrDefault();

            if (caja is null)
            {
                _offlineStore.MarcarCajasServidorCerradas();
                return _offlineStore.ExisteCajaAbierta();
            }

            IntentarGuardarSnapshotServidor(caja);
            return true;
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            _context.ChangeTracker.Clear();
            return _offlineStore.ExisteCajaAbierta();
        }
    }

    public bool TieneCajaAbiertaParaUsuario(int usuarioId)
    {
        try
        {
            // Se consulta la caja global para distinguir entre "no existe caja"
            // y "la caja abierta pertenece a otro usuario".
            CashRegister? caja = _context.CashRegisters
                .AsNoTracking()
                .Where(register => register.Status == "Open")
                .OrderByDescending(register => register.OpeningDateTime)
                .FirstOrDefault();

            if (caja is null)
            {
                _offlineStore.MarcarCajasServidorCerradas();
                return _offlineStore.TieneCajaAbiertaParaUsuario(usuarioId);
            }

            IntentarGuardarSnapshotServidor(caja);
            return caja.OpeningUserId == usuarioId;
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            _context.ChangeTracker.Clear();
            return _offlineStore.TieneCajaAbiertaParaUsuario(usuarioId);
        }
    }

    public CashRegisterDto? AbrirCaja(
        int usuarioId,
        decimal montoApertura,
        DateTime fechaApertura)
    {
        try
        {
            CashRegister? cajaAbierta = _context.CashRegisters
                .AsNoTracking()
                .Where(register => register.Status == "Open")
                .OrderByDescending(register => register.OpeningDateTime)
                .FirstOrDefault();

            if (cajaAbierta is not null)
            {
                IntentarGuardarSnapshotServidor(cajaAbierta);
                return null;
            }

            // El servidor confirmó que no hay caja abierta. Se limpian copias
            // antiguas, pero nunca las operaciones locales pendientes.
            _offlineStore.MarcarCajasServidorCerradas();

            // Evita abrir una caja online mientras haya una caja provisional
            // todavía abierta en esta instalación.
            if (_offlineStore.ExisteCajaAbierta())
                return null;

            var caja = new CashRegister
            {
                OpeningUserId = usuarioId,
                OpeningDateTime = fechaApertura,
                OpeningAmount = montoApertura,
                Status = "Open"
            };

            _context.CashRegisters.Add(caja);
            _context.SaveChanges();

            IntentarGuardarSnapshotServidor(caja);
            return MapearCaja(caja);
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            _context.ChangeTracker.Clear();

            if (_offlineStore.ExisteCajaAbierta())
                return null;

            return _offlineStore.AbrirCajaLocal(
                usuarioId,
                montoApertura,
                fechaApertura);
        }
    }

    public void RegistrarMovimiento(
        int cajaId,
        int usuarioId,
        string tipo,
        string metodoPago,
        string concepto,
        decimal monto)
    {
        // Los identificadores negativos pertenecen exclusivamente a SQLite.
        if (cajaId < 0)
        {
            _offlineStore.RegistrarMovimientoLocal(
                cajaId, usuarioId, tipo, metodoPago, concepto, monto);
            return;
        }

        try
        {
            bool cajaAbierta = _context.CashRegisters.Any(register =>
                register.CashRegisterId == cajaId &&
                register.Status == "Open");

            if (!cajaAbierta)
                throw new InvalidOperationException("La caja ya no está abierta.");

            _context.CashMovements.Add(new CashMovement
            {
                CashRegisterId = cajaId,
                UserId = usuarioId,
                MovementType = tipo,
                PaymentMethod = metodoPago,
                Concept = concepto,
                Amount = monto,
                MovementDateTime = DateTime.Now
            });

            _context.SaveChanges();

            CashRegister? caja = _context.CashRegisters
                .AsNoTracking()
                .FirstOrDefault(register => register.CashRegisterId == cajaId);

            if (caja is not null)
                IntentarGuardarSnapshotServidor(caja);
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            _context.ChangeTracker.Clear();
            _offlineStore.RegistrarMovimientoLocal(
                cajaId, usuarioId, tipo, metodoPago, concepto, monto);
        }
    }

    public void CerrarCaja(
        int cajaId,
        int usuarioId,
        decimal efectivoEsperado,
        decimal efectivoReal,
        decimal diferencia,
        DateTime fechaCierre)
    {
        if (cajaId < 0)
        {
            _offlineStore.CerrarCajaLocal(
                cajaId,
                usuarioId,
                efectivoEsperado,
                efectivoReal,
                diferencia,
                fechaCierre);
            return;
        }

        try
        {
            CashRegister? caja = _context.CashRegisters.FirstOrDefault(register =>
                register.CashRegisterId == cajaId &&
                register.Status == "Open");

            if (caja is null)
                throw new InvalidOperationException(
                    "La caja seleccionada no existe o ya está cerrada.");

            caja.ClosingDateTime = fechaCierre;
            caja.ExpectedCash = efectivoEsperado;
            caja.ActualCash = efectivoReal;
            caja.Difference = diferencia;
            caja.ClosingUserId = usuarioId;
            caja.Status = "Closed";

            _context.SaveChanges();
            IntentarGuardarSnapshotServidor(caja);
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            _context.ChangeTracker.Clear();
            _offlineStore.CerrarCajaLocal(
                cajaId,
                usuarioId,
                efectivoEsperado,
                efectivoReal,
                diferencia,
                fechaCierre);
        }
    }

    public void SincronizarVentasCompletadas(int cajaId, DateTime fechaApertura)
    {
        // Las ventas locales se integrarán en una etapa posterior. Una caja
        // local no debe provocar consultas SQL con un ID temporal negativo.
        if (cajaId < 0)
            return;

        try
        {
            CashRegister? caja = _context.CashRegisters
                .FirstOrDefault(register =>
                    register.CashRegisterId == cajaId &&
                    register.Status == "Open");

            if (caja is null)
                return;

            List<Sale> ventas = _context.Sales
                .AsNoTracking()
                .Where(sale =>
                    sale.Status == "Completed" &&
                    sale.SaleDateTime >= fechaApertura)
                .OrderBy(sale => sale.SaleDateTime)
                .ToList();

            foreach (Sale venta in ventas)
            {
                List<SalePayment> pagos = _context.SalePayments
                    .AsNoTracking()
                    .Where(payment => payment.SaleId == venta.SaleId)
                    .ToList();

                decimal totalPagos = pagos.Sum(payment => payment.Amount);

                decimal totalMovimientos = _context.CashMovements
                    .Where(movement =>
                        movement.CashRegisterId == cajaId &&
                        movement.SaleId == venta.SaleId &&
                        movement.MovementType == "Sale")
                    .Sum(movement => (decimal?)movement.Amount) ?? 0m;

                decimal diferenciaPendiente = totalPagos - totalMovimientos;
                if (diferenciaPendiente <= 0)
                    continue;

                foreach (SalePayment pago in pagos)
                {
                    if (diferenciaPendiente <= 0)
                        break;

                    if (pago.Amount <= 0)
                        continue;

                    decimal registrar = Math.Min(pago.Amount, diferenciaPendiente);

                    _context.CashMovements.Add(new CashMovement
                    {
                        CashRegisterId = cajaId,
                        SaleId = venta.SaleId,
                        UserId = venta.UserId,
                        MovementType = "Sale",
                        PaymentMethod = pago.PaymentMethod,
                        Concept = $"Venta #{venta.SaleId:0000}",
                        Amount = registrar,
                        MovementDateTime = pago.PaymentDateTime,
                        Reference = pago.Reference,
                        Notes = "Movimiento sincronizado desde Punto de Venta."
                    });

                    diferenciaPendiente -= registrar;
                }
            }

            _context.SaveChanges();

            CashRegister? cajaActualizada = _context.CashRegisters
                .AsNoTracking()
                .FirstOrDefault(register => register.CashRegisterId == cajaId);

            if (cajaActualizada is not null)
                IntentarGuardarSnapshotServidor(cajaActualizada);
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            _context.ChangeTracker.Clear();
            // La copia local de la caja y sus movimientos se mantiene intacta.
        }
    }

    public ResumenCajaDto ObtenerResumen(int cajaId, decimal montoApertura)
    {
        if (cajaId < 0)
            return _offlineStore.ObtenerResumenLocal(cajaId, montoApertura);

        try
        {
            List<CashMovement> movimientos = _context.CashMovements
                .AsNoTracking()
                .Where(movement => movement.CashRegisterId == cajaId)
                .OrderByDescending(movement => movement.MovementDateTime)
                .ToList();

            return CrearResumen(movimientos, montoApertura);
        }
        catch (Exception ex) when (
            SqlServerConnectionFailureDetector.IsConnectionFailure(ex))
        {
            _context.ChangeTracker.Clear();
            return _offlineStore.ObtenerResumenLocal(cajaId, montoApertura);
        }
    }

    private void IntentarGuardarSnapshotServidor(CashRegister caja)
    {
        try
        {
            List<CashMovement> movimientos = _context.CashMovements
                .AsNoTracking()
                .Where(movement => movement.CashRegisterId == caja.CashRegisterId)
                .OrderBy(movement => movement.MovementDateTime)
                .ToList();

            _offlineStore.GuardarSnapshotServidor(caja, movimientos);
        }
        catch (Exception ex)
        {
            // Un fallo al actualizar SQLite no debe interrumpir el flujo online.
            System.Diagnostics.Debug.WriteLine(
                $"No fue posible actualizar la caché local de Caja: {ex}");
        }
    }

    private static ResumenCajaDto CrearResumen(
        IReadOnlyCollection<CashMovement> movimientos,
        decimal montoApertura)
    {
        decimal ingresos = movimientos
            .Where(movement => movement.MovementType is "Sale" or "Income")
            .Sum(movement => movement.Amount);

        decimal egresos = movimientos
            .Where(movement => movement.MovementType == "Expense")
            .Sum(movement => movement.Amount);

        decimal ingresosEfectivo = movimientos
            .Where(movement =>
                (movement.MovementType is "Sale" or "Income") &&
                movement.PaymentMethod == "Cash")
            .Sum(movement => movement.Amount);

        decimal egresosEfectivo = movimientos
            .Where(movement =>
                movement.MovementType == "Expense" &&
                movement.PaymentMethod == "Cash")
            .Sum(movement => movement.Amount);

        return new ResumenCajaDto
        {
            Ingresos = ingresos,
            Egresos = egresos,
            EfectivoEsperado = montoApertura + ingresosEfectivo - egresosEfectivo,
            Movimientos = movimientos.Select(movement => new MovimientoCajaDto
            {
                Fecha = movement.MovementDateTime,
                Tipo = TraducirTipo(movement.MovementType),
                Concepto = movement.Concept,
                MetodoPago = TraducirMetodoPago(movement.PaymentMethod),
                Monto = movement.Amount,
                Usuario = movement.UserId.ToString()
            }).ToList()
        };
    }

    private static CashRegisterDto MapearCaja(CashRegister caja) => new()
    {
        CashRegisterId = caja.CashRegisterId,
        OpeningUserId = caja.OpeningUserId,
        OpeningDateTime = caja.OpeningDateTime,
        OpeningAmount = caja.OpeningAmount,
        ClosingDateTime = caja.ClosingDateTime,
        ExpectedCash = caja.ExpectedCash,
        ActualCash = caja.ActualCash,
        Difference = caja.Difference,
        ClosingUserId = caja.ClosingUserId,
        Status = caja.Status
    };

    private static string TraducirTipo(string tipo) => tipo switch
    {
        "Sale" => "Venta",
        "Income" => "Ingreso",
        "Expense" => "Egreso",
        "Adjustment" => "Ajuste",
        _ => tipo
    };

    private static string TraducirMetodoPago(string? metodoPago) => metodoPago switch
    {
        "Cash" => "Efectivo",
        "Card" => "Tarjeta",
        "Transfer" => "Transferencia",
        _ => string.IsNullOrWhiteSpace(metodoPago) ? "-" : metodoPago
    };

    public void Dispose() => _context.Dispose();

}
