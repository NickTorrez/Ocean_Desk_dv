using Ocean_Desk_dv.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ocean_Desk_dv.UI
{
    public partial class FrmLoading : Form
    {
        private int progreso;

        private FrmLogin _login;

        private readonly UsuarioAutenticadoDto _usuarioAutenticado;

        public FrmLoading(FrmLogin login, UsuarioAutenticadoDto usuarioAutenticado)
        {
            InitializeComponent();

            _login = login ??throw new ArgumentNullException(nameof(login));

            _usuarioAutenticado = usuarioAutenticado ??
                throw new ArgumentNullException(nameof(usuarioAutenticado));

            if (_usuarioAutenticado.UserId <= 0)
                throw new ArgumentException("La identidad del usuario no es válida.");

            if (_usuarioAutenticado.MustChangePassword)
                throw new InvalidOperationException("El usuario todavía debe cambiar su contraseña.");
        }

        private void FrmLoading_Load(object sender, EventArgs e)
        {
            // Configurar el estilo del ProgressBar para que sea continuo
            progreso = 0;
            progressbar.Value = 0;
            lblStatus.Text = "Iniciando sistema...";

            // Iniciar el temporizador para simular la carga
            timerLoading.Start();
        }

        /// <summary>
        /// Maneja el evento Tick del temporizador, actualizando el progreso y el estado de carga en la interfaz de usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerLoading_Tick(object sender, EventArgs e)
        {
            progreso += 2;

            if (progreso <= 100)
            {
                progressbar.Value = progreso;
            }

            if (progreso < 25)
            {
                lblStatus.Text = "Inicializando componentes...";
            }
            else if (progreso < 50)
            {
                lblStatus.Text = "Preparando entorno...";
            }
            else if (progreso < 75)
            {
                lblStatus.Text = "Cargando configuración...";
            }
            else if (progreso < 95)
            {
                lblStatus.Text = "Verificando sistema...";
            }
            else if (progreso < 100)
            {
                lblStatus.Text = "Finalizando carga...";
            }
            else
            {
                timerLoading.Stop();

                lblStatus.Text = "Sistema listo.";

                AbrirMenuPrincipal();
            }
        }

        /// <summary>
        /// Abre el formulario principal del sistema y oculta el formulario de carga.
        /// </summary>
        private void AbrirMenuPrincipal()
        {
            FrmMainMenu menuPrincipal = new FrmMainMenu(
                _login,
                _usuarioAutenticado);

            menuPrincipal.Show();

            // El formulario de carga ya no se necesita.
            Close();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
