using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DB.CRM
{
    public class dbClient
    {
        private int id;
        private string name;
        private string mail;

        private List<dbClient> getUsers()
        {
            List<dbClient> users = new List<dbClient>();
            string connString = "Provider=SQLOLEDB.1;Persist Security Info=True;User ID=sa;Initial Catalog=CRM;Data Source=SIERSCIUCH-NB\\SQL2014;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Use Encryption for Data=False;Tag with column collation when possible=False;Password=Politechnika*2016";
            ADODB.Connection conn = new ADODB.Connection();
            conn.Open(connString, "", "", -1);
            ADODB.Recordset rdUsers = new ADODB.Recordset();
            string sql = "select id, name, mail from Clients";
            rdUsers.Open(sql, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, 0);


            return users;

        }
       
    }
}
