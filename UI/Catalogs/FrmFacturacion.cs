using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ocean_Desk_dv.UI.Models;

namespace Ocean_Desk_dv.UI.Catalogs
{
    public partial class FrmFacturacion : Form
    {
        private readonly List<FacturaPrueba> _facturas = new List<FacturaPrueba>(); //Declaramos una lista para las facturas

        public FrmFacturacion()
        {
            InitializeComponent();

            CargarFacturasPrueba(); //Cargamos las Facturas
            MostrarFacturas(); //Se mjuestran las facturas en el dgv
            ActualizarEstadoBotones(); //Comportamiento entre botones y dgv
        }

        #region Metodos para Cargar y Mostrar Facturas de Prueba
        private void MostrarFacturas()
        {
            dgvFacturas.DataSource = null;
            dgvFacturas.DataSource = _facturas;
        }

        private void CargarFacturasPrueba()
        {
            _facturas.Clear();

            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0001",
                Fecha = DateTime.Today,
                Cliente = "Juan Pérez",
                TipoOrden = "Local",
                Total = 450.00m,
                Estado = "Pagada"
            });

            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0002",
                Fecha = DateTime.Today,
                Cliente = "María López",
                TipoOrden = "Delivery",
                Total = 320.50m,
                Estado = "Pagada"
            });

            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0003",
                Fecha = DateTime.Today.AddDays(-1),
                Cliente = "Carlos Rodríguez",
                TipoOrden = "Local",
                Total = 180.00m,
                Estado = "Anulada"
            });

            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0004",
                Fecha = DateTime.Today.AddDays(-2),
                Cliente = "Consumidor Final",
                TipoOrden = "Local",
                Total = 275.75m,
                Estado = "Pagada"
            });

            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0005",
                Fecha = DateTime.Today.AddDays(-3),
                Cliente = "Ana Martínez",
                TipoOrden = "Delivery",
                Total = 525.00m,
                Estado = "Pagada"
            });

            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0006",
                Fecha = DateTime.Today.AddDays(-4),
                Cliente = "Pedro Gómez",
                TipoOrden = "Local",
                Total = 150.00m,
                Estado = "Anulada"
            });
        }
        #endregion

        #region Metodos de Comportamiento entre los Buttons y el Dgv
        private void ActualizarEstadoBotones()//Reacción de los botones al tipo de factura
        {
            bool haySeleccion = dgvFacturas.SelectedRows.Count > 0;

            if (!haySeleccion)
            {
                ConfigurarEstadoBoton(
                    btnVerDetalle,
                    false,
                    _colorBotonNormal,
                    _colorBotonTexto);

                ConfigurarEstadoBoton(
                    btnImprimir,
                    false,
                    _colorBotonNormal,
                    _colorBotonTexto);

                ConfigurarEstadoBoton(
                    btnAnular,
                    false,
                    _colorAnularNormal,
                    _colorAnularTexto);

                return;
            }

            DataGridViewRow fila = dgvFacturas.SelectedRows[0];

            string estado = fila.Cells["colEstado"].Value?.ToString();

            bool facturaAnulada = estado == "Anulada";

            ConfigurarEstadoBoton(
                btnVerDetalle,
                true,
                _colorBotonNormal,
                _colorBotonTexto);

            ConfigurarEstadoBoton(
                btnImprimir,
                true,
                _colorBotonNormal,
                _colorBotonTexto);

            ConfigurarEstadoBoton(
                btnAnular,
                !facturaAnulada,
                _colorAnularNormal,
                _colorAnularTexto);
        }

        private void dgvFacturas_SelectionChanged(object sender, EventArgs e) //Reaccion del dgv a los botones
        {
            ActualizarEstadoBotones();
        }
        #endregion

        private readonly Color _colorBotonNormal = Color.FromArgb(238, 243, 247);

        private readonly Color _colorBotonTexto = Color.FromArgb(8, 31, 63);

        private readonly Color _colorBotonDisabled = Color.FromArgb(232, 236, 239);

        private readonly Color _colorTextoDisabled = Color.FromArgb(155, 163, 170);

        private readonly Color _colorAnularNormal = Color.FromArgb(248, 234, 234);

        private readonly Color _colorAnularTexto = Color.FromArgb(163, 61, 61);

        private void ConfigurarEstadoBoton(Button boton,bool habilitado,Color colorNormal,Color colorTexto)
        {
            boton.Enabled = habilitado;

            if (habilitado)
            {
                boton.BackColor = colorNormal;
                boton.ForeColor = colorTexto;
            }
            else
            {
                boton.BackColor = _colorBotonDisabled;
                boton.ForeColor = _colorTextoDisabled;
            }
        }
    }
}
