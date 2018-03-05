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
        int id;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="con"></param>
        public void disconnect(MySqlConnection con)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="result"></param>
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
               // MessageBox.Show(ex.Message);
                result = 0;
            }
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        public void executing(string query)
        {
            try
            {
                MySqlConnection Conn = myConnection();
                cmd = new MySqlCommand(query, Conn);
                if (Conn.State != ConnectionState.Open)
                    Conn.Open();
                cmd.ExecuteNonQuery();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectQuery"></param>
        /// <returns></returns>
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



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public void setId(string query)
        {
            MySqlConnection Conn = myConnection();
            cmd = new MySqlCommand(query, Conn);
            if (Conn.State != ConnectionState.Open)
                Conn.Open();
            cmd.ExecuteNonQuery();
        }

        public int rowCount(string query)
        {
            Dt = new DataTable();
            MySqlDataAdapter Da = new MySqlDataAdapter(query, myConnection());
            Da.Fill(Dt);
            id = int.Parse( Dt.Rows[0][0].ToString());
            return id;
        }

    }
}
