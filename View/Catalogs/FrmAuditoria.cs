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
    /// Vista de Bitácoras / Auditoría. Solo consulta: no permite editar ni eliminar eventos.
    /// </summary>
    public partial class FrmAuditoria : Form
    {

        #region Constructor
        public FrmAuditoria()
        {
            InitializeComponent();

            dgvAuditoria.AutoGenerateColumns = false;
        }
        #endregion

        #region Eventos de controles
        private void btnFiltrar_Click(object sender, EventArgs e) { }
        private void btnLimpiar_Click(object sender, EventArgs e) { }
        private void btnVerDetalle_Click(object sender, EventArgs e) { }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dgvAuditoria_SelectionChanged(object sender, EventArgs e)
        {
           
        }
        #endregion

        #region Formato visual
        private void dgvAuditoria_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void ActualizarBotonDetalle()
        {
            
        }
        #endregion

        #region Liberación de recursos
        private void FrmAuditoria_FormClosed(object? sender, FormClosedEventArgs e)
        {
           
        }
        #endregion
    }
}
