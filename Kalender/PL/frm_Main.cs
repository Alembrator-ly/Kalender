using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kalender.DAL;
using Kalender.PL;
using MySql.Data.MySqlClient;

namespace Kalender
{
    public partial class frm_Main : Form
    {
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
            if (frm == null)
                frm = this;

            //Properties.Settings.Default.Reset();
            String nl = Environment.NewLine;
            //Make Instance from Class "DataAccessLayer" to call the functions
            DataAccessLayer DAL = new DataAccessLayer();

            // Connect to Database
            MySqlConnection mySqlConnection = new MySqlConnection(DAL.myConnection("localhost","db_kalender",3306,"root","root"));
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
    }
}
