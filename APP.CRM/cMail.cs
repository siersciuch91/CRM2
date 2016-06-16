using ActiveUp.Net.Mail;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace APP.CRM
{
    public class cMail
    {
        enum mailType{inbox = 0,sendbox = 1};

        public int id;
        public int type;
        public string address;
        public string name;
        public string tittle;
        public string text;
        public DateTime date;
        public int userId;

        public cMail(int vtype, string vAddress, string vName, string vTittle, DateTime vDate, int vUserId)
        {
            type = vtype;
            address = vAddress;
            name = vName;
            tittle = vTittle;
            date = vDate;
            userId = vUserId;
        }

        public cMail()
        {
        }

        void insertMail()
        {
            try
            {
                ADODB.Recordset rdMail = new ADODB.Recordset();
                string sql = "select id, type, name, mail, tittle, messageText, messageDate, userid from mailbox";
                object nilTempConv = Type.Missing;
                rdMail.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, (Int32)ADODB.CommandTypeEnum.adCmdText);
                rdMail.AddNew(nilTempConv, nilTempConv);

                rdMail.Fields["TYPE"].Value = type;
                rdMail.Fields["NAME"].Value = name;
                rdMail.Fields["MAIL"].Value = address;
                rdMail.Fields["TITTLE"].Value = tittle;
                rdMail.Fields["MESSAGEDATE"].Value = date;
                rdMail.Fields["MESSAGETEXT"].Value = text;
                rdMail.Fields["USERID"].Value = cSession.userId;

                rdMail.Update();

                id = rdMail.Fields["ID"].Value;

                rdMail.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int getNewMail()
        {
            int countMail = 0;
            IEnumerable<ActiveUp.Net.Mail.Message> mailList;
            mailList = cSession.inbox.GetUnreadMails("inbox");


            foreach (ActiveUp.Net.Mail.Message mail in mailList)
            {
                countMail++;

                cMail tempMail = new cMail();//(0, mail.From.Email,mail.From.Name, mail.Subject, mail.ReceivedDate, 1);
                tempMail.type = (int)mailType.inbox;
                tempMail.address = mail.From.Email;
                tempMail.name = mail.From.Name;
                tempMail.tittle = mail.Subject;
                tempMail.userId = cSession.userId;
                tempMail.date = mail.ReceivedDate;
                tempMail.text = mail.BodyText.Text;
                tempMail.insertMail();

                foreach (MimePart a in mail.Attachments)
                {
                    cAttachments att = new cAttachments();
                    att.messageId = tempMail.id;
                    att.data = a.BinaryContent;
                    att.name = a.ContentName;
                    att.insertAttachment();
                }
            }

            return countMail;
        }

        public static List<cMail> getInboxMailDB()
        {
            List<cMail> listMail = new List<cMail>();

            try
            {
                ADODB.Recordset rdMail = new ADODB.Recordset();
                string sql = "select id, type, name, mail, tittle, messageText, messageDate from mailbox where type = 0 and userid =" + cSession.userId;
                rdMail.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, (Int32)ADODB.CommandTypeEnum.adCmdText);

                while(!rdMail.EOF)
                {
                    cMail tempMail = new cMail();

                    tempMail.id = rdMail.Fields["ID"].Value;
                    tempMail.type = rdMail.Fields["TYPE"].Value;
                    tempMail.name = rdMail.Fields["NAME"].Value;
                    tempMail.address = rdMail.Fields["MAIL"].Value;
                    tempMail.tittle = rdMail.Fields["TITTLE"].Value;
                    tempMail.date = rdMail.Fields["MESSAGEDATE"].Value;
                    tempMail.text = rdMail.Fields["MESSAGETEXT"].Value;

                    listMail.Add(tempMail);
                    rdMail.MoveNext();
                }
                rdMail.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return listMail;
        }
    }
}
