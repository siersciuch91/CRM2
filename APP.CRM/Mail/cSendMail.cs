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

        public bool sendMail()
        {
            MailMessage mail = new MailMessage();
            

            mail.From = new System.Net.Mail.MailAddress("adrian.kasia.pk2106@gmail.com");

            // The important part -- configuring the SMTP client
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Port = 587;   // [1] You can try with 465 also, I always used 587 and got success
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // [2] Added this
            smtp.UseDefaultCredentials = false; // [3] Changed this
            smtp.Credentials = new NetworkCredential("adrian.kasia.pk2106@gmail.com", "Politechnika*2016");  // [4] Added this. Note, first parameter is NOT string.
            smtp.Host = "smtp.gmail.com";

            //recipient address
            mail.To.Add(new MailAddress(mailAddress));
            //mail.Attachments.Add()
            //Formatted mail body
            mail.IsBodyHtml = true;
            mail.Subject = mailTittle;

            mail.Body = mailText;
            smtp.Send(mail);

            return true;
        }
    }
}
