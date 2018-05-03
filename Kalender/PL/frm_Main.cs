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
        public static string cbName = "";
        public static string cbTitel = "";
        public int KalenderId;
        CheckBox getCheckBoxInfo;
        //fuctions fuctions = new fuctions(cbName,cbTitel);
        public string color = "255 255 255";
        public int red = 0;
        public int green = 0;
        public int blue = 0;
        //field from type this Form 
        private static frm_Main frm;

        //to get the form if is not null 
        public static frm_Main getMainForm
        {
            get
            {
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
            dgv_ContentTermin.RowTemplate.Height = 50;
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
                    btn_AddKalender.Enabled = false;
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
                //ts_btn_Login.Image = Image.FromFile(Environment.CurrentDirectory + "\\icon\\Logout.png");

            }

            lbl_UserName.Text = "Benutzer: " + Properties.Settings.Default.userName;

            //fuctions.cmbGenrator(red, green, blue, cbName, cbTitel);
            //TODO: All in one function
            try
            {
                fLP_Kalender.Controls.Clear();
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

            try
            {
                fLP_SharedCalender.Controls.Clear();
                string query = "select k.kalenderName, k.color,u.userName from tbl_kalender as k " +
                    "inner join tbl_shared as s on k.kalender_Id = s.kalenderId " +
                    "inner join tbl_users as u on k.userId = u.user_Id " +
                    "where s.userId = " + Properties.Settings.Default.userId;
                DataTable Dt = DAL.fetchData(query);


                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    //TO call the value from Color Columns
                    string kalenderColor = Dt.Rows[i]["color"].ToString();
                    string[] colorArray = kalenderColor.Split(' ');
                    red = int.Parse(colorArray[0]);
                    green = int.Parse(colorArray[1]);
                    blue = int.Parse(colorArray[2]);

                    CheckBox cb = new CheckBox();
                    cb.Name = "cb_" + Dt.Rows[i]["kalenderName"].ToString();
                    cb.Text = Dt.Rows[i]["kalenderName"].ToString()+"-("+Dt.Rows[i]["userName"].ToString()+")";
                    cb.BackColor = Color.FromArgb(red, green, blue);
                    cb.CheckedChanged += Cb_Shared_CheckedChanged;
                    cb.MouseHover += Item_MouseHover;
                    //cb.ContextMenuStrip = frm_Main.getMainForm.contextMS_Kalender;
                    fLP_SharedCalender.Controls.Add(cb);
                }
                Dt.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Cb_Shared_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string[] splitkalenderName = checkBox.Text.Split('-');
            string kalenderName = splitkalenderName[0];
            string kalenderOwner = splitkalenderName[1].Substring(1, splitkalenderName[1].Length-2).ToLower();
            string query = "SELECT t.termin_id, t.Titel,t.started,t.status,t.ended, k.kalenderName, k.color, u.userName as 'Kalender Owner' " +
                "from tbl_kalender as k " +
                "inner join tbl_termin as t " +
                "on k.kalender_Id = t.kalenderId " +
                "inner join tbl_users as u " +
                "on k.userId = u.user_Id " +
                "where k.kalenderName = '" + kalenderName + 
                "' and  k.userid <> " + Properties.Settings.Default.userId + " and u.userName = '"+kalenderOwner+"'";



            if (checkBox.Checked == true)
            {
                DtShowTermin = DAL.fetchData(query);

                DtAll.Merge(DtShowTermin);
                dgv_ContentTermin.DataSource = DtAll;
                dgv_ContentTermin.Columns["color"].Visible = false;
               // dgv_ContentTermin.Columns["userName"].Visible = false;
                dgv_ContentTermin.Columns["termin_id"].Visible = false;

            }
            else
            {
                //string query2 = "select userid from tbl_kalender where kalenderName  ='" + dgv_ContentTermin.CurrentRow.Cells[4].Value.ToString() + "'";
                //int userId = int.Parse(DAL.fetchData(query2).Rows[0][0].ToString());
                foreach (DataRow row in DtAll.Rows)
                {
                    if (row["kalenderName"].ToString() == kalenderName && 
                        row["Kalender Owner"].ToString().ToLower() != Properties.Settings.Default.userName.ToLower())
                    {
                        row.Delete();
                    }

                }
                DtAll.AcceptChanges();

                dgv_ContentTermin.DataSource = DtAll;

            }

            //To set rows color like calendar color
            try
            {
                for (int i = 0; i < dgv_ContentTermin.Rows.Count; i++)
                {
                    string rowColor = dgv_ContentTermin.Rows[i].Cells["color"].Value.ToString();
                    string[] colors = rowColor.Split(' ');
                    dgv_ContentTermin.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(int.Parse(colors[0]), int.Parse(colors[1]), int.Parse(colors[2]));
                }
            }
            catch (Exception)
            {


            }
        }

        private void Cb_Selected(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string kalenderName = checkBox.Text;
            string query = "SELECT t.termin_id, t.Titel,t.started,t.status,t.ended, k.kalenderName, k.color, u.userName as 'Kalender Owner' " +
                "from tbl_Kalender as k " +
                "inner join tbl_termin as t " +
                "on k.kalender_Id = t.kalenderId " +
                " inner join tbl_users as u " +
                "on k.userId = u.user_Id " +
                "where k.kalenderName = '" + kalenderName + "'and k.userid = " + Properties.Settings.Default.userId;

            // To Show and hide the termin from Datagridview
            if (checkBox.Checked == true)
            {
                DtShowTermin = DAL.fetchData(query);

                DtAll.Merge(DtShowTermin);
                dgv_ContentTermin.DataSource = DtAll;
                dgv_ContentTermin.Columns["color"].Visible = false;
                //dgv_ContentTermin.Columns["userName"].Visible = false;
                dgv_ContentTermin.Columns["termin_id"].Visible = false;

            }
            else
            {

                foreach (DataRow row in DtAll.Rows)
                {
                    if (row["kalenderName"].ToString() == checkBox.Text && row["Kalender Owner"].ToString().ToLower() == Properties.Settings.Default.userName.ToLower())
                    {
                        row.Delete();
                    }

                }
                DtAll.AcceptChanges();

                dgv_ContentTermin.DataSource = DtAll;



            }

            //To set rows color like calendar color
            try
            {
                for (int i = 0; i < dgv_ContentTermin.Rows.Count; i++)
                {
                    string rowColor = dgv_ContentTermin.Rows[i].Cells["color"].Value.ToString();
                    string[] colors = rowColor.Split(' ');
                    dgv_ContentTermin.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(int.Parse(colors[0]), int.Parse(colors[1]), int.Parse(colors[2]));
                }
            }
            catch (Exception)
            {


            }
        }

        private void ts_btn_Login_Click(object sender, EventArgs e)
        {
            if (this.ts_btn_Login.Name == "ts_btn_Login")
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
            //to check the calendar if a found don't added the calendar else add the calendar
            List<string> kalenders = new List<string>();
            foreach (CheckBox cb in fLP_Kalender.Controls)
            {
                kalenders.Add(cb.Text.ToUpper());
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
                        string query = "insert into tbl_Kalender (kalenderName, userId,color) values('" + txtb_KalenderName.Text + "'," + Properties.Settings.Default.userId + ",'" + color + "')";
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

                txtb_KalenderName.Clear();
            }
            else
            {
                MessageBox.Show("calendar is used");
            }

        }

        private void contextMSItem_UserLogout_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Application.Restart();
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

                DAL.executing("delete from tbl_kalender where kalendername='" + cbTitel + "'", out output);
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

            getCheckBoxInfo = (CheckBox)sender;
            cbName = getCheckBoxInfo.Name;
            cbTitel = getCheckBoxInfo.Text;

        }

        private void kalenderFarbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                DtAll.Clear();
                //MessageBox.Show(colorDialog.Color.R.ToString()+" "+ colorDialog.Color.G.ToString()+ " " + colorDialog.Color.B.ToString());
                color = colorDialog.Color.R.ToString() + " " + colorDialog.Color.G.ToString() + " " + colorDialog.Color.B.ToString();
                DataTable Dt = DAL.fetchData("select * from tbl_kalender where kalenderName='" + cbTitel + "' and userid =" + Properties.Settings.Default.userId + ";");
                int KalenderId = int.Parse(Dt.Rows[0]["kalender_Id"].ToString());
                string query = "update tbl_kalender set color='" + color + "' where kalender_Id=" + KalenderId + "";
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
                        cb.Checked = true;
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

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            // to uncheked the the calendar 
            foreach (CheckBox item in fLP_Kalender.Controls)
            {
                item.Checked = false;
            }
            //TODO: Show only the Termins which the user selected the date 
            string query;
            if (monthCalendar1.SelectionEnd.ToString("yyyy-MM-dd") == monthCalendar1.SelectionStart.ToString("yyyy-MM-dd"))
            {
                query = "SELECT t.Titel,t.started,t.status,t.ended, k.kalenderName, k.color " +
            "from tbl_termin as t " +
            "inner join tbl_kalender as k " +
            "on t.kalenderId = k.kalender_Id " +
            "where started like '" + monthCalendar1.SelectionStart.ToString("yyyy-MM-dd") + " %' and k.userId = " + Properties.Settings.Default.userId;
            }
            else
            {
                query = "SELECT t.Titel,t.started,t.status,t.ended, k.kalenderName, k.color " +
           "from tbl_termin as t " +
           "inner join tbl_kalender as k " +
           "on t.kalenderId = k.kalender_Id " +
           "where started between '" + monthCalendar1.SelectionStart.ToString("yyyy-MM-dd") + " %' " +
           "and  '" + monthCalendar1.SelectionEnd.ToString("yyyy-MM-dd") + " %'and k.userId = " + Properties.Settings.Default.userId;
            }

            dgv_ContentTermin.DataSource = DAL.fetchData(query);

            try
            {
                for (int i = 0; i < dgv_ContentTermin.Rows.Count; i++)
                {
                    string rowColor = dgv_ContentTermin.Rows[i].Cells["color"].Value.ToString();
                    string[] colors = rowColor.Split(' ');
                    dgv_ContentTermin.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(int.Parse(colors[0]), int.Parse(colors[1]), int.Parse(colors[2]));
                }
            }
            catch (Exception)
            {


            }
        }

        private void monthCalendar1_MouseHover(object sender, EventArgs e)
        {
            Point point = monthCalendar1.Location;
            toolTip1.ToolTipTitle = "Informationen";
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.Show("Wenn Sie die Termine zwischen zwei Datum zeigen möchten, \n" +
                " Klicken Sie auf erste Datum und ziehen bis zweite Datum", monthCalendar1, point.X, point.Y, 3000);

        }

        private void txtb_Search_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT t.Titel, t.started, t.status, t.ended, k.kalendername " +
                "from tbl_Kalender as K " +
                "inner join tbl_Termin as t on k.kalender_Id = t.kalenderId " +
                "where t.titel like '%" + txtb_Search.Text + "%' and " +
                "k.userId = " + Properties.Settings.Default.userId;

            try
            {
                dgv_ContentTermin.Refresh();
                dgv_ContentTermin.DataSource = DAL.fetchData(query);
            }
            catch (Exception ex)
            {

            }
        }

        private void contextMSItem_ShareKalender_Click(object sender, EventArgs e)
        {
            DataTable Dt = DAL.fetchData("select * from tbl_Kalender where userid = " + Properties.Settings.Default.userId
                + " and kalenderName = '" + getCheckBoxInfo.Text + "'");
            KalenderId = Convert.ToInt32(Dt.Rows[0][0].ToString());

            using (frm_CalenderShared frm = new frm_CalenderShared())
            {
                frm.ShowDialog();
            }

        }

        //To open the Termin edit window and passed the old Value int the Termin fildes 
        private void ContextMS_Item_EditTermin_Click(object sender, EventArgs e)
        {
            using (frm_Termin frm = new frm_Termin())
            {
                frm.txtb_TerminTitel.Text = dgv_ContentTermin.CurrentRow.Cells["Titel"].Value.ToString();
                frm.dtp_DateStart.Text = dgv_ContentTermin.CurrentRow.Cells["started"].Value.ToString();
                frm.dtp_DateEnd.Text = dgv_ContentTermin.CurrentRow.Cells["ended"].Value.ToString();
                frm.dtp_TimeStart.Text = dgv_ContentTermin.CurrentRow.Cells["started"].Value.ToString();
                frm.dtp_TimeEnd.Text= dgv_ContentTermin.CurrentRow.Cells["ended"].Value.ToString();
                Program.Kalender = dgv_ContentTermin.CurrentRow.Cells["KalenderName"].Value.ToString();
                frm.btn_AddTermin.Text = "Aktualisierung";
                frm.ShowDialog();

            }
        }



        //Delete Termin  
        private void ContextMS_Item_DeleteTermin_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Möchten sie den Termin löschen", "Termin löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // select the userId where userName = Name
                string query2 = "select user_id from tbl_users where userName  ='" + dgv_ContentTermin.CurrentRow.Cells["userName"].Value.ToString() + "' ";
                int userId = int.Parse(DAL.fetchData(query2).Rows[0][0].ToString());
                
                // if userId not  owner than can't Delete the termin
                if (userId == Properties.Settings.Default.userId)
                {
                    string query = "Delete t from  tbl_Termin t " +
                        " inner join tbl_Kalender k on t.kalenderId = k.Kalender_Id " +
                        " where k.kalenderName = '" + dgv_ContentTermin.CurrentRow.Cells["kalenderName"].Value.ToString() + "' " +
                        " and k.userId = " + Properties.Settings.Default.userId +
                        " and t.titel = '" + dgv_ContentTermin.CurrentRow.Cells["Titel"].Value.ToString() + "' ";
                    DAL.executing(query);

                    foreach (CheckBox checkbox in fLP_Kalender.Controls)
                    {
                        checkbox.Checked = false;
                    }
                    foreach (CheckBox checkbox in fLP_Kalender.Controls)
                    {
                        checkbox.Checked = true;
                    }
                }
                else
                {
                    MessageBox.Show("Haben Sie kein Richte zu löschen !", "Benachrichtigung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {

        }
    }
}
