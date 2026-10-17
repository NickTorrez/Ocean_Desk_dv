using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;

namespace Ocean_Desk_dv.Services.Repository;

/// <summary>
/// Implementa el acceso a datos del módulo Productos mediante Entity Framework Core.
/// La clase consulta y modifica la base de datos; no conoce los controles del formulario.
/// </summary>
public sealed class ProductosRepository : IProductosRepository
{
    private const string TipoProductoTerminado = "FinishedProduct";
    private const string TipoIngrediente = "Ingredient";
    private readonly OceanDeskDbContext _context;
    private bool _disposed;

    /// <summary>
    /// Inicializa el repositorio con el contexto de base de datos que utilizará para sus operaciones.
    /// </summary>
    /// <param name="context">Contexto de Entity Framework Core configurado para Ocean Desk.</param>
    public ProductosRepository(OceanDeskDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IReadOnlyList<ProductoCatalogoDto> ObtenerProductos(string? filtro = null, bool incluirInactivos = true)
    {
        IQueryable<Product> consulta = _context.Products
            .AsNoTracking()
            .Where(p => p.ProductType == TipoProductoTerminado);

        if (!incluirInactivos)
            consulta = consulta.Where(p => p.IsActive);

        if (!string.IsNullOrWhiteSpace(filtro))
        {
            string texto = filtro.Trim();
            consulta = consulta.Where(p => p.ProductCode.Contains(texto) || p.ProductName.Contains(texto));
        }

        return consulta
            .OrderBy(p => p.ProductName)
            .Select(p => new ProductoCatalogoDto
            {
                ProductId = p.ProductId,
                ProductCode = p.ProductCode,
                ProductName = p.ProductName,
                Description = p.Description,
                ProductCategoryId = p.ProductCategoryId,
                CategoryName = p.ProductCategory.CategoryName,
                UnitPrice = p.UnitPrice,
                IsAvailable = p.IsAvailable,
                IsActive = p.IsActive,
                ProductType = p.ProductType,
                UnitOfMeasureId = p.UnitOfMeasureId,
                UnitCode = p.UnitOfMeasure != null ? p.UnitOfMeasure.UnitCode : null,
                UnitName = p.UnitOfMeasure != null ? p.UnitOfMeasure.UnitName : null
            })
            .ToList();
    }

    public IReadOnlyList<CategoriaProductoDto> ObtenerCategoriasActivas()
    {
        return _context.ProductCategories
            .AsNoTracking()
            .Where(c => c.IsActive)
            .OrderBy(c => c.CategoryName)
            .Select(c => new CategoriaProductoDto
            {
                ProductCategoryId = c.ProductCategoryId,
                CategoryName = c.CategoryName
            })
            .ToList();
    }

    public IReadOnlyList<UnidadMedidaDto> ObtenerUnidadesActivas()
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

    public ResultadoOperacionDto GuardarProducto(GuardarProductoDto solicitud, out int productoId)
    {
        productoId = 0;
        if (solicitud is null)
            return ResultadoOperacionDto.Fallido("No se recibieron los datos del producto.");

        string codigo = solicitud.ProductCode.Trim();
        string nombre = solicitud.ProductName.Trim();
        string? descripcion = string.IsNullOrWhiteSpace(solicitud.Description)
            ? null
            : solicitud.Description.Trim();

        if (codigo.Length == 0 || codigo.Length > 30)
            return ResultadoOperacionDto.Fallido("El código del producto es obligatorio y debe tener como máximo 30 caracteres.");
        if (nombre.Length == 0 || nombre.Length > 150)
            return ResultadoOperacionDto.Fallido("El nombre del producto es obligatorio y debe tener como máximo 150 caracteres.");
        if (descripcion?.Length > 300)
            return ResultadoOperacionDto.Fallido("La descripción no puede superar los 300 caracteres.");
        if (solicitud.ProductCategoryId <= 0 || !_context.ProductCategories.Any(c => c.ProductCategoryId == solicitud.ProductCategoryId && c.IsActive))
            return ResultadoOperacionDto.Fallido("Seleccione una categoría activa.");
        if (solicitud.UnitPrice < 0 || solicitud.UnitPrice > 9999999999.99m || decimal.Round(solicitud.UnitPrice, 2) != solicitud.UnitPrice)
            return ResultadoOperacionDto.Fallido("El precio debe ser positivo o cero y admitir como máximo dos decimales.");
        if (solicitud.UnitOfMeasureId.HasValue &&
            !_context.UnitOfMeasures.Any(u => u.UnitOfMeasureId == solicitud.UnitOfMeasureId.Value && u.IsActive))
            return ResultadoOperacionDto.Fallido("La unidad de medida seleccionada no existe o está inactiva.");

        bool codigoDuplicado = _context.Products.Any(p =>
            p.ProductCode == codigo && (!solicitud.ProductId.HasValue || p.ProductId != solicitud.ProductId.Value));
        if (codigoDuplicado)
            return ResultadoOperacionDto.Fallido("Ya existe un producto registrado con ese código.");

        Product? producto;
        bool esNuevo = !solicitud.ProductId.HasValue;

        if (esNuevo)
        {
            producto = new Product
            {
                ProductCode = codigo,
                ProductName = nombre,
                CreatedAt = DateTime.Now,
                ProductType = TipoProductoTerminado
            };
            _context.Products.Add(producto);
        }
        else
        {
            producto = _context.Products.FirstOrDefault(p =>
                p.ProductId == solicitud.ProductId!.Value && p.ProductType == TipoProductoTerminado);

            if (producto is null)
                return ResultadoOperacionDto.Fallido("El producto terminado que intenta editar no existe.");

            producto.UpdatedAt = DateTime.Now;
        }

        producto.ProductCode = codigo;
        producto.ProductName = nombre;
        producto.Description = descripcion;
        producto.ProductCategoryId = solicitud.ProductCategoryId;
        producto.UnitPrice = solicitud.UnitPrice;
        producto.UnitOfMeasureId = solicitud.UnitOfMeasureId;
        producto.IsAvailable = solicitud.IsActive && solicitud.IsAvailable;
        producto.IsActive = solicitud.IsActive;

        try
        {
            _context.SaveChanges();
            productoId = producto.ProductId;
            string accion = esNuevo ? "registrado" : "actualizado";
            return ResultadoOperacionDto.Correcto($"El producto {producto.ProductName} fue {accion} correctamente.");
        }
        catch (DbUpdateException)
        {
            return ResultadoOperacionDto.Fallido("No se pudo guardar el producto. Verifique que el código no esté duplicado y que los datos sean válidos.");
        }
    }

    public ResultadoOperacionDto CambiarEstadoProducto(int productoId)
    {
        if (productoId <= 0)
            return ResultadoOperacionDto.Fallido("El identificador del producto no es válido.");

        Product? producto = _context.Products.FirstOrDefault(p =>
            p.ProductId == productoId && p.ProductType == TipoProductoTerminado);

        if (producto is null)
            return ResultadoOperacionDto.Fallido("No se encontró el producto terminado seleccionado.");

        producto.IsActive = !producto.IsActive;
        if (!producto.IsActive)
            producto.IsAvailable = false;
        producto.UpdatedAt = DateTime.Now;

        try
        {
            _context.SaveChanges();
            return ResultadoOperacionDto.Correcto(producto.IsActive
                ? "El producto se activó correctamente. Revise su disponibilidad para la venta."
                : "El producto se desactivó y dejó de estar disponible para la venta.");
        }
        catch (DbUpdateException)
        {
            return ResultadoOperacionDto.Fallido("No se pudo cambiar el estado del producto.");
        }
    }

    public IReadOnlyList<ProductoRecetaSelectorDto> ObtenerProductosTerminadosParaReceta()
    {
        return _context.Products
            .AsNoTracking()
            .Where(p => p.ProductType == TipoProductoTerminado && p.IsActive)
            .OrderBy(p => p.ProductName)
            .Select(p => new ProductoRecetaSelectorDto
            {
                ProductId = p.ProductId,
                ProductCode = p.ProductCode,
                ProductName = p.ProductName
            })
            .ToList();
    }

    public IReadOnlyList<IngredienteSelectorDto> ObtenerIngredientesActivos()
    {
        return _context.Products
            .AsNoTracking()
            .Where(p => p.ProductType == TipoIngrediente && p.IsActive && p.UnitOfMeasureId.HasValue && p.UnitOfMeasure != null && p.UnitOfMeasure.IsActive)
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

    public RecetaProductoDto? ObtenerReceta(int productoId)
    {
        if (productoId <= 0)
            return null;

        Recipe? receta = _context.Recipes
            .AsNoTracking()
            .Include(r => r.RecipeDetails)
                .ThenInclude(d => d.IngredientProduct)
                    .ThenInclude(p => p.UnitOfMeasure)
            .FirstOrDefault(r => r.ProductId == productoId && r.Product.ProductType == TipoProductoTerminado);

        if (receta is null)
            return null;

        return new RecetaProductoDto
        {
            RecipeId = receta.RecipeId,
            ProductId = receta.ProductId,
            Instructions = receta.Instructions,
            IsActive = receta.IsActive,
            Detalles = receta.RecipeDetails
                .OrderBy(d => d.IngredientProduct.ProductName)
                .Select(d => new DetalleRecetaDto
                {
                    RecipeDetailId = d.RecipeDetailId,
                    IngredientProductId = d.IngredientProductId,
                    IngredientCode = d.IngredientProduct.ProductCode,
                    IngredientName = d.IngredientProduct.ProductName,
                    UnitCode = d.IngredientProduct.UnitOfMeasure != null ? d.IngredientProduct.UnitOfMeasure.UnitCode : string.Empty,
                    UnitName = d.IngredientProduct.UnitOfMeasure != null ? d.IngredientProduct.UnitOfMeasure.UnitName : string.Empty,
                    Quantity = d.Quantity,
                    Notes = d.Notes
                })
                .ToList()
        };
    }

    public ResultadoOperacionDto GuardarReceta(GuardarRecetaDto solicitud)
    {
        if (solicitud is null)
            return ResultadoOperacionDto.Fallido("No se recibieron los datos de la receta.");
        if (solicitud.ProductId <= 0)
            return ResultadoOperacionDto.Fallido("Seleccione un producto terminado válido.");
        if (solicitud.Instructions?.Length > 1000)
            return ResultadoOperacionDto.Fallido("Las instrucciones no pueden superar los 1,000 caracteres.");
        if (solicitud.Detalles is null || solicitud.Detalles.Count == 0)
            return ResultadoOperacionDto.Fallido("Agregue al menos un ingrediente a la receta.");

        var idsIngredientes = solicitud.Detalles.Select(d => d.IngredientProductId).ToList();
        if (idsIngredientes.Any(id => id <= 0))
            return ResultadoOperacionDto.Fallido("La receta contiene un ingrediente con identificador inválido.");
        if (idsIngredientes.Distinct().Count() != idsIngredientes.Count)
            return ResultadoOperacionDto.Fallido("No puede agregar el mismo ingrediente más de una vez a una receta.");
        if (solicitud.Detalles.Any(d => d.Quantity <= 0 || d.Quantity > 99999999.9999m || decimal.Round(d.Quantity, 4) != d.Quantity))
            return ResultadoOperacionDto.Fallido("Cada cantidad debe ser mayor que cero y tener como máximo cuatro decimales.");
        if (solicitud.Detalles.Any(d => d.Notes?.Length > 250))
            return ResultadoOperacionDto.Fallido("Las notas de cada ingrediente no pueden superar los 250 caracteres.");

        Product? producto = _context.Products.FirstOrDefault(p =>
            p.ProductId == solicitud.ProductId && p.ProductType == TipoProductoTerminado && p.IsActive);
        if (producto is null)
            return ResultadoOperacionDto.Fallido("El producto terminado no existe o está inactivo.");

        var ingredientes = _context.Products
            .Include(p => p.UnitOfMeasure)
            .Where(p => idsIngredientes.Contains(p.ProductId) && p.ProductType == TipoIngrediente && p.IsActive)
            .ToList();

        if (ingredientes.Count != idsIngredientes.Count)
            return ResultadoOperacionDto.Fallido("Uno o más ingredientes no existen, están inactivos o no son ingredientes válidos.");
        if (ingredientes.Any(p => !p.UnitOfMeasureId.HasValue || p.UnitOfMeasure is null || !p.UnitOfMeasure.IsActive))
            return ResultadoOperacionDto.Fallido("Todos los ingredientes deben tener una unidad base activa asignada.");

        using IDbContextTransaction transaccion = _context.Database.BeginTransaction();
        try
        {
            Recipe? receta = _context.Recipes
                .Include(r => r.RecipeDetails)
                .FirstOrDefault(r => r.ProductId == solicitud.ProductId);

            if (receta is null)
            {
                receta = new Recipe
                {
                    ProductId = solicitud.ProductId,
                    CreatedAt = DateTime.Now
                };
                _context.Recipes.Add(receta);
            }
            else
            {
                // Se reemplazan los detalles completos para que la receta guardada refleje la solicitud actual.
                _context.RecipeDetails.RemoveRange(receta.RecipeDetails.ToList());
                receta.RecipeDetails.Clear();
            }

            receta.Instructions = string.IsNullOrWhiteSpace(solicitud.Instructions)
                ? null
                : solicitud.Instructions.Trim();
            receta.IsActive = solicitud.IsActive;
            receta.UpdatedAt = receta.RecipeId > 0 ? DateTime.Now : null;

            foreach (DetalleRecetaDto detalle in solicitud.Detalles)
            {
                receta.RecipeDetails.Add(new RecipeDetail
                {
                    IngredientProductId = detalle.IngredientProductId,
                    Quantity = detalle.Quantity,
                    Notes = string.IsNullOrWhiteSpace(detalle.Notes) ? null : detalle.Notes.Trim(),
                    CreatedAt = DateTime.Now
                });
            }

            _context.SaveChanges();
            transaccion.Commit();
            return ResultadoOperacionDto.Correcto("La receta y sus ingredientes se guardaron correctamente.");
        }
        catch (DbUpdateException)
        {
            transaccion.Rollback();
            _context.ChangeTracker.Clear();
            return ResultadoOperacionDto.Fallido("No se pudo guardar la receta. Verifique los ingredientes, las cantidades y las restricciones de la base de datos.");
        }
        catch
        {
            transaccion.Rollback();
            _context.ChangeTracker.Clear();
            throw;
        }
    }

    /// <summary>
    /// Libera el contexto de Entity Framework Core cuando el módulo termina de utilizar el repositorio.
    /// </summary>
    public void Dispose()
    {
        if (_disposed)
            return;

        _context.Dispose();
        _disposed = true;
        GC.SuppressFinalize(this);
    }
}
