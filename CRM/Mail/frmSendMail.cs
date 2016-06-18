using APP.CRM;
using APP.CRM.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
        public cMail mail;
        private void btnSend_Click(object sender, EventArgs e)
        {
            cSendMail sendMail = new cSendMail();
            sendMail.setMailAddress(txtAddress.Text);
            sendMail.setMailTittle(txtTittle.Text);
            sendMail.setMailText(txtMessage.Text);
            sendMail.sendMail();

            mail = new cMail();
            mail.address = txtAddress.Text;
            mail.type = 1;
            mail.tittle = txtTittle.Text;
            mail.text = txtMessage.Text;
            mail.read = true;
            mail.date = DateTime.Now;
            mail.insertMail();

            this.Hide();
        }

        private void frmSendMail_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void btnZalacz_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cAttachments tempAtt = new cAttachments();
                tempAtt.name = System.IO.Path.GetFileName(openFileDialog1.FileName);
                tempAtt.data = File.ReadAllBytes(openFileDialog1.FileName);
                ListViewItem lvItem = new ListViewItem(tempAtt.name);
                lvItem.Tag = tempAtt;
                lvAttachments.Items.Add(lvItem);
            }
        }

        private void lvAttachments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ListViewItem lvItem = lvAttachments.SelectedItems[0];
                lvAttachments.Items.Remove(lvItem);
            }
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Ewidencja.frmCompany frmTemp = new Ewidencja.frmCompany();
            frmTemp.trybReturns = true;
            frmTemp.ShowDialog();
            if (frmTemp.returnsMail.Trim().Length > 0)
                txtAddress.Text = frmTemp.returnsMail.Trim();
            frmTemp.Close();
        }
    }
}
