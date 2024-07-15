namespace POS
{
    partial class CreditTransactionList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditTransactionList));
            this.dgvTransactionList = new System.Windows.Forms.DataGridView();
            this.ColTransactionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalePerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefund = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColViewDetail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColExported = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTransactionList
            // 
            this.dgvTransactionList.AllowUserToAddRows = false;
            this.dgvTransactionList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTransactionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactionList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColTransactionId,
            this.ColDate,
            this.ColTime,
            this.ColSalePerson,
            this.ColCustomerName,
            this.ColAmount,
            this.ColRefund,
            this.ColViewDetail,
            this.ColDelete,
            this.ColExported});
            this.dgvTransactionList.Location = new System.Drawing.Point(34, 82);
            this.dgvTransactionList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTransactionList.Name = "dgvTransactionList";
            this.dgvTransactionList.RowHeadersVisible = false;
            this.dgvTransactionList.Size = new System.Drawing.Size(1010, 400);
            this.dgvTransactionList.TabIndex = 9;
            this.dgvTransactionList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactionList_CellClick);
            this.dgvTransactionList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactionList_CellContentClick);
            this.dgvTransactionList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTransactionList_DataBindingComplete);
            // 
            // ColTransactionId
            // 
            this.ColTransactionId.Frozen = true;
            this.ColTransactionId.HeaderText = "TransactionId";
            this.ColTransactionId.Name = "ColTransactionId";
            // 
            // ColDate
            // 
            this.ColDate.Frozen = true;
            this.ColDate.HeaderText = "Date";
            this.ColDate.Name = "ColDate";
            // 
            // ColTime
            // 
            this.ColTime.Frozen = true;
            this.ColTime.HeaderText = "Time";
            this.ColTime.Name = "ColTime";
            // 
            // ColSalePerson
            // 
            this.ColSalePerson.Frozen = true;
            this.ColSalePerson.HeaderText = "Sale Person";
            this.ColSalePerson.Name = "ColSalePerson";
            this.ColSalePerson.Width = 150;
            // 
            // ColCustomerName
            // 
            this.ColCustomerName.Frozen = true;
            this.ColCustomerName.HeaderText = "CustomerName";
            this.ColCustomerName.Name = "ColCustomerName";
            this.ColCustomerName.Width = 150;
            // 
            // ColAmount
            // 
            this.ColAmount.Frozen = true;
            this.ColAmount.HeaderText = "Amount";
            this.ColAmount.Name = "ColAmount";
            // 
            // ColRefund
            // 
            this.ColRefund.Frozen = true;
            this.ColRefund.HeaderText = "";
            this.ColRefund.Name = "ColRefund";
            this.ColRefund.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRefund.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColRefund.Text = "Refund";
            this.ColRefund.UseColumnTextForLinkValue = true;
            this.ColRefund.Width = 80;
            // 
            // ColViewDetail
            // 
            this.ColViewDetail.Frozen = true;
            this.ColViewDetail.HeaderText = "";
            this.ColViewDetail.Name = "ColViewDetail";
            this.ColViewDetail.Text = "View Detail";
            this.ColViewDetail.UseColumnTextForLinkValue = true;
            // 
            // ColDelete
            // 
            this.ColDelete.Frozen = true;
            this.ColDelete.HeaderText = "";
            this.ColDelete.Name = "ColDelete";
            this.ColDelete.Text = "Delete";
            this.ColDelete.UseColumnTextForLinkValue = true;
            // 
            // ColExported
            // 
            this.ColExported.HeaderText = "IsExported";
            this.ColExported.Name = "ColExported";
            this.ColExported.Visible = false;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(399, 35);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(233, 21);
            this.dtpTo.TabIndex = 8;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(353, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "To";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(91, 35);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(233, 21);
            this.dtpFrom.TabIndex = 6;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(30, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "From";
            // 
            // CreditTransactionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(1082, 502);
            this.Controls.Add(this.dgvTransactionList);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CreditTransactionList";
            this.Text = "Credit Transaction List";
            this.Load += new System.EventHandler(this.CreditTransactionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTransactionList;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTransactionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalePerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewLinkColumn ColRefund;
        private System.Windows.Forms.DataGridViewLinkColumn ColViewDetail;
        private System.Windows.Forms.DataGridViewLinkColumn ColDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExported;
    }
}