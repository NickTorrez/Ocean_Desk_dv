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
    /// Representa un cuadro de diálogo que solicita al usuario un valor decimal.
    /// </summary>
    public partial class FrmInputBox : Form
    {
        #region Propiedades
        /// <summary>
        /// Obtiene el valor decimal ingresado por el usuario en el cuadro de diálogo.
        /// </summary>
        public decimal Valor => nudValor.Value;

        /// <summary>
        /// Obtiene o establece el título del cuadro de diálogo.
        /// </summary>
        public string Titulo
        {
            get => lblTitulo.Text;
            set => lblTitulo.Text = value;
        }

        /// <summary>
        /// Obtiene o establece el mensaje que se mostrará al usuario en el cuadro de diálogo.
        /// </summary>
        public string Mensaje
        {
            get => lblMensaje.Text;
            set => lblMensaje.Text = value;
        }
        #endregion

        #region Constructor
        public FrmInputBox()
        {
            InitializeComponent();
        }
        #endregion

        #region Botones
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Solicita al usuario un monto decimal mediante un cuadro de diálogo.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="titulo"></param>
        /// <param name="mensaje"></param>
        /// <param name="valorInicial"></param>
        /// <returns></returns>
        public static decimal? SolicitarMonto(
        IWin32Window? owner,
        string titulo,
        string mensaje,
        decimal valorInicial = 0)
        {
            using var formulario = new FrmInputBox();

            formulario.Titulo = titulo;
            formulario.Mensaje = mensaje;
            formulario.nudValor.Value = valorInicial;

            DialogResult resultado =
                owner == null
                    ? formulario.ShowDialog()
                    : formulario.ShowDialog(owner);

            return resultado == DialogResult.OK
                ? formulario.Valor
                : null;
        }
        #endregion
    }
}
