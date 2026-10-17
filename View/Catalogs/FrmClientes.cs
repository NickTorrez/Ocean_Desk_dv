using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Presenters;
using Ocean_Desk_dv.Services;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Ocean_Desk_dv.UI.Catalogs
{
    /// <summary>
    /// Vista del módulo de Clientes.
    /// Implementa IClientesView y delega la lógica a ClientesPresenter.
    /// </summary>
    public partial class FrmClientes : Form
    {

        #region Constructor
        public FrmClientes()
        {
            InitializeComponent();

        }
        #endregion

        #region Eventos de controles
        private void btnBuscar_Click(object sender, EventArgs e) { }
        private void btnNuevo_Click(object sender, EventArgs e) { }
        private void btnGuardar_Click(object sender, EventArgs e) { }
        private void btnCambiarEstado_Click(object sender, EventArgs e) { }
        private void btnCancelar_Click(object sender, EventArgs e) { }
        private void chkSoloActivos_CheckedChanged(object sender, EventArgs e) { }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
           
        }
        #endregion

        #region Formato visual
        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void dgvHistorial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvHistorial.Columns[e.ColumnIndex].Name != "colHTotal") return;

            if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal total))
            {
                e.Value = FormatearMoneda(total);
                e.FormattingApplied = true;
            }
        }

        private void ActualizarEstadoVisualBotones()
        {
            if (btnCambiarEstado.Enabled)
            {
                btnCambiarEstado.BackColor = Color.FromArgb(238, 243, 247);
                btnCambiarEstado.ForeColor = Color.FromArgb(8, 31, 63);
            }
            else
            {
                btnCambiarEstado.BackColor = Color.FromArgb(232, 236, 239);
                btnCambiarEstado.ForeColor = Color.FromArgb(155, 163, 170);
            }
        }

        private static string FormatearMoneda(decimal monto) =>
            "C$ " + monto.ToString("N2", CultureInfo.GetCultureInfo("es-NI"));
        #endregion

        #region Liberación de recursos
        private void FrmClientes_FormClosed(object? sender, FormClosedEventArgs e)
        {
            
        }
        #endregion
    }
}
