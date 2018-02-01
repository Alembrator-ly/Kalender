namespace Kalender.PL
{
    partial class frm_Termin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtb_TerminTitel = new System.Windows.Forms.TextBox();
            this.cmb_Kalender = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_DateStart = new System.Windows.Forms.DateTimePicker();
            this.dtp_DateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtp_TimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dtp_TimeStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtb_TerminDesc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titel:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kalender:";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(61, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(357, 2);
            this.label3.TabIndex = 2;
            // 
            // txtb_TerminTitel
            // 
            this.txtb_TerminTitel.Location = new System.Drawing.Point(132, 72);
            this.txtb_TerminTitel.Name = "txtb_TerminTitel";
            this.txtb_TerminTitel.Size = new System.Drawing.Size(229, 20);
            this.txtb_TerminTitel.TabIndex = 3;
            // 
            // cmb_Kalender
            // 
            this.cmb_Kalender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Kalender.FormattingEnabled = true;
            this.cmb_Kalender.Location = new System.Drawing.Point(132, 111);
            this.cmb_Kalender.Name = "cmb_Kalender";
            this.cmb_Kalender.Size = new System.Drawing.Size(229, 21);
            this.cmb_Kalender.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ende:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Beginn:";
            // 
            // dtp_DateStart
            // 
            this.dtp_DateStart.CustomFormat = "dd.MM.yyyy";
            this.dtp_DateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_DateStart.Location = new System.Drawing.Point(132, 191);
            this.dtp_DateStart.Name = "dtp_DateStart";
            this.dtp_DateStart.Size = new System.Drawing.Size(138, 20);
            this.dtp_DateStart.TabIndex = 7;
            this.dtp_DateStart.Value = new System.DateTime(2018, 2, 1, 0, 0, 0, 0);
            // 
            // dtp_DateEnd
            // 
            this.dtp_DateEnd.CustomFormat = "dd.MM.yyyy";
            this.dtp_DateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_DateEnd.Location = new System.Drawing.Point(132, 227);
            this.dtp_DateEnd.Name = "dtp_DateEnd";
            this.dtp_DateEnd.Size = new System.Drawing.Size(138, 20);
            this.dtp_DateEnd.TabIndex = 8;
            // 
            // dtp_TimeEnd
            // 
            this.dtp_TimeEnd.CustomFormat = "HH:mm";
            this.dtp_TimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_TimeEnd.Location = new System.Drawing.Point(276, 227);
            this.dtp_TimeEnd.Name = "dtp_TimeEnd";
            this.dtp_TimeEnd.ShowUpDown = true;
            this.dtp_TimeEnd.Size = new System.Drawing.Size(76, 20);
            this.dtp_TimeEnd.TabIndex = 10;
            this.dtp_TimeEnd.Value = new System.DateTime(2018, 2, 1, 0, 0, 0, 0);
            // 
            // dtp_TimeStart
            // 
            this.dtp_TimeStart.CustomFormat = "HH:mm";
            this.dtp_TimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_TimeStart.Location = new System.Drawing.Point(276, 190);
            this.dtp_TimeStart.Name = "dtp_TimeStart";
            this.dtp_TimeStart.ShowUpDown = true;
            this.dtp_TimeStart.Size = new System.Drawing.Size(76, 20);
            this.dtp_TimeStart.TabIndex = 9;
            this.dtp_TimeStart.Value = new System.DateTime(2018, 2, 1, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(61, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(357, 2);
            this.label6.TabIndex = 11;
            // 
            // txtb_TerminDesc
            // 
            this.txtb_TerminDesc.Location = new System.Drawing.Point(61, 351);
            this.txtb_TerminDesc.Multiline = true;
            this.txtb_TerminDesc.Name = "txtb_TerminDesc";
            this.txtb_TerminDesc.Size = new System.Drawing.Size(357, 213);
            this.txtb_TerminDesc.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 324);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Beschreibung:";
            // 
            // frm_Termin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 608);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtb_TerminDesc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtp_TimeEnd);
            this.Controls.Add(this.dtp_TimeStart);
            this.Controls.Add(this.dtp_DateEnd);
            this.Controls.Add(this.dtp_DateStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_Kalender);
            this.Controls.Add(this.txtb_TerminTitel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_Termin";
            this.Text = "Neuer Termin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtb_TerminTitel;
        private System.Windows.Forms.ComboBox cmb_Kalender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_DateStart;
        private System.Windows.Forms.DateTimePicker dtp_DateEnd;
        private System.Windows.Forms.DateTimePicker dtp_TimeEnd;
        private System.Windows.Forms.DateTimePicker dtp_TimeStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtb_TerminDesc;
        private System.Windows.Forms.Label label7;
    }
}