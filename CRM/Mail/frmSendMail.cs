using APP.CRM.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM.GUI.Mail
{
    public partial class frmSendMail : Form
    {
        public frmSendMail()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            cSendMail sendMail = new cSendMail();
            sendMail.setMailAddress(txtAddress.Text);
            sendMail.setMailTittle(txtTittle.Text);
            sendMail.sendMail();
        }

        private void frmSendMail_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }
    }
}
