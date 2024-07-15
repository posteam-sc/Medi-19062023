﻿namespace POS
{
    partial class Loc_TransactionList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loc_TransactionList));
            this.rdbId = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdbDate = new System.Windows.Forms.RadioButton();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbId = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbDate = new System.Windows.Forms.GroupBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTransactionList = new System.Windows.Forms.DataGridView();
            this.gbPaymentType = new System.Windows.Forms.GroupBox();
            this.chkTester = new System.Windows.Forms.CheckBox();
            this.chkFOC = new System.Windows.Forms.CheckBox();
            this.chkMPU = new System.Windows.Forms.CheckBox();
            this.chkCredit = new System.Windows.Forms.CheckBox();
            this.chkGiftCard = new System.Windows.Forms.CheckBox();
            this.chkCash = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbSummary = new System.Windows.Forms.RadioButton();
            this.rdbDebt = new System.Windows.Forms.RadioButton();
            this.rdbRefund = new System.Windows.Forms.RadioButton();
            this.rdbSale = new System.Windows.Forms.RadioButton();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.IsExported = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4.SuspendLayout();
            this.gbId.SuspendLayout();
            this.gbDate.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionList)).BeginInit();
            this.gbPaymentType.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbId
            // 
            this.rdbId.AutoSize = true;
            this.rdbId.Location = new System.Drawing.Point(320, 34);
            this.rdbId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdbId.Name = "rdbId";
            this.rdbId.Size = new System.Drawing.Size(139, 21);
            this.rdbId.TabIndex = 2;
            this.rdbId.Text = "By Transaction Id";
            this.rdbId.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.rdbDate);
            this.groupBox4.Controls.Add(this.rdbId);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox4.Location = new System.Drawing.Point(27, 30);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(820, 73);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search For Type";
            // 
            // rdbDate
            // 
            this.rdbDate.AutoSize = true;
            this.rdbDate.Checked = true;
            this.rdbDate.Location = new System.Drawing.Point(112, 34);
            this.rdbDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdbDate.Name = "rdbDate";
            this.rdbDate.Size = new System.Drawing.Size(79, 21);
            this.rdbDate.TabIndex = 1;
            this.rdbDate.TabStop = true;
            this.rdbDate.Text = "By Date";
            this.rdbDate.UseVisualStyleBackColor = true;
            this.rdbDate.CheckedChanged += new System.EventHandler(this.rdbDate_CheckedChanged);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(176, 36);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(376, 22);
            this.txtId.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Transaction Id";
            // 
            // gbId
            // 
            this.gbId.BackColor = System.Drawing.Color.Transparent;
            this.gbId.Controls.Add(this.btnSearch);
            this.gbId.Controls.Add(this.txtId);
            this.gbId.Controls.Add(this.label3);
            this.gbId.Enabled = false;
            this.gbId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbId.Location = new System.Drawing.Point(871, 112);
            this.gbId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbId.Name = "gbId";
            this.gbId.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbId.Size = new System.Drawing.Size(707, 82);
            this.gbId.TabIndex = 11;
            this.gbId.TabStop = false;
            this.gbId.Text = "By Transaction Id";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(569, 28);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 38);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gbDate
            // 
            this.gbDate.BackColor = System.Drawing.Color.Transparent;
            this.gbDate.Controls.Add(this.dtpFrom);
            this.gbDate.Controls.Add(this.label1);
            this.gbDate.Controls.Add(this.dtpTo);
            this.gbDate.Controls.Add(this.label2);
            this.gbDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbDate.Location = new System.Drawing.Point(27, 112);
            this.gbDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbDate.Name = "gbDate";
            this.gbDate.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbDate.Size = new System.Drawing.Size(820, 82);
            this.gbDate.TabIndex = 10;
            this.gbDate.TabStop = false;
            this.gbDate.Text = "By Date";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(91, 38);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(309, 22);
            this.dtpFrom.TabIndex = 3;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(488, 38);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(309, 22);
            this.dtpTo.TabIndex = 4;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "To";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dgvTransactionList);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(27, 274);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1551, 492);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transaction List";
            // 
            // dgvTransactionList
            // 
            this.dgvTransactionList.AllowUserToAddRows = false;
            this.dgvTransactionList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTransactionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactionList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column9,
            this.Column10,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column8,
            this.Column11,
            this.IsExported});
            this.dgvTransactionList.Location = new System.Drawing.Point(16, 53);
            this.dgvTransactionList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvTransactionList.Name = "dgvTransactionList";
            this.dgvTransactionList.RowHeadersVisible = false;
            this.dgvTransactionList.Size = new System.Drawing.Size(1513, 412);
            this.dgvTransactionList.TabIndex = 7;
            this.dgvTransactionList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactionList_CellClick);
            this.dgvTransactionList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTransactionList_DataBindingComplete);
            // 
            // gbPaymentType
            // 
            this.gbPaymentType.Controls.Add(this.chkTester);
            this.gbPaymentType.Controls.Add(this.chkFOC);
            this.gbPaymentType.Controls.Add(this.chkMPU);
            this.gbPaymentType.Controls.Add(this.chkCredit);
            this.gbPaymentType.Controls.Add(this.chkGiftCard);
            this.gbPaymentType.Controls.Add(this.chkCash);
            this.gbPaymentType.Location = new System.Drawing.Point(711, 203);
            this.gbPaymentType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPaymentType.Name = "gbPaymentType";
            this.gbPaymentType.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPaymentType.Size = new System.Drawing.Size(867, 73);
            this.gbPaymentType.TabIndex = 14;
            this.gbPaymentType.TabStop = false;
            this.gbPaymentType.Text = "Report Payment Type";
            // 
            // chkTester
            // 
            this.chkTester.AutoSize = true;
            this.chkTester.Checked = true;
            this.chkTester.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTester.Location = new System.Drawing.Point(783, 25);
            this.chkTester.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkTester.Name = "chkTester";
            this.chkTester.Size = new System.Drawing.Size(71, 21);
            this.chkTester.TabIndex = 6;
            this.chkTester.Text = "Tester";
            this.chkTester.UseVisualStyleBackColor = true;
            // 
            // chkFOC
            // 
            this.chkFOC.AutoSize = true;
            this.chkFOC.Checked = true;
            this.chkFOC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFOC.Location = new System.Drawing.Point(665, 25);
            this.chkFOC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkFOC.Name = "chkFOC";
            this.chkFOC.Size = new System.Drawing.Size(58, 21);
            this.chkFOC.TabIndex = 5;
            this.chkFOC.Text = "FOC";
            this.chkFOC.UseVisualStyleBackColor = true;
            // 
            // chkMPU
            // 
            this.chkMPU.AutoSize = true;
            this.chkMPU.Checked = true;
            this.chkMPU.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMPU.Location = new System.Drawing.Point(380, 25);
            this.chkMPU.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkMPU.Name = "chkMPU";
            this.chkMPU.Size = new System.Drawing.Size(60, 21);
            this.chkMPU.TabIndex = 4;
            this.chkMPU.Text = "MPU";
            this.chkMPU.UseVisualStyleBackColor = true;
            // 
            // chkCredit
            // 
            this.chkCredit.AutoSize = true;
            this.chkCredit.Checked = true;
            this.chkCredit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCredit.Location = new System.Drawing.Point(529, 25);
            this.chkCredit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCredit.Name = "chkCredit";
            this.chkCredit.Size = new System.Drawing.Size(67, 21);
            this.chkCredit.TabIndex = 2;
            this.chkCredit.Text = "Credit";
            this.chkCredit.UseVisualStyleBackColor = true;
            // 
            // chkGiftCard
            // 
            this.chkGiftCard.AutoSize = true;
            this.chkGiftCard.Checked = true;
            this.chkGiftCard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGiftCard.Location = new System.Drawing.Point(221, 25);
            this.chkGiftCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkGiftCard.Name = "chkGiftCard";
            this.chkGiftCard.Size = new System.Drawing.Size(86, 21);
            this.chkGiftCard.TabIndex = 1;
            this.chkGiftCard.Text = "Gift Card";
            this.chkGiftCard.UseVisualStyleBackColor = true;
            // 
            // chkCash
            // 
            this.chkCash.AutoSize = true;
            this.chkCash.Checked = true;
            this.chkCash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCash.Location = new System.Drawing.Point(77, 25);
            this.chkCash.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCash.Name = "chkCash";
            this.chkCash.Size = new System.Drawing.Size(62, 21);
            this.chkCash.TabIndex = 0;
            this.chkCash.Text = "Cash";
            this.chkCash.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbSummary);
            this.groupBox2.Controls.Add(this.rdbDebt);
            this.groupBox2.Controls.Add(this.rdbRefund);
            this.groupBox2.Controls.Add(this.rdbSale);
            this.groupBox2.Location = new System.Drawing.Point(27, 203);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(651, 73);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "By Transaction Type";
            // 
            // rdbSummary
            // 
            this.rdbSummary.AutoSize = true;
            this.rdbSummary.Checked = true;
            this.rdbSummary.Location = new System.Drawing.Point(77, 21);
            this.rdbSummary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbSummary.Name = "rdbSummary";
            this.rdbSummary.Size = new System.Drawing.Size(44, 21);
            this.rdbSummary.TabIndex = 3;
            this.rdbSummary.TabStop = true;
            this.rdbSummary.Text = "All";
            this.rdbSummary.UseVisualStyleBackColor = true;
            this.rdbSummary.CheckedChanged += new System.EventHandler(this.rdbSummary_CheckedChanged);
            // 
            // rdbDebt
            // 
            this.rdbDebt.AutoSize = true;
            this.rdbDebt.Location = new System.Drawing.Point(531, 21);
            this.rdbDebt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbDebt.Name = "rdbDebt";
            this.rdbDebt.Size = new System.Drawing.Size(100, 21);
            this.rdbDebt.TabIndex = 2;
            this.rdbDebt.Text = "Settlement ";
            this.rdbDebt.UseVisualStyleBackColor = true;
            this.rdbDebt.CheckedChanged += new System.EventHandler(this.rdbDebt_CheckedChanged);
            // 
            // rdbRefund
            // 
            this.rdbRefund.AutoSize = true;
            this.rdbRefund.Location = new System.Drawing.Point(384, 21);
            this.rdbRefund.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbRefund.Name = "rdbRefund";
            this.rdbRefund.Size = new System.Drawing.Size(75, 21);
            this.rdbRefund.TabIndex = 1;
            this.rdbRefund.Text = "Refund";
            this.rdbRefund.UseVisualStyleBackColor = true;
            this.rdbRefund.CheckedChanged += new System.EventHandler(this.rdbRefund_CheckedChanged);
            // 
            // rdbSale
            // 
            this.rdbSale.AutoSize = true;
            this.rdbSale.Location = new System.Drawing.Point(251, 21);
            this.rdbSale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbSale.Name = "rdbSale";
            this.rdbSale.Size = new System.Drawing.Size(57, 21);
            this.rdbSale.TabIndex = 0;
            this.rdbSale.Text = "Sale";
            this.rdbSale.UseVisualStyleBackColor = true;
            this.rdbSale.CheckedChanged += new System.EventHandler(this.rdbSale_CheckedChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "TransactionId";
            this.Column1.Name = "Column1";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Type";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Payment Method";
            this.Column10.Name = "Column10";
            this.Column10.Width = 130;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Date";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Time";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Sale Person";
            this.Column4.Name = "Column4";
            this.Column4.Width = 130;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Amount";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column6.Text = "Refund";
            this.Column6.UseColumnTextForLinkValue = true;
            this.Column6.Width = 70;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "";
            this.Column8.Name = "Column8";
            this.Column8.Text = "View Detail";
            this.Column8.UseColumnTextForLinkValue = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "";
            this.Column11.Name = "Column11";
            this.Column11.Text = "Delete";
            this.Column11.UseColumnTextForLinkValue = true;
            this.Column11.Width = 70;
            // 
            // IsExported
            // 
            this.IsExported.DataPropertyName = "IsExported";
            this.IsExported.HeaderText = "IsExported";
            this.IsExported.Name = "IsExported";
            this.IsExported.Visible = false;
            // 
            // Loc_TransactionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(1603, 831);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbPaymentType);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gbId);
            this.Controls.Add(this.gbDate);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Loc_TransactionList";
            this.Text = "Loc_TransactionList";
            this.Load += new System.EventHandler(this.Loc_TransactionList_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbId.ResumeLayout(false);
            this.gbId.PerformLayout();
            this.gbDate.ResumeLayout(false);
            this.gbDate.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionList)).EndInit();
            this.gbPaymentType.ResumeLayout(false);
            this.gbPaymentType.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbId;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdbDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbId;
        private System.Windows.Forms.GroupBox gbDate;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTransactionList;
        private System.Windows.Forms.GroupBox gbPaymentType;
        private System.Windows.Forms.CheckBox chkTester;
        private System.Windows.Forms.CheckBox chkFOC;
        private System.Windows.Forms.CheckBox chkMPU;
        private System.Windows.Forms.CheckBox chkCredit;
        private System.Windows.Forms.CheckBox chkGiftCard;
        private System.Windows.Forms.CheckBox chkCash;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbSummary;
        private System.Windows.Forms.RadioButton rdbDebt;
        private System.Windows.Forms.RadioButton rdbRefund;
        private System.Windows.Forms.RadioButton rdbSale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewLinkColumn Column6;
        private System.Windows.Forms.DataGridViewLinkColumn Column8;
        private System.Windows.Forms.DataGridViewLinkColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsExported;
    }
}