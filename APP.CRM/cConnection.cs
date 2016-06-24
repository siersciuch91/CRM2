using System;

namespace APP.CRM
{
    //osobna klasa tworzaca i przechowujaca polaczenie do bnzy danych
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
            catch
            {
                return false;
            }
        }
    }
}
