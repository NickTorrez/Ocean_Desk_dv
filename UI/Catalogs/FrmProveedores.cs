using CevicheSys_Pro_2.Services.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CevicheSys_Pro_2.Helpers;

namespace CevicheSys_Pro_2.UI.Catalogs
{
    public partial class FrmProveedores : Form
    {
        #region Propiedades y Referencias
        private readonly SupplierBusiness _supplierBusiness;
        private int _proveedorSeleccionadoId = 0;
        #endregion

        #region Constructores y Load
        public FrmProveedores()
        {
            InitializeComponent();
            _supplierBusiness = new SupplierBusiness();
            ResponsiveUi.Apply(this);
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            ConfigurarFormulario();
            ConfigurarGrid();
            CargarProveedores();
            LimpiarCampos();
        }
        #endregion

        #region Configuraciones Visuales y Comportamientos

        private void ConfigurarFormulario()
        {
            txtCedulaRuc.MaxLength = 20;
            txtNombreProveedor.MaxLength = 50;
            txtApellidoProveedor.MaxLength = 50;
            txtTelefono.MaxLength = 20;
            txtEmail.MaxLength = 100;
            txtDireccion.MaxLength = 255;

            // Restringir ingreso de letras en campo teléfono
            txtTelefono.KeyPress += (s, ev) =>
            {
                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && ev.KeyChar != '-')
                    ev.Handled = true;
            };

            ResponsiveUi.AddFocusStyle(
                txtCedulaRuc,
                txtNombreProveedor,
                txtApellidoProveedor,
                txtTelefono,
                txtEmail,
                txtDireccion,
                txtBuscarProveedor);
        }

        private void ConfigurarGrid()
        {
            dgvProveedores.ReadOnly = true;
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.MultiSelect = false;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.BackgroundColor = Color.White;
            dgvProveedores.RowHeadersVisible = false;
            ResponsiveUi.ConfigureGrid(dgvProveedores);
        }

        private void InputControl_Enter(object sender, EventArgs e)
        {
            // Evaluamos si el elemento es un control válido
            if (sender is Control ctrl)
            {
                // Cambia a celeste claro marino al entrar
                ctrl.BackColor = Color.FromArgb(227, 242, 253);
            }
        }

        private void InputControl_Leave(object sender, EventArgs e)
        {
            if (sender is Control ctrl)
            {
                // Regresa a blanco al salir
                ctrl.BackColor = Color.White;
            }
        }
        #endregion

        #region Métodos de Procesamiento
        private void CargarProveedores()
        {
            try
            {
                dgvProveedores.DataSource = _supplierBusiness.ListSuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proveedores:\n{ex.Message}", "Fallo de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            _proveedorSeleccionadoId = 0;
            txtCedulaRuc.Clear();
            txtNombreProveedor.Clear();
            txtApellidoProveedor.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtBuscarProveedor.Clear();
            txtCedulaRuc.Focus();
        }
        #endregion

        #region Eventos de Botones
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier newSupplier = new Supplier
                {
                    Tax_Id = txtCedulaRuc.Text,
                    First_Name = txtNombreProveedor.Text,
                    Last_Name = txtApellidoProveedor.Text,
                    Phone = txtTelefono.Text,
                    Email = txtEmail.Text,
                    Address = txtDireccion.Text
                };

                _supplierBusiness.InsertSupplier(newSupplier);

                MessageBox.Show("Proveedor registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProveedores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación de Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_proveedorSeleccionadoId <= 0)
                    throw new ArgumentException("Seleccione un proveedor del listado antes de editar.");

                Supplier editSupplier = new Supplier
                {
                    Supplier_Id = _proveedorSeleccionadoId,
                    Tax_Id = txtCedulaRuc.Text,
                    First_Name = txtNombreProveedor.Text,
                    Last_Name = txtApellidoProveedor.Text,
                    Phone = txtTelefono.Text,
                    Email = txtEmail.Text,
                    Address = txtDireccion.Text
                };

                _supplierBusiness.UpdateSupplier(editSupplier);

                MessageBox.Show("Proveedor actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProveedores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación de Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_proveedorSeleccionadoId <= 0)
                    throw new ArgumentException("Seleccione un proveedor del listado antes de darlo de baja.");

                if (MessageBox.Show($"¿Dar de baja al proveedor {txtNombreProveedor.Text} {txtApellidoProveedor.Text}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _supplierBusiness.DeleteSupplier(_proveedorSeleccionadoId);
                    MessageBox.Show("Proveedor dado de baja exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProveedores();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }


        private void txtBuscarProveedor_TextChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.DataSource is DataTable dt)
            {
                string filtro = txtBuscarProveedor.Text.Trim().Replace("'", "''");
                dt.DefaultView.RowFilter = string.IsNullOrWhiteSpace(filtro)
                    ? ""
                    : $"Tax_Id LIKE '%{filtro}%' OR First_Name LIKE '%{filtro}%' OR Last_Name LIKE '%{filtro}%'";
            }
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProveedores.CurrentRow != null)
            {
                DataGridViewRow row = dgvProveedores.Rows[e.RowIndex];
                _proveedorSeleccionadoId = Convert.ToInt32(row.Cells["Supplier_Id"]?.Value ?? 0);
                txtCedulaRuc.Text = row.Cells["Tax_Id"]?.Value?.ToString() ?? "";
                txtNombreProveedor.Text = row.Cells["First_Name"]?.Value?.ToString() ?? "";
                txtApellidoProveedor.Text = row.Cells["Last_Name"]?.Value?.ToString() ?? "";
                txtTelefono.Text = row.Cells["Phone"]?.Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"]?.Value?.ToString() ?? "";
                txtDireccion.Text = row.Cells["Address"]?.Value?.ToString() ?? "";
            }
        }
        #endregion
    }
}
