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
            txtMailAddress.Text = mail.address;
            txtTittle.Text = mail.tittle;
            txtMessText.Text = mail.text;

            cAttachments.getListWithoutBin(mail.id, listView1);
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
                    tempAtt.getBinnary();

                FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                fs.Write(tempAtt.data, 0, tempAtt.data.Length);
                fs.Close();
            }
            System.Diagnostics.Process.Start(filePath);
        }
    }
}
