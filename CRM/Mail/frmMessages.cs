using APP.CRM;
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
    public partial class frmMessages : Form
    {
        public int clientId =0;
        public int companyId = 0;
        System.Drawing.Font normalFont;
        System.Drawing.Font boldFont;

        public frmMessages()
        {
            InitializeComponent();
        }

        private void frmMessages_Load(object sender, EventArgs e)
        {
            string strWhere;
            if (clientId != 0)
                strWhere = " clientId = " + clientId;
            else if (companyId != 0)
                strWhere = " clientId in (select id from client where active = 1 and id_company = " + companyId + ")";
            else
            {
                MessageBox.Show("Wystąpił błąd", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<cMail> listMail = cMail.getConversation(strWhere);

            if (listMail == null)
            {
                MessageBox.Show("Błąd podczas pobierania maili z bazy danych. Skontaktuj się z administratorem", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            normalFont = lvInbox.Font;
            boldFont = new System.Drawing.Font(lvInbox.Font, System.Drawing.FontStyle.Bold);

            lvInbox.View = View.Details;
            lvInbox.Columns.Add("Od", 300, HorizontalAlignment.Left);
            lvInbox.Columns.Add("Do", 300, HorizontalAlignment.Left);
            lvInbox.Columns.Add("Tytuł", 700, HorizontalAlignment.Left);
            lvInbox.Columns.Add("Data", 200, HorizontalAlignment.Right);
            lvInbox.FullRowSelect = true;

            foreach (cMail m in listMail)
            {
                string mailTo = "", mailFrom = "";

                if (m.type == 0)//otrzymany
                {
                    mailTo = m.userAddress;
                    mailFrom = m.address;
                }  
                else
                {
                    mailTo = m.address;
                    mailFrom = m.userAddress;
                }

                ListViewItem lvItem = new ListViewItem(mailFrom);
                lvItem.SubItems.Add(mailTo);
                lvItem.SubItems.Add(m.tittle);
                DateTime receiveDate = m.date.ToLocalTime();
                if (receiveDate.Date == DateTime.Now.Date)
                    lvItem.SubItems.Add((receiveDate.TimeOfDay.Hours) + ":" + receiveDate.TimeOfDay.Minutes.ToString("00"));
                else if (receiveDate.Date.Year == DateTime.Now.Date.Year)
                    lvItem.SubItems.Add(receiveDate.Date.ToString("dd") + "-" + receiveDate.Date.ToString("MM"));
                else
                    lvItem.SubItems.Add(receiveDate.ToString("dd") + "-" + receiveDate.Date.ToString("MM") + "-" + receiveDate.Date.ToString("yyyy"));

                if (!m.read)
                    lvItem.Font = boldFont;

                lvItem.Tag = m;

                lvInbox.Items.Add(lvItem);
            }
        }

        private void lvInbox_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem lvItem = sender as ListViewItem;
            cMail tempMail = lvInbox.SelectedItems[0].Tag as cMail;

            if (!tempMail.markAsRead())
            {
                MessageBox.Show("Błąd podczas zmiany statusu wiadmości", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            lvInbox.SelectedItems[0].Font = normalFont;
            frmMessage frmTemp = new frmMessage();
            frmTemp.mail = tempMail;
            frmTemp.ShowDialog();
        }
    }
}
