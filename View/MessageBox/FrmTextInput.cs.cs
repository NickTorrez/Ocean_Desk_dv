using Ocean_Desk_dv.UI.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv.View.MessageBox
{
    /// <summary>
    /// Formulario reutilizable para solicitar texto al usuario.
    /// </summary>
    public partial class FrmTextInput : Form
    {
        #region Propiedades
        /// <summary>
        /// Obtiene el texto introducido por el usuario.
        /// </summary>
        public string Texto => txtTexto.Text.Trim();

        /// <summary>
        /// Obtiene o establece el título del formulario.
        /// </summary>
        public string Titulo
        {
            get => lblTituloText.Text;
            set => lblTituloText.Text = value;
        }

        /// <summary>
        /// Obtiene o establece el mensaje mostrado al usuario.
        /// </summary>
        public string Mensaje
        {
            get => lblMensajeText.Text;
            set => lblMensajeText.Text = value;
        }
        #endregion

        #region
        public FrmTextInput()
        {
            InitializeComponent();
        }
        #endregion

        #region Botones
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTexto.Text))
            {
                FrmMessageBox.Show(
                    "Ingrese un texto para continuar.",
                    "Entrada de texto",
                    MessageType.Warning);

                txtTexto.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Solicita un texto mediante el formulario personalizado.
        /// </summary>
        public static string? SolicitarTexto(
            IWin32Window? owner,
            string titulo,
            string mensaje)
        {
            using var formulario = new FrmTextInput();

            formulario.Titulo = titulo;
            formulario.Mensaje = mensaje;

            DialogResult resultado =
                owner == null
                    ? formulario.ShowDialog()
                    : formulario.ShowDialog(owner);

            return resultado == DialogResult.OK
                ? formulario.Texto
                : null;
        }
        #endregion
    }
}
