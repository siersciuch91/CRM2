using System;
using System.Windows.Forms;
using APP.CRM;

namespace CRM.GUI
{
    public partial class frmLogin : Form
    {
        public bool loginState = false;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cUser.checkUserLogin(txtLogin.Text, txtPass.Text))
            {
                cSession.login = txtLogin.Text;
                cSession.passwordUser = txtPass.Text;
                loginState = true;
                this.Hide();
            }
            else
                if (MessageBox.Show("Błędne dane logowania, spróbuj ponownie.", "CRM", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                    this.Close();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(null, null);
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(null, null);
        }
    }
}
