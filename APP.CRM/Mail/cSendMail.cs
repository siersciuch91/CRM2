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

                mail.From = new System.Net.Mail.MailAddress(cSession.login);
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(cSession.login, cSession.passwordUser);
                smtp.Host = "smtp.gmail.com";
                mail.To.Add(new MailAddress(mailAddress));
                mail.IsBodyHtml = true;
                mail.Subject = mailTittle;
                mail.Body = mailText;
                smtp.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
