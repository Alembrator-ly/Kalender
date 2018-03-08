using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Kalender.BL;
using Kalender.DAL;
using Kalender.PL;
using MySql.Data.MySqlClient;

namespace Kalender
{
    public partial class frm_Main : Form
    {

        DataAccessLayer DAL = new DataAccessLayer();
        DataTable DtShowTermin = new DataTable();
        DataTable DtAll = new DataTable();
        ColorDialog colorDialog = new ColorDialog();
        public static string  cbName="";
        public static string cbTitel="";
        //fuctions fuctions = new fuctions(cbName,cbTitel);
        public string color = "255 255 255";
        public int red = 0;
        public int green = 0;
        public int blue = 0;
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
            //Properties.Settings.Default.Reset();
            try
            {
                string selectQuery = "select * from tbl_users where userName = '" + Properties.Settings.Default.userName
                    + "' and userPass = '" + Properties.Settings.Default.Password + "'";
                DataTable Dt = new DataTable();
                Dt = DAL.fetchData(selectQuery);
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
                    w.WriteLine(DateTime.Now + "-->" + ex.Message);
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
            {

                ts_btn_Login.Text = "Abmelden";
                ts_btn_Login.Name = "ts_btn_Abmelden";
                ts_btn_Login.Image = Image.FromFile(Environment.CurrentDirectory + "\\icon\\Logout.png");
                
            }

            lbl_UserName.Text = "Benutzer: " + Properties.Settings.Default.userName;

            //fuctions.cmbGenrator(red, green, blue, cbName, cbTitel);
            //TODO: All in one function
            try
            {

                string query = "select * from tbl_kalender where userId = " + Properties.Settings.Default.userId;
                DataTable Dt = DAL.fetchData(query);


                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    string kalenderColor = Dt.Rows[i]["color"].ToString();
                    string[] colorArray = kalenderColor.Split(' ');
                    red = int.Parse(colorArray[0]);
                    green = int.Parse(colorArray[1]);
                    blue = int.Parse(colorArray[2]);

                    CheckBox cb = new CheckBox();
                    cb.Name = "cb_" + Dt.Rows[i]["kalenderName"].ToString();
                    cb.Text = Dt.Rows[i]["kalenderName"].ToString();
                    cb.BackColor = Color.FromArgb(red, green, blue);
                    cb.CheckedChanged += Cb_Selected;
                    cb.MouseHover += Item_MouseHover;
                    cb.ContextMenuStrip = frm_Main.getMainForm.contextMS_Kalender;
                    frm_Main.getMainForm.fLP_Kalender.Controls.Add(cb);
                }
                Dt.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Cb_Selected(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string kalenderName=checkBox.Text;
            string query = "SELECT t.Titel,t.started,t.status,t.ended, k.kalenderName " +
                "from tbl_termin as t " +
                "inner join tbl_kalender as k " +
                "on t.kalenderId = k.kalender_Id " +
                "where k.kalenderName = '"+kalenderName+"'";
            
            
            if (checkBox.Checked==true)
            {
                DtShowTermin = DAL.fetchData(query);

                DtAll.Merge(DtShowTermin);
                dgv_ContentTermin.DataSource = DtAll;

                //MessageBox.Show(checkBox.Name+"is checked");
            }
            else
            {
                foreach (DataRow row in DtAll.Rows)
                {
                    if (row["kalenderName"].ToString() == checkBox.Text)
                    {
                        row.Delete();
                    }

                }
                DtAll.AcceptChanges();
                
                dgv_ContentTermin.DataSource = DtAll;
            }
        }

        private void ts_btn_Login_Click(object sender, EventArgs e)
        {
            if (this.ts_btn_Login.Name=="ts_btn_Login")
            {

                frm_Login frm = new frm_Login();
                frm.ShowDialog();
            }
            else
            {
                Properties.Settings.Default.Reset();
                Application.Exit();

            }
        }

        private void ts_btn_Termin_Click(object sender, EventArgs e)
        {
            frm_Termin frm = new frm_Termin();
            frm.ShowDialog();
        }



        private void btn_AddKalender_Click(object sender, EventArgs e)
        {
            //to check the calendar if a found don't add the calendar else add the calendar
            List<string> kalenders = new List<string>();
            foreach (CheckBox cb in fLP_Kalender.Controls )
            {
                kalenders.Add(cb.Text.ToUpper());
                //MessageBox.Show(cb.Text);
            }
            if (!kalenders.Contains(txtb_KalenderName.Text.ToUpper()))
            {

                if (!string.IsNullOrEmpty(txtb_KalenderName.Text))
                {

                    List<string> listKalender = new List<string>();
                    int result;
                    fLP_Kalender.Controls.Clear();


                    try
                    {
                        string query = "insert into tbl_Kalender (kalenderName, userId,color) values('" + txtb_KalenderName.Text + "'," + Properties.Settings.Default.userId + ",'"+color+"')";
                        Thread thread = new Thread(delegate () { DAL.executing(query, out result); });
                        thread.Start();
                        thread.Join();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //fuctions.cmbGenrator(red, green, blue, cbName, cbTitel);
                    //TODO: All in one function
                    try
                    {

                        string query = "select * from tbl_kalender where userId = " + Properties.Settings.Default.userId;
                        DataTable Dt = DAL.fetchData(query);


                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            string kalenderColor = Dt.Rows[i]["color"].ToString();
                            string[] colorArray = kalenderColor.Split(' ');
                            red = int.Parse(colorArray[0]);
                            green = int.Parse(colorArray[1]);
                            blue = int.Parse(colorArray[2]);

                            CheckBox cb = new CheckBox();
                            cb.Name = "cb_" + Dt.Rows[i]["kalenderName"].ToString();
                            cb.Text = Dt.Rows[i]["kalenderName"].ToString();
                            cb.BackColor = Color.FromArgb(red, green, blue);
                            cb.CheckedChanged += Cb_Selected;
                            cb.MouseHover += Item_MouseHover;
                            cb.ContextMenuStrip = frm_Main.getMainForm.contextMS_Kalender;
                            frm_Main.getMainForm.fLP_Kalender.Controls.Add(cb);
                        }
                        Dt.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("schreiben Sie den Kalender Name Bitte!", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("calendar is used");
            }
        }

        private void contextMSItem_UserLogout_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Application.Exit();            
        }

        private void kalenderLöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            List<Control> cl = new List<Control>();
            foreach (Control item in fLP_Kalender.Controls)
            {
               
                cl.Add(item);
                
            }




            try
            {
                int output;
                CheckBox check = (CheckBox)cl[cl.FindIndex(x => x.Name == cbName)];
                check.Checked = false;

                DAL.executing("delete from tbl_kalender where kalendername='" + cbTitel +"'", out output);
                if (output == 1)
                {
                    MessageBox.Show("Delete is succed");
                    int id = DAL.rowCount("select count(*) from tbl_kalender") + 1;
                    DAL.setId("alter table tbl_kalender auto_increment = " + id + "");
                    fLP_Kalender.Controls.Clear();
                    //TODO: All in one function
                    try
                    {

                        string query = "select * from tbl_kalender where userId = " + Properties.Settings.Default.userId;
                        DataTable Dt = DAL.fetchData(query);


                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            string kalenderColor = Dt.Rows[i]["color"].ToString();
                            string[] colorArray = kalenderColor.Split(' ');
                            red = int.Parse(colorArray[0]);
                            green = int.Parse(colorArray[1]);
                            blue = int.Parse(colorArray[2]);

                            CheckBox cb = new CheckBox();
                            cb.Name = "cb_" + Dt.Rows[i]["kalenderName"].ToString();
                            cb.Text = Dt.Rows[i]["kalenderName"].ToString();
                            cb.BackColor = Color.FromArgb(red, green, blue);
                            cb.CheckedChanged += Cb_Selected;
                            cb.MouseHover += Item_MouseHover;
                            cb.ContextMenuStrip = frm_Main.getMainForm.contextMS_Kalender;
                            frm_Main.getMainForm.fLP_Kalender.Controls.Add(cb);
                        }
                        Dt.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Delete is not succed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Item_MouseHover(object sender, EventArgs e)
        {

            CheckBox cb = (CheckBox)sender;
            cbName = cb.Name;
            cbTitel = cb.Text;

        }

        private void kalenderFarbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(colorDialog.Color.R.ToString()+" "+ colorDialog.Color.G.ToString()+ " " + colorDialog.Color.B.ToString());
                color = colorDialog.Color.R.ToString() + " " + colorDialog.Color.G.ToString() + " " + colorDialog.Color.B.ToString();
                DataTable Dt = DAL.fetchData("select * from tbl_kalender where kalenderName='"+cbTitel+"';");
                int KalenderId = int.Parse(Dt.Rows[0]["kalender_Id"].ToString());
                string query = "update tbl_kalender set color='"+color+"' where kalender_Id="+KalenderId+"";
                DAL.executing(query);

                //TODO: All in one function
                try
                {

                    string query1 = "select * from tbl_kalender where userId = " + Properties.Settings.Default.userId;
                    DataTable Dt1 = DAL.fetchData(query1);

                    fLP_Kalender.Controls.Clear();
                    for (int i = 0; i < Dt1.Rows.Count; i++)
                    {
                        string kalenderColor = Dt1.Rows[i]["color"].ToString();
                        string[] colorArray = kalenderColor.Split(' ');
                        red = int.Parse(colorArray[0]);
                        green = int.Parse(colorArray[1]);
                        blue = int.Parse(colorArray[2]);

                        CheckBox cb = new CheckBox();
                        cb.Name = "cb_" + Dt1.Rows[i]["kalenderName"].ToString();
                        cb.Text = Dt1.Rows[i]["kalenderName"].ToString();
                        cb.BackColor = Color.FromArgb(red, green, blue);
                        cb.CheckedChanged += Cb_Selected;
                        cb.MouseHover += Item_MouseHover;
                        cb.ContextMenuStrip = contextMS_Kalender;
                        fLP_Kalender.Controls.Add(cb);
                    }
                    Dt.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            } 
        }
    }
}
