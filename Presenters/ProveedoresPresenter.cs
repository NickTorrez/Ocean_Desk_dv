using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Services.Interfaces_Services;
using Ocean_Desk_dv.View.Interfaces;

namespace Ocean_Desk_dv.Presenters;

/// <summary>Coordina las operaciones del catálogo de proveedores.</summary>
public sealed class ProveedoresPresenter : IDisposable
{
    private readonly IProveedoresView _view;
    private readonly IProveedoresRepository _repository;
    private bool _editando;
    private bool _disposed;

    public ProveedoresPresenter(
        IProveedoresView view,
        IProveedoresRepository repository)
    {
        _view = view ?? throw new ArgumentNullException(nameof(view));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        _view.BusquedaCambiada += AlCambiarBusqueda;
        _view.ProveedorSeleccionadoCambiado += AlCambiarProveedorSeleccionado;
        _view.NuevoProveedorSolicitado += AlSolicitarNuevoProveedor;
        _view.EditarProveedorSolicitado += AlSolicitarEditarProveedor;
        _view.CambiarEstadoProveedorSolicitado += AlSolicitarCambiarEstado;
        _view.GuardarProveedorSolicitado += AlSolicitarGuardarProveedor;
        _view.CancelarEdicionSolicitada += AlSolicitarCancelarEdicion;
        _view.ProveedorComprasSeleccionadoCambiado += AlCambiarProveedorComprasSeleccionado;
    }

    public void Inicializar()
    {
        EjecutarSeguro(() =>
        {
            _editando = false;
            _view.MostrarProveedores(
                _repository.ObtenerProveedores(_view.TextoBusqueda), null);
            ActualizarSelectorProveedoresConCompras();
            _view.MostrarComprasAsociadas(Array.Empty<CompraProveedorDto>());
            _view.LimpiarFormularioProveedor();
            _view.HabilitarEdicion(false);
            _view.ActualizarEstadoAcciones(false, false);
        });
    }

    private void AlCambiarBusqueda(object? sender, EventArgs e)
    {
        if (_editando)
            return;

        EjecutarSeguro(() =>
        {
            _view.MostrarProveedores(
                _repository.ObtenerProveedores(_view.TextoBusqueda), null);
            _view.LimpiarFormularioProveedor();
            _view.HabilitarEdicion(false);
            _view.ActualizarEstadoAcciones(false, false);
        });
    }

    private void AlCambiarProveedorSeleccionado(object? sender, EventArgs e)
    {
        if (_editando)
            return;

        EjecutarSeguro(() =>
        {
            int? proveedorId = _view.ProveedorSeleccionadoId;
            if (!proveedorId.HasValue)
            {
                _view.LimpiarFormularioProveedor();
                _view.HabilitarEdicion(false);
                _view.ActualizarEstadoAcciones(false, false);
                return;
            }

            ProveedorDto? proveedor = _repository.ObtenerProveedor(proveedorId.Value);
            if (proveedor is null)
            {
                _view.MostrarMensaje("El proveedor seleccionado ya no existe.", true);
                RecargarProveedores(null);
                return;
            }

            _view.CargarProveedorEnFormulario(proveedor);
            _view.HabilitarEdicion(false);
            _view.ActualizarEstadoAcciones(true, false);
        });
    }

    private void AlSolicitarNuevoProveedor(object? sender, EventArgs e)
    {
        _editando = true;
        _view.SeleccionarPestanaProveedores();
        _view.LimpiarBusqueda();
        _view.LimpiarFormularioProveedor();
        _view.HabilitarEdicion(true);
        _view.ActualizarEstadoAcciones(false, true);
    }

    private void AlSolicitarEditarProveedor(object? sender, EventArgs e)
    {
        if (!_view.ProveedorSeleccionadoId.HasValue)
        {
            _view.MostrarMensaje("Seleccione un proveedor para editar.");
            return;
        }

        EjecutarSeguro(() =>
        {
            ProveedorDto? proveedor =
                _repository.ObtenerProveedor(_view.ProveedorSeleccionadoId.Value);

            if (proveedor is null)
            {
                _view.MostrarMensaje("El proveedor seleccionado ya no existe.", true);
                RecargarProveedores(null);
                return;
            }

            _editando = true;
            _view.CargarProveedorEnFormulario(proveedor);
            _view.HabilitarEdicion(true);
            _view.ActualizarEstadoAcciones(true, true);
        });
    }

