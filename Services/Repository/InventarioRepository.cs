using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Services.Repository
{
    /// <summary>
    /// Implementa las consultas y operaciones de inventario mediante EF Core.
    /// </summary>
    public sealed class InventarioRepository : IInventarioRepository
    {
        private readonly OceanDeskDbContext _context;

        public InventarioRepository(OceanDeskDbContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Obtiene las existencias de ingredientes con sus estados de stock
        /// y la fecha de vencimiento más próxima entre los lotes con saldo.
        /// </summary>
        public IReadOnlyList<ExistenciaInventarioDto> ObtenerExistencias(
            FiltroExistenciasInventarioDto filtro)
        {
            filtro ??= new FiltroExistenciasInventarioDto();

            IQueryable<Product> consulta = _context.Products
                .AsNoTracking()
                .Where(p =>
                EsFiltroAplicable(filtro.EstadoVencimiento) ||
                (
                    string.Equals(
                        filtro.EstadoVencimiento?.Trim(),
                        "Vencidos",
                        StringComparison.OrdinalIgnoreCase)
                    && p.ExpirationStatus == "Vencido"
                ) ||
                string.Equals(
                    p.ExpirationStatus,
                    filtro.EstadoVencimiento?.Trim(),
                    StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(filtro.TextoBusqueda))
            {
                string texto = filtro.TextoBusqueda.Trim();

                consulta = consulta.Where(p =>
                    p.ProductCode.Contains(texto) ||
                    p.ProductName.Contains(texto));
            }

            if (!string.IsNullOrWhiteSpace(filtro.Categoria) &&
                !filtro.Categoria.StartsWith("Seleccione",
                    StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(filtro.Categoria, "Todas",
                    StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(filtro.Categoria, "Todos",
                    StringComparison.OrdinalIgnoreCase))
            {
                string categoria = filtro.Categoria.Trim();

                consulta = consulta.Where(p =>
                    p.ProductCategory.CategoryName == categoria);
            }

            // La proyección incluye productos sin fila Inventory:
            // para ellos el stock presentado será cero.
            List<ExistenciaInventarioDto> registros = consulta
                .OrderBy(p => p.ProductName)
                .Select(p => new ExistenciaInventarioDto
                {
                    ProductId = p.ProductId,
                    ProductCode = p.ProductCode,
                    ProductName = p.ProductName,
                    CategoryName = p.ProductCategory.CategoryName,

                    UnitName = p.UnitOfMeasure != null
                        ? p.UnitOfMeasure.UnitName
                        : "Sin unidad",

                    CurrentStock = p.Inventory != null
                        ? p.Inventory.CurrentStock
                        : 0m,

                    MinimumStock = p.Inventory != null
                        ? p.Inventory.MinimumStock
                        : 0m,

                    ExpirationDate = _context.InventoryLots
                        .Where(l =>
                            l.ProductId == p.ProductId &&
                            l.IsActive &&
                            l.RemainingQuantity > 0m &&
                            l.ExpirationDate.HasValue)
                        .OrderBy(l => l.ExpirationDate)
                        .ThenBy(l => l.ReceivedAt)
                        .Select(l => l.ExpirationDate)
                        .FirstOrDefault()
                })
                .ToList();

            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);
            DateOnly limite = hoy.AddDays(30);

            // Los estados calculados se filtran después de proyectar los datos.
            List<ExistenciaInventarioDto> resultados = registros
                .Select(p =>
                {
                    string estadoStock = ObtenerEstadoStock(
                        p.CurrentStock,
                        p.MinimumStock);

                    string estadoVencimiento =
                        ObtenerEstadoVencimiento(
                            p.ExpirationDate,
                            hoy,
                            limite);

                    return new ExistenciaInventarioDto
                    {
                        ProductId = p.ProductId,
                        ProductCode = p.ProductCode,
                        ProductName = p.ProductName,
                        CategoryName = p.CategoryName,
                        UnitName = p.UnitName,
                        CurrentStock = p.CurrentStock,
                        MinimumStock = p.MinimumStock,
                        StockStatus = estadoStock,
                        ExpirationDate = p.ExpirationDate,
                        ExpirationStatus = estadoVencimiento
                    };
                })
                .Where(p =>
                    EsFiltroAplicable(filtro.EstadoStock) ||
                    string.Equals(
                        p.StockStatus,
                        filtro.EstadoStock?.Trim(),
                        StringComparison.OrdinalIgnoreCase))
                .Where(p =>
                    EsFiltroAplicable(filtro.EstadoVencimiento) ||
                    string.Equals(
                        p.ExpirationStatus,
                        filtro.EstadoVencimiento?.Trim(),
                        StringComparison.OrdinalIgnoreCase))
                .ToList();

            return resultados;
        }

        /// <summary>
        /// Obtiene las categorías de los ingredientes activos.
        /// </summary>
        public IReadOnlyList<string> ObtenerCategoriasInventario()
        {
            return _context.Products
                .AsNoTracking()
                .Where(p =>
                    p.ProductType == "Ingredient" &&
                    p.IsActive)
                .Select(p => p.ProductCategory.CategoryName)
                .Distinct()
                .OrderBy(nombre => nombre)
                .ToList();
        }

        /// <summary>
        /// Obtiene ingredientes activos con unidades de medida activas
        /// para utilizarlos en el registro de movimientos.
        /// </summary>
        public IReadOnlyList<ProductoInventarioSelectorDto>
            ObtenerIngredientesActivosParaMovimiento()
        {
            return _context.Products
                .AsNoTracking()
                .Where(p =>
                    p.ProductType == "Ingredient" &&
                    p.IsActive &&
                    p.UnitOfMeasureId.HasValue &&
                    p.UnitOfMeasure != null &&
                    p.UnitOfMeasure.IsActive)
                .OrderBy(p => p.ProductName)
                .Select(p => new ProductoInventarioSelectorDto
                {
                    ProductId = p.ProductId,
                    ProductCode = p.ProductCode,
                    ProductName = p.ProductName,
                    UnitName = p.UnitOfMeasure!.UnitName
                })
                .ToList();
        }

        /// <summary>
        /// Consulta los movimientos dentro del intervalo indicado.
        /// La fecha final es inclusiva para el usuario.
        /// </summary>
        public IReadOnlyList<MovimientoInventarioDto> ObtenerMovimientos(
            FiltroMovimientosInventarioDto filtro)
        {
            if (filtro is null || filtro.Hasta.Date < filtro.Desde.Date)
                return Array.Empty<MovimientoInventarioDto>();

            DateTime desde = filtro.Desde.Date;
            DateTime hastaExclusivo = filtro.Hasta.Date.AddDays(1);

            IQueryable<InventoryMovement> consulta =
                _context.InventoryMovements
                    .AsNoTracking()
                    .Where(m =>
                        m.MovementDateTime >= desde &&
                        m.MovementDateTime < hastaExclusivo);

            if (!string.IsNullOrWhiteSpace(filtro.TipoMovimiento) &&
                !string.Equals(
                    filtro.TipoMovimiento,
                    "Todos",
                    StringComparison.OrdinalIgnoreCase))
            {
                string tipo = filtro.TipoMovimiento.Trim();

                consulta = consulta.Where(m => m.MovementType == tipo);
            }

            if (!string.IsNullOrWhiteSpace(filtro.TextoBusqueda))
            {
                string texto = filtro.TextoBusqueda.Trim();

                consulta = consulta.Where(m =>
                    m.Product.ProductName.Contains(texto) ||
                    m.Product.ProductCode.Contains(texto));
            }

            var registros = consulta
                .OrderByDescending(m => m.MovementDateTime)
                .Select(m => new
                {
                    m.InventoryMovementId,
                    m.MovementDateTime,
                    m.MovementType,
                    m.Product.ProductName,
                    Quantity = m.Quantity,
                    UnitName = m.Product.UnitOfMeasure != null
                        ? m.Product.UnitOfMeasure.UnitName
                        : "Sin unidad",
                    Source = m.SaleId.HasValue
                        ? "Venta #" + m.SaleId.Value
                        : m.ReferenceType == null
                            ? "Manual"
                            : m.ReferenceId == null
                                ? m.ReferenceType
                                : m.ReferenceType + " " + m.ReferenceId,
                    LotCode = m.InventoryLot != null
                        ? m.InventoryLot.LotCode
                        : null,
                    m.Notes,
                    m.StockBefore,
                    m.StockAfter
                })
                .ToList();

            return registros.Select(m => new MovimientoInventarioDto
            {
                InventoryMovementId = m.InventoryMovementId,
                MovementDateTime = m.MovementDateTime,
                MovementType = TraducirTipoMovimiento(m.MovementType),
                ProductName = m.ProductName,
                Quantity = m.Quantity,
                UnitName = m.UnitName,
                Source = m.Source,
                LotCode = m.LotCode,
                Notes = m.Notes,
                StockBefore = m.StockBefore,
                StockAfter = m.StockAfter
            }).ToList();
        }

        /// <summary>
        /// Registra entradas, salidas, ajustes y pérdidas.
        /// Las existencias, lotes y movimientos se modifican en una transacción.
        /// </summary>
        public ResultadoOperacionDto RegistrarMovimiento(
            SolicitudMovimientoInventarioDto solicitud)
        {
            if (solicitud is null)
                return ResultadoOperacionDto.Fallido(
                    "No se recibieron datos para el movimiento.");

            string tipo = solicitud.MovementType?.Trim() ?? string.Empty;

            if (solicitud.ProductId <= 0)
                return ResultadoOperacionDto.Fallido(
                    "Seleccione un ingrediente válido.");

            if (tipo != TiposMovimientoInventario.Entrada &&
                tipo != TiposMovimientoInventario.Salida &&
                tipo != TiposMovimientoInventario.Ajuste &&
                tipo != TiposMovimientoInventario.Perdida)
            {
                return ResultadoOperacionDto.Fallido(
                    "El tipo de movimiento no está permitido para el registro manual.");
            }

            // En un ajuste se permite cero porque representa el stock final deseado.
            if (tipo == TiposMovimientoInventario.Ajuste)
            {
                if (solicitud.Quantity < 0m)
                    return ResultadoOperacionDto.Fallido(
                        "El stock final no puede ser negativo.");
            }
            else if (solicitud.Quantity <= 0m)
            {
                return ResultadoOperacionDto.Fallido(
                    "La cantidad debe ser mayor que cero.");
            }

            if ((solicitud.Notes?.Length ?? 0) > 500)
                return ResultadoOperacionDto.Fallido(
                    "Las observaciones no pueden superar los 500 caracteres.");

            string? codigoLote = string.IsNullOrWhiteSpace(solicitud.LotCode)
                ? null
                : solicitud.LotCode.Trim();

            if ((codigoLote?.Length ?? 0) > 50)
                return ResultadoOperacionDto.Fallido(
                    "El código del lote no puede superar los 50 caracteres.");

            string? notas = string.IsNullOrWhiteSpace(solicitud.Notes)
                ? null
                : solicitud.Notes.Trim();

            if ((tipo == TiposMovimientoInventario.Perdida ||
                 tipo == TiposMovimientoInventario.Ajuste) &&
                string.IsNullOrWhiteSpace(notas))
            {
                return ResultadoOperacionDto.Fallido(
                    "Indique el motivo del ajuste o de la pérdida.");
            }

            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);

            if (tipo == TiposMovimientoInventario.Entrada &&
                solicitud.ExpirationDate.HasValue &&
                solicitud.ExpirationDate.Value < hoy)
            {
                return ResultadoOperacionDto.Fallido(
                    "No se puede registrar una entrada con un lote vencido.");
            }

            try
            {
                // Evita que dos operaciones concurrentes calculen saldos incompatibles.
                using var transaccion =
                    _context.Database.BeginTransaction(
                        IsolationLevel.Serializable);

                Product? producto = _context.Products
                    .Include(p => p.Inventory)
                    .Include(p => p.UnitOfMeasure)
                    .FirstOrDefault(p =>
                        p.ProductId == solicitud.ProductId &&
                        p.ProductType == "Ingredient" &&
                        p.IsActive);

                if (producto is null)
                    return ResultadoOperacionDto.Fallido(
                        "El ingrediente no existe o está inactivo.");

                if (producto.UnitOfMeasure is null ||
                    !producto.UnitOfMeasure.IsActive)
                {
                    return ResultadoOperacionDto.Fallido(
                        "El ingrediente no tiene una unidad de medida activa.");
                }

                Inventory? inventario = producto.Inventory;

                decimal stockAntes = inventario?.CurrentStock ?? 0m;

                List<InventoryLot> lotes = _context.InventoryLots
                    .Where(l => l.ProductId == producto.ProductId)
                    .OrderBy(l => l.ExpirationDate.HasValue ? 0 : 1)
                    .ThenBy(l => l.ExpirationDate)
                    .ThenBy(l => l.ReceivedAt)
                    .ThenBy(l => l.InventoryLotId)
                    .ToList();

                decimal saldoLotes = lotes.Sum(l => l.RemainingQuantity);

                // No se permiten operaciones si el saldo consolidado y los lotes
                // ya se encuentran desincronizados; requiere conciliación previa.
                if (saldoLotes != stockAntes)
                {
                    return ResultadoOperacionDto.Fallido(
                        "El stock consolidado no coincide con el saldo de los lotes. " +
                        "Debe conciliarse el inventario antes de registrar este movimiento.");
                }

                // Un ajuste que no cambia el saldo no debe generar un movimiento vacío.
                if (tipo == TiposMovimientoInventario.Ajuste &&
                    solicitud.Quantity == stockAntes)
                {
                    return ResultadoOperacionDto.Fallido(
                        "El stock indicado coincide con el actual. No se requiere un ajuste.");
                }

                var movimientos = new List<InventoryMovement>();
                decimal stockDespues = stockAntes;

                if (tipo == TiposMovimientoInventario.Entrada)
                {
                    InventoryLot? loteExistente = null;

                    if (codigoLote is not null)
                    {
                        loteExistente = lotes.FirstOrDefault(l =>
                            string.Equals(
                                l.LotCode,
                                codigoLote,
                                StringComparison.OrdinalIgnoreCase));
                    }

                    if (loteExistente is not null &&
                        solicitud.ExpirationDate.HasValue &&
                        loteExistente.ExpirationDate != solicitud.ExpirationDate)
                    {
                        return ResultadoOperacionDto.Fallido(
                            "El código de lote ya existe con otra fecha de vencimiento.");
                    }

                    decimal cantidad = solicitud.Quantity;

                    if (loteExistente is null)
                    {
                        loteExistente = new InventoryLot
                        {
                            ProductId = producto.ProductId,
                            LotCode = codigoLote,
                            ReceivedAt = DateTime.Now,
                            ExpirationDate = solicitud.ExpirationDate,
                            InitialQuantity = cantidad,
                            RemainingQuantity = cantidad,
                            Notes = notas,
                            IsActive = true,
                            Product = producto
                        };

                        _context.InventoryLots.Add(loteExistente);
                    }
                    else
                    {
                        if (loteExistente.ExpirationDate.HasValue &&
                            loteExistente.ExpirationDate.Value < hoy)
                        {
                            return ResultadoOperacionDto.Fallido(
                                "El lote existente está vencido y no puede recibir nuevas cantidades.");
                        }

                        loteExistente.InitialQuantity += cantidad;
                        loteExistente.RemainingQuantity += cantidad;
                        loteExistente.IsActive = true;

                        if (!string.IsNullOrWhiteSpace(notas))
                            loteExistente.Notes = notas;
                    }

                    stockDespues = stockAntes + cantidad;

                    movimientos.Add(CrearMovimiento(
                        producto.ProductId,
                        tipo,
                        cantidad,
                        stockAntes,
                        stockDespues,
                        loteExistente,
                        notas));
                }
                else if (tipo == TiposMovimientoInventario.Ajuste &&
                         solicitud.Quantity > stockAntes)
                {
                    decimal diferencia = solicitud.Quantity - stockAntes;

                    InventoryLot? loteExistente = null;

                    if (codigoLote is not null)
                    {
                        loteExistente = lotes.FirstOrDefault(l =>
                            string.Equals(
                                l.LotCode,
                                codigoLote,
                                StringComparison.OrdinalIgnoreCase));
                    }

                    if (loteExistente is not null &&
                        solicitud.ExpirationDate.HasValue &&
                        loteExistente.ExpirationDate != solicitud.ExpirationDate)
                    {
                        return ResultadoOperacionDto.Fallido(
                            "El código de lote ya existe con otra fecha de vencimiento.");
                    }

                    if (loteExistente is null)
                    {
                        loteExistente = new InventoryLot
                        {
                            ProductId = producto.ProductId,
                            LotCode = codigoLote,
                            ReceivedAt = DateTime.Now,
                            ExpirationDate = solicitud.ExpirationDate,
                            InitialQuantity = diferencia,
                            RemainingQuantity = diferencia,
                            Notes = notas,
                            IsActive = true,
                            Product = producto
                        };

                        _context.InventoryLots.Add(loteExistente);
                    }
                    else
                    {
                        if (loteExistente.ExpirationDate.HasValue &&
                            loteExistente.ExpirationDate.Value < hoy)
                        {
                            return ResultadoOperacionDto.Fallido(
                                "No se puede incrementar un lote vencido.");
                        }

                        loteExistente.InitialQuantity += diferencia;
                        loteExistente.RemainingQuantity += diferencia;
                        loteExistente.IsActive = true;
                    }

                    stockDespues = solicitud.Quantity;

                    movimientos.Add(CrearMovimiento(
                        producto.ProductId,
                        tipo,
                        diferencia,
                        stockAntes,
                        stockDespues,
                        loteExistente,
                        notas));
                }
                else
                {
                    // Las salidas solo consumen lotes no vencidos.
                    // Las pérdidas pueden consumir también lotes vencidos.
                    IEnumerable<InventoryLot> lotesConsumibles = lotes
                        .Where(l => l.IsActive && l.RemainingQuantity > 0m);

                    if (tipo == TiposMovimientoInventario.Salida)
                    {
                        lotesConsumibles = lotesConsumibles.Where(l =>
                            !l.ExpirationDate.HasValue ||
                            l.ExpirationDate.Value >= hoy);
                    }

                    List<InventoryLot> disponibles = lotesConsumibles.ToList();

                    decimal cantidadDisponible = disponibles.Sum(
                        l => l.RemainingQuantity);

                    decimal cantidadAConsumir =
                        tipo == TiposMovimientoInventario.Ajuste
                            ? stockAntes - solicitud.Quantity
                            : solicitud.Quantity;

                    if (cantidadAConsumir > stockAntes)
                    {
                        return ResultadoOperacionDto.Fallido(
                            "La operación supera las existencias registradas.");
                    }

                    if (cantidadAConsumir > cantidadDisponible)
                    {
                        return ResultadoOperacionDto.Fallido(
                            "No hay saldo suficiente en los lotes permitidos para completar la operación.");
                    }

                    decimal restante = cantidadAConsumir;
                    stockDespues = stockAntes;

                    foreach (InventoryLot lote in disponibles)
                    {
                        if (restante <= 0m)
                            break;

                        decimal cantidad = Math.Min(
                            restante,
                            lote.RemainingQuantity);

                        decimal saldoAnterior = stockDespues;
                        decimal saldoPosterior = saldoAnterior - cantidad;

                        lote.RemainingQuantity -= cantidad;
                        restante -= cantidad;
                        stockDespues = saldoPosterior;

                        movimientos.Add(CrearMovimiento(
                            producto.ProductId,
                            tipo,
                            cantidad,
                            saldoAnterior,
                            saldoPosterior,
                            lote,
                            notas));
                    }

                    // En un ajuste descendente, el valor final tiene que coincidir
                    // exactamente con el stock solicitado.
                    if (tipo == TiposMovimientoInventario.Ajuste &&
                        stockDespues != solicitud.Quantity)
                    {
                        return ResultadoOperacionDto.Fallido(
                            "No fue posible alcanzar el stock final solicitado.");
                    }
                }

                if (inventario is null)
                {
                    inventario = new Inventory
                    {
                        ProductId = producto.ProductId,
                        CurrentStock = stockDespues,
                        MinimumStock = 0m,
                        UpdatedAt = DateTime.Now,
                        Product = producto
                    };

                    _context.Inventories.Add(inventario);
                    producto.Inventory = inventario;
                }
                else
                {
                    inventario.CurrentStock = stockDespues;
                    inventario.UpdatedAt = DateTime.Now;
                }

                _context.InventoryMovements.AddRange(movimientos);

                _context.SaveChanges();
                transaccion.Commit();

                return ResultadoOperacionDto.Correcto(
                    $"Movimiento registrado correctamente. " +
                    $"Stock anterior: {stockAntes:0.####}; " +
                    $"stock actual: {stockDespues:0.####}.");
            }
            catch (Exception ex)
            {
                return ResultadoOperacionDto.Fallido(
                    $"No se pudo registrar el movimiento. Detalle: {ex.Message}");
            }
        }

        private static InventoryMovement CrearMovimiento(
            int productoId,
            string tipo,
            decimal cantidad,
            decimal stockAntes,
            decimal stockDespues,
            InventoryLot lote,
            string? notas)
        {
            return new InventoryMovement
            {
                ProductId = productoId,
                MovementType = tipo,
                Quantity = cantidad,
                StockBefore = stockAntes,
                StockAfter = stockDespues,
                InventoryLot = lote,
                ReferenceType = "Inventory",
                Notes = notas,
                MovementDateTime = DateTime.Now
            };
        }

        private static string ObtenerEstadoStock(
            decimal stock,
            decimal minimo)
        {
            if (stock <= 0m)
                return "Agotado";

            if (stock <= minimo)
                return "Bajo";

            return "Normal";
        }

        private static string ObtenerEstadoVencimiento(
            DateOnly? vencimiento,
            DateOnly hoy,
            DateOnly limite)
        {
            if (!vencimiento.HasValue)
                return "Sin fecha";

            if (vencimiento.Value < hoy)
                return "Vencido";

            if (vencimiento.Value <= limite)
                return "Próximos a vencer";

            return "Normal";
        }

        private static bool EsFiltroAplicable(string? filtro)
        {
            return string.IsNullOrWhiteSpace(filtro) ||
                   filtro.StartsWith(
                       "Seleccione",
                       StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(filtro, "Todos",
                       StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(filtro, "Todas",
                       StringComparison.OrdinalIgnoreCase);
        }

        private static string TraducirTipoMovimiento(string tipo)
        {
            return tipo switch
            {
                TiposMovimientoInventario.Entrada => "Entrada",
                TiposMovimientoInventario.Salida => "Salida",
                TiposMovimientoInventario.Ajuste => "Ajuste",
                TiposMovimientoInventario.Perdida => "Pérdida/Dañado",
                TiposMovimientoInventario.Compra => "Compra",
                TiposMovimientoInventario.Venta => "Venta",
                _ => tipo
            };
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
