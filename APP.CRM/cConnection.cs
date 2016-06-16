using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.CRM
{
    public class cConnection
    {
        public static ADODB.Connection conn = new ADODB.Connection();

        public static bool setConnection(string server, string database, bool windowsAuth, string user = "", string password="")
        {
            try
            {
                //ADODB.Connection connTemp = new ADODB.Connection();
                string connString = "Provider=SQLOLEDB.1;Initial Catalog=" + database + ";Data Source=" + server + ";";//;Password=Politechnika*2016";

                if (windowsAuth)
                    connString += "Trusted_Connection=yes;";

                conn.Open(connString, user, password);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
