namespace DVLD_UiLayer
{
    partial class frmAddEditUser
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
            tControlAddEditUser = new TabControl();
            tPagePersonalInfo = new TabPage();
            btnNext = new Button();
            ctrPersonCardWithFilter = new ctrPersonCardWithFilter();
            tPageLoginInfo = new TabPage();
            txtConfirmPassword = new MaskedTextBox();
            txtPassword = new MaskedTextBox();
            chkIsActive = new CheckBox();
            pictureBox2 = new PictureBox();
            pictureBox8 = new PictureBox();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            label2 = new Label();
            pictureBox9 = new PictureBox();
            label8 = new Label();
            lblUserID = new Label();
            txtUserName = new TextBox();
            label5 = new Label();
            lblMode = new Label();
            btnSave = new Button();
            btnCloseForm = new Button();
            errorProvider1 = new ErrorProvider(components);
            ConfirmPasswordVisibility = new PictureBox();
            NewPasswordVisibility = new PictureBox();
            tControlAddEditUser.SuspendLayout();
            tPagePersonalInfo.SuspendLayout();
            tPageLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ConfirmPasswordVisibility).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NewPasswordVisibility).BeginInit();
            SuspendLayout();
            // 
            // tControlAddEditUser
            // 
            tControlAddEditUser.Controls.Add(tPagePersonalInfo);
            tControlAddEditUser.Controls.Add(tPageLoginInfo);
            tControlAddEditUser.Location = new Point(1, 135);
            tControlAddEditUser.Margin = new Padding(3, 4, 3, 4);
            tControlAddEditUser.Name = "tControlAddEditUser";
            tControlAddEditUser.SelectedIndex = 0;
            tControlAddEditUser.Size = new Size(1161, 672);
            tControlAddEditUser.TabIndex = 0;
            // 
            // tPagePersonalInfo
            // 
            tPagePersonalInfo.Controls.Add(btnNext);
            tPagePersonalInfo.Controls.Add(ctrPersonCardWithFilter);
            tPagePersonalInfo.Font = new Font("Tahoma", 9F);
            tPagePersonalInfo.Location = new Point(4, 29);
            tPagePersonalInfo.Margin = new Padding(3, 4, 3, 4);
            tPagePersonalInfo.Name = "tPagePersonalInfo";
            tPagePersonalInfo.Padding = new Padding(3, 4, 3, 4);
            tPagePersonalInfo.Size = new Size(1153, 639);
            tPagePersonalInfo.TabIndex = 0;
            tPagePersonalInfo.Text = "Persona lInfo";
            tPagePersonalInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Image = ImageResources.Next_32;
            btnNext.ImageAlign = ContentAlignment.MiddleRight;
            btnNext.Location = new Point(974, 576);
            btnNext.Margin = new Padding(5, 5, 5, 5);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(152, 51);
            btnNext.TabIndex = 50;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // ctrPersonCardWithFilter
            // 
            ctrPersonCardWithFilter.AutoValidate = AutoValidate.EnableAllowFocusChange;
            ctrPersonCardWithFilter.FilterEnabled = true;
            ctrPersonCardWithFilter.Location = new Point(19, 41);
            ctrPersonCardWithFilter.Margin = new Padding(6, 5, 6, 5);
            ctrPersonCardWithFilter.Name = "ctrPersonCardWithFilter";
            ctrPersonCardWithFilter.ShowAddPerson = true;
            ctrPersonCardWithFilter.Size = new Size(1125, 548);
            ctrPersonCardWithFilter.TabIndex = 0;
            // 
            // tPageLoginInfo
            // 
            tPageLoginInfo.Controls.Add(ConfirmPasswordVisibility);
            tPageLoginInfo.Controls.Add(NewPasswordVisibility);
            tPageLoginInfo.Controls.Add(txtConfirmPassword);
            tPageLoginInfo.Controls.Add(txtPassword);
            tPageLoginInfo.Controls.Add(chkIsActive);
            tPageLoginInfo.Controls.Add(pictureBox2);
            tPageLoginInfo.Controls.Add(pictureBox8);
            tPageLoginInfo.Controls.Add(pictureBox1);
            tPageLoginInfo.Controls.Add(label4);
            tPageLoginInfo.Controls.Add(label2);
            tPageLoginInfo.Controls.Add(pictureBox9);
            tPageLoginInfo.Controls.Add(label8);
            tPageLoginInfo.Controls.Add(lblUserID);
            tPageLoginInfo.Controls.Add(txtUserName);
            tPageLoginInfo.Controls.Add(label5);
            tPageLoginInfo.Font = new Font("Tahoma", 9F);
            tPageLoginInfo.Location = new Point(4, 29);
            tPageLoginInfo.Margin = new Padding(3, 4, 3, 4);
            tPageLoginInfo.Name = "tPageLoginInfo";
            tPageLoginInfo.Padding = new Padding(3, 4, 3, 4);
            tPageLoginInfo.Size = new Size(1153, 639);
            tPageLoginInfo.TabIndex = 1;
            tPageLoginInfo.Text = "Login Info";
            tPageLoginInfo.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Location = new Point(297, 236);
            txtConfirmPassword.Margin = new Padding(3, 4, 3, 4);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(218, 26);
            txtConfirmPassword.TabIndex = 69;
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.Validating += Password_Validateing;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(297, 188);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(218, 26);
            txtPassword.TabIndex = 68;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Location = new Point(297, 305);
            chkIsActive.Margin = new Padding(3, 4, 3, 4);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(87, 22);
            chkIsActive.TabIndex = 67;
            chkIsActive.Text = "Is Active";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = ImageResources.Number_321;
            pictureBox2.Location = new Point(241, 88);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(27, 29);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 64;
            pictureBox2.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = ImageResources.Number_321;
            pictureBox8.Location = new Point(241, 238);
            pictureBox8.Margin = new Padding(3, 4, 3, 4);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(27, 29);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 62;
            pictureBox8.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = ImageResources.Person_32;
            pictureBox1.Location = new Point(241, 136);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 29);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 61;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(29, 238);
            label4.Name = "label4";
            label4.Size = new Size(153, 18);
            label4.TabIndex = 58;
            label4.Text = "Confirm Password :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(95, 136);
            label2.Name = "label2";
            label2.Size = new Size(95, 18);
            label2.TabIndex = 57;
            label2.Text = "UserName :";
            // 
            // pictureBox9
            // 
            pictureBox9.Image = ImageResources.Number_321;
            pictureBox9.Location = new Point(241, 188);
            pictureBox9.Margin = new Padding(3, 4, 3, 4);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(27, 29);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 63;
            pictureBox9.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(119, 88);
            label8.Name = "label8";
            label8.Size = new Size(74, 18);
            label8.TabIndex = 56;
            label8.Text = "User ID :";
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserID.Location = new Point(294, 88);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(35, 18);
            lblUserID.TabIndex = 60;
            lblUserID.Text = "???";
            // 
            // txtUserName
            // 
            txtUserName.BorderStyle = BorderStyle.FixedSingle;
            txtUserName.Location = new Point(297, 135);
            txtUserName.Margin = new Padding(3, 4, 3, 4);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(218, 26);
            txtUserName.TabIndex = 55;
            txtUserName.Validating += UserName_Validateing;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(101, 188);
            label5.Name = "label5";
            label5.Size = new Size(90, 18);
            label5.TabIndex = 59;
            label5.Text = "Password :";
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.Font = new Font("Tahoma", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMode.ForeColor = Color.DarkRed;
            lblMode.Location = new Point(458, 55);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(203, 36);
            lblMode.TabIndex = 2;
            lblMode.Text = "Add New User";
            // 
            // btnSave
            // 
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Image = ImageResources.Save_32;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(1008, 816);
            btnSave.Margin = new Padding(5, 5, 5, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(152, 51);
            btnSave.TabIndex = 48;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            btnSave.Validating += SelectedPerson_Validating;
            // 
            // btnCloseForm
            // 
            btnCloseForm.FlatStyle = FlatStyle.Flat;
            btnCloseForm.Image = ImageResources.Close_321;
            btnCloseForm.ImageAlign = ContentAlignment.MiddleLeft;
            btnCloseForm.Location = new Point(847, 816);
            btnCloseForm.Margin = new Padding(5, 5, 5, 5);
            btnCloseForm.Name = "btnCloseForm";
            btnCloseForm.Size = new Size(152, 51);
            btnCloseForm.TabIndex = 49;
            btnCloseForm.Text = "Close";
            btnCloseForm.UseVisualStyleBackColor = true;
            btnCloseForm.Click += btnCloseForm_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ConfirmPasswordVisibility
            // 
            ConfirmPasswordVisibility.Image = ImageResources.Vision_Test_32;
            ConfirmPasswordVisibility.Location = new Point(554, 236);
            ConfirmPasswordVisibility.Margin = new Padding(3, 4, 3, 4);
            ConfirmPasswordVisibility.Name = "ConfirmPasswordVisibility";
            ConfirmPasswordVisibility.Size = new Size(31, 28);
            ConfirmPasswordVisibility.SizeMode = PictureBoxSizeMode.StretchImage;
            ConfirmPasswordVisibility.TabIndex = 86;
            ConfirmPasswordVisibility.TabStop = false;
            ConfirmPasswordVisibility.Click += ConfirmPasswordVisibility_Click;
            // 
            // NewPasswordVisibility
            // 
            NewPasswordVisibility.ErrorImage = null;
            NewPasswordVisibility.Image = ImageResources.Vision_Test_32;
            NewPasswordVisibility.Location = new Point(554, 187);
            NewPasswordVisibility.Margin = new Padding(3, 4, 3, 4);
            NewPasswordVisibility.Name = "NewPasswordVisibility";
            NewPasswordVisibility.Size = new Size(31, 28);
            NewPasswordVisibility.SizeMode = PictureBoxSizeMode.StretchImage;
            NewPasswordVisibility.TabIndex = 85;
            NewPasswordVisibility.TabStop = false;
            NewPasswordVisibility.Click += NewPasswordVisibility_Click;
            // 
            // frmAddEditUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(1171, 884);
            Controls.Add(btnSave);
            Controls.Add(btnCloseForm);
            Controls.Add(lblMode);
            Controls.Add(tControlAddEditUser);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmAddEditUser";
            Text = "frmAddEditUser";
            Load += frmAddEditUser_Load;
            tControlAddEditUser.ResumeLayout(false);
            tPagePersonalInfo.ResumeLayout(false);
            tPageLoginInfo.ResumeLayout(false);
            tPageLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ConfirmPasswordVisibility).EndInit();
            ((System.ComponentModel.ISupportInitialize)NewPasswordVisibility).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tControlAddEditUser;
        private System.Windows.Forms.TabPage tPagePersonalInfo;
        private System.Windows.Forms.TabPage tPageLoginInfo;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnNext;
        private ctrPersonCardWithFilter ctrPersonCardWithFilter;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MaskedTextBox txtPassword;
        private System.Windows.Forms.MaskedTextBox txtConfirmPassword;
        private PictureBox ConfirmPasswordVisibility;
        private PictureBox NewPasswordVisibility;
    }
}