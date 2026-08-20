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
using CevicheSys_Pro_2.Helpers;

namespace CevicheSys_Pro_2.UI.Catalogs
{

    public partial class FrmInventario : Form
    {
        // Controladores de Lógica de Negocio Reales
        private readonly ProductBusiness _productBusiness;
        private readonly DishBusiness _dishBusiness;
        private readonly CategoryBusiness _categoryBusiness;
        private readonly SupplierBusiness _supplierBusiness;

        // Variables de estado internas para guardar los IDs seleccionados de las tablas
        private int _productoSeleccionadoId = 0;
        private int _platilloSeleccionadoId = 0;

        // DataTables en memoria para soportar el filtrado/búsqueda en tiempo real
        private DataTable _dtProductos = new DataTable();
        private DataTable _dtPlatillos = new DataTable();

        public FrmInventario()
        {
            InitializeComponent();
            // Inicialización de capas de negocio
            _productBusiness = new ProductBusiness();
            _dishBusiness = new DishBusiness();
            _categoryBusiness = new CategoryBusiness();
            _supplierBusiness = new SupplierBusiness();

            ResponsiveUi.Apply(this);
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            AsignarEventosEstilo();
            AjustarLayoutMaximizado();
            CargarCombosMaestros();
            CargarInventarioProductos();
            CargarInventarioPlatillos();
        }

        #region Eventos Visuales
        private void AsignarEventosEstilo()
        {
            // Pestaña Insumos
            var controlesInsumos = new List<Control>
            {
                txtNombreProducto, cmbCategoria, cmbProveedor,
                txtStockActual, dtpFechaVencimiento, txtBuscarProducto
            };

            // Pestaña Platillos
            var controlesPlatillos = new List<Control>
            {
                txtTipoPlatillo, txtTamano, txtPrecio, txtBuscarPlatillo
            };

            // Unificar y asignar dinámicamente
            foreach (var ctrl in controlesInsumos.Concat(controlesPlatillos))
            {
                ResponsiveUi.AddFocusStyle(ctrl);
            }
        }

        private void InputControl_Enter(object sender, EventArgs e)
        {
            if (sender is Control ctrl)
            {
                ctrl.BackColor = Color.FromArgb(227, 242, 253);
            }
        }

        private void InputControl_Leave(object sender, EventArgs e)
        {
            if (sender is Control ctrl)
            {
                ctrl.BackColor = Color.White;
            }
        }
        #endregion

        private void AjustarLayoutMaximizado()
        {
            tableLayoutPanel1.ColumnStyles[0].Width = 32F;
            tableLayoutPanel1.ColumnStyles[1].Width = 68F;
            tableLayoutPanel2.ColumnStyles[0].Width = 32F;
            tableLayoutPanel2.ColumnStyles[1].Width = 68F;
            pnlBuscarProducto.Height = Math.Max(pnlBuscarProducto.Height, 72);
            pnlBuscarPlatillo.Height = Math.Max(pnlBuscarPlatillo.Height, 72);
        }

