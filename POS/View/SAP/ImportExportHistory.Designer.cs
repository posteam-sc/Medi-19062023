﻿
namespace POS
{
    partial class ImportExportHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportExportHistory));
            this.dgvImportHistory = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvExportHistory = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.EndDatedateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDatedateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.colBatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLastProcessingDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetails = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colBatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEBatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColELastProcessingDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEDetails = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colEBatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportHistory)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportHistory)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvImportHistory
            // 
            this.dgvImportHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImportHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBatch,
            this.colDateTime,
            this.ColLastProcessingDateTime,
            this.colType,
            this.colStatus,
            this.colDetails,
            this.colBatchID});
            this.dgvImportHistory.Location = new System.Drawing.Point(6, 21);
            this.dgvImportHistory.Name = "dgvImportHistory";
            this.dgvImportHistory.Size = new System.Drawing.Size(853, 147);
            this.dgvImportHistory.TabIndex = 11;
            this.dgvImportHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImportHistory_CellClick);
            this.dgvImportHistory.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvImportHistory_DataBindingComplete);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvImportHistory);
            this.groupBox2.Location = new System.Drawing.Point(43, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(870, 182);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Import History";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvExportHistory);
            this.groupBox3.Location = new System.Drawing.Point(43, 316);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(870, 182);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Export History";
            // 
            // dgvExportHistory
            // 
            this.dgvExportHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExportHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEBatch,
            this.ColEDate,
            this.ColELastProcessingDateTime,
            this.ColEType,
            this.ColEStatus,
            this.colEDetails,
            this.colEBatchID});
            this.dgvExportHistory.Location = new System.Drawing.Point(6, 21);
            this.dgvExportHistory.Name = "dgvExportHistory";
            this.dgvExportHistory.Size = new System.Drawing.Size(853, 147);
            this.dgvExportHistory.TabIndex = 11;
            this.dgvExportHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExportHistory_CellClick);
            this.dgvExportHistory.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvExportHistory_DataBindingComplete);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::POS.Properties.Resources.search_small;
            this.btnSearch.Location = new System.Drawing.Point(562, 5);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 62);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // EndDatedateTimePicker
            // 
            this.EndDatedateTimePicker.Location = new System.Drawing.Point(352, 25);
            this.EndDatedateTimePicker.Name = "EndDatedateTimePicker";
            this.EndDatedateTimePicker.Size = new System.Drawing.Size(199, 20);
            this.EndDatedateTimePicker.TabIndex = 1;
            // 
            // StartDatedateTimePicker
            // 
            this.StartDatedateTimePicker.Location = new System.Drawing.Point(68, 25);
            this.StartDatedateTimePicker.Name = "StartDatedateTimePicker";
            this.StartDatedateTimePicker.Size = new System.Drawing.Size(202, 20);
            this.StartDatedateTimePicker.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "To Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "From Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.EndDatedateTimePicker);
            this.groupBox1.Controls.Add(this.StartDatedateTimePicker);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(19, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 69);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // colBatch
            // 
            this.colBatch.HeaderText = "Import Batch";
            this.colBatch.Name = "colBatch";
            this.colBatch.Width = 170;
            // 
            // colDateTime
            // 
            this.colDateTime.HeaderText = "Processing Date/Time";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.Width = 170;
            // 
            // ColLastProcessingDateTime
            // 
            this.ColLastProcessingDateTime.HeaderText = "Last Processing Date/Time";
            this.ColLastProcessingDateTime.Name = "ColLastProcessingDateTime";
            this.ColLastProcessingDateTime.Width = 170;
            // 
            // colType
            // 
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // colDetails
            // 
            this.colDetails.HeaderText = "";
            this.colDetails.Name = "colDetails";
            this.colDetails.Text = "Detail";
            this.colDetails.UseColumnTextForLinkValue = true;
            // 
            // colBatchID
            // 
            this.colBatchID.HeaderText = "BatchID";
            this.colBatchID.Name = "colBatchID";
            this.colBatchID.Visible = false;
            // 
            // colEBatch
            // 
            this.colEBatch.HeaderText = "Export Batch";
            this.colEBatch.Name = "colEBatch";
            this.colEBatch.Width = 170;
            // 
            // ColEDate
            // 
            this.ColEDate.HeaderText = "Processing Date/Time";
            this.ColEDate.Name = "ColEDate";
            this.ColEDate.Width = 170;
            // 
            // ColELastProcessingDateTime
            // 
            this.ColELastProcessingDateTime.HeaderText = "Last Processing Date/Time";
            this.ColELastProcessingDateTime.Name = "ColELastProcessingDateTime";
            this.ColELastProcessingDateTime.Width = 170;
            // 
            // ColEType
            // 
            this.ColEType.HeaderText = "Type";
            this.ColEType.Name = "ColEType";
            // 
            // ColEStatus
            // 
            this.ColEStatus.HeaderText = "Status";
            this.ColEStatus.Name = "ColEStatus";
            // 
            // colEDetails
            // 
            this.colEDetails.HeaderText = "";
            this.colEDetails.Name = "colEDetails";
            this.colEDetails.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEDetails.Text = "Detail";
            this.colEDetails.UseColumnTextForLinkValue = true;
            // 
            // colEBatchID
            // 
            this.colEBatchID.HeaderText = "BatchID";
            this.colEBatchID.Name = "colEBatchID";
            this.colEBatchID.Visible = false;
            // 
            // ImportExportHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(931, 524);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportExportHistory";
            this.Text = "SAP Export/Import History";
            this.Load += new System.EventHandler(this.ImportExportHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportHistory)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportHistory)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvImportHistory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvExportHistory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker EndDatedateTimePicker;
        private System.Windows.Forms.DateTimePicker StartDatedateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLastProcessingDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewLinkColumn colDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEBatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColELastProcessingDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEStatus;
        private System.Windows.Forms.DataGridViewLinkColumn colEDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEBatchID;
    }
}