using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ocean_Desk_dv;

namespace Ocean_Desk_dv.UI
{
    public partial class FrmMainMenu : Form
    {
        // Se creo el objeto Login para instanciar enviar la referencia del formulario de login al formulario principal
        private FrmLogin login;

        // Colores para los botones del menú
        private Color colorNormal = Color.Transparent;
        private Color colorHover = Color.FromArgb(20, 52, 90);
        private Color colorActivo = Color.FromArgb(30, 70, 115);
        private Button botonActivo = null;

        private Color colorBarraActivo = Color.FromArgb(0, 190, 220); // Color de la barra lateral para el botón activo
        private Panel indicadorActivo; // Panel para indicar el botón activo

        public FrmMainMenu(FrmLogin login)
        {
            InitializeComponent();
            this.login = login;

            // Inicializar el panel indicador para el botón activo
            indicadorActivo = new Panel();

            indicadorActivo.Width = 4;
            indicadorActivo.Height = btnInicio.Height;
            indicadorActivo.BackColor = colorBarraActivo;
            indicadorActivo.Visible = false;

            pnlMenu.Controls.Add(indicadorActivo);
            indicadorActivo.BringToFront();
        }

        /// <summary>
        /// Maneja el evento MouseEnter de los botones del menú, cambiando su color de fondo al color de hover.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton_MouseEnter(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            if (boton != null && boton != botonActivo)
            {
                boton.BackColor = colorHover;
            }
        }

        /// <summary>
        /// Maneja el evento MouseLeave de los botones del menú, restaurando su color de fondo al color normal si no es el botón activo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton_MouseLeave(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            if (boton != null && boton != botonActivo)
            {
                boton.BackColor = colorNormal;
            }
        }

        /// <summary>
        /// Maneja el evento Click de los botones del menú, seleccionando el botón y cambiando su color de fondo al color activo.
        /// </summary>
        /// <param name="boton"></param>
        private void SeleccionarBoton(Button boton)
        {
            // Restablecer el botón anteriormente seleccionado
            if (botonActivo != null)
            {
                botonActivo.BackColor = colorNormal;
            }

            // Seleccionar el nuevo botón
            botonActivo = boton;
            botonActivo.BackColor = colorActivo;

            // Posicionar la barra en el botón seleccionado
            indicadorActivo.Height = boton.Height;
            indicadorActivo.Top = boton.Top;
            indicadorActivo.Left = 0;

            indicadorActivo.Visible = true;
            indicadorActivo.BringToFront();
        }

        /// <summary>
        /// Maneja el evento Click del botón de cerrar sesión, limpiando los campos del formulario de login, ocultando el formulario principal y mostrando el formulario de login.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            login.LimpiarCampos(); // Llamar al método LimpiarCampos() del formulario de login para limpiar los campos de usuario y contraseña

            this.Hide();

            login.Show();
        }

        /// <summary>
        /// Maneja el evento Click de los botones del menú, llamando al método SeleccionarBoton() para cambiar el color de fondo del botón seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnInicio_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnInicio);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnUsuarios);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnClientes);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnProductos);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnInventario);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnCompras);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnVentas);
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnFacturacion);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnProveedores);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnReportes);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEmpleados);
        }

        private void btnMesas_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnMesas);
        }

        private void btnCocina_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnCocina);
        }

        private void btnBitacoras_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnBitacoras);
        }
    }
}
