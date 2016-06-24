using System.Net.Mail;
using System.Net;
using System.Collections.Generic;

namespace APP.CRM.Mail
{
    public class cSendMail
    {
        private string mailAddress;
        private string mailTittle;
        private string mailText;
        List<Attachment> attachments = new List<Attachment>();

        public void setMailAddress(string value)
        {
            this.mailAddress = value;
        }

        public void setMailTittle(string value)
        {
            this.mailTittle = value;
        }

        public void setMailText(string value)
        {
            this.mailText = value;
        }

        public void setAttachments(List<Attachment> value)
        {
            this.attachments = value;
        }
        /// <summary>
        /// Metoda wysylajaca wiadomosc
        /// </summary>
        public bool sendMail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(cSession.login);
                mail.To.Add(mailAddress);
                mail.Subject = mailTittle;
                mail.Body = mailText;

                foreach(Attachment a in attachments)
                    mail.Attachments.Add(a);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(cSession.login, cSession.passwordUser);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
