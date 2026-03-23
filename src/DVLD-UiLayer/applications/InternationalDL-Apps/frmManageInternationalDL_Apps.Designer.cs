namespace DVLD_UiLayer
{
    partial class frmManageInternationalDL_Apps
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
            this.dgvManageInternationalDL_Apps = new System.Windows.Forms.DataGridView();
            this.cmsManageInternationalDL_Apps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewInternationalDL_AppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLiceseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.cbFindBy = new System.Windows.Forms.ComboBox();
            this.txtFilterSearch = new System.Windows.Forms.TextBox();
            this.cbIsActiveFilter = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddInternationalDL_App = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageInternationalDL_Apps)).BeginInit();
            this.cmsManageInternationalDL_Apps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvManageInternationalDL_Apps
            // 
            this.dgvManageInternationalDL_Apps.AllowUserToAddRows = false;
            this.dgvManageInternationalDL_Apps.AllowUserToDeleteRows = false;
            this.dgvManageInternationalDL_Apps.AllowUserToOrderColumns = true;
            this.dgvManageInternationalDL_Apps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageInternationalDL_Apps.ContextMenuStrip = this.cmsManageInternationalDL_Apps;
            this.dgvManageInternationalDL_Apps.Location = new System.Drawing.Point(16, 304);
            this.dgvManageInternationalDL_Apps.Margin = new System.Windows.Forms.Padding(4);
            this.dgvManageInternationalDL_Apps.Name = "dgvManageInternationalDL_Apps";
            this.dgvManageInternationalDL_Apps.ReadOnly = true;
            this.dgvManageInternationalDL_Apps.RowHeadersWidth = 51;
            this.dgvManageInternationalDL_Apps.Size = new System.Drawing.Size(1435, 366);
            this.dgvManageInternationalDL_Apps.TabIndex = 0;
            // 
            // cmsManageInternationalDL_Apps
            // 
            this.cmsManageInternationalDL_Apps.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageInternationalDL_Apps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showApplicationDetailsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.addNewInternationalDL_AppToolStripMenuItem,
            this.toolStripMenuItem2,
            this.showLicenseToolStripMenuItem,
            this.showPersonLiceseHistoryToolStripMenuItem});
            this.cmsManageInternationalDL_Apps.Name = "cmsManageInternationalDL_Apps";
            this.cmsManageInternationalDL_Apps.Size = new System.Drawing.Size(291, 174);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.Applications_64;
            this.showApplicationDetailsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(287, 6);
            // 
            // addNewInternationalDL_AppToolStripMenuItem
            // 
            this.addNewInternationalDL_AppToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.New_Application_64;
            this.addNewInternationalDL_AppToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addNewInternationalDL_AppToolStripMenuItem.Name = "addNewInternationalDL_AppToolStripMenuItem";
            this.addNewInternationalDL_AppToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
            this.addNewInternationalDL_AppToolStripMenuItem.Text = "Add New _NewInternationalLicnese";
            this.addNewInternationalDL_AppToolStripMenuItem.Click += new System.EventHandler(this.AddNewInternationalDL_App_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(287, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.License_View_32;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showPersonLiceseHistoryToolStripMenuItem
            // 
            this.showPersonLiceseHistoryToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.PersonLicenseHistory_32;
            this.showPersonLiceseHistoryToolStripMenuItem.Name = "showPersonLiceseHistoryToolStripMenuItem";
            this.showPersonLiceseHistoryToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
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
            this.label1.Size = new System.Drawing.Size(85, 21);
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
            this.label3.Size = new System.Drawing.Size(636, 41);
            this.label3.TabIndex = 3;
            this.label3.Text = "International Driving Licese Applications";
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
            // cbFilterBy
            // 
            this.cbFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFindBy.FormattingEnabled = true;
            this.cbFindBy.Items.AddRange(new object[] {
            "None",
            "InternationalDL_App ID",
            "Driver ID",
            "Local License ID",
            "Is Active"});
            this.cbFindBy.Location = new System.Drawing.Point(124, 265);
            this.cbFindBy.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbFindBy.Name = "cbFilterBy";
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
            // cbIsActiveFilter
            // 
            this.cbIsActiveFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActiveFilter.FormattingEnabled = true;
            this.cbIsActiveFilter.Items.AddRange(new object[] {
            "All",
            "Active",
            "Not Active"});
            this.cbIsActiveFilter.Location = new System.Drawing.Point(355, 265);
            this.cbIsActiveFilter.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbIsActiveFilter.Name = "cbIsActiveFilter";
            this.cbIsActiveFilter.Size = new System.Drawing.Size(121, 24);
            this.cbIsActiveFilter.TabIndex = 11;
            this.cbIsActiveFilter.Visible = false;
            this.cbIsActiveFilter.SelectedIndexChanged += new System.EventHandler(this.cbIsActiveFilter_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_UiLayer.ImageResources.International_32;
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
            // btnAddInternationalDL_App
            // 
            this.btnAddInternationalDL_App.AutoSize = true;
            this.btnAddInternationalDL_App.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddInternationalDL_App.Image = global::DVLD_UiLayer.ImageResources.New_Application_64;
            this.btnAddInternationalDL_App.Location = new System.Drawing.Point(1367, 208);
            this.btnAddInternationalDL_App.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddInternationalDL_App.Name = "btnAddInternationalDL_App";
            this.btnAddInternationalDL_App.Size = new System.Drawing.Size(84, 89);
            this.btnAddInternationalDL_App.TabIndex = 5;
            this.btnAddInternationalDL_App.UseVisualStyleBackColor = true;
            this.btnAddInternationalDL_App.Click += new System.EventHandler(this.AddNewInternationalDL_App_Click);
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
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.PersonDetails_32;
            this.showPersonDetailsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(290, 26);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // frmManageInternationalDL_Apps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 734);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cbIsActiveFilter);
            this.Controls.Add(this.txtFilterSearch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbFindBy);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.btnAddInternationalDL_App);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvManageInternationalDL_Apps);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManageInternationalDL_Apps";
            this.Text = "ManageInternationalDL_Apps";
            this.Load += new System.EventHandler(this.frmManageInternationalDL_Apps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageInternationalDL_Apps)).EndInit();
            this.cmsManageInternationalDL_Apps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvManageInternationalDL_Apps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnAddInternationalDL_App;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.ComboBox cbFindBy;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip cmsManageInternationalDL_Apps;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewInternationalDL_AppToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.TextBox txtFilterSearch;
        private System.Windows.Forms.ComboBox cbIsActiveFilter;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLiceseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
    }
}