using System;
using System.Collections.Generic;


namespace APP.CRM
{
    public class cUser
    {
        int id;
        string login;
        string name;



        public static bool checkUserLogin(string login, string password)
        {
            bool returnValue = false;
            try
            {
                ADODB.Recordset rdUser = new ADODB.Recordset();
                string sql = "select id from users where login = '" + login + "' and password = HASHBYTES('MD5','" + password + "')";
                rdUser.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, 0);

                if (!rdUser.EOF)
                {
                    cSession.userId = rdUser.Fields[0].Value;
                    returnValue = true;
                }

                rdUser.Close();

                return returnValue;
            }
            catch (Exception ex)
            {
                return returnValue;
            }
        }

        public List<cUser> getListUsers()
        {
            List<cUser> users = new List<cUser>();
            ADODB.Recordset rdUsers = new ADODB.Recordset();
            string sql = "select id, name, login from users";
            rdUsers.Open(sql, cConnection.conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, 0);

            while(!rdUsers.EOF)
            {
                cUser tempUser = new cUser();
                tempUser.id = rdUsers.Fields["id"].Value;
                tempUser.login = rdUsers.Fields["login"].Value;
                tempUser.name = rdUsers.Fields["name"].Value;
                users.Add(tempUser);
                rdUsers.MoveNext();
            }
            rdUsers.Close();

            return users;

        }
    }
}