        #region Métodos de Carga de Datos
        private void CargarCombosMaestros()
        {
            try
            {
                // Categorías usando el método real 'ListCategories()'
                DataTable dtCategorias = _categoryBusiness.ListCategories("Inventario");
                cmbCategoria.DataSource = dtCategorias;
                cmbCategoria.DisplayMember = "Category_Name"; // Propiedad real de tu BD
                cmbCategoria.ValueMember = "Category_Id";
                cmbCategoria.SelectedIndex = -1;

                // Proveedores usando el método real 'ListSuppliers()'
                DataTable dtProveedores = _supplierBusiness.ListSuppliers();
                cmbProveedor.DataSource = dtProveedores;
                cmbProveedor.DisplayMember = "Supplier_Name"; // Propiedad calculada o real de tu BD
                cmbProveedor.ValueMember = "Supplier_Id";
                cmbProveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar catálogos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarInventarioProductos()
        {
            try
            {
                // Método real de tu ProductBusiness es 'ListProducts()'
                _dtProductos = _productBusiness.ListProducts();
                dgvInventario.DataSource = null;
                dgvInventario.DataSource = _dtProductos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarInventarioPlatillos()
        {
            try
            {
                // Método real de tu DishBusiness es 'ListDishes()'
                _dtPlatillos = _dishBusiness.ListDishes();
                dgvPlatillos.DataSource = null;
                dgvPlatillos.DataSource = _dtPlatillos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar platillos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Eventos de Botones Producto

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposProducto()) return;

            try
            {
                Product nuevoProducto = new Product
                {
                    Product_Name = txtNombreProducto.Text.Trim(),
                    Category_Id = Convert.ToInt32(cmbCategoria.SelectedValue),
                    Supplier_Id = Convert.ToInt32(cmbProveedor.SelectedValue),
                    Current_Stock = Convert.ToDecimal(txtStockActual.Text.Trim()),
                    Expiration_Date = dtpFechaVencimiento.Value,
                    Enable = true
                };

                // Solución al Error CS0029: Tu método es void. Si no lanza excepción, es exitoso.
                _productBusiness.InsertProduct(nuevoProducto);

                MessageBox.Show("Insumo guardado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarInventarioProductos();
                LimpiarCamposProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionadoId <= 0)
            {
                MessageBox.Show("Seleccione un producto del listado para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCamposProducto()) return;

            try
            {
                Product productoEditar = new Product
                {
                    Product_Id = _productoSeleccionadoId, // Se gestiona internamente
                    Product_Name = txtNombreProducto.Text.Trim(),
                    Category_Id = Convert.ToInt32(cmbCategoria.SelectedValue),
                    Supplier_Id = Convert.ToInt32(cmbProveedor.SelectedValue),
                    Current_Stock = Convert.ToDecimal(txtStockActual.Text.Trim()),
                    Expiration_Date = dtpFechaVencimiento.Value,
                    Enable = true
                };

                // Tu método de negocio es void
                _productBusiness.UpdateProduct(productoEditar);

                MessageBox.Show("Insumo actualizado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarInventarioProductos();
                LimpiarCamposProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionadoId <= 0)
            {
                MessageBox.Show("Seleccione un producto del listado para dar de baja.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea dar de baja este insumo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // Tu método de negocio es void
                    _productBusiness.DeleteProduct(_productoSeleccionadoId);

                    MessageBox.Show("Insumo dado de baja con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarInventarioProductos();
                    LimpiarCamposProducto();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCamposProducto();
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            if (_dtProductos != null)
            {
                // Filtrado nativo sobre el DataView del DataTable para búsquedas instantáneas sin recargar base de datos
                string filtro = txtBuscarProducto.Text.Trim().Replace("'", "''");
                _dtProductos.DefaultView.RowFilter = string.IsNullOrEmpty(filtro)
                    ? ""
                    : $"Product_Name LIKE '%{filtro}%'";
            }
        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {// 1. BLINDAJE CRÍTICO: Si hacen clic en los encabezados de columna (fila -1)
         // o el control detecta un área vacía (CurrentRow nulo), salimos del método para evitar el crash.
            if (e.RowIndex < 0 || dgvInventario.CurrentRow == null)
            {
                return;
            }

            try
            {
                // Capturamos de forma segura la fila seleccionada
                DataGridViewRow filaActual = dgvInventario.Rows[e.RowIndex];

                // 2. DETECCIÓN DE FILA FANTASMA: Si es la fila en blanco para agregar nuevos registros de Windows Forms, salimos.
                if (filaActual.IsNewRow)
                {
                    return;
                }

                // 3. MAPEO SEGURO DE TEXTOS (Nombre del Insumo/Producto)
                // Usamos ?.ToString() ?? string.Empty para que si la celda es NULL en SQL Server, no explote el programa.
                _productoSeleccionadoId = Convert.ToInt32(filaActual.Cells["Product_Id"].Value ?? 0);
                txtNombreProducto.Text = filaActual.Cells["Product_Name"].Value?.ToString() ?? string.Empty;

                // 4. MAPEO SEGURO DE COMBOBOXES (Categoría y Proveedor)
                // Buscamos el texto en el ComboBox. Si existe, lo selecciona.
                if (filaActual.Cells["Category_Id"].Value != null && filaActual.Cells["Category_Id"].Value != DBNull.Value)
                    cmbCategoria.SelectedValue = Convert.ToInt32(filaActual.Cells["Category_Id"].Value);

                if (filaActual.Cells["Supplier_Id"].Value != null && filaActual.Cells["Supplier_Id"].Value != DBNull.Value)
                    cmbProveedor.SelectedValue = Convert.ToInt32(filaActual.Cells["Supplier_Id"].Value);
                else
                    cmbProveedor.SelectedIndex = -1;

                // 5. MAPEO SEGURO DE NÚMEROS (Precio de Compra y Stock Actual)

                if (filaActual.Cells["Current_Stock"].Value != null && filaActual.Cells["Current_Stock"].Value != DBNull.Value)
                {
                    txtStockActual.Text = Convert.ToDecimal(filaActual.Cells["Current_Stock"].Value).ToString("0.##");
                }
                else
                {
                    txtStockActual.Text = "0";
                }

                // 6. MAPEO SEGURO DE FECHA (Fecha de Vencimiento)
                if (filaActual.Cells["Expiration_Date"].Value != null && filaActual.Cells["Expiration_Date"].Value != DBNull.Value)
                {
                    dtpFechaVencimiento.Value = Convert.ToDateTime(filaActual.Cells["Expiration_Date"].Value);
                }
                else
                {
                    dtpFechaVencimiento.Value = DateTime.Today; // Fecha por defecto segura si viene vacía en la BD
                }
            }
            catch (Exception ex)
            {
                // El bloque catch absorbe cualquier error inesperado y muestra una alerta amigable
                MessageBox.Show($"Aviso de consistencia al mapear el insumo: {ex.Message}", "Inventario de Insumos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidarCamposProducto()
        {
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text) || cmbCategoria.SelectedIndex == -1 ||
                cmbProveedor.SelectedIndex == -1 ||string.IsNullOrWhiteSpace(txtStockActual.Text))
            {
                MessageBox.Show("Todos los campos informativos del insumo son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtStockActual.Text, out decimal stock) || stock < 0)
            {
                MessageBox.Show("El stock actual no puede ser un número negativo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarCamposProducto()
        {
            _productoSeleccionadoId = 0;
            txtNombreProducto.Clear();
            cmbCategoria.SelectedIndex = -1;
            cmbProveedor.SelectedIndex = -1;
            txtStockActual.Clear();
            dtpFechaVencimiento.Value = DateTime.Today;
            txtBuscarProducto.Clear();
            txtNombreProducto.Focus();
        }

        #endregion


        #region Eventos de Botones Platillos
        private void btnGuardarPlatillo_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposPlatillo()) return;

            Dish nuevoPlatillo = new Dish
            {
                Dish_Type = txtTipoPlatillo.Text.Trim(), // Mapea al tipo/nombre del platillo
                Size = txtTamano.Text.Trim(),
                Price = Convert.ToDecimal(txtPrecio.Text.Trim()),
                Is_Available = chkDisponible.Checked,
                Enable = chkDisponible.Checked
            };

            int resultado = _dishBusiness.InsertDish(nuevoPlatillo);
            EvaluarRespuestaNegocio(resultado, "Platillo Registrado");

            if (resultado > 0)
            {
                CargarInventarioPlatillos();
                LimpiarCamposPlatillo();
            }
        }

        private void btnEditarPlatillo_Click_1(object sender, EventArgs e)
        {
            if (_platilloSeleccionadoId <= 0)
            {
                MessageBox.Show("Debe seleccionar un platillo de la lista para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCamposPlatillo()) return;

            Dish platilloEditar = new Dish
            {
                Dish_Id = _platilloSeleccionadoId,
                Dish_Type = txtTipoPlatillo.Text.Trim(),
                Size = txtTamano.Text.Trim(),
                Price = Convert.ToDecimal(txtPrecio.Text.Trim()),
                Is_Available = chkDisponible.Checked,
                Enable = chkDisponible.Checked
            };

            int resultado = _dishBusiness.UpdateDish(platilloEditar);
            EvaluarRespuestaNegocio(resultado, "Platillo Modificado");

            if (resultado > 0)
            {
                CargarInventarioPlatillos();
                LimpiarCamposPlatillo();
            }
        }

        private void btnEliminarPlatillo_Click(object sender, EventArgs e)
        {
            if (_platilloSeleccionadoId <= 0)
            {
                MessageBox.Show("Debe seleccionar un platillo de la lista para remover.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Desea retirar de la venta este platillo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                int resultado = _dishBusiness.DeleteDish(_platilloSeleccionadoId);
                EvaluarRespuestaNegocio(resultado, "Platillo Removido");

                if (resultado > 0)
                {
                    CargarInventarioPlatillos();
                    LimpiarCamposPlatillo();
                }
            }
        }

        private void btnLimpiarControles_Click(object sender, EventArgs e)
        {
            LimpiarCamposPlatillo();
        }

        private void LimpiarCamposPlatillo()
        {
            _platilloSeleccionadoId = 0;
            txtTipoPlatillo.Clear();
            txtTamano.Clear();
            txtPrecio.Clear();
            chkDisponible.Checked = true;
            txtBuscarPlatillo.Clear();
            txtTipoPlatillo.Focus();
        }

        private void txtBuscarPlatillo_TextChanged(object sender, EventArgs e)
        {
            if (_dtPlatillos != null)
            {
                string filtro = txtBuscarPlatillo.Text.Trim().Replace("'", "''");
                _dtPlatillos.DefaultView.RowFilter = string.IsNullOrEmpty(filtro)
                    ? ""
                    : $"Dish_Type LIKE '%{filtro}%'";
            }
        }

        private void dgvPlatillos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. BLINDAJE ANTI-ENCABEZADOS: Si el usuario toca los títulos de columna (fila -1)
            // o hace clic en un área muerta donde la fila actual sea nula, cancelamos el proceso de inmediato.
            if (e.RowIndex < 0 || dgvPlatillos.CurrentRow == null)
            {
                return;
            }

            try
            {
                // Capturamos de forma segura la fila que recibió el clic
                DataGridViewRow filaActual = dgvPlatillos.Rows[e.RowIndex];

                // 2. DETECCIÓN DE FILA FANTASMA: Si es la fila en blanco de inserción nueva, salimos.
                if (filaActual.IsNewRow)
                {
                    return;
                }

                _platilloSeleccionadoId = Convert.ToInt32(filaActual.Cells["Dish_Id"].Value ?? 0);

                // 3. MAPEO SEGURO DE TEXTO: Usamos el operador '?.ToString() ?? string.Empty'
                // Esto previene que si 'Dish_Type' o 'Size' son nulos en la BD, la app lance un NullReferenceException
                txtTipoPlatillo.Text = filaActual.Cells["Dish_Type"].Value?.ToString() ?? string.Empty;
                txtTamano.Text = filaActual.Cells["Size"].Value?.ToString() ?? string.Empty;

                // 4. MAPEO SEGURO DE PRECIOS: Validamos que la celda no sea nula ni contenga DBNull
                if (filaActual.Cells["Price"].Value != null && filaActual.Cells["Price"].Value != DBNull.Value)
                {
                    txtPrecio.Text = Convert.ToDecimal(filaActual.Cells["Price"].Value).ToString("F2");
                }
                else
                {
                    txtPrecio.Text = "0.00"; // Valor por defecto seguro si está vacío en SQL
                }

                // 5. MAPEO SEGURO DE CHECKBOX (Estado Activado/Habilitado):
                if (filaActual.Cells["Enable"].Value != null && filaActual.Cells["Enable"].Value != DBNull.Value)
                {
                    chkDisponible.Checked = Convert.ToBoolean(filaActual.Cells["Enable"].Value);
                }
                else
                {
                    chkDisponible.Checked = false;
                }
            }
            catch (Exception ex)
            {
                // Si llegase a ocurrir otra anomalía imprevista, el catch absorbe el golpe 
                // e informa amigablemente en lugar de cerrar el software del restaurante.
                MessageBox.Show($"Aviso de consistencia de datos: {ex.Message}", "Catálogo de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidarCamposPlatillo()
        {
            if (string.IsNullOrWhiteSpace(txtTipoPlatillo.Text) || string.IsNullOrWhiteSpace(txtTamano.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Complete el tipo, tamaño y precio del platillo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio asignado al menú debe ser un número positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        #endregion

        #region Helper de Respuestas del Servidor
        private void EvaluarRespuestaNegocio(int codigo, string operacion)
        {
            if (codigo > 0)
            {
                MessageBox.Show($"Operación [{operacion}] procesada con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Error de consistencia. El servidor de datos devolvió el código de anomalía: {codigo}", "Error en Operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }

}
