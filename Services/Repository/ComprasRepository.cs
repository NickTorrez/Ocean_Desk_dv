using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;
using System.Data;

namespace Ocean_Desk_dv.Services.Repository;

/// <summary>
/// Persistencia de compras. Recibir una compra actualiza Inventory,
/// crea lotes y registra movimientos en una sola transacción.
/// </summary>
public sealed class ComprasRepository : IComprasRepository
{
    private readonly OceanDeskDbContext _context;
    private bool _disposed;

    public ComprasRepository(OceanDeskDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IReadOnlyList<ProveedorCompraDto> ObtenerProveedoresActivos() =>
        _context.Suppliers.AsNoTracking()
            .Where(s => s.IsActive)
            .OrderBy(s => s.SupplierName)
            .Select(s => new ProveedorCompraDto
            {
                SupplierId = s.SupplierId,
                SupplierCode = s.SupplierCode,
                SupplierName = s.SupplierName,
                Phone = s.Phone
            }).ToList();

    public IReadOnlyList<ProductoCompraDto> ObtenerIngredientesActivos() =>
        _context.Products.AsNoTracking()
            .Where(p => p.IsActive && p.ProductType == "Ingredient" && p.UnitOfMeasureId != null)
            .OrderBy(p => p.ProductName)
            .Select(p => new ProductoCompraDto
            {
                UnitOfMeasureId = p.UnitOfMeasureId,
                ProductId = p.ProductId,
                ProductCode = p.ProductCode,
                ProductName = p.ProductName,
                UnitName = p.UnitOfMeasure != null ? p.UnitOfMeasure.UnitName : "Sin unidad",
                CurrentStock = p.Inventory != null ? p.Inventory.CurrentStock : 0m
            }).ToList();

    public IReadOnlyList<UnidadMedidaDto> ObtenerUnidadesMedidaActivas() =>
    _context.UnitOfMeasures
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

    public IReadOnlyList<CompraResumenDto> ObtenerCompras(FiltroComprasDto filtro)
    {
        IQueryable<Purchase> query = _context.Purchases.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(filtro.Texto))
        {
            string texto = filtro.Texto.Trim();
            query = query.Where(p =>
                p.PurchaseCode.Contains(texto) ||
                (p.DocumentNumber != null && p.DocumentNumber.Contains(texto)) ||
                p.Supplier.SupplierName.Contains(texto));
        }

        if (!string.IsNullOrWhiteSpace(filtro.Estado) &&
            !string.Equals(filtro.Estado, "Todas", StringComparison.OrdinalIgnoreCase))
        {
            string estado = filtro.Estado.Trim();
            query = query.Where(p => p.Status == estado);
        }

        if (filtro.Fecha.HasValue)
        {
            DateTime desde = filtro.Fecha.Value.Date;
            DateTime hasta = desde.AddDays(1);
            query = query.Where(p => p.PurchaseDate >= desde && p.PurchaseDate < hasta);
        }

        return query.OrderByDescending(p => p.PurchaseDate)
            .ThenByDescending(p => p.PurchaseId)
            .Select(p => new CompraResumenDto
            {
                PurchaseId = p.PurchaseId,
                PurchaseCode = p.PurchaseCode,
                PurchaseDate = p.PurchaseDate,
                SupplierId = p.SupplierId,
                SupplierName = p.Supplier.SupplierName,
                DocumentNumber = p.DocumentNumber,
                Status = p.Status,
                Subtotal = p.Subtotal,
                Total = p.Total,
                ReceivedDate = p.ReceivedDate,
                Notes = p.Notes
            }).ToList();
    }

    public CompraResumenDto? ObtenerCompra(int purchaseId) =>
        _context.Purchases.AsNoTracking()
            .Where(p => p.PurchaseId == purchaseId)
            .Select(p => new CompraResumenDto
            {
                PurchaseId = p.PurchaseId,
                PurchaseCode = p.PurchaseCode,
                PurchaseDate = p.PurchaseDate,
                SupplierId = p.SupplierId,
                SupplierName = p.Supplier.SupplierName,
                DocumentNumber = p.DocumentNumber,
                Status = p.Status,
                Subtotal = p.Subtotal,
                Total = p.Total,
                ReceivedDate = p.ReceivedDate,
                Notes = p.Notes
            }).FirstOrDefault();

