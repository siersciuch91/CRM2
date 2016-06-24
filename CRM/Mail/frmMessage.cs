using APP.CRM;
using System.IO;
using System.Windows.Forms;

namespace CRM.GUI.Mail
{
    public partial class frmMessage : Form
    {
        public cMail mail;
        public frmMessage()
        {
            InitializeComponent();
        }

        private void frmMessage_Load(object sender, System.EventArgs e)
        {
            if (mail.type == 0)
            {
                txtMailAddressFrom.Text = mail.address;
                txtMailAddressTo.Text = mail.userAddress;
            }
            else
            {
                txtMailAddressTo.Text = mail.address;
                txtMailAddressFrom.Text = mail.userAddress;
            }
            txtTittle.Text = mail.tittle;
            txtMessText.Text = mail.text;

            if (mail.clientId != 0)
                btnAddClient.Visible = false;

            if (!cAttachments.getListWithoutBin(mail.id, listView1))
            {
                MessageBox.Show("Nie udało się załadować załączników wiadomości. Skontaktuj się z administratorem", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void listView1_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.listView1.Items.Count == 0)
                return;

            if (this.listView1.SelectedItems == null)
                return;

            if (this.listView1.SelectedItems.Count == 0)
                return;

            cAttachments tempAtt = listView1.SelectedItems[0].Tag as cAttachments;


            string messageDirectory = cSession.tempPath + "\\" + mail.id;
            if (!Directory.Exists(messageDirectory))
                Directory.CreateDirectory(messageDirectory);

            string filePath = messageDirectory + "\\" + tempAtt.name;
            if (!File.Exists(filePath))
            {
                if (tempAtt.data == null)
                    if(!tempAtt.getBinnary())
                    {
                        MessageBox.Show("Nie udało się załadować załącznika. Skontaktuj się z administratorem", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                fs.Write(tempAtt.data, 0, tempAtt.data.Length);
                fs.Close();
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void btnAddClient_Click(object sender, System.EventArgs e)
        {
            Ewidencja.frmClient frmTemp = new Ewidencja.frmClient();
            frmTemp.prepareNew();
            frmTemp.setEmail(mail.address);
            frmTemp.trybReturns = true;
            frmTemp.ShowDialog();
            if (frmTemp.returnId > 0)
            {
                mail.clientId = frmTemp.returnId;
                btnAddClient.Visible = false;
                if (!mail.updateClientMail())
                {
                    MessageBox.Show("Nie udało się zaktualizawać wiadomościm, wybierz jeszcze raz klienta.", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            frmTemp.Close();

        }
    }
}
