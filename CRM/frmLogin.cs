﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
