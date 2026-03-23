namespace DVLD_UiLayer
{
    partial class frmAddEditLocalDL_App
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
            this.tControlAddEditLocalDL_App = new System.Windows.Forms.TabControl();
            this.tPagePersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrPersonCardWithFilter = new DVLD_UiLayer.ctrPersonCardWithFilter();
            this.tPageApplicationInfo = new System.Windows.Forms.TabPage();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblLocalDL_AppID = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tControlAddEditLocalDL_App.SuspendLayout();
            this.tPagePersonalInfo.SuspendLayout();
            this.tPageApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tControlAddEditLocalDL_App
            // 
            this.tControlAddEditLocalDL_App.Controls.Add(this.tPagePersonalInfo);
            this.tControlAddEditLocalDL_App.Controls.Add(this.tPageApplicationInfo);
            this.tControlAddEditLocalDL_App.Location = new System.Drawing.Point(1, 88);
            this.tControlAddEditLocalDL_App.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tControlAddEditLocalDL_App.Name = "tControlAddEditLocalDL_App";
            this.tControlAddEditLocalDL_App.SelectedIndex = 0;
            this.tControlAddEditLocalDL_App.Size = new System.Drawing.Size(871, 437);
            this.tControlAddEditLocalDL_App.TabIndex = 0;
            this.tControlAddEditLocalDL_App.Validating += new System.ComponentModel.CancelEventHandler(this.SelectedPerson_Validating);
            // 
            // tPagePersonalInfo
            // 
            this.tPagePersonalInfo.Controls.Add(this.btnNext);
            this.tPagePersonalInfo.Controls.Add(this.ctrPersonCardWithFilter);
            this.tPagePersonalInfo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tPagePersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tPagePersonalInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tPagePersonalInfo.Name = "tPagePersonalInfo";
            this.tPagePersonalInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tPagePersonalInfo.Size = new System.Drawing.Size(863, 411);
            this.tPagePersonalInfo.TabIndex = 0;
            this.tPagePersonalInfo.Text = "Persona lInfo";
            this.tPagePersonalInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Image = global::DVLD_UiLayer.ImageResources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(730, 375);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(114, 33);
            this.btnNext.TabIndex = 50;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrPersonCardWithFilter
            // 
            this.ctrPersonCardWithFilter.FilterEnabled = true;
            this.ctrPersonCardWithFilter.Location = new System.Drawing.Point(15, 27);
            this.ctrPersonCardWithFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrPersonCardWithFilter.Name = "ctrPersonCardWithFilter";
            this.ctrPersonCardWithFilter.ShowAddPerson = true;
            this.ctrPersonCardWithFilter.Size = new System.Drawing.Size(843, 356);
            this.ctrPersonCardWithFilter.TabIndex = 0;
            // 
            // tPageApplicationInfo
            // 
            this.tPageApplicationInfo.Controls.Add(this.cbLicenseClass);
            this.tPageApplicationInfo.Controls.Add(this.pictureBox5);
            this.tPageApplicationInfo.Controls.Add(this.label7);
            this.tPageApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.tPageApplicationInfo.Controls.Add(this.pictureBox4);
            this.tPageApplicationInfo.Controls.Add(this.label5);
            this.tPageApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.tPageApplicationInfo.Controls.Add(this.pictureBox3);
            this.tPageApplicationInfo.Controls.Add(this.label3);
            this.tPageApplicationInfo.Controls.Add(this.pictureBox1);
            this.tPageApplicationInfo.Controls.Add(this.label1);
            this.tPageApplicationInfo.Controls.Add(this.lblUserName);
            this.tPageApplicationInfo.Controls.Add(this.pictureBox2);
            this.tPageApplicationInfo.Controls.Add(this.label8);
            this.tPageApplicationInfo.Controls.Add(this.lblLocalDL_AppID);
            this.tPageApplicationInfo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tPageApplicationInfo.Location = new System.Drawing.Point(4, 22);
            this.tPageApplicationInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tPageApplicationInfo.Name = "tPageApplicationInfo";
            this.tPageApplicationInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tPageApplicationInfo.Size = new System.Drawing.Size(863, 411);
            this.tPageApplicationInfo.TabIndex = 1;
            this.tPageApplicationInfo.Text = "Login Info";
            this.tPageApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Items.AddRange(new object[] {
            "Class 1 - Small Motorcycle",
            "Class 2 - Heavy Motorcycle License",
            "Class 3 - Ordinary driving license",
            "Class 4 - Commercial",
            "Class 5 - Agricultural",
            "Class 6 - Small and medium bus",
            "Class 7 - Truck and heavy vehicle"});
            this.cbLicenseClass.Location = new System.Drawing.Point(223, 122);
            this.cbLicenseClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(251, 22);
            this.cbLicenseClass.TabIndex = 77;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_UiLayer.ImageResources.money_32;
            this.pictureBox5.Location = new System.Drawing.Point(181, 155);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(21, 19);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 76;
            this.pictureBox5.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 14);
            this.label7.TabIndex = 74;
            this.label7.Text = "Application PaidFees :";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(220, 156);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(41, 14);
            this.lblApplicationFees.TabIndex = 75;
            this.lblApplicationFees.Text = "[$$$]";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_UiLayer.ImageResources.Calendar_32;
            this.pictureBox4.Location = new System.Drawing.Point(181, 89);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(21, 19);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 73;
            this.pictureBox4.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 14);
            this.label5.TabIndex = 71;
            this.label5.Text = "Application  Date :";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(220, 90);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(38, 14);
            this.lblApplicationDate.TabIndex = 72;
            this.lblApplicationDate.Text = "[???]";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_UiLayer.ImageResources.LocalDriving_License;
            this.pictureBox3.Location = new System.Drawing.Point(181, 122);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(21, 19);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 70;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 14);
            this.label3.TabIndex = 68;
            this.label3.Text = "License  Class  :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_UiLayer.ImageResources.User_32__2;
            this.pictureBox1.Location = new System.Drawing.Point(181, 193);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 67;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 65;
            this.label1.Text = "Created  By :";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(220, 193);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(38, 14);
            this.lblUserName.TabIndex = 66;
            this.lblUserName.Text = "[???]";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_UiLayer.ImageResources.Number_321;
            this.pictureBox2.Location = new System.Drawing.Point(181, 56);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 19);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 64;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(30, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 14);
            this.label8.TabIndex = 56;
            this.label8.Text = "D.L.Application ID  :";
            // 
            // lblLocalDL_AppID
            // 
            this.lblLocalDL_AppID.AutoSize = true;
            this.lblLocalDL_AppID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalDL_AppID.Location = new System.Drawing.Point(220, 57);
            this.lblLocalDL_AppID.Name = "lblLocalDL_AppID";
            this.lblLocalDL_AppID.Size = new System.Drawing.Size(38, 14);
            this.lblLocalDL_AppID.TabIndex = 60;
            this.lblLocalDL_AppID.Text = "[???]";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMode.Location = new System.Drawing.Point(200, 32);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(426, 29);
            this.lblMode.TabIndex = 2;
            this.lblMode.Text = "New  Local Driving License  Application";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::DVLD_UiLayer.ImageResources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(756, 531);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 33);
            this.btnSave.TabIndex = 48;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Image = global::DVLD_UiLayer.ImageResources.Close_321;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(635, 531);
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
            // frmAddEditLocalDL_App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(879, 574);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.tControlAddEditLocalDL_App);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAddEditLocalDL_App";
            this.Text = "frmAddEditLocalDL_App";
            this.Load += new System.EventHandler(this.frmAddEditLocalDL_App_Load);
            this.tControlAddEditLocalDL_App.ResumeLayout(false);
            this.tPagePersonalInfo.ResumeLayout(false);
            this.tPageApplicationInfo.ResumeLayout(false);
            this.tPageApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tControlAddEditLocalDL_App;
        private System.Windows.Forms.TabPage tPagePersonalInfo;
        private System.Windows.Forms.TabPage tPageApplicationInfo;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnNext;
        private ctrPersonCardWithFilter ctrPersonCardWithFilter;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblLocalDL_AppID;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.ComboBox cbLicenseClass;
    }
}