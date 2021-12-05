using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFC_READ
{
    class DB_Look
    {
        public int info = 0;
        public bool Enabled = false;

        string Set_Hostname, Set_Database, Set_User, Set_Password;

        string connectionString;
        MySqlConnection conn;

        public DB_Look(String Set_Hostname, String Set_Password, String Set_User, String Set_Database)
        {
            this.Set_Hostname = Set_Hostname;
            this.Set_Password = Set_Password;
            this.Set_User = Set_User;
            this.Set_Database = Set_Database;
        }


        public void Start()
        {
            Task.Run(() => {

                Task.Delay(2000);
                Enabled = true;
                info = 0;
                while (Enabled == true && info == 0)
                {
                    try
                    {
                        connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3}", Set_Hostname, Set_Database, Set_User, Set_Password);

                        conn = new MySqlConnection(connectionString);
                        conn.Open();

                        info = 1;
                        Enabled = false;

                    }
                    catch (Exception)
                    {
                        info = 0;

                        Task.Delay(2000);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            });
        }
    }

}
