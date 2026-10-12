using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Services.Interfaces_Services;
using Ocean_Desk_dv.Models.Entities;

namespace Ocean_Desk_dv.Services.Repository;

public sealed class CajaRepository : ICajaRepository
{
    private readonly OceanDeskDbContext _context;

    public CajaRepository(OceanDeskDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public CashRegisterDto? ObtenerCajaAbiertaMasReciente()
    {
        var db = _context;
        var caja = db.CashRegisters.AsNoTracking().Where(c => c.Status == "Open").OrderByDescending(c => c.OpeningDateTime).FirstOrDefault();
        return caja is null ? null : MapearCaja(caja);
    }

    public CashRegisterDto? ObtenerUltimoCierre()
    {
        var db = _context;
        var caja = db.CashRegisters.AsNoTracking().Where(c => c.Status == "Closed").OrderByDescending(c => c.ClosingDateTime).FirstOrDefault();
        return caja is null ? null : MapearCaja(caja);
    }

    public bool ExisteCajaAbierta()
    {
        var db = _context;
        return db.CashRegisters.Any(c => c.Status == "Open");
    }

    public bool TieneCajaAbiertaParaUsuario(int usuarioId)
    {
        var db = _context;
        return db.CashRegisters.Any(c => c.OpeningUserId == usuarioId && c.Status == "Open");
    }

    public CashRegisterDto? AbrirCaja(int usuarioId, decimal montoApertura, DateTime fechaApertura)
    {
        var db = _context;
        if (db.CashRegisters.Any(c => c.Status == "Open")) return null;
        var caja = new CashRegister
        {
            OpeningUserId = usuarioId,
            OpeningDateTime = fechaApertura,
            OpeningAmount = montoApertura,
            Status = "Open"
        };
        db.CashRegisters.Add(caja);
        db.SaveChanges();
        return MapearCaja(caja);
    }

    public void RegistrarMovimiento(int cajaId, int usuarioId, string tipo, string metodoPago, string concepto, decimal monto)
    {
        var db = _context;
        if (!db.CashRegisters.Any(c => c.CashRegisterId == cajaId && c.Status == "Open"))
            throw new InvalidOperationException("La caja ya no está abierta.");
        db.CashMovements.Add(new CashMovement
        {
            CashRegisterId = cajaId,
            UserId = usuarioId,
            MovementType = tipo,
            PaymentMethod = metodoPago,
            Concept = concepto,
            Amount = monto,
            MovementDateTime = DateTime.Now
        });
        db.SaveChanges();
    }

    public void CerrarCaja(int cajaId, int usuarioId, decimal efectivoEsperado, decimal efectivoReal, decimal diferencia, DateTime fechaCierre)
    {
        var db = _context;
        var caja = db.CashRegisters.FirstOrDefault(c => c.CashRegisterId == cajaId && c.Status == "Open");
        if (caja is null) throw new InvalidOperationException("La caja seleccionada no existe o ya está cerrada.");
        caja.ClosingDateTime = fechaCierre;
        caja.ExpectedCash = efectivoEsperado;
        caja.ActualCash = efectivoReal;
        caja.Difference = diferencia;
        caja.ClosingUserId = usuarioId;
        caja.Status = "Closed";
        db.SaveChanges();
    }

    public void SincronizarVentasCompletadas(int cajaId, DateTime fechaApertura)
    {
        var db = _context;
        var caja = db.CashRegisters.FirstOrDefault(c => c.CashRegisterId == cajaId && c.Status == "Open");
        if (caja is null) return;
        var ventas = db.Sales.AsNoTracking()
            .Where(s => s.Status == "Completed" && s.SaleDateTime >= fechaApertura)
            .OrderBy(s => s.SaleDateTime).ToList();
        foreach (var venta in ventas)
        {
            var pagos = db.SalePayments.AsNoTracking().Where(p => p.SaleId == venta.SaleId).ToList();
            decimal totalPagos = pagos.Sum(p => p.Amount);
            decimal totalMovimientos = db.CashMovements
                .Where(m => m.CashRegisterId == cajaId && m.SaleId == venta.SaleId && m.MovementType == "Sale")
                .Sum(m => (decimal?)m.Amount) ?? 0m;
            decimal diferenciaPendiente = totalPagos - totalMovimientos;
            if (diferenciaPendiente <= 0) continue;
            foreach (var pago in pagos)
            {
                if (diferenciaPendiente <= 0) break;
                if (pago.Amount <= 0) continue;
                decimal registrar = Math.Min(pago.Amount, diferenciaPendiente);
                db.CashMovements.Add(new CashMovement
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
        db.SaveChanges();
    }

    public ResumenCajaDto ObtenerResumen(int cajaId, decimal montoApertura)
    {
        var db = _context;
        var movimientos = db.CashMovements.AsNoTracking().Where(m => m.CashRegisterId == cajaId)
            .OrderByDescending(m => m.MovementDateTime).ToList();
        decimal ingresos = movimientos.Where(m => m.MovementType is "Sale" or "Income").Sum(m => m.Amount);
        decimal egresos = movimientos.Where(m => m.MovementType == "Expense").Sum(m => m.Amount);
        decimal ingresosEfectivo = movimientos.Where(m => (m.MovementType is "Sale" or "Income") && m.PaymentMethod == "Cash").Sum(m => m.Amount);
        decimal egresosEfectivo = movimientos.Where(m => m.MovementType == "Expense" && m.PaymentMethod == "Cash").Sum(m => m.Amount);
        return new ResumenCajaDto
        {
            Ingresos = ingresos,
            Egresos = egresos,
            EfectivoEsperado = montoApertura + ingresosEfectivo - egresosEfectivo,
            Movimientos = movimientos.Select(m => new MovimientoCajaDto
            {
                Fecha = m.MovementDateTime,
                Tipo = m.MovementType switch { "Sale" => "Venta", "Income" => "Ingreso", "Expense" => "Egreso", "Adjustment" => "Ajuste", _ => m.MovementType },
                Concepto = m.Concept,
                MetodoPago = m.PaymentMethod switch { "Cash" => "Efectivo", "Card" => "Tarjeta", "Transfer" => "Transferencia", _ => string.IsNullOrWhiteSpace(m.PaymentMethod) ? "-" : m.PaymentMethod },
                Monto = m.Amount,
                Usuario = m.UserId.ToString()
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
    public void Dispose() => _context.Dispose();

}
