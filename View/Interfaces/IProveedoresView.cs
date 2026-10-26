using System;
using System.Collections.Generic;
using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.View.Interfaces;

/// <summary>Contrato entre FrmProveedores y ProveedoresPresenter.</summary>
public interface IProveedoresView
{
    string TextoBusqueda { get; }
    int? ProveedorSeleccionadoId { get; }
    int? ProveedorComprasSeleccionadoId { get; }
    GuardarProveedorDto DatosFormulario { get; }

    event EventHandler? BusquedaCambiada;
    event EventHandler? ProveedorSeleccionadoCambiado;
    event EventHandler? NuevoProveedorSolicitado;
    event EventHandler? EditarProveedorSolicitado;
    event EventHandler? CambiarEstadoProveedorSolicitado;
    event EventHandler? GuardarProveedorSolicitado;
    event EventHandler? CancelarEdicionSolicitada;
    event EventHandler? ProveedorComprasSeleccionadoCambiado;

    void MostrarProveedores(IReadOnlyList<ProveedorDto> proveedores, int? seleccionarId = null);
    void MostrarProveedoresConCompras(IReadOnlyList<ProveedorSelectorDto> proveedores, int? seleccionarId = null);
    void MostrarComprasAsociadas(IReadOnlyList<CompraProveedorDto> compras);
    void CargarProveedorEnFormulario(ProveedorDto proveedor);
    void LimpiarFormularioProveedor();
    void HabilitarEdicion(bool habilitar);
    void ActualizarEstadoAcciones(bool haySeleccion, bool editando);
    void SeleccionarPestanaProveedores();
    void LimpiarBusqueda();
    void MostrarMensaje(string mensaje, bool esError = false);
    bool ConfirmarCambioEstado(string nombreProveedor, bool activar);
}
