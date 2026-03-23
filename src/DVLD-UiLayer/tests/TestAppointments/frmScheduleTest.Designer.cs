namespace DVLD_UiLayer.TestAppointments
{
    partial class frmScheduleTest
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
            this.ScheduleTestCard = new DVLD_UiLayer.UserControls.ctrlScheduleTest();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ScheduleTestCard
            // 
            this.ScheduleTestCard.Location = new System.Drawing.Point(1, 39);
            this.ScheduleTestCard.Margin = new System.Windows.Forms.Padding(4);
            this.ScheduleTestCard.Name = "ScheduleTestCard";
            this.ScheduleTestCard.Size = new System.Drawing.Size(526, 756);
            this.ScheduleTestCard.TabIndex = 0;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Image = global::DVLD_UiLayer.ImageResources.Close_321;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(192, 803);
            this.btnCloseForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(133, 41);
            this.btnCloseForm.TabIndex = 5;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // frmScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 861);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.ScheduleTestCard);
            this.Name = "frmScheduleTest";
            this.Text = "frmScheduleTest";
            this.Load += new System.EventHandler(this.frmScheduleTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ctrlScheduleTest ScheduleTestCard;
        private System.Windows.Forms.Button btnCloseForm;
    }
}