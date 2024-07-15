namespace POS
{
    partial class RefundTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RefundTransaction));
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSalePerson = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvItemLists = new System.Windows.Forms.DataGridView();
            this.colRefundCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExported = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMainTransaction = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblChangeGivenTitle = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.lblChangeGiven = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.dgvRedundedList = new System.Windows.Forms.DataGridView();
            this.colRefundId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRefundAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscountAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViewDetail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemLists)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedundedList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(720, 54);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(10, 13);
            this.lblTime.TabIndex = 15;
            this.lblTime.Text = "-";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(720, 25);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(10, 13);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "-";
            // 
            // lblSalePerson
            // 
            this.lblSalePerson.AutoSize = true;
            this.lblSalePerson.Location = new System.Drawing.Point(115, 25);
            this.lblSalePerson.Name = "lblSalePerson";
            this.lblSalePerson.Size = new System.Drawing.Size(10, 13);
            this.lblSalePerson.TabIndex = 13;
            this.lblSalePerson.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(678, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Time :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(678, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Sale Person :";
            // 
            // dgvItemLists
            // 
            this.dgvItemLists.AllowUserToAddRows = false;
            this.dgvItemLists.AllowUserToDeleteRows = false;
            this.dgvItemLists.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvItemLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemLists.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRefundCheck,
            this.colSKU,
            this.colProductName,
            this.colBatchNo,
            this.colQty,
            this.colPrice,
            this.colDiscount,
            this.colTax,
            this.colCost,
            this.colProductId,
            this.ColCount,
            this.ColExported});
            this.dgvItemLists.Location = new System.Drawing.Point(11, 36);
            this.dgvItemLists.Name = "dgvItemLists";
            this.dgvItemLists.Size = new System.Drawing.Size(857, 204);
            this.dgvItemLists.TabIndex = 19;
            this.dgvItemLists.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvItemLists_DataBindingComplete);
            // 
            // colRefundCheck
            // 
            this.colRefundCheck.HeaderText = "Select Refund Product";
            this.colRefundCheck.Name = "colRefundCheck";
            // 
            // colSKU
            // 
            this.colSKU.HeaderText = "SKU";
            this.colSKU.Name = "colSKU";
            this.colSKU.Width = 80;
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "Item Name";
            this.colProductName.Name = "colProductName";
            this.colProductName.Width = 200;
            // 
            // colBatchNo
            // 
            this.colBatchNo.HeaderText = "BatchNo";
            this.colBatchNo.Name = "colBatchNo";
            // 
            // colQty
            // 
            this.colQty.HeaderText = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            this.colQty.Width = 40;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Unit Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 80;
            // 
            // colDiscount
            // 
            this.colDiscount.HeaderText = "Discount Percent";
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.ReadOnly = true;
            this.colDiscount.Width = 55;
            // 
            // colTax
            // 
            this.colTax.HeaderText = "Tax";
            this.colTax.Name = "colTax";
            this.colTax.Width = 55;
            // 
            // colCost
            // 
            this.colCost.HeaderText = "Cost";
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            // 
            // colProductId
            // 
            this.colProductId.HeaderText = "ID";
            this.colProductId.Name = "colProductId";
            this.colProductId.Visible = false;
            // 
            // ColCount
            // 
            this.ColCount.HeaderText = "Count";
            this.ColCount.Name = "ColCount";
            this.ColCount.ReadOnly = true;
            this.ColCount.Visible = false;
            // 
            // ColExported
            // 
            this.ColExported.HeaderText = "IsExported";
            this.ColExported.Name = "ColExported";
            this.ColExported.Visible = false;
            // 
            // lblMainTransaction
            // 
            this.lblMainTransaction.AutoSize = true;
            this.lblMainTransaction.Location = new System.Drawing.Point(142, 54);
            this.lblMainTransaction.Name = "lblMainTransaction";
            this.lblMainTransaction.Size = new System.Drawing.Size(10, 13);
            this.lblMainTransaction.TabIndex = 23;
            this.lblMainTransaction.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Main Transaction :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(394, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cash";
            // 
            // lblChangeGivenTitle
            // 
            this.lblChangeGivenTitle.AutoSize = true;
            this.lblChangeGivenTitle.Location = new System.Drawing.Point(394, 30);
            this.lblChangeGivenTitle.Name = "lblChangeGivenTitle";
            this.lblChangeGivenTitle.Size = new System.Drawing.Size(75, 13);
            this.lblChangeGivenTitle.TabIndex = 1;
            this.lblChangeGivenTitle.Text = "Change Given";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Total";
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Location = new System.Drawing.Point(540, 0);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(10, 13);
            this.lblCash.TabIndex = 3;
            this.lblCash.Text = "-";
            // 
            // lblChangeGiven
            // 
            this.lblChangeGiven.AutoSize = true;
            this.lblChangeGiven.Location = new System.Drawing.Point(540, 30);
            this.lblChangeGiven.Name = "lblChangeGiven";
            this.lblChangeGiven.Size = new System.Drawing.Size(10, 13);
            this.lblChangeGiven.TabIndex = 4;
            this.lblChangeGiven.Text = "-";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(165, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(10, 13);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "-";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.76412F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.23588F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.72611F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.46497F));
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTotal, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblDiscount, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblCash, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblChangeGivenTitle, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblChangeGiven, 3, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(47, 547);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(785, 61);
            this.tableLayoutPanel2.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Discount";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(165, 30);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(10, 13);
            this.lblDiscount.TabIndex = 7;
            this.lblDiscount.Text = "-";
            // 
            // dgvRedundedList
            // 
            this.dgvRedundedList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvRedundedList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRedundedList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRefundId,
            this.colDate,
            this.ColTime,
            this.colRefundAmt,
            this.colDiscountAmt,
            this.colViewDetail});
            this.dgvRedundedList.Location = new System.Drawing.Point(11, 26);
            this.dgvRedundedList.Name = "dgvRedundedList";
            this.dgvRedundedList.Size = new System.Drawing.Size(757, 119);
            this.dgvRedundedList.TabIndex = 26;
            this.dgvRedundedList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRedundedList_CellClick);
            this.dgvRedundedList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRedundedList_DataBindingComplete);
            // 
            // colRefundId
            // 
            this.colRefundId.HeaderText = "Refund Id";
            this.colRefundId.Name = "colRefundId";
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            // 
            // ColTime
            // 
            this.ColTime.HeaderText = "Time";
            this.ColTime.Name = "ColTime";
            // 
            // colRefundAmt
            // 
            this.colRefundAmt.HeaderText = "Refund Amount";
            this.colRefundAmt.Name = "colRefundAmt";
            this.colRefundAmt.Width = 150;
            // 
            // colDiscountAmt
            // 
            this.colDiscountAmt.HeaderText = "Discount Amount";
            this.colDiscountAmt.Name = "colDiscountAmt";
            this.colDiscountAmt.Width = 160;
            // 
            // colViewDetail
            // 
            this.colViewDetail.HeaderText = "";
            this.colViewDetail.Name = "colViewDetail";
            this.colViewDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colViewDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colViewDetail.Text = "View Detail";
            this.colViewDetail.UseColumnTextForLinkValue = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvRedundedList);
            this.groupBox1.Location = new System.Drawing.Point(41, 390);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(791, 151);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Refunded List Of Current Transaction";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvItemLists);
            this.groupBox2.Controls.Add(this.btnSubmit);
            this.groupBox2.Location = new System.Drawing.Point(41, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(868, 296);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "To Refund ";
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Image = global::POS.Properties.Resources.refund_big;
            this.btnSubmit.Location = new System.Drawing.Point(759, 246);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(103, 33);
            this.btnSubmit.TabIndex = 18;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // RefundTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(921, 625);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.lblMainTransaction);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSalePerson);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RefundTransaction";
            this.Text = "Refund Transaction";
            this.Load += new System.EventHandler(this.RefundTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemLists)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedundedList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSalePerson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView dgvItemLists;
        private System.Windows.Forms.Label lblMainTransaction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblChangeGivenTitle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label lblChangeGiven;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.DataGridView dgvRedundedList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRefundId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRefundAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscountAmt;
        private System.Windows.Forms.DataGridViewLinkColumn colViewDetail;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colRefundCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExported;
    }
}