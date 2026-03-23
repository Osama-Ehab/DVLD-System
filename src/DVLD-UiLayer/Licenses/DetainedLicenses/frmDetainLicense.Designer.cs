namespace DVLD_UiLayer
{
    partial class frmDetainLicense
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
            this.tControlAddEditBasicApplication = new System.Windows.Forms.TabControl();
            this.tPageLocalDriverLicensealInfo = new System.Windows.Forms.TabPage();
            this.LocalDriverLicenseCardWithFilter = new DVLD_UiLayer.UserControls.ctrLocalDriverLicenseInfoWithFilter();
            this.tPageApplicationInfo = new System.Windows.Forms.TabPage();
            this.DetainLicenseInfoCard = new DVLD_UiLayer.UserControls.ctrDetainLicenseInfoCard();
            this.lblMode = new System.Windows.Forms.Label();
            this.btnDetain = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.linklblShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.tControlAddEditBasicApplication.SuspendLayout();
            this.tPageLocalDriverLicensealInfo.SuspendLayout();
            this.tPageApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tControlAddEditBasicApplication
            // 
            this.tControlAddEditBasicApplication.Controls.Add(this.tPageLocalDriverLicensealInfo);
            this.tControlAddEditBasicApplication.Controls.Add(this.tPageApplicationInfo);
            this.tControlAddEditBasicApplication.Location = new System.Drawing.Point(9, 83);
            this.tControlAddEditBasicApplication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tControlAddEditBasicApplication.Name = "tControlAddEditBasicApplication";
            this.tControlAddEditBasicApplication.SelectedIndex = 0;
            this.tControlAddEditBasicApplication.Size = new System.Drawing.Size(854, 452);
            this.tControlAddEditBasicApplication.TabIndex = 0;
            this.tControlAddEditBasicApplication.Validating += new System.ComponentModel.CancelEventHandler(this.SelectedLocalDriverLicense_Validating);
            // 
            // tPageLocalDriverLicensealInfo
            // 
            this.tPageLocalDriverLicensealInfo.Controls.Add(this.LocalDriverLicenseCardWithFilter);
            this.tPageLocalDriverLicensealInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPageLocalDriverLicensealInfo.Location = new System.Drawing.Point(4, 22);
            this.tPageLocalDriverLicensealInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tPageLocalDriverLicensealInfo.Name = "tPageLocalDriverLicensealInfo";
            this.tPageLocalDriverLicensealInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tPageLocalDriverLicensealInfo.Size = new System.Drawing.Size(846, 426);
            this.tPageLocalDriverLicensealInfo.TabIndex = 0;
            this.tPageLocalDriverLicensealInfo.Text = "LocalDriverLicensea lInfo";
            this.tPageLocalDriverLicensealInfo.UseVisualStyleBackColor = true;
            // 
            // LocalDriverLicenseCardWithFilter
            // 
            this.LocalDriverLicenseCardWithFilter.FilterEnabled = true;
            this.LocalDriverLicenseCardWithFilter.Location = new System.Drawing.Point(8, 9);
            this.LocalDriverLicenseCardWithFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LocalDriverLicenseCardWithFilter.Name = "LocalDriverLicenseCardWithFilter";
            this.LocalDriverLicenseCardWithFilter.Size = new System.Drawing.Size(831, 408);
            this.LocalDriverLicenseCardWithFilter.TabIndex = 0;
            this.LocalDriverLicenseCardWithFilter.LicenseSelected += new System.EventHandler<DVLD_UiLayer.EventArgsClasses.LicenseEventArgs>(this.LocalDriverLicenseCardWithFilter_LicenseSelected);
            // 
            // tPageApplicationInfo
            // 
            this.tPageApplicationInfo.Controls.Add(this.DetainLicenseInfoCard);
            this.tPageApplicationInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPageApplicationInfo.Location = new System.Drawing.Point(4, 22);
            this.tPageApplicationInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tPageApplicationInfo.Name = "tPageApplicationInfo";
            this.tPageApplicationInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tPageApplicationInfo.Size = new System.Drawing.Size(846, 426);
            this.tPageApplicationInfo.TabIndex = 1;
            this.tPageApplicationInfo.Text = "Application Info";
            this.tPageApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // DetainLicenseInfoCard
            // 
            this.DetainLicenseInfoCard.Location = new System.Drawing.Point(6, 5);
            this.DetainLicenseInfoCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DetainLicenseInfoCard.Name = "DetainLicenseInfoCard";
            this.DetainLicenseInfoCard.Size = new System.Drawing.Size(709, 198);
            this.DetainLicenseInfoCard.TabIndex = 78;
            this.DetainLicenseInfoCard.Validating += new System.ComponentModel.CancelEventHandler(this.DetainLicenseInfoCard_Validating);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMode.Location = new System.Drawing.Point(332, 28);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(167, 29);
            this.lblMode.TabIndex = 2;
            this.lblMode.Text = "Detain License";
            // 
            // btnDetain
            // 
            this.btnDetain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetain.Image = global::DVLD_UiLayer.ImageResources.Detain_32;
            this.btnDetain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetain.Location = new System.Drawing.Point(719, 540);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(143, 33);
            this.btnDetain.TabIndex = 48;
            this.btnDetain.Text = "Detain";
            this.btnDetain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Image = global::DVLD_UiLayer.ImageResources.Close_321;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(598, 540);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(114, 33);
            this.btnCloseForm.TabIndex = 49;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // linklblShowLicensesHistory
            // 
            this.linklblShowLicensesHistory.AutoSize = true;
            this.linklblShowLicensesHistory.Enabled = false;
            this.linklblShowLicensesHistory.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblShowLicensesHistory.Location = new System.Drawing.Point(23, 548);
            this.linklblShowLicensesHistory.Name = "linklblShowLicensesHistory";
            this.linklblShowLicensesHistory.Size = new System.Drawing.Size(148, 14);
            this.linklblShowLicensesHistory.TabIndex = 50;
            this.linklblShowLicensesHistory.TabStop = true;
            this.linklblShowLicensesHistory.Text = "Show Licenses History.";
            this.linklblShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowLicensesHistory_LinkClicked);
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(873, 583);
            this.Controls.Add(this.linklblShowLicensesHistory);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.tControlAddEditBasicApplication);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDetainLicense";
            this.Text = "frmDetainLicense";
            this.Activated += new System.EventHandler(this.frmDetainLicenseApplication_Activated);
            this.Load += new System.EventHandler(this.frmDetainLicense_Load);
            this.tControlAddEditBasicApplication.ResumeLayout(false);
            this.tPageLocalDriverLicensealInfo.ResumeLayout(false);
            this.tPageApplicationInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tControlAddEditBasicApplication;
        private System.Windows.Forms.TabPage tPageLocalDriverLicensealInfo;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage tPageApplicationInfo;
        private UserControls.ctrDetainLicenseInfoCard DetainLicenseInfoCard;
        private DVLD_UiLayer.UserControls.ctrLocalDriverLicenseInfoWithFilter LocalDriverLicenseCardWithFilter;
        private System.Windows.Forms.LinkLabel linklblShowLicensesHistory;
    }
}