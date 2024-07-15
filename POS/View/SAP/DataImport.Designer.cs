
namespace POS
{
    partial class DataImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataImport));
            this.lblImportDate = new System.Windows.Forms.Label();
            this.lblImportProgress = new System.Windows.Forms.Label();
            this.ImportProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblImportDate
            // 
            this.lblImportDate.AutoSize = true;
            this.lblImportDate.Location = new System.Drawing.Point(111, 41);
            this.lblImportDate.Name = "lblImportDate";
            this.lblImportDate.Size = new System.Drawing.Size(0, 13);
            this.lblImportDate.TabIndex = 8;
            // 
            // lblImportProgress
            // 
            this.lblImportProgress.AutoSize = true;
            this.lblImportProgress.Location = new System.Drawing.Point(44, 69);
            this.lblImportProgress.Name = "lblImportProgress";
            this.lblImportProgress.Size = new System.Drawing.Size(204, 13);
            this.lblImportProgress.TabIndex = 7;
            this.lblImportProgress.Text = "Importing Data From SAP! Please Wait.....";
            // 
            // ImportProgressBar
            // 
            this.ImportProgressBar.Location = new System.Drawing.Point(47, 110);
            this.ImportProgressBar.Maximum = 9;
            this.ImportProgressBar.Name = "ImportProgressBar";
            this.ImportProgressBar.Size = new System.Drawing.Size(339, 23);
            this.ImportProgressBar.Step = 1;
            this.ImportProgressBar.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Import Date:";
            // 
            // DataImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(411, 174);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblImportDate);
            this.Controls.Add(this.lblImportProgress);
            this.Controls.Add(this.ImportProgressBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataImport";
            this.Text = "Data Import";
            this.Load += new System.EventHandler(this.DataImport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblImportDate;
        private System.Windows.Forms.Label lblImportProgress;
        private System.Windows.Forms.ProgressBar ImportProgressBar;
        private System.Windows.Forms.Label label1;
    }
}