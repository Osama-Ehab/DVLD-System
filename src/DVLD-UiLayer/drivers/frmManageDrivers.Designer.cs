namespace DVLD_UiLayer
{
    partial class frmManageDrivers
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
            dgvManageDrivers = new DataGridView();
            cmsManageDrivers = new ContextMenuStrip(components);
            showDetailsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            toolStripMenuItem2 = new ToolStripSeparator();
            sendToolStripMenuItem = new ToolStripMenuItem();
            phoneCallToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblRecordsCount = new Label();
            mtxtFilterSearch = new MaskedTextBox();
            cbFilterBy = new ComboBox();
            btnSearchDriverLicenseHistory = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            btnCloseForm = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvManageDrivers).BeginInit();
            cmsManageDrivers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvManageDrivers
            // 
            dgvManageDrivers.AllowUserToAddRows = false;
            dgvManageDrivers.AllowUserToDeleteRows = false;
            dgvManageDrivers.AllowUserToOrderColumns = true;
            dgvManageDrivers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvManageDrivers.ContextMenuStrip = cmsManageDrivers;
            dgvManageDrivers.Location = new Point(14, 285);
            dgvManageDrivers.Margin = new Padding(4);
            dgvManageDrivers.Name = "dgvManageDrivers";
            dgvManageDrivers.ReadOnly = true;
            dgvManageDrivers.RowHeadersWidth = 51;
            dgvManageDrivers.Size = new Size(1071, 343);
            dgvManageDrivers.TabIndex = 0;
            // 
            // cmsManageDrivers
            // 
            cmsManageDrivers.ImageScalingSize = new Size(20, 20);
            cmsManageDrivers.Items.AddRange(new ToolStripItem[] { showDetailsToolStripMenuItem, toolStripMenuItem3, toolStripMenuItem2, sendToolStripMenuItem, phoneCallToolStripMenuItem });
            cmsManageDrivers.Name = "cmsManageDrivers";
            cmsManageDrivers.Size = new Size(230, 94);
            // 
            // showDetailsToolStripMenuItem
            // 
            showDetailsToolStripMenuItem.Image = ImageResources.License_View_32;
            showDetailsToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            showDetailsToolStripMenuItem.Size = new Size(229, 26);
            showDetailsToolStripMenuItem.Text = "Show Driver Licenses History";
            showDetailsToolStripMenuItem.Click += showDetailsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(226, 6);
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(226, 6);
            // 
            // sendToolStripMenuItem
            // 
            sendToolStripMenuItem.Image = ImageResources.send_email_321;
            sendToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            sendToolStripMenuItem.Name = "sendToolStripMenuItem";
            sendToolStripMenuItem.Size = new Size(229, 26);
            sendToolStripMenuItem.Text = "Send Email";
            // 
            // phoneCallToolStripMenuItem
            // 
            phoneCallToolStripMenuItem.Image = ImageResources.call_32;
            phoneCallToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            phoneCallToolStripMenuItem.Name = "phoneCallToolStripMenuItem";
            phoneCallToolStripMenuItem.Size = new Size(229, 26);
            phoneCallToolStripMenuItem.Text = "Phone Call";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 248);
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
            label2.Location = new Point(13, 647);
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
            label3.Location = new Point(457, 193);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(206, 33);
            label3.TabIndex = 3;
            label3.Text = "Manage Drivers";
            // 
            // lblRecordsCount
            // 
            lblRecordsCount.AutoSize = true;
            lblRecordsCount.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecordsCount.Location = new Point(124, 647);
            lblRecordsCount.Margin = new Padding(4, 0, 4, 0);
            lblRecordsCount.Name = "lblRecordsCount";
            lblRecordsCount.Size = new Size(15, 16);
            lblRecordsCount.TabIndex = 6;
            lblRecordsCount.Text = "0";
            // 
            // mtxtFilterSearch
            // 
            mtxtFilterSearch.Location = new Point(342, 246);
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
            cbFilterBy.Items.AddRange(new object[] { "None", "Driver ID", "Person ID", "National No.", "Full Name" });
            cbFilterBy.Location = new Point(113, 248);
            cbFilterBy.Margin = new Padding(4, 2, 4, 2);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(208, 23);
            cbFilterBy.TabIndex = 8;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // btnSearchDriverLicenseHistory
            // 
            btnSearchDriverLicenseHistory.FlatStyle = FlatStyle.Flat;
            btnSearchDriverLicenseHistory.Image = ImageResources.PersonLicenseHistory_321;
            btnSearchDriverLicenseHistory.Location = new Point(1001, 216);
            btnSearchDriverLicenseHistory.Margin = new Padding(4);
            btnSearchDriverLicenseHistory.Name = "btnSearchDriverLicenseHistory";
            btnSearchDriverLicenseHistory.Size = new Size(84, 62);
            btnSearchDriverLicenseHistory.TabIndex = 11;
            btnSearchDriverLicenseHistory.UseVisualStyleBackColor = true;
            btnSearchDriverLicenseHistory.Click += btnSearchDriverLicenseHistory_Click;
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
            pictureBox1.Image = ImageResources.Driver_Main;
            pictureBox1.Location = new Point(444, 8);
            pictureBox1.Margin = new Padding(4, 2, 4, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(293, 179);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // btnCloseForm
            // 
            btnCloseForm.FlatStyle = FlatStyle.Flat;
            btnCloseForm.Image = ImageResources.Close_321;
            btnCloseForm.ImageAlign = ContentAlignment.MiddleLeft;
            btnCloseForm.Location = new Point(952, 647);
            btnCloseForm.Margin = new Padding(4);
            btnCloseForm.Name = "btnCloseForm";
            btnCloseForm.Size = new Size(133, 38);
            btnCloseForm.TabIndex = 4;
            btnCloseForm.Text = "Close";
            btnCloseForm.UseVisualStyleBackColor = true;
            btnCloseForm.Click += btnCloseForm_Click;
            // 
            // frmManageDrivers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1103, 705);
            Controls.Add(btnSearchDriverLicenseHistory);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(cbFilterBy);
            Controls.Add(mtxtFilterSearch);
            Controls.Add(lblRecordsCount);
            Controls.Add(btnCloseForm);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvManageDrivers);
            Margin = new Padding(4);
            Name = "frmManageDrivers";
            Text = "ManageAll";
            Load += frmManageDrivers_Load;
            ((System.ComponentModel.ISupportInitialize)dgvManageDrivers).EndInit();
            cmsManageDrivers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvManageDrivers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.MaskedTextBox mtxtFilterSearch;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip cmsManageDrivers;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phoneCallToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSearchDriverLicenseHistory;
    }
}