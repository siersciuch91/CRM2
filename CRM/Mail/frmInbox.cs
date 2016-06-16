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
        IEnumerable<ActiveUp.Net.Mail.Message> mailList;
        public frmInbox()
        {
            InitializeComponent();
        }

        private void Inbox_Load(object sender, EventArgs e)
        {
            List<cMail> mailList = cMail.getInboxMailDB();


            
            //mailList = inbox.GetUnreadMails("inbox");
            lvInbox.View = View.Details;
            lvInbox.Columns.Add("Od", 100, HorizontalAlignment.Left);
            lvInbox.Columns.Add("Tytuł", 300, HorizontalAlignment.Left);
            lvInbox.Columns.Add("Data", 200, HorizontalAlignment.Right);
            lvInbox.FullRowSelect = true;

            foreach(cMail m in mailList)
            {
                ListViewItem lvItem = new ListViewItem(m.address);
                lvItem.SubItems.Add(m.tittle);
                DateTime receiveDate = m.date;
                if (receiveDate.Date == DateTime.Now.Date)
                    lvItem.SubItems.Add((receiveDate.TimeOfDay.Hours + 2) + ":" + receiveDate.TimeOfDay.Minutes);
                else if (receiveDate.Date.Year == DateTime.Now.Date.Year)
                    lvItem.SubItems.Add(receiveDate.Date.ToString("dd") + "-" + receiveDate.Date.ToString("MM"));
                else
                    lvItem.SubItems.Add(receiveDate.ToString("dd") + "-" + receiveDate.Date.ToString("MM") + "-" + receiveDate.Date.ToString("yyyy"));

                lvItem.Tag = m;

                lvInbox.Items.Add(lvItem);
            }

            /*
            foreach (ActiveUp.Net.Mail.Message mail in mailList)
            {
                ListViewItem lvItem = new ListViewItem(mail.From.ToString());
                lvItem.SubItems.Add(mail.Subject.ToString());
                DateTime receiveDate = mail.ReceivedDate;
                if (receiveDate.Date == DateTime.Now.Date)
                    lvItem.SubItems.Add((receiveDate.TimeOfDay.Hours + 2) + ":" + receiveDate.TimeOfDay.Minutes);
                else if (receiveDate.Date.Year == DateTime.Now.Date.Year)
                    lvItem.SubItems.Add(receiveDate.Date.ToString("dd") + "-" + receiveDate.Date.ToString("MM"));
                else
                    lvItem.SubItems.Add(receiveDate.ToString("dd") + "-" + receiveDate.Date.ToString("MM") + "-" + receiveDate.Date.ToString("yyyy"));

                lvInbox.Items.Add(lvItem);

            }*/

        }

        private void lvInbox_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem lvItem  = sender as ListViewItem;
            
            //IEnumerator<ActiveUp.Net.Mail.Message> mailEnumerator = mailList.GetEnumerator();
            frmMessage frmTemp = new frmMessage();
            frmTemp.mail = (cMail)lvInbox.SelectedItems[0].Tag;
            frmTemp.ShowDialog();
                // mailEnumerator.MoveNext();
        }
    }
}
