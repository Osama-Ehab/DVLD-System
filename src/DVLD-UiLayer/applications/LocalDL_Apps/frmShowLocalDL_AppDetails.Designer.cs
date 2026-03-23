namespace DVLD_UiLayer
{
    partial class frmShowLocalDL_AppDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.LocalDL_AppCard = new DVLD_UiLayer.UserControls.ctrLocalDL_AppCard();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(117, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(455, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local Driving License  Application Deatails";
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Image = global::DVLD_UiLayer.ImageResources.Close_321;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(608, 388);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(114, 33);
            this.btnCloseForm.TabIndex = 5;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // LocalDL_AppCard
            // 
            this.LocalDL_AppCard.Location = new System.Drawing.Point(12, 79);
            this.LocalDL_AppCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LocalDL_AppCard.Name = "LocalDL_AppCard";
            this.LocalDL_AppCard.Size = new System.Drawing.Size(717, 303);
            this.LocalDL_AppCard.TabIndex = 6;
            // 
            // frmShowLocalDL_AppDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 431);
            this.Controls.Add(this.LocalDL_AppCard);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmShowLocalDL_AppDetails";
            this.Text = "_LocalDrivingLicenseApplication Details";
            this.Load += new System.EventHandler(this.frmShowLocalDL_AppDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCloseForm;

        private UserControls.ctrLocalDL_AppCard LocalDL_AppCard;
    }
}