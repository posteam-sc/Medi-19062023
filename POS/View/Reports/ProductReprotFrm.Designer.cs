﻿namespace POS
{
    partial class ProductReprotFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductReprotFrm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtSKUCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboLine = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chkDiscontinous = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboSubCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMainCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reportViewer1);
            this.groupBox1.Location = new System.Drawing.Point(5, 194);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1501, 634);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product List";
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS.Reports.TransactionReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(11, 23);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowPrintButton = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(1482, 603);
            this.reportViewer1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(1, 164);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date:";
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCurrentDate.Location = new System.Drawing.Point(64, 164);
            this.lblCurrentDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(11, 16);
            this.lblCurrentDate.TabIndex = 2;
            this.lblCurrentDate.Text = "-";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtSKUCode);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(5, 9);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(492, 66);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "By Product Code";
            // 
            // txtSKUCode
            // 
            this.txtSKUCode.Location = new System.Drawing.Point(175, 23);
            this.txtSKUCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtSKUCode.Name = "txtSKUCode";
            this.txtSKUCode.Size = new System.Drawing.Size(285, 22);
            this.txtSKUCode.TabIndex = 1;
            this.txtSKUCode.TextChanged += new System.EventHandler(this.txtSKUCode_TextChanged);
            this.txtSKUCode.Enter += new System.EventHandler(this.txtSKUCode_Enter);
            this.txtSKUCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSKUCode_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(52, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "SKU Code";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboLine);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(505, 9);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(417, 66);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "By Line";
            // 
            // cboLine
            // 
            this.cboLine.FormattingEnabled = true;
            this.cboLine.Location = new System.Drawing.Point(116, 20);
            this.cboLine.Margin = new System.Windows.Forms.Padding(4);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(283, 24);
            this.cboLine.TabIndex = 3;
            this.cboLine.SelectedIndexChanged += new System.EventHandler(this.cboLine_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(20, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 2;
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
            this.btnSearch.Location = new System.Drawing.Point(781, 155);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 32);
            this.btnSearch.TabIndex = 13;
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
            this.btnRefresh.Location = new System.Drawing.Point(660, 155);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(113, 32);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chkDiscontinous
            // 
            this.chkDiscontinous.AutoSize = true;
            this.chkDiscontinous.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkDiscontinous.Location = new System.Drawing.Point(279, 166);
            this.chkDiscontinous.Margin = new System.Windows.Forms.Padding(4);
            this.chkDiscontinous.Name = "chkDiscontinous";
            this.chkDiscontinous.Size = new System.Drawing.Size(116, 20);
            this.chkDiscontinous.TabIndex = 14;
            this.chkDiscontinous.Text = "IsDiscontinous";
            this.chkDiscontinous.UseVisualStyleBackColor = true;
            this.chkDiscontinous.CheckedChanged += new System.EventHandler(this.chkDiscontinous_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboSubCategory);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cboMainCategory);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox3.Location = new System.Drawing.Point(5, 82);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(917, 66);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "By Segment";
            // 
            // cboSubCategory
            // 
            this.cboSubCategory.FormattingEnabled = true;
            this.cboSubCategory.Location = new System.Drawing.Point(600, 26);
            this.cboSubCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cboSubCategory.Name = "cboSubCategory";
            this.cboSubCategory.Size = new System.Drawing.Size(285, 24);
            this.cboSubCategory.TabIndex = 6;
            this.cboSubCategory.SelectedIndexChanged += new System.EventHandler(this.cboSubCategory_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(477, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Sub-Segment";
            // 
            // cboMainCategory
            // 
            this.cboMainCategory.FormattingEnabled = true;
            this.cboMainCategory.Location = new System.Drawing.Point(116, 26);
            this.cboMainCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cboMainCategory.Name = "cboMainCategory";
            this.cboMainCategory.Size = new System.Drawing.Size(283, 24);
            this.cboMainCategory.TabIndex = 4;
            this.cboMainCategory.SelectedIndexChanged += new System.EventHandler(this.cboMainCategory_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Segment";
            // 
            // ProductReprotFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(1512, 832);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.chkDiscontinous);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblCurrentDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductReprotFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product";
            this.Load += new System.EventHandler(this.ProductReprotFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentDate;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboLine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSKUCode;
        private System.Windows.Forms.CheckBox chkDiscontinous;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboSubCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMainCategory;
        private System.Windows.Forms.Label label3;
    }
}