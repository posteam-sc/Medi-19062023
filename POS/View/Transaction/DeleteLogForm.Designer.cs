namespace POS
{
    partial class DeleteLogForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteLogForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDeleteLog = new System.Windows.Forms.DataGridView();
            this.dgvDeleteLogPartial = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCounterName = new System.Windows.Forms.Label();
            this.cboCounter = new System.Windows.Forms.ComboBox();
            this.ColDeletedDate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCounter2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDeleteUser2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTransactionId2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDeletedProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColViewDetail2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColDeletedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCounter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDeletedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoTransactionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColViewDetail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeleteLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeleteLogPartial)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(33, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "By Period";
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(252, 29);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(111, 20);
            this.dtTo.TabIndex = 3;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(83, 29);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(111, 20);
            this.dtFrom.TabIndex = 1;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "From";
            // 
            // dgvDeleteLog
            // 
            this.dgvDeleteLog.AllowUserToAddRows = false;
            this.dgvDeleteLog.AllowUserToDeleteRows = false;
            this.dgvDeleteLog.AllowUserToResizeColumns = false;
            this.dgvDeleteLog.AllowUserToResizeRows = false;
            this.dgvDeleteLog.BackgroundColor = System.Drawing.Color.White;
            this.dgvDeleteLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDeleteLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeleteLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDeletedDate,
            this.ColCounter,
            this.ColDeletedUser,
            this.CoTransactionId,
            this.ColViewDetail});
            this.dgvDeleteLog.Location = new System.Drawing.Point(34, 138);
            this.dgvDeleteLog.Name = "dgvDeleteLog";
            this.dgvDeleteLog.RowHeadersVisible = false;
            this.dgvDeleteLog.Size = new System.Drawing.Size(527, 458);
            this.dgvDeleteLog.TabIndex = 3;
            this.dgvDeleteLog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeleteLog_CellClick);
            this.dgvDeleteLog.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDeleteLog_DataBindingComplete);
            // 
            // dgvDeleteLogPartial
            // 
            this.dgvDeleteLogPartial.AllowDrop = true;
            this.dgvDeleteLogPartial.AllowUserToAddRows = false;
            this.dgvDeleteLogPartial.AllowUserToDeleteRows = false;
            this.dgvDeleteLogPartial.AllowUserToResizeColumns = false;
            this.dgvDeleteLogPartial.AllowUserToResizeRows = false;
            this.dgvDeleteLogPartial.BackgroundColor = System.Drawing.Color.White;
            this.dgvDeleteLogPartial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDeleteLogPartial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeleteLogPartial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDeletedDate2,
            this.ColCounter2,
            this.ColDeleteUser2,
            this.ColTransactionId2,
            this.ColDeletedProduct,
            this.ColQty,
            this.ColViewDetail2});
            this.dgvDeleteLogPartial.Location = new System.Drawing.Point(580, 138);
            this.dgvDeleteLogPartial.Name = "dgvDeleteLogPartial";
            this.dgvDeleteLogPartial.RowHeadersVisible = false;
            this.dgvDeleteLogPartial.Size = new System.Drawing.Size(724, 458);
            this.dgvDeleteLogPartial.TabIndex = 5;
            this.dgvDeleteLogPartial.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeleteLogPartial_CellClick);
            this.dgvDeleteLogPartial.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDeleteLogPartial_DataBindingComplete);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Whole Boucher Delete ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(589, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Partial Delete ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCounterName);
            this.groupBox2.Controls.Add(this.cboCounter);
            this.groupBox2.Location = new System.Drawing.Point(569, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 64);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Counter ";
            // 
            // lblCounterName
            // 
            this.lblCounterName.AutoSize = true;
            this.lblCounterName.Location = new System.Drawing.Point(18, 30);
            this.lblCounterName.Name = "lblCounterName";
            this.lblCounterName.Size = new System.Drawing.Size(75, 13);
            this.lblCounterName.TabIndex = 0;
            this.lblCounterName.Text = "Counter Name";
            // 
            // cboCounter
            // 
            this.cboCounter.FormattingEnabled = true;
            this.cboCounter.Location = new System.Drawing.Point(132, 25);
            this.cboCounter.Name = "cboCounter";
            this.cboCounter.Size = new System.Drawing.Size(227, 21);
            this.cboCounter.TabIndex = 1;
            this.cboCounter.SelectedValueChanged += new System.EventHandler(this.cboCounter_SelectedValueChanged);
            // 
            // ColDeletedDate2
            // 
            this.ColDeletedDate2.DataPropertyName = "DeletedDate";
            this.ColDeletedDate2.HeaderText = "Deleted Date";
            this.ColDeletedDate2.Name = "ColDeletedDate2";
            this.ColDeletedDate2.Width = 120;
            // 
            // ColCounter2
            // 
            this.ColCounter2.HeaderText = "Counter";
            this.ColCounter2.Name = "ColCounter2";
            this.ColCounter2.Width = 80;
            // 
            // ColDeleteUser2
            // 
            this.ColDeleteUser2.HeaderText = "Delete User";
            this.ColDeleteUser2.Name = "ColDeleteUser2";
            // 
            // ColTransactionId2
            // 
            this.ColTransactionId2.DataPropertyName = "TransactionId";
            this.ColTransactionId2.HeaderText = "Transaction ID";
            this.ColTransactionId2.Name = "ColTransactionId2";
            this.ColTransactionId2.Width = 120;
            // 
            // ColDeletedProduct
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColDeletedProduct.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColDeletedProduct.HeaderText = "Deleted Product";
            this.ColDeletedProduct.Name = "ColDeletedProduct";
            this.ColDeletedProduct.Width = 120;
            // 
            // ColQty
            // 
            this.ColQty.HeaderText = "Qty";
            this.ColQty.Name = "ColQty";
            this.ColQty.Width = 50;
            // 
            // ColViewDetail2
            // 
            this.ColViewDetail2.HeaderText = "";
            this.ColViewDetail2.Name = "ColViewDetail2";
            this.ColViewDetail2.Text = "View Detail";
            this.ColViewDetail2.UseColumnTextForLinkValue = true;
            // 
            // ColDeletedDate
            // 
            this.ColDeletedDate.DataPropertyName = "DeletedDate";
            this.ColDeletedDate.HeaderText = "Deleted Date";
            this.ColDeletedDate.Name = "ColDeletedDate";
            this.ColDeletedDate.Width = 120;
            // 
            // ColCounter
            // 
            this.ColCounter.HeaderText = "Counter";
            this.ColCounter.Name = "ColCounter";
            this.ColCounter.Width = 80;
            // 
            // ColDeletedUser
            // 
            this.ColDeletedUser.HeaderText = "Delete User";
            this.ColDeletedUser.Name = "ColDeletedUser";
            // 
            // CoTransactionId
            // 
            this.CoTransactionId.DataPropertyName = "TransactionId";
            this.CoTransactionId.HeaderText = "Transaction ID";
            this.CoTransactionId.Name = "CoTransactionId";
            // 
            // ColViewDetail
            // 
            this.ColViewDetail.HeaderText = "";
            this.ColViewDetail.Name = "ColViewDetail";
            this.ColViewDetail.Text = "View Detail";
            this.ColViewDetail.UseColumnTextForLinkValue = true;
            // 
            // DeleteLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(1339, 649);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDeleteLogPartial);
            this.Controls.Add(this.dgvDeleteLog);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeleteLogForm";
            this.Text = "Delete Log";
            this.Load += new System.EventHandler(this.DeleteLogForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeleteLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeleteLogPartial)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDeleteLog;
        private System.Windows.Forms.DataGridView dgvDeleteLogPartial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCounterName;
        private System.Windows.Forms.ComboBox cboCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDeletedDate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCounter2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDeleteUser2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTransactionId2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDeletedProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQty;
        private System.Windows.Forms.DataGridViewLinkColumn ColViewDetail2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDeletedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDeletedUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoTransactionId;
        private System.Windows.Forms.DataGridViewLinkColumn ColViewDetail;
    }
}