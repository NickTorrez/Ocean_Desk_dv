using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Services.Interfaces_Services;
using Ocean_Desk_dv.Services.Repository;

namespace Ocean_Desk_dv.Services;

/// <summary>
/// Punto de composición manual del proyecto. FrmMainMenu crea las dependencias
/// y las entrega a las Vistas; los Presenters reciben contratos de servicio.
/// </summary>
public static class OceanDeskRepositoryFactory
{
    public static IReportesRepository CrearReportesRepository() => new ReportesRepository(new OceanDeskDbContext());
    public static ICajaRepository CrearCajaRepository() => new CajaRepository(new OceanDeskDbContext());
    public static ICocinaRepository CrearCocinaRepository() => new CocinaRepository(new OceanDeskDbContext());
    public static IFacturacionRepository CrearFacturacionRepository() => new FacturacionRepository(new OceanDeskDbContext());
    public static IMesasReservasRepository CrearMesasReservasRepository() => new MesasReservasRepository(new OceanDeskDbContext());
    public static IPuntoVentaRepository CrearPuntoVentaRepository() => new PuntoVentaRepository(new OceanDeskDbContext());

    /// <summary>Crea el repositorio del módulo Productos con su propio contexto de base de datos.</summary>
    public static IProductosRepository CrearProductosRepository() => new ProductosRepository(new OceanDeskDbContext());
    /// <summary>
    /// Crea el repositorio de inventario con su propio contexto de base de datos.
    /// </summary>
    public static IInventarioRepository CrearInventarioRepository() =>
        new InventarioRepository(new OceanDeskDbContext());
}
