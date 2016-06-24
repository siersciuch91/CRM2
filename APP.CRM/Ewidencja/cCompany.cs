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
        /// <summary>
        /// Funkcja zwracajaca liste firm
        /// </summary>
        /// <returns></returns>
        public static List<cCompany> getCompany()
        {
            List<cCompany> listCompany = new List<cCompany>();
            try
            {
                ADODB.Recordset rdCompany = new ADODB.Recordset();
                string sql = "select id, companyName, id_street, houseno, nip, tel, mail from company where active =1";
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
                return listCompany;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Pobiera nazwe firmy po id
        /// </summary>
        /// <param name="id">id firmy dla ktorej pobieramy nazwe</param>
        /// <returns>nazwe firmy/null w przypadku bledu</returns>
        public static string getNameById(int id)
        {
            try
            {
                string returnName = "";
                ADODB.Recordset rdCompany = new ADODB.Recordset();
                string sql = "select companyName from company where active = 1 and id = " + id;
                rdCompany.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, (Int32)ADODB.CommandTypeEnum.adCmdText);
                if (!rdCompany.EOF)
                    returnName = rdCompany.Fields[0].Value;

                rdCompany.Close();
                return returnName;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Dezaktywacja firmy i wszystkich klientow powiazanych do niej
        /// </summary>
        /// <returns></returns>
        public bool deleteCompany()
        {
            try
            {
                object tempObj;
                cConnection.conn.BeginTrans();
                cConnection.conn.Execute("update company set active = 0 where id = " + id, out tempObj);
                cConnection.conn.Execute("update client set active = 0 where id_company = " + id, out tempObj);
                cConnection.conn.CommitTrans();
                return true;
            }
            catch
            {
                cConnection.conn.RollbackTrans();
                return false;
            }
        }
        /// <summary>
        /// Metoda dodająca firmę
        /// </summary>
        public bool addCompany()
        {
            try
            {
                ADODB.Recordset rdCompany = new ADODB.Recordset();
                string sql = "select id, companyName, id_street, houseno, nip, tel, mail from company";

                object nilTempConv = Type.Missing;
                rdCompany.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, (Int32)ADODB.CommandTypeEnum.adCmdText);
                rdCompany.AddNew(nilTempConv, nilTempConv);
                setProperty(rdCompany);

                rdCompany.Update();

                id = rdCompany.Fields["ID"].Value;
                rdCompany.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Metoda ustawiajace wartosci rekordu
        /// </summary>
        /// <param name="rdUser"></param>
        private void setProperty(ADODB.Recordset rdUser)
        {
            rdUser.Fields["companyName"].Value = name;
            rdUser.Fields["id_street"].Value = streetId;
            rdUser.Fields["houseno"].Value = houseNo;
            rdUser.Fields["nip"].Value = NIP;
            rdUser.Fields["tel"].Value = tel;
            rdUser.Fields["MAIL"].Value = mail;
        }
        /// <summary>
        /// Funkcja zmianiajaca dane klienta
        /// </summary>
        /// <returns></returns>
        public bool modifyCompany()
        {
            try
            {
                ADODB.Recordset rdCompany = new ADODB.Recordset();
                string sql = "select id, companyName, id_street, houseno, nip, tel, mail from company where id = " + id;
                rdCompany.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, (Int32)ADODB.CommandTypeEnum.adCmdText);

                setProperty(rdCompany);

                rdCompany.Update();
                rdCompany.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
