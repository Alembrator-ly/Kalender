using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kalender.DAL;
using Kalender.PL;
using MySql.Data.MySqlClient;

namespace Kalender
{
    public partial class frm_Main : Form
    {

        DataAccessLayer DAL = new DataAccessLayer();
        //field from type this Form 
        private static frm_Main frm;
        
        //to get the form if is not null 
        public static frm_Main getMainForm {
            get {
                if (frm == null)
                {
                    frm = new frm_Main();
                    frm.FormClosed += Frm_FormClosed;
                }
                return frm;
            }
        }
        

        private static void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public frm_Main()
        {
            InitializeComponent();
            DataAccessLayer DAL = new DataAccessLayer();

            if (frm == null)
                frm = this;
            try
            {
                string selectQuery = "select * from tbl_users where userName = '" + Properties.Settings.Default.userName 
                    + "' and userPass = '" + Properties.Settings.Default.Password + "'";
                DataTable Dt = DAL.fetchData(selectQuery);
                if (Dt.Rows.Count == 0)
                {
                    Properties.Settings.Default.Reset();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            
            //Make Instance from Class "DataAccessLayer" to call the functions

            // Connect to Database
            MySqlConnection mySqlConnection = DAL.myConnection();
            try
            {
                mySqlConnection.Open();
                lbl_OnOff.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                //To write log file when some problem hapend with the connection to database
                using (StreamWriter w = File.AppendText(Environment.CurrentDirectory + "\\log.txt"))
                {
                    w.WriteLine(DateTime.Now +"-->"+ ex.Message);
                } 
                
                lbl_OnOff.BackColor = Color.Red;
            }

            //to get Days of current month
            int DaysOfMonth = DateTime.DaysInMonth(int.Parse(DateTime.Now.ToString("yyyy")), int.Parse(DateTime.Now.ToString("MM")));
            DAL.disconnect(mySqlConnection);

            if (string.IsNullOrEmpty(Properties.Settings.Default.userName) && string.IsNullOrEmpty(Properties.Settings.Default.Password))
            {
                ts_btn_Termin.Enabled = false;
                frm_Login frm_Login = new frm_Login();
                frm_Login.ShowDialog();

            }
            else
                ts_btn_Login.Enabled = false;

            
        }

        private void ts_btn_Login_Click(object sender, EventArgs e)
        {
            frm_Login frm = new frm_Login();
            frm.ShowDialog();
        }

        private void ts_btn_Termin_Click(object sender, EventArgs e)
        {
            frm_Termin frm = new frm_Termin();
            frm.ShowDialog();
        }

      

        private void btn_AddKalender_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "insert into tbl_Kalender (kalenderName, userId) values('" + txt_KalenderName.Text + "'," + Properties.Settings.Default.userId + ")";
                DAL.executing(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
