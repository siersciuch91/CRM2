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
        public string userAddress = "";
        public string name = "";
        public string tittle;
        public string text;
        public DateTime date;
        public int userId;
        public bool read;
        public int clientId = 0;

        /// <summary>
        /// Usuniecie maila z bazy danych
        /// </summary>
        /// <returns>true - powodzenie/false-niepowodzenie</returns>
        public bool deleteMail()
        {
            try
            {
                object tempObj;
                cConnection.conn.Execute("Delete from mailbox where id = " + id, out tempObj);

                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Aktualizacja klienta w mailach
        /// </summary>
        /// <returns>true - powodzenie/false-niepowodzenie</returns>
        public bool updateClientMail()
        {
            try
            {
                object tempObj;
                cConnection.conn.Execute("update mailbox set clientId = " + clientId + "where mail = '" + address + "'", out tempObj);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Dodanie nowego maila pobranego z serwera do BD
        /// </summary>
        /// <returns>true - powodzenie/false-niepowodzenie</returns>
        public bool insertMail()
        {
            try
            {
                ADODB.Recordset rdMail = new ADODB.Recordset();
                string sql = "select id, ISNULL(NAME, '') + ' ' + ISNULL(SECONDNAME, '') from client where mail = '" + address + "'";

                rdMail.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, (Int32)ADODB.CommandTypeEnum.adCmdText);
                if (!rdMail.EOF)
                {
                    clientId = rdMail.Fields[0].Value;
                    name = rdMail.Fields[1].Value;
                }
                rdMail.Close();

                sql = "select id, type, name, mail, tittle, messageText, messageDate, userid, readMail, clientid from mailbox";
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
                rdMail.Fields["READMAIL"].Value = read;

                if (clientId > 0)
                    rdMail.Fields["CLIENTID"].Value = clientId;

                rdMail.Update();
                rdMail.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Pobranie nowych maila z serwera
        /// </summary>
        /// <param name="cMailList">zwraca liste nowych maili</param>
        /// <returns>liczba maili/null w przypadku niepowodzenia</returns>
        public static int getNewMail(ref List<cMail> cMailList)
        {
            try
            {
                if (cSession.inbox == null)
                {
                    MessageBox.Show("Nie nawiązano jeszcze połączenia, proszę spróbować za chwilę.", "Brak połączenia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }

                int countMail = 0;
                IEnumerable<ActiveUp.Net.Mail.Message> mailList;
                mailList = cSession.inbox.GetUnreadMails("inbox");
                cMailList = new List<cMail>();

                foreach (ActiveUp.Net.Mail.Message mail in mailList)
                {
                    countMail++;

                    cMail tempMail = new cMail();
                    tempMail.type = (int)mailType.inbox;
                    tempMail.address = mail.From.Email;
                    tempMail.name = mail.From.Name;
                    tempMail.tittle = mail.Subject;
                    tempMail.userId = cSession.userId;
                    tempMail.date = mail.ReceivedDate;
                    tempMail.text = mail.BodyText.Text;
                    tempMail.read = false;
                    if (!tempMail.insertMail())
                    {
                        MessageBox.Show("Nie udało się dodać wiadomości. Skontaktuj się z administratorem", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return 0;
                    }

                    foreach (MimePart a in mail.Attachments)
                    {
                        cAttachments att = new cAttachments();

                        att.messageId = tempMail.id;
                        att.data = a.BinaryContent;
                        att.name = a.ContentName;
                        if (!att.insertAttachment())
                        {
                            MessageBox.Show("Nie udało się dodać załączników wiadomości. Skontaktuj się z administratorem", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return 0;
                        }
                    }
                    cMailList.Add(tempMail);
                }
                return countMail;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// Pobiera maila odebrane do zalogowanego z=uzytkownika
        /// </summary>
        /// <returns>Lista maili</returns>
        public static List<cMail> getInboxMailDB()
        {
            List<cMail> listMail = new List<cMail>();

            try
            {
                ADODB.Recordset rdMail = new ADODB.Recordset();
                string sql = "select m.id, m.type, m.name, m.mail, m.tittle, m.messageText, m.messageDate, m.readMail, ISNULL(m.clientId,0) clientId, u.login mail2 from mailbox m join users u on m.userid = u.id where m.type = 0 and m.userid =" + cSession.userId + "order by m.MESSAGEDATE desc";
                rdMail.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, (Int32)ADODB.CommandTypeEnum.adCmdText);

                while(!rdMail.EOF)
                {
                    cMail tempMail = new cMail();

                    tempMail.id = rdMail.Fields["ID"].Value;
                    tempMail.type = rdMail.Fields["TYPE"].Value;
                    tempMail.name = rdMail.Fields["NAME"].Value;
                    tempMail.address = rdMail.Fields["MAIL"].Value;
                    tempMail.userAddress = rdMail.Fields["MAIL2"].Value;
                    tempMail.tittle = rdMail.Fields["TITTLE"].Value;
                    tempMail.date = rdMail.Fields["MESSAGEDATE"].Value;
                    tempMail.text = rdMail.Fields["MESSAGETEXT"].Value;
                    tempMail.read = rdMail.Fields["READMAIL"].Value;
                    tempMail.userId = cSession.userId;

                    if (rdMail.Fields["CLIENTID"].Value != 0)
                        tempMail.clientId = rdMail.Fields["CLIENTID"].Value;

                    listMail.Add(tempMail);
                    rdMail.MoveNext();
                }
                rdMail.Close();
                return listMail;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Pobiera maila wyslane do zalogowanego z=uzytkownika
        /// </summary>
        /// <returns>Lista maili</returns>
        public static List<cMail> getSendboxMailDB()
        {
            List<cMail> listMail = new List<cMail>();

            try
            {
                ADODB.Recordset rdMail = new ADODB.Recordset();
                string sql = "select m.id, m.type, m.name, m.mail, m.tittle, m.messageText, m.messageDate, m.readMail, ISNULL(m.clientId,0) clientId, u.login mail2 from mailbox m join users u on m.userid = u.id where m.type = 1 and m.userid =" + cSession.userId + "order by m.MESSAGEDATE desc";
                rdMail.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, (Int32)ADODB.CommandTypeEnum.adCmdText);

                while (!rdMail.EOF)
                {
                    cMail tempMail = new cMail();

                    tempMail.id = rdMail.Fields["ID"].Value;
                    tempMail.type = rdMail.Fields["TYPE"].Value;
                    tempMail.name = rdMail.Fields["NAME"].Value;
                    tempMail.address = rdMail.Fields["MAIL"].Value;
                    tempMail.userAddress = rdMail.Fields["MAIL2"].Value;
                    tempMail.tittle = rdMail.Fields["TITTLE"].Value;
                    tempMail.date = rdMail.Fields["MESSAGEDATE"].Value;
                    tempMail.text = rdMail.Fields["MESSAGETEXT"].Value;
                    tempMail.read = rdMail.Fields["READMAIL"].Value;
                    tempMail.userId = cSession.userId;

                    if (rdMail.Fields["CLIENTID"].Value != 0)
                        tempMail.clientId = rdMail.Fields["CLIENTID"].Value;

                    listMail.Add(tempMail);
                    rdMail.MoveNext();
                }
                rdMail.Close();
                return listMail;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Pobiera cala konwersacje dla firmy lub uzytkownika
        /// </summary>
        /// <param name="where">where do zapytania pobierajacego dane</param>
        /// <returns>Lista maili</returns>
        public static List<cMail> getConversation(string where)
        {
            List<cMail> listMail = new List<cMail>();

            try
            {
                ADODB.Recordset rdMail = new ADODB.Recordset();
                string sql = "select m.id, m.type, m.name, m.mail, m.tittle, m.messageText, m.messageDate, m.readMail, ISNULL(m.clientId,0) clientId, u.login mail2 from mailbox m join users u on m.userid = u.id where " +where+ " order by m.MESSAGEDATE desc";
                rdMail.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, (Int32)ADODB.CommandTypeEnum.adCmdText);

                while (!rdMail.EOF)
                {
                    cMail tempMail = new cMail();

                    tempMail.id = rdMail.Fields["ID"].Value;
                    tempMail.type = rdMail.Fields["TYPE"].Value;
                    tempMail.name = rdMail.Fields["NAME"].Value;
                    tempMail.address = rdMail.Fields["MAIL"].Value;
                    tempMail.userAddress = rdMail.Fields["MAIL2"].Value;
                    tempMail.tittle = rdMail.Fields["TITTLE"].Value;
                    tempMail.date = rdMail.Fields["MESSAGEDATE"].Value;
                    tempMail.text = rdMail.Fields["MESSAGETEXT"].Value;
                    tempMail.read = rdMail.Fields["READMAIL"].Value;
                    tempMail.userId = cSession.userId;

                    if (rdMail.Fields["CLIENTID"].Value != 0)
                        tempMail.clientId = rdMail.Fields["CLIENTID"].Value;

                    listMail.Add(tempMail);
                    rdMail.MoveNext();
                }
                rdMail.Close();
                return listMail;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Oznaczenie wiadomosci jako przeczytanej
        /// </summary>
        /// <returns>true - powodzenie/false - niepowodzenie</returns>
        public bool markAsRead()
        {
            try
            {
                object tempObj;
                if (read == false)
                {
                    read = true;
                    cConnection.conn.Execute("update mailbox set readMail = 1 where id = " + id, out tempObj);
                }
                return true; 
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Oznaczenie wiadomosci jako nieprzeczytanej
        /// </summary>
        /// <returns>true - powodzenie/false - niepowodzenie</returns>
        public bool markAsUnRead()
        {
            try
            {
                object tempObj;
                cConnection.conn.Execute("update mailbox set readMail = 0 where id = " + id, out tempObj);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
