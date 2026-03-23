namespace DVLD_UiLayer
{
    partial class frmLogin
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
            txtPassword = new MaskedTextBox();
            chkRememberMe = new CheckBox();
            label2 = new Label();
            txtUserName = new TextBox();
            label5 = new Label();
            pictureBox3 = new PictureBox();
            pictureBox9 = new PictureBox();
            btnLogin = new Button();
            pictureBox2 = new PictureBox();
            btnCloseForm = new Button();
            label1 = new Label();
            NewPasswordVisibility = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NewPasswordVisibility).BeginInit();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(935, 304);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(218, 27);
            txtPassword.TabIndex = 76;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // chkRememberMe
            // 
            chkRememberMe.AutoSize = true;
            chkRememberMe.Checked = true;
            chkRememberMe.CheckState = CheckState.Checked;
            chkRememberMe.Location = new Point(935, 382);
            chkRememberMe.Margin = new Padding(3, 4, 3, 4);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.Size = new Size(132, 24);
            chkRememberMe.TabIndex = 75;
            chkRememberMe.Text = "Remember Me.";
            chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            label2.Location = new Point(733, 252);
            label2.Name = "label2";
            label2.Size = new Size(109, 21);
            label2.TabIndex = 71;
            label2.Text = "UserName :";
            // 
            // txtUserName
            // 
            txtUserName.BorderStyle = BorderStyle.FixedSingle;
            txtUserName.Location = new Point(935, 251);
            txtUserName.Margin = new Padding(3, 4, 3, 4);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(218, 27);
            txtUserName.TabIndex = 70;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            label5.Location = new Point(738, 304);
            label5.Name = "label5";
            label5.Size = new Size(104, 21);
            label5.TabIndex = 72;
            label5.Text = "Password :";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = ImageResources.Person_32;
            pictureBox3.Location = new Point(879, 252);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(27, 29);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 73;
            pictureBox3.TabStop = false;
            // 
            // pictureBox9
            // 
            pictureBox9.Image = ImageResources.Number_321;
            pictureBox9.Location = new Point(879, 304);
            pictureBox9.Margin = new Padding(3, 4, 3, 4);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(27, 29);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 74;
            pictureBox9.TabStop = false;
            // 
            // btnLogin
            // 
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Image = ImageResources.sign_in_321;
            btnLogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogin.Location = new Point(1001, 474);
            btnLogin.Margin = new Padding(5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(152, 51);
            btnLogin.TabIndex = 69;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = ImageResources.Login_Screen_Logo;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(672, 760);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // btnCloseForm
            // 
            btnCloseForm.FlatStyle = FlatStyle.Flat;
            btnCloseForm.Image = ImageResources.closeBlack32;
            btnCloseForm.Location = new Point(1181, 16);
            btnCloseForm.Margin = new Padding(5);
            btnCloseForm.Name = "btnCloseForm";
            btnCloseForm.Size = new Size(37, 40);
            btnCloseForm.TabIndex = 77;
            btnCloseForm.UseVisualStyleBackColor = true;
            btnCloseForm.Click += btnCloseForm_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 14.2F, FontStyle.Bold);
            label1.Location = new Point(753, 121);
            label1.Name = "label1";
            label1.Size = new Size(281, 29);
            label1.TabIndex = 78;
            label1.Text = "Login  to your account";
            // 
            // NewPasswordVisibility
            // 
            NewPasswordVisibility.ErrorImage = null;
            NewPasswordVisibility.Image = ImageResources.Vision_Test_32;
            NewPasswordVisibility.Location = new Point(1187, 304);
            NewPasswordVisibility.Margin = new Padding(3, 4, 3, 4);
            NewPasswordVisibility.Name = "NewPasswordVisibility";
            NewPasswordVisibility.Size = new Size(31, 28);
            NewPasswordVisibility.SizeMode = PictureBoxSizeMode.StretchImage;
            NewPasswordVisibility.TabIndex = 86;
            NewPasswordVisibility.TabStop = false;
            NewPasswordVisibility.Click += NewPasswordVisibility_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1238, 761);
            Controls.Add(NewPasswordVisibility);
            Controls.Add(label1);
            Controls.Add(btnCloseForm);
            Controls.Add(txtPassword);
            Controls.Add(chkRememberMe);
            Controls.Add(pictureBox3);
            Controls.Add(label2);
            Controls.Add(pictureBox9);
            Controls.Add(txtUserName);
            Controls.Add(label5);
            Controls.Add(btnLogin);
            Controls.Add(pictureBox2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmLogin";
            Text = "Login";
            Load += frmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)NewPasswordVisibility).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.MaskedTextBox txtPassword;
        private System.Windows.Forms.CheckBox chkRememberMe;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Label label1;
        private PictureBox NewPasswordVisibility;
    }
}