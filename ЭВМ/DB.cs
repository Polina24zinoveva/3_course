using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=root;database=izdatelskii_center");

        public void OpenDB()
        {
            if(connection.State == System.Data.ConnectionState.Closed) 
            {
                connection.Open();
            }
        }
        public void CloseDB()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
