namespace Ocean_Desk_dv
{
    public partial class FrmLogin : Form
    {
        private bool passwordVisible = false;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;

            txtPassword.UseSystemPasswordChar = !passwordVisible;


            if (passwordVisible)
            {
                btnShowPassword.Text = "🔒";
            }
            else
            {
                btnShowPassword.Text = "👁";
            }
        }

        private void lblCopyright_Click(object sender, EventArgs e)
        {

        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