    private void AlSolicitarGuardarProveedor(object? sender, EventArgs e)
    {
        if (!_editando)
        {
            _view.MostrarMensaje("Pulse «Nuevo proveedor» o «Editar proveedor» antes de guardar.");
            return;
        }

        EjecutarSeguro(() =>
        {
            GuardarProveedorDto solicitud = _view.DatosFormulario;
            ResultadoOperacionDto resultado =
                _repository.GuardarProveedor(solicitud, out int proveedorId);

            _view.MostrarMensaje(resultado.Mensaje, !resultado.Exito);
            if (!resultado.Exito)
                return;

            _editando = false;
            _view.LimpiarBusqueda();
            RecargarProveedores(proveedorId);
            ProveedorDto? proveedorGuardado = _repository.ObtenerProveedor(proveedorId);

            if (proveedorGuardado is not null)
            {
                _view.CargarProveedorEnFormulario(proveedorGuardado);
                _view.HabilitarEdicion(false);
                _view.ActualizarEstadoAcciones(true, false);
            }
            else
            {
                _view.LimpiarFormularioProveedor();
                _view.HabilitarEdicion(false);
                _view.ActualizarEstadoAcciones(false, false);
            }

            ActualizarSelectorProveedoresConCompras();
        });
    }

    private void AlSolicitarCancelarEdicion(object? sender, EventArgs e)
    {
        _editando = false;

        EjecutarSeguro(() =>
        {
            int? proveedorId = _view.ProveedorSeleccionadoId;
            ProveedorDto? proveedor = proveedorId.HasValue
                ? _repository.ObtenerProveedor(proveedorId.Value)
                : null;

            if (proveedor is null)
            {
                _view.LimpiarFormularioProveedor();
                _view.HabilitarEdicion(false);
                _view.ActualizarEstadoAcciones(false, false);
            }
            else
            {
                _view.CargarProveedorEnFormulario(proveedor);
                _view.HabilitarEdicion(false);
                _view.ActualizarEstadoAcciones(true, false);
            }
        });
    }

    private void AlSolicitarCambiarEstado(object? sender, EventArgs e)
    {
        if (!_view.ProveedorSeleccionadoId.HasValue)
        {
            _view.MostrarMensaje("Seleccione un proveedor para cambiar su estado.");
            return;
        }

        EjecutarSeguro(() =>
        {
            int proveedorId = _view.ProveedorSeleccionadoId.Value;
            ProveedorDto? proveedor = _repository.ObtenerProveedor(proveedorId);
            if (proveedor is null)
            {
                _view.MostrarMensaje("El proveedor seleccionado ya no existe.", true);
                RecargarProveedores(null);
                return;
            }

            bool activar = !proveedor.IsActive;
            if (!_view.ConfirmarCambioEstado(proveedor.SupplierName, activar))
                return;

            ResultadoOperacionDto resultado =
                _repository.CambiarEstadoProveedor(proveedorId);

            _view.MostrarMensaje(resultado.Mensaje, !resultado.Exito);
            if (!resultado.Exito)
                return;

            RecargarProveedores(proveedorId);
            ProveedorDto? actualizado = _repository.ObtenerProveedor(proveedorId);
            if (actualizado is not null)
            {
                _view.CargarProveedorEnFormulario(actualizado);
                _view.HabilitarEdicion(false);
                _view.ActualizarEstadoAcciones(true, false);
            }

            ActualizarSelectorProveedoresConCompras();
        });
    }

    private void AlCambiarProveedorComprasSeleccionado(object? sender, EventArgs e)
    {
        EjecutarSeguro(() =>
        {
            int? supplierId = _view.ProveedorComprasSeleccionadoId;
            _view.MostrarComprasAsociadas(supplierId.HasValue
                ? _repository.ObtenerComprasAsociadas(supplierId.Value)
                : Array.Empty<CompraProveedorDto>());
        });
    }

    private void RecargarProveedores(int? seleccionarId)
    {
        _view.MostrarProveedores(
            _repository.ObtenerProveedores(_view.TextoBusqueda), seleccionarId);
    }

    private void ActualizarSelectorProveedoresConCompras()
    {
        _view.MostrarProveedoresConCompras(
            _repository.ObtenerProveedoresConCompras(),
            _view.ProveedorComprasSeleccionadoId);
    }

    private void EjecutarSeguro(Action accion)
    {
        try
        {
            accion();
        }
        catch (Exception ex)
        {
            _view.MostrarMensaje(
                $"No se pudo completar la operación de proveedores: {ex.GetBaseException().Message}",
                true);
        }
    }

    public void Dispose()
    {
        if (_disposed)
            return;

        _view.BusquedaCambiada -= AlCambiarBusqueda;
        _view.ProveedorSeleccionadoCambiado -= AlCambiarProveedorSeleccionado;
        _view.NuevoProveedorSolicitado -= AlSolicitarNuevoProveedor;
        _view.EditarProveedorSolicitado -= AlSolicitarEditarProveedor;
        _view.CambiarEstadoProveedorSolicitado -= AlSolicitarCambiarEstado;
        _view.GuardarProveedorSolicitado -= AlSolicitarGuardarProveedor;
        _view.CancelarEdicionSolicitada -= AlSolicitarCancelarEdicion;
        _view.ProveedorComprasSeleccionadoCambiado -= AlCambiarProveedorComprasSeleccionado;
        _repository.Dispose();
        _disposed = true;
        GC.SuppressFinalize(this);
    }
}
