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
    public partial class FrmAuditoria : Form, IAuditoriaView
    {
        private AuditoriaPresenter? _presenter;
        private bool _cargando;

        #region Constructor
        public FrmAuditoria()
        {
            InitializeComponent();

            dgvAuditoria.AutoGenerateColumns = false;

            _presenter = new AuditoriaPresenter(this, OceanDeskRepositoryFactory.CrearAuditoriaRepository());
            _presenter.Inicializar();
        }
        #endregion

        #region Implementación de IAuditoriaView
        public long? RegistroSeleccionadoId =>
            dgvAuditoria.SelectedRows.Count > 0 && dgvAuditoria.SelectedRows[0].DataBoundItem is AuditoriaDto a
                ? a.AuditId
                : null;

        public bool DetalleVisible => pnlDetalle.Visible;

        public event EventHandler FiltrarClicked = delegate { };
        public event EventHandler LimpiarClicked = delegate { };
        public event EventHandler VerDetalleClicked = delegate { };
        public event EventHandler RegistroSeleccionado = delegate { };

        public AuditoriaFiltroDto ObtenerFiltro() => new()
        {
            Desde = dtpDesde.Checked ? dtpDesde.Value.Date : null,
            Hasta = dtpHasta.Checked ? dtpHasta.Value.Date : null,
            Modulo = ValorSeleccionado(cmbModulo),
            Accion = ValorSeleccionado(cmbAccion),
            Usuario = ValorSeleccionado(cmbUsuario),
            Texto = txtBuscar.Text.Trim()
        };

        public void CargarOpcionesFiltro(FiltrosAuditoriaDto opciones)
        {
            Rellenar(cmbModulo, opciones.Modulos);
            Rellenar(cmbAccion, opciones.Acciones);
            Rellenar(cmbUsuario, opciones.Usuarios);
        }

        public void MostrarRegistros(AuditoriaResultadoDto resultado)
        {
            _cargando = true;
            dgvAuditoria.DataSource = null;
            dgvAuditoria.DataSource = resultado.Registros.ToList();
            dgvAuditoria.ClearSelection();
            _cargando = false;

            CultureInfo cultura = CultureInfo.GetCultureInfo("es-NI");
            lblTotalRegistros.Text = resultado.Limitado
                ? $"Mostrando los {resultado.Registros.Count.ToString("N0", cultura)} más recientes de {resultado.TotalCoincidencias.ToString("N0", cultura)} registros. Use los filtros para acotar."
                : $"{resultado.TotalCoincidencias.ToString("N0", cultura)} registros";

            OcultarDetalle();
            ActualizarBotonDetalle();
        }

        public void MostrarDetalle(AuditoriaDetalleDto detalle)
        {
            lblInfoEvento.Text =
                $"{detalle.Accion} en {detalle.Modulo}" +
                (detalle.RegistroId.HasValue ? $" · Registro #{detalle.RegistroId}" : string.Empty) +
                $" · {detalle.Usuario} · {detalle.FechaHora:dd/MM/yyyy HH:mm:ss}";

            txtAnteriores.Text = string.IsNullOrWhiteSpace(detalle.ValoresAnteriores) ? "(sin datos)" : detalle.ValoresAnteriores;
            txtNuevos.Text = string.IsNullOrWhiteSpace(detalle.ValoresNuevos) ? "(sin datos)" : detalle.ValoresNuevos;

            pnlDetalle.Visible = true;
            btnVerDetalle.Text = "OCULTAR DETALLE";
        }

        public void OcultarDetalle()
        {
            pnlDetalle.Visible = false;
            btnVerDetalle.Text = "VER DETALLE";
        }

        public void LimpiarFiltros()
        {
            dtpDesde.Checked = false;
            dtpHasta.Checked = false;
            if (cmbModulo.Items.Count > 0) cmbModulo.SelectedIndex = 0;
            if (cmbAccion.Items.Count > 0) cmbAccion.SelectedIndex = 0;
            if (cmbUsuario.Items.Count > 0) cmbUsuario.SelectedIndex = 0;
            txtBuscar.Clear();
        }

        public void MostrarMensaje(string mensaje, MessageType tipo)
        {
            FrmMessageBox.Show(mensaje, "Auditoría", tipo);
        }
        #endregion

        #region Utilidades de filtros
        private static void Rellenar(ComboBox combo, IReadOnlyList<OpcionFiltroDto> opciones)
        {
            List<OpcionFiltroDto> lista = new() { new OpcionFiltroDto { Valor = string.Empty, Texto = "Todos" } };
            lista.AddRange(opciones);

            combo.DisplayMember = "Texto";
            combo.ValueMember = "Valor";
            combo.DataSource = lista;
            combo.SelectedIndex = 0;
        }

        private static string? ValorSeleccionado(ComboBox combo)
        {
            string? valor = combo.SelectedValue as string;
            return string.IsNullOrEmpty(valor) ? null : valor;
        }
        #endregion

        #region Eventos de controles
        private void btnFiltrar_Click(object sender, EventArgs e) => FiltrarClicked.Invoke(this, EventArgs.Empty);
        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarClicked.Invoke(this, EventArgs.Empty);
        private void btnVerDetalle_Click(object sender, EventArgs e) => VerDetalleClicked.Invoke(this, EventArgs.Empty);

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            FiltrarClicked.Invoke(this, EventArgs.Empty);
        }

        private void dgvAuditoria_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargando) return;
            ActualizarBotonDetalle();
            RegistroSeleccionado.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Formato visual
        private void dgvAuditoria_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvAuditoria.Columns[e.ColumnIndex].Name != "colAccion") return;
            if (dgvAuditoria.Rows[e.RowIndex].DataBoundItem is not AuditoriaDto registro) return;

            e.CellStyle.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            e.CellStyle.ForeColor = registro.Accion switch
            {
                "Registro" => Color.FromArgb(42, 122, 82),
                "Modificación" => Color.FromArgb(176, 120, 10),
                "Eliminación" => Color.FromArgb(178, 58, 58),
                _ => Color.FromArgb(8, 31, 63)
            };
        }

        private void ActualizarBotonDetalle()
        {
            bool habilitado = RegistroSeleccionadoId.HasValue;
            btnVerDetalle.Enabled = habilitado;
            btnVerDetalle.BackColor = habilitado ? Color.LightSkyBlue : Color.FromArgb(232, 236, 239);
            btnVerDetalle.ForeColor = habilitado ? Color.FromArgb(8, 31, 63) : Color.FromArgb(155, 163, 170);
        }
        #endregion

        #region Liberación de recursos
        private void FrmAuditoria_FormClosed(object? sender, FormClosedEventArgs e)
        {
            _presenter?.Dispose();
            _presenter = null;
        }
        #endregion
    }
}
