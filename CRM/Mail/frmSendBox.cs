using APP.CRM.Mail;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ActiveUp.Net.Mail;
using APP.CRM;

namespace CRM.GUI.Mail
{
    public partial class frmSendBox : Form
    {
        System.Drawing.Font normalFont;
        System.Drawing.Font boldFont;

        //IEnumerable<ActiveUp.Net.Mail.Message> mailList;
        public frmSendBox()
        {
            InitializeComponent();
        }

        private void Inbox_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
            List<cMail> mailList = cMail.getSendboxMailDB();

            normalFont = lvInbox.Font;
            boldFont = new System.Drawing.Font(lvInbox.Font, System.Drawing.FontStyle.Bold);

            //mailList = inbox.GetUnreadMails("inbox");
            lvInbox.View = View.Details;
            lvInbox.Columns.Add("Do", 300, HorizontalAlignment.Left);
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
                DateTime receiveDate = m.date;
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

        public void insertNewMail(cMail newMail)
        {
                string add = newMail.address;
                if (newMail.name.Trim().Length > 0)
                    add = newMail.name + "(" + add + ")";

                ListViewItem lvItem = new ListViewItem(add);
                lvItem.SubItems.Add(newMail.tittle);
                DateTime receiveDate = newMail.date;
                if (receiveDate.Date == DateTime.Now.Date)
                    lvItem.SubItems.Add((receiveDate.TimeOfDay.Hours) + ":" + receiveDate.TimeOfDay.Minutes.ToString("00"));
                else if (receiveDate.Date.Year == DateTime.Now.Date.Year)
                    lvItem.SubItems.Add(receiveDate.Date.ToString("dd") + "-" + receiveDate.Date.ToString("MM"));
                else
                    lvItem.SubItems.Add(receiveDate.ToString("dd") + "-" + receiveDate.Date.ToString("MM") + "-" + receiveDate.Date.ToString("yyyy"));

                lvItem.Tag = newMail;
                //do odwolan z innego watku
                this.Invoke((MethodInvoker)delegate{lvInbox.Items.Insert(0, lvItem);});
        }
        private void lvInbox_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem lvItem  = sender as ListViewItem;
            cMail tempMail = lvInbox.SelectedItems[0].Tag as cMail;
            frmMessage frmTemp = new frmMessage();
            frmTemp.mail = tempMail;
            frmTemp.ShowDialog();
        }

        public void deleteMessage()
        {
            ListViewItem lvItem = lvInbox.SelectedItems[0];
            cMail tempMail = lvItem.Tag as cMail;
            tempMail.deleteMail();
            lvInbox.Items.Remove(lvItem);
        }
    }
}
