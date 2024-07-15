
namespace POS
{
    partial class ImportExportLogDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportExportLogDetails));
            this.dgvImportExportDetail = new System.Windows.Forms.DataGridView();
            this.colAPIName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJson = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColJsonText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpLogDetails = new System.Windows.Forms.GroupBox();
            this.lblBatchNo = new System.Windows.Forms.Label();
            this.lblBatchLable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportExportDetail)).BeginInit();
            this.grpLogDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvImportExportDetail
            // 
            this.dgvImportExportDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImportExportDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAPIName,
            this.colStatus,
            this.colMessage,
            this.colJson,
            this.ColJsonText});
            this.dgvImportExportDetail.Location = new System.Drawing.Point(14, 25);
            this.dgvImportExportDetail.Name = "dgvImportExportDetail";
            this.dgvImportExportDetail.Size = new System.Drawing.Size(725, 159);
            this.dgvImportExportDetail.TabIndex = 11;
            this.dgvImportExportDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImportExportDetail_CellClick);
            this.dgvImportExportDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvImportExportDetail_DataBindingComplete);
            // 
            // colAPIName
            // 
            this.colAPIName.DataPropertyName = "ProcessName";
            this.colAPIName.HeaderText = "API Name";
            this.colAPIName.Name = "colAPIName";
            this.colAPIName.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "DetailStatus";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 80;
            // 
            // colMessage
            // 
            this.colMessage.DataPropertyName = "ResponseMessageFromSAP";
            this.colMessage.HeaderText = "Response Message From SAP";
            this.colMessage.Name = "colMessage";
            this.colMessage.Width = 350;
            // 
            // colJson
            // 
            this.colJson.HeaderText = "";
            this.colJson.Name = "colJson";
            this.colJson.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colJson.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colJson.Text = "View Json";
            this.colJson.UseColumnTextForLinkValue = true;
            // 
            // ColJsonText
            // 
            this.ColJsonText.DataPropertyName = "PostJson";
            this.ColJsonText.HeaderText = "Json";
            this.ColJsonText.Name = "ColJsonText";
            this.ColJsonText.Visible = false;
            // 
            // grpLogDetails
            // 
            this.grpLogDetails.Controls.Add(this.dgvImportExportDetail);
            this.grpLogDetails.Location = new System.Drawing.Point(12, 78);
            this.grpLogDetails.Name = "grpLogDetails";
            this.grpLogDetails.Size = new System.Drawing.Size(749, 205);
            this.grpLogDetails.TabIndex = 21;
            this.grpLogDetails.TabStop = false;
            this.grpLogDetails.Text = "Import Log Details:";
            // 
            // lblBatchNo
            // 
            this.lblBatchNo.AutoSize = true;
            this.lblBatchNo.Location = new System.Drawing.Point(109, 29);
            this.lblBatchNo.Name = "lblBatchNo";
            this.lblBatchNo.Size = new System.Drawing.Size(0, 13);
            this.lblBatchNo.TabIndex = 23;
            // 
            // lblBatchLable
            // 
            this.lblBatchLable.AutoSize = true;
            this.lblBatchLable.Location = new System.Drawing.Point(12, 29);
            this.lblBatchLable.Name = "lblBatchLable";
            this.lblBatchLable.Size = new System.Drawing.Size(70, 13);
            this.lblBatchLable.TabIndex = 22;
            this.lblBatchLable.Text = "Import Batch:";
            // 
            // ImportExportLogDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(770, 311);
            this.Controls.Add(this.grpLogDetails);
            this.Controls.Add(this.lblBatchNo);
            this.Controls.Add(this.lblBatchLable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportExportLogDetails";
            this.Text = "Import/Export Log Details";
            this.Load += new System.EventHandler(this.ImportExportLogDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportExportDetail)).EndInit();
            this.grpLogDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvImportExportDetail;
        private System.Windows.Forms.GroupBox grpLogDetails;
        private System.Windows.Forms.Label lblBatchNo;
        private System.Windows.Forms.Label lblBatchLable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAPIName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMessage;
        private System.Windows.Forms.DataGridViewLinkColumn colJson;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColJsonText;
    }
}