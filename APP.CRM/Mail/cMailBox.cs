using ActiveUp.Net.Mail;
using System.Collections.Generic;
using System.Linq;
//use API http://mailsystem.codeplex.com/
namespace APP.CRM.Mail
{
    public class cMailBox
    {
        private Imap4Client client;

        public cMailBox(string mailServer, int port, bool ssl, string login, string password)
        {
            if (ssl)
                Client.ConnectSsl(mailServer, port);
            else
                Client.Connect(mailServer, port);
            Client.Login(login, password);
        }

        public IEnumerable<Message> GetAllMails(string mailBox)
        {
            return GetMails(mailBox, "ALL").Cast<Message>().OrderByDescending(c => c.ReceivedDate);
        }

        public IEnumerable<Message> GetUnreadMails(string mailBox)
        {
            return GetMails(mailBox, "UNSEEN").Cast<Message>().OrderByDescending(c => c.ReceivedDate);
        }

        protected Imap4Client Client
        {
            get { return client ?? (client = new Imap4Client()); }
        }

        private MessageCollection GetMails(string mailBox, string searchPhrase)
        {
            Mailbox mails = Client.SelectMailbox(mailBox);
            MessageCollection messages = mails.SearchParse(searchPhrase);
            return messages;
        }

        public void getAndSaveMail()
        {

        }
    }
}
