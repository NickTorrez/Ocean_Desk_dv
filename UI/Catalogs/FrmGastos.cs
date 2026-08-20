using CevicheSys_Pro_2.Helpers;
using CevicheSys_Pro_2.Services.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CevicheSys_Pro_2.UI.Catalogs
{
    public partial class FrmGastos : Form
    {
        #region Properties
        private readonly ExpenseBusiness _expenseBusiness;
        private readonly CategoryBusiness _categoryBusiness;
        private readonly SupplierBusiness _supplierBusiness;
        private int _gastoSeleccionadoId = 0;
        #endregion

        #region Constructores y Load
        public FrmGastos()
        {
            InitializeComponent();
            _expenseBusiness = new ExpenseBusiness();
            _categoryBusiness = new CategoryBusiness();
            _supplierBusiness = new SupplierBusiness();
            ResponsiveUi.Apply(this);
            ConfigurarLayoutFiltro();
            pnlFiltrar.Resize += (_, _) => AlinearFechaFin();
        }

        private void FrmGastos_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            ConfigurarLayoutFiltro();
            CargarCombos();
            CargarGastos();
            LimpiarFormulario();
        }
        #endregion

        #region Configuraciones Visuales y Comportamientos
        private void ConfigurarGrid()
        {
            dgvGastos.ReadOnly = true;
            dgvGastos.AllowUserToAddRows = false;
            dgvGastos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGastos.MultiSelect = false;
            dgvGastos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGastos.BackgroundColor = Color.White;
            dgvGastos.RowHeadersVisible = false;
            ResponsiveUi.ConfigureGrid(dgvGastos);

            // Si el grid ya tiene las columnas autogeneradas no hay problema.
            // Opcional: dgvGastos.Columns["Expense_Id"].Visible = false;
        }

        private void ConfigurarLayoutFiltro()
        {
            dtpInicio.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            dtpFin.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            if (dtpInicio.MaximumSize.Width > 0)
                dtpInicio.MaximumSize = Size.Empty;

            if (dtpFin.MaximumSize.Width > 0)
                dtpFin.MaximumSize = Size.Empty;

            dtpInicio.Width = 250;
            dtpFin.Width = 250;

            dtpInicio.MinimumSize = new Size(dtpInicio.Width, 0);
            dtpInicio.MaximumSize = new Size(dtpInicio.Width, 0);
            dtpFin.MinimumSize = new Size(dtpFin.Width, 0);
            dtpFin.MaximumSize = new Size(dtpFin.Width, 0);

            AlinearFechaFin();
        }

        private void AlinearFechaFin()
        {
            const int margenDerecho = 24;
            dtpFin.Left = Math.Max(dtpInicio.Right + 24, pnlFiltrar.ClientSize.Width - dtpFin.Width - margenDerecho);
        }

        private void CargarCombos()
        {
            try
            {
                // Cargar Categorías
                cmbTipoGasto.DataSource = _categoryBusiness.ListCategories();
                cmbTipoGasto.DisplayMember = "Category_Name";
                cmbTipoGasto.ValueMember = "Category_Id";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de gasto:\n{ex.Message}", "Catálogos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            // Evaluamos si el elemento es un control válido
            if (sender is Control ctrl)
            {
                // Cambia a celeste claro marino al entrar
                ctrl.BackColor = Color.FromArgb(227, 242, 253);
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (sender is Control ctrl)
            {
                // Regresa a blanco al salir
                ctrl.BackColor = Color.White;
            }
        }

        #endregion

        #region Metodos de Procesamiento
        private void CargarGastos()
        {
            try
            {
                dgvGastos.DataSource = _expenseBusiness.ListExpenses();
                AplicarFiltro();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar gastos:\n{ex.Message}", "Fallo de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltro()
        {
            if (dgvGastos.DataSource is DataTable dt)
            {
                string inicio = dtpInicio.Value.Date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                string fin = dtpFin.Value.Date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                dt.DefaultView.RowFilter = $"Date >= #{inicio}# AND Date <= #{fin}#";
            }
        }

        private void LimpiarFormulario()
        {
            _gastoSeleccionadoId = 0;
            txtConcepto.Clear();
            txtMonto.Clear();
            cmbTipoGasto.SelectedIndex = cmbTipoGasto.Items.Count > 0 ? 0 : -1;
            dtpFechaGasto.Value = DateTime.Today;
        }

        private void SoloNumerosYDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.' && sender is TextBox txt && txt.Text.Contains("."))
                e.Handled = true;
        }

        #endregion

        #region Eventos de Botones
        private void btnGuardarEgreso_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtMonto.Text, out decimal monto))
                    throw new ArgumentException("El monto ingresado no es válido.");
                if (cmbTipoGasto.SelectedValue == null || cmbTipoGasto.SelectedIndex < 0)
                    throw new ArgumentException("Debe seleccionar un tipo de gasto válido.");

                Expense newExpense = new Expense
                {
                    Category_Id = Convert.ToInt32(cmbTipoGasto.SelectedValue),
                    Concept = txtConcepto.Text,
                    Amount = monto,
                    Date = dtpFechaGasto.Value.Date,
                    User_Id = Session.ActiveUser?.User_Id ?? 1 // Tomamos el ID del usuario en sesión
                };

                _expenseBusiness.InsertExpense(newExpense);

                MessageBox.Show("Egreso registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGastos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación de Gasto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditarEgreso_Click(object sender, EventArgs e)
        {
            try
            {
                if (_gastoSeleccionadoId <= 0)
                    throw new ArgumentException("Seleccione un gasto del listado antes de editar.");

                if (!decimal.TryParse(txtMonto.Text, out decimal monto))
                    throw new ArgumentException("El monto ingresado no es válido.");

                if (cmbTipoGasto.SelectedValue == null || cmbTipoGasto.SelectedIndex < 0)
                    throw new ArgumentException("Debe seleccionar un tipo de gasto válido.");

                Expense editExpense = new Expense
                {
                    Expense_Id = _gastoSeleccionadoId,
                    Category_Id = Convert.ToInt32(cmbTipoGasto.SelectedValue),
                    Concept = txtConcepto.Text.Trim(),
                    Amount = monto,
                    Date = dtpFechaGasto.Value.Date,
                    User_Id = Session.ActiveUser?.User_Id ?? 1
                };

                _expenseBusiness.UpdateExpense(editExpense);

                MessageBox.Show("Egreso actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGastos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación de Gasto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarEgreso_Click(object sender, EventArgs e)
        {
            try
            {
                if (_gastoSeleccionadoId <= 0)
                    throw new ArgumentException("Seleccione un gasto del listado antes de anularlo.");

                if (MessageBox.Show($"¿Desea anular permanentemente este gasto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _expenseBusiness.DeleteExpense(_gastoSeleccionadoId);
                    MessageBox.Show("Gasto anulado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGastos();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvGastos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvGastos.CurrentRow != null)
            {
                DataGridViewRow row = dgvGastos.Rows[e.RowIndex];
                _gastoSeleccionadoId = Convert.ToInt32(row.Cells["Expense_Id"]?.Value ?? 0);
                dtpFechaGasto.Value = Convert.ToDateTime(row.Cells["Date"].Value);
                txtConcepto.Text = row.Cells["Concept"]?.Value?.ToString();
                txtMonto.Text = row.Cells["Amount"]?.Value?.ToString();
            }
        }

        private void btnFiltrarEgreso_Click(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnLimpiarEgreso_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        #endregion

        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
