using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP.CRM
{
    class cAttachments
    {
        public int id;
        public int messageId;
        public byte[] data;
        public string name;

        internal void insertAttachment()
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal List<cAttachments> getListWithoutBin(int messageId)
        {
            List<cAttachments> listAtt = new List<cAttachments>();
            ADODB.Recordset rdAtt = new ADODB.Recordset();
            string sql = "select id,  name from attachment where messageid = " +messageId;
            rdAtt.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, 0);

            while(!rdAtt.EOF)
            {
                cAttachments attTemp = new cAttachments();
                attTemp.id = rdAtt.Fields["ID"].Value;
                attTemp.messageId = messageId;
                attTemp.name = rdAtt.Fields["NAME"].Value;
                listAtt.Add(attTemp);
                rdAtt.MoveNext();
            }
            rdAtt.Close();


            return listAtt;
        }
    }
}
