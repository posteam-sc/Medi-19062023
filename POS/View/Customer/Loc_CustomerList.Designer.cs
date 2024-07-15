namespace POS
{
    partial class Loc_CustomerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loc_CustomerList));
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoVIP = new System.Windows.Forms.RadioButton();
            this.rdoNonVIP = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoMemberId = new System.Windows.Forms.RadioButton();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.rdoCustomerName = new System.Windows.Forms.RadioButton();
            this.rdoPhoneNumber = new System.Windows.Forms.RadioButton();
            this.rdoEmail = new System.Windows.Forms.RadioButton();
            this.rdoNIRC = new System.Windows.Forms.RadioButton();
            this.dgvCustomerList = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.createdshop = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_fix = new System.Windows.Forms.Button();
            this.groupvipstarted = new System.Windows.Forms.GroupBox();
            this.btnRevoke = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddNewCustomer = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerList)).BeginInit();
            this.groupvipstarted.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.rdoAll.Location = new System.Drawing.Point(28, 46);
            this.rdoAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(110, 20);
            this.rdoAll.TabIndex = 4;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All Customers";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.CheckedChanged += new System.EventHandler(this.rdoAll_CheckedChanged);
            // 
            // rdoVIP
            // 
            this.rdoVIP.AutoSize = true;
            this.rdoVIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.rdoVIP.Location = new System.Drawing.Point(175, 46);
            this.rdoVIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoVIP.Name = "rdoVIP";
            this.rdoVIP.Size = new System.Drawing.Size(116, 20);
            this.rdoVIP.TabIndex = 5;
            this.rdoVIP.Text = "VIP Customers";
            this.rdoVIP.UseVisualStyleBackColor = true;
            this.rdoVIP.CheckedChanged += new System.EventHandler(this.rdoVIP_CheckedChanged);
            // 
            // rdoNonVIP
            // 
            this.rdoNonVIP.AutoSize = true;
            this.rdoNonVIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.rdoNonVIP.Location = new System.Drawing.Point(325, 46);
            this.rdoNonVIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoNonVIP.Name = "rdoNonVIP";
            this.rdoNonVIP.Size = new System.Drawing.Size(145, 20);
            this.rdoNonVIP.TabIndex = 6;
            this.rdoNonVIP.Text = "Non-VIP Customers";
            this.rdoNonVIP.UseVisualStyleBackColor = true;
            this.rdoNonVIP.CheckedChanged += new System.EventHandler(this.rdoNonVIP_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoMemberId);
            this.groupBox1.Controls.Add(this.btnClearSearch);
            this.groupBox1.Controls.Add(this.lblSearchTitle);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.rdoCustomerName);
            this.groupBox1.Controls.Add(this.rdoPhoneNumber);
            this.groupBox1.Controls.Add(this.rdoEmail);
            this.groupBox1.Controls.Add(this.rdoNIRC);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(55)))), ((int)(((byte)(46)))));
            this.groupBox1.Location = new System.Drawing.Point(16, 86);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(932, 123);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // rdoMemberId
            // 
            this.rdoMemberId.AutoSize = true;
            this.rdoMemberId.Checked = true;
            this.rdoMemberId.Location = new System.Drawing.Point(45, 38);
            this.rdoMemberId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoMemberId.Name = "rdoMemberId";
            this.rdoMemberId.Size = new System.Drawing.Size(94, 20);
            this.rdoMemberId.TabIndex = 17;
            this.rdoMemberId.TabStop = true;
            this.rdoMemberId.Text = "Member ID";
            this.rdoMemberId.UseVisualStyleBackColor = true;
            this.rdoMemberId.CheckedChanged += new System.EventHandler(this.rdoMemberId_CheckedChanged);
            // 
            // lblSearchTitle
            // 
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Location = new System.Drawing.Point(51, 82);
            this.lblSearchTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(73, 16);
            this.lblSearchTitle.TabIndex = 15;
            this.lblSearchTitle.Text = "Member ID";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(169, 82);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(348, 22);
            this.txtSearch.TabIndex = 5;
            // 
            // rdoCustomerName
            // 
            this.rdoCustomerName.AutoSize = true;
            this.rdoCustomerName.Location = new System.Drawing.Point(192, 38);
            this.rdoCustomerName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoCustomerName.Name = "rdoCustomerName";
            this.rdoCustomerName.Size = new System.Drawing.Size(125, 20);
            this.rdoCustomerName.TabIndex = 0;
            this.rdoCustomerName.Text = "Customer Name";
            this.rdoCustomerName.UseVisualStyleBackColor = true;
            this.rdoCustomerName.CheckedChanged += new System.EventHandler(this.rdoCustomerName_CheckedChanged);
            // 
            // rdoPhoneNumber
            // 
            this.rdoPhoneNumber.AutoSize = true;
            this.rdoPhoneNumber.Location = new System.Drawing.Point(379, 38);
            this.rdoPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoPhoneNumber.Name = "rdoPhoneNumber";
            this.rdoPhoneNumber.Size = new System.Drawing.Size(118, 20);
            this.rdoPhoneNumber.TabIndex = 1;
            this.rdoPhoneNumber.Text = "Phone Number";
            this.rdoPhoneNumber.UseVisualStyleBackColor = true;
            this.rdoPhoneNumber.CheckedChanged += new System.EventHandler(this.rdoPhoneNumber_CheckedChanged);
            // 
            // rdoEmail
            // 
            this.rdoEmail.AutoSize = true;
            this.rdoEmail.Location = new System.Drawing.Point(692, 38);
            this.rdoEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoEmail.Name = "rdoEmail";
            this.rdoEmail.Size = new System.Drawing.Size(62, 20);
            this.rdoEmail.TabIndex = 3;
            this.rdoEmail.Text = "Email";
            this.rdoEmail.UseVisualStyleBackColor = true;
            this.rdoEmail.CheckedChanged += new System.EventHandler(this.rdoEmail_CheckedChanged);
            // 
            // rdoNIRC
            // 
            this.rdoNIRC.AutoSize = true;
            this.rdoNIRC.Location = new System.Drawing.Point(565, 38);
            this.rdoNIRC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoNIRC.Name = "rdoNIRC";
            this.rdoNIRC.Size = new System.Drawing.Size(60, 20);
            this.rdoNIRC.TabIndex = 2;
            this.rdoNIRC.Text = "NRIC";
            this.rdoNIRC.UseVisualStyleBackColor = true;
            this.rdoNIRC.CheckedChanged += new System.EventHandler(this.rdoNIRC_CheckedChanged);
            // 
            // dgvCustomerList
            // 
            this.dgvCustomerList.AllowUserToAddRows = false;
            this.dgvCustomerList.AllowUserToResizeColumns = false;
            this.dgvCustomerList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column10,
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column8,
            this.Column3,
            this.Column9,
            this.Column4});
            this.dgvCustomerList.Location = new System.Drawing.Point(16, 225);
            this.dgvCustomerList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCustomerList.Name = "dgvCustomerList";
            this.dgvCustomerList.RowHeadersWidth = 51;
            this.dgvCustomerList.Size = new System.Drawing.Size(1300, 505);
            this.dgvCustomerList.TabIndex = 8;
            this.dgvCustomerList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerList_CellClick);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Id";
            this.Column6.HeaderText = "ID";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            this.Column6.Width = 125;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "VIPMemberId";
            this.Column10.HeaderText = "MemberId";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Width = 125;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "Customer Name";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 180;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PhoneNumber";
            this.Column2.HeaderText = "Phone Number";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Email";
            this.Column5.HeaderText = "Email";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "NRC";
            this.Column8.HeaderText = "NRIC";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Text = "Detail";
            this.Column3.UseColumnTextForLinkValue = true;
            this.Column3.VisitedLinkColor = System.Drawing.Color.Blue;
            this.Column3.Width = 80;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Text = "Edit";
            this.Column9.UseColumnTextForLinkValue = true;
            this.Column9.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Text = "Delete";
            this.Column4.UseColumnTextForLinkValue = true;
            this.Column4.Width = 80;
            // 
            // createdshop
            // 
            this.createdshop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createdshop.FormattingEnabled = true;
            this.createdshop.Location = new System.Drawing.Point(127, 23);
            this.createdshop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.createdshop.Name = "createdshop";
            this.createdshop.Size = new System.Drawing.Size(271, 25);
            this.createdshop.TabIndex = 9;
            this.createdshop.SelectedIndexChanged += new System.EventHandler(this.createdshop_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "VipStartedIn";
            // 
            // btn_fix
            // 
            this.btn_fix.Location = new System.Drawing.Point(1244, 39);
            this.btn_fix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_fix.Name = "btn_fix";
            this.btn_fix.Size = new System.Drawing.Size(88, 38);
            this.btn_fix.TabIndex = 18;
            this.btn_fix.Text = "Fix Data";
            this.btn_fix.UseVisualStyleBackColor = true;
            this.btn_fix.Click += new System.EventHandler(this.btn_fix_Click);
            // 
            // groupvipstarted
            // 
            this.groupvipstarted.Controls.Add(this.label1);
            this.groupvipstarted.Controls.Add(this.createdshop);
            this.groupvipstarted.Location = new System.Drawing.Point(515, 10);
            this.groupvipstarted.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupvipstarted.Name = "groupvipstarted";
            this.groupvipstarted.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupvipstarted.Size = new System.Drawing.Size(433, 69);
            this.groupvipstarted.TabIndex = 18;
            this.groupvipstarted.TabStop = false;
            this.groupvipstarted.Text = "select shop";
            this.groupvipstarted.Visible = false;
            // 
            // btnRevoke
            // 
            this.btnRevoke.BackColor = System.Drawing.Color.Transparent;
            this.btnRevoke.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnRevoke.FlatAppearance.BorderSize = 0;
            this.btnRevoke.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRevoke.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRevoke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevoke.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRevoke.Image = ((System.Drawing.Image)(resources.GetObject("btnRevoke.Image")));
            this.btnRevoke.Location = new System.Drawing.Point(1032, 133);
            this.btnRevoke.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRevoke.Name = "btnRevoke";
            this.btnRevoke.Size = new System.Drawing.Size(188, 57);
            this.btnRevoke.TabIndex = 19;
            this.btnRevoke.UseVisualStyleBackColor = false;
            this.btnRevoke.Click += new System.EventHandler(this.btnRevoke_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnClearSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnClearSearch.FlatAppearance.BorderSize = 0;
            this.btnClearSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClearSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.Image = global::POS.Properties.Resources.refresh_small;
            this.btnClearSearch.Location = new System.Drawing.Point(659, 74);
            this.btnClearSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(100, 41);
            this.btnClearSearch.TabIndex = 16;
            this.btnClearSearch.UseVisualStyleBackColor = false;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
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
            this.btnSearch.Location = new System.Drawing.Point(533, 74);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 41);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewCustomer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnAddNewCustomer.FlatAppearance.BorderSize = 0;
            this.btnAddNewCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddNewCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddNewCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddNewCustomer.Image = global::POS.Properties.Resources.newcustomer_130x36_;
            this.btnAddNewCustomer.Location = new System.Drawing.Point(1032, 27);
            this.btnAddNewCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(188, 57);
            this.btnAddNewCustomer.TabIndex = 3;
            this.btnAddNewCustomer.UseVisualStyleBackColor = false;
            this.btnAddNewCustomer.Click += new System.EventHandler(this.btnAddNewCustomer_Click);
            // 
            // Loc_CustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(1361, 746);
            this.Controls.Add(this.btnRevoke);
            this.Controls.Add(this.groupvipstarted);
            this.Controls.Add(this.btn_fix);
            this.Controls.Add(this.dgvCustomerList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rdoNonVIP);
            this.Controls.Add(this.rdoVIP);
            this.Controls.Add(this.rdoAll);
            this.Controls.Add(this.btnAddNewCustomer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Loc_CustomerList";
            this.Text = "Customer List";
            this.Load += new System.EventHandler(this.CustomerList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerList)).EndInit();
            this.groupvipstarted.ResumeLayout(false);
            this.groupvipstarted.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewCustomer;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoVIP;
        private System.Windows.Forms.RadioButton rdoNonVIP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rdoCustomerName;
        private System.Windows.Forms.RadioButton rdoPhoneNumber;
        private System.Windows.Forms.RadioButton rdoEmail;
        private System.Windows.Forms.RadioButton rdoNIRC;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.DataGridView dgvCustomerList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewLinkColumn Column3;
        private System.Windows.Forms.DataGridViewLinkColumn Column9;
        private System.Windows.Forms.DataGridViewLinkColumn Column4;
        private System.Windows.Forms.RadioButton rdoMemberId;
        private System.Windows.Forms.ComboBox createdshop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_fix;
        private System.Windows.Forms.GroupBox groupvipstarted;
        private System.Windows.Forms.Button btnRevoke;
    }
}