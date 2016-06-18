using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP.CRM.Ewidencja
{
    public class cCompany
    {
        public int id;
        public string name = "";
        public int streetId;
        public string houseNo;
        public string NIP;
        public string tel;
        public string mail;

        public static List<cCompany> getCompany()
        {
            List<cCompany> listCompany = new List<cCompany>();

            try
            {
                ADODB.Recordset rdCompany = new ADODB.Recordset();
                string sql = "select id, companyName, id_street, houseno, nip, tel, mail from company";
                rdCompany.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, (Int32)ADODB.CommandTypeEnum.adCmdText);

                while (!rdCompany.EOF)
                {
                    cCompany tempCompany = new cCompany();

                    tempCompany.id = rdCompany.Fields["ID"].Value;
                    tempCompany.name = rdCompany.Fields["companyName"].Value;
                    tempCompany.streetId = rdCompany.Fields["id_street"].Value;
                    tempCompany.houseNo = rdCompany.Fields["houseno"].Value;
                    tempCompany.NIP = rdCompany.Fields["nip"].Value;
                    tempCompany.tel = rdCompany.Fields["tel"].Value;
                    tempCompany.mail = rdCompany.Fields["mail"].Value;

                    listCompany.Add(tempCompany);
                    rdCompany.MoveNext();
                }
                rdCompany.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return listCompany;
        }

        public static string getNameById(int id)
        {
            string returnName = "";
            ADODB.Recordset rdCompany = new ADODB.Recordset();
            string sql = "select companyName from company where id = " + id;
            rdCompany.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, (Int32)ADODB.CommandTypeEnum.adCmdText);
            if (!rdCompany.EOF)
                returnName = rdCompany.Fields[0].Value;

            rdCompany.Close();

            return returnName;
        }

    }
}