    public IReadOnlyList<CompraDetalleDto> ObtenerDetalles(int purchaseId) =>
        _context.PurchaseDetails.AsNoTracking()
            .Where(d => d.PurchaseId == purchaseId)
            .OrderBy(d => d.PurchaseDetailId)
            .Select(d => new CompraDetalleDto
            {
                PurchaseDetailId = d.PurchaseDetailId,
                ProductId = d.ProductId,
                ProductCode = d.Product.ProductCode,
                ProductName = d.Product.ProductName,
                UnitName = d.Product.UnitOfMeasure != null ? d.Product.UnitOfMeasure.UnitName : "Sin unidad",
                Quantity = d.Quantity,
                UnitCost = d.UnitCost,
                Subtotal = d.Subtotal,
                ReceivedQuantity = d.ReceivedQuantity,
                LotCode = d.LotCode,
                ExpirationDate = d.ExpirationDate,
                Notes = d.Notes
            }).ToList();

    public ResultadoCompraDto RegistrarCompra(SolicitudCompraDto solicitud)
    {
        if (solicitud is null)
            return ResultadoCompraDto.Fallido(
                "No se recibieron los datos de la compra.");

        if (solicitud.SupplierId <= 0)
            return ResultadoCompraDto.Fallido(
                "Seleccione un proveedor válido.");

        if (solicitud.Details is null || solicitud.Details.Count == 0)
            return ResultadoCompraDto.Fallido(
                "Agregue al menos un producto a la compra.");

        if (solicitud.Details.Any(d =>
            string.IsNullOrWhiteSpace(d.ProductName) ||
            d.ProductName.Trim().Length > 150 ||
            d.UnitOfMeasureId <= 0 ||
            d.Quantity <= 0m ||
            d.Quantity > 99999999.9999m ||
            d.Quantity != decimal.Round(d.Quantity, 4) ||
            d.UnitCost < 0m ||
            d.UnitCost > 999999m ||
            d.UnitCost != decimal.Round(d.UnitCost, 4)))
        {
            return ResultadoCompraDto.Fallido(
                "Revise los productos: el nombre y la unidad son obligatorios, " +
                "la cantidad debe ser mayor que cero y el costo no puede ser negativo.");
        }

        if (solicitud.Details.Any(d =>
            (d.LotCode?.Length ?? 0) > 50 ||
            (d.Notes?.Length ?? 0) > 250))
        {
            return ResultadoCompraDto.Fallido(
                "El código del lote admite hasta 50 caracteres " +
                "y las observaciones hasta 250.");
        }

        DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);

        if (solicitud.Details.Any(d =>
            d.ExpirationDate.HasValue &&
            d.ExpirationDate.Value < hoy))
        {
            return ResultadoCompraDto.Fallido(
                "Una fecha de vencimiento no puede estar en el pasado.");
        }

        using var tx = _context.Database.BeginTransaction(
            IsolationLevel.Serializable);

