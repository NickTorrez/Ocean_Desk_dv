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
        private FrmLogin login;
        public FrmMainMenu(FrmLogin login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            login.LimpiarCampos();

            this.Hide();

            login.Show();
        }
    }
}
