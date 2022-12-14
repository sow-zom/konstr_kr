using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace konstr_kr
{
    class db
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;username=root;database=sportinfostructure");

        public void OpenDBconnect()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                }
                catch
                {
                    MessageBox.Show("Не має підключення до Бази даних!");
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void CloseDBconnect()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection getConnention()
        {
            return connection;
        }
    }
}
