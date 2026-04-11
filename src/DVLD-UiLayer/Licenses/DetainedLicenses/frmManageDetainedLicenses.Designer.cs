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
            components = new System.ComponentModel.Container();
            dgvManageDetainedLicenses = new DataGridView();
            cmsManageDetainedLicenses = new ContextMenuStrip(components);
            showPersonDetailsToolStripMenuItem = new ToolStripMenuItem();
            showLicenseDetailsToolStripMenuItem = new ToolStripMenuItem();
            showPersonLicenseHistoryToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            releaseDetainToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblRecordsCount = new Label();
            mtxtFilterSearch = new MaskedTextBox();
            cbFilterBy = new ComboBox();
            btnDetainLicense = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            btnCloseForm = new Button();
            btnReleaseDetainedLicense = new Button();
            cbIsReleasedFilter = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvManageDetainedLicenses).BeginInit();
            cmsManageDetainedLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvManageDetainedLicenses
            // 
            dgvManageDetainedLicenses.AllowUserToAddRows = false;
            dgvManageDetainedLicenses.AllowUserToDeleteRows = false;
            dgvManageDetainedLicenses.AllowUserToOrderColumns = true;
            dgvManageDetainedLicenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvManageDetainedLicenses.ContextMenuStrip = cmsManageDetainedLicenses;
            dgvManageDetainedLicenses.Location = new Point(14, 352);
            dgvManageDetainedLicenses.Margin = new Padding(4);
            dgvManageDetainedLicenses.Name = "dgvManageDetainedLicenses";
            dgvManageDetainedLicenses.ReadOnly = true;
            dgvManageDetainedLicenses.RowHeadersWidth = 51;
            dgvManageDetainedLicenses.Size = new Size(1252, 343);
            dgvManageDetainedLicenses.TabIndex = 0;
            // 
            // cmsManageDetainedLicenses
            // 
            cmsManageDetainedLicenses.ImageScalingSize = new Size(20, 20);
            cmsManageDetainedLicenses.Items.AddRange(new ToolStripItem[] { showPersonDetailsToolStripMenuItem, showLicenseDetailsToolStripMenuItem, showPersonLicenseHistoryToolStripMenuItem, toolStripMenuItem1, releaseDetainToolStripMenuItem });
            cmsManageDetainedLicenses.Name = "cmsManageDetainedLicenses";
            cmsManageDetainedLicenses.Size = new Size(230, 114);
            cmsManageDetainedLicenses.Opening += cmsManageDetainedLicenses_Opening;
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            showPersonDetailsToolStripMenuItem.Image = ImageResources.PersonDetails_32;
            showPersonDetailsToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            showPersonDetailsToolStripMenuItem.Size = new Size(229, 26);
            showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            showPersonDetailsToolStripMenuItem.Click += showPersonDetailsToolStripMenuItem_Click;
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            showLicenseDetailsToolStripMenuItem.Image = ImageResources.License_View_32;
            showLicenseDetailsToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            showLicenseDetailsToolStripMenuItem.Size = new Size(229, 26);
            showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            showLicenseDetailsToolStripMenuItem.Click += showLicenseDetailsToolStripMenuItem_Click;
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            showPersonLicenseHistoryToolStripMenuItem.Image = ImageResources.PersonLicenseHistory_32;
            showPersonLicenseHistoryToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            showPersonLicenseHistoryToolStripMenuItem.Size = new Size(229, 26);
            showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            showPersonLicenseHistoryToolStripMenuItem.Click += showPersonLicenseHistoryToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(226, 6);
            // 
            // releaseDetainToolStripMenuItem
            // 
            releaseDetainToolStripMenuItem.Image = ImageResources.Release_Detained_License_32;
            releaseDetainToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            releaseDetainToolStripMenuItem.Name = "releaseDetainToolStripMenuItem";
            releaseDetainToolStripMenuItem.Size = new Size(229, 26);
            releaseDetainToolStripMenuItem.Text = "Release Detained License";
            releaseDetainToolStripMenuItem.Click += releaseDetainToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 316);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 16);
            label1.TabIndex = 1;
            label1.Text = "Filter By :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(13, 714);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(86, 16);
            label2.TabIndex = 2;
            label2.Text = "# Records : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift SemiBold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkRed;
            label3.Location = new Point(457, 262);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(334, 33);
            label3.TabIndex = 3;
            label3.Text = "Manage Detained Licenses";
            // 
            // lblRecordsCount
            // 
            lblRecordsCount.AutoSize = true;
            lblRecordsCount.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecordsCount.Location = new Point(124, 714);
            lblRecordsCount.Margin = new Padding(4, 0, 4, 0);
            lblRecordsCount.Name = "lblRecordsCount";
            lblRecordsCount.Size = new Size(15, 16);
            lblRecordsCount.TabIndex = 6;
            lblRecordsCount.Text = "0";
            // 
            // mtxtFilterSearch
            // 
            mtxtFilterSearch.Location = new Point(342, 313);
            mtxtFilterSearch.Margin = new Padding(4, 2, 4, 2);
            mtxtFilterSearch.Name = "mtxtFilterSearch";
            mtxtFilterSearch.Size = new Size(247, 23);
            mtxtFilterSearch.TabIndex = 7;
            mtxtFilterSearch.TextChanged += mtxtFilterSearch_TextChanged;
            mtxtFilterSearch.KeyPress += mtxtFilterSearch_KeyPress;
            // 
            // cbFilterBy
            // 
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "Detain ID", "Is Releasaed", "National No", "Full Name", "Release Application ID" });
            cbFilterBy.Location = new Point(113, 316);
            cbFilterBy.Margin = new Padding(4, 2, 4, 2);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(208, 23);
            cbFilterBy.TabIndex = 8;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // btnDetainLicense
            // 
            btnDetainLicense.FlatStyle = FlatStyle.Flat;
            btnDetainLicense.Image = ImageResources.Detain_64;
            btnDetainLicense.Location = new Point(1182, 283);
            btnDetainLicense.Margin = new Padding(4);
            btnDetainLicense.Name = "btnDetainLicense";
            btnDetainLicense.Size = new Size(84, 62);
            btnDetainLicense.TabIndex = 11;
            btnDetainLicense.UseVisualStyleBackColor = true;
            btnDetainLicense.Click += btnDetainLicense_Click;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = ImageResources.PersonLicenseHistory_321;
            button1.Location = new Point(1771, 170);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(105, 78);
            button1.TabIndex = 10;
            button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = ImageResources.Detain_512;
            pictureBox1.Location = new Point(524, 9);
            pictureBox1.Margin = new Padding(4, 2, 4, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(281, 248);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // btnCloseForm
            // 
            btnCloseForm.FlatStyle = FlatStyle.Flat;
            btnCloseForm.Image = ImageResources.Close_321;
            btnCloseForm.ImageAlign = ContentAlignment.MiddleLeft;
            btnCloseForm.Location = new Point(1133, 706);
            btnCloseForm.Margin = new Padding(4);
            btnCloseForm.Name = "btnCloseForm";
            btnCloseForm.Size = new Size(133, 38);
            btnCloseForm.TabIndex = 4;
            btnCloseForm.Text = "Close";
            btnCloseForm.UseVisualStyleBackColor = true;
            btnCloseForm.Click += btnCloseForm_Click;
            // 
            // btnReleaseDetainedLicense
            // 
            btnReleaseDetainedLicense.FlatStyle = FlatStyle.Flat;
            btnReleaseDetainedLicense.Image = ImageResources.Release_Detained_License_64;
            btnReleaseDetainedLicense.Location = new Point(1090, 283);
            btnReleaseDetainedLicense.Margin = new Padding(4);
            btnReleaseDetainedLicense.Name = "btnReleaseDetainedLicense";
            btnReleaseDetainedLicense.Size = new Size(84, 62);
            btnReleaseDetainedLicense.TabIndex = 13;
            btnReleaseDetainedLicense.UseVisualStyleBackColor = true;
            btnReleaseDetainedLicense.Click += btnReleaseDetainedLicense_Click;
            // 
            // cbIsReleasedFilter
            // 
            cbIsReleasedFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIsReleasedFilter.FormattingEnabled = true;
            cbIsReleasedFilter.Items.AddRange(new object[] { "All", "Yes", "No" });
            cbIsReleasedFilter.Location = new Point(342, 316);
            cbIsReleasedFilter.Name = "cbIsReleasedFilter";
            cbIsReleasedFilter.Size = new Size(121, 23);
            cbIsReleasedFilter.TabIndex = 14;
            cbIsReleasedFilter.Visible = false;
            cbIsReleasedFilter.SelectedIndexChanged += cbIsReleasedFilter_SelectedIndexChanged;
            // 
            // frmManageDetainedLicenses
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1279, 757);
            Controls.Add(cbIsReleasedFilter);
            Controls.Add(btnReleaseDetainedLicense);
            Controls.Add(btnDetainLicense);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(cbFilterBy);
            Controls.Add(mtxtFilterSearch);
            Controls.Add(lblRecordsCount);
            Controls.Add(btnCloseForm);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvManageDetainedLicenses);
            Margin = new Padding(4);
            Name = "frmManageDetainedLicenses";
            Text = "ManageAll";
            Load += frmManageDetainedLicenses_Load;
            ((System.ComponentModel.ISupportInitialize)dgvManageDetainedLicenses).EndInit();
            cmsManageDetainedLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvManageDetainedLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCloseForm;
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