
namespace POS
{
    partial class DataExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataExport));
            this.lblExportDate = new System.Windows.Forms.Label();
            this.lblExportProgress = new System.Windows.Forms.Label();
            this.ExportProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblExportDate
            // 
            this.lblExportDate.AutoSize = true;
            this.lblExportDate.Location = new System.Drawing.Point(111, 38);
            this.lblExportDate.Name = "lblExportDate";
            this.lblExportDate.Size = new System.Drawing.Size(0, 13);
            this.lblExportDate.TabIndex = 10;
            // 
            // lblExportProgress
            // 
            this.lblExportProgress.AutoSize = true;
            this.lblExportProgress.Location = new System.Drawing.Point(43, 72);
            this.lblExportProgress.Name = "lblExportProgress";
            this.lblExportProgress.Size = new System.Drawing.Size(195, 13);
            this.lblExportProgress.TabIndex = 9;
            this.lblExportProgress.Text = "Exporting Data To SAP! Please Wait.....";
            // 
            // ExportProgressBar
            // 
            this.ExportProgressBar.Location = new System.Drawing.Point(46, 113);
            this.ExportProgressBar.Maximum = 9;
            this.ExportProgressBar.Name = "ExportProgressBar";
            this.ExportProgressBar.Size = new System.Drawing.Size(342, 23);
            this.ExportProgressBar.Step = 1;
            this.ExportProgressBar.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Export Date: ";
            // 
            // DataExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(411, 174);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblExportDate);
            this.Controls.Add(this.lblExportProgress);
            this.Controls.Add(this.ExportProgressBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataExport";
            this.Text = "Data Export";
            this.Load += new System.EventHandler(this.DataExport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExportDate;
        private System.Windows.Forms.Label lblExportProgress;
        private System.Windows.Forms.ProgressBar ExportProgressBar;
        private System.Windows.Forms.Label label1;
    }
}