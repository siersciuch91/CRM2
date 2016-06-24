using APP.CRM;
using System;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
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
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(cSession.login);
            mail.To.Add(txtAddress.Text);
            mail.Subject = txtTittle.Text;
            mail.Body = txtMessage.Text;


            foreach (ListViewItem i in lvAttachments.Items)
            {
                cAttachments att = i.Tag as cAttachments;
                Attachment data = new Attachment(i.SubItems[1].Text, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(i.SubItems[1].Text);
                
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(i.SubItems[1].Text);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(i.SubItems[1].Text);
                mail.Attachments.Add(data);
            }

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(cSession.login, cSession.passwordUser);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);

            cMail mailDB = new cMail();
            mailDB.address = txtAddress.Text;
            mailDB.type = 1;
            mailDB.tittle = txtTittle.Text;
            mailDB.text = txtMessage.Text;
            mailDB.read = true;
            mailDB.date = DateTime.Now.ToUniversalTime();
            if (!mailDB.insertMail())
            {
                MessageBox.Show("Nie udało się dodać wiadomości. Skontaktuj się z administratorem", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (ListViewItem i in lvAttachments.Items)
            {
                cAttachments attTemp = i.Tag as cAttachments;
                attTemp.messageId = mailDB.id;
                if (!attTemp.insertAttachment())
                {
                    MessageBox.Show("Nie udało się dodać załączników wiadomości. Skontaktuj się z administratorem", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
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
                lvItem.SubItems.Add(openFileDialog1.FileName);
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
            Ewidencja.frmClient frmTemp = new Ewidencja.frmClient();
            frmTemp.trybReturns = true;
            frmTemp.ShowDialog();

            if (frmTemp.returnsMail.Trim().Length > 0)
                txtAddress.Text = frmTemp.returnsMail.Trim();

            frmTemp.Close();
        }

        private void btnFirm_Click(object sender, EventArgs e)
        {
            Ewidencja.frmCompany frmTemp = new Ewidencja.frmCompany();
            frmTemp.trybReturns = 2;
            frmTemp.ShowDialog();
            if (frmTemp.returnsMail.Trim().Length > 0)
                txtAddress.Text = frmTemp.returnsMail.Trim();
            frmTemp.Close();
        }
    }
}
