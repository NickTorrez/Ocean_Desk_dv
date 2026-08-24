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
        #endregion
    }
}
