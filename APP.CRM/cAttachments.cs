using System;
using System.Windows.Forms;

namespace APP.CRM
{
    public class cAttachments
    {
        public int id;
        public int messageId;
        public byte[] data;
        public string name;

        
        public ListView lvItem;
        /// <summary>
        /// Zapsianie załączników do bazy
        /// </summary>
        public bool insertAttachment()
        {
            try
            {
                ADODB.Recordset rdAtt = new ADODB.Recordset();
                string sql = "select id, messageId, name, data from attachment";
                object nilTempConv = Type.Missing;
                rdAtt.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, 0);
                rdAtt.AddNew(nilTempConv, nilTempConv);

                rdAtt.Fields["MESSAGEID"].Value = messageId;
                rdAtt.Fields["NAME"].Value = name;
                rdAtt.Fields["DATA"].Value = data;

                rdAtt.Update();
                rdAtt.Close();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// Pobanie informacji o załącznikach bez binary
        /// </summary>
        /// <param name="messageId">id wiadomosci dla których maja byc pobrane</param>
        /// <param name="lvAtt">ListView do którego wczytujemy załączniki</param>
        public static bool  getListWithoutBin(int messageId, ListView lvAtt)
        {
            try
            {
                ADODB.Recordset rdAtt = new ADODB.Recordset();
                string sql = "select id,  name from attachment where messageid = " + messageId;
                rdAtt.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, 0);

                string tempPath = System.IO.Path.GetTempPath();
                while (!rdAtt.EOF)
                {
                    cAttachments attTemp = new cAttachments();
                    attTemp.id = rdAtt.Fields["ID"].Value;
                    attTemp.messageId = messageId;
                    attTemp.name = rdAtt.Fields["NAME"].Value;

                    ListViewItem lviTemp = new ListViewItem(attTemp.name);

                    lviTemp.Tag = attTemp;

                    lvAtt.Items.Add(lviTemp);
                    rdAtt.MoveNext();
                }
                rdAtt.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Pobranie binarek do załącznika
        /// </summary>
        /// <returns></returns>
        public bool getBinnary()
        {
            try
            {
                ADODB.Recordset rdAtt = new ADODB.Recordset();
                string sql = "select data from attachment where id = " + this.id;
                rdAtt.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, 0);

                this.data = rdAtt.Fields["DATA"].Value;

                rdAtt.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
