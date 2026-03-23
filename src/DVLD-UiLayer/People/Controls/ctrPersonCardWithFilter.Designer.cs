namespace DVLD_UiLayer
{
    partial class ctrPersonCardWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbFilterBy = new System.Windows.Forms.GroupBox();
            this.btnSearchingForAPerson = new System.Windows.Forms.Button();
            this.txtSearchingForAPerson = new System.Windows.Forms.TextBox();
            this.cbFindBy = new System.Windows.Forms.ComboBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.PersonCard = new DVLD_UiLayer.ctrPersonCard();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilterBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilterBy
            // 
            this.gbFilterBy.Controls.Add(this.btnSearchingForAPerson);
            this.gbFilterBy.Controls.Add(this.txtSearchingForAPerson);
            this.gbFilterBy.Controls.Add(this.cbFindBy);
            this.gbFilterBy.Controls.Add(this.btnAddPerson);
            this.gbFilterBy.Controls.Add(this.label1);
            this.gbFilterBy.Location = new System.Drawing.Point(8, 0);
            this.gbFilterBy.Margin = new System.Windows.Forms.Padding(4);
            this.gbFilterBy.Name = "gbFilterBy";
            this.gbFilterBy.Padding = new System.Windows.Forms.Padding(4);
            this.gbFilterBy.Size = new System.Drawing.Size(833, 69);
            this.gbFilterBy.TabIndex = 1;
            this.gbFilterBy.TabStop = false;
            this.gbFilterBy.Text = "Filter";
            // 
            // btnSearchingForAPerson
            // 
            this.btnSearchingForAPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchingForAPerson.Image = global::DVLD_UiLayer.ImageResources.SearchPerson;
            this.btnSearchingForAPerson.Location = new System.Drawing.Point(560, 20);
            this.btnSearchingForAPerson.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchingForAPerson.Name = "btnSearchingForAPerson";
            this.btnSearchingForAPerson.Size = new System.Drawing.Size(43, 38);
            this.btnSearchingForAPerson.TabIndex = 12;
            this.btnSearchingForAPerson.UseVisualStyleBackColor = true;
            this.btnSearchingForAPerson.Click += new System.EventHandler(this.btnSearchingForAPerson_Click);
            // 
            // txtSearchingForAPerson
            // 
            this.txtSearchingForAPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchingForAPerson.Location = new System.Drawing.Point(335, 28);
            this.txtSearchingForAPerson.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchingForAPerson.Name = "txtSearchingForAPerson";
            this.txtSearchingForAPerson.Size = new System.Drawing.Size(210, 24);
            this.txtSearchingForAPerson.TabIndex = 2;
            this.txtSearchingForAPerson.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchingForAPerson_KeyDown);
            this.txtSearchingForAPerson.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchingForAPerson_KeyPress);
            this.txtSearchingForAPerson.Validating += new System.ComponentModel.CancelEventHandler(this.txtSearchingForAPerson_Validating);
            // 
            // cbFilterBy
            // 
            this.cbFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFindBy.FormattingEnabled = true;
            this.cbFindBy.Items.AddRange(new object[] {
            "National No.",
            "Person ID"});
            this.cbFindBy.Location = new System.Drawing.Point(119, 28);
            this.cbFindBy.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbFindBy.Name = "cbFilterBy";
            this.cbFindBy.Size = new System.Drawing.Size(208, 24);
            this.cbFindBy.TabIndex = 11;
            this.cbFindBy.SelectedIndexChanged += new System.EventHandler(this.cbFindBy_SelectedIndexChanged);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPerson.Image = global::DVLD_UiLayer.ImageResources.AddPerson_32;
            this.btnAddPerson.Location = new System.Drawing.Point(610, 20);
            this.btnAddPerson.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(43, 38);
            this.btnAddPerson.TabIndex = 10;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.AddNewPerson_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "Filter By :";
            // 
            // PersonCard
            // 
            this.PersonCard.Location = new System.Drawing.Point(5, 80);
            this.PersonCard.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.PersonCard.Name = "PersonCard";
            this.PersonCard.Size = new System.Drawing.Size(842, 302);
            this.PersonCard.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.gbFilterBy);
            this.Controls.Add(this.PersonCard);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrPersonCardWithFilter";
            this.Size = new System.Drawing.Size(853, 386);
            this.Load += new System.EventHandler(this.ctrPersonCardWithFilter_Load);
            this.gbFilterBy.ResumeLayout(false);
            this.gbFilterBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSearchingForAPerson;
        private System.Windows.Forms.ComboBox cbFindBy;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.GroupBox gbFilterBy;
        public ctrPersonCard PersonCard;
        public System.Windows.Forms.TextBox txtSearchingForAPerson;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
