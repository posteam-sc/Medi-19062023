namespace POS
{
    partial class SaleByRangeAndSegment
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
            this.gbPeriod = new System.Windows.Forms.GroupBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbDisSaleTrueValue = new System.Windows.Forms.RadioButton();
            this.rdbSaleTrueValue = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCounterName = new System.Windows.Forms.Label();
            this.cboCounter = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbPeriod.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPeriod
            // 
            this.gbPeriod.Controls.Add(this.dtTo);
            this.gbPeriod.Controls.Add(this.dtFrom);
            this.gbPeriod.Controls.Add(this.label3);
            this.gbPeriod.Controls.Add(this.label2);
            this.gbPeriod.Location = new System.Drawing.Point(8, 4);
            this.gbPeriod.Margin = new System.Windows.Forms.Padding(4);
            this.gbPeriod.Name = "gbPeriod";
            this.gbPeriod.Padding = new System.Windows.Forms.Padding(4);
            this.gbPeriod.Size = new System.Drawing.Size(924, 63);
            this.gbPeriod.TabIndex = 0;
            this.gbPeriod.TabStop = false;
            this.gbPeriod.Text = "By Period";
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(543, 28);
            this.dtTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(147, 22);
            this.dtTo.TabIndex = 5;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(164, 28);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(145, 22);
            this.dtFrom.TabIndex = 4;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(471, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "From";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbDisSaleTrueValue);
            this.groupBox2.Controls.Add(this.rdbSaleTrueValue);
            this.groupBox2.Location = new System.Drawing.Point(8, 74);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(924, 68);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "By Require Sale Value";
            // 
            // rdbDisSaleTrueValue
            // 
            this.rdbDisSaleTrueValue.AutoSize = true;
            this.rdbDisSaleTrueValue.Location = new System.Drawing.Point(27, 39);
            this.rdbDisSaleTrueValue.Margin = new System.Windows.Forms.Padding(4);
            this.rdbDisSaleTrueValue.Name = "rdbDisSaleTrueValue";
            this.rdbDisSaleTrueValue.Size = new System.Drawing.Size(121, 20);
            this.rdbDisSaleTrueValue.TabIndex = 3;
            this.rdbDisSaleTrueValue.TabStop = true;
            this.rdbDisSaleTrueValue.Text = "Sale True Price";
            this.rdbDisSaleTrueValue.UseVisualStyleBackColor = true;
            this.rdbDisSaleTrueValue.CheckedChanged += new System.EventHandler(this.rdbDisSaleTrueValue_CheckedChanged);
            // 
            // rdbSaleTrueValue
            // 
            this.rdbSaleTrueValue.AutoSize = true;
            this.rdbSaleTrueValue.Location = new System.Drawing.Point(543, 39);
            this.rdbSaleTrueValue.Margin = new System.Windows.Forms.Padding(4);
            this.rdbSaleTrueValue.Name = "rdbSaleTrueValue";
            this.rdbSaleTrueValue.Size = new System.Drawing.Size(85, 20);
            this.rdbSaleTrueValue.TabIndex = 2;
            this.rdbSaleTrueValue.TabStop = true;
            this.rdbSaleTrueValue.Text = "Unit Price";
            this.rdbSaleTrueValue.UseVisualStyleBackColor = true;
            this.rdbSaleTrueValue.CheckedChanged += new System.EventHandler(this.rdbSaleTrueValue_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.reportViewer1);
            this.groupBox3.Location = new System.Drawing.Point(8, 229);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1497, 601);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sale List";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(8, 31);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowPrintButton = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(1477, 562);
            this.reportViewer1.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboCity);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.lblCounterName);
            this.groupBox4.Controls.Add(this.cboCounter);
            this.groupBox4.Location = new System.Drawing.Point(8, 149);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(924, 63);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Select City And Cuounter";
            // 
            // cboCity
            // 
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(97, 23);
            this.cboCity.Margin = new System.Windows.Forms.Padding(4);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(257, 24);
            this.cboCity.TabIndex = 1;
            this.cboCity.SelectedValueChanged += new System.EventHandler(this.cboCity_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 27);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "City";
            // 
            // lblCounterName
            // 
            this.lblCounterName.AutoSize = true;
            this.lblCounterName.Location = new System.Drawing.Point(436, 27);
            this.lblCounterName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCounterName.Name = "lblCounterName";
            this.lblCounterName.Size = new System.Drawing.Size(93, 16);
            this.lblCounterName.TabIndex = 2;
            this.lblCounterName.Text = "Counter Name";
            // 
            // cboCounter
            // 
            this.cboCounter.FormattingEnabled = true;
            this.cboCounter.Location = new System.Drawing.Point(555, 23);
            this.cboCounter.Margin = new System.Windows.Forms.Padding(4);
            this.cboCounter.Name = "cboCounter";
            this.cboCounter.Size = new System.Drawing.Size(301, 24);
            this.cboCounter.TabIndex = 3;
            this.cboCounter.SelectedValueChanged += new System.EventHandler(this.cboCounter_SelectedValueChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(940, 165);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(117, 38);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // SaleByRangeAndSegment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(1509, 832);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbPeriod);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SaleByRangeAndSegment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sale By Range And Segment And SubSegment";
            this.Load += new System.EventHandler(this.SaleByRangeAndSegment_Load);
            this.gbPeriod.ResumeLayout(false);
            this.gbPeriod.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPeriod;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.RadioButton rdbDisSaleTrueValue;
        private System.Windows.Forms.RadioButton rdbSaleTrueValue;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboCity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCounterName;
        private System.Windows.Forms.ComboBox cboCounter;
        private System.Windows.Forms.Button btnSearch;
    }
}