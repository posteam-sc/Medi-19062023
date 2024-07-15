namespace POS
{
    partial class TransactionList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionList));
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dgvTransactionList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbDate = new System.Windows.Forms.GroupBox();
            this.gbId = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdbDate = new System.Windows.Forms.RadioButton();
            this.rdbId = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCounterName = new System.Windows.Forms.Label();
            this.cboCounter = new System.Windows.Forms.ComboBox();
            this.ColTransactionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPaymentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCounter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPoint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColRefund = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColViewDetail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColDeleteCopy = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColExported = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbDate.SuspendLayout();
            this.gbId.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(67, 33);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(233, 21);
            this.dtpFrom.TabIndex = 1;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "To";
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(365, 33);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(233, 21);
            this.dtpTo.TabIndex = 3;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // dgvTransactionList
            // 
            this.dgvTransactionList.AllowUserToAddRows = false;
            this.dgvTransactionList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTransactionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactionList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColTransactionId,
            this.ColType,
            this.ColPaymentMethod,
            this.ColDate,
            this.ColTime,
            this.ColSalesPerson,
            this.ColCounter,
            this.ColAmount,
            this.ColPoint,
            this.ColRefund,
            this.ColViewDetail,
            this.ColDelete,
            this.ColDeleteCopy,
            this.ColExported});
            this.dgvTransactionList.Location = new System.Drawing.Point(12, 43);
            this.dgvTransactionList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTransactionList.Name = "dgvTransactionList";
            this.dgvTransactionList.RowHeadersVisible = false;
            this.dgvTransactionList.Size = new System.Drawing.Size(1168, 335);
            this.dgvTransactionList.TabIndex = 0;
            this.dgvTransactionList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactionList_CellClick);
            this.dgvTransactionList.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvTransactionList_CurrentCellDirtyStateChanged);
            this.dgvTransactionList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTransactionList_DataBindingComplete);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dgvTransactionList);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(21, 174);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1186, 400);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transaction List";
            // 
            // gbDate
            // 
            this.gbDate.BackColor = System.Drawing.Color.Transparent;
            this.gbDate.Controls.Add(this.dtpFrom);
            this.gbDate.Controls.Add(this.label1);
            this.gbDate.Controls.Add(this.dtpTo);
            this.gbDate.Controls.Add(this.label2);
            this.gbDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbDate.Location = new System.Drawing.Point(21, 89);
            this.gbDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDate.Name = "gbDate";
            this.gbDate.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDate.Size = new System.Drawing.Size(615, 77);
            this.gbDate.TabIndex = 2;
            this.gbDate.TabStop = false;
            this.gbDate.Text = "By Date";
            // 
            // gbId
            // 
            this.gbId.BackColor = System.Drawing.Color.Transparent;
            this.gbId.Controls.Add(this.btnSearch);
            this.gbId.Controls.Add(this.txtId);
            this.gbId.Controls.Add(this.label3);
            this.gbId.Enabled = false;
            this.gbId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbId.Location = new System.Drawing.Point(652, 89);
            this.gbId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbId.Name = "gbId";
            this.gbId.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbId.Size = new System.Drawing.Size(530, 77);
            this.gbId.TabIndex = 3;
            this.gbId.TabStop = false;
            this.gbId.Text = "By Transaction Id";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::POS.Properties.Resources.search_small;
            this.btnSearch.Location = new System.Drawing.Point(427, 34);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 31);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(132, 35);
            this.txtId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(283, 21);
            this.txtId.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Transaction Id";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.rdbDate);
            this.groupBox4.Controls.Add(this.rdbId);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox4.Location = new System.Drawing.Point(21, 22);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(615, 59);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search For Type";
            // 
            // rdbDate
            // 
            this.rdbDate.AutoSize = true;
            this.rdbDate.Checked = true;
            this.rdbDate.Location = new System.Drawing.Point(84, 28);
            this.rdbDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbDate.Name = "rdbDate";
            this.rdbDate.Size = new System.Drawing.Size(67, 19);
            this.rdbDate.TabIndex = 0;
            this.rdbDate.TabStop = true;
            this.rdbDate.Text = "By Date";
            this.rdbDate.UseVisualStyleBackColor = true;
            this.rdbDate.CheckedChanged += new System.EventHandler(this.rdbDate_CheckedChanged);
            // 
            // rdbId
            // 
            this.rdbId.AutoSize = true;
            this.rdbId.Location = new System.Drawing.Point(240, 28);
            this.rdbId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbId.Name = "rdbId";
            this.rdbId.Size = new System.Drawing.Size(118, 19);
            this.rdbId.TabIndex = 1;
            this.rdbId.Text = "By Transaction Id";
            this.rdbId.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCounterName);
            this.groupBox2.Controls.Add(this.cboCounter);
            this.groupBox2.Location = new System.Drawing.Point(652, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 59);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Counter ";
            // 
            // lblCounterName
            // 
            this.lblCounterName.AutoSize = true;
            this.lblCounterName.Location = new System.Drawing.Point(18, 30);
            this.lblCounterName.Name = "lblCounterName";
            this.lblCounterName.Size = new System.Drawing.Size(87, 15);
            this.lblCounterName.TabIndex = 0;
            this.lblCounterName.Text = "Counter Name";
            // 
            // cboCounter
            // 
            this.cboCounter.FormattingEnabled = true;
            this.cboCounter.Location = new System.Drawing.Point(132, 25);
            this.cboCounter.Name = "cboCounter";
            this.cboCounter.Size = new System.Drawing.Size(227, 23);
            this.cboCounter.TabIndex = 1;
            this.cboCounter.SelectedValueChanged += new System.EventHandler(this.cboCounter_SelectedValueChanged);
            // 
            // ColTransactionId
            // 
            this.ColTransactionId.HeaderText = "TransactionId";
            this.ColTransactionId.Name = "ColTransactionId";
            // 
            // ColType
            // 
            this.ColType.HeaderText = "Type";
            this.ColType.Name = "ColType";
            this.ColType.Width = 70;
            // 
            // ColPaymentMethod
            // 
            this.ColPaymentMethod.HeaderText = "Payment Method";
            this.ColPaymentMethod.Name = "ColPaymentMethod";
            // 
            // ColDate
            // 
            this.ColDate.HeaderText = "Date";
            this.ColDate.Name = "ColDate";
            this.ColDate.Width = 90;
            // 
            // ColTime
            // 
            this.ColTime.HeaderText = "Time";
            this.ColTime.Name = "ColTime";
            this.ColTime.Width = 70;
            // 
            // ColSalesPerson
            // 
            this.ColSalesPerson.HeaderText = "Sale Person";
            this.ColSalesPerson.Name = "ColSalesPerson";
            this.ColSalesPerson.Width = 120;
            // 
            // ColCounter
            // 
            this.ColCounter.HeaderText = "Counter";
            this.ColCounter.Name = "ColCounter";
            // 
            // ColAmount
            // 
            this.ColAmount.HeaderText = "Amount";
            this.ColAmount.Name = "ColAmount";
            // 
            // ColPoint
            // 
            this.ColPoint.DataPropertyName = "Loc_IsCalculatePoint";
            this.ColPoint.HeaderText = "Calculate Point";
            this.ColPoint.Name = "ColPoint";
            this.ColPoint.Width = 70;
            // 
            // ColRefund
            // 
            this.ColRefund.HeaderText = "";
            this.ColRefund.Name = "ColRefund";
            this.ColRefund.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRefund.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColRefund.Text = "Refund";
            this.ColRefund.UseColumnTextForLinkValue = true;
            this.ColRefund.Width = 70;
            // 
            // ColViewDetail
            // 
            this.ColViewDetail.HeaderText = "";
            this.ColViewDetail.Name = "ColViewDetail";
            this.ColViewDetail.Text = "View Detail";
            this.ColViewDetail.UseColumnTextForLinkValue = true;
            // 
            // ColDelete
            // 
            this.ColDelete.HeaderText = "";
            this.ColDelete.Name = "ColDelete";
            this.ColDelete.Text = "Delete";
            this.ColDelete.UseColumnTextForLinkValue = true;
            this.ColDelete.Width = 70;
            // 
            // ColDeleteCopy
            // 
            this.ColDeleteCopy.HeaderText = "";
            this.ColDeleteCopy.Name = "ColDeleteCopy";
            this.ColDeleteCopy.Text = "Delete&Copy";
            this.ColDeleteCopy.UseColumnTextForLinkValue = true;
            // 
            // ColExported
            // 
            this.ColExported.HeaderText = "IsExported";
            this.ColExported.Name = "ColExported";
            this.ColExported.Visible = false;
            // 
            // TransactionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(1219, 601);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gbId);
            this.Controls.Add(this.gbDate);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TransactionList";
            this.Text = "Transaction List";
            this.Load += new System.EventHandler(this.TransactionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.gbDate.ResumeLayout(false);
            this.gbDate.PerformLayout();
            this.gbId.ResumeLayout(false);
            this.gbId.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DataGridView dgvTransactionList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbDate;
        private System.Windows.Forms.GroupBox gbId;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdbDate;
        private System.Windows.Forms.RadioButton rdbId;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCounterName;
        private System.Windows.Forms.ComboBox cboCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTransactionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPaymentMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColPoint;
        private System.Windows.Forms.DataGridViewLinkColumn ColRefund;
        private System.Windows.Forms.DataGridViewLinkColumn ColViewDetail;
        private System.Windows.Forms.DataGridViewLinkColumn ColDelete;
        private System.Windows.Forms.DataGridViewLinkColumn ColDeleteCopy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExported;
    }
}