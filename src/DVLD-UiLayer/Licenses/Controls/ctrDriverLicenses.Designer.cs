namespace DVLD_UiLayer.UserControls
{
    partial class ctrDriverLicenses
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
            this.gbDriverLicenses = new System.Windows.Forms.GroupBox();
            this.tabControlDriverLicenses = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPLocalDriverLicenses = new System.Windows.Forms.TabPage();
            this._dgvManageLocalDriverLicenses = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLocalDriverLicensesRecordsCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPInternationalDriverLicenses = new System.Windows.Forms.TabPage();
            this._dgvManageInternationlDriverLicenses = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.lblInternationalDriverLicensesRecordsCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbDriverLicenses.SuspendLayout();
            this.tabControlDriverLicenses.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPLocalDriverLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvManageLocalDriverLicenses)).BeginInit();
            this.tabPInternationalDriverLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvManageInternationlDriverLicenses)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDriverLicenses
            // 
            this.gbDriverLicenses.Controls.Add(this.tabControlDriverLicenses);
            this.gbDriverLicenses.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDriverLicenses.Location = new System.Drawing.Point(9, 3);
            this.gbDriverLicenses.Name = "gbDriverLicenses";
            this.gbDriverLicenses.Size = new System.Drawing.Size(1032, 344);
            this.gbDriverLicenses.TabIndex = 0;
            this.gbDriverLicenses.TabStop = false;
            this.gbDriverLicenses.Text = "Driver Licenses";
            // 
            // tabControlDriverLicenses
            // 
            this.tabControlDriverLicenses.ContextMenuStrip = this.contextMenuStrip1;
            this.tabControlDriverLicenses.Controls.Add(this.tabPLocalDriverLicenses);
            this.tabControlDriverLicenses.Controls.Add(this.tabPInternationalDriverLicenses);
            this.tabControlDriverLicenses.Location = new System.Drawing.Point(11, 32);
            this.tabControlDriverLicenses.Name = "tabControlDriverLicenses";
            this.tabControlDriverLicenses.SelectedIndex = 0;
            this.tabControlDriverLicenses.Size = new System.Drawing.Size(1009, 306);
            this.tabControlDriverLicenses.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 30);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD_UiLayer.ImageResources.LocalDriving_License;
            this.showLicenseInfoToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.ShowLicenseInfo_Click);
            // 
            // tabPLocalDriverLicenses
            // 
            this.tabPLocalDriverLicenses.Controls.Add(this._dgvManageLocalDriverLicenses);
            this.tabPLocalDriverLicenses.Controls.Add(this.label2);
            this.tabPLocalDriverLicenses.Controls.Add(this.lblLocalDriverLicensesRecordsCount);
            this.tabPLocalDriverLicenses.Controls.Add(this.label5);
            this.tabPLocalDriverLicenses.Location = new System.Drawing.Point(4, 27);
            this.tabPLocalDriverLicenses.Name = "tabPLocalDriverLicenses";
            this.tabPLocalDriverLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tabPLocalDriverLicenses.Size = new System.Drawing.Size(1001, 275);
            this.tabPLocalDriverLicenses.TabIndex = 0;
            this.tabPLocalDriverLicenses.Text = "Local";
            this.tabPLocalDriverLicenses.UseVisualStyleBackColor = true;
            // 
            // _dgvManageLocalDriverLicenses
            // 
            this._dgvManageLocalDriverLicenses.AllowUserToAddRows = false;
            this._dgvManageLocalDriverLicenses.AllowUserToDeleteRows = false;
            this._dgvManageLocalDriverLicenses.AllowUserToOrderColumns = true;
            this._dgvManageLocalDriverLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvManageLocalDriverLicenses.ContextMenuStrip = this.contextMenuStrip1;
            this._dgvManageLocalDriverLicenses.Location = new System.Drawing.Point(28, 55);
            this._dgvManageLocalDriverLicenses.Name = "_dgvManageLocalDriverLicenses";
            this._dgvManageLocalDriverLicenses.ReadOnly = true;
            this._dgvManageLocalDriverLicenses.RowHeadersWidth = 51;
            this._dgvManageLocalDriverLicenses.RowTemplate.Height = 26;
            this._dgvManageLocalDriverLicenses.Size = new System.Drawing.Size(952, 165);
            this._dgvManageLocalDriverLicenses.TabIndex = 7;
            this._dgvManageLocalDriverLicenses.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "# Records :";
            // 
            // lblLocalDriverLicensesRecordsCount
            // 
            this.lblLocalDriverLicensesRecordsCount.AutoSize = true;
            this.lblLocalDriverLicensesRecordsCount.Location = new System.Drawing.Point(126, 230);
            this.lblLocalDriverLicensesRecordsCount.Name = "lblLocalDriverLicensesRecordsCount";
            this.lblLocalDriverLicensesRecordsCount.Size = new System.Drawing.Size(18, 18);
            this.lblLocalDriverLicensesRecordsCount.TabIndex = 5;
            this.lblLocalDriverLicensesRecordsCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(244, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "International Licenses History :";
            // 
            // tabPInternationalDriverLicenses
            // 
            this.tabPInternationalDriverLicenses.Controls.Add(this._dgvManageInternationlDriverLicenses);
            this.tabPInternationalDriverLicenses.Controls.Add(this.label3);
            this.tabPInternationalDriverLicenses.Controls.Add(this.lblInternationalDriverLicensesRecordsCount);
            this.tabPInternationalDriverLicenses.Controls.Add(this.label1);
            this.tabPInternationalDriverLicenses.Location = new System.Drawing.Point(4, 27);
            this.tabPInternationalDriverLicenses.Name = "tabPInternationalDriverLicenses";
            this.tabPInternationalDriverLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tabPInternationalDriverLicenses.Size = new System.Drawing.Size(1001, 275);
            this.tabPInternationalDriverLicenses.TabIndex = 1;
            this.tabPInternationalDriverLicenses.Text = "International";
            this.tabPInternationalDriverLicenses.UseVisualStyleBackColor = true;
            // 
            // _dgvManageInternationlDriverLicenses
            // 
            this._dgvManageInternationlDriverLicenses.AllowUserToAddRows = false;
            this._dgvManageInternationlDriverLicenses.AllowUserToDeleteRows = false;
            this._dgvManageInternationlDriverLicenses.AllowUserToOrderColumns = true;
            this._dgvManageInternationlDriverLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvManageInternationlDriverLicenses.Location = new System.Drawing.Point(28, 55);
            this._dgvManageInternationlDriverLicenses.Name = "_dgvManageInternationlDriverLicenses";
            this._dgvManageInternationlDriverLicenses.ReadOnly = true;
            this._dgvManageInternationlDriverLicenses.RowHeadersWidth = 51;
            this._dgvManageInternationlDriverLicenses.RowTemplate.Height = 26;
            this._dgvManageInternationlDriverLicenses.Size = new System.Drawing.Size(952, 165);
            this._dgvManageInternationlDriverLicenses.TabIndex = 3;
            this._dgvManageInternationlDriverLicenses.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "# Records :";
            // 
            // lblInternationalDriverLicensesRecordsCount
            // 
            this.lblInternationalDriverLicensesRecordsCount.AutoSize = true;
            this.lblInternationalDriverLicensesRecordsCount.Location = new System.Drawing.Point(126, 230);
            this.lblInternationalDriverLicensesRecordsCount.Name = "lblInternationalDriverLicensesRecordsCount";
            this.lblInternationalDriverLicensesRecordsCount.Size = new System.Drawing.Size(18, 18);
            this.lblInternationalDriverLicensesRecordsCount.TabIndex = 1;
            this.lblInternationalDriverLicensesRecordsCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "International Licenses History :";
            // 
            // ctrDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDriverLicenses);
            this.Name = "ctrDriverLicenses";
            this.Size = new System.Drawing.Size(1051, 361);
            this.gbDriverLicenses.ResumeLayout(false);
            this.tabControlDriverLicenses.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPLocalDriverLicenses.ResumeLayout(false);
            this.tabPLocalDriverLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvManageLocalDriverLicenses)).EndInit();
            this.tabPInternationalDriverLicenses.ResumeLayout(false);
            this.tabPInternationalDriverLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvManageInternationlDriverLicenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDriverLicenses;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabControlDriverLicenses;
        private System.Windows.Forms.TabPage tabPLocalDriverLicenses;
        private System.Windows.Forms.TabPage tabPInternationalDriverLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblInternationalDriverLicensesRecordsCount;
        private System.Windows.Forms.DataGridView _dgvManageInternationlDriverLicenses;
        private System.Windows.Forms.DataGridView _dgvManageLocalDriverLicenses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLocalDriverLicensesRecordsCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
    }
}
