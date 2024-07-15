namespace POS
{
    partial class ItemList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemList));
            this.dgvItemList = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchDetail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMainCategory = new System.Windows.Forms.ComboBox();
            this.cboSubCategory = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.cboLine = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbBarCode = new System.Windows.Forms.GroupBox();
            this.btnSearch2 = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbBarCode = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).BeginInit();
            this.gbType.SuspendLayout();
            this.gbBarCode.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvItemList
            // 
            this.dgvItemList.AllowUserToAddRows = false;
            this.dgvItemList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column10,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.colBatchDetail,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column11});
            this.dgvItemList.Location = new System.Drawing.Point(40, 247);
            this.dgvItemList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvItemList.Name = "dgvItemList";
            this.dgvItemList.RowHeadersVisible = false;
            this.dgvItemList.RowHeadersWidth = 51;
            this.dgvItemList.Size = new System.Drawing.Size(1339, 528);
            this.dgvItemList.TabIndex = 12;
            this.dgvItemList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemList_CellClick);
            this.dgvItemList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvItemList_DataBindingComplete);
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Id";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Visible = false;
            this.Column9.Width = 125;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "No";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Width = 40;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "SKU";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "Item Name";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Qty";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Unit Price";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Discount Percent";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 120;
            // 
            // colBatchDetail
            // 
            this.colBatchDetail.HeaderText = "";
            this.colBatchDetail.MinimumWidth = 6;
            this.colBatchDetail.Name = "colBatchDetail";
            this.colBatchDetail.Text = "ViewQtyDetail";
            this.colBatchDetail.UseColumnTextForLinkValue = true;
            this.colBatchDetail.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Text = "Edit";
            this.Column6.UseColumnTextForLinkValue = true;
            this.Column6.Visible = false;
            this.Column6.Width = 60;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Text = "Print Barcode";
            this.Column7.UseColumnTextForLinkValue = true;
            this.Column7.Width = 125;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Text = "Delete";
            this.Column8.UseColumnTextForLinkValue = true;
            this.Column8.Visible = false;
            this.Column8.Width = 60;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.Text = "Price Change History";
            this.Column11.UseColumnTextForLinkValue = true;
            this.Column11.Width = 160;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(269, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Segment :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(544, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sub Segment  :";
            // 
            // cboMainCategory
            // 
            this.cboMainCategory.FormattingEnabled = true;
            this.cboMainCategory.Location = new System.Drawing.Point(351, 31);
            this.cboMainCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboMainCategory.Name = "cboMainCategory";
            this.cboMainCategory.Size = new System.Drawing.Size(184, 24);
            this.cboMainCategory.TabIndex = 6;
            this.cboMainCategory.SelectedValueChanged += new System.EventHandler(this.cboMainCategory_SelectedValueChanged);
            // 
            // cboSubCategory
            // 
            this.cboSubCategory.FormattingEnabled = true;
            this.cboSubCategory.Location = new System.Drawing.Point(655, 31);
            this.cboSubCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboSubCategory.Name = "cboSubCategory";
            this.cboSubCategory.Size = new System.Drawing.Size(184, 24);
            this.cboSubCategory.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(933, 31);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(252, 22);
            this.txtName.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(871, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Name :";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::POS.Properties.Resources.search_small;
            this.btnSearch.Location = new System.Drawing.Point(1195, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(119, 55);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = global::POS.Properties.Resources.addnewproduct;
            this.btnAdd.Location = new System.Drawing.Point(1175, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(225, 68);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.cboLine);
            this.gbType.Controls.Add(this.label4);
            this.gbType.Controls.Add(this.cboSubCategory);
            this.gbType.Controls.Add(this.label5);
            this.gbType.Controls.Add(this.label2);
            this.gbType.Controls.Add(this.label3);
            this.gbType.Controls.Add(this.btnSearch);
            this.gbType.Controls.Add(this.txtName);
            this.gbType.Controls.Add(this.cboMainCategory);
            this.gbType.Location = new System.Drawing.Point(40, 143);
            this.gbType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbType.Name = "gbType";
            this.gbType.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbType.Size = new System.Drawing.Size(1328, 70);
            this.gbType.TabIndex = 13;
            this.gbType.TabStop = false;
            this.gbType.Text = "All Type";
            // 
            // cboLine
            // 
            this.cboLine.FormattingEnabled = true;
            this.cboLine.Location = new System.Drawing.Point(76, 31);
            this.cboLine.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(184, 24);
            this.cboLine.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(13, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Line :";
            // 
            // gbBarCode
            // 
            this.gbBarCode.Controls.Add(this.btnSearch2);
            this.gbBarCode.Controls.Add(this.txtBarcode);
            this.gbBarCode.Controls.Add(this.label1);
            this.gbBarCode.Location = new System.Drawing.Point(637, 55);
            this.gbBarCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbBarCode.Name = "gbBarCode";
            this.gbBarCode.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbBarCode.Size = new System.Drawing.Size(545, 64);
            this.gbBarCode.TabIndex = 14;
            this.gbBarCode.TabStop = false;
            this.gbBarCode.Text = "By Product Code";
            // 
            // btnSearch2
            // 
            this.btnSearch2.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnSearch2.FlatAppearance.BorderSize = 0;
            this.btnSearch2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearch2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearch2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch2.Image = global::POS.Properties.Resources.search_small;
            this.btnSearch2.Location = new System.Drawing.Point(396, 10);
            this.btnSearch2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch2.Name = "btnSearch2";
            this.btnSearch2.Size = new System.Drawing.Size(119, 55);
            this.btnSearch2.TabIndex = 11;
            this.btnSearch2.UseVisualStyleBackColor = false;
            this.btnSearch2.Click += new System.EventHandler(this.btnSearch2_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(128, 26);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(184, 22);
            this.txtBarcode.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bar Code";
            // 
            // rdbBarCode
            // 
            this.rdbBarCode.AutoSize = true;
            this.rdbBarCode.Location = new System.Drawing.Point(308, 30);
            this.rdbBarCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbBarCode.Name = "rdbBarCode";
            this.rdbBarCode.Size = new System.Drawing.Size(104, 20);
            this.rdbBarCode.TabIndex = 0;
            this.rdbBarCode.TabStop = true;
            this.rdbBarCode.Text = "By Bar Code";
            this.rdbBarCode.UseVisualStyleBackColor = true;
            this.rdbBarCode.CheckedChanged += new System.EventHandler(this.rdbBarCode_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbAll);
            this.groupBox3.Controls.Add(this.rdbBarCode);
            this.groupBox3.Location = new System.Drawing.Point(40, 55);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(589, 64);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Slect One";
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(85, 30);
            this.rdbAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(97, 20);
            this.rdbAll.TabIndex = 1;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "By All Type";
            this.rdbAll.UseVisualStyleBackColor = true;
            this.rdbAll.CheckedChanged += new System.EventHandler(this.rdbAll_CheckedChanged);
            // 
            // ItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(1403, 831);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbBarCode);
            this.Controls.Add(this.gbType);
            this.Controls.Add(this.dgvItemList);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ItemList";
            this.Text = "Product List";
            this.Load += new System.EventHandler(this.ItemList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).EndInit();
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            this.gbBarCode.ResumeLayout(false);
            this.gbBarCode.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvItemList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMainCategory;
        private System.Windows.Forms.ComboBox cboSubCategory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.GroupBox gbBarCode;
        private System.Windows.Forms.RadioButton rdbBarCode;
        private System.Windows.Forms.Button btnSearch2;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.ComboBox cboLine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewLinkColumn colBatchDetail;
        private System.Windows.Forms.DataGridViewLinkColumn Column6;
        private System.Windows.Forms.DataGridViewLinkColumn Column7;
        private System.Windows.Forms.DataGridViewLinkColumn Column8;
        private System.Windows.Forms.DataGridViewLinkColumn Column11;
    }
}