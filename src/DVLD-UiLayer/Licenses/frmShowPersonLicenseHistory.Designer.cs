namespace DVLD_UiLayer.Licenses
{
    partial class frmShowPersonLicenseHistory
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrDriverLicenses = new DVLD_UiLayer.UserControls.ctrDriverLicenses();
            this.ctrPersonCardWithFilter = new DVLD_UiLayer.ctrPersonCardWithFilter();
            this.btnCloseForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_UiLayer.ImageResources.PersonLicenseHistory_512;
            this.pictureBox1.Location = new System.Drawing.Point(11, 169);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 188);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(357, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 33);
            this.label3.TabIndex = 10;
            this.label3.Text = "Licenses History";
            // 
            // ctrDriverLicenses
            // 
            this.ctrDriverLicenses.Location = new System.Drawing.Point(11, 396);
            this.ctrDriverLicenses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctrDriverLicenses.Name = "ctrDriverLicenses";
            this.ctrDriverLicenses.Size = new System.Drawing.Size(901, 293);
            this.ctrDriverLicenses.TabIndex = 13;
            // 
            // ctrPersonCardWithFilter
            // 
            this.ctrPersonCardWithFilter.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ctrPersonCardWithFilter.FilterEnabled = true;
            this.ctrPersonCardWithFilter.Location = new System.Drawing.Point(180, 78);
            this.ctrPersonCardWithFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrPersonCardWithFilter.Name = "ctrPersonCardWithFilter";
            this.ctrPersonCardWithFilter.ShowAddPerson = true;
            this.ctrPersonCardWithFilter.Size = new System.Drawing.Size(732, 313);
            this.ctrPersonCardWithFilter.TabIndex = 12;
            this.ctrPersonCardWithFilter.PersonSelected += new System.EventHandler<DVLD_UiLayer.EventArgsClasses.PersonEventArgs>(this.ctrPersonCardWithFilter_PersonSelected);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Image = global::DVLD_UiLayer.ImageResources.Close_321;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(790, 686);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(114, 33);
            this.btnCloseForm.TabIndex = 14;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // frmShowPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 729);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.ctrDriverLicenses);
            this.Controls.Add(this.ctrPersonCardWithFilter);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmShowPersonLicenseHistory";
            this.Text = "frmLicenseHistory";
            this.Load += new System.EventHandler(this.frmLicenseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private ctrPersonCardWithFilter ctrPersonCardWithFilter;
        private UserControls.ctrDriverLicenses ctrDriverLicenses;
        private System.Windows.Forms.Button btnCloseForm;
    }
}