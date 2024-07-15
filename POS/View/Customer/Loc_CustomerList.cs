using POS.APP_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class Loc_CustomerList : Form
    {
        #region Variables


        //  POSEntities entity = new POSEntities();
        private POSEntities entity = new POSEntities();
        bool start = false;
        int nonVIPId = 0, defaultCus = 0, iBackMonth = 24;
        #endregion


        #region Event

        public Loc_CustomerList()
        {
            InitializeComponent();
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {

            List<Customer> cu = entity.Customers.Where(x => x.VIPMemberId != string.Empty && x.VipStartedShop == null).ToList();
            if (cu.Count > 0)
            {
                btn_fix.Visible = true;

            }
            else
            {
                btn_fix.Visible = false;
            }

            dgvCustomerList.AutoGenerateColumns = false;
            List<APP_Data.Shop> shoplist = new List<APP_Data.Shop>();
            APP_Data.Shop shopobj = new APP_Data.Shop();
            shopobj.ShortCode = "0";
            shopobj.ShopName = "Select";
            shoplist.Add(shopobj);

            List<APP_Data.Shop> shoplistdis = new List<APP_Data.Shop>();

            shoplist.AddRange(entity.Shops.Where(x => x.ShortCode != "-").GroupBy(x => x.ShortCode).Select(x => x.FirstOrDefault()).ToList());
            createdshop.DataSource = shoplist;
            createdshop.DisplayMember = "ShopName";
            createdshop.ValueMember = "ShortCode";
            start = true;
            nonVIPId = entity.CustomerTypes.Where(x => x.TypeName.Equals("NonVIP")).FirstOrDefault().Id;
            defaultCus = entity.Customers.Where(x => x.Name.Equals("Default")).FirstOrDefault().Id;


            LoadData();
            try
            {
                iBackMonth = SettingController.MemberTypeResetBackMonth;
            }
            catch
            {
                MessageBox.Show("An error has occure while getting some setting value, Please contact administrator for assist.");
                this.Close();
            }
        }
        public void RevokeFromCustomersList()
        {
            try
            {
                if (iBackMonth < 1)
                {
                    MessageBox.Show("Require parameter is not provided(Duration)!");
                    return;
                }
                DateTime dtDate = DateTime.Now.AddMonths(0 - iBackMonth);

                DialogResult res = MessageBox.Show("From " + dtDate.ToString("dd-MMMM-yyyy") + ", VIP will be revoked to Non-VIP for those who don't have a transaction.", "Are you sure want to revoke?", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Application.UseWaitCursor = true;
                    btnRevoke.Enabled = false;

                    DateTime dtToday = DateTime.Now.Date;
                    entity = new POSEntities();
                    IQueryable<POS.APP_Data.Transaction> iqTrans = entity.Transactions.Where(x => x.IsDeleted == false && x.IsComplete == true && x.DateTime >= dtDate && x.CustomerId != defaultCus && x.Type=="Sale");
                    IQueryable<POS.APP_Data.Customer> iqc = entity.Customers.Where(x => x.Name != "Default" && x.CustomerTypeId != nonVIPId && (x.LatestRevokeDate == null || x.LatestRevokeDate < dtToday));
                    IQueryable<POS.APP_Data.Transaction> iqTrans_0_2999 = iqTrans.Where(x => x.CustomerId < 3000);
                    IQueryable<POS.APP_Data.Transaction> iqTrans_3000_5999 = iqTrans.Where(x => x.CustomerId >= 3000 && x.CustomerId < 6000);
                    IQueryable<POS.APP_Data.Transaction> iqTrans_6000_8999 = iqTrans.Where(x => x.CustomerId >= 6000 && x.CustomerId < 9000);
                    IQueryable<POS.APP_Data.Transaction> iqTrans_Over_9000 = iqTrans.Where(x => x.CustomerId >= 9000);
                    //IQueryable<POS.APP_Data.Transaction> iqTrans_Over_15000 = iqTrans.Where(x => x.CustomerId >= 15000);
                    foreach (Customer c in iqc.ToList())
                    {
                        if (c != null && c.CustomerTypeId != nonVIPId && c.CustomerTypeId != null && (c.LatestRevokeDate == null || c.LatestRevokeDate < DateTime.Now.Date))
                        {
                            //if(c.Id>=15000)
                            //{
                            //    var iqTrans4Each = iqTrans_Over_15000.Where(x => x.CustomerId == c.Id).FirstOrDefault();
                            //    if (iqTrans4Each == null)
                            //    {
                            //        Utility.InsertRevokeHistoryData(c, nonVIPId, txtNote.Text);
                            //    }
                            //}
                            if (c.Id >= 9000)
                            {
                                var iqTrans4Each = iqTrans_Over_9000.Where(x => x.CustomerId == c.Id).FirstOrDefault();
                                if (iqTrans4Each == null)
                                {
                                    Utility.InsertRevokeHistoryData(c, nonVIPId, "Revoked from customer list control.");
                                }
                            }
                            else if (c.Id >= 6000)
                            {
                                var iqTrans4Each = iqTrans_6000_8999.Where(x => x.CustomerId == c.Id).FirstOrDefault();
                                if (iqTrans4Each == null)
                                {
                                    Utility.InsertRevokeHistoryData(c, nonVIPId, "Revoked from customer list control.");
                                }
                            }
                            else if (c.Id >= 3000)
                            {
                                var iqTrans4Each = iqTrans_3000_5999.Where(x => x.CustomerId == c.Id).FirstOrDefault();
                                if (iqTrans4Each == null)
                                {
                                    Utility.InsertRevokeHistoryData(c, nonVIPId, "Revoked from customer list control.");
                                }
                            }
                            else
                            {
                                var iqTrans4Each = iqTrans_0_2999.Where(x => x.CustomerId == c.Id).FirstOrDefault();
                                if (iqTrans4Each == null)
                                {
                                    Utility.InsertRevokeHistoryData(c, nonVIPId, "Revoked from customer list control.");
                                }
                            }

                        }

                    }
                    //foreach (Customer c in iqc.ToList())
                    //{
                    //    if (c != null && c.CustomerTypeId != nonVIPId && c.CustomerTypeId != null && (c.LatestRevokeDate is null || c.LatestRevokeDate < DateTime.Now.Date))
                    //    {
                    //        var iqTrans4Each = iqTrans.Where(x => x.CustomerId == c.Id).FirstOrDefault();
                    //        if (iqTrans4Each == null)
                    //        {

                    //            Utility.InsertRevokeHistoryData(c, nonVIPId, "Revoked from customer list control.");

                    //        }

                    //    }

                    //    //Application.DoEvents();
                    //}
                    Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                    if (newForm != null)
                    {
                        newForm.ReloadCustomerList();
                    }
                    MessageBox.Show("Revoke process successfully done.");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException, "Revoke process failed with an error!");

            }
            finally
            {
                btnRevoke.Enabled = true;
                Cursor.Current = Cursors.Default;
                Application.UseWaitCursor = false;
            }
        }



        private void rdoVIP_CheckedChanged(object sender, EventArgs e)
        {
            groupvipstarted.Visible = true;

            LoadData();
        }

        private void rdoNonVIP_CheckedChanged(object sender, EventArgs e)
        {
            createdshop.SelectedIndex = 0;
            groupvipstarted.Visible = false;
            LoadData();
        }

        private void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            createdshop.SelectedIndex = 0;
            groupvipstarted.Visible = false;
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void rdoCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            lblSearchTitle.Text = "Customer Name";
        }

        private void rdoPhoneNumber_CheckedChanged(object sender, EventArgs e)
        {
            lblSearchTitle.Text = "Phone Number";
        }

        private void rdoNIRC_CheckedChanged(object sender, EventArgs e)
        {
            lblSearchTitle.Text = "NIRC";
        }

        private void rdoEmail_CheckedChanged(object sender, EventArgs e)
        {
            lblSearchTitle.Text = "Email";
        }
        private void rdoMemberId_CheckedChanged(object sender, EventArgs e)
        {
            lblSearchTitle.Text = "Member ID";
        }
        private void dgvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //View detail information of customer
                if (e.ColumnIndex == 6)
                {
                    if (System.Windows.Forms.Application.OpenForms["CustomerDetail"] != null)
                    {
                        Loc_CustomerDetail newForm = (Loc_CustomerDetail)System.Windows.Forms.Application.OpenForms["CustomerDetail"];
                        newForm.customerId = Convert.ToInt32(dgvCustomerList.Rows[e.RowIndex].Cells[0].Value);
                        newForm.ShowDialog();
                    }
                    else
                    {
                        Loc_CustomerDetail newForm = new Loc_CustomerDetail();
                        newForm.customerId = Convert.ToInt32(dgvCustomerList.Rows[e.RowIndex].Cells[0].Value);
                        newForm.ShowDialog();
                    }
                }
                //Edit this User
                else if (e.ColumnIndex == 7)
                {
                    //Role Management
                    RoleManagementController controller = new RoleManagementController();
                    controller.Load(MemberShip.UserRoleId);
                    if (controller.Customer.EditOrDelete || MemberShip.isAdmin)
                    {
                        NewCustomer form = new NewCustomer();
                        form.isEdit = true;
                        form.Text = "Edit Customer";
                        form.CustomerId = Convert.ToInt32(dgvCustomerList.Rows[e.RowIndex].Cells[0].Value);
                        form.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to edit customer", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                //Delete this User
                else if (e.ColumnIndex == 8)
                {
                    //Role Management
                    RoleManagementController controller = new RoleManagementController();
                    controller.Load(MemberShip.UserRoleId);
                    if (controller.Customer.EditOrDelete || MemberShip.isAdmin)
                    {

                        DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {
                            DataGridViewRow row = dgvCustomerList.Rows[e.RowIndex];
                            Customer cust = (Customer)row.DataBoundItem;
                            cust = (from c in entity.Customers where c.Id == cust.Id select c).FirstOrDefault<Customer>();

                            //Need to recheck
                            if (cust.Transactions.Count > 0)
                            {
                                MessageBox.Show("This customer already made transactions!", "Unable to Delete");
                                return;
                            }
                            else
                            {
                                entity.Customers.Remove(cust);
                                entity.SaveChanges();
                                LoadData();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to delete customer", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
                {
                    Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                    newForm.Clear();
                }
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            lblSearchTitle.Text = "Member ID";
            rdoMemberId.Checked = true;
            LoadData();
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            //Role Management
            RoleManagementController controller = new RoleManagementController();
            controller.Load(MemberShip.UserRoleId);
            if (controller.Customer.Add || MemberShip.isAdmin)
            {

                NewCustomer form = new NewCustomer();
                form.isEdit = false;
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("You are not allowed to add new customer", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvCustomerList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvCustomerList.Rows)
            {
                Customer cs = (Customer)row.DataBoundItem;
                row.Cells[5].Value = Loc_CustomerPointSystem.GetPointFromCustomerId(cs.Id).ToString();
            }
        }

        #endregion

        #region Function

        public void updateCustomerPoint()
        {
            foreach (DataGridViewRow row in dgvCustomerList.Rows)
            {
                Customer cs = (Customer)row.DataBoundItem;
                //row.Cells[5].Value = Loc_CustomerPointSystem.GetPointFromCustomerId(cs.Id).ToString();
            }
        }

        public void LoadData()
        {
            List<Customer> customerList = new List<Customer>();
            entity = new POSEntities();
            //Filter By Customer Type
            if (start == true)
            {

                if (rdoAll.Checked)
                {

                    customerList = (from p in entity.Customers select p).ToList();

                }
                else if (rdoVIP.Checked)
                {
                    string selectshop = createdshop.SelectedValue.ToString();
                    customerList = (from p in entity.Customers where ((selectshop == "0" && 1 == 1) || (selectshop != "0" && p.VipStartedShop == selectshop)) && p.CustomerTypeId == 1 select p).ToList();
                }
                else
                {
                    customerList = (from p in entity.Customers where p.CustomerTypeId == 2 select p).ToList();
                }

                //User make a search
                if (txtSearch.Text.Trim() != string.Empty)
                {
                    //Search BY Customer Name
                    if (rdoCustomerName.Checked)
                    {
                        // customerList = customerList.Where(x => x.Name.Trim().ToLower().Contains(txtSearch.Text.Trim().ToLower())).ToList();
                        customerList = (from p in entity.Customers where p.Name.Trim().ToLower().Contains(txtSearch.Text.Trim().ToLower()) select p).ToList();
                    }
                    //Search By Email
                    else if (rdoEmail.Checked)
                    {
                        //  customerList = customerList.Where(x => x.Email.Contains(txtSearch.Text.Trim())).ToList();
                        customerList = (from p in entity.Customers where p.Email.Contains(txtSearch.Text.Trim()) select p).ToList();
                    }
                    //Search BY NIRC
                    else if (rdoNIRC.Checked)
                    {
                        customerList = customerList.Where(x => x.NRC.Contains(txtSearch.Text.Trim())).ToList();
                    }
                    //Search By MemberId
                    else if (rdoMemberId.Checked)
                    {
                        customerList = customerList.Where(x => x.VIPMemberId == txtSearch.Text.Trim()).ToList();
                    }
                    //Search By Phone Number
                    else
                    {
                        customerList = customerList.Where(x => x.PhoneNumber.Contains(txtSearch.Text.Trim())).ToList();
                    }
                }



                dgvCustomerList.DataSource = customerList;
                if (customerList.Count == 0)
                {
                    MessageBox.Show("Item not found!", "Cannot find");
                }
            }

        }

        #endregion

        private void createdshop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_fix_Click(object sender, EventArgs e)
        {
            List<Customer> cu = entity.Customers.Where(x => x.VIPMemberId != "" && x.VipStartedShop == null).ToList();
            refix_Data(cu);
        }

        private void btnRevoke_Click(object sender, EventArgs e)
        {
            RevokeFromCustomersList();
        }

        private void refix_Data(List<Customer> cu)
        {
            foreach (Customer c in cu)
            {

                c.VipStartedShop = c.CustomerCode.Substring(2, 2).ToString();
                entity.Entry(c).State = EntityState.Modified;

            }
            entity.SaveChanges();
        }
    }
}


