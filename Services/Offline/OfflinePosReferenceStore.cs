using Ocean_Desk_dv.Data.SQLite;
using Ocean_Desk_dv.Data.SQLite.Entities;
using Ocean_Desk_dv.Models.DTOs;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Services.Offline
{
    /// <summary>
    /// Administra la caché local de productos y mesas del Punto de Venta.
    /// Los datos proceden de SQL Server y se conservan en SQLite.
    /// </summary>
    public sealed class OfflinePosReferenceStore
    {
        public OfflinePosReferenceStore()
        {
            LocalDatabaseInitializer.Initialize();
        }

        /// <summary>
        /// Reemplaza la caché local de productos por la información
        /// más reciente recibida desde SQL Server.
        /// </summary>
        public void ActualizarCatalogoDesdeServidor(
            IReadOnlyCollection<ProductoVentaDto> productos)
        {
            ArgumentNullException.ThrowIfNull(productos);

            using var context =
                OceanDeskLocalDbContextFactory.CreateContext();

            using var transaction =
                context.Database.BeginTransaction();

            // El catálogo es una fotografía completa del servidor.
            // Se reemplaza dentro de una transacción para evitar
            // conservar productos eliminados o desactualizados.
            context.LocalProducts.RemoveRange(context.LocalProducts);
            context.SaveChanges();

            DateTime ahoraUtc = DateTime.UtcNow;

            var productosLocales = productos.Select(producto =>
                new LocalProduct
                {
                    ServerProductId = producto.ProductId,
                    ProductCode = producto.ProductCode,
                    ProductName = producto.ProductName,
                    UnitPrice = producto.UnitPrice,
                    IsAvailable = producto.IsAvailable,
                    IsActive = producto.IsActive,
                    CategoryName = producto.CategoryName,
                    CachedAtUtc = ahoraUtc
                });

            context.LocalProducts.AddRange(productosLocales);
            context.SaveChanges();

            transaction.Commit();
        }

        /// <summary>
        /// Obtiene el catálogo almacenado en SQLite.
        /// </summary>
        public IReadOnlyList<ProductoVentaDto> ObtenerCatalogoLocal()
        {
            using var context =
                OceanDeskLocalDbContextFactory.CreateContext();

            return context.LocalProducts
                .AsNoTracking()
                .Where(producto => producto.IsActive)
                .OrderBy(producto => producto.CategoryName)
                .ThenBy(producto => producto.ProductName)
                .Select(producto => new ProductoVentaDto
                {
                    ProductId = producto.ServerProductId,
                    ProductCode = producto.ProductCode,
                    ProductName = producto.ProductName,
                    UnitPrice = producto.UnitPrice,
                    IsAvailable = producto.IsAvailable,
                    IsActive = producto.IsActive,
                    CategoryName = producto.CategoryName
                })
                .ToList();
        }

        /// <summary>
        /// Actualiza la caché local con las mesas activas recibidas
        /// desde SQL Server, conservando su estado actual.
        /// </summary>
        public void ActualizarMesasDesdeServidor(
            IReadOnlyCollection<MesaDto> mesas)
        {
            ArgumentNullException.ThrowIfNull(mesas);

            using var context =
                OceanDeskLocalDbContextFactory.CreateContext();

            using var transaction =
                context.Database.BeginTransaction();

            context.LocalRestaurantTables.RemoveRange(
                context.LocalRestaurantTables);

            context.SaveChanges();

            DateTime ahoraUtc = DateTime.UtcNow;

            var mesasLocales = mesas.Select(mesa =>
                new LocalRestaurantTable
                {
                    ServerTableId = mesa.TableId,
                    TableNumber = mesa.TableNumber,
                    Capacity = mesa.Capacity,
                    Status = mesa.Status,
                    IsActive = mesa.IsActive,
                    CachedAtUtc = ahoraUtc
                });

            context.LocalRestaurantTables.AddRange(mesasLocales);
            context.SaveChanges();

            transaction.Commit();
        }

        /// <summary>
        /// Obtiene las mesas que figuraban disponibles
        /// en la última actualización de SQLite.
        /// </summary>
        public IReadOnlyList<MesaDto> ObtenerMesasDisponiblesLocales()
        {
            using var context =
                OceanDeskLocalDbContextFactory.CreateContext();

            return context.LocalRestaurantTables
                .AsNoTracking()
                .Where(mesa =>
                    mesa.IsActive &&
                    mesa.Status == "Available")
                .OrderBy(mesa => mesa.TableNumber)
                .Select(mesa => new MesaDto
                {
                    TableId = mesa.ServerTableId,
                    TableNumber = mesa.TableNumber,
                    Capacity = mesa.Capacity,
                    Status = mesa.Status,
                    IsActive = mesa.IsActive
                })
                .ToList();
        }
    }
}
