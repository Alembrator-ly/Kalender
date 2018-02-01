using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace Kalender.DAL
{
    class DataAccessLayer
    {

        private string host;
        private string database;

        private MySqlConnection connection;


        //public void connect()
        //{
        //    MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder();
        //    csb.Server = host;
        //    csb.Database = database;
        //    csb.Port = 3306;
        //    csb.UserID = "root";
        //    csb.Password = "root";
        //    string cs = csb.ToString();

        //    this.connection = new MySqlConnection(cs);
        //}

        public void disconnect(MySqlConnection con)
        {
            if (con.State ==ConnectionState.Open)
                con.Close();
        }

        //TODO: function to excute the query
        public void transaction(string query)
        {
            
        }



        
        public string myConnection(string host,string dbName, uint port, string userID, string userPassword)
        {
            MySqlConnectionStringBuilder ConnectionSB = new MySqlConnectionStringBuilder();
            ConnectionSB.Server = host;
            ConnectionSB.Database = dbName;
            ConnectionSB.Port = port;
            ConnectionSB.UserID = userID;
            ConnectionSB.Password = userPassword;
            return ConnectionSB.ToString();
        }

    }
}
