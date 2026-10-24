using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;
using System.Data;
using Microsoft.EntityFrameworkCore;
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
        private const decimal StockMaximo = 99999999.9999m;
        private const int DiasAlertaVencimiento = 30;

        private readonly OceanDeskDbContext _context;

        /// <summary>
        /// Inicializa el repositorio con su contexto de base de datos.
        /// </summary>
        /// <param name="context">Contexto de Ocean Desk.</param>
        public InventarioRepository(OceanDeskDbContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }
        private static string ObtenerDetalleExcepcion(Exception ex)
        {
            var detalles = new List<string>();

            Exception? actual = ex;

            while (actual is not null)
            {
                detalles.Add(
                    $"{actual.GetType().Name}: {actual.Message}");

                actual = actual.InnerException;
            }

            return string.Join(" --> ", detalles);
        }

        // ============================================================
        // 1. CONSULTA DE EXISTENCIAS
        // ============================================================

        /// <summary>
        /// Obtiene las existencias de ingredientes aplicando los filtros
        /// de búsqueda, categoría, stock y vencimiento.
        /// </summary>
        /// <param name="filtro">Criterios de búsqueda del inventario.</param>
        /// <returns>Existencias preparadas para la interfaz.</returns>
        public IReadOnlyList<ExistenciaInventarioDto> ObtenerExistencias(
            FiltroExistenciasInventarioDto filtro)
        {
            filtro ??= new FiltroExistenciasInventarioDto();

            // Consultar únicamente ingredientes activos.
            // El estado de vencimiento se calcula a partir de sus lotes,
            // no desde la entidad Product.
            IQueryable<Product> consulta = _context.Products
                .AsNoTracking()
                .Where(p =>
                    p.ProductType == "Ingredient" &&
                    p.IsActive);

            // Filtro por código o nombre.
            if (!string.IsNullOrWhiteSpace(filtro.TextoBusqueda))
            {
                string texto = filtro.TextoBusqueda.Trim();

                consulta = consulta.Where(p =>
                    p.ProductCode.Contains(texto) ||
                    p.ProductName.Contains(texto));
            }

            // Filtro por categoría.
            if (!EsFiltroAplicable(filtro.Categoria))
            {
                string categoria = filtro.Categoria!.Trim();

                consulta = consulta.Where(p =>
                    p.ProductCategory.CategoryName == categoria);
            }

            // Obtener los datos base de los productos.
            // Los ingredientes sin registro Inventory se muestran con stock 0.
            var productosBase = consulta
                .OrderBy(p => p.ProductCode)
                .Select(p => new
                {
                    p.ProductId,
                    p.ProductCode,
                    p.ProductName,
                    CategoryName = p.ProductCategory.CategoryName,

                    UnitName = p.UnitOfMeasure != null
                        ? p.UnitOfMeasure.UnitName
                        : "Sin unidad",

                    CurrentStock = p.Inventory != null
                        ? p.Inventory.CurrentStock
                        : 0m,

                    MinimumStock = p.Inventory != null
                        ? p.Inventory.MinimumStock
                        : 0m
                })
                .ToList();

            // Evitar consultar los lotes si no hay productos.
            if (productosBase.Count == 0)
                return Array.Empty<ExistenciaInventarioDto>();

            List<int> productoIds = productosBase
                .Select(p => p.ProductId)
                .ToList();

            // Buscar lotes con saldo y fecha de vencimiento conocida.
            // El orden permite obtener el vencimiento más próximo de cada
            // producto, incluyendo lotes que ya vencieron pero conservan saldo.
            var lotesConVencimiento = _context.InventoryLots
                .AsNoTracking()
                .Where(l =>
                    productoIds.Contains(l.ProductId) &&
                    l.IsActive &&
                    l.RemainingQuantity > 0m &&
                    l.ExpirationDate.HasValue)
                .OrderBy(l => l.ExpirationDate)
                .ThenBy(l => l.ReceivedAt)
                .ThenBy(l => l.InventoryLotId)
                .Select(l => new
                {
                    l.ProductId,
                    l.ExpirationDate
                })
                .ToList();

            var vencimientosPorProducto = new Dictionary<int, DateOnly>();

            foreach (var lote in lotesConVencimiento)
            {
                if (!lote.ExpirationDate.HasValue)
                    continue;

                if (!vencimientosPorProducto.ContainsKey(lote.ProductId))
                {
                    vencimientosPorProducto[lote.ProductId] =
                        lote.ExpirationDate.Value;
                }
            }

            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);
            DateOnly limiteVencimiento =
                hoy.AddDays(DiasAlertaVencimiento);

            var resultados = new List<ExistenciaInventarioDto>();

            foreach (var producto in productosBase)
            {
                DateOnly? vencimiento = vencimientosPorProducto.TryGetValue(
                    producto.ProductId,
                    out DateOnly fecha)
                        ? fecha
                        : null;

                string estadoStock = ObtenerEstadoStock(
                    producto.CurrentStock,
                    producto.MinimumStock);

                string estadoVencimiento = ObtenerEstadoVencimiento(
                    vencimiento,
                    hoy,
                    limiteVencimiento);

                // Filtrar por estado de existencias.
                if (!EsFiltroAplicable(filtro.EstadoStock) &&
                    !string.Equals(
                        estadoStock,
                        filtro.EstadoStock!.Trim(),
                        StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // El diseñador utiliza "Vencidos" en plural,
                // mientras que el estado individual se llama "Vencido".
                if (!CoincideFiltroVencimiento(
                    filtro.EstadoVencimiento,
                    estadoVencimiento))
                {
                    continue;
                }

                resultados.Add(new ExistenciaInventarioDto
                {
                    ProductId = producto.ProductId,
                    ProductCode = producto.ProductCode,
                    ProductName = producto.ProductName,
                    CategoryName = producto.CategoryName,
                    UnitName = producto.UnitName,
                    CurrentStock = producto.CurrentStock,
                    MinimumStock = producto.MinimumStock,
                    StockStatus = estadoStock,
                    ExpirationDate = vencimiento,
                    ExpirationStatus = estadoVencimiento
                });
            }

            return resultados;
        }

        // ============================================================
        // 2. CONSULTA DE CATEGORÍAS
        // ============================================================

        /// <summary>
        /// Obtiene las categorías que tienen ingredientes activos.
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

        // ============================================================
        // 3. SELECTOR DE INGREDIENTES
        // ============================================================

        /// <summary>
        /// Obtiene los ingredientes activos que tienen una unidad
        /// de medida activa, para registrar movimientos.
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

        // ============================================================
        // 4. HISTORIAL DE MOVIMIENTOS
        // ============================================================

        /// <summary>
        /// Obtiene los movimientos del intervalo solicitado,
        /// aplicando los filtros por tipo y producto.
        /// </summary>
        public IReadOnlyList<MovimientoInventarioDto> ObtenerMovimientos(
            FiltroMovimientosInventarioDto filtro)
        {
            if (filtro is null ||
                filtro.Hasta.Date < filtro.Desde.Date)
            {
                return Array.Empty<MovimientoInventarioDto>();
            }

            DateTime desde = filtro.Desde.Date;
            DateTime hastaExclusivo = filtro.Hasta.Date.AddDays(1);

            IQueryable<InventoryMovement> consulta =
                _context.InventoryMovements
                    .AsNoTracking()
                    .Where(m =>
                        m.MovementDateTime >= desde &&
                        m.MovementDateTime < hastaExclusivo);

            // El tipo recibido debe coincidir con el valor almacenado.
            if (!string.IsNullOrWhiteSpace(filtro.TipoMovimiento) &&
                !string.Equals(
                    filtro.TipoMovimiento.Trim(),
                    "Todos",
                    StringComparison.OrdinalIgnoreCase))
            {
                string tipo = filtro.TipoMovimiento.Trim();

                consulta = consulta.Where(m =>
                    m.MovementType == tipo);
            }

            // Filtro de texto aplicado al producto del movimiento.
            if (!string.IsNullOrWhiteSpace(filtro.TextoBusqueda))
            {
                string texto = filtro.TextoBusqueda.Trim();

                consulta = consulta.Where(m =>
                    m.Product.ProductCode.Contains(texto) ||
                    m.Product.ProductName.Contains(texto));
            }

            // Proyectar primero los campos que dependen de SQL Server.
            var registros = consulta
                .OrderByDescending(m => m.MovementDateTime)
                .ThenByDescending(m => m.InventoryMovementId)
                .Select(m => new
                {
                    m.InventoryMovementId,
                    m.MovementDateTime,
                    m.MovementType,
                    ProductName = m.Product.ProductName,

                    Quantity = m.Quantity,

                    UnitName = m.Product.UnitOfMeasure != null
                        ? m.Product.UnitOfMeasure.UnitName
                        : "Sin unidad",

                    m.SaleId,
                    m.ReferenceType,
                    m.ReferenceId,

                    LotCode = m.InventoryLot != null
                        ? m.InventoryLot.LotCode
                        : null,

                    m.Notes,
                    m.StockBefore,
                    m.StockAfter
                })
                .ToList();

            // Traducir los valores y preparar los DTO fuera de la consulta SQL.
            return registros
                .Select(m => new MovimientoInventarioDto
                {
                    InventoryMovementId = m.InventoryMovementId,
                    MovementDateTime = m.MovementDateTime,
                    MovementType = TraducirTipoMovimiento(m.MovementType),
                    ProductName = m.ProductName,
                    Quantity = m.Quantity,
                    UnitName = m.UnitName,
                    Source = ObtenerOrigen(
                        m.SaleId,
                        m.ReferenceType,
                        m.ReferenceId),
                    LotCode = m.LotCode,
                    Notes = m.Notes,
                    StockBefore = m.StockBefore,
                    StockAfter = m.StockAfter
                })
                .ToList();
        }

        // ============================================================
        // 5. REGISTRO DE MOVIMIENTOS
        // ============================================================

        /// <summary>
        /// Actualiza el umbral de stock mínimo de un ingrediente.
        /// No modifica el stock actual, los lotes ni el historial de movimientos.
        /// </summary>
        public ResultadoOperacionDto ActualizarStockMinimo(
            int productId,
            decimal stockMinimo)
        {
            if (productId <= 0)
            {
                return ResultadoOperacionDto.Fallido(
                    "Seleccione un ingrediente válido.");
            }

            if (stockMinimo < 0m || stockMinimo > StockMaximo)
            {
                return ResultadoOperacionDto.Fallido(
                    "El stock mínimo debe estar entre cero y el máximo permitido.");
            }

            if (decimal.Round(stockMinimo, 4) != stockMinimo)
            {
                return ResultadoOperacionDto.Fallido(
                    "El stock mínimo admite como máximo cuatro decimales.");
            }

            Product? producto = _context.Products.FirstOrDefault(p =>
                p.ProductId == productId &&
                p.ProductType == "Ingredient" &&
                p.IsActive);

            if (producto is null)
            {
                return ResultadoOperacionDto.Fallido(
                    "El ingrediente no existe o está inactivo.");
            }

            try
            {
                Inventory? inventario = _context.Inventories
                    .FirstOrDefault(i => i.ProductId == productId);

                if (inventario is null)
                {
                    // Si el ingrediente todavía no tiene registro Inventory,
                    // se crea con el stock que actualmente representa el sistema: cero.
                    inventario = new Inventory
                    {
                        ProductId = producto.ProductId,
                        Product = producto,
                        CurrentStock = 0m,
                        MinimumStock = stockMinimo,
                        UpdatedAt = DateTime.Now
                    };

                    _context.Inventories.Add(inventario);
                }
                else
                {
                    // Solo cambia el umbral; el stock actual permanece intacto.
                    inventario.MinimumStock = stockMinimo;
                    inventario.UpdatedAt = DateTime.Now;
                }

                _context.SaveChanges();

                return ResultadoOperacionDto.Correcto(
                    "El stock mínimo se guardó correctamente.");
            }
            catch (DbUpdateException ex)
            {
                string detalle = ObtenerDetalleExcepcion(ex);

                _context.ChangeTracker.Clear();

                System.Diagnostics.Debug.WriteLine(ex.ToString());

                return ResultadoOperacionDto.Fallido(
                    $"No se pudo guardar el stock mínimo. Detalle técnico: {detalle}");
            }
        }

        /// <summary>
        /// Registra una entrada, salida, ajuste o pérdida.
        /// Actualiza los lotes, el saldo total y el historial dentro
        /// de una sola transacción.
        /// </summary>
        public ResultadoOperacionDto RegistrarMovimiento(
            SolicitudMovimientoInventarioDto solicitud)
        {
            if (solicitud is null)
            {
                return ResultadoOperacionDto.Fallido(
                    "No se recibieron datos para registrar el movimiento.");
            }

            string tipo = solicitud.MovementType?.Trim() ?? string.Empty;

            if (solicitud.ProductId <= 0)
            {
                return ResultadoOperacionDto.Fallido(
                    "Seleccione un ingrediente válido.");
            }

            if (!EsTipoMovimientoManualValido(tipo))
            {
                return ResultadoOperacionDto.Fallido(
                    "El tipo de movimiento no está permitido para el registro manual.");
            }

            bool esAjuste =
                tipo == TiposMovimientoInventario.Ajuste;

            // Los ajustes representan el stock final deseado.
            if (esAjuste)
            {
                if (solicitud.Quantity < 0m)
                {
                    return ResultadoOperacionDto.Fallido(
                        "El stock final no puede ser negativo.");
                }
            }
            else if (solicitud.Quantity <= 0m)
            {
                return ResultadoOperacionDto.Fallido(
                    "La cantidad debe ser mayor que cero.");
            }

            if (!TieneMaximoCuatroDecimales(solicitud.Quantity))
            {
                return ResultadoOperacionDto.Fallido(
                    "La cantidad admite como máximo cuatro decimales.");
            }

            if (solicitud.Quantity > StockMaximo)
            {
                return ResultadoOperacionDto.Fallido(
                    "La cantidad supera el máximo permitido por el inventario.");
            }

            if ((solicitud.Notes?.Length ?? 0) > 500)
            {
                return ResultadoOperacionDto.Fallido(
                    "Las observaciones no pueden superar los 500 caracteres.");
            }

            string? codigoLote =
                string.IsNullOrWhiteSpace(solicitud.LotCode)
                    ? null
                    : solicitud.LotCode.Trim();

            if ((codigoLote?.Length ?? 0) > 50)
            {
                return ResultadoOperacionDto.Fallido(
                    "El código de lote no puede superar los 50 caracteres.");
            }

            string? notas =
                string.IsNullOrWhiteSpace(solicitud.Notes)
                    ? null
                    : solicitud.Notes.Trim();

            if ((tipo == TiposMovimientoInventario.Perdida ||
                 esAjuste) &&
                string.IsNullOrWhiteSpace(notas))
            {
                return ResultadoOperacionDto.Fallido(
                    "Indique el motivo del ajuste o de la pérdida.");
            }

            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);

            // Las entradas y los ajustes que aumentan el stock
            // no deben incorporar existencias con vencimiento pasado.
            if ((tipo == TiposMovimientoInventario.Entrada ||
                 esAjuste) &&
                solicitud.ExpirationDate.HasValue &&
                solicitud.ExpirationDate.Value < hoy)
            {
                return ResultadoOperacionDto.Fallido(
                    "No se puede incorporar un lote con fecha de vencimiento pasada.");
            }

            try
            {
                // La transacción serializable evita que dos operaciones
                // concurrentes calculen saldos incompatibles.
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
                {
                    return ResultadoOperacionDto.Fallido(
                        "El ingrediente no existe o está inactivo.");
                }

                if (producto.UnitOfMeasure is null ||
                    !producto.UnitOfMeasure.IsActive)
                {
                    return ResultadoOperacionDto.Fallido(
                        "El ingrediente no tiene una unidad de medida activa.");
                }

                Inventory? inventario = producto.Inventory;

                decimal stockAntes =
                    inventario?.CurrentStock ?? 0m;

                List<InventoryLot> lotes = _context.InventoryLots
                    .Where(l => l.ProductId == producto.ProductId)
                    .OrderBy(l => l.ExpirationDate.HasValue ? 0 : 1)
                    .ThenBy(l => l.ExpirationDate)
                    .ThenBy(l => l.ReceivedAt)
                    .ThenBy(l => l.InventoryLotId)
                    .ToList();

                // El saldo consolidado debe coincidir con los lotes.
                decimal saldoLotes =
                    lotes.Sum(l => l.RemainingQuantity);

                if (saldoLotes != stockAntes)
                {
                    return ResultadoOperacionDto.Fallido(
                        "El stock consolidado no coincide con los saldos de los lotes. " +
                        "Debe conciliarse el inventario antes de registrar este movimiento.");
                }

                if (lotes.Any(l =>
                    !l.IsActive &&
                    l.RemainingQuantity > 0m))
                {
                    return ResultadoOperacionDto.Fallido(
                        "Existe un lote inactivo con saldo positivo. " +
                        "Debe revisarse antes de continuar.");
                }

                // Un ajuste que no modifica el saldo no debe generar movimientos.
                if (esAjuste &&
                    solicitud.Quantity == stockAntes)
                {
                    return ResultadoOperacionDto.Fallido(
                        "El stock indicado coincide con el actual. No se requiere un ajuste.");
                }

                var movimientos = new List<InventoryMovement>();
                decimal stockDespues = stockAntes;

                // ----------------------------------------------------
                // ENTRADA
                // ----------------------------------------------------
                if (tipo == TiposMovimientoInventario.Entrada)
                {
                    decimal nuevoStock = stockAntes + solicitud.Quantity;

                    if (nuevoStock > StockMaximo)
                    {
                        return ResultadoOperacionDto.Fallido(
                            "La entrada supera el máximo de stock permitido.");
                    }

                    InventoryLot lote = ObtenerOCrearLoteEntrada(
                        producto,
                        lotes,
                        codigoLote,
                        solicitud.ExpirationDate,
                        solicitud.Quantity,
                        notas,
                        hoy);

                    stockDespues = nuevoStock;

                    movimientos.Add(CrearMovimiento(
                        producto.ProductId,
                        tipo,
                        solicitud.Quantity,
                        stockAntes,
                        stockDespues,
                        lote,
                        notas));
                }

                // ----------------------------------------------------
                // AJUSTE ASCENDENTE
                // ----------------------------------------------------
                else if (esAjuste &&
                         solicitud.Quantity > stockAntes)
                {
                    decimal diferencia =
                        solicitud.Quantity - stockAntes;

                    InventoryLot lote = ObtenerOCrearLoteEntrada(
                        producto,
                        lotes,
                        codigoLote,
                        solicitud.ExpirationDate,
                        diferencia,
                        notas,
                        hoy);

                    stockDespues = solicitud.Quantity;

                    movimientos.Add(CrearMovimiento(
                        producto.ProductId,
                        tipo,
                        diferencia,
                        stockAntes,
                        stockDespues,
                        lote,
                        notas));
                }

                // ----------------------------------------------------
                // SALIDA, PÉRDIDA Y AJUSTE DESCENDENTE
                // ----------------------------------------------------
                else
                {
                    bool esSalida =
                        tipo == TiposMovimientoInventario.Salida;

                    bool esPerdida =
                        tipo == TiposMovimientoInventario.Perdida;

                    decimal cantidadAConsumir = esAjuste
                        ? stockAntes - solicitud.Quantity
                        : solicitud.Quantity;

                    if (cantidadAConsumir > stockAntes)
                    {
                        return ResultadoOperacionDto.Fallido(
                            "La operación supera las existencias registradas.");
                    }

                    if (cantidadAConsumir <= 0m)
                    {
                        return ResultadoOperacionDto.Fallido(
                            "La cantidad del movimiento debe ser mayor que cero.");
                    }

                    // Las salidas ordinarias no pueden consumir lotes vencidos.
                    // Las pérdidas y los ajustes descendentes sí pueden descontarlos.
                    List<InventoryLot> disponibles = lotes
                        .Where(l =>
                            l.IsActive &&
                            l.RemainingQuantity > 0m)
                        .Where(l =>
                            !esSalida ||
                            !l.ExpirationDate.HasValue ||
                            l.ExpirationDate.Value >= hoy)
                        .ToList();

                    decimal cantidadDisponible = disponibles.Sum(
                        l => l.RemainingQuantity);

                    if (cantidadAConsumir > cantidadDisponible)
                    {
                        return ResultadoOperacionDto.Fallido(
                            esSalida
                                ? "No hay cantidad suficiente en los lotes no vencidos para completar la salida."
                                : "No hay saldo suficiente en los lotes para completar la operación.");
                    }

                    decimal restante = cantidadAConsumir;

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

                        if (lote.RemainingQuantity == 0m)
                            lote.IsActive = false;

                        movimientos.Add(CrearMovimiento(
                            producto.ProductId,
                            tipo,
                            cantidad,
                            saldoAnterior,
                            saldoPosterior,
                            lote,
                            notas));
                    }

                    if (restante != 0m)
                    {
                        return ResultadoOperacionDto.Fallido(
                            "No se pudo completar el descuento de los lotes.");
                    }

                    // Asegura el resultado exacto solicitado para un ajuste.
                    if (esAjuste &&
                        stockDespues != solicitud.Quantity)
                    {
                        return ResultadoOperacionDto.Fallido(
                            "No fue posible alcanzar el stock final solicitado.");
                    }

                    // Salvaguarda para evitar que una rama produzca negativos.
                    if (stockDespues < 0m)
                    {
                        return ResultadoOperacionDto.Fallido(
                            "La operación produciría existencias negativas.");
                    }

                    // Las variables se conservan para distinguir con claridad
                    // los casos de salida y pérdida en futuras ampliaciones.
                    _ = esPerdida;
                }

                // ----------------------------------------------------
                // ACTUALIZAR STOCK CONSOLIDADO
                // ----------------------------------------------------
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

                // Registrar el historial dentro de la misma transacción.
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
                string detalle = ObtenerDetalleExcepcion(ex);

                // Evita conservar entidades modificadas tras una excepción
                // que haya provocado la reversión de la transacción.
                _context.ChangeTracker.Clear();

                System.Diagnostics.Debug.WriteLine(ex.ToString());

                return ResultadoOperacionDto.Fallido(
                    $"No se pudo registrar el movimiento. Detalle técnico: {detalle}");
            }
        }

        // ============================================================
        // 6. GESTIÓN DE LOTES
        // ============================================================

        /// <summary>
        /// Busca el lote indicado para una entrada o ajuste ascendente,
        /// o crea uno nuevo si no existe.
        /// </summary>
        private InventoryLot ObtenerOCrearLoteEntrada(
            Product producto,
            IReadOnlyList<InventoryLot> lotes,
            string? codigoLote,
            DateOnly? vencimiento,
            decimal cantidad,
            string? notas,
            DateOnly hoy)
        {
            InventoryLot? lote = null;

            if (!string.IsNullOrWhiteSpace(codigoLote))
            {
                lote = lotes.FirstOrDefault(l =>
                    string.Equals(
                        l.LotCode,
                        codigoLote,
                        StringComparison.OrdinalIgnoreCase));
            }

            if (lote is not null)
            {
                // No puede asignarse una fecha incompatible con la del lote.
                if (lote.ExpirationDate.HasValue &&
                    vencimiento.HasValue &&
                    lote.ExpirationDate.Value != vencimiento.Value)
                {
                    throw new InvalidOperationException(
                        "El código del lote ya existe con otra fecha de vencimiento.");
                }

                if (lote.ExpirationDate.HasValue &&
                    lote.ExpirationDate.Value < hoy)
                {
                    throw new InvalidOperationException(
                        "El lote existente está vencido y no puede recibir más existencias.");
                }

                // Si la fecha se desconocía y ahora se aporta, se completa.
                if (!lote.ExpirationDate.HasValue &&
                    vencimiento.HasValue)
                {
                    lote.ExpirationDate = vencimiento;
                }

                decimal saldoInicialNuevo = lote.InitialQuantity + cantidad;
                decimal saldoRestanteNuevo = lote.RemainingQuantity + cantidad;

                if (saldoInicialNuevo > StockMaximo ||
                    saldoRestanteNuevo > StockMaximo)
                {
                    throw new InvalidOperationException(
                        "La cantidad supera el máximo permitido para el lote.");
                }

                lote.InitialQuantity = saldoInicialNuevo;
                lote.RemainingQuantity = saldoRestanteNuevo;
                lote.IsActive = true;

                if (!string.IsNullOrWhiteSpace(notas))
                    lote.Notes = notas;

                return lote;
            }

            // Sin código de lote, cada entrada genera una partida independiente.
            var nuevoLote = new InventoryLot
            {
                ProductId = producto.ProductId,
                LotCode = codigoLote,
                ReceivedAt = DateTime.Now,
                ExpirationDate = vencimiento,
                InitialQuantity = cantidad,
                RemainingQuantity = cantidad,
                Notes = notas,
                IsActive = true,
                Product = producto
            };

            _context.InventoryLots.Add(nuevoLote);

            return nuevoLote;
        }

        /// <summary>
        /// Construye un movimiento de inventario para persistirlo.
        /// </summary>
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
                ReferenceId = null,
                SaleId = null,
                Notes = notas,
                MovementDateTime = DateTime.Now
            };
        }

        // ============================================================
        // 7. REGLAS DE PRESENTACIÓN Y VALIDACIÓN
        // ============================================================

        /// <summary>
        /// Calcula el estado del stock para la presentación en la interfaz.
        /// </summary>
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

        /// <summary>
        /// Calcula el estado de vencimiento a partir de la fecha disponible.
        /// </summary>
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

        /// <summary>
        /// Comprueba si el filtro representa una opción general sin restricción.
        /// </summary>
        private static bool EsFiltroAplicable(string? filtro)
        {
            return string.IsNullOrWhiteSpace(filtro) ||
                   filtro.StartsWith(
                       "Seleccione",
                       StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(
                       filtro.Trim(),
                       "Todos",
                       StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(
                       filtro.Trim(),
                       "Todas",
                       StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Compara el estado del vencimiento con el valor del ComboBox.
        /// Admite la opción "Vencidos" aunque el estado calculado sea "Vencido".
        /// </summary>
        private static bool CoincideFiltroVencimiento(
            string? filtro,
            string estado)
        {
            if (EsFiltroAplicable(filtro))
                return true;

            string valor = filtro!.Trim();

            if (string.Equals(
                valor,
                "Vencidos",
                StringComparison.OrdinalIgnoreCase))
            {
                return string.Equals(
                    estado,
                    "Vencido",
                    StringComparison.OrdinalIgnoreCase);
            }

            return string.Equals(
                estado,
                valor,
                StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Valida los tipos que pueden registrarse desde los botones manuales.
        /// Compra y Venta se reservan para sus respectivos procesos de negocio.
        /// </summary>
        private static bool EsTipoMovimientoManualValido(string tipo)
        {
            return tipo == TiposMovimientoInventario.Entrada ||
                   tipo == TiposMovimientoInventario.Salida ||
                   tipo == TiposMovimientoInventario.Ajuste ||
                   tipo == TiposMovimientoInventario.Perdida;
        }

        /// <summary>
        /// Comprueba que una cantidad pueda almacenarse con cuatro decimales.
        /// </summary>
        private static bool TieneMaximoCuatroDecimales(decimal cantidad)
        {
            return cantidad == decimal.Round(cantidad, 4);
        }

        /// <summary>
        /// Traduce el código almacenado a un texto de presentación en español.
        /// </summary>
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

        /// <summary>
        /// Obtiene el origen legible del movimiento.
        /// </summary>
        private static string ObtenerOrigen(
            int? ventaId,
            string? tipoReferencia,
            string? referenciaId)
        {
            if (ventaId.HasValue)
                return $"Venta #{ventaId.Value}";

            if (string.IsNullOrWhiteSpace(tipoReferencia) ||
                string.Equals(
                    tipoReferencia,
                    "Inventory",
                    StringComparison.OrdinalIgnoreCase))
            {
                return "Manual";
            }

            return string.IsNullOrWhiteSpace(referenciaId)
                ? tipoReferencia
                : $"{tipoReferencia} {referenciaId}";
        }

        // ============================================================
        // 8. LIBERACIÓN DE RECURSOS
        // ============================================================

        /// <summary>
        /// Libera el contexto de Entity Framework Core.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }


        public IReadOnlyList<UnidadMedidaDto> ObtenerUnidadesMedidaActivas()
        {
            return _context.UnitOfMeasures
                .AsNoTracking()
                .Where(u => u.IsActive)
                .OrderBy(u => u.UnitName)
                .Select(u => new UnidadMedidaDto
                {
                    UnitOfMeasureId = u.UnitOfMeasureId,
                    UnitCode = u.UnitCode,
                    UnitName = u.UnitName,
                    UnitSymbol = u.UnitSymbol
                })
                .ToList();
        }

        public IReadOnlyList<IngredienteSelectorDto> ObtenerIngredientesParaEntrada()
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
                .Select(p => new IngredienteSelectorDto
                {
                    ProductId = p.ProductId,
                    ProductCode = p.ProductCode,
                    ProductName = p.ProductName,
                    UnitOfMeasureId = p.UnitOfMeasureId,
                    UnitCode = p.UnitOfMeasure!.UnitCode,
                    UnitName = p.UnitOfMeasure.UnitName
                })
                .ToList();
        }

        /// <summary>
        /// Obtiene un código ING libre para mostrar una propuesta en el formulario.
        /// El repositorio vuelve a comprobar el código al guardar.
        /// </summary>
        public string? ObtenerSiguienteCodigoIngrediente()
        {
            List<string> codigos = _context.Products
                .AsNoTracking()
                .Select(p => p.ProductCode)
                .ToList();

            return CalcularCodigoDisponibleIngrediente(codigos);
        }

        private static string? CalcularCodigoDisponibleIngrediente(
            IEnumerable<string> codigos)
        {
            var existentes = new HashSet<string>(
                codigos,
                StringComparer.OrdinalIgnoreCase);

            for (int numero = 1; numero <= 999; numero++)
            {
                string candidato = $"ING-{numero:000}";

                if (!existentes.Contains(candidato))
                    return candidato;
            }

            return null;
        }

        /// <summary>
        /// Registra una entrada para un ingrediente existente o crea un nuevo
        /// ingrediente con inventario, lote y movimiento inicial.
        /// </summary>
        public ResultadoEntradaIngredienteDto RegistrarEntradaIngrediente(
            SolicitudEntradaIngredienteDto solicitud)
        {
            if (solicitud is null)
            {
                return ResultadoEntradaIngredienteDto.Fallido(
                    "No se recibieron datos para registrar la entrada.");
            }

            string nombre = solicitud.ProductName?.Trim() ?? string.Empty;
            string? notas = string.IsNullOrWhiteSpace(solicitud.Notes)
                ? null
                : solicitud.Notes.Trim();

            if (string.IsNullOrWhiteSpace(nombre) || nombre.Length > 150)
            {
                return ResultadoEntradaIngredienteDto.Fallido(
                    "El nombre del ingrediente es obligatorio y admite hasta 150 caracteres.");
            }

            if (solicitud.UnitOfMeasureId <= 0)
            {
                return ResultadoEntradaIngredienteDto.Fallido(
                    "Seleccione una unidad de medida válida.");
            }

            if (solicitud.Quantity <= 0m ||
                solicitud.Quantity > StockMaximo ||
                solicitud.Quantity != decimal.Round(solicitud.Quantity, 4))
            {
                return ResultadoEntradaIngredienteDto.Fallido(
                    "La cantidad debe ser positiva y admitir como máximo cuatro decimales.");
            }

            if ((notas?.Length ?? 0) > 250)
            {
                return ResultadoEntradaIngredienteDto.Fallido(
                    "Las observaciones de la entrada no pueden superar 250 caracteres.");
            }

            DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);

            if (solicitud.ExpirationDate.HasValue &&
                solicitud.ExpirationDate.Value < hoy)
            {
                return ResultadoEntradaIngredienteDto.Fallido(
                    "La fecha de vencimiento no puede estar en el pasado.");
            }

            // Caso 1: el usuario escribió un ingrediente existente.
            // Se conserva su código y su unidad; solo se registra el movimiento.
            if (solicitud.ProductId.HasValue)
            {
                Product? existente = _context.Products
                    .Include(p => p.UnitOfMeasure)
                    .FirstOrDefault(p =>
                        p.ProductId == solicitud.ProductId.Value &&
                        p.ProductType == "Ingredient" &&
                        p.IsActive);

                if (existente is null)
                {
                    return ResultadoEntradaIngredienteDto.Fallido(
                        "El ingrediente seleccionado no existe o está inactivo.");
                }

                if (!existente.UnitOfMeasureId.HasValue ||
                    existente.UnitOfMeasureId.Value != solicitud.UnitOfMeasureId ||
                    existente.UnitOfMeasure is null ||
                    !existente.UnitOfMeasure.IsActive)
                {
                    return ResultadoEntradaIngredienteDto.Fallido(
                        "La unidad no coincide con la unidad base del ingrediente.");
                }

                ResultadoOperacionDto movimiento = RegistrarMovimiento(
                    new SolicitudMovimientoInventarioDto
                    {
                        ProductId = existente.ProductId,
                        MovementType = TiposMovimientoInventario.Entrada,
                        Quantity = solicitud.Quantity,
                        LotCode = null,
                        ExpirationDate = solicitud.ExpirationDate,
                        Notes = notas
                    });

                if (!movimiento.Exito)
                {
                    return ResultadoEntradaIngredienteDto.Fallido(
                        movimiento.Mensaje);
                }

                return ResultadoEntradaIngredienteDto.Correcto(
                    $"Entrada registrada para {existente.ProductName} " +
                    $"({existente.ProductCode}). {movimiento.Mensaje}",
                    existente.ProductId,
                    existente.ProductCode);
            }

            // Caso 2: ingrediente nuevo. Toda la creación se realiza en
            // una transacción para evitar productos sin stock o movimientos huérfanos.
            try
            {
                using var transaccion =
                    _context.Database.BeginTransaction(
                        IsolationLevel.Serializable);

                // Un nombre existente debe seleccionarse desde el autocompletado.
                // Se comprueban todos los ingredientes, también los inactivos,
                // para no generar duplicados por nombre.
                List<string> nombresExistentes = _context.Products
                    .Where(p => p.ProductType == "Ingredient")
                    .Select(p => p.ProductName)
                    .ToList();

                if (nombresExistentes.Any(n =>
                    string.Equals(
                        n.Trim(),
                        nombre,
                        StringComparison.OrdinalIgnoreCase)))
                {
                    return ResultadoEntradaIngredienteDto.Fallido(
                        "Ya existe un ingrediente con ese nombre. " +
                        "Búsquelo en el campo de ingrediente y selecciónelo.");
                }

                UnitOfMeasure? unidad = _context.UnitOfMeasures
                    .FirstOrDefault(u =>
                        u.UnitOfMeasureId == solicitud.UnitOfMeasureId &&
                        u.IsActive);

                if (unidad is null)
                {
                    return ResultadoEntradaIngredienteDto.Fallido(
                        "La unidad de medida no existe o está inactiva.");
                }

                // Se calcula nuevamente dentro de la transacción. No se confía
                // exclusivamente en el código preliminar mostrado en pantalla.
                List<string> codigos = _context.Products
                    .Select(p => p.ProductCode)
                    .ToList();

                string? codigo = CalcularCodigoDisponibleIngrediente(codigos);

                if (codigo is null)
                {
                    return ResultadoEntradaIngredienteDto.Fallido(
                        "No hay códigos ING disponibles entre ING-001 e ING-999.");
                }

                // Buscar la categoría de ingredientes que usa el catálogo actual.
                ProductCategory? categoria = _context.ProductCategories
                    .FirstOrDefault(c =>
                        c.CategoryName == "Ingredients" ||
                        c.CategoryName == "Ingredientes");

                if (categoria is null)
                {
                    categoria = new ProductCategory
                    {
                        CategoryName = "Ingredients",
                        Description = "Ingredientes e insumos de cocina",
                        IsActive = true,
                        CreatedAt = DateTime.Now
                    };

                    _context.ProductCategories.Add(categoria);
                    _context.SaveChanges();
                }
                else if (!categoria.IsActive)
                {
                    categoria.IsActive = true;
                }

                DateTime ahora = DateTime.Now;

                var producto = new Product
                {
                    ProductCode = codigo,
                    ProductName = nombre,
                    Description = null,
                    ProductCategoryId = categoria.ProductCategoryId,
                    ProductCategory = categoria,
                    UnitOfMeasureId = unidad.UnitOfMeasureId,
                    UnitOfMeasure = unidad,
                    ProductType = "Ingredient",
                    UnitPrice = 0m,
                    IsAvailable = false,
                    IsActive = true,
                    CreatedAt = ahora
                };

                _context.Products.Add(producto);

                // Necesitamos el ProductId antes de crear los registros relacionados.
                _context.SaveChanges();

                var inventario = new Inventory
                {
                    ProductId = producto.ProductId,
                    Product = producto,
                    CurrentStock = solicitud.Quantity,
                    MinimumStock = 0m,
                    UpdatedAt = ahora
                };

                // La primera entrada recibe un lote inicial con código generado.
                var lote = new InventoryLot
                {
                    ProductId = producto.ProductId,
                    Product = producto,
                    LotCode = $"{codigo}-LOT01",
                    ReceivedAt = ahora,
                    ExpirationDate = solicitud.ExpirationDate,
                    InitialQuantity = solicitud.Quantity,
                    RemainingQuantity = solicitud.Quantity,
                    Notes = notas,
                    IsActive = true
                };

                var movimientoInicial = new InventoryMovement
                {
                    ProductId = producto.ProductId,
                    Product = producto,
                    MovementType = TiposMovimientoInventario.Entrada,
                    Quantity = solicitud.Quantity,
                    StockBefore = 0m,
                    StockAfter = solicitud.Quantity,
                    SaleId = null,
                    ReferenceType = "Inventory",
                    ReferenceId = null,
                    Notes = notas,
                    MovementDateTime = ahora,
                    InventoryLot = lote
                };

                _context.Inventories.Add(inventario);
                _context.InventoryLots.Add(lote);
                _context.InventoryMovements.Add(movimientoInicial);

                _context.SaveChanges();
                transaccion.Commit();

                return ResultadoEntradaIngredienteDto.Correcto(
                    $"Ingrediente {nombre} registrado correctamente con código {codigo}. " +
                    $"Stock inicial: {solicitud.Quantity:0.####} {unidad.UnitName}.",
                    producto.ProductId,
                    codigo);
            }
            catch (DbUpdateException ex)
            {
                string detalle = ObtenerDetalleExcepcion(ex);

                _context.ChangeTracker.Clear();

                System.Diagnostics.Debug.WriteLine(ex.ToString());

                return ResultadoEntradaIngredienteDto.Fallido(
                    $"No se pudo guardar el ingrediente. Detalle técnico: {detalle}");
            }
            catch (Exception ex)
            {
                string detalle = ObtenerDetalleExcepcion(ex);

                _context.ChangeTracker.Clear();

                System.Diagnostics.Debug.WriteLine(ex.ToString());

                return ResultadoEntradaIngredienteDto.Fallido(
                    $"No se pudo registrar la entrada. Detalle técnico: {detalle}");
            }
        }

    }
}

