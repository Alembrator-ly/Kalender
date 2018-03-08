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
                    frm_Main.getMainForm.ts_btn_Login.Image = Image.FromFile(Environment.CurrentDirectory + "\\icon\\Logout.png");


                    // To fetch the Calendar and add it to TreeViewer 
                    try
                    {
                        //TreeNode tn;
                        string query = "select * from tbl_kalender where userId = " + Properties.Settings.Default.userId;
                        DataTable DtKalender = DAL.fetchData(query);

                        frm_Main.getMainForm.fLP_Kalender.Controls.Clear();
                        for (int i = 1; i < Dt.Rows.Count; i++)
                        {

                            CheckBox cb = new CheckBox();
                            cb.Name = "cb_" + Dt.Rows[i]["kalenderName"].ToString();
                            cb.Text = Dt.Rows[i]["kalenderName"].ToString();
                            cb.CheckedChanged += Cb_Selected;
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
            if (checkBox.Checked == true)
            {
                MessageBox.Show(checkBox.Name + "is checked");
            }
            else
            {
                MessageBox.Show(checkBox.Name + "is unchecked");
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


    }
}
