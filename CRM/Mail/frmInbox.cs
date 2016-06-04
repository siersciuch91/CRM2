using APP.CRM.Mail;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ActiveUp.Net.Mail;

namespace CRM.Mail
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
            cMailBox inbox = new cMailBox("imap.gmail.com",
                            993,
                            true,
                            "adrian.kasia.pk2106@gmail.com", "Politechnika*2016");
            //List<cMail> mailList = inbox.getMail();

            mailList = inbox.GetUnreadMails("inbox");
            lvInbox.View = View.Details;
            lvInbox.Columns.Add("Od", 100, HorizontalAlignment.Left);
            lvInbox.Columns.Add("Tytuł", 300, HorizontalAlignment.Left);
            lvInbox.Columns.Add("Data", 200, HorizontalAlignment.Right);
            lvInbox.FullRowSelect = true;

            

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

            }

        }

        private void lvInbox_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem lvItem = lvInbox.SelectedItems[0];
            //IEnumerator<ActiveUp.Net.Mail.Message> mailEnumerator = mailList.GetEnumerator();
            frmMessage frmTemp = new frmMessage();

                // mailEnumerator.MoveNext();
        }
    }
}