        try
        {
            bool proveedorActivo = _context.Suppliers.Any(s =>
                s.SupplierId == solicitud.SupplierId &&
                s.IsActive);

            if (!proveedorActivo)
                return ResultadoCompraDto.Fallido(
                    "El proveedor seleccionado no existe o está inactivo.");

            // Comprobar que todas las unidades solicitadas existan y estén activas.
            List<int> unidadIds = solicitud.Details
                .Select(d => d.UnitOfMeasureId)
                .Distinct()
                .ToList();

            var unidadesActivas = _context.UnitOfMeasures
                .Where(u =>
                    unidadIds.Contains(u.UnitOfMeasureId) &&
                    u.IsActive)
                .ToDictionary(u => u.UnitOfMeasureId);

            if (unidadesActivas.Count != unidadIds.Count)
                return ResultadoCompraDto.Fallido(
                    "Una o más unidades de medida no existen o están inactivas.");

            // Incluye los ingredientes inactivos para evitar crear otro producto
            // con el mismo nombre cuando ya hay uno que debe revisarse.
            List<Product> ingredientes = _context.Products
                .Where(p => p.ProductType == "Ingredient")
                .ToList();

            var productosPorNombre =
                new Dictionary<string, Product>(
                    StringComparer.OrdinalIgnoreCase);

            var productosNuevosPendientes =
                new Dictionary<string, (string Nombre, int UnidadId)>(
                    StringComparer.OrdinalIgnoreCase);

            var lineasResueltas =
                new List<(DetalleCompraCapturaDto Detalle,
                          Product? Producto,
                          string Nombre)>();

            // Primero validar todas las líneas. Aún no se crea la compra
            // ni se escribe producto alguno.
            foreach (DetalleCompraCapturaDto detalle in solicitud.Details)
            {
                string nombre = detalle.ProductName.Trim();
                Product? producto = null;

                if (detalle.ProductId.HasValue)
                {
                    producto = ingredientes.FirstOrDefault(p =>
                        p.ProductId == detalle.ProductId.Value);

                    if (producto is null)
                        return ResultadoCompraDto.Fallido(
                            $"El producto '{nombre}' no corresponde a un ingrediente registrado.");
                }
                else if (productosPorNombre.TryGetValue(
                    nombre, out Product? productoEnCache))
                {
                    producto = productoEnCache;
                }
                else
                {
                    producto = ingredientes.FirstOrDefault(p =>
                        string.Equals(
                            p.ProductName.Trim(),
                            nombre,
                            StringComparison.OrdinalIgnoreCase));

                    if (producto is not null)
                    {
                        productosPorNombre[nombre] = producto;
                    }
                    else if (productosNuevosPendientes.TryGetValue(
                        nombre, out var pendiente))
                    {
                        if (pendiente.UnidadId != detalle.UnitOfMeasureId)
                            return ResultadoCompraDto.Fallido(
                                $"El producto '{nombre}' aparece con dos unidades de medida distintas.");
                    }
                    else
                    {
                        productosNuevosPendientes[nombre] =
                            (nombre, detalle.UnitOfMeasureId);
                    }
                }

                if (producto is not null)
                {
                    if (!producto.IsActive)
                        return ResultadoCompraDto.Fallido(
                            $"El ingrediente '{producto.ProductName}' está inactivo. " +
                            "Revíselo desde el catálogo antes de comprarlo.");

                    if (!producto.UnitOfMeasureId.HasValue ||
                        producto.UnitOfMeasureId.Value != detalle.UnitOfMeasureId)
                    {
                        return ResultadoCompraDto.Fallido(
                            $"La unidad de medida de '{producto.ProductName}' " +
                            "no coincide con su unidad registrada.");
                    }

                    productosPorNombre[nombre] = producto;
                }

                lineasResueltas.Add((detalle, producto, nombre));
            }

            decimal subtotal = Math.Round(
                solicitud.Details.Sum(d => d.Quantity * d.UnitCost),
                2,
                MidpointRounding.AwayFromZero);

            var compra = new Purchase
            {
                PurchaseCode = "TMP" + Guid.NewGuid().ToString("N")[..20],
                SupplierId = solicitud.SupplierId,
                PurchaseDate = solicitud.PurchaseDate,
                DocumentNumber = NormalizarTexto(solicitud.DocumentNumber),
                Status = EstadosCompra.Pendiente,
                Subtotal = subtotal,
                Total = subtotal,
                Notes = NormalizarTexto(solicitud.Notes),
                CreatedAt = DateTime.Now
            };

            _context.Purchases.Add(compra);
            _context.SaveChanges();

            compra.PurchaseCode =
                $"COMP-{compra.PurchaseDate:yyyy}-{compra.PurchaseId:000000}";

            var productosNuevos =
                new Dictionary<string, Product>(
                    StringComparer.OrdinalIgnoreCase);

            ProductCategory? categoriaIngredientes = null;

            // Crear una única entidad Product por cada nombre nuevo.
            // Varias líneas con diferentes lotes podrán referenciar
            // ese mismo ProductId.
            foreach (var pendiente in productosNuevosPendientes)
            {
                string? codigo = ObtenerSiguienteCodigoIngredienteDisponible();

                if (codigo is null)
                    throw new InvalidOperationException(
                        "No hay códigos ING disponibles entre ING-001 e ING-999.");

                categoriaIngredientes ??= ObtenerOCrearCategoriaIngredientes();

                UnitOfMeasure unidad =
                    unidadesActivas[pendiente.Value.UnidadId];

                var productoNuevo = new Product
                {
                    ProductCode = codigo,
                    ProductName = pendiente.Value.Nombre,
                    Description = null,
                    ProductCategoryId =
                        categoriaIngredientes.ProductCategoryId,
                    UnitOfMeasureId = unidad.UnitOfMeasureId,
                    ProductType = "Ingredient",
                    UnitPrice = 0m,
                    IsAvailable = false,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };

                _context.Products.Add(productoNuevo);
                _context.SaveChanges();

                productosNuevos[pendiente.Key] = productoNuevo;
            }

            // Crear los detalles de la compra usando el ID del producto
            // existente o el ID del producto que acaba de crearse.
            foreach (var linea in lineasResueltas)
            {
                Product producto = linea.Producto
                    ?? productosNuevos[linea.Nombre];

                decimal subtotalLinea = Math.Round(
                    linea.Detalle.Quantity * linea.Detalle.UnitCost,
                    2,
                    MidpointRounding.AwayFromZero);

                _context.PurchaseDetails.Add(new PurchaseDetail
                {
                    PurchaseId = compra.PurchaseId,
                    ProductId = producto.ProductId,
                    Quantity = linea.Detalle.Quantity,
                    UnitCost = linea.Detalle.UnitCost,
                    Subtotal = subtotalLinea,
                    ReceivedQuantity = 0m,
                    LotCode = NormalizarTexto(linea.Detalle.LotCode),
                    ExpirationDate = linea.Detalle.ExpirationDate,
                    Notes = NormalizarTexto(linea.Detalle.Notes)
                });
            }

            compra.Subtotal = subtotal;
            compra.Total = subtotal;
            compra.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
            tx.Commit();

            // Evitar que las siguientes operaciones del formulario reutilicen
            // entidades que pertenecieron a esta transacción.
            _context.ChangeTracker.Clear();

            return ResultadoCompraDto.Correcto(
                $"Compra {compra.PurchaseCode} guardada como pendiente de recepción.",
                compra.PurchaseId);
        }
        catch (Exception ex)
        {
            try
            {
                tx.Rollback();
            }
            catch
            {
                // La transacción podría haberse revertido ya.
            }

            _context.ChangeTracker.Clear();

            return ResultadoCompraDto.Fallido(
                $"No se pudo guardar la compra: {ex.GetBaseException().Message}");
        }
    }

    public ResultadoCompraDto RegistrarRecepcion(int purchaseId)
    {
        using var tx = _context.Database.BeginTransaction();
        try
        {
            Purchase? compra = _context.Purchases
                .Include(p => p.PurchaseDetails)
                .FirstOrDefault(p => p.PurchaseId == purchaseId);

            if (compra is null)
                return ResultadoCompraDto.Fallido("La compra seleccionada ya no existe.");
            if (compra.Status == EstadosCompra.Recibida)
                return ResultadoCompraDto.Fallido("Esta compra ya fue recibida; no se volverá a sumar al inventario.");
            if (compra.Status != EstadosCompra.Pendiente)
                return ResultadoCompraDto.Fallido("Solo se pueden recibir compras pendientes.");
            if (compra.PurchaseDetails.Count == 0)
                return ResultadoCompraDto.Fallido("La compra no tiene líneas para recibir.");

            // Validar códigos de lote repetidos dentro de la misma compra.
            // La restricción SQL es única por producto + código de lote.
            var codigosLoteSolicitud = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (PurchaseDetail detalle in compra.PurchaseDetails)
            {
                string? codigoValidar = NormalizarTexto(detalle.LotCode);
                if (codigoValidar is null)
                    continue;

                string clave = $"{detalle.ProductId}\u001f{codigoValidar}";
                if (!codigosLoteSolicitud.Add(clave))
                    throw new InvalidOperationException(
                        $"El lote '{codigoValidar}' se repite para el mismo ingrediente en la compra.");
            }

            // Conciliar una sola vez por ingrediente ANTES de agregar lotes nuevos.
            // Así se permiten varias líneas del mismo producto en una recepción,
            // sin comparar el stock en memoria con lotes que aún no se han guardado.
            foreach (int productId in compra.PurchaseDetails
                .Select(d => d.ProductId).Distinct())
            {
                Product productoValidacion = _context.Products
                    .AsNoTracking()
                    .First(p => p.ProductId == productId);

                decimal stockRegistrado = _context.Inventories.AsNoTracking()
                    .Where(i => i.ProductId == productId)
                    .Select(i => (decimal?)i.CurrentStock)
                    .FirstOrDefault() ?? 0m;

                decimal saldoLotesRegistrado = _context.InventoryLots.AsNoTracking()
                    .Where(l => l.ProductId == productId)
                    .Select(l => (decimal?)l.RemainingQuantity)
                    .Sum() ?? 0m;

                if (stockRegistrado != saldoLotesRegistrado)
                    throw new InvalidOperationException(
                        $"El stock de {productoValidacion.ProductName} ({stockRegistrado:0.####}) " +
                        $"no coincide con sus lotes ({saldoLotesRegistrado:0.####}). " +
                        "Concilie el inventario antes de recibir esta compra.");
            }

            DateTime ahora = DateTime.Now;
            foreach (PurchaseDetail detalle in compra.PurchaseDetails)
            {
                decimal cantidadRecibir = detalle.Quantity - detalle.ReceivedQuantity;
                if (cantidadRecibir <= 0m)
                    continue;

                Product producto = _context.Products
                    .First(p => p.ProductId == detalle.ProductId);
                if (producto.ProductType != "Ingredient" || !producto.IsActive)
                    throw new InvalidOperationException($"{producto.ProductName} ya no es un ingrediente activo.");

                Inventory? inventario = _context.Inventories
                    .FirstOrDefault(i => i.ProductId == detalle.ProductId);
                if (inventario is null)
                {
                    inventario = new Inventory
                    {
                        ProductId = detalle.ProductId,
                        CurrentStock = 0m,
                        MinimumStock = 0m,
                        UpdatedAt = ahora
                    };
                    _context.Inventories.Add(inventario);
                    _context.SaveChanges();
                }

                string? codigoLote = NormalizarTexto(detalle.LotCode);
                if (codigoLote is not null && _context.InventoryLots.Any(l =>
                    l.ProductId == detalle.ProductId && l.LotCode == codigoLote))
                    throw new InvalidOperationException($"El lote '{codigoLote}' ya existe para {producto.ProductName}. Use un código diferente.");

                decimal stockAntes = inventario.CurrentStock;
                decimal stockDespues = stockAntes + cantidadRecibir;
                var lote = new InventoryLot
                {
                    ProductId = detalle.ProductId,
                    LotCode = codigoLote,
                    ReceivedAt = ahora,
                    ExpirationDate = detalle.ExpirationDate,
                    InitialQuantity = cantidadRecibir,
                    RemainingQuantity = cantidadRecibir,
                    Notes = $"Recepción de compra {compra.PurchaseCode}" +
                            (string.IsNullOrWhiteSpace(detalle.Notes) ? string.Empty : $" — {detalle.Notes}"),
                    IsActive = true
                };
                _context.InventoryLots.Add(lote);
                inventario.CurrentStock = stockDespues;
                inventario.UpdatedAt = ahora;
                detalle.ReceivedQuantity += cantidadRecibir;

                _context.InventoryMovements.Add(new InventoryMovement
                {
                    ProductId = detalle.ProductId,
                    MovementType = TiposMovimientoInventario.Compra,
                    Quantity = cantidadRecibir,
                    StockBefore = stockAntes,
                    StockAfter = stockDespues,
                    SaleId = null,
                    ReferenceType = "Purchase",
                    ReferenceId = compra.PurchaseId.ToString(),
                    Notes = $"Recepción de compra {compra.PurchaseCode}",
                    MovementDateTime = ahora,
                    InventoryLot = lote
                });
            }

            compra.Status = EstadosCompra.Recibida;
            compra.ReceivedDate = ahora;
            compra.UpdatedAt = ahora;
            _context.SaveChanges();
            tx.Commit();
            return ResultadoCompraDto.Correcto(
                $"Compra {compra.PurchaseCode} recibida. Se actualizaron las existencias, los lotes y el historial de inventario.",
                compra.PurchaseId);
        }
        catch (Exception ex)
        {
            tx.Rollback();
            return ResultadoCompraDto.Fallido($"No se pudo registrar la recepción: {ex.GetBaseException().Message}");
        }
    }

    public ResultadoCompraDto CancelarCompra(int purchaseId)
    {
        Purchase? compra = _context.Purchases.FirstOrDefault(p => p.PurchaseId == purchaseId);
        if (compra is null)
            return ResultadoCompraDto.Fallido("La compra seleccionada ya no existe.");
        if (compra.Status != EstadosCompra.Pendiente)
            return ResultadoCompraDto.Fallido("Solo se pueden cancelar compras pendientes.");

        compra.Status = EstadosCompra.Cancelada;
        compra.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return ResultadoCompraDto.Correcto($"Compra {compra.PurchaseCode} cancelada.", compra.PurchaseId);
    }

    private string? ObtenerSiguienteCodigoIngredienteDisponible()
    {
        var codigosExistentes = _context.Products
            .AsNoTracking()
            .Select(p => p.ProductCode)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        for (int numero = 1; numero <= 999; numero++)
        {
            string codigo = $"ING-{numero:000}";

            if (!codigosExistentes.Contains(codigo))
                return codigo;
        }

        return null;
    }

    private ProductCategory ObtenerOCrearCategoriaIngredientes()
    {
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

        return categoria;
    }

    private static string? NormalizarTexto(string? texto) =>
        string.IsNullOrWhiteSpace(texto) ? null : texto.Trim();

    public void Dispose()
    {
        if (_disposed) return;
        _context.Dispose();
        _disposed = true;
    }
}
