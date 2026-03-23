namespace DVLD_UiLayer.TestAppointments
{
    partial class FrmTestAppointments
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
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.lblTestType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvManageAppointments = new System.Windows.Forms.DataGridView();
            this.cmsManageAppointment_Apps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LocalDL_AppCard = new DVLD_UiLayer.UserControls.ctrLocalDL_AppCard();
            this.pbTestType = new System.Windows.Forms.PictureBox();
            this.btnAddTestAppointment = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageAppointments)).BeginInit();
            this.cmsManageAppointment_Apps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(128, 859);
            this.lblRecordsCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(21, 21);
            this.lblRecordsCount.TabIndex = 16;
            this.lblRecordsCount.Text = "0";
            // 
            // lblTitle
            // 
            this.lblTestType.AutoSize = true;
            this.lblTestType.Font = new System.Drawing.Font("Bahnschrift SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestType.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTestType.Location = new System.Drawing.Point(231, 156);
            this.lblTestType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTestType.Name = "lblTitle";
            this.lblTestType.Size = new System.Drawing.Size(411, 41);
            this.lblTestType.TabIndex = 13;
            this.lblTestType.Text = "Vision Test  Appointments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 859);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "# Records : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 610);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Appointments :";
            // 
            // dgvManageAppointments
            // 
            this.dgvManageAppointments.AllowUserToAddRows = false;
            this.dgvManageAppointments.AllowUserToDeleteRows = false;
            this.dgvManageAppointments.AllowUserToOrderColumns = true;
            this.dgvManageAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageAppointments.ContextMenuStrip = this.cmsManageAppointment_Apps;
            this.dgvManageAppointments.Location = new System.Drawing.Point(21, 647);
            this.dgvManageAppointments.Margin = new System.Windows.Forms.Padding(4);
            this.dgvManageAppointments.Name = "dgvManageAppointments";
            this.dgvManageAppointments.ReadOnly = true;
            this.dgvManageAppointments.RowHeadersWidth = 51;
            this.dgvManageAppointments.Size = new System.Drawing.Size(811, 197);
            this.dgvManageAppointments.TabIndex = 10;
            // 
            // cmsManageAppointment_Apps
            // 
            this.cmsManageAppointment_Apps.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageAppointment_Apps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cmsManageAppointment_Apps.Name = "cmsManageLocalDL_Apps";
            this.cmsManageAppointment_Apps.Size = new System.Drawing.Size(142, 56);
            this.cmsManageAppointment_Apps.Opening += new System.ComponentModel.CancelEventHandler(this.cmsManageAppointment_Apps_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.edit_32;
            this.editToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.Test_32;
            this.takeTestToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // LocalDL_AppCard
            // 
            this.LocalDL_AppCard.Location = new System.Drawing.Point(5, 201);
            this.LocalDL_AppCard.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.LocalDL_AppCard.Name = "LocalDL_AppCard";
            this.LocalDL_AppCard.Size = new System.Drawing.Size(832, 374);
            this.LocalDL_AppCard.TabIndex = 0;
            // 
            // pbTestTypeImage
            // 
            this.pbTestType.Image = global::DVLD_UiLayer.ImageResources.Vision_512;
            this.pbTestType.Location = new System.Drawing.Point(360, 37);
            this.pbTestType.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pbTestType.Name = "pbTestTypeImage";
            this.pbTestType.Size = new System.Drawing.Size(108, 103);
            this.pbTestType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTestType.TabIndex = 17;
            this.pbTestType.TabStop = false;
            // 
            // btnAddTestAppointment
            // 
            this.btnAddTestAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTestAppointment.Image = global::DVLD_UiLayer.ImageResources.AddAppointment_32;
            this.btnAddTestAppointment.Location = new System.Drawing.Point(783, 599);
            this.btnAddTestAppointment.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTestAppointment.Name = "btnAddTestAppointment";
            this.btnAddTestAppointment.Size = new System.Drawing.Size(49, 39);
            this.btnAddTestAppointment.TabIndex = 15;
            this.btnAddTestAppointment.Text = " ";
            this.btnAddTestAppointment.UseVisualStyleBackColor = true;
            this.btnAddTestAppointment.Click += new System.EventHandler(this.btnAddTestAppointment_Click);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Image = global::DVLD_UiLayer.ImageResources.Close_321;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(699, 852);
            this.btnCloseForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(133, 41);
            this.btnCloseForm.TabIndex = 14;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // frmTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 910);
            this.Controls.Add(this.pbTestType);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.btnAddTestAppointment);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.lblTestType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvManageAppointments);
            this.Controls.Add(this.LocalDL_AppCard);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTestAppointments";
            this.Text = "frmTestAppointments";
            this.Load += new System.EventHandler(this.frmTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageAppointments)).EndInit();
            this.cmsManageAppointment_Apps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.ctrLocalDL_AppCard LocalDL_AppCard;
        private System.Windows.Forms.PictureBox pbTestType;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Button btnAddTestAppointment;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Label lblTestType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvManageAppointments;
        private System.Windows.Forms.ContextMenuStrip cmsManageAppointment_Apps;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}