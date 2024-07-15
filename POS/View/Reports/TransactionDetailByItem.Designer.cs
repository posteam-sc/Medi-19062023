namespace POS
{
    partial class TransactionDetailByItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionDetailByItem));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbRefund = new System.Windows.Forms.RadioButton();
            this.rdbSale = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboSubCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMainCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbList = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboLine = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboProductName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCounterName = new System.Windows.Forms.Label();
            this.cboCounter = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbList.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtTo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtFrom);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(8, 59);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(968, 64);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report Period";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(565, 23);
            this.dtTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(265, 22);
            this.dtTo.TabIndex = 3;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(511, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "To";
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(111, 23);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(265, 22);
            this.dtFrom.TabIndex = 1;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbRefund);
            this.groupBox1.Controls.Add(this.rdbSale);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(968, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Type";
            // 
            // rdbRefund
            // 
            this.rdbRefund.AutoSize = true;
            this.rdbRefund.Location = new System.Drawing.Point(517, 21);
            this.rdbRefund.Margin = new System.Windows.Forms.Padding(4);
            this.rdbRefund.Name = "rdbRefund";
            this.rdbRefund.Size = new System.Drawing.Size(71, 20);
            this.rdbRefund.TabIndex = 1;
            this.rdbRefund.Text = "Refund";
            this.rdbRefund.UseVisualStyleBackColor = true;
            this.rdbRefund.CheckedChanged += new System.EventHandler(this.rdbRefund_CheckedChanged);
            // 
            // rdbSale
            // 
            this.rdbSale.AutoSize = true;
            this.rdbSale.Checked = true;
            this.rdbSale.Location = new System.Drawing.Point(164, 21);
            this.rdbSale.Margin = new System.Windows.Forms.Padding(4);
            this.rdbSale.Name = "rdbSale";
            this.rdbSale.Size = new System.Drawing.Size(56, 20);
            this.rdbSale.TabIndex = 0;
            this.rdbSale.TabStop = true;
            this.rdbSale.Text = "Sale";
            this.rdbSale.UseVisualStyleBackColor = true;
            this.rdbSale.CheckedChanged += new System.EventHandler(this.rdbSale_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboSubCategory);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cboMainCategory);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(8, 204);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(968, 66);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "By Segment";
            // 
            // cboSubCategory
            // 
            this.cboSubCategory.FormattingEnabled = true;
            this.cboSubCategory.Location = new System.Drawing.Point(565, 23);
            this.cboSubCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cboSubCategory.Name = "cboSubCategory";
            this.cboSubCategory.Size = new System.Drawing.Size(285, 24);
            this.cboSubCategory.TabIndex = 3;
            this.cboSubCategory.SelectedIndexChanged += new System.EventHandler(this.cboSubCategory_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Sub-Segment";
            // 
            // cboMainCategory
            // 
            this.cboMainCategory.FormattingEnabled = true;
            this.cboMainCategory.Location = new System.Drawing.Point(111, 23);
            this.cboMainCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cboMainCategory.Name = "cboMainCategory";
            this.cboMainCategory.Size = new System.Drawing.Size(285, 24);
            this.cboMainCategory.TabIndex = 1;
            this.cboMainCategory.SelectedValueChanged += new System.EventHandler(this.cboMainCategory_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Segment";
            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.reportViewer1);
            this.gbList.Location = new System.Drawing.Point(8, 396);
            this.gbList.Margin = new System.Windows.Forms.Padding(4);
            this.gbList.Name = "gbList";
            this.gbList.Padding = new System.Windows.Forms.Padding(4);
            this.gbList.Size = new System.Drawing.Size(1351, 431);
            this.gbList.TabIndex = 8;
            this.gbList.TabStop = false;
            this.gbList.Text = "Sale ";
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS.Reports.TransactionReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(8, 23);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowPrintButton = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(1334, 400);
            this.reportViewer1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboLine);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(8, 279);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(440, 66);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "By Line";
            // 
            // cboLine
            // 
            this.cboLine.FormattingEnabled = true;
            this.cboLine.Location = new System.Drawing.Point(113, 23);
            this.cboLine.Margin = new System.Windows.Forms.Padding(4);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(283, 24);
            this.cboLine.TabIndex = 1;
            this.cboLine.SelectedIndexChanged += new System.EventHandler(this.cboLine_SelectedIndexChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Line";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::POS.Properties.Resources.search_small;
            this.btnSearch.Location = new System.Drawing.Point(876, 357);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 32);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::POS.Properties.Resources.refresh_small;
            this.btnRefresh.Location = new System.Drawing.Point(703, 357);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(113, 32);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboProductName);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(455, 279);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(521, 66);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "By Product Name";
            // 
            // cboProductName
            // 
            this.cboProductName.FormattingEnabled = true;
            this.cboProductName.Location = new System.Drawing.Point(119, 23);
            this.cboProductName.Margin = new System.Windows.Forms.Padding(4);
            this.cboProductName.Name = "cboProductName";
            this.cboProductName.Size = new System.Drawing.Size(328, 24);
            this.cboProductName.TabIndex = 1;
            this.cboProductName.SelectedIndexChanged += new System.EventHandler(this.cboProductName_SelectedIndexChanged);
            this.cboProductName.SelectedValueChanged += new System.EventHandler(this.cboProductName_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Name ";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cboCity);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.lblCounterName);
            this.groupBox6.Controls.Add(this.cboCounter);
            this.groupBox6.Location = new System.Drawing.Point(8, 132);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(968, 63);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Select Counter And City";
            // 
            // cboCity
            // 
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(111, 23);
            this.cboCity.Margin = new System.Windows.Forms.Padding(4);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(257, 24);
            this.cboCity.TabIndex = 1;
            this.cboCity.SelectedValueChanged += new System.EventHandler(this.cboCity_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 27);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "City";
            // 
            // lblCounterName
            // 
            this.lblCounterName.AutoSize = true;
            this.lblCounterName.Location = new System.Drawing.Point(443, 27);
            this.lblCounterName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCounterName.Name = "lblCounterName";
            this.lblCounterName.Size = new System.Drawing.Size(93, 16);
            this.lblCounterName.TabIndex = 2;
            this.lblCounterName.Text = "Counter Name";
            // 
            // cboCounter
            // 
            this.cboCounter.FormattingEnabled = true;
            this.cboCounter.Location = new System.Drawing.Point(565, 23);
            this.cboCounter.Margin = new System.Windows.Forms.Padding(4);
            this.cboCounter.Name = "cboCounter";
            this.cboCounter.Size = new System.Drawing.Size(301, 24);
            this.cboCounter.TabIndex = 3;
            this.cboCounter.SelectedValueChanged += new System.EventHandler(this.cboCounter_SelectedValueChanged);
            // 
            // TransactionDetailByItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(1361, 832);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbList);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TransactionDetailByItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transaction Detail ";
            this.Load += new System.EventHandler(this.TransactionDetailByItem_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbList.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbRefund;
        private System.Windows.Forms.RadioButton rdbSale;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboMainCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSubCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox gbList;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboLine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cboProductName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cboCity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCounterName;
        private System.Windows.Forms.ComboBox cboCounter;
    }
}