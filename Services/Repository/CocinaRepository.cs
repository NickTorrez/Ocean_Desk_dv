using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;

namespace Ocean_Desk_dv.Services.Repository;

public sealed class CocinaRepository : ICocinaRepository
{
    private readonly OceanDeskDbContext _context;

    public CocinaRepository(OceanDeskDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IReadOnlyList<CocinaPedidoResumenDto> ObtenerPedidosActivos()
    {
        var db = _context;
        return db.KitchenOrders.AsNoTracking()
            .Include(k => k.Sale).ThenInclude(s => s.Table)
            .Where(k => k.Status == "Pending" || k.Status == "InPreparation" || k.Status == "Ready")
            .OrderBy(k => k.ReceptionDateTime)
            .Select(k => new CocinaPedidoResumenDto
            {
                KitchenOrderId = k.KitchenOrderId,
                SaleId = k.SaleId,
                Mesa = k.Sale.Table != null ? k.Sale.Table.TableNumber.ToString("00") : "N/A",
                TipoOrden = k.Sale.OrderType,
                Hora = k.ReceptionDateTime,
                Prioridad = k.Priority,
                Estado = k.Status
            }).ToList();
    }

    public CocinaPedidoCompletoDto? ObtenerPedido(int pedidoId)
    {
        var db = _context;
        var pedido = db.KitchenOrders.AsNoTracking()
            .Include(k => k.Sale).ThenInclude(s => s.Table)
            .Include(k => k.KitchenOrderDetails).ThenInclude(d => d.SaleDetail).ThenInclude(sd => sd.Product)
            .FirstOrDefault(k => k.KitchenOrderId == pedidoId);
        if (pedido is null) return null;
        return new CocinaPedidoCompletoDto
        {
            Pedido = new CocinaPedidoSeleccionadoDto
            {
                KitchenOrderId = pedido.KitchenOrderId,
                Mesa = pedido.Sale.Table != null ? pedido.Sale.Table.TableNumber.ToString("00") : "N/A",
                TipoOrden = pedido.Sale.OrderType,
                Hora = pedido.ReceptionDateTime,
                Prioridad = pedido.Priority,
                Estado = pedido.Status
            },
            Detalles = pedido.KitchenOrderDetails.OrderBy(d => d.KitchenOrderDetailId)
                .Select(d => new CocinaPedidoDetalleDto
                {
                    Cantidad = d.Quantity,
                    Producto = d.SaleDetail.Product.ProductName,
                    Observaciones = d.Notes ?? d.SaleDetail.Notes ?? string.Empty
                }).ToList()
        };
    }

    public string? ObtenerEstadoPedido(int pedidoId)
    {
        var db = _context;
        return db.KitchenOrders.AsNoTracking().Where(k => k.KitchenOrderId == pedidoId).Select(k => k.Status).FirstOrDefault();
    }

    public ResultadoOperacionDto CambiarEstado(int pedidoId, string estadoEsperado, string nuevoEstado, DateTime fechaCambio)
    {
        var db = _context;
        var pedido = db.KitchenOrders.FirstOrDefault(k => k.KitchenOrderId == pedidoId);
        if (pedido is null) return ResultadoOperacionDto.Fallido("No se encontró el pedido seleccionado.");
        if (pedido.Status != estadoEsperado)
            return ResultadoOperacionDto.Fallido($"El pedido no puede pasar a '{nuevoEstado}' porque su estado actual es '{pedido.Status}'.");

        pedido.Status = nuevoEstado;
        if (nuevoEstado == "InPreparation") pedido.PreparationStartDateTime = fechaCambio;
        else if (nuevoEstado == "Ready") pedido.ReadyDateTime = fechaCambio;
        else if (nuevoEstado == "Delivered") pedido.DeliveredDateTime = fechaCambio;
        db.SaveChanges();
        return ResultadoOperacionDto.Correcto();
    }

    public ResultadoOperacionDto CancelarPedido(int pedidoId, string motivo, string estadoEsperado)
    {
        var db = _context;
        var pedido = db.KitchenOrders.FirstOrDefault(k => k.KitchenOrderId == pedidoId);
        if (pedido is null) return ResultadoOperacionDto.Fallido("El pedido seleccionado ya no existe.");
        if (pedido.Status != estadoEsperado) return ResultadoOperacionDto.Fallido("El pedido cambió de estado. Actualice la lista e inténtelo nuevamente.");
        pedido.Status = "Cancelled";
        string motivoLimpio = $"[Cancellation reason: {motivo.Trim()}]";
        string notas = string.IsNullOrWhiteSpace(pedido.Notes) ? string.Empty : pedido.Notes.Trim();
        if (!notas.Contains(motivoLimpio, StringComparison.OrdinalIgnoreCase))
            pedido.Notes = string.IsNullOrWhiteSpace(notas) ? motivoLimpio : $"{notas} {motivoLimpio}";
        db.SaveChanges();
        return ResultadoOperacionDto.Correcto("El pedido fue cancelado correctamente.");
    }
    public void Dispose() => _context.Dispose();

}
