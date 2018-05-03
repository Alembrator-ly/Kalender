using Kalender.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalender.BL
{

    class functions
    {
		// TODO: the code to genrate the checkbox 
		DataAccessLayer DAL = new DataAccessLayer();
        string cbName;
        string cbTitel;


		public functions()
		{

		}
		public functions(string _cbName, string _cbTitel)
        {
            cbName = _cbName;
            cbTitel = _cbTitel;
        }



        /// <summary>
        /// TO Generate the CheckBox for Calendar
        /// </summary>
        /// <param name="red">color als integar</param>
        /// <param name="green">color als integar</param>
        /// <param name="blue">color als integar</param>
        /// <param name="_cbName">the Name of the CheckBox to used in a Code</param>
        /// <param name="_cbTitel">the Name of the CheckBox to used in a Code</param>
        public void cmbGenrator(int red,int green,int blue,string _cbName, string _cbTitel)
        {
            cbName = _cbName;
            cbTitel = _cbTitel;
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

        // Event when thr Mouse on the CheckBox
        private void Item_MouseHover(object sender, EventArgs e)
        {

            CheckBox cb = (CheckBox)sender;
            cbName = cb.Name;
            cbTitel = cb.Text;

        }
        // Event when the CheckBox Selected is
        private void Cb_Selected(object sender, EventArgs e)
        {
            DataTable DtShowTermin = new DataTable();
            DataTable DtAll = new DataTable();
            CheckBox checkBox = (CheckBox)sender;
            string kalenderName = checkBox.Text;
            string query = "SELECT t.Titel,t.started,t.status,t.ended, k.kalenderName " +
                "from tbl_termin as t " +
                "inner join tbl_kalender as k " +
                "on t.kalenderId = k.kalender_Id " +
                "where k.kalenderName = '" + kalenderName + "'";


            if (checkBox.Checked == true)
            {
                DtShowTermin = DAL.fetchData(query);

                DtAll.Merge(DtShowTermin);
                frm_Main.getMainForm.dgv_ContentTermin.DataSource = DtAll;



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

                frm_Main.getMainForm.dgv_ContentTermin.DataSource = DtAll;
            }
        }
    }
}
