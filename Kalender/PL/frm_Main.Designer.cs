namespace Kalender
{
    partial class frm_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.tabL_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tabC_Main = new System.Windows.Forms.TabControl();
            this.tabP_Kalender = new System.Windows.Forms.TabPage();
            this.tabL_Kalender = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.fLP_Kalender = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.txtb_KalenderName = new System.Windows.Forms.TextBox();
            this.btn_AddKalender = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_ContentTermin = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.ts_Main = new System.Windows.Forms.ToolStrip();
            this.ts_btn_Termin = new System.Windows.Forms.ToolStripButton();
            this.ts_btn_Login = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_ConnectionState = new System.Windows.Forms.Label();
            this.lbl_OnOff = new System.Windows.Forms.Label();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.contextMS_User = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMSItem_UserLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMS_Kalender = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMSItem_AddKalender = new System.Windows.Forms.ToolStripMenuItem();
            this.kalenderLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kalenderFarbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gfhfdhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sdthgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erthtrhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ertherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thrtehToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabL_Main.SuspendLayout();
            this.tabC_Main.SuspendLayout();
            this.tabP_Kalender.SuspendLayout();
            this.tabL_Kalender.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ContentTermin)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.ts_Main.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMS_User.SuspendLayout();
            this.contextMS_Kalender.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabL_Main
            // 
            this.tabL_Main.ColumnCount = 1;
            this.tabL_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabL_Main.Controls.Add(this.tabC_Main, 0, 0);
            this.tabL_Main.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tabL_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabL_Main.Location = new System.Drawing.Point(0, 0);
            this.tabL_Main.Name = "tabL_Main";
            this.tabL_Main.RowCount = 2;
            this.tabL_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabL_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tabL_Main.Size = new System.Drawing.Size(1201, 784);
            this.tabL_Main.TabIndex = 0;
            // 
            // tabC_Main
            // 
            this.tabC_Main.Controls.Add(this.tabP_Kalender);
            this.tabC_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabC_Main.Location = new System.Drawing.Point(3, 3);
            this.tabC_Main.Name = "tabC_Main";
            this.tabC_Main.SelectedIndex = 0;
            this.tabC_Main.Size = new System.Drawing.Size(1195, 752);
            this.tabC_Main.TabIndex = 0;
            // 
            // tabP_Kalender
            // 
            this.tabP_Kalender.Controls.Add(this.tabL_Kalender);
            this.tabP_Kalender.Location = new System.Drawing.Point(4, 22);
            this.tabP_Kalender.Name = "tabP_Kalender";
            this.tabP_Kalender.Padding = new System.Windows.Forms.Padding(3);
            this.tabP_Kalender.Size = new System.Drawing.Size(1187, 726);
            this.tabP_Kalender.TabIndex = 0;
            this.tabP_Kalender.Text = "Kalender";
            this.tabP_Kalender.UseVisualStyleBackColor = true;
            // 
            // tabL_Kalender
            // 
            this.tabL_Kalender.ColumnCount = 1;
            this.tabL_Kalender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabL_Kalender.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tabL_Kalender.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tabL_Kalender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabL_Kalender.Location = new System.Drawing.Point(3, 3);
            this.tabL_Kalender.Name = "tabL_Kalender";
            this.tabL_Kalender.RowCount = 2;
            this.tabL_Kalender.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tabL_Kalender.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabL_Kalender.Size = new System.Drawing.Size(1181, 720);
            this.tabL_Kalender.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 201F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 32);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1175, 685);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.monthCalendar1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.fLP_Kalender, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 179F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 414F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(195, 679);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthCalendar1.Location = new System.Drawing.Point(9, 9);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // fLP_Kalender
            // 
            this.fLP_Kalender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fLP_Kalender.Location = new System.Drawing.Point(3, 247);
            this.fLP_Kalender.Name = "fLP_Kalender";
            this.fLP_Kalender.Size = new System.Drawing.Size(189, 429);
            this.fLP_Kalender.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kalender";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel6.Controls.Add(this.txtb_KalenderName, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btn_AddKalender, 2, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 209);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(184, 32);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // txtb_KalenderName
            // 
            this.txtb_KalenderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtb_KalenderName.Location = new System.Drawing.Point(3, 6);
            this.txtb_KalenderName.Name = "txtb_KalenderName";
            this.txtb_KalenderName.Size = new System.Drawing.Size(106, 20);
            this.txtb_KalenderName.TabIndex = 0;
            // 
            // btn_AddKalender
            // 
            this.btn_AddKalender.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddKalender.Image")));
            this.btn_AddKalender.Location = new System.Drawing.Point(145, 3);
            this.btn_AddKalender.Name = "btn_AddKalender";
            this.btn_AddKalender.Size = new System.Drawing.Size(36, 26);
            this.btn_AddKalender.TabIndex = 1;
            this.btn_AddKalender.UseVisualStyleBackColor = true;
            this.btn_AddKalender.Click += new System.EventHandler(this.btn_AddKalender_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(204, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(968, 679);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gray;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 33);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_ContentTermin);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.PapayaWhip;
            this.splitContainer1.Size = new System.Drawing.Size(962, 643);
            this.splitContainer1.SplitterDistance = 531;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgv_ContentTermin
            // 
            this.dgv_ContentTermin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ContentTermin.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ContentTermin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ContentTermin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ContentTermin.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_ContentTermin.Location = new System.Drawing.Point(0, 0);
            this.dgv_ContentTermin.Name = "dgv_ContentTermin";
            this.dgv_ContentTermin.RowHeadersVisible = false;
            this.dgv_ContentTermin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ContentTermin.Size = new System.Drawing.Size(962, 531);
            this.dgv_ContentTermin.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel5.Controls.Add(this.ts_Main, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1175, 23);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // ts_Main
            // 
            this.ts_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_btn_Termin,
            this.ts_btn_Login});
            this.ts_Main.Location = new System.Drawing.Point(0, 0);
            this.ts_Main.Name = "ts_Main";
            this.ts_Main.Size = new System.Drawing.Size(990, 23);
            this.ts_Main.TabIndex = 2;
            this.ts_Main.Text = "toolStrip1";
            // 
            // ts_btn_Termin
            // 
            this.ts_btn_Termin.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_Termin.Image")));
            this.ts_btn_Termin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_btn_Termin.Name = "ts_btn_Termin";
            this.ts_btn_Termin.Size = new System.Drawing.Size(64, 20);
            this.ts_btn_Termin.Text = "Termin";
            this.ts_btn_Termin.Click += new System.EventHandler(this.ts_btn_Termin_Click);
            // 
            // ts_btn_Login
            // 
            this.ts_btn_Login.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_Login.Image")));
            this.ts_btn_Login.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_btn_Login.Name = "ts_btn_Login";
            this.ts_btn_Login.Size = new System.Drawing.Size(57, 20);
            this.ts_btn_Login.Text = "Login";
            this.ts_btn_Login.Click += new System.EventHandler(this.ts_btn_Login_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 930F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_ConnectionState, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_OnOff, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_UserName, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 761);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1195, 20);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lbl_ConnectionState
            // 
            this.lbl_ConnectionState.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_ConnectionState.AutoSize = true;
            this.lbl_ConnectionState.Location = new System.Drawing.Point(3, 3);
            this.lbl_ConnectionState.Name = "lbl_ConnectionState";
            this.lbl_ConnectionState.Size = new System.Drawing.Size(92, 13);
            this.lbl_ConnectionState.TabIndex = 2;
            this.lbl_ConnectionState.Text = "Connection State:";
            // 
            // lbl_OnOff
            // 
            this.lbl_OnOff.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_OnOff.AutoSize = true;
            this.lbl_OnOff.Location = new System.Drawing.Point(108, 3);
            this.lbl_OnOff.Name = "lbl_OnOff";
            this.lbl_OnOff.Size = new System.Drawing.Size(13, 13);
            this.lbl_OnOff.TabIndex = 3;
            this.lbl_OnOff.Text = "  ";
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_UserName.AutoSize = true;
            this.lbl_UserName.ContextMenuStrip = this.contextMS_User;
            this.lbl_UserName.Location = new System.Drawing.Point(1140, 3);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(52, 13);
            this.lbl_UserName.TabIndex = 4;
            this.lbl_UserName.Text = "Benutzer:";
            // 
            // contextMS_User
            // 
            this.contextMS_User.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMSItem_UserLogout});
            this.contextMS_User.Name = "contextMS_User";
            this.contextMS_User.Size = new System.Drawing.Size(179, 26);
            // 
            // contextMSItem_UserLogout
            // 
            this.contextMSItem_UserLogout.Image = ((System.Drawing.Image)(resources.GetObject("contextMSItem_UserLogout.Image")));
            this.contextMSItem_UserLogout.Name = "contextMSItem_UserLogout";
            this.contextMSItem_UserLogout.Size = new System.Drawing.Size(178, 22);
            this.contextMSItem_UserLogout.Text = "Benutzer Abmelden";
            this.contextMSItem_UserLogout.Click += new System.EventHandler(this.contextMSItem_UserLogout_Click);
            // 
            // contextMS_Kalender
            // 
            this.contextMS_Kalender.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMSItem_AddKalender,
            this.kalenderLöschenToolStripMenuItem,
            this.kalenderFarbeToolStripMenuItem});
            this.contextMS_Kalender.Name = "contextMenuStrip1";
            this.contextMS_Kalender.Size = new System.Drawing.Size(184, 70);
            // 
            // contextMSItem_AddKalender
            // 
            this.contextMSItem_AddKalender.Name = "contextMSItem_AddKalender";
            this.contextMSItem_AddKalender.Size = new System.Drawing.Size(183, 22);
            this.contextMSItem_AddKalender.Text = "Kalender hinzufügen";
            // 
            // kalenderLöschenToolStripMenuItem
            // 
            this.kalenderLöschenToolStripMenuItem.Name = "kalenderLöschenToolStripMenuItem";
            this.kalenderLöschenToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.kalenderLöschenToolStripMenuItem.Text = "Kalender Löschen";
            this.kalenderLöschenToolStripMenuItem.Click += new System.EventHandler(this.kalenderLöschenToolStripMenuItem_Click);
            // 
            // kalenderFarbeToolStripMenuItem
            // 
            this.kalenderFarbeToolStripMenuItem.Name = "kalenderFarbeToolStripMenuItem";
            this.kalenderFarbeToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.kalenderFarbeToolStripMenuItem.Text = "Kalender Farbe";
            this.kalenderFarbeToolStripMenuItem.Click += new System.EventHandler(this.kalenderFarbeToolStripMenuItem_Click);
            // 
            // gfhfdhToolStripMenuItem
            // 
            this.gfhfdhToolStripMenuItem.Name = "gfhfdhToolStripMenuItem";
            this.gfhfdhToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // sdthgToolStripMenuItem
            // 
            this.sdthgToolStripMenuItem.Name = "sdthgToolStripMenuItem";
            this.sdthgToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // erthtrhToolStripMenuItem
            // 
            this.erthtrhToolStripMenuItem.Name = "erthtrhToolStripMenuItem";
            this.erthtrhToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // ertherToolStripMenuItem
            // 
            this.ertherToolStripMenuItem.Name = "ertherToolStripMenuItem";
            this.ertherToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // thrtehToolStripMenuItem
            // 
            this.thrtehToolStripMenuItem.Name = "thrtehToolStripMenuItem";
            this.thrtehToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 784);
            this.Controls.Add(this.tabL_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Main";
            this.Text = "Kalender";
            this.tabL_Main.ResumeLayout(false);
            this.tabC_Main.ResumeLayout(false);
            this.tabP_Kalender.ResumeLayout(false);
            this.tabL_Kalender.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ContentTermin)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ts_Main.ResumeLayout(false);
            this.ts_Main.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMS_User.ResumeLayout(false);
            this.contextMS_Kalender.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tabL_Main;
        private System.Windows.Forms.TabControl tabC_Main;
        private System.Windows.Forms.TabPage tabP_Kalender;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_ConnectionState;
        private System.Windows.Forms.Label lbl_OnOff;
        private System.Windows.Forms.TableLayoutPanel tabL_Kalender;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem gfhfdhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sdthgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erthtrhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ertherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thrtehToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.ToolStrip ts_Main;
        public System.Windows.Forms.ToolStripButton ts_btn_Termin;
        public System.Windows.Forms.ToolStripButton ts_btn_Login;
        private System.Windows.Forms.ToolStripMenuItem contextMSItem_AddKalender;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TextBox txtb_KalenderName;
        private System.Windows.Forms.Button btn_AddKalender;
        private System.Windows.Forms.ContextMenuStrip contextMS_User;
        private System.Windows.Forms.ToolStripMenuItem contextMSItem_UserLogout;
        private System.Windows.Forms.ToolStripMenuItem kalenderLöschenToolStripMenuItem;
        public System.Windows.Forms.Label lbl_UserName;
        public System.Windows.Forms.FlowLayoutPanel fLP_Kalender;
        private System.Windows.Forms.ToolStripMenuItem kalenderFarbeToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip contextMS_Kalender;
        public System.Windows.Forms.DataGridView dgv_ContentTermin;
    }
}

