using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data.SQLite;
using Ocean_Desk_dv.Data.SQLite.Entities;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;

namespace Ocean_Desk_dv.Services.Offline;

/// <summary>
/// Almacena en SQLite la copia local de las cajas y sus movimientos.
/// Los registros con identificadores locales se exponen al resto del sistema
/// mediante IDs negativos para distinguirlos de los IDs de SQL Server.
/// </summary>
public sealed class OfflineCashRegisterStore
{
    public OfflineCashRegisterStore()
    {
        LocalDatabaseInitializer.Initialize();
    }

    public CashRegisterDto? ObtenerCajaAbiertaMasReciente()
    {
        using var context = OceanDeskLocalDbContextFactory.CreateContext();

        LocalCashRegister? caja = context.LocalCashRegisters
            .AsNoTracking()
            .Where(register => register.Status == "Open")
            .OrderByDescending(register => register.OpeningDateTime)
            .FirstOrDefault();

        return caja is null ? null : MapearCaja(caja);
    }

    public CashRegisterDto? ObtenerUltimoCierre()
    {
        using var context = OceanDeskLocalDbContextFactory.CreateContext();

        LocalCashRegister? caja = context.LocalCashRegisters
            .AsNoTracking()
            .Where(register => register.Status == "Closed")
            .OrderByDescending(register => register.ClosingDateTime)
            .FirstOrDefault();

        return caja is null ? null : MapearCaja(caja);
    }

    public bool ExisteCajaAbierta()
    {
        using var context = OceanDeskLocalDbContextFactory.CreateContext();
        return context.LocalCashRegisters.Any(register => register.Status == "Open");
    }

    public bool TieneCajaAbiertaParaUsuario(int usuarioId)
    {
        using var context = OceanDeskLocalDbContextFactory.CreateContext();

        return context.LocalCashRegisters.Any(register =>
            register.OpeningUserId == usuarioId &&
            register.Status == "Open");
    }

    /// <summary>
    /// Crea una caja provisional. Solo garantiza exclusividad dentro de
    /// esta instalación de Ocean Desk; no puede bloquear otras terminales
    /// que estén desconectadas al mismo tiempo.
    /// </summary>
    public CashRegisterDto? AbrirCajaLocal(
        int usuarioId,
        decimal montoApertura,
        DateTime fechaApertura)
    {
        if (usuarioId <= 0)
            throw new ArgumentOutOfRangeException(nameof(usuarioId));

        if (montoApertura < 0)
            throw new ArgumentOutOfRangeException(nameof(montoApertura));

        using var context = OceanDeskLocalDbContextFactory.CreateContext();
        using var transaction = context.Database.BeginTransaction();

        bool existeCajaAbierta = context.LocalCashRegisters
            .Any(register => register.Status == "Open");

        if (existeCajaAbierta)
            return null;

        var caja = new LocalCashRegister
        {
            OpeningUserId = usuarioId,
            OpeningDateTime = fechaApertura,
            OpeningAmount = montoApertura,
            Status = "Open",
            Origin = LocalCashRegisterOrigin.OfflineCreated,
            SyncStatus = LocalCashSyncStatus.Pending,
            CachedAtUtc = DateTime.UtcNow
        };

        context.LocalCashRegisters.Add(caja);
        context.SaveChanges();
        transaction.Commit();

        return MapearCaja(caja);
    }

    public void RegistrarMovimientoLocal(
        int cajaId,
        int usuarioId,
        string tipo,
        string metodoPago,
        string concepto,
        decimal monto)
    {
        if (usuarioId <= 0)
            throw new ArgumentOutOfRangeException(nameof(usuarioId));

        if (monto <= 0)
            throw new ArgumentOutOfRangeException(nameof(monto));

        if (string.IsNullOrWhiteSpace(tipo))
            throw new ArgumentException("El tipo de movimiento es obligatorio.", nameof(tipo));

        if (string.IsNullOrWhiteSpace(metodoPago))
            throw new ArgumentException("El método de pago es obligatorio.", nameof(metodoPago));

        if (string.IsNullOrWhiteSpace(concepto))
            throw new ArgumentException("El concepto es obligatorio.", nameof(concepto));

        using var context = OceanDeskLocalDbContextFactory.CreateContext();
        using var transaction = context.Database.BeginTransaction();

        LocalCashRegister caja = ObtenerCaja(context, cajaId)
            ?? throw new InvalidOperationException(
                "La caja local indicada no existe.");

        if (caja.Status != "Open")
            throw new InvalidOperationException("La caja ya no está abierta.");

        var movimiento = new LocalCashMovement
        {
            LocalCashRegisterId = caja.LocalCashRegisterId,
            UserId = usuarioId,
            MovementType = tipo.Trim(),
            PaymentMethod = metodoPago.Trim(),
            Concept = concepto.Trim(),
            Amount = monto,
            MovementDateTime = DateTime.Now,
            SyncStatus = LocalCashSyncStatus.Pending
        };

        context.LocalCashMovements.Add(movimiento);
        caja.SyncStatus = LocalCashSyncStatus.Pending;
        caja.CachedAtUtc = DateTime.UtcNow;
        caja.LastSyncError = null;

        context.SaveChanges();
        transaction.Commit();
    }

