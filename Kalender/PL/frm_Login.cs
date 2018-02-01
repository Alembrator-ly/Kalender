using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kalender.DAL;

namespace Kalender.PL
{
    public partial class frm_Login : Form
    {
        DataAccessLayer DAL = new DataAccessLayer();
        MySqlConnection mySqlConnection;

        public frm_Login()
        {
            InitializeComponent();
            mySqlConnection = new MySqlConnection(DAL.myConnection("localhost", "db_kalender", 3306, "root", "root"));
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("select * from tbl_users where userName = '" + txtb_UserName.Text+"' and userPass = '"+txtb_Password.Text+"'", mySqlConnection);
            MySqlDataAdapter Da = new MySqlDataAdapter(mySqlCommand);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                frm_Main.getMainForm.ts_btn_Termin.Enabled = true;
                frm_Main.getMainForm.ts_btn_Login.Enabled = false;
                Properties.Settings.Default.userName = txtb_UserName.Text;
                Properties.Settings.Default.Password = txtb_Password.Text;
                Properties.Settings.Default.Save();
                this.Close();
            }
            else
            {
                MessageBox.Show("Password or User Name is wrong");
            }
        }
    }
}
