using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagautdinovSQLApp
{
    internal class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=avtor");
        public void open()
        {
            if(connection.State==System.Data.ConnectionState.Closed) {
            connection.Open();}
        }
        public void close()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
            public MySqlConnection get()
            {
            return connection;
            }
        }
    }

