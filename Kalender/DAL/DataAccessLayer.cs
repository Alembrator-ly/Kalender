using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.Windows.Forms;

namespace Kalender.DAL
{
    class DataAccessLayer
    {

        private DataTable Dt = new DataTable();
        private MySqlCommand cmd;

        public void disconnect(MySqlConnection con)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }


        public void executing(string query,out int result)
        {
            try
            {
                MySqlConnection Conn = myConnection();
                cmd = new MySqlCommand(query, Conn);
                if (Conn.State != ConnectionState.Open)
                    Conn.Open();
                cmd.ExecuteNonQuery();
                result = 1;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = 0;
            }
        }

        public DataTable fetchData(string selectQuery)
        {
            try
            {
                MySqlDataAdapter Da = new MySqlDataAdapter(selectQuery, myConnection());
                Da.Fill(Dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Dt;
        }




        public MySqlConnection myConnection()
        {
            MySqlConnectionStringBuilder ConnectionSB = new MySqlConnectionStringBuilder();
            ConnectionSB.Server = Properties.Settings.Default.host;
            ConnectionSB.Database = Properties.Settings.Default.dbName;
            ConnectionSB.Port = Properties.Settings.Default.port;
            ConnectionSB.UserID = Properties.Settings.Default.db_userID;
            ConnectionSB.Password = Properties.Settings.Default.userPassword;
            string cs = ConnectionSB.ToString();
            return new MySqlConnection(cs);
        }

    }
}
