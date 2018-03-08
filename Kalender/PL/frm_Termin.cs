﻿using Kalender.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalender.PL
{
    public partial class frm_Termin : Form
    {
        DataAccessLayer DAL = new DataAccessLayer();
        DataTable Dt;
        public frm_Termin()
        {
            InitializeComponent();
            dtp_TimeStart.Value = DateTime.Now;
            dtp_TimeEnd.Value = DateTime.Now.AddHours(2);
            dtp_DateStart.Value = DateTime.Now;
            dtp_DateEnd.Value = DateTime.Now.AddDays(2);

        }

        private void btn_CancelTermin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Termin_Load(object sender, EventArgs e)
        {
            // to fetch the Calendars and show it in calendar combobox
            Dt = DAL.fetchData("select * from tbl_kalender where userId=" + Properties.Settings.Default.userId + "");
            foreach (DataRow row in Dt.Rows)
            {
                cmb_Kalender.Items.Add(row["kalendername"]);
            }
        }

        private void btn_AddTermin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtb_TerminTitel.Text)&&!string.IsNullOrEmpty(cmb_Kalender.Text))
            {
                // To save the value in variable and passed it in query
                int result;
                string titel = txtb_TerminTitel.Text;
                string dateStarted = dtp_DateStart.Value.ToString("yyyy-MM-dd");
                string timestarted = dtp_TimeStart.Value.ToString("HH:mm:ss");
                string dateEnded = dtp_DateEnd.Value.ToString("yyyy-MM-dd");
                string timeEnded = dtp_TimeEnd.Value.ToString("HH:mm:ss");
                DataRow kalenderRow = Dt.AsEnumerable().SingleOrDefault(r => r.Field<string>("kalendername") == cmb_Kalender.Text);
                int kalenderId = int.Parse(kalenderRow[0].ToString());

                // to insert the date in database
                string query = "insert into tbl_termin (`titel`,`started`,`ended`,`status`,`kalenderId`) " +
                    "values('" + titel + "','" + dateStarted + " " + timestarted + "','" + dateEnded + " " + timeEnded + "',1," + kalenderId + ")";
                try
                {
                    DAL.executing(query, out result);
                    if (result == 1)
                    {
                        MessageBox.Show("Neue Termin hizugefügt");
                    }
                    else
                    {
                        MessageBox.Show("Fehlergeschlagen");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("Der Termintitel und Kalender muss nicht leer sein");
            }
        }
    }
}