    public void CerrarCajaLocal(
        int cajaId,
        int usuarioId,
        decimal efectivoEsperado,
        decimal efectivoReal,
        decimal diferencia,
        DateTime fechaCierre)
    {
        if (usuarioId <= 0)
            throw new ArgumentOutOfRangeException(nameof(usuarioId));

        using var context = OceanDeskLocalDbContextFactory.CreateContext();
        using var transaction = context.Database.BeginTransaction();

        LocalCashRegister caja = ObtenerCaja(context, cajaId)
            ?? throw new InvalidOperationException(
                "La caja local indicada no existe.");

        if (caja.Status != "Open")
            throw new InvalidOperationException(
                "La caja seleccionada no existe o ya está cerrada.");

        caja.ClosingDateTime = fechaCierre;
        caja.ExpectedCash = efectivoEsperado;
        caja.ActualCash = efectivoReal;
        caja.Difference = diferencia;
        caja.ClosingUserId = usuarioId;
        caja.Status = "Closed";
        caja.SyncStatus = LocalCashSyncStatus.Pending;
        caja.CachedAtUtc = DateTime.UtcNow;
        caja.LastSyncError = null;

        context.SaveChanges();
        transaction.Commit();
    }

    public ResumenCajaDto ObtenerResumenLocal(
        int cajaId,
        decimal montoApertura)
    {
        using var context = OceanDeskLocalDbContextFactory.CreateContext();

        LocalCashRegister caja = ObtenerCaja(context, cajaId)
            ?? throw new InvalidOperationException(
                "No existe una copia local de la caja solicitada.");

        List<LocalCashMovement> movimientos = context.LocalCashMovements
            .AsNoTracking()
            .Where(movement =>
                movement.LocalCashRegisterId == caja.LocalCashRegisterId)
            .OrderByDescending(movement => movement.MovementDateTime)
            .ToList();

        decimal ingresos = movimientos
            .Where(movement =>
                movement.MovementType is "Sale" or "Income")
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

    /// <summary>
    /// Guarda o actualiza la copia local de una caja obtenida desde SQL Server.
    /// Las operaciones locales pendientes nunca se sobrescriben con la caché.
    /// </summary>
    public void GuardarSnapshotServidor(
        CashRegister cajaServidor,
        IReadOnlyCollection<CashMovement> movimientosServidor)
    {
        ArgumentNullException.ThrowIfNull(cajaServidor);
        ArgumentNullException.ThrowIfNull(movimientosServidor);

        using var context = OceanDeskLocalDbContextFactory.CreateContext();
        using var transaction = context.Database.BeginTransaction();

        LocalCashRegister? cajaLocal = context.LocalCashRegisters
            .SingleOrDefault(register =>
                register.ServerCashRegisterId == cajaServidor.CashRegisterId);

        if (cajaLocal is null)
        {
            cajaLocal = new LocalCashRegister
            {
                ServerCashRegisterId = cajaServidor.CashRegisterId,
                Origin = LocalCashRegisterOrigin.ServerCache,
                SyncStatus = LocalCashSyncStatus.Cached
            };

            context.LocalCashRegisters.Add(cajaLocal);
        }

        bool tieneCambiosLocalesPendientes =
            cajaLocal.SyncStatus == LocalCashSyncStatus.Pending;

        if (!tieneCambiosLocalesPendientes)
        {
            cajaLocal.OpeningUserId = cajaServidor.OpeningUserId;
            cajaLocal.OpeningDateTime = cajaServidor.OpeningDateTime;
            cajaLocal.OpeningAmount = cajaServidor.OpeningAmount;
            cajaLocal.ClosingDateTime = cajaServidor.ClosingDateTime;
            cajaLocal.ExpectedCash = cajaServidor.ExpectedCash;
            cajaLocal.ActualCash = cajaServidor.ActualCash;
            cajaLocal.Difference = cajaServidor.Difference;
            cajaLocal.ClosingUserId = cajaServidor.ClosingUserId;
            cajaLocal.Status = cajaServidor.Status;
            cajaLocal.Origin = LocalCashRegisterOrigin.ServerCache;
            cajaLocal.SyncStatus = LocalCashSyncStatus.Cached;
            cajaLocal.LastSyncError = null;
        }

        cajaLocal.CachedAtUtc = DateTime.UtcNow;
        context.SaveChanges();

        foreach (CashMovement movimientoServidor in movimientosServidor)
        {
            LocalCashMovement? movimientoLocal =
                context.LocalCashMovements.SingleOrDefault(movement =>
                    movement.ServerCashMovementId ==
                    movimientoServidor.CashMovementId);

            if (movimientoLocal is null)
            {
                context.LocalCashMovements.Add(new LocalCashMovement
                {
                    LocalCashRegisterId = cajaLocal.LocalCashRegisterId,
                    ServerCashMovementId = movimientoServidor.CashMovementId,
                    UserId = movimientoServidor.UserId,
                    MovementType = movimientoServidor.MovementType,
                    PaymentMethod = movimientoServidor.PaymentMethod ?? "-",
                    Concept = movimientoServidor.Concept,
                    Amount = movimientoServidor.Amount,
                    MovementDateTime = movimientoServidor.MovementDateTime,
                    Reference = movimientoServidor.Reference,
                    Notes = movimientoServidor.Notes,
                    SyncStatus = LocalCashSyncStatus.Cached
                });

                continue;
            }

            if (movimientoLocal.SyncStatus == LocalCashSyncStatus.Pending)
                continue;

            movimientoLocal.LocalCashRegisterId = cajaLocal.LocalCashRegisterId;
            movimientoLocal.UserId = movimientoServidor.UserId;
            movimientoLocal.MovementType = movimientoServidor.MovementType;
            movimientoLocal.PaymentMethod = movimientoServidor.PaymentMethod ?? "-";
            movimientoLocal.Concept = movimientoServidor.Concept;
            movimientoLocal.Amount = movimientoServidor.Amount;
            movimientoLocal.MovementDateTime = movimientoServidor.MovementDateTime;
            movimientoLocal.Reference = movimientoServidor.Reference;
            movimientoLocal.Notes = movimientoServidor.Notes;
            movimientoLocal.SyncStatus = LocalCashSyncStatus.Cached;
            movimientoLocal.LastSyncError = null;
        }

        context.SaveChanges();
        transaction.Commit();
    }

    /// <summary>
    /// SQL Server confirmó que no hay ninguna caja abierta.
    /// Cierra las copias antiguas; si tienen cambios offline pendientes,
    /// las marca en conflicto para impedir que se sigan utilizando.
    /// </summary>
    public void MarcarCajasServidorCerradas()
    {
        using var context = OceanDeskLocalDbContextFactory.CreateContext();

        List<LocalCashRegister> cajasLocales = context.LocalCashRegisters
            .Where(register =>
                register.Origin == LocalCashRegisterOrigin.ServerCache &&
                register.Status == "Open")
            .ToList();

        foreach (LocalCashRegister caja in cajasLocales)
        {
            if (caja.SyncStatus == LocalCashSyncStatus.Pending)
            {
                caja.Status = "Conflict";
                caja.SyncStatus = LocalCashSyncStatus.Conflict;
                caja.LastSyncError =
                    "SQL Server ya no tiene abierta esta caja, pero existen cambios locales pendientes de resolver.";
            }
            else
            {
                caja.Status = "Closed";
                caja.SyncStatus = LocalCashSyncStatus.Cached;
            }

            caja.CachedAtUtc = DateTime.UtcNow;
        }

        if (cajasLocales.Count > 0)
            context.SaveChanges();
    }

    private static LocalCashRegister? ObtenerCaja(
        OceanDeskLocalDbContext context,
        int cajaId)
    {
        if (cajaId == 0 || cajaId == int.MinValue)
            return null;

        return cajaId < 0
            ? context.LocalCashRegisters.SingleOrDefault(register =>
                register.LocalCashRegisterId == -cajaId)
            : context.LocalCashRegisters.SingleOrDefault(register =>
                register.ServerCashRegisterId == cajaId);
    }

    private static CashRegisterDto MapearCaja(LocalCashRegister caja) => new()
    {
        CashRegisterId = checked(-caja.LocalCashRegisterId),
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

    private static string TraducirMetodoPago(string metodoPago) => metodoPago switch
    {
        "Cash" => "Efectivo",
        "Card" => "Tarjeta",
        "Transfer" => "Transferencia",
        _ => string.IsNullOrWhiteSpace(metodoPago) || metodoPago == "-"
            ? "-"
            : metodoPago
    };
}
