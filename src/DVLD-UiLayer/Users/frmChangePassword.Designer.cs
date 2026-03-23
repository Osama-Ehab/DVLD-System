namespace DVLD_UiLayer.Users
{
    partial class frmChangePassword
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
            UserCard = new DVLD_UiLayer.UserControls.ctrUserCard();
            txtConfirmPassword = new TextBox();
            txtNewPassword = new TextBox();
            pictureBox8 = new PictureBox();
            label4 = new Label();
            pictureBox9 = new PictureBox();
            label5 = new Label();
            btnSave = new Button();
            btnCloseForm = new Button();
            txtCurrentPassword = new TextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            ctrApplicationBasicInfoCard1 = new ctrApplicationBasicInfoCard();
            CurrentPasswordVisibility = new PictureBox();
            NewPasswordVisibility = new PictureBox();
            ConfirmPasswordVisibility = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CurrentPasswordVisibility).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NewPasswordVisibility).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ConfirmPasswordVisibility).BeginInit();
            SuspendLayout();
            // 
            // UserCard
            // 
            UserCard.Location = new Point(16, 39);
            UserCard.Margin = new Padding(3, 5, 3, 5);
            UserCard.Name = "UserCard";
            UserCard.Size = new Size(971, 482);
            UserCard.TabIndex = 1;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Location = new Point(294, 658);
            txtConfirmPassword.Margin = new Padding(3, 4, 3, 4);
            txtConfirmPassword.MaxLength = 40;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(252, 27);
            txtConfirmPassword.TabIndex = 77;
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.Validating += txtConfirmPassword_Validating;
            // 
            // txtNewPassword
            // 
            txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtNewPassword.Location = new Point(294, 609);
            txtNewPassword.Margin = new Padding(3, 4, 3, 4);
            txtNewPassword.MaxLength = 40;
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(252, 27);
            txtNewPassword.TabIndex = 76;
            txtNewPassword.UseSystemPasswordChar = true;
            txtNewPassword.Validating += txtNewPassword_Validating;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = ImageResources.Number_321;
            pictureBox8.Location = new Point(238, 659);
            pictureBox8.Margin = new Padding(3, 4, 3, 4);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(27, 29);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 74;
            pictureBox8.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 659);
            label4.Name = "label4";
            label4.Size = new Size(153, 18);
            label4.TabIndex = 72;
            label4.Text = "Confirm Password :";
            // 
            // pictureBox9
            // 
            pictureBox9.Image = ImageResources.Number_321;
            pictureBox9.Location = new Point(238, 609);
            pictureBox9.Margin = new Padding(3, 4, 3, 4);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(27, 29);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 75;
            pictureBox9.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(54, 609);
            label5.Name = "label5";
            label5.Size = new Size(128, 18);
            label5.TabIndex = 73;
            label5.Text = "New Password :";
            // 
            // btnSave
            // 
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Image = ImageResources.Save_32;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(829, 788);
            btnSave.Margin = new Padding(5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(152, 51);
            btnSave.TabIndex = 70;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCloseForm
            // 
            btnCloseForm.FlatStyle = FlatStyle.Flat;
            btnCloseForm.Image = ImageResources.Close_321;
            btnCloseForm.ImageAlign = ContentAlignment.MiddleLeft;
            btnCloseForm.Location = new Point(667, 788);
            btnCloseForm.Margin = new Padding(5);
            btnCloseForm.Name = "btnCloseForm";
            btnCloseForm.Size = new Size(152, 51);
            btnCloseForm.TabIndex = 71;
            btnCloseForm.Text = "Close";
            btnCloseForm.UseVisualStyleBackColor = true;
            btnCloseForm.Click += btnCloseForm_Click;
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.BorderStyle = BorderStyle.FixedSingle;
            txtCurrentPassword.Location = new Point(294, 558);
            txtCurrentPassword.Margin = new Padding(3, 4, 3, 4);
            txtCurrentPassword.MaxLength = 40;
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(252, 27);
            txtCurrentPassword.TabIndex = 80;
            txtCurrentPassword.UseSystemPasswordChar = true;
            txtCurrentPassword.Validating += txtCurrentPassword_Validating;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = ImageResources.Number_321;
            pictureBox1.Location = new Point(238, 558);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 29);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 79;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 558);
            label1.Name = "label1";
            label1.Size = new Size(151, 18);
            label1.TabIndex = 78;
            label1.Text = "Current Password :";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ctrApplicationBasicInfoCard1
            // 
            ctrApplicationBasicInfoCard1.Location = new Point(538, 561);
            ctrApplicationBasicInfoCard1.Margin = new Padding(5, 2, 5, 2);
            ctrApplicationBasicInfoCard1.Name = "ctrApplicationBasicInfoCard1";
            ctrApplicationBasicInfoCard1.Size = new Size(8, 8);
            ctrApplicationBasicInfoCard1.TabIndex = 81;
            // 
            // CurrentPasswordVisibility
            // 
            CurrentPasswordVisibility.Image = ImageResources.Vision_Test_32;
            CurrentPasswordVisibility.Location = new Point(575, 558);
            CurrentPasswordVisibility.Margin = new Padding(3, 4, 3, 4);
            CurrentPasswordVisibility.Name = "CurrentPasswordVisibility";
            CurrentPasswordVisibility.Size = new Size(31, 28);
            CurrentPasswordVisibility.SizeMode = PictureBoxSizeMode.StretchImage;
            CurrentPasswordVisibility.TabIndex = 82;
            CurrentPasswordVisibility.TabStop = false;
            CurrentPasswordVisibility.Click += CurrentPasswordVisibility_Click;
            // 
            // NewPasswordVisibility
            // 
            NewPasswordVisibility.ErrorImage = null;
            NewPasswordVisibility.Image = ImageResources.Vision_Test_32;
            NewPasswordVisibility.Location = new Point(575, 608);
            NewPasswordVisibility.Margin = new Padding(3, 4, 3, 4);
            NewPasswordVisibility.Name = "NewPasswordVisibility";
            NewPasswordVisibility.Size = new Size(31, 28);
            NewPasswordVisibility.SizeMode = PictureBoxSizeMode.StretchImage;
            NewPasswordVisibility.TabIndex = 83;
            NewPasswordVisibility.TabStop = false;
            NewPasswordVisibility.Click += NewPasswordVisibility_Click;
            // 
            // ConfirmPasswordVisibility
            // 
            ConfirmPasswordVisibility.Image = ImageResources.Vision_Test_32;
            ConfirmPasswordVisibility.Location = new Point(575, 657);
            ConfirmPasswordVisibility.Margin = new Padding(3, 4, 3, 4);
            ConfirmPasswordVisibility.Name = "ConfirmPasswordVisibility";
            ConfirmPasswordVisibility.Size = new Size(31, 28);
            ConfirmPasswordVisibility.SizeMode = PictureBoxSizeMode.StretchImage;
            ConfirmPasswordVisibility.TabIndex = 84;
            ConfirmPasswordVisibility.TabStop = false;
            ConfirmPasswordVisibility.Click += ConfirmPasswordVisibility_Click;
            // 
            // frmChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(1005, 860);
            Controls.Add(ConfirmPasswordVisibility);
            Controls.Add(NewPasswordVisibility);
            Controls.Add(CurrentPasswordVisibility);
            Controls.Add(ctrApplicationBasicInfoCard1);
            Controls.Add(txtCurrentPassword);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(pictureBox8);
            Controls.Add(label4);
            Controls.Add(pictureBox9);
            Controls.Add(label5);
            Controls.Add(btnSave);
            Controls.Add(btnCloseForm);
            Controls.Add(UserCard);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmChangePassword";
            Text = "Change Password";
            Load += frmChangePassword_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)CurrentPasswordVisibility).EndInit();
            ((System.ComponentModel.ISupportInitialize)NewPasswordVisibility).EndInit();
            ((System.ComponentModel.ISupportInitialize)ConfirmPasswordVisibility).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private UserControls.ctrUserCard UserCard;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private PictureBox ConfirmPasswordVisibility;
        private PictureBox NewPasswordVisibility;
        private PictureBox CurrentPasswordVisibility;
        private ctrApplicationBasicInfoCard ctrApplicationBasicInfoCard1;
    }
}