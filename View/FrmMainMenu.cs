using Ocean_Desk_dv;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.UI.Catalogs;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.View.Catalogs;
using Ocean_Desk_dv.View.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv.UI
{
    public partial class FrmMainMenu : Form
    {
        #region Variables 
        // Se creo el objeto Login para instanciar enviar la referencia del formulario de login al formulario principal
        private FrmLogin login;
        private readonly int _usuarioId;
        private bool _permitirCerrarFormulario;

        // Colores para los botones del menú
        private Color colorNormal = Color.Transparent;
        private Color colorHover = Color.FromArgb(20, 52, 90);
        private Color colorActivo = Color.FromArgb(30, 70, 115);
        private Button botonActivo = null;

        private Color colorBarraActivo = Color.FromArgb(0, 190, 220); // Color de la barra lateral para el botón activo
        private Panel indicadorActivo; // Panel para indicar el botón activo

        #endregion

        #region Constructor y Inicialización
        public FrmMainMenu(FrmLogin login) : this(login, 1) { }
        public FrmMainMenu(FrmLogin login, int usuarioId)
        {
            if (login == null)
                throw new ArgumentNullException(nameof(login));

            if (usuarioId <= 0)
                throw new ArgumentOutOfRangeException(nameof(usuarioId));

            InitializeComponent();
            this.login = login;
            _usuarioId = usuarioId;

            this.FormClosing += FrmMainMenu_FormClosing;

            // Inicializar el panel indicador para el botón activo
            indicadorActivo = new Panel();

            indicadorActivo.Width = 4;
            indicadorActivo.Height = btnReportes.Height;
            indicadorActivo.BackColor = colorBarraActivo;
            indicadorActivo.Visible = false;

            pnlMenu.Controls.Add(indicadorActivo);
            indicadorActivo.BringToFront();

            //Iniciar Timer
            tmrReloj.Start();
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {

            lblSeccion.Text = "Inicio";
            lblSubtitulo.Text = "Seleccione un módulo para comenzar";
        }

        private void AbrirFormularioEnPanel(Form formulario)
        {
            // Limpiar el contenido actual
            pnlContent.Controls.Clear();

            // El formulario no se mostrará como ventana independiente
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            // Agregarlo al panel principal
            pnlContent.Controls.Add(formulario);

            // Llevarlo al frente
            formulario.BringToFront();

            // Mostrarlo
            formulario.Show();
        }

        private void FrmMainMenu_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_permitirCerrarFormulario)
                return;

            if (!ValidarCajaParaSalir())
                e.Cancel = true;
        }
        #endregion

        #region Validación de Apertura/Cierre de Caja
        private bool TieneCajaAbierta()
        {
            try
            {
                using var context = new OceanDeskDbContext();

                return context.CashRegisters.Any(c =>
                    c.OpeningUserId == _usuarioId &&
                    c.Status == "Open");
            }
            catch (Exception ex)
            {
                FrmMessageBox.Show(
                    $"No fue posible verificar el estado de la caja.\n\n{ex.Message}",
                    "Verificación de caja",
                    MessageType.Error);

                return false;
            }
        }

        private bool ValidarCajaParaPuntoVenta()
        {
            if (TieneCajaAbierta())
                return true;

            FrmMessageBox.Show(
                "Debe realizar la apertura de caja antes de ingresar al Punto de Venta.",
                "Caja requerida",
                MessageType.Warning);

            return false;
        }

        private bool ValidarCajaParaSalir()
        {
            if (!TieneCajaAbierta())
                return true;

            FrmMessageBox.Show(
                "No puede salir del sistema mientras tenga una caja abierta.\n\n" +
                "Realice primero el cierre de caja y luego vuelva a intentarlo.",
                "Cierre de caja requerido",
                MessageType.Warning);

            return false;
        }
        #endregion

        #region Metodos de eventos
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

        private void WindowButton_MouseEnter(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            if (boton != null)
            {
                boton.BackColor = Color.FromArgb(235, 242, 247);
            }
        }

        private void WindowButton_MouseLeave(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            if (boton != null)
            {
                boton.BackColor = Color.Transparent;
            }
        }
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(220, 70, 70);
            btnClose.ForeColor = Color.White;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Transparent;
            btnClose.ForeColor = Color.FromArgb(18, 48, 71);
        }

        #endregion

        #region Botones y Controles
        /// <summary>
        /// Maneja el evento Click del botón de cerrar sesión, limpiando los campos del formulario de login, ocultando el formulario principal y mostrando el formulario de login.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (!ValidarCajaParaSalir())
                return;

            login.LimpiarCampos(); // Llamar al método LimpiarCampos() del formulario de login para limpiar los campos de usuario y contraseña

            this.Hide();

            login.Show();
        }

        /// <summary>
        /// Maneja el evento Click de los botones del menú, llamando al método SeleccionarBoton() para cambiar el color de fondo del botón seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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
            if (!ValidarCajaParaPuntoVenta())
                return;

            SeleccionarBoton(btnVentas);

            lblSeccion.Text = "Punto de Venta";
            lblSubtitulo.Text = "Control y Toma de Ordenes";

            FrmPuntoVenta ventas = new FrmPuntoVenta();
            AbrirFormularioEnPanel(ventas);
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnFacturacion);

            lblSeccion.Text = "Facturación";
            lblSubtitulo.Text = "Gestión y Consultas de Comprobantes";

            FrmFacturacion facturacion = new FrmFacturacion();
            AbrirFormularioEnPanel(facturacion);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnProveedores);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEmpleados);
        }

        private void btnMesas_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnMesas);

            lblSeccion.Text = "Gestión de Mesas";
            lblSubtitulo.Text = "Disponibilidad y asignación de mesas";

            FrmMesasReservas mesas = new FrmMesasReservas();
            AbrirFormularioEnPanel(mesas);
        }

        private void btnCocina_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnCocina);

            lblSeccion.Text = "Control de Pedidos";
            lblSubtitulo.Text = "Gestión y seguimiento de pedidos en cocina";

            FrmCocinaPedidos cocina = new FrmCocinaPedidos();
            AbrirFormularioEnPanel(cocina);
        }

        private void btnBitacoras_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnBitacoras);
        }

        private void tmrReloj_Tick(object sender, EventArgs e)
        {
            // Actualiza la hora y la fecha cada segundo
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt"); // Formato 12 horas con AM/PM
            lblFecha.Text = DateTime.Now.ToLongDateString(); // Ejemplo: "lunes, 24 de mayo de 2026"
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnCaja);

            lblSeccion.Text = "Manejo de Caja";
            lblSubtitulo.Text = "Entrada, salida y cierre diario de dinero";

            FrmCaja caja = new FrmCaja(_usuarioId);
            AbrirFormularioEnPanel(caja);
        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnPromociones);
        }

        private void btnFidelizacion_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnFidelizacion);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximize.Text = "❐";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximize.Text = "□";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!ValidarCajaParaSalir())
                return;

            _permitirCerrarFormulario = true;

            Application.Exit();
        }

        private void btnReportes_Click_1(object sender, EventArgs e)
        {
            SeleccionarBoton(btnReportes);

            lblSeccion.Text = "Reportes";
            lblSubtitulo.Text = "Indicadores y comportamiento general";

            FrmReportes reportes = new FrmReportes();

            AbrirFormularioEnPanel(reportes);
        }
        #endregion

    }
}

