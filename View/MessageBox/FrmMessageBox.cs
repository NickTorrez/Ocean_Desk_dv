using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv.UI.MessageBox
{
    public partial class FrmMessageBox : Form
    {
        private const int AlturaMinima = 230;

        #region Propiedades
        private MessageType _messageType;

        private DialogResult _result;

        public DialogResult Result
        {
            get => _result;
        }
        #endregion

        #region Constructor Reutilizable
        public FrmMessageBox(string title, string message, MessageType type)
        {
            InitializeComponent();

            lblTitle.Text = title;
            lblMessage.Text = message;
            _messageType = type;

            ConfigurarTipo(type);
            ConfigurarBotones(type);

        }
        #endregion  

        #region Metodo del Constructor
        private void ConfigurarTipo(MessageType type)
        {
            switch (type)
            {
                case MessageType.Information:

                    picIcon.Image =
                        Properties.Resources.info;

                    pnlHeader.BackColor =
                        Color.FromArgb(8, 126, 164);

                    break;

                case MessageType.Warning:

                    picIcon.Image =
                        Properties.Resources.warning;

                    pnlHeader.BackColor =
                        Color.FromArgb(218, 154, 24);

                    break;

                case MessageType.Error:

                    picIcon.Image =
                        Properties.Resources.error;

                    pnlHeader.BackColor =
                        Color.FromArgb(190, 66, 66);

                    break;

                case MessageType.Confirmation:

                    picIcon.Image =
                        Properties.Resources.confirm;

                    pnlHeader.BackColor =
                        Color.FromArgb(8, 31, 63);

                    break;
            }
        }

        private void ConfigurarBotones(MessageType type)
        {
            switch (type)
            {
                case MessageType.Information:
                case MessageType.Warning:
                case MessageType.Error:

                    btnAccept.Visible = true;
                    btnCancel.Visible = false;

                    btnAccept.Text = "ACEPTAR";

                    break;

                case MessageType.Confirmation:

                    btnAccept.Visible = true;
                    btnCancel.Visible = true;

                    btnAccept.Text = "CONFIRMAR";
                    btnCancel.Text = "CANCELAR";

                    break;
            }
        }
        public static DialogResult Show(string message, string title, MessageType type)
        {
            using (FrmMessageBox form = new FrmMessageBox(title, message, type))
            {
                return form.ShowDialog();
            }
        }

        private void AjustarTamanoAlMensaje()
        {
            const int anchoFormulario = 460;
            const int anchoTexto = 400;

            Size textoMedido = TextRenderer.MeasureText(
                lblMessage.Text,
                lblMessage.Font,
                new Size(anchoTexto, 0),
                TextFormatFlags.WordBreak |
                TextFormatFlags.TextBoxControl);

            int altoTexto = Math.Max(
                textoMedido.Height,
                lblMessage.Font.Height + 4);

            Rectangle areaTrabajo =
                Screen.FromControl(this).WorkingArea;

            int alturaMaxima = Math.Max(
                AlturaMinima,
                areaTrabajo.Height - 80);

            int alturaBase =
                pnlHeader.Height +
                pnlFooter.Height +
                pnlBody.Padding.Vertical;

            int alturaDeseada = alturaBase + altoTexto;

            bool necesitaDesplazamiento =
                alturaDeseada > alturaMaxima;

            int alturaFinal =
                Math.Min(alturaDeseada, alturaMaxima);

            pnlBody.AutoSize = false;

            ClientSize = new Size(
                anchoFormulario,
                alturaFinal);

            pnlBody.AutoScroll = necesitaDesplazamiento;

            PerformLayout();

            int anchoDisponible =
                pnlBody.ClientSize.Width -
                pnlBody.Padding.Horizontal;

            if (necesitaDesplazamiento)
            {
                anchoDisponible -=
                    SystemInformation.VerticalScrollBarWidth;
            }

            anchoDisponible = Math.Max(100, anchoDisponible);

            // Permite que el mensaje use la altura calculada.
            lblMessage.Dock = DockStyle.None;
            lblMessage.AutoSize = false;
            lblMessage.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            lblMessage.Location = new Point(
                pnlBody.Padding.Left,
                pnlBody.Padding.Top);

            lblMessage.Size = new Size(
                anchoDisponible,
                altoTexto);

            lblMessage.TextAlign = ContentAlignment.TopLeft;

            // En mensajes muy largos, el área central se desplaza.
            // Los botones permanecen visibles en el pie del diálogo.
            pnlBody.AutoScrollMinSize = necesitaDesplazamiento
                ? new Size(
                    0,
                    altoTexto + pnlBody.Padding.Vertical)
                : Size.Empty;
        }
        #endregion

        #region Eventos de Buttons Aceptar y Cancelar
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (_messageType == MessageType.Confirmation)
            {
                DialogResult = DialogResult.Yes;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_messageType == MessageType.Confirmation)
            {
                DialogResult = DialogResult.No;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }

            Close();
        }

        private void FrmMessageBox_Shown(object sender, EventArgs e)
        {
            PerformLayout();

            AjustarTamanoAlMensaje();

            PerformLayout();
        }
        #endregion
    }
}
