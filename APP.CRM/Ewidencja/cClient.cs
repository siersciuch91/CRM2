using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP.CRM.Ewidencja
{
    public class cClient
    {
        public int id;
        public int companyId;
        public string name;
        public string secondName;
        public string tel;
        public string mail;
        /// <summary>
        /// Funkcja zmieniajaca status na nieaktywny, aby powiazania wiadomosci nie byly stracone
        /// </summary>
        /// <returns>true w przypadku powodzenia</returns>
        public bool deleteClient()
        {
            try
            {
                object tempObj;
                cConnection.conn.Execute("update client set active = 0 where id = " + id, out tempObj);

                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Funkcja dodajaca nowego klienta do bazy
        /// </summary>
        public bool addUser()
        {
            try
            {
                ADODB.Recordset rdUser = new ADODB.Recordset();
                string sql = "select id, id_company, name, secondname, tel, mail from client";

                object nilTempConv = Type.Missing;
                rdUser.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, (Int32)ADODB.CommandTypeEnum.adCmdText);
                rdUser.AddNew(nilTempConv, nilTempConv);
                setProperty(rdUser);

                rdUser.Update();

                id = rdUser.Fields["ID"].Value;
                rdUser.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Funkcja ustawiajaca dane w bazie
        /// </summary>
        /// <param name="rdUser"></param>
        private void setProperty(ADODB.Recordset rdUser)
        {
            if (companyId > 0)
                rdUser.Fields["ID_COMPANY"].Value = companyId;

            rdUser.Fields["NAME"].Value = name;
            rdUser.Fields["SECONDNAME"].Value = secondName;
            rdUser.Fields["TEL"].Value = tel;
            rdUser.Fields["MAIL"].Value = mail;
        }
        /// <summary>
        /// Funkcja modyfikujaca klienta
        /// </summary>
        /// <returns></returns>
        public bool modifyUser()
        {
            try
            {
                ADODB.Recordset rdUser = new ADODB.Recordset();
                string sql = "select id, id_company, name, secondname, tel, mail from client where id = " + id;
                rdUser.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, (Int32)ADODB.CommandTypeEnum.adCmdText);

                setProperty(rdUser);

                rdUser.Update();
                rdUser.Close();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        /// <summary>
        /// Funckja zwracaja liste klientow
        /// </summary>
        /// <param name="addWhere"></param>
        /// <returns></returns>
        public static List<cClient> getClient(string addWhere = "")
        {
            List<cClient> listCompany = new List<cClient>();

            try
            {
                ADODB.Recordset rdCompany = new ADODB.Recordset();
                string sql = "select id, id_company, name, secondname, tel, mail from client where active = 1 " + addWhere;
                rdCompany.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, (Int32)ADODB.CommandTypeEnum.adCmdText);

                while (!rdCompany.EOF)
                {
                    cClient tempClient= new cClient();

                    tempClient.id = rdCompany.Fields["ID"].Value;
                    tempClient.companyId = rdCompany.Fields["id_company"].Value;
                    tempClient.name = rdCompany.Fields["name"].Value;
                    tempClient.secondName = rdCompany.Fields["secondname"].Value;
                    tempClient.tel = rdCompany.Fields["tel"].Value;
                    tempClient.mail = rdCompany.Fields["mail"].Value;

                    listCompany.Add(tempClient);
                    rdCompany.MoveNext();
                }
                rdCompany.Close();
                return listCompany;
            }
            catch 
            {
                return null;
            }
        }
    }
}
