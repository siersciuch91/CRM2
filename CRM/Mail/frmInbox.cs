using APP.CRM.Mail;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ActiveUp.Net.Mail;
using APP.CRM;

namespace CRM.GUI.Mail
{
    public partial class frmInbox : Form
    {
        System.Drawing.Font normalFont;
        System.Drawing.Font boldFont;

        public frmInbox()
        {
            InitializeComponent();
        }

        private void Inbox_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
            List<cMail> mailList = cMail.getInboxMailDB();

            if (mailList == null)
            {
                MessageBox.Show("Błąd podczas pobierania maili z bazy danych. Skontaktuj się z administratorem", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            normalFont = lvInbox.Font;
            boldFont = new System.Drawing.Font(lvInbox.Font, System.Drawing.FontStyle.Bold);

            lvInbox.View = View.Details;
            lvInbox.Columns.Add("Od", 300, HorizontalAlignment.Left);
            lvInbox.Columns.Add("Tytuł", 700, HorizontalAlignment.Left);
            lvInbox.Columns.Add("Data", 200, HorizontalAlignment.Right);
            lvInbox.FullRowSelect = true;

            foreach(cMail m in mailList)
            {
                string add = m.address;
                if (m.name.Trim().Length > 0)
                    add = m.name + "(" + add + ")";
 
                ListViewItem lvItem = new ListViewItem(add);
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

        public void insertNewMailList(List<cMail> listNewMail)
        {
            listNewMail.Reverse();
            foreach (cMail m in listNewMail)
            {
                string add = m.address;
                if (m.name.Trim().Length > 0)
                    add = m.name + "(" + add + ")";

                ListViewItem lvItem = new ListViewItem(add);
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
                //do odwolan z innego watku
                this.Invoke((MethodInvoker)delegate{lvInbox.Items.Insert(0, lvItem);});
            }
        }
        private void lvInbox_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem lvItem  = sender as ListViewItem;
            cMail tempMail = lvInbox.SelectedItems[0].Tag as cMail;
            if(!tempMail.markAsRead())
            {
                MessageBox.Show("Błąd podczas zmiany statusu wiadmości", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            lvInbox.SelectedItems[0].Font = normalFont;
            frmMessage frmTemp = new frmMessage();
            frmTemp.mail = tempMail;
            frmTemp.ShowDialog();
        }

        public void deleteMessage()
        {
            ListViewItem lvItem = lvInbox.SelectedItems[0];
            cMail tempMail = lvItem.Tag as cMail;
            if(!tempMail.deleteMail())
            {
                MessageBox.Show("Nie udało się usunąć wiadomości", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            lvInbox.Items.Remove(lvItem);
        }
    }
}
