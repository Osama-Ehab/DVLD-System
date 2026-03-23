namespace DVLD_UiLayer
{
    partial class frmAddEditLicenseApplication
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
            this.gbReplacementAppChoices = new System.Windows.Forms.GroupBox();
            this.rbReplacementForLost = new System.Windows.Forms.RadioButton();
            this.rbReplacementForDamaged = new System.Windows.Forms.RadioButton();
            this.LocalDriverLicenseCardWithFilter = new DVLD_UiLayer.UserControls.ctrLocalDriverLicenseInfoWithFilter();
            this.tPageApplicationInfo = new System.Windows.Forms.TabPage();
            this.ReleaseDetainedLicenseAppCard = new DVLD_UiLayer.UserControls.ctrReleaseDetainedLicenseAppCard();
            this.NewDL_AppCard = new DVLD_UiLayer.UserControls.ctrNewDL_AppCard();
            this.InternationalApplicationCard = new DVLD_UiLayer.UserControls.ctrInternationalDL_AppCard();
            this.lblMode = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.linklblShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.tControlAddEditBasicApplication.SuspendLayout();
            this.tPageLocalDriverLicensealInfo.SuspendLayout();
            this.gbReplacementAppChoices.SuspendLayout();
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
            this.tPageLocalDriverLicensealInfo.Controls.Add(this.gbReplacementAppChoices);
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
            // gbReplacementAppChoices
            // 
            this.gbReplacementAppChoices.Controls.Add(this.rbReplacementForLost);
            this.gbReplacementAppChoices.Controls.Add(this.rbReplacementForDamaged);
            this.gbReplacementAppChoices.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReplacementAppChoices.Location = new System.Drawing.Point(608, 19);
            this.gbReplacementAppChoices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbReplacementAppChoices.Name = "gbReplacementAppChoices";
            this.gbReplacementAppChoices.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbReplacementAppChoices.Size = new System.Drawing.Size(217, 76);
            this.gbReplacementAppChoices.TabIndex = 51;
            this.gbReplacementAppChoices.TabStop = false;
            this.gbReplacementAppChoices.Text = "Replacement For.";
            // 
            // rbReplacementForLost
            // 
            this.rbReplacementForLost.AutoSize = true;
            this.rbReplacementForLost.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbReplacementForLost.Location = new System.Drawing.Point(5, 50);
            this.rbReplacementForLost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbReplacementForLost.Name = "rbReplacementForLost";
            this.rbReplacementForLost.Size = new System.Drawing.Size(158, 18);
            this.rbReplacementForLost.TabIndex = 55;
            this.rbReplacementForLost.TabStop = true;
            this.rbReplacementForLost.Text = "Replacement For Lost";
            this.rbReplacementForLost.UseVisualStyleBackColor = true;
            // 
            // rbReplacementForDamaged
            // 
            this.rbReplacementForDamaged.AutoSize = true;
            this.rbReplacementForDamaged.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbReplacementForDamaged.Location = new System.Drawing.Point(5, 24);
            this.rbReplacementForDamaged.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbReplacementForDamaged.Name = "rbReplacementForDamaged";
            this.rbReplacementForDamaged.Size = new System.Drawing.Size(188, 18);
            this.rbReplacementForDamaged.TabIndex = 54;
            this.rbReplacementForDamaged.TabStop = true;
            this.rbReplacementForDamaged.Text = "Replacement For Damaged";
            this.rbReplacementForDamaged.UseVisualStyleBackColor = true;
            this.rbReplacementForDamaged.CheckedChanged += new System.EventHandler(this.rbReplacement_CheckedChanged);
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
            this.tPageApplicationInfo.Controls.Add(this.ReleaseDetainedLicenseAppCard);
            this.tPageApplicationInfo.Controls.Add(this.NewDL_AppCard);
            this.tPageApplicationInfo.Controls.Add(this.InternationalApplicationCard);
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
            // ReleaseDetainedLicenseAppCard
            // 
            this.ReleaseDetainedLicenseAppCard.Location = new System.Drawing.Point(15, 11);
            this.ReleaseDetainedLicenseAppCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReleaseDetainedLicenseAppCard.Name = "ReleaseDetainedLicenseAppCard";
            this.ReleaseDetainedLicenseAppCard.Size = new System.Drawing.Size(712, 208);
            this.ReleaseDetainedLicenseAppCard.TabIndex = 80;
            // 
            // NewDL_AppCard
            // 
            this.NewDL_AppCard.Location = new System.Drawing.Point(11, 11);
            this.NewDL_AppCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NewDL_AppCard.Name = "NewDL_AppCard";
            this.NewDL_AppCard.Size = new System.Drawing.Size(712, 296);
            this.NewDL_AppCard.TabIndex = 79;
            // 
            // InternationalApplicationCard
            // 
            this.InternationalApplicationCard.Location = new System.Drawing.Point(6, 5);
            this.InternationalApplicationCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InternationalApplicationCard.Name = "InternationalApplicationCard";
            this.InternationalApplicationCard.Size = new System.Drawing.Size(709, 198);
            this.InternationalApplicationCard.TabIndex = 78;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMode.Location = new System.Drawing.Point(147, 32);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(507, 29);
            this.lblMode.TabIndex = 2;
            this.lblMode.Text = "New  International Driving License  Application";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::DVLD_UiLayer.ImageResources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(719, 540);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(143, 33);
            this.btnSave.TabIndex = 48;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // frmAddEditLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(873, 583);
            this.Controls.Add(this.linklblShowLicensesHistory);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.tControlAddEditBasicApplication);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAddEditLicenseApplication";
            this.Text = "frmAddEditLicenseApplication";
            this.Load += new System.EventHandler(this.frmAddEditBasicApplication_Load);
            this.tControlAddEditBasicApplication.ResumeLayout(false);
            this.tPageLocalDriverLicensealInfo.ResumeLayout(false);
            this.gbReplacementAppChoices.ResumeLayout(false);
            this.gbReplacementAppChoices.PerformLayout();
            this.tPageApplicationInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tControlAddEditBasicApplication;
        private System.Windows.Forms.TabPage tPageLocalDriverLicensealInfo;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage tPageApplicationInfo;
        private UserControls.ctrInternationalDL_AppCard InternationalApplicationCard;
        private UserControls.ctrLocalDriverLicenseInfoWithFilter LocalDriverLicenseCardWithFilter;
        private System.Windows.Forms.LinkLabel linklblShowLicensesHistory;
        private UserControls.ctrNewDL_AppCard NewDL_AppCard;
        private System.Windows.Forms.GroupBox gbReplacementAppChoices;
        private System.Windows.Forms.RadioButton rbReplacementForLost;
        private System.Windows.Forms.RadioButton rbReplacementForDamaged;
        private UserControls.ctrReleaseDetainedLicenseAppCard ReleaseDetainedLicenseAppCard;
    }
}