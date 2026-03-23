namespace DVLD_UiLayer
{
    partial class frmManageDetainedLicenses
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
            this.dgvManageDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.cmsManageDetainedLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.releaseDetainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.mtxtFilterSearch = new System.Windows.Forms.MaskedTextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.btnDetainLicense = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddDetainedLicense = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnReleaseDetainedLicense = new System.Windows.Forms.Button();
            this.cbIsReleasedFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageDetainedLicenses)).BeginInit();
            this.cmsManageDetainedLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvManageDetainedLicenses
            // 
            this.dgvManageDetainedLicenses.AllowUserToAddRows = false;
            this.dgvManageDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgvManageDetainedLicenses.AllowUserToOrderColumns = true;
            this.dgvManageDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageDetainedLicenses.ContextMenuStrip = this.cmsManageDetainedLicenses;
            this.dgvManageDetainedLicenses.Location = new System.Drawing.Point(14, 376);
            this.dgvManageDetainedLicenses.Margin = new System.Windows.Forms.Padding(4);
            this.dgvManageDetainedLicenses.Name = "dgvManageDetainedLicenses";
            this.dgvManageDetainedLicenses.ReadOnly = true;
            this.dgvManageDetainedLicenses.RowHeadersWidth = 51;
            this.dgvManageDetainedLicenses.Size = new System.Drawing.Size(1252, 366);
            this.dgvManageDetainedLicenses.TabIndex = 0;
            // 
            // cmsManageDetainedLicenses
            // 
            this.cmsManageDetainedLicenses.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageDetainedLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem,
            this.toolStripMenuItem1,
            this.releaseDetainToolStripMenuItem});
            this.cmsManageDetainedLicenses.Name = "cmsManageDetainedLicenses";
            this.cmsManageDetainedLicenses.Size = new System.Drawing.Size(269, 114);
            this.cmsManageDetainedLicenses.Opening += new System.ComponentModel.CancelEventHandler(this.cmsManageDetainedLicenses_Opening);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.PersonDetails_32;
            this.showPersonDetailsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.License_View_32;
            this.showLicenseDetailsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.PersonLicenseHistory_32;
            this.showPersonLicenseHistoryToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(265, 6);
            // 
            // releaseDetainToolStripMenuItem
            // 
            this.releaseDetainToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.Release_Detained_License_32;
            this.releaseDetainToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.releaseDetainToolStripMenuItem.Name = "releaseDetainToolStripMenuItem";
            this.releaseDetainToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.releaseDetainToolStripMenuItem.Text = "Release Detained License";
            this.releaseDetainToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 337);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter By :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 762);
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
            this.label3.Location = new System.Drawing.Point(457, 279);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(422, 41);
            this.label3.TabIndex = 3;
            this.label3.Text = "Manage Detained Licenses";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(124, 762);
            this.lblRecordsCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(21, 21);
            this.lblRecordsCount.TabIndex = 6;
            this.lblRecordsCount.Text = "0";
            // 
            // mtxtFilterSearch
            // 
            this.mtxtFilterSearch.Location = new System.Drawing.Point(342, 334);
            this.mtxtFilterSearch.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.mtxtFilterSearch.Name = "mtxtFilterSearch";
            this.mtxtFilterSearch.Size = new System.Drawing.Size(247, 24);
            this.mtxtFilterSearch.TabIndex = 7;
            this.mtxtFilterSearch.TextChanged += new System.EventHandler(this.mtxtFilterSearch_TextChanged);
            this.mtxtFilterSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtFilterSearch_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "Is Releasaed",
            "National No",
            "Full Name",
            "Release Application ID"});
            this.cbFilterBy.Location = new System.Drawing.Point(113, 337);
            this.cbFilterBy.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(208, 24);
            this.cbFilterBy.TabIndex = 8;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetainLicense.Image = global::DVLD_UiLayer.ImageResources.Detain_64;
            this.btnDetainLicense.Location = new System.Drawing.Point(1182, 302);
            this.btnDetainLicense.Margin = new System.Windows.Forms.Padding(4);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.Size = new System.Drawing.Size(84, 66);
            this.btnDetainLicense.TabIndex = 11;
            this.btnDetainLicense.UseVisualStyleBackColor = true;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::DVLD_UiLayer.ImageResources.PersonLicenseHistory_321;
            this.button1.Location = new System.Drawing.Point(1771, 181);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 83);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_UiLayer.ImageResources.Detain_512;
            this.pictureBox1.Location = new System.Drawing.Point(524, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(281, 265);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddDetainedLicense
            // 
            this.btnAddDetainedLicense.Location = new System.Drawing.Point(0, 0);
            this.btnAddDetainedLicense.Name = "btnAddDetainedLicense";
            this.btnAddDetainedLicense.Size = new System.Drawing.Size(75, 23);
            this.btnAddDetainedLicense.TabIndex = 12;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Image = global::DVLD_UiLayer.ImageResources.Close_321;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(1133, 753);
            this.btnCloseForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(133, 41);
            this.btnCloseForm.TabIndex = 4;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnReleaseDetainedLicense
            // 
            this.btnReleaseDetainedLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReleaseDetainedLicense.Image = global::DVLD_UiLayer.ImageResources.Release_Detained_License_64;
            this.btnReleaseDetainedLicense.Location = new System.Drawing.Point(1090, 302);
            this.btnReleaseDetainedLicense.Margin = new System.Windows.Forms.Padding(4);
            this.btnReleaseDetainedLicense.Name = "btnReleaseDetainedLicense";
            this.btnReleaseDetainedLicense.Size = new System.Drawing.Size(84, 66);
            this.btnReleaseDetainedLicense.TabIndex = 13;
            this.btnReleaseDetainedLicense.UseVisualStyleBackColor = true;
            this.btnReleaseDetainedLicense.Click += new System.EventHandler(this.btnReleaseDetainedLicense_Click);
            // 
            // cbIsReleasedFilter
            // 
            this.cbIsReleasedFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsReleasedFilter.FormattingEnabled = true;
            this.cbIsReleasedFilter.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsReleasedFilter.Location = new System.Drawing.Point(342, 337);
            this.cbIsReleasedFilter.Name = "cbIsReleasedFilter";
            this.cbIsReleasedFilter.Size = new System.Drawing.Size(121, 24);
            this.cbIsReleasedFilter.TabIndex = 14;
            this.cbIsReleasedFilter.Visible = false;
            this.cbIsReleasedFilter.SelectedIndexChanged += new System.EventHandler(this.cbIsReleasedFilter_SelectedIndexChanged);
            // 
            // frmManageDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 807);
            this.Controls.Add(this.cbIsReleasedFilter);
            this.Controls.Add(this.btnReleaseDetainedLicense);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.mtxtFilterSearch);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.btnAddDetainedLicense);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvManageDetainedLicenses);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManageDetainedLicenses";
            this.Text = "ManageAll";
            this.Load += new System.EventHandler(this.frmManageDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageDetainedLicenses)).EndInit();
            this.cmsManageDetainedLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvManageDetainedLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnAddDetainedLicense;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.MaskedTextBox mtxtFilterSearch;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip cmsManageDetainedLicenses;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDetainLicense;
        private System.Windows.Forms.Button btnReleaseDetainedLicense;
        private System.Windows.Forms.ComboBox cbIsReleasedFilter;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainToolStripMenuItem;
    }
}