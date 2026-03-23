namespace DVLD_UiLayer
{
    partial class frmManageLocalDL_Apps
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
            this.dgvManageLocalDL_Apps = new System.Windows.Forms.DataGridView();
            this.cmsManageLocalDL_Apps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewLocalDL_AppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleTestsMenue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmScheduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmScheduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmScheduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLiceseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.cbFindBy = new System.Windows.Forms.ComboBox();
            this.txtFilterSearch = new System.Windows.Forms.TextBox();
            this.cbStatusFilter = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddLocalDL_App = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageLocalDL_Apps)).BeginInit();
            this.cmsManageLocalDL_Apps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvManageLocalDL_Apps
            // 
            this.dgvManageLocalDL_Apps.AllowUserToAddRows = false;
            this.dgvManageLocalDL_Apps.AllowUserToDeleteRows = false;
            this.dgvManageLocalDL_Apps.AllowUserToOrderColumns = true;
            this.dgvManageLocalDL_Apps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageLocalDL_Apps.ContextMenuStrip = this.cmsManageLocalDL_Apps;
            this.dgvManageLocalDL_Apps.Location = new System.Drawing.Point(16, 304);
            this.dgvManageLocalDL_Apps.Margin = new System.Windows.Forms.Padding(4);
            this.dgvManageLocalDL_Apps.Name = "dgvManageLocalDL_Apps";
            this.dgvManageLocalDL_Apps.ReadOnly = true;
            this.dgvManageLocalDL_Apps.RowHeadersWidth = 51;
            this.dgvManageLocalDL_Apps.Size = new System.Drawing.Size(1435, 366);
            this.dgvManageLocalDL_Apps.TabIndex = 0;
            // 
            // cmsManageLocalDL_Apps
            // 
            this.cmsManageLocalDL_Apps.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageLocalDL_Apps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.addNewLocalDL_AppToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem2,
            this.cancelApplicationToolStripMenuItem,
            this.scheduleTestsMenue,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonLiceseHistoryToolStripMenuItem});
            this.cmsManageLocalDL_Apps.Name = "cmsManageLocalDL_Apps";
            this.cmsManageLocalDL_Apps.Size = new System.Drawing.Size(363, 250);
            this.cmsManageLocalDL_Apps.Opening += new System.ComponentModel.CancelEventHandler(this.cmsManageLocalDL_Apps_Opening);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.PersonDetails_32;
            this.showDetailsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(362, 26);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(359, 6);
            // 
            // addNewLocalDL_AppToolStripMenuItem
            // 
            this.addNewLocalDL_AppToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.AddAppointment_32;
            this.addNewLocalDL_AppToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addNewLocalDL_AppToolStripMenuItem.Name = "addNewLocalDL_AppToolStripMenuItem";
            this.addNewLocalDL_AppToolStripMenuItem.Size = new System.Drawing.Size(362, 26);
            this.addNewLocalDL_AppToolStripMenuItem.Text = "Add New _LocalDrivingLicenseApplication";
            this.addNewLocalDL_AppToolStripMenuItem.Click += new System.EventHandler(this.AddNewLocalDL_App_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.edit_32;
            this.editToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(362, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.Delete_32_2;
            this.deleteToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(362, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(359, 6);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.Delete_32;
            this.cancelApplicationToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(362, 26);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // scheduleTestsMenue
            // 
            this.scheduleTestsMenue.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmScheduleVisionTest,
            this.tsmScheduleWrittenTest,
            this.tsmScheduleStreetTest});
            this.scheduleTestsMenue.Image = global::DVLD_UiLayer.ImageResources.Schedule_Test_32;
            this.scheduleTestsMenue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scheduleTestsMenue.Name = "scheduleTestsMenue";
            this.scheduleTestsMenue.Size = new System.Drawing.Size(362, 26);
            this.scheduleTestsMenue.Text = "Schedule Tests";
            // 
            // tsmScheduleVisionTest
            // 
            this.tsmScheduleVisionTest.Image = global::DVLD_UiLayer.ImageResources.Vision_Test_32;
            this.tsmScheduleVisionTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmScheduleVisionTest.Name = "tsmScheduleVisionTest";
            this.tsmScheduleVisionTest.Size = new System.Drawing.Size(235, 26);
            this.tsmScheduleVisionTest.Tag = "";
            this.tsmScheduleVisionTest.Text = "Schedule Vision Test";
            this.tsmScheduleVisionTest.Click += new System.EventHandler(this.ScheduleTest_Click);
            // 
            // tsmScheduleWrittenTest
            // 
            this.tsmScheduleWrittenTest.Image = global::DVLD_UiLayer.ImageResources.Written_Test_32;
            this.tsmScheduleWrittenTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmScheduleWrittenTest.Name = "tsmScheduleWrittenTest";
            this.tsmScheduleWrittenTest.Size = new System.Drawing.Size(235, 26);
            this.tsmScheduleWrittenTest.Tag = "";
            this.tsmScheduleWrittenTest.Text = "Schedule Written Test";
            this.tsmScheduleWrittenTest.Click += new System.EventHandler(this.ScheduleTest_Click);
            // 
            // tsmScheduleStreetTest
            // 
            this.tsmScheduleStreetTest.Image = global::DVLD_UiLayer.ImageResources.Street_Test_32;
            this.tsmScheduleStreetTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmScheduleStreetTest.Name = "tsmScheduleStreetTest";
            this.tsmScheduleStreetTest.Size = new System.Drawing.Size(235, 26);
            this.tsmScheduleStreetTest.Tag = "";
            this.tsmScheduleStreetTest.Text = "Schedule Street Test";
            this.tsmScheduleStreetTest.Click += new System.EventHandler(this.ScheduleTest_Click);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.IssueDrivingLicense_32;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(362, 26);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = " Issue Driving License (First Time)";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.issueDrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.License_View_32;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(362, 26);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showPersonLiceseHistoryToolStripMenuItem
            // 
            this.showPersonLiceseHistoryToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.PersonLicenseHistory_32;
            this.showPersonLiceseHistoryToolStripMenuItem.Name = "showPersonLiceseHistoryToolStripMenuItem";
            this.showPersonLiceseHistoryToolStripMenuItem.Size = new System.Drawing.Size(362, 26);
            this.showPersonLiceseHistoryToolStripMenuItem.Text = "Show Person Licese History";
            this.showPersonLiceseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLiceseHistoryToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 265);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter by :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 690);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "# Records : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(457, 202);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(524, 41);
            this.label3.TabIndex = 3;
            this.label3.Text = "Local Driving Licese Applications";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(140, 690);
            this.lblRecordsCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(21, 21);
            this.lblRecordsCount.TabIndex = 6;
            this.lblRecordsCount.Text = "0";
            // 
            // cbFindBy
            // 
            this.cbFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFindBy.FormattingEnabled = true;
            this.cbFindBy.Items.AddRange(new object[] {
            "None",
            "LocalDL_AppID",
            "NationalNo",
            "FullName",
            "Status"});
            this.cbFindBy.Location = new System.Drawing.Point(124, 265);
            this.cbFindBy.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbFindBy.Name = "cbFindBy";
            this.cbFindBy.Size = new System.Drawing.Size(208, 24);
            this.cbFindBy.TabIndex = 8;
            this.cbFindBy.SelectedIndexChanged += new System.EventHandler(this.cbFindBy_SelectedIndexChanged);
            // 
            // txtFilterSearch
            // 
            this.txtFilterSearch.Location = new System.Drawing.Point(355, 266);
            this.txtFilterSearch.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtFilterSearch.Name = "txtFilterSearch";
            this.txtFilterSearch.Size = new System.Drawing.Size(275, 24);
            this.txtFilterSearch.TabIndex = 10;
            this.txtFilterSearch.TextChanged += new System.EventHandler(this.txtFilterSearch_TextChanged);
            this.txtFilterSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterSearch_KeyPress);
            // 
            // cbStatusFilter
            // 
            this.cbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusFilter.FormattingEnabled = true;
            this.cbStatusFilter.Items.AddRange(new object[] {
            "All",
            "New",
            "Cancelled",
            "Completed"});
            this.cbStatusFilter.Location = new System.Drawing.Point(355, 265);
            this.cbStatusFilter.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbStatusFilter.Name = "cbStatusFilter";
            this.cbStatusFilter.Size = new System.Drawing.Size(121, 24);
            this.cbStatusFilter.TabIndex = 11;
            this.cbStatusFilter.Visible = false;
            this.cbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cbStatusFilter_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_UiLayer.ImageResources.Local_32;
            this.pictureBox2.Location = new System.Drawing.Point(804, 85);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(44, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_UiLayer.ImageResources.Manage_Applications_64;
            this.pictureBox1.Location = new System.Drawing.Point(630, 21);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 176);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddLocalDL_App
            // 
            this.btnAddLocalDL_App.AutoSize = true;
            this.btnAddLocalDL_App.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLocalDL_App.Image = global::DVLD_UiLayer.ImageResources.New_Application_64;
            this.btnAddLocalDL_App.Location = new System.Drawing.Point(1367, 208);
            this.btnAddLocalDL_App.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddLocalDL_App.Name = "btnAddLocalDL_App";
            this.btnAddLocalDL_App.Size = new System.Drawing.Size(84, 89);
            this.btnAddLocalDL_App.TabIndex = 5;
            this.btnAddLocalDL_App.UseVisualStyleBackColor = true;
            this.btnAddLocalDL_App.Click += new System.EventHandler(this.AddNewLocalDL_App_Click);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Image = global::DVLD_UiLayer.ImageResources.Close_321;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(1318, 678);
            this.btnCloseForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(133, 41);
            this.btnCloseForm.TabIndex = 4;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // frmManageLocalDL_Apps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 734);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cbStatusFilter);
            this.Controls.Add(this.txtFilterSearch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbFindBy);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.btnAddLocalDL_App);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvManageLocalDL_Apps);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManageLocalDL_Apps";
            this.Text = "ManageLocalDL_Apps";
            this.Load += new System.EventHandler(this.frmManageLocalDL_Apps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageLocalDL_Apps)).EndInit();
            this.cmsManageLocalDL_Apps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvManageLocalDL_Apps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnAddLocalDL_App;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.ComboBox cbFindBy;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip cmsManageLocalDL_Apps;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewLocalDL_AppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.TextBox txtFilterSearch;
        private System.Windows.Forms.ComboBox cbStatusFilter;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLiceseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestsMenue;
        private System.Windows.Forms.ToolStripMenuItem tsmScheduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem tsmScheduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem tsmScheduleStreetTest;
    }
}