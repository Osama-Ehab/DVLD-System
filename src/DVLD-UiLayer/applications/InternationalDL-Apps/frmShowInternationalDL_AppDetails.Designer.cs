namespace DVLD_UiLayer
{
    partial class frmShowInternationalDL_AppDetails
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
            this.InternationalDL_AppCard = new DVLD_UiLayer.UserControls.ctrInternationalDL_AppCard();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(97, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(674, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "International Driving License  Application Deatails";
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Image = global::DVLD_UiLayer.ImageResources.Close_321;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(701, 344);
            this.btnCloseForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(133, 41);
            this.btnCloseForm.TabIndex = 5;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // InternationalDL_AppCard
            // 
            this.InternationalDL_AppCard.Location = new System.Drawing.Point(14, 97);
            this.InternationalDL_AppCard.Name = "InternationalDL_AppCard";
            this.InternationalDL_AppCard.Size = new System.Drawing.Size(837, 240);
            this.InternationalDL_AppCard.TabIndex = 6;
            // 
            // frmShowInternationalDL_AppDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 393);
            this.Controls.Add(this.InternationalDL_AppCard);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmShowInternationalDL_AppDetails";
            this.Text = "_NewInternationalLicnese Details";
            this.Load += new System.EventHandler(this.LoadInternationalDL_AppData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCloseForm;

        private UserControls.ctrInternationalDL_AppCard InternationalDL_AppCard;
    }
}