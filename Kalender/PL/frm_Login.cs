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
using System.Security.Cryptography;
using Kalender.Properties;

namespace Kalender.PL
{
    public partial class frm_Login : Form
    {
        DataAccessLayer DAL = new DataAccessLayer();
        BL.hashValue hv = new BL.hashValue();
		DataTable DtShowTermin = new DataTable();
		DataTable DtAll = new DataTable();
		int red;
		int green;
		int blue;

		public frm_Login()
        {
            InitializeComponent();

        }


        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtb_UserName.Text) && !string.IsNullOrWhiteSpace(txtb_Password.Text))
            {
                string hashPassword = hv.Hash(txtb_Password.Text);
                string selectQuery = "select * from tbl_users where userName = '" + txtb_UserName.Text + "' and userPass = '" + hashPassword + "'";

                DataTable Dt = DAL.fetchData(selectQuery);

                if (Dt.Rows.Count > 0)
                {
                    frm_Main.getMainForm.ts_btn_Termin.Enabled = true;
                    frm_Main.getMainForm.ts_btn_Login.Enabled = false;
                    Properties.Settings.Default.userName = txtb_UserName.Text;
                    Properties.Settings.Default.Password = hashPassword;
                    Properties.Settings.Default.userId = int.Parse(Dt.Rows[0][0].ToString());
                    frm_Main.getMainForm.lbl_UserName.Text = "Benutzer: "+txtb_UserName.Text;

                    Properties.Settings.Default.Save();
                    this.Close();
                    frm_Main.getMainForm.ts_btn_Login.Text = "Abmelden";
                    frm_Main.getMainForm.ts_btn_Login.Name = "ts_btn_Abmelden";
                    frm_Main.getMainForm.ts_btn_Login.Enabled = true;
                    frm_Main.getMainForm.btn_AddKalender.Enabled = true;
                    //frm_Main.getMainForm.ts_btn_Login.Image = Image.FromFile(Environment.CurrentDirectory + "\\icon\\Logout.png");

					

                    // To fetch the Calendar and add it to TreeViewer 
                    try
                    {
                        //TreeNode tn;
                        string query = "select * from tbl_kalender where userId = " + Properties.Settings.Default.userId;
                        DataTable DtKalender = DAL.fetchData(query);

                        frm_Main.getMainForm.fLP_Kalender.Controls.Clear();
                        for (int i = 0; i < DtKalender.Rows.Count; i++)
                        {
							string kalenderColor = DtKalender.Rows[i]["color"].ToString();
							string[] colorArray = kalenderColor.Split(' ');
							red = int.Parse(colorArray[0]);
							green = int.Parse(colorArray[1]);
							blue = int.Parse(colorArray[2]);

							CheckBox cb = new CheckBox();
                            cb.Name = "cb_" + DtKalender.Rows[i]["kalenderName"].ToString();
                            cb.Text = DtKalender.Rows[i]["kalenderName"].ToString();
                            cb.CheckedChanged += Cb_Selected;
							cb.BackColor = Color.FromArgb(red, green, blue);
                            cb.MouseHover += Item_MouseHover;
                            cb.ContextMenuStrip = frm_Main.getMainForm.contextMS_Kalender;
                            frm_Main.getMainForm.fLP_Kalender.Controls.Add(cb);

                        }




                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Password or User Name is wrong");
                }
            }
            else
                MessageBox.Show("Username and Password must be not Empty");
        }

        private void Item_MouseHover(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            //cbName = cb.Name;
            //cbTitel = cb.Text;
        }

        private void Cb_Selected(object sender, EventArgs e)
        {
			CheckBox checkBox = (CheckBox)sender;
			string kalenderName = checkBox.Text;
			string query = "SELECT t.Titel,t.started,t.status,t.ended, k.kalenderName, k.color " +
				"from tbl_termin as t " +
				"inner join tbl_kalender as k " +
				"on t.kalenderId = k.kalender_Id " +
				"where k.kalenderName = '" + kalenderName + "' and k.userid = "+Properties.Settings.Default.userId;


			if (checkBox.Checked == true)
			{
				DtShowTermin = DAL.fetchData(query);

				DtAll.Merge(DtShowTermin);
				frm_Main.getMainForm.dgv_ContentTermin.DataSource = DtAll;
				frm_Main.getMainForm.dgv_ContentTermin.Columns["color"].Visible = false;

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

				frm_Main.getMainForm.dgv_ContentTermin.DataSource = DtAll;

			}

			//To set rows color like calendar color
			try
			{
				for (int i = 0; i < frm_Main.getMainForm.dgv_ContentTermin.Rows.Count; i++)
				{
					string rowColor = frm_Main.getMainForm.dgv_ContentTermin.Rows[i].Cells["color"].Value.ToString();
					string[] colors = rowColor.Split(' ');
					frm_Main.getMainForm.dgv_ContentTermin.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(int.Parse(colors[0]), int.Parse(colors[1]), int.Parse(colors[2]));
				}
			}
			catch (Exception)
			{


			}
		}

        private void btn_Rigester_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtb_UserName.Text) && !string.IsNullOrWhiteSpace(txtb_Password.Text))
            {
                string selectQuery = "select username from tbl_users ";
                DataTable Dt = DAL.fetchData(selectQuery);
                List<string> names = Dt.AsEnumerable().Select(r => r.Field<string>("username")).ToList();


                if (!names.Contains(txtb_UserName.Text))
                {

                    int result;
                    try
                    {

                        string hashPassword = hv.Hash(txtb_Password.Text);
                        string query = "insert into tbl_users(userName,userPass) values ('" + txtb_UserName.Text + "','" + hashPassword + "')";
                        DAL.executing(query, out result);
                        if (result == 1)
                            MessageBox.Show("Rigester successful");
                        else
                            MessageBox.Show("Rigester not successful");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("the Name is Used");
                }
            }
            else
                MessageBox.Show("Username and Password must be not Empty");


        }

        private void btn_CreateDatabase_Click(object sender, EventArgs e)
        {
            //DAL.executing("create Database if not exists db_Kalender; ");
            //Properties.Settings.Default.dbName = "db_Kalender";
            //Properties.Settings.Default.Save();
            //string databaseQuery = "  CREATE TABLE `tbl_users` (" +
            //                       " `user_Id` int(11) NOT NULL AUTO_INCREMENT, " +
            //                       " `userName` varchar(100) NOT NULL, " +
            //                       " `userPass` varchar(255) NOT NULL, " +
            //                       " PRIMARY KEY(`user_Id`) ) " +
            //                       " ENGINE = InnoDB AUTO_INCREMENT = 12 DEFAULT CHARSET = utf8; " +
            //                       " CREATE TABLE `tbl_kalender` ( " +
            //                       " `kalender_Id` int(11) NOT NULL AUTO_INCREMENT, " +
            //                       " `kalenderName` varchar(255) DEFAULT NULL, " +
            //                       " `userId` int(11) DEFAULT NULL, " +
            //                       " `color` varchar(25) DEFAULT NULL, " +
            //                       " PRIMARY KEY(`kalender_Id`), " +
            //                       " KEY `userId` (`userId`), " +
            //                       " CONSTRAINT `tbl_kalender_ibfk_1` FOREIGN KEY(`userId`) REFERENCES `tbl_users` (`user_Id`) " +
            //                       " ON DELETE CASCADE) " +
            //                       " ENGINE = InnoDB AUTO_INCREMENT = 12 DEFAULT CHARSET = utf8; " +
            //                       " " +
            //                       " CREATE TABLE `tbl_shared` ( " +
            //                       " `userId` int(11) DEFAULT NULL, " +
            //                       " `kalenderId` int(11) DEFAULT NULL, " +
            //                       " `Rechte` tinyint(4) NOT NULL, " +
            //                       " KEY `userId` (`userId`), " +
            //                       " KEY `kalenderId` (`kalenderId`), " +
            //                       " CONSTRAINT `tbl_shared_ibfk_1` FOREIGN KEY(`userId`) REFERENCES `tbl_users` (`user_Id`) ON DELETE CASCADE, " +
            //                       "  CONSTRAINT `tbl_shared_ibfk_2` FOREIGN KEY(`kalenderId`) REFERENCES `tbl_kalender` (`kalender_Id`) ON DELETE CASCADE) " +
            //                       " ENGINE = InnoDB DEFAULT CHARSET = utf8;  " +
            //                       " " +
            //                       " CREATE TABLE `tbl_termin` ( " +
            //                       " `termin_Id` int(11) NOT NULL AUTO_INCREMENT, " +
            //                       " `Titel` varchar(255) DEFAULT NULL, " +
            //                       " `started` datetime DEFAULT NULL, " +
            //                       " `ended` datetime DEFAULT NULL, " +
            //                       " `status` tinyint(4) DEFAULT NULL, " +
            //                       " `kalenderId` int(11) DEFAULT NULL, " +
            //                       " PRIMARY KEY(`termin_Id`), " +
            //                       " KEY `kalenderId` (`kalenderId`), " +
            //                       " CONSTRAINT `tbl_termin_ibfk_1` FOREIGN KEY(`kalenderId`) REFERENCES `tbl_kalender` (`kalender_Id`) ON DELETE CASCADE ) " +
            //                       " ENGINE = InnoDB AUTO_INCREMENT = 23 DEFAULT CHARSET = utf8; ";
            //DAL.executing(databaseQuery);
        }
    }
}
