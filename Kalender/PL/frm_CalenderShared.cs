using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kalender.BL;
using Kalender.DAL;

namespace Kalender.PL
{
    public partial class frm_CalenderShared : Form
    {
		functions cls_func = new functions();
		DataAccessLayer DAL = new DataAccessLayer();
		List<string> listIdUsersToShare = new List<string>();
		int KalenderId;
		public frm_CalenderShared()
        {
            InitializeComponent();
        }

		private void frm_CalenderShared_Load(object sender, EventArgs e)
		{
			//To Generate users checkbox to share Calender
			string query = "select * from tbl_users where user_id <> "+Properties.Settings.Default.userId;
			DataTable Dt = DAL.fetchData(query);
			foreach (DataRow row in Dt.Rows )
			{
				CheckBox cb = new CheckBox();
				cb.Text = row[1].ToString();
				cb.Name = "cb_" + cb.Text+"_"+row[0];
				cb.Click += CalendarShared_Cb_Click;
				fLP_UsersShared.Controls.Add(cb);
			}
		}

		private void CalendarShared_Cb_Click(object sender, EventArgs e)
		{
			// choose the user_id to shared the Calendar
			CheckBox checkBox = (CheckBox)sender;
			if (checkBox.CheckState == CheckState.Checked)
			{
				string name = checkBox.Name;
				string[] splitedName = name.Split('_');
				listIdUsersToShare.Add(splitedName[splitedName.Length - 1]);
			}


		}

		private void btn_Save_Click(object sender, EventArgs e)
		{
			KalenderId = frm_Main.getMainForm.KalenderId;
			for (int i = 0; i < listIdUsersToShare.Count; i++)
			{
				string query = "insert into tbl_Shared (userId, kalenderId, Rechte) " +
					"values ("+listIdUsersToShare[i]+","+KalenderId+",0)";
				DAL.executing(query);

			}
		}
	}
}
