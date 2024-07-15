using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using POS.APP_Data;
using Microsoft.Reporting.WinForms;
using System.Threading;

namespace POS
{
    public partial class Sales : Form
    {
        #region Variables

        public string mssg = "";

        private POSEntities entity = new POSEntities();

        private Boolean isDraft = false;

        private String DraftId = string.Empty;

        public int CurrentCustomerId = 0;
        bool isload = false;
        DateTime todayDate = DateTime.Today.Date;
        public EventArgs e { get; set; }

        List<TransactionDetail> PList = new List<TransactionDetail>();

        private List<GiftSystem> GiftList = new List<GiftSystem>();
        private List<GiftSystem> GivenGiftList = new List<GiftSystem>();
        public static bool Isduplicate { get; set; }

        //public static bool IsBackDateExportSuccess { get; set; } = true;
        //public static bool IsImportSuccess { get; set; } = true;

        public bool IsBackDateExportSuccess { get; set; }
        public bool IsAutoImportSuccess { get; set; }
        int proCount = 0;
        int nonVIPId = 0;
        public int _rowIndex;
        bool IsBirthday = false, IsDetected = false;
        decimal disRate = 0;
        public static decimal birthdayDiscount = 0;
        static int backMonths4Reset = 24;
        PointDeductionPercentage_History pdp;

        #endregion

        #region Events

        public Sales()
        {
            InitializeComponent();

        }

        List<AvailableProductQtyWithBatch> availablePList = new List<AvailableProductQtyWithBatch>();
        public class AvailableProductQtyWithBatch
        {

            public long ProductID { get; set; }
            public string BatchNo { get; set; }
            public DateTime? ExpireDate { get; set; }
            public int AvailableQty { get; set; }

            public int InUseQty { get; set; }
        }

        public static IQueryable<Product> iTempP { get; set; }

        public static void getCommonProduct()
        {
            POSEntities entity = new POSEntities();
            iTempP = (from p in entity.Products join pd in entity.ProductCategories on p.ProductCategoryId equals pd.Id where !pd.Name.Contains("GWP") select p).Distinct();
        }

        private void BindBatchNo(List<AvailableProductQtyWithBatch> tempProductControlList, DataGridViewComboBoxCell dataGridViewComboBoxCell, string defaultbatch)
        {
            dataGridViewComboBoxCell.Items.Clear();
            tempProductControlList.ForEach(delegate (AvailableProductQtyWithBatch stockIn)
            {
                dataGridViewComboBoxCell.Items.Add(stockIn.BatchNo);
            });
            dataGridViewComboBoxCell.Value = defaultbatch;
        }

        // public static IQueryable<POS.APP_Data.PaymentMethod> iTempPaymentMethod { get; set; }
        public static IQueryable<POS.APP_Data.PaymentType> iTempPaymentMethod { get; set; }
        public static IQueryable<POS.APP_Data.PaymentMethod> iTempSubPaymentMethod { get; set; }
        public static void getCommonPaymentMethod()
        {
            POSEntities entity = new POSEntities();
            //iTempPaymentMethod = entity.PaymentMethods.Where(x => x.PaymentParentId != 0 || x.PaymentParentId == null);
            iTempPaymentMethod = entity.PaymentTypes.Where(x => !x.Name.Contains("Multi") && !x.Name.Contains("Credit"));
            iTempSubPaymentMethod = entity.PaymentMethods.Where(x => (!string.IsNullOrEmpty(x.AccountCode.Trim()) || (string.IsNullOrEmpty(x.AccountCode) && (x.Name == "FOC" || x.Name == "Tester"))));
        }
        public static void getCommonSubPaymentMethod()
        {
            POSEntities entity = new POSEntities();
            iTempSubPaymentMethod = entity.PaymentMethods.Where(x => (!string.IsNullOrEmpty(x.AccountCode.Trim()) || (string.IsNullOrEmpty(x.AccountCode) && (x.Name == "FOC" || x.Name == "Tester"))));
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        private void CheckExported()
        {

            if (!IsBackDateExportSuccess || !IsAutoImportSuccess)
            {
                SalesButtonsControl(false);

            }
            else
            {
                SalesButtonsControl(true);
                if (DataExport.exportStatus == -1)
                {
                    DateTime todayDate = DateTime.Now.Date;
                    bool Unexported = true;
                    // List<Transaction> todayExportedTransactionList = entity.Transactions.Where(x => EntityFunctions.TruncateTime(x.DateTime) == todayDate && x.IsDeleted != true && x.IsExported == true).ToList();
                    ImportExportLog exLog = entity.ImportExportLogs.Where(x => EntityFunctions.TruncateTime(x.ProcessingDateTime) == todayDate && x.Type == "Export").FirstOrDefault();
                    if (exLog != null)
                    {
                        Unexported = false;
                        DataExport.exportStatus = 1;
                    }

                    SalesButtonsControl(Unexported);
                }
                else if (DataExport.exportStatus == 1)
                {
                    SalesButtonsControl(false);
                }

            }

            SAPMenuControl();


        }

        private void SAPMenuControl()
        {
            ((MDIParent)this.ParentForm).importDataToolStripMenuItem.Enabled =
            ((MDIParent)this.ParentForm).importDataByProductToolStripMenuItem.Enabled =
            ((MDIParent)this.ParentForm).importAllDataToolStripMenuItem.Enabled =
            ((MDIParent)this.ParentForm).exportDataToolStripMenuItem.Enabled = IsBackDateExportSuccess;
            ((MDIParent)this.ParentForm).backDateExportToolStripMenuItem.Visible = !IsBackDateExportSuccess;

        }

        private void SalesButtonsControl(bool buttonControl)
        {
            btnPaymentAdd.Enabled = buttonControl;
            btnPaid.Enabled = buttonControl;
            btnSave.Enabled = buttonControl;
            btnLoadDraft.Enabled = buttonControl;
        }


        private void Sales_Load(object sender, EventArgs e)
        {
            this.cboPaymentMethod.TextChanged -= new EventHandler(cboPaymentMethod_TextChanged);
            cboPaymentMethod.SelectedIndexChanged -= cboPaymentMethod_SelectedIndexChanged;
            dgvSearchProductList.AutoGenerateColumns = false;
            if (iTempPaymentMethod == null)
            {
                getCommonPaymentMethod();
            }
            if (iTempSubPaymentMethod == null)
            {
                getCommonSubPaymentMethod();
            }
            cboPaymentMethod.DataSource = iTempPaymentMethod.ToList();//iTempPaymentMethod.Where(x => x.PaymentParentId == null).ToList();

            cboPaymentMethod.DisplayMember = "Name";
            cboPaymentMethod.ValueMember = "Id";

            Thread tLoadProduct = new Thread(LoadProductNameList);
            Thread tLoadCustomer = new Thread(ReLoadCustomer);
            // Set the priority of threads
            tLoadProduct.Priority = ThreadPriority.Normal;
            tLoadCustomer.Priority = ThreadPriority.Highest;

            tLoadCustomer.Start();
            tLoadProduct.Start();

            dgvSalesItem.Focus();
            lblGift.Visible = false;
            plGift.Visible = false;
            isload = false;
            this.cboPaymentMethod.TextChanged += new EventHandler(cboPaymentMethod_TextChanged);
            cboPaymentMethod.SelectedIndexChanged += cboPaymentMethod_SelectedIndexChanged;
            cboPaymentMethod_SelectedIndexChanged(sender, e);
            CheckExported();

            nonVIPId = entity.CustomerTypes.Where(x => x.TypeName.Equals("NonVIP")).FirstOrDefault().Id;
            birthdayDiscount = SettingController.birthday_discount;
            backMonths4Reset = SettingController.MemberTypeResetBackMonth;
            Application.DoEvents();
        }
        delegate void DelReLoadCustomer();

        private void ReLoadCustomer()
        {
            try
            {
                if (this.cboCustomer.InvokeRequired)
                {

                    DelReLoadCustomer d = new DelReLoadCustomer(ReloadCustomerList);
                    this.Invoke(d);
                }
            }
            catch
            {
                // Utility.ShowErrMessage("Sales", "Please restart SQL Server and reopen the mPOS!");
            }
        }

        delegate void DelLoadProductNameList();

        private void LoadProductNameList()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.cboProductName.InvokeRequired)
            {

                DelLoadProductNameList d = new DelLoadProductNameList(LoadProductNameListDe);
                this.Invoke(d);
            }

        }

        private void LoadProductNameListDe()
        {
            List<Product> productList = new List<Product>();
            Product product = new Product();
            product.Id = 0;
            product.Name = "";
            if (iTempP == null)
            {
                getCommonProduct();
            }
            //if (iTempStockFillingFromSAP == null || iTempStockFillingFromSAP.Count() < 1)
            //{
            //    getCommonStockFillingFromSAP();
            //}
            productList.Add(product);//not contain the GWP product when sale
            productList.AddRange(iTempP.ToList());
            cboProductName.DataSource = productList;
            cboProductName.DisplayMember = "Name";
            cboProductName.ValueMember = "Id";
            cboProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProductName.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void dgvSalesItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AvoidAction();
            _rowIndex = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                //Delete
                if (e.ColumnIndex == 9)
                {
                    object deleteProductCode = dgvSalesItem[1, e.RowIndex].Value;

                    //If product code is null, this is just new role without product. Do not need to delete the row.
                    if (deleteProductCode != null)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {
                            if (dgvSalesItem.Rows[e.RowIndex].Cells[(int)sCol.pId].Value == null)
                            {
                                dgvSalesItem.Rows.RemoveAt(e.RowIndex);
                                ListenAction();
                                return;
                            }

                            int currentProductId = Convert.ToInt32(dgvSalesItem.Rows[e.RowIndex].Cells[(int)sCol.pId].Value.ToString());
                            Product pro = iTempP.Where(p => p.Id == currentProductId).FirstOrDefault<Product>();

                            RemoveProductByLineFromDataGrid(pro, dgvSalesItem.Rows[e.RowIndex]);
                            dgvSalesItem.Rows.RemoveAt(e.RowIndex);
                            UpdateTotalCost();
                            dgvSalesItem.CurrentCell = dgvSalesItem[0, e.RowIndex];
                        }
                    }
                    else
                    {
                        try
                        {
                            dgvSalesItem.Rows.RemoveAt(e.RowIndex);
                        }
                        catch { }
                        ListenAction();
                        return;
                    }
                }
                else if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2)
                {
                    dgvSalesItem.CurrentCell = dgvSalesItem.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgvSalesItem.BeginEdit(true);
                }
            }
            ListenAction();
        }
        private void RemoveProductByLineFromDataGrid(Product pro, DataGridViewRow dataGridViewRow)
        {
            try
            {
                if (pro != null)
                {
                    string batchNo = dataGridViewRow.Cells[(int)sCol.BatchNo].Value.ToString();
                    AvailableProductQtyWithBatch newAvList = availablePList.Where(p => p.ProductID == pro.Id && p.BatchNo == batchNo).FirstOrDefault();
                    if (newAvList != null)
                    {
                        newAvList.AvailableQty = newAvList.AvailableQty + newAvList.InUseQty;
                        newAvList.InUseQty = 0;
                    }
                }
            }
            catch { }
        }
        private void dgvSalesItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            AvoidAction();

            _rowIndex = e.RowIndex;
            entity = new POSEntities();
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dgvSalesItem.Rows[e.RowIndex];
                dgvSalesItem.CommitEdit(new DataGridViewDataErrorContexts());
                if (row.Cells[0].Value != null || row.Cells[1].Value != null)
                {
                    //Barcode Change
                    if (e.ColumnIndex == (int)sCol.BarCode)
                    {
                        string currentBarcode = row.Cells[0].Value.ToString();

                        //get current product
                        Product pro = iTempP.Where(p => p.Barcode == currentBarcode).FirstOrDefault<Product>();
                        if (pro != null)
                        {
                            List<AvailableProductQtyWithBatch> tempProductControlList = availablePList == null ? null : availablePList.Where(Product => Product.ProductID == pro.Id).ToList();
                            if (tempProductControlList == null || tempProductControlList.Count == 0)
                            {
                                AddNew4AvailableProductQtyWithBatch(pro.Id, string.Empty);
                            }
                            tempProductControlList = availablePList.Where(Product => Product.ProductID == pro.Id && Product.AvailableQty > 0).OrderBy(p => p.ExpireDate).ToList();

                            if (tempProductControlList != null && tempProductControlList.Count > 0)
                            {
                                //fill the current row with the product information
                                //isload = true;
                                row.Cells[(int)sCol.SKU].Value = pro.ProductCode;
                                row.Cells[(int)sCol.Qty].Value = 1;
                                row.Cells[(int)sCol.ItemName].Value = pro.Name;
                                BindBatchNo(tempProductControlList, row.Cells[(int)sCol.BatchNo] as DataGridViewComboBoxCell, tempProductControlList[0].BatchNo);


                                //row.Cells[(int)sCol.BatchNo].Value = tempProductControl.BatchNo;

                                row.Cells[(int)sCol.SalePrice].Value = pro.Price;
                                if (IsBirthday)
                                {
                                    disRate = birthdayDiscount;
                                }
                                else
                                {
                                    disRate = pro.DiscountRate;
                                }
                                row.Cells[(int)sCol.DisPercent].Value = disRate;
                                row.Cells[(int)sCol.Tax].Value = pro.Tax.TaxPercent;
                                row.Cells[(int)sCol.Cost].Value = getActualCost(pro, disRate);
                                row.Cells[(int)sCol.pId].Value = pro.Id;

                                tempProductControlList[0].AvailableQty -= 1;
                                tempProductControlList[0].InUseQty += 1;
                                if (row.Cells[(int)sCol.BatchNo].Value != null)
                                {
                                    Check_SameProductCode_BatchNo(pro.Id, row.Cells[(int)sCol.BatchNo].Value.ToString());
                                }

                            }
                            else
                            {

                                dgvSalesItem.Rows[e.RowIndex].Cells[(int)sCol.BarCode].Value = null;

                                MessageBox.Show("Product out of stock!");
                                BeginInvoke(new Action(delegate { dgvSalesItem.Rows.Remove(dgvSalesItem.Rows[e.RowIndex]); }));
                            }

                        }
                        else
                        {
                            //remove current row if input have no associate product
                            MessageBox.Show("Wrong item code");
                            mssg = "Wrong";
                            BeginInvoke(new Action(delegate { dgvSalesItem.Rows.Remove(dgvSalesItem.Rows[e.RowIndex]); }));
                        }
                    }
                    //Product Code Change
                    else if (e.ColumnIndex == (int)sCol.SKU)
                    {
                        string currentProductCode = row.Cells[(int)sCol.SKU].Value.ToString();

                        //get current product //not contain the GWP product when sale
                        Product pro = iTempP.Where(p => p.ProductCode == currentProductCode).FirstOrDefault<Product>();
                        if (pro != null)
                        {
                            List<AvailableProductQtyWithBatch> tempProductControlList = availablePList == null ? null : availablePList.Where(Product => Product.ProductID == pro.Id).ToList();
                            if (tempProductControlList == null || tempProductControlList.Count == 0)
                            {
                                AddNew4AvailableProductQtyWithBatch(pro.Id, string.Empty);
                            }
                            tempProductControlList = availablePList.Where(Product => Product.ProductID == pro.Id && Product.AvailableQty > 0).OrderBy(p => p.ExpireDate).ToList();

                            if (tempProductControlList != null && tempProductControlList.Count > 0)
                            {
                                row.Cells[(int)sCol.BarCode].Value = pro.Barcode;
                                row.Cells[(int)sCol.SKU].Value = pro.ProductCode;
                                row.Cells[(int)sCol.Qty].Value = 1;
                                row.Cells[(int)sCol.ItemName].Value = pro.Name;
                                BindBatchNo(tempProductControlList, row.Cells[(int)sCol.BatchNo] as DataGridViewComboBoxCell, tempProductControlList[0].BatchNo);

                                //row.Cells[(int)sCol.BatchNo].Value = tempProductControl.BatchNo;

                                row.Cells[(int)sCol.SalePrice].Value = pro.Price;
                                if (IsBirthday)
                                {
                                    disRate = birthdayDiscount;
                                }
                                else
                                {
                                    disRate = pro.DiscountRate;
                                }
                                row.Cells[(int)sCol.DisPercent].Value = disRate;
                                row.Cells[(int)sCol.Tax].Value = pro.Tax.TaxPercent;
                                row.Cells[(int)sCol.Cost].Value = getActualCost(pro, disRate);
                                row.Cells[(int)sCol.pId].Value = pro.Id;
                                tempProductControlList[0].AvailableQty -= 1;
                                tempProductControlList[0].InUseQty += 1;
                                if (row.Cells[(int)sCol.BatchNo].Value != null)
                                {
                                    Check_SameProductCode_BatchNo(pro.Id, row.Cells[(int)sCol.BatchNo].Value.ToString());
                                }

                            }
                            else
                            {

                                dgvSalesItem.Rows[e.RowIndex].Cells[(int)sCol.SKU].Value = null;

                                MessageBox.Show("Product out of stock!");
                                BeginInvoke(new Action(delegate { dgvSalesItem.Rows.Remove(dgvSalesItem.Rows[e.RowIndex]); }));

                            }

                        }
                        else
                        {
                            //remove current row if input have no associate product
                            MessageBox.Show("Wrong item code");
                            mssg = "Wrong";
                            BeginInvoke(new Action(delegate { dgvSalesItem.Rows.Remove(dgvSalesItem.Rows[e.RowIndex]); }));
                        }

                        //check if current row isn't topmost
                        //  Check_ProductCode_Exist(currentProductCode);


                    }
                    //Qty Changes
                    else if (e.ColumnIndex == (int)sCol.Qty)
                    {
                        int currentQty = 0;
                        decimal DiscountRate = Convert.ToDecimal(row.Cells[(int)sCol.DisPercent].Value);

                        if (isload == true)
                        {

                            string currentProductCode = row.Cells[(int)sCol.SKU].Value.ToString();

                            //get current Project by Id
                            Product pro = iTempP.Where(p => p.ProductCode == currentProductCode).FirstOrDefault<Product>();
                            AvailableProductQtyWithBatch tempProductControl = availablePList == null ? null : availablePList.Where(Product => Product.ProductID == pro.Id).FirstOrDefault();

                            try
                            {
                                //get updated qty
                                currentQty = Convert.ToInt32(row.Cells[(int)sCol.Qty].Value);
                                string BatchNo = row.Cells[(int)sCol.BatchNo].Value.ToString();
                                if (currentQty.ToString() != null && currentQty > 0)
                                {
                                    if (tempProductControl == null)
                                    {
                                        AddNew4AvailableProductQtyWithBatch(pro.Id, string.Empty);
                                    }
                                    tempProductControl = availablePList.Where(Product => Product.ProductID == pro.Id && Product.BatchNo == BatchNo).OrderBy(p => p.ExpireDate).FirstOrDefault();

                                    if (currentQty > (tempProductControl.AvailableQty + tempProductControl.InUseQty))
                                    {
                                        MessageBox.Show("Input quantity is greater than available quantity!");

                                        tempProductControl.InUseQty = tempProductControl.InUseQty + tempProductControl.AvailableQty;
                                        tempProductControl.AvailableQty = 0;

                                        row.Cells[(int)sCol.Qty].Value = tempProductControl.InUseQty.ToString();
                                        currentQty = tempProductControl.InUseQty;


                                    }
                                    else
                                    {
                                        tempProductControl.AvailableQty -= currentQty - tempProductControl.InUseQty;
                                        tempProductControl.InUseQty = currentQty;

                                    }
                                }
                                else
                                {
                                    row.Cells[(int)sCol.Qty].Value = "1";
                                    row.Cells[(int)sCol.Cost].Value = getActualCost(pro, DiscountRate);
                                    tempProductControl.AvailableQty -= 1 - tempProductControl.InUseQty;
                                    tempProductControl.InUseQty = 1;
                                    currentQty = 1;
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Input quantity have invalid keywords.");
                                row.Cells[(int)sCol.Qty].Value = "1";
                                tempProductControl.AvailableQty -= 1 - tempProductControl.InUseQty;
                                tempProductControl.InUseQty = 1;
                                currentQty = 1;

                            }

                            // by SYM
                            //update the total cost
                            row.Cells[(int)sCol.SalePrice].Value = Convert.ToInt32(getActualCost(pro, 0));
                            row.Cells[(int)sCol.Cost].Value = currentQty * getActualCost(pro, DiscountRate);
                            // isload = false;

                        }
                    }

                    //Discount Rate Change
                    else if (e.ColumnIndex == (int)sCol.DisPercent)
                    {
                        string currentProductCode = row.Cells[1].Value.ToString();
                        //get current Project by Id
                        entity = new POSEntities();
                        Product pro = iTempP.Where(p => p.ProductCode == currentProductCode).FirstOrDefault<Product>();



                        int currentQty = 1;
                        try
                        {
                            //get updated qty
                            currentQty = Convert.ToInt32(row.Cells[(int)sCol.Qty].Value);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Input quantity have invalid keywords.");
                            row.Cells[(int)sCol.Qty].Value = "1";
                        }

                        decimal DiscountRate = 0;
                        try
                        {

                            // Decimal.TryParse(row.Cells[5].Value.ToString(), out DiscountRate);
                            DiscountRate = Convert.ToDecimal(row.Cells[(int)sCol.DisPercent].Value);
                            if (DiscountRate > 100)
                            {
                                row.Cells[(int)sCol.DisPercent].Value = 100;
                                DiscountRate = 100;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Input Discount rate have invalid keywords.");
                            row.Cells[(int)sCol.DisPercent].Value = "0.00";
                        }


                        row.Cells[(int)sCol.SalePrice].Value = Convert.ToInt32(getActualCost(pro, 0));
                        row.Cells[(int)sCol.Cost].Value = currentQty * getActualCost(pro, DiscountRate);
                    }
                    if (mssg == "")
                    {
                        Cell_ReadOnly();
                    }
                    UpdateTotalCost();
                }
                else
                {
                    dgvSalesItem.CurrentCell = dgvSalesItem[0, e.RowIndex];
                    MessageBox.Show("You need to input product code or barcode firstly in order to add product quentity!");
                    mssg = "Wrong";
                }
            }
            ListenAction();
        }
        private void dgvSalesItem_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvSalesItem.CurrentCell.ColumnIndex == (int)sCol.BatchNo && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                if (comboBox.Items.Count < 2)
                {
                    return;
                }

                comboBox.SelectedIndexChanged += new System.EventHandler(cboBatchNo_SelectedIndexChanged);

            }
        }


        private void cboBatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            LastColumnBatchNoComboSelectionChanged(comboBox, dgvSalesItem.CurrentCell.RowIndex);
        }
        private void LastColumnBatchNoComboSelectionChanged(ComboBox cb, int rowIndex)
        {
            try
            {
                AvoidAction();
                int currentQty = 0;


                DataGridViewRow row = dgvSalesItem.Rows[rowIndex];
                string currentProductCode = row.Cells[(int)sCol.SKU].Value.ToString();

                //get current Project by Id
                Product pro = iTempP.Where(p => p.ProductCode == currentProductCode).FirstOrDefault<Product>();
                AvailableProductQtyWithBatch tempProductControl = availablePList == null ? null : availablePList.Where(Product => Product.ProductID == pro.Id).FirstOrDefault();

                try
                {
                    string BatchNo = cb.Text;//row.Cells[(int)sCol.BatchNo].Value.ToString();
                    int.TryParse(row.Cells[(int)sCol.Qty].Value.ToString(), out currentQty);

                    if (tempProductControl == null)
                    {
                        AddNew4AvailableProductQtyWithBatch(pro.Id, string.Empty);
                    }
                    tempProductControl = availablePList.Where(Product => Product.ProductID == pro.Id && Product.BatchNo == BatchNo).OrderBy(p => p.ExpireDate).FirstOrDefault();

                    if (currentQty > (tempProductControl.AvailableQty + tempProductControl.InUseQty))
                    {

                        MessageBox.Show("Batch No '" + BatchNo + "' is not enough quantity as much as you want!, current available quantity is " + tempProductControl.AvailableQty);
                        if (cb.Tag != null && !string.IsNullOrEmpty(cb.Tag.ToString()))
                        {
                            //change back to orginal batch no before change
                            cb.SelectedIndexChanged -= new System.EventHandler(cboBatchNo_SelectedIndexChanged);
                            cb.Text = cb.Tag.ToString();
                            cb.SelectedIndexChanged += new System.EventHandler(cboBatchNo_SelectedIndexChanged);

                        }
                        currentQty = tempProductControl.AvailableQty;
                        //tempProductControl.InUseQty = tempProductControl.AvailableQty + tempProductControl.InUseQty;
                        //tempProductControl.AvailableQty = 0;
                        //Check_SameProductCode_BatchNo(tempProductControl.ProductID, tempProductControl.BatchNo);

                    }
                    else
                    {
                        dgvSalesItem.Rows[rowIndex].Cells[(int)sCol.BatchNo].Value = BatchNo;
                        int tBatch = CountProductQtyWithBatchInGrid(tempProductControl.ProductID.ToString(), BatchNo);
                        if (tBatch == 0)
                        {
                            tBatch = 1;
                        }

                        // List<AvailableProductQtyWithBatch> ProductList = availablePList.Where(Product => Product.ProductID == pro.Id).ToList();

                        for (int i = 0; i < availablePList.Count; i++)
                        {
                            int j = CountProductQtyWithBatchInGrid(availablePList[i].ProductID.ToString(), availablePList[i].BatchNo);
                            availablePList[i].AvailableQty = availablePList[i].AvailableQty + availablePList[i].InUseQty - j;
                            availablePList[i].InUseQty = j;

                        }

                        tempProductControl.AvailableQty = tempProductControl.AvailableQty + tempProductControl.InUseQty - tBatch;
                        tempProductControl.InUseQty = tBatch;

                        Check_SameProductCode_BatchNo(tempProductControl.ProductID, tempProductControl.BatchNo);

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Input quantity have invalid keywords.");
                    row.Cells[(int)sCol.Qty].Value = "1";
                    tempProductControl.AvailableQty -= 1 - tempProductControl.InUseQty;
                    tempProductControl.InUseQty = 1;
                    currentQty = 1;

                }

                // by SYM
                //update the total cost
                row.Cells[(int)sCol.Qty].Value = currentQty;
                if (IsBirthday)
                {
                    disRate = birthdayDiscount;

                }
                else
                {
                    disRate = pro.DiscountRate;
                }
                row.Cells[(int)sCol.SalePrice].Value = Convert.ToInt32(getActualCost(pro, 0));
                row.Cells[(int)sCol.Cost].Value = currentQty * getActualCost(pro, disRate);
                // isload = false;

                cb.Tag = cb.Text;

            }
            catch (Exception ex)
            {
                ListenAction();
            }
            ListenAction();
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<TransactionDetail> DetailList = GetTranscationListFromDataGridView();
                if (DetailList.Count() != 0)
                {

                    List<int> index = (from r in dgvSalesItem.Rows.Cast<DataGridViewRow>()
                                       where r.Cells[2].Value == null || r.Cells[2].Value.ToString() == String.Empty || r.Cells[(int)sCol.Qty].Value.ToString() == "0"
                                       select r.Index).ToList();


                    index.RemoveAt(index.Count - 1);

                    if (index.Count > 0)
                    {

                        foreach (var a in index)
                        {
                            try
                            {
                                dgvSalesItem.Rows.RemoveAt(a);
                            }
                            catch
                            {
                                dgvSalesItem.Rows[a].DefaultCellStyle.BackColor = Color.Red; // highlight the rows with qty = null/0/empty 
                            }

                        }
                        Cursor.Current = Cursors.Default;

                        return;
                    }

                    if (cboCustomer.SelectedIndex > 0)
                    {
                        //check if gift has
                        if (GiftList.Count > 0)
                        {
                            GivenGiftList.Clear();
                            for (int i = 0; i < chkGiftList.Items.Count; i++)
                            {
                                if (chkGiftList.GetItemChecked(i) == true)
                                {
                                    GivenGiftList.Add(GiftList[i]);
                                }
                            }
                        }
                        else
                        {
                            GivenGiftList.Clear();
                        }
                        if (GivenGiftList.Count > 0)
                        {
                            foreach (GiftSystem gObj in GivenGiftList)
                            {
                                if (gObj.Product1 != null)
                                {
                                    StockFillingFromSAP sp = entity.StockFillingFromSAPs.Where(x => x.ProductId == gObj.Product1.Id && x.IsActive == true && x.AvailableQty > 0).OrderBy(x => x.ExpireDate).FirstOrDefault();
                                    if (sp != null)
                                    {
                                        TransactionDetail tDObj = new TransactionDetail();
                                        tDObj.ProductId = gObj.Product1.Id;
                                        tDObj.TotalAmount = gObj.PriceForGiftProduct;
                                        tDObj.DiscountRate = 0;
                                        tDObj.TaxRate = 0;
                                        tDObj.Qty = 1;
                                        tDObj.UnitPrice = 0;
                                        tDObj.BatchNo = sp.BatchNo;
                                        DetailList.Add(tDObj);

                                    }
                                }
                            }
                        }

                        #region MultiPayment
                        Boolean hasError = false;
                        int _extraDiscount = 0;
                        //Int32.TryParse(txtAdditionalDiscount.Text, out _extraDiscount);
                        int _extraTax = 0;
                        Int32.TryParse(txtExtraTax.Text, out _extraTax);
                        int totalAmount = Convert.ToInt32(lblTotal.Text);


                        Currency cu = entity.Currencies.FirstOrDefault(x => x.Id == 1);
                        if (dgvPaymentType.Rows.Count == 1 && Convert.ToString(dgvPaymentType[1, 0].Value).Trim() == "Cash" && dgvPaymentType[1, 0].Value != null)
                        {
                            decimal decRec = Convert.ToDecimal(dgvPaymentType[3, 0].Value.ToString().Trim());
                            if (decRec > totalAmount)
                            {
                                dgvPaymentType.Rows[0].Cells[3].Value = totalAmount;
                                dgvPaymentType.Rows[0].Cells[5].Value = totalAmount;
                                dgvPaymentType.EndEdit();
                                dgvPaymentType.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            }

                        }
                        Transaction insertedTransaction = new Transaction();
                        int paidAmount = 0; bool isFoc = false; int giftcardAmt = 0; int creditAmount = 0;

                        int tempPayType = 1; string mainPaymentID = string.Empty;
                        string tempPaymentTypeID = string.Empty;
                        foreach (DataGridViewRow row in dgvPaymentType.Rows)
                        {
                            if (row.Cells[6].Value != null && string.IsNullOrEmpty(mainPaymentID))
                            {
                                mainPaymentID = row.Cells[6].Value.ToString();
                            }
                            if (row.Cells[0].Value != null)
                            {
                                if (!string.IsNullOrEmpty(tempPaymentTypeID) && tempPaymentTypeID != row.Cells[0].Value.ToString())
                                {
                                    ++tempPayType;
                                }
                                tempPaymentTypeID = row.Cells[0].Value.ToString();
                            }
                            if (row.Cells[5].Value == null)
                            {
                                paidAmount = 0;
                                isFoc = true;
                            }
                            else
                            {
                                if (row.Cells[2].Value.ToString() == "Gift Card")
                                {
                                    giftcardAmt += Convert.ToInt32(row.Cells[5].Value);
                                }
                                else if (row.Cells[2].Value.ToString() == "Credit")
                                {
                                    creditAmount += Convert.ToInt32(row.Cells[5].Value);
                                }
                                paidAmount += Convert.ToInt32(row.Cells[5].Value);

                            }
                        }
                        if (string.IsNullOrEmpty(tempPaymentTypeID))
                        {
                            MessageBox.Show("Please add customer's payment method(s)!");
                            ListenAction();
                            Cursor.Current = Cursors.Default;

                            return;
                        }
                        if (giftcardAmt > 0)
                        {
                            if (!verifyDiscount())
                            {
                                ListenAction();

                                Cursor.Current = Cursors.Default;
                                return;
                            }
                        }

                        if (tempPayType > 1)//more than one payment type =multipayment
                        {
                            tempPayType = Utility.PaymentTypeID.MultiPayment;
                        }
                        else //which table can i use to calculate payment type
                        {
                            tempPayType = Convert.ToInt32(mainPaymentID);
                        }

                        if (paidAmount == 0 && isFoc == false)
                        {
                            MessageBox.Show("Please fill up receive amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            hasError = true;
                        }
                        else if (totalAmount > (paidAmount + _extraDiscount) && isFoc == false)
                        {
                            MessageBox.Show("Receive amount must be greater than total cost!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            hasError = true;
                        }

                        if (!hasError)
                        {
                            System.Data.Objects.ObjectResult<String> Id;

                            long totalCost = (long)DetailList.Sum(x => x.TotalAmount) - _extraDiscount;
                            if (!isFoc)
                            {
                                //Sale
                                if (creditAmount == 0)
                                {
                                    Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, tempPayType, _extraTax + Convert.ToInt32(lblTaxTotal.Text), _extraDiscount + Convert.ToInt32(lblDiscountTotal.Text), totalCost, paidAmount - giftcardAmt, null, Convert.ToInt32(cboCustomer.SelectedValue), SettingController.DefaultShop.ShortCode, SettingController.DefaultShop.Id, false);
                                }
                                //Credit
                                else
                                {
                                    Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Credit, true, true, tempPayType, _extraTax + Convert.ToInt32(lblTaxTotal.Text), _extraDiscount + Convert.ToInt32(lblDiscountTotal.Text), totalCost, paidAmount - (giftcardAmt + creditAmount), null, Convert.ToInt32(cboCustomer.SelectedValue), SettingController.DefaultShop.ShortCode, SettingController.DefaultShop.Id, false);
                                }
                            }
                            //FOC
                            else
                            {
                                Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, tempPayType, 0, 0, 0, 0, null, Convert.ToInt32(cboCustomer.SelectedValue), SettingController.DefaultShop.ShortCode, SettingController.DefaultShop.Id, false);
                            }
                            bool pointCalculate = false;
                            entity = new POSEntities();
                            string resultId = Id.FirstOrDefault().ToString();
                            insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();
                            string TId = insertedTransaction.Id;
                            insertedTransaction.IsDeleted = false;
                            insertedTransaction.ReceivedCurrencyId = 1;
                            foreach (TransactionDetail detail in DetailList)
                            {

                                Utility.MinusProductAvailableQtyCosOfSales(entity, (long)detail.ProductId, detail.BatchNo, (int)detail.Qty);


                                detail.IsDeleted = false;//Update IsDelete (Null to 0)

                                detail.Product = entity.Products.Where(prod => prod.Id == (long)detail.ProductId).FirstOrDefault();

                                //    var detailID = entity.InsertTransactionDetail(TId, Convert.ToInt32(detail.ProductId), Convert.ToInt32(detail.Qty), Convert.ToInt32(detail.UnitPrice), Convert.ToDouble(detail.DiscountRate), Convert.ToDouble(detail.TaxRate), Convert.ToInt32(detail.TotalAmount), detail.IsDeleted, detail.ConsignmentPrice, IsConsignmentPaid).SingleOrDefault();
                                long detailID = 0;
                                bool IsBdDiscounted = false;
                                if (!string.IsNullOrEmpty(txtVIPID.Text) && cboCustomer.SelectedValue != null && (int)cboCustomer.SelectedValue > 0 && IsBirthday && detail.DiscountRate >= SettingController.birthday_discount)
                                {
                                    IsBdDiscounted = true;

                                }
                                if (cboPaymentMethod.Enabled)
                                {
                                    detailID = (long)entity.InsertTransactionDetail(TId, Convert.ToInt32(detail.ProductId), Convert.ToInt32(detail.Qty), Convert.ToInt32(detail.UnitPrice), Convert.ToDouble(detail.DiscountRate), Convert.ToDouble(detail.TaxRate), Convert.ToInt32(detail.TotalAmount), detail.IsDeleted, Convert.ToDouble(detail.IsDeductedBy), detail.BatchNo, IsBdDiscounted).SingleOrDefault();
                                }
                                else
                                {
                                    detailID = (long)entity.InsertTransactionDetail(TId, Convert.ToInt32(detail.ProductId), Convert.ToInt32(detail.Qty), 0, 0, 0, 0, detail.IsDeleted, Convert.ToDouble(detail.IsDeductedBy), detail.BatchNo, IsBdDiscounted).SingleOrDefault();
                                }

                                if (!string.IsNullOrEmpty(txtVIPID.Text) && cboCustomer.SelectedValue != null && (int)cboCustomer.SelectedValue > 0 && (IsBdDiscounted || pdp == null || detail.IsDeductedBy == null || detail.DiscountRate < pdp.DiscountRate))
                                {
                                    pointCalculate = true;
                                }

                                //detail.Product.Qty = detail.Product.Qty - detail.Qty;

                                //save in stocktransaction


                                //if (detail.Product.Brand.Name == "Special Promotion")
                                if (detail.Product.Line != null && detail.Product.Line.Name == "Special Promotion")
                                {
                                    List<WrapperItem> wList = detail.Product.WrapperItems.ToList();
                                    if (wList.Count > 0)
                                    {
                                        foreach (WrapperItem w in wList)
                                        {
                                            Product wpObj = iTempP.Where(p => p.Id == w.ChildProductId).FirstOrDefault();
                                            wpObj.Qty = wpObj.Qty - detail.Qty;

                                            SPDetail spDetail = new SPDetail();
                                            spDetail.TransactionDetailID = Convert.ToInt32(detailID);
                                            spDetail.DiscountRate = detail.DiscountRate;
                                            spDetail.ParentProductID = w.ParentProductId;
                                            spDetail.ChildProductID = w.ChildProductId;
                                            spDetail.Price = wpObj.Price;
                                            entity.insertSPDetail(spDetail.TransactionDetailID, spDetail.ParentProductID, spDetail.ChildProductID, spDetail.Price, spDetail.DiscountRate, "PC");
                                            //entity.SPDetails.Add(spDetail);
                                        }
                                    }
                                }

                                entity.SaveChanges();
                            }
                            //if (!string.IsNullOrEmpty(txtVIPID.Text) && cboCustomer.SelectedValue != null && (int)cboCustomer.SelectedValue > 0 && !IsDetected)
                            //{
                            //    insertedTransaction.Loc_IsCalculatePoint = true;
                            //}
                            //else
                            //{
                            //    insertedTransaction.Loc_IsCalculatePoint = false;
                            //}
                            insertedTransaction.Loc_IsCalculatePoint = pointCalculate;
                            entity.SaveChanges();
                            //save in stocktransaction


                            if (giftcardAmt != 0)
                            {
                                foreach (DataGridViewRow row in dgvPaymentType.Rows)
                                {
                                    if (row.Cells[2].Value.ToString() == "Gift Card")
                                    {
                                        int customerid = Convert.ToInt32(cboCustomer.SelectedValue);

                                        string cardNumber = row.Cells[3].Value.ToString();
                                        int giftcardid = entity.GiftCards.Where(x => x.CardNumber.Trim() == cardNumber && x.CustomerId == customerid).Select(x => x.Id).FirstOrDefault();
                                        if (giftcardid != 0)
                                        {
                                            GiftCardInTransaction gic = new GiftCardInTransaction();
                                            gic.TransactionId = TId;
                                            gic.GiftCardId = giftcardid;
                                            entity.GiftCardInTransactions.Add(gic);
                                            //Clear giftcard in giftcard list

                                            GiftCard giftcard = entity.GiftCards.Where(x => x.Id == giftcardid).FirstOrDefault();
                                            giftcard.IsUsed = true;
                                        }

                                    }
                                }
                            }
                            List<MultiPayment> multiPaymentList = new List<MultiPayment>();

                            if (tempPayType == Utility.PaymentTypeID.MultiPayment)
                            {
                                foreach (DataGridViewRow row in dgvPaymentType.Rows)
                                {
                                    if (multiPaymentList.Count != 0)
                                    {

                                        var data = multiPaymentList.Where(x => x.id == (int)row.Cells[0].Value).FirstOrDefault();
                                        if (data != null)
                                        {
                                            data.amount += Convert.ToInt32(row.Cells[5].Value);
                                        }
                                        else
                                        {
                                            MultiPayment multiPayment = new MultiPayment();
                                            multiPayment.id = Convert.ToInt32(row.Cells[0].Value);
                                            multiPayment.paymentName = Convert.ToString(row.Cells[2].Value);
                                            multiPayment.amount = Convert.ToInt32(row.Cells[5].Value);
                                            multiPaymentList.Add(multiPayment);
                                        }
                                    }
                                    else
                                    {
                                        MultiPayment multiPayment = new MultiPayment();
                                        multiPayment.id = Convert.ToInt32(row.Cells[0].Value);
                                        multiPayment.paymentName = Convert.ToString(row.Cells[2].Value);
                                        multiPayment.amount = Convert.ToInt32(row.Cells[5].Value);
                                        multiPaymentList.Add(multiPayment);
                                    }
                                }

                                foreach (var item in multiPaymentList)
                                {

                                    TransactionPaymentDetail tranPaymentDetail = new TransactionPaymentDetail();
                                    tranPaymentDetail.TransactionId = TId;
                                    tranPaymentDetail.PaymentMethodId = item.id;
                                    tranPaymentDetail.Amount = item.amount;
                                    entity.TransactionPaymentDetails.Add(tranPaymentDetail);
                                    entity.SaveChanges();
                                }
                            }
                            else
                            {
                                if (cboPaymentMethod.Enabled)
                                {
                                    foreach (DataGridViewRow row in dgvPaymentType.Rows)
                                    {

                                        TransactionPaymentDetail tranPaymentDetail = new TransactionPaymentDetail();
                                        tranPaymentDetail.TransactionId = TId;
                                        tranPaymentDetail.PaymentMethodId = Convert.ToInt32(row.Cells[0].Value);
                                        if (row.Cells[2].Value != null && !string.IsNullOrEmpty(row.Cells[2].Value.ToString()) && row.Cells[2].Value.ToString() == "Gift Card")
                                        {
                                            tranPaymentDetail.Amount = Convert.ToInt32(row.Cells[5].Value);
                                        }
                                        else
                                        {
                                            tranPaymentDetail.Amount = Convert.ToInt32(row.Cells[3].Value);
                                        }
                                        entity.TransactionPaymentDetails.Add(tranPaymentDetail);
                                        entity.SaveChanges();
                                    }
                                }
                                else
                                {
                                    TransactionPaymentDetail tranPaymentDetail = new TransactionPaymentDetail();
                                    tranPaymentDetail.TransactionId = TId;
                                    tranPaymentDetail.PaymentMethodId = Convert.ToInt32(dgvPaymentType.Rows[0].Cells[0].Value);
                                    tranPaymentDetail.Amount = 0;
                                    entity.TransactionPaymentDetails.Add(tranPaymentDetail);
                                    entity.SaveChanges();
                                }


                            }
                            if (GiftList.Count > 0)
                            {
                                foreach (GiftSystem gs in GiftList)
                                {
                                    AttachGiftSystemForTransaction agft = new AttachGiftSystemForTransaction();
                                    agft.AttachGiftSystemId = gs.Id;
                                    agft.TransactionId = insertedTransaction.Id;
                                    entity.AttachGiftSystemForTransactions.Add(agft);
                                }
                            }
                            entity.SaveChanges();

                            ExchangeRateForTransaction ex = new ExchangeRateForTransaction();
                            ex.TransactionId = TId;
                            ex.CurrencyId = cu.Id;
                            ex.ExchangeRate = Convert.ToInt32(cu.LatestExchangeRate);
                            entity.ExchangeRateForTransactions.Add(ex);
                            entity.SaveChanges();

                            //CheckExportLog();

                            #region [ Print ]


                            dsReportTemp dsReport = new dsReportTemp();
                            dsReportTemp.ItemListDataTable dtReport = (dsReportTemp.ItemListDataTable)dsReport.Tables["ItemList"];
                            dsReportTemp.MultiPaymentDataTable multiReport = (dsReportTemp.MultiPaymentDataTable)dsReport.Tables["MultiPayment"];
                            int _tAmt = 0;
                            PList.Clear();
                            Isduplicate = false;
                            PrintDetailList(DetailList);
                            if (Isduplicate)
                            {
                                DetailList = PList;
                            }

                            foreach (TransactionDetail transaction in DetailList)
                            {
                                dsReportTemp.ItemListRow newRow = dtReport.NewItemListRow();
                                newRow.ItemId = transaction.Product.ProductCode;
                                newRow.Name = transaction.Product.Name;
                                newRow.Qty = transaction.Qty.ToString();
                                newRow.DiscountPercent = transaction.DiscountRate.ToString();
                                //newRow.TotalAmount = (int)transaction.TotalAmount;
                                newRow.TotalAmount = (int)transaction.UnitPrice * (int)transaction.Qty;
                                newRow.UnitPrice = "1@" + transaction.UnitPrice.ToString();
                                _tAmt += newRow.TotalAmount;
                                dtReport.AddItemListRow(newRow);
                            }

                            string reportPath = "";
                            ReportViewer rv = new ReportViewer();
                            ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["ItemList"]);

                            //if (!SettingController.DefaultShop.ShopName.Contains("Mandalay"))
                            if (DefaultPrinter.SlipPrinter.Contains("EPSON TM-T88IV Receipt"))
                            {
                                reportPath = Application.StartupPath + "\\Epson\\Loc_InvoiceCash.rdlc";
                            }
                            else if (DefaultPrinter.SlipPrinter.Contains("XP-80C"))
                            {
                                reportPath = Application.StartupPath + "\\XP\\Loc_InvoiceCash.rdlc";
                            }
                            else if (DefaultPrinter.SlipPrinter.Contains("Birch BP-003"))
                            {

                                reportPath = Application.StartupPath + "\\Birch\\Loc_InvoiceCash.rdlc";

                            }
                            else if (DefaultPrinter.SlipPrinter.Contains("JM Thermal Series Printer"))
                            {
                                reportPath = Application.StartupPath + "\\Birch\\Loc_InvoiceCash.rdlc";
                            }
                            else
                            {

                                reportPath = Application.StartupPath + "\\Epson\\Loc_InvoiceCash.rdlc";

                            }


                            foreach (var item in multiPaymentList)
                            {
                                dsReportTemp.MultiPaymentRow newRow = multiReport.NewMultiPaymentRow();
                                newRow.PaymentMethod = item.paymentName;
                                newRow.Amount = Convert.ToString(item.amount);
                                multiReport.AddMultiPaymentRow(newRow);
                            }
                            if (multiReport.Count < 1)
                            {
                                try
                                {
                                    dsReportTemp.MultiPaymentRow newRow = multiReport.NewMultiPaymentRow();
                                    newRow.PaymentMethod = dgvPaymentType.Rows[0].Cells[2].Value.ToString();
                                    // newRow.Amount = Convert.ToString(dgvPaymentType.Rows[0].Cells[3].Value.ToString()); //By TTN; modifed to satisfy giftcard amount
                                    newRow.Amount = Convert.ToString(dgvPaymentType.Rows[0].Cells[5].Value.ToString());
                                    multiReport.AddMultiPaymentRow(newRow);
                                }
                                catch { }
                            }

                            ReportDataSource rds2 = new ReportDataSource("MultiPayment", multiReport.AsEnumerable());

                            //    reportPath = Application.StartupPath + "\\HagalReports\\Loc_InvoiceCash.rdlc";
                            rv.Reset();
                            rv.LocalReport.ReportPath = reportPath;
                            rv.LocalReport.DataSources.Add(rds);
                            rv.LocalReport.DataSources.Add(rds2);

                            var cID = Convert.ToInt32(cboCustomer.SelectedValue);
                            Customer cus = entity.Customers.Where(x => x.Id == cID).FirstOrDefault();

                            string _Point = Loc_CustomerPointSystem.GetPointFromCustomerId(cus.Id).ToString();

                            ReportParameter CustomerName = new ReportParameter("CustomerName", cus.Title + " " + cus.Name);
                            rv.LocalReport.SetParameters(CustomerName);


                            ReportParameter AvailablePoint = new ReportParameter("AvailablePoint", _Point);
                            rv.LocalReport.SetParameters(AvailablePoint);

                            ReportParameter TAmt = new ReportParameter("TAmt", _tAmt.ToString());
                            rv.LocalReport.SetParameters(TAmt);

                            ReportParameter ShopName = new ReportParameter("ShopName", SettingController.DefaultShop.ShopName);
                            rv.LocalReport.SetParameters(ShopName);

                            ReportParameter BranchName = new ReportParameter("BranchName", SettingController.DefaultShop.Address);
                            rv.LocalReport.SetParameters(BranchName);

                            ReportParameter Phone = new ReportParameter("Phone", SettingController.DefaultShop.PhoneNumber);
                            rv.LocalReport.SetParameters(Phone);

                            ReportParameter OpeningHours = new ReportParameter("OpeningHours", SettingController.DefaultShop.OpeningHours);
                            rv.LocalReport.SetParameters(OpeningHours);

                            ReportParameter TransactionId = new ReportParameter("TransactionId", resultId.ToString());
                            rv.LocalReport.SetParameters(TransactionId);

                            APP_Data.Counter c = entity.Counters.Where(x => x.Id == MemberShip.CounterId).FirstOrDefault();

                            ReportParameter CounterName = new ReportParameter("CounterName", c.Name);
                            rv.LocalReport.SetParameters(CounterName);

                            ReportParameter PrintDateTime = new ReportParameter("PrintDateTime", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                            rv.LocalReport.SetParameters(PrintDateTime);

                            ReportParameter CasherName = new ReportParameter("CasherName", MemberShip.UserName);
                            rv.LocalReport.SetParameters(CasherName);

                            // Int64 totalAmountRep = insertedTransaction.TotalAmount == null ? 0 : Convert.ToInt64(insertedTransaction.TotalAmount + insertedTransaction.DiscountAmount);
                            Int64 totalAmountRep = insertedTransaction.TotalAmount == null ? 0 : Convert.ToInt64(insertedTransaction.TotalAmount);
                            ReportParameter TotalAmount = new ReportParameter("TotalAmount", totalAmountRep.ToString());
                            rv.LocalReport.SetParameters(TotalAmount);

                            Int64 taxAmountRep = insertedTransaction.TaxAmount == null ? 0 : Convert.ToInt64(insertedTransaction.TaxAmount);
                            ReportParameter TaxAmount = new ReportParameter("TaxAmount", taxAmountRep.ToString());
                            rv.LocalReport.SetParameters(TaxAmount);

                            Int64 disAmountRep = insertedTransaction.DiscountAmount == null ? 0 : Convert.ToInt64(insertedTransaction.DiscountAmount);
                            ReportParameter DiscountAmount = new ReportParameter("DiscountAmount", disAmountRep.ToString());
                            rv.LocalReport.SetParameters(DiscountAmount);

                            ReportParameter PaidAmount = new ReportParameter("PaidAmount", (paidAmount - giftcardAmt).ToString());
                            rv.LocalReport.SetParameters(PaidAmount);

                            var CurrencySymbol = "Ks";
                            ReportParameter CurrencyCode = new ReportParameter("CurrencyCode", CurrencySymbol);
                            rv.LocalReport.SetParameters(CurrencyCode);
                            if (dgvPaymentType.Rows.Count == 1 && Convert.ToString(dgvPaymentType[1, 0].Value).Trim() == "Cash" && dgvPaymentType[1, 0].Value != null)
                            {
                                ReportParameter Change = new ReportParameter("Change", "0");
                                rv.LocalReport.SetParameters(Change);
                            }
                            else
                            {
                                ReportParameter Change = new ReportParameter("Change", lblChanges.Text);
                                rv.LocalReport.SetParameters(Change);
                            }
                            PrintDoc.PrintReport(rv, "Slip");
                            PrintDoc.PrintReport(rv, "Slip");

                            #endregion
                            DialogResult result = MessageBox.Show("Payment Completed", "mPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();

                        }


                        #endregion


                        #region Single Payment
                        //Cash
                        if (false)
                        {
                            Loc_PaidByCash form = new Loc_PaidByCash();
                            form.DetailList = DetailList;
                            form.GiftList = GivenGiftList;
                            int extraDiscount = 0;
                            //Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);
                            int giftDiscount = 0;
                            Int32.TryParse(txtGiftDiscount.Text, out giftDiscount);
                            int tax = 0;
                            Int32.TryParse(txtExtraTax.Text, out tax);
                            form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                            form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                            form.isDraft = isDraft;
                            form.DraftId = DraftId;
                            //if cashier doesn't select customer, leave it as null.
                            if (cboCustomer.SelectedIndex != 0)
                                form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue.ToString());
                            else
                                form.CustomerId = null;
                            form.ExtraTax = tax;
                            form.ExtraDiscount = extraDiscount + giftDiscount;
                            form.isDebt = false;
                            form.ShowDialog();
                        }
                        //Credit
                        else if (false)
                        {
                            Loc_PaidByCredit form = new Loc_PaidByCredit();
                            form.DetailList = DetailList;
                            form.GiftList = GivenGiftList;
                            int extraDiscount = 0;
                            // Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);
                            int giftDiscount = 0;
                            Int32.TryParse(txtGiftDiscount.Text, out giftDiscount);
                            int tax = 0;
                            Int32.TryParse(txtExtraTax.Text, out tax);
                            form.isDraft = isDraft;
                            form.DraftId = DraftId;
                            //if cashier doesn't select customer, leave it as null.
                            if (cboCustomer.SelectedIndex != 0)
                                form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue.ToString());
                            else
                                form.CustomerId = null;

                            form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                            form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                            form.ExtraTax = tax;
                            form.ExtraDiscount = extraDiscount + giftDiscount;
                            form.ShowDialog();
                        }
                        //GiftCard
                        else if (false)
                        {
                            Loc_PaidByGiftCard form = new Loc_PaidByGiftCard();
                            form.GiftList = GivenGiftList;
                            form.DetailList = DetailList;
                            int extraDiscount = 0;
                            int discount = 0;
                            //Int32.TryParse(txtAdditionalDiscount.Text, out discount);
                            int GiftDiscount = 0;
                            Int32.TryParse(txtGiftDiscount.Text, out GiftDiscount);
                            extraDiscount = discount + GiftDiscount;
                            int tax = 0;
                            Int32.TryParse(txtExtraTax.Text, out tax);
                            form.isDraft = isDraft;
                            form.DraftId = DraftId;
                            //if cashier doesn't select customer, leave it as null.
                            if (cboCustomer.SelectedIndex != 0)
                                form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue.ToString());
                            else
                            {
                                MessageBox.Show("Please fill up customer name!");
                                Cursor.Current = Cursors.Default;

                                return;
                            }
                            form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                            form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                            form.ExtraTax = tax;
                            form.ExtraDiscount = extraDiscount;
                            form.ShowDialog();
                        }
                        //FOC
                        else if (false)
                        {
                            Loc_FOC form = new Loc_FOC();
                            form.DetailList = DetailList;
                            form.GiftList = GivenGiftList;
                            form.Type = 4;
                            int extraDiscount = 0;
                            //Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);
                            int giftDiscount = 0;
                            Int32.TryParse(txtGiftDiscount.Text, out giftDiscount);
                            int tax = 0;
                            Int32.TryParse(txtExtraTax.Text, out tax);
                            form.isDraft = isDraft;
                            form.DraftId = DraftId;
                            //if cashier doesn't select customer, leave it as null.
                            if (cboCustomer.SelectedIndex != 0)
                                form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue.ToString());
                            else
                                form.CustomerId = null;
                            form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                            form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                            form.ExtraTax = tax;
                            form.ExtraDiscount = extraDiscount + giftDiscount;
                            form.ShowDialog();
                        }
                        //Paid by MPU
                        else if (false)
                        {
                            PaidByMPU form = new PaidByMPU();
                            form.DetailList = DetailList;
                            int extraDiscount = 0;
                            //Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);
                            int giftDiscount = 0;
                            Int32.TryParse(txtGiftDiscount.Text, out giftDiscount);
                            int tax = 0;
                            Int32.TryParse(txtExtraTax.Text, out tax);
                            form.isDraft = isDraft;
                            form.DraftId = DraftId;
                            //if cashier doesn't select customer, leave it as null.
                            if (cboCustomer.SelectedIndex != 0)
                                form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue.ToString());
                            else
                                form.CustomerId = null;
                            form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                            form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                            form.ExtraTax = tax;
                            form.ExtraDiscount = extraDiscount + giftDiscount;
                            form.ShowDialog();
                        }
                        else if (false)
                        {
                            Loc_FOC form = new Loc_FOC();
                            form.DetailList = DetailList;
                            form.GiftList = GivenGiftList;
                            form.Type = 6;
                            int extraDiscount = 0;
                            //Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);
                            int giftDiscount = 0;
                            Int32.TryParse(txtGiftDiscount.Text, out giftDiscount);
                            int tax = 0;
                            Int32.TryParse(txtExtraTax.Text, out tax);
                            form.isDraft = isDraft;
                            form.DraftId = DraftId;
                            //if cashier doesn't select customer, leave it as null.
                            if (cboCustomer.SelectedIndex != 0)
                                form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue.ToString());
                            else
                                form.CustomerId = null;
                            form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                            form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                            form.ExtraTax = tax;
                            form.ExtraDiscount = extraDiscount + giftDiscount;
                            form.ShowDialog();
                        }

                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("Please select customer!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("You haven't select any item to paid");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowErrMessage("Unable to pay!", "An error occure while paid, Please contact administrator for assist!" + Environment.NewLine + "Error Message :" + Environment.NewLine + ex.ToString());
            }
            Application.DoEvents();
            Cursor.Current = Cursors.Default;

        }

        private void RemoveNecessaryRow()
        {
            try
            {
                List<int> index = (from r in dgvSalesItem.Rows.Cast<DataGridViewRow>()
                                   where r.Cells[2].Value == null || r.Cells[2].Value.ToString() == String.Empty || r.Cells[(int)sCol.Qty].Value.ToString() == "0"
                                   select r.Index).ToList();


                index.RemoveAt(index.Count - 1);

                if (index.Count > 0)
                {

                    foreach (var a in index)
                    {
                        try
                        {
                            dgvSalesItem.Rows.RemoveAt(a);
                        }
                        catch
                        {
                            dgvSalesItem.Rows[a].DefaultCellStyle.BackColor = Color.Red; // highlight the rows with qty = null/0/empty 
                        }

                    }

                    return;
                }
            }
            catch { }
        }

        private void btnLoadDraft_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This action will erase current sale data. Would you like to continue?", "Load", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                DraftList form = new DraftList();
                form.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //will only work if the grid have data row
            //datagrid count header as a row, so we have to check there is more than one row
            if (dgvSalesItem.Rows.Count > 1)
            {
                List<TransactionDetail> DetailList = GetTranscationListFromDataGridView();

                int extraDiscount = 0;
                //Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);

                int tax = 0;
                Int32.TryParse(txtExtraTax.Text, out tax);
                int cusId = Convert.ToInt32(cboCustomer.SelectedValue);
                if (cusId <= 0)
                {
                    cusId = 9128;//Customer Default Id is different between Pearl and Main Office.Now using Id is gernal default Id that clude in this two shop.
                }
                System.Data.Objects.ObjectResult<String> Id;
                Id = entity.InsertDraft(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, tax, extraDiscount, DetailList.Sum(x => x.TotalAmount) + tax - extraDiscount, 0, null, cusId, SettingController.DefaultShop.ShortCode, SettingController.DefaultShop.Id);
                string resultId = Id.FirstOrDefault().ToString();
                Transaction insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();
                foreach (TransactionDetail detail in DetailList)
                {
                    insertedTransaction.TransactionDetails.Add(detail);
                    Utility.MinusProductAvailableQtyCosOfSales(entity, (long)detail.ProductId, detail.BatchNo, (int)detail.Qty);

                }
                entity.SaveChanges();  //// 111111
                Clear();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string productName = cboProductName.Text.Trim();
            List<Product> productList = (from p in entity.Products
                                         join pd in entity.ProductCategories
                      on p.ProductCategoryId equals pd.Id
                                         where !pd.Name.Contains("GWP")//not contain the GWP product when sale
                                         && p.Name.Contains(productName)
                                         select p).Distinct().ToList();
            if (productList.Count > 0)
            {
                dgvSearchProductList.DataSource = productList;
                dgvSearchProductList.Focus();
            }
            else
            {
                MessageBox.Show("Item not found!", "Cannot find");
                dgvSearchProductList.DataSource = null;
                return;
            }
        }

        private void dgvSearchProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AvoidAction();
            RemoveNecessaryRow();

            if (e.RowIndex >= 0 && dgvSearchProductList.RowCount > 0)
            {
                long currentProductId = Convert.ToInt64(dgvSearchProductList.Rows[e.RowIndex].Cells[0].Value);
                int count = dgvSalesItem.Rows.Count;
                if (e.ColumnIndex == 1)
                {
                    entity = new POSEntities();
                    Product pro = iTempP.Where(p => p.Id == currentProductId).FirstOrDefault<Product>();
                    if (pro != null)
                    {

                        List<AvailableProductQtyWithBatch> tempProductControlList = availablePList == null ? null : availablePList.Where(Product => Product.ProductID == pro.Id).ToList();
                        if (tempProductControlList == null || tempProductControlList.Count == 0)
                        {
                            AddNew4AvailableProductQtyWithBatch(pro.Id, string.Empty);
                        }
                        tempProductControlList = availablePList.Where(Product => Product.ProductID == pro.Id && Product.AvailableQty > 0).OrderBy(p => p.ExpireDate).ToList();

                        if (tempProductControlList != null && tempProductControlList.Count > 0)
                        {
                            DataGridViewRow row = (DataGridViewRow)dgvSalesItem.Rows[count - 1].Clone();
                            row.Cells[(int)sCol.BarCode].Value = pro.Barcode;
                            row.Cells[(int)sCol.SKU].Value = pro.ProductCode;
                            row.Cells[(int)sCol.Qty].Value = 1;
                            row.Cells[(int)sCol.ItemName].Value = pro.Name;
                            BindBatchNo(tempProductControlList, row.Cells[(int)sCol.BatchNo] as DataGridViewComboBoxCell, tempProductControlList[0].BatchNo);

                            //row.Cells[(int)sCol.BatchNo].Value = tempProductControl.BatchNo;

                            row.Cells[(int)sCol.SalePrice].Value = pro.Price;
                            if (IsBirthday)
                            {
                                disRate = birthdayDiscount;

                            }
                            else
                            {
                                disRate = pro.DiscountRate;
                            }
                            row.Cells[(int)sCol.DisPercent].Value = disRate;
                            row.Cells[(int)sCol.Tax].Value = pro.Tax.TaxPercent;
                            row.Cells[(int)sCol.Cost].Value = getActualCost(pro, disRate);
                            row.Cells[(int)sCol.pId].Value = currentProductId;
                            dgvSalesItem.Rows.Add(row);

                            _rowIndex = dgvSalesItem.Rows.Count - 2;
                            cboProductName.SelectedIndex = 0;
                            dgvSearchProductList.DataSource = "";
                            dgvSearchProductList.ClearSelection();
                            dgvSalesItem.Focus();
                            tempProductControlList[0].AvailableQty -= 1;
                            tempProductControlList[0].InUseQty += 1;
                            if (row.Cells[(int)sCol.BatchNo].Value != null)
                            {
                                Check_SameProductCode_BatchNo(pro.Id, row.Cells[(int)sCol.BatchNo].Value.ToString());
                            }
                            Cell_ReadOnly();
                        }
                        else
                        {
                            MessageBox.Show("Product Out of Stock!..");
                        }

                    }
                    else
                    {

                        MessageBox.Show("Item not found!", "Cannot find");
                    }

                    UpdateTotalCost();
                }
            }
            ListenAction();
        }


        private void AddNew4AvailableProductQtyWithBatch(long ProductID, string BatchNo)
        {
            try
            {
                //if(iTempStockFillingFromSAP==null || iTempStockFillingFromSAP.Count()<1)
                //{
                //    getCommonStockFillingFromSAP();
                //}
                List<AvailableProductQtyWithBatch> newAvList = null;
                if (string.IsNullOrEmpty(BatchNo))
                {
                    newAvList = (from s in entity.StockFillingFromSAPs
                                 let p = entity.Products.Where(x => x.Id == s.ProductId).FirstOrDefault()
                                 where p.Id == ProductID && s.AvailableQty > 0 && s.IsActive == true
                                 orderby s.ExpireDate ascending
                                 select new AvailableProductQtyWithBatch()
                                 {
                                     ProductID = p.Id,
                                     BatchNo = s.BatchNo,
                                     AvailableQty = s.AvailableQty,//entity.StockFillingFromSAPs.Where(x=>x.ProductId==p.Id && x.BatchNo==s.BatchNo).Select(x=>x.AvailableQty).Sum(),
                                     ExpireDate = s.ExpireDate,
                                     InUseQty = 0
                                 }).ToList();
                }
                else
                {
                    newAvList = (from s in entity.StockFillingFromSAPs
                                 let p = entity.Products.Where(x => x.Id == s.ProductId).FirstOrDefault()
                                 where p.Id == ProductID && s.AvailableQty > 0 && s.IsActive == true && s.BatchNo == BatchNo
                                 orderby s.ExpireDate ascending
                                 select new AvailableProductQtyWithBatch()
                                 {
                                     ProductID = p.Id,
                                     BatchNo = s.BatchNo,
                                     AvailableQty = s.AvailableQty,//entity.StockFillingFromSAPs.Where(x=>x.ProductId==p.Id && x.BatchNo==s.BatchNo).Select(x=>x.AvailableQty).Sum(),
                                     ExpireDate = s.ExpireDate,
                                     InUseQty = 0
                                 }).ToList();
                }
                if (newAvList != null && newAvList.Count() > 0)
                {
                    foreach (AvailableProductQtyWithBatch ap in newAvList)
                    {
                        availablePList.Add(ap);
                    }
                }
                else
                {
                    availablePList.Add(new AvailableProductQtyWithBatch
                    {
                        ProductID = ProductID,
                        BatchNo = null,
                        AvailableQty = 0,
                        InUseQty = 0
                    });
                }
            }
            catch (Exception ex)
            {
                //  Utility.ShowErrMessage("AddNew4AvailableProductQtyWithBatch", ex.Message);
            }
        }
        private void dgvSearchProductList_KeyDown(object sender, KeyEventArgs e)
        {
            AvoidAction();
            RemoveNecessaryRow();
            if (e.KeyData == Keys.Enter && dgvSearchProductList.CurrentCell != null)
            {
                int Row = dgvSearchProductList.CurrentCell.RowIndex;
                int Column = dgvSearchProductList.CurrentCell.ColumnIndex;
                int currentProductId = Convert.ToInt32(dgvSearchProductList.Rows[Row].Cells[0].Value);
                int count = dgvSalesItem.Rows.Count;
                if (Column == 1)
                {
                    Product pro = iTempP.Where(p => p.Id == currentProductId).FirstOrDefault();
                    if (pro != null)
                    {
                        List<AvailableProductQtyWithBatch> tempProductControlList = availablePList == null ? null : availablePList.Where(Product => Product.ProductID == pro.Id).ToList();
                        if (tempProductControlList == null || tempProductControlList.Count == 0)
                        {
                            AddNew4AvailableProductQtyWithBatch(pro.Id, string.Empty);
                        }
                        tempProductControlList = availablePList.Where(Product => Product.ProductID == pro.Id && Product.AvailableQty > 0).OrderBy(p => p.ExpireDate).ToList();

                        if (tempProductControlList != null && tempProductControlList.Count > 0)
                        {

                            DataGridViewRow row = (DataGridViewRow)dgvSalesItem.Rows[count - 1].Clone();
                            row.Cells[(int)sCol.BarCode].Value = pro.Barcode;
                            row.Cells[(int)sCol.SKU].Value = pro.ProductCode;
                            row.Cells[(int)sCol.Qty].Value = 1;
                            row.Cells[(int)sCol.ItemName].Value = pro.Name;
                            BindBatchNo(tempProductControlList, row.Cells[(int)sCol.BatchNo] as DataGridViewComboBoxCell, tempProductControlList[0].BatchNo);

                            //row.Cells[(int)sCol.BatchNo].Value = tempProductControl.BatchNo;
                            if (IsBirthday)
                            {
                                disRate = birthdayDiscount;
                            }
                            else
                            {
                                disRate = pro.DiscountRate;
                            }
                            row.Cells[(int)sCol.SalePrice].Value = pro.Price;
                            row.Cells[(int)sCol.DisPercent].Value = disRate;
                            row.Cells[(int)sCol.Tax].Value = pro.Tax.TaxPercent;
                            row.Cells[(int)sCol.Cost].Value = getActualCost(pro, disRate);
                            row.Cells[(int)sCol.pId].Value = currentProductId;
                            dgvSalesItem.Rows.Add(row);
                            cboProductName.SelectedIndex = 0;
                            dgvSearchProductList.DataSource = "";
                            dgvSearchProductList.ClearSelection();
                            dgvSalesItem.Focus();
                            //dgvSalesItem.CurrentCell = dgvSalesItem.Rows[count].Cells[0];
                            tempProductControlList[0].AvailableQty -= 1;
                            tempProductControlList[0].InUseQty += 1;
                            if (row.Cells[(int)sCol.BatchNo].Value != null)
                            {
                                Check_SameProductCode_BatchNo(pro.Id, row.Cells[(int)sCol.BatchNo].Value.ToString());
                            }
                            Cell_ReadOnly();
                        }
                        else
                        {
                            MessageBox.Show("Product Out of Stock!..");
                        }

                    }
                    else
                    {

                        MessageBox.Show("Item not found!", "Cannot find");
                    }

                    UpdateTotalCost();
                }
            }
            ListenAction();
        }

        private void AvoidAction()
        {
            this.dgvSearchProductList.CellClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchProductList_CellClick);
            this.dgvSearchProductList.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.dgvSearchProductList_KeyDown);
            this.dgvSalesItem.CellClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesItem_CellClick);
            this.dgvSalesItem.CellLeave -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesItem_CellLeave);
            this.dgvSalesItem.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesItem_CellValueChanged);
            this.dgvSalesItem.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.dgvSalesItem_KeyDown);

        }

        private void ListenAction()
        {
            this.dgvSearchProductList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchProductList_CellClick);
            this.dgvSearchProductList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSearchProductList_KeyDown);
            this.dgvSalesItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesItem_CellClick);
            this.dgvSalesItem.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesItem_CellLeave);
            this.dgvSalesItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesItem_CellValueChanged);
            this.dgvSalesItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSalesItem_KeyDown);

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F2))
            {
                cboProductName.Focus();
                return true;
            }
            else if (keyData == (Keys.F1))
            {
                btnPaid_Click(this.btnPaid, e);
                return true;
            }
            //else if (keyData == Keys.End)
            //{
            //    txtAdditionalDiscount.Focus();
            //    return true;
            //}
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cboProductName_KeyDown(object sender, KeyEventArgs e)
        {
            this.AcceptButton = btnSearch;
        }

        private void txtAdditionalDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void PrintDetailList(List<TransactionDetail> Dlist)
        {
            HashSet<TransactionDetail> hset = new HashSet<TransactionDetail>();
            // IEnumerable<TransactionDetail> SameCodeProducts = Dlist.Where(x=> !hset.Add(x));           
            IEnumerable<Nullable<long>> SameCodeProducts = Dlist.GroupBy(x => x.ProductId).Where(g => g.Count() > 1).Select(x => x.Key);
            if (SameCodeProducts.Count() > 0)
            {

                Isduplicate = true;

                PList = Dlist.GroupBy(x => new { x.Product, x.DiscountRate, x.UnitPrice })
                    .Select(y => new TransactionDetail()
                    {
                        Product = y.Key.Product,
                        Qty = (int)y.Sum(z => z.Qty),
                        DiscountRate = (decimal)y.Key.DiscountRate,
                        UnitPrice = (long)y.Key.UnitPrice,
                        TotalAmount = (long)y.Sum(z => z.TotalAmount)
                    }).ToList();
            }

        }
        private void txtExtraTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboCustomer.SelectedIndex != 0)
            {
                dgvPaymentType.Rows.Clear();
                lblChanges.Text = "0";
                SetCurrentCustomer(Convert.ToInt32(cboCustomer.SelectedValue.ToString()), false);

            }
            else
            {
                //Clear customer data
                CurrentCustomerId = 0;
                lblCustomerName.Text = "-";
                lblEmail.Text = "-";
                lblNRIC.Text = "-";
                lblPhoneNumber.Text = "-";
                lblbday.Text = "-";
            }
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

        private void dgvSalesItem_KeyDown(object sender, KeyEventArgs e)
        {
            AvoidAction();
            if (e.KeyData == Keys.Enter)
            {
                int col = dgvSalesItem.CurrentCell.ColumnIndex;
                int row = dgvSalesItem.CurrentCell.RowIndex;

                if (col == 8)
                {
                    object deleteProductCode = dgvSalesItem[1, row].Value;

                    //If product code is null, this is just new role without product. Do not need to delete the row.
                    if (deleteProductCode != null)
                    {

                        DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {
                            dgvSalesItem.Rows.RemoveAt(row);
                            UpdateTotalCost();
                            dgvSalesItem.CurrentCell = dgvSalesItem[0, row];

                        }
                    }
                }
                e.Handled = true;
            }
            ListenAction();
        }
        #endregion

        #region Function

        private List<TransactionDetail> GetTranscationListFromDataGridView()
        {
            pdp = entity.PointDeductionPercentage_History.Where(p => p.Active == true).OrderByDescending(x => x.Id).FirstOrDefault();

            List<TransactionDetail> DetailList = null;
            DetailList = new List<TransactionDetail>();
            dgvSalesItem.Refresh();
            foreach (DataGridViewRow row in dgvSalesItem.Rows)
            {
                if (!row.IsNewRow && row.Cells[10].Value != null && row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null)
                {
                    TransactionDetail transDetail = new TransactionDetail();

                    int qty = 0, productId = 0;
                    string batchNo = "";
                    bool alreadyinclude = false;
                    decimal discountRate = 0;
                    Int32.TryParse(row.Cells[10].Value.ToString(), out productId);
                    Int32.TryParse(row.Cells[2].Value.ToString(), out qty);
                    Decimal.TryParse(row.Cells[(int)sCol.DisPercent].Value.ToString(), out discountRate);

                    if (row.Cells[(int)sCol.BatchNo].Value != null)
                    {
                        batchNo = row.Cells[(int)sCol.BatchNo].Value.ToString();
                    }

                    //Check if the product is already include in above row
                    foreach (TransactionDetail td in DetailList)
                    {
                        if (td.ProductId == productId && td.DiscountRate == discountRate && td.BatchNo == batchNo)
                        {
                            Product tempProd = iTempP.Where(p => p.Id == productId).FirstOrDefault<Product>();
                            td.Qty = td.Qty + qty;
                            //td.TotalAmount = Convert.ToInt64(tempProd) * Convert.ToInt64( td.Qty);
                            // by SYM
                            td.TotalAmount = Convert.ToInt64(Convert.ToDecimal(row.Cells[8].Value));
                            alreadyinclude = true;
                        }
                    }

                    if (!alreadyinclude)
                    {
                        //Check productId is valid or not.

                        Product pro = iTempP.Where(p => p.Id == productId).FirstOrDefault<Product>();
                        if (pro != null)
                        {
                            transDetail.ProductId = pro.Id;
                            transDetail.UnitPrice = pro.Price;
                            transDetail.DiscountRate = discountRate;
                            transDetail.TaxRate = Convert.ToDecimal(pro.Tax.TaxPercent);
                            transDetail.Qty = qty;

                            // this expression statement is used to control double promotion rules by Discount percentage
                            // Customer must be VIP member , Double promotion rule must be activated , the discount rate of product must not be Zero when selling 
                            //by LHST
                            //modified by khs
                            if (!IsBirthday)
                            {
                                transDetail.IsDeductedBy = txtVIPID.Text.Trim() != "" && pdp != null && transDetail.DiscountRate != 0 ? pdp.DiscountRate : (decimal?)null;
                                if (transDetail.DiscountRate > pdp.DiscountRate)
                                {
                                    IsDetected = true;
                                }
                            }
                            else
                            {
                                transDetail.IsDeductedBy = (decimal?)null;
                            }
                            //transDetail.TotalAmount = Convert.ToInt64(getActualCost(pro, discountRate)) * qty;
                            // by SYM
                            transDetail.TotalAmount = Convert.ToInt64(Convert.ToDecimal(row.Cells[8].Value));
                            transDetail.IsDeleted = false;
                            transDetail.BatchNo = batchNo;
                            DetailList.Add(transDetail);
                        }
                    }
                }
            }

            return DetailList;
        }

        private void UpdateTotalCost()
        {
            int discount = 0, tax = 0, total = 0, totalqty = 0;

            int count = Convert.ToInt32(dgvSalesItem.Rows.Count - 1);
            bool shouldAdd = true;

            foreach (DataGridViewRow dgrow in dgvSalesItem.Rows)
            {
                shouldAdd = true;
                //check if the current one is new empty row
                if (!dgrow.IsNewRow && dgrow.Cells[(int)sCol.SKU].Value != null)
                {
                    string rowProductCode = string.Empty;
                    rowProductCode = dgrow.Cells[(int)sCol.SKU].Value.ToString().Trim();
                    if (dgrow.Index > 0 && dgrow.Index == dgvSalesItem.RowCount - 2)
                    {
                        for (int i = 0; i < dgrow.Index; i++)
                        {
                            if (dgvSalesItem.Rows[i].Cells[(int)sCol.SKU].Value != null && dgvSalesItem.Rows[i].Cells[(int)sCol.BatchNo].Value != null)
                            {
                                if (rowProductCode == dgvSalesItem.Rows[i].Cells[(int)sCol.SKU].Value.ToString() && dgrow.Cells[(int)sCol.BatchNo].Value.ToString() == dgvSalesItem.Rows[i].Cells[(int)sCol.BatchNo].Value.ToString())
                                {
                                    shouldAdd = false;
                                }
                            }
                        }
                    }
                    if (shouldAdd)
                    {
                        int qty = 0;
                        if (rowProductCode != string.Empty && dgrow.Cells[(int)sCol.Qty].Value != null && dgrow.Cells[(int)sCol.status].Value == null)
                        {
                            //Get qty
                            Int32.TryParse(dgrow.Cells[(int)sCol.Qty].Value.ToString(), out qty);
                            Product pro = iTempP.Where(p => p.ProductCode == rowProductCode).FirstOrDefault<Product>();
                            decimal productDiscount = 0;
                            if (dgrow.Cells[(int)sCol.DisPercent].Value != null)
                            {
                                Decimal.TryParse(dgrow.Cells[(int)sCol.DisPercent].Value.ToString(), out productDiscount);
                            }
                            else
                            {
                                if (IsBirthday)
                                {
                                    productDiscount = birthdayDiscount;
                                }
                                else
                                {
                                    productDiscount = pro.DiscountRate;
                                }
                            }

                            total += (int)Math.Ceiling(Convert.ToDecimal(dgrow.Cells[(int)sCol.Cost].Value));
                            discount += (int)Math.Ceiling(getDiscountAmount(pro.Price, productDiscount) * qty);
                            tax += (int)Math.Ceiling(getTaxAmount(pro) * qty);
                            totalqty += qty;
                        }
                    }
                }

            }
            // by SYM//TotalAmount
            lblTotal.Text = total.ToString();
            lblDiscountTotal.Text = discount.ToString();
            lblTaxTotal.Text = tax.ToString();
            lblQty.Text = totalqty.ToString();

            #region GiftSystem

            bool HasGift = false; bool IsProduct = false, IsLine = false, IsCategory = false, IsSubCategory = false, IsQtyValid = true, IsCost = true, IsSize = true, IsFilterQty = true;
            GiftList.Clear();

            DateTime CurrentDate = DateTime.Now.Date;
            List<GiftSystem> GiftSysList = entity.GiftSystems.Where(x => x.ValidTo >= CurrentDate && x.ValidFrom <= CurrentDate && x.IsActive == true).ToList();

            foreach (GiftSystem giftObj in GiftSysList)
            {
                IsQtyValid = false; IsCost = false;
                HasGift = false; IsProduct = false; IsLine = false; IsCategory = false; IsSubCategory = false; IsSize = false; IsFilterQty = false;
                if (giftObj != null)
                {
                    if (giftObj.UsePromotionQty == true)
                    {
                        List<AttachGiftSystemForTransaction> attachList = entity.AttachGiftSystemForTransactions.Where(x => x.AttachGiftSystemId == giftObj.Id).ToList();
                        if (attachList.Count >= giftObj.PromotionQty)
                        {
                            IsQtyValid = false;
                        }
                        else
                        {
                            IsQtyValid = true;
                        }
                    }
                    else
                    {
                        IsQtyValid = true;
                    }

                    if (giftObj.MustBuyCostFrom > 0 && giftObj.MustBuyCostTo > 0)
                    {
                        if (total < giftObj.MustBuyCostFrom || total > giftObj.MustBuyCostTo)
                        {
                            IsCost = false;
                        }
                        else
                        {
                            IsCost = true;
                        }

                    }
                    else if (giftObj.MustBuyCostFrom > 0 && giftObj.MustBuyCostTo == 0)
                    {
                        if (total < giftObj.MustBuyCostFrom)
                        {
                            IsCost = false;
                        }
                        else
                        {
                            IsCost = true;
                        }
                    }
                    else if (giftObj.MustBuyCostFrom == 0 && giftObj.MustBuyCostTo == 0)
                    {
                        IsCost = true;
                    }

                    if (IsQtyValid == true && IsCost == true)
                    {
                        proCount = 0;

                        #region 
                        foreach (DataGridViewRow dgrow in dgvSalesItem.Rows)
                        {
                            IsProduct = false; IsLine = false; IsCategory = false; IsSubCategory = false; IsSize = false; IsFilterQty = false;
                            IsLine = false;
                            int currentProductId = Convert.ToInt32(dgrow.Cells[(int)sCol.pId].Value);
                            int Qty = Convert.ToInt32(dgrow.Cells[(int)sCol.Qty].Value);
                            Product pro = iTempP.Where(p => p.Id == currentProductId).FirstOrDefault<Product>();
                            if (pro != null)
                            {
                                if (giftObj.UseProductFilter == true)
                                {
                                    if (pro.Id == giftObj.MustIncludeProductId)
                                    {
                                        IsProduct = true;
                                    }
                                }
                                //if (giftObj.UseBrandFilter == true)
                                //{
                                //    if (pro.BrandId == giftObj.FilterBrandId)
                                //    {
                                //        IsBrand = true;
                                //    }
                                //}

                                if (giftObj.UseLineFilter == true)
                                {
                                    if (pro.LineId == giftObj.FilterLineId)
                                    {
                                        IsLine = true;
                                    }
                                }
                                if (giftObj.UseCategoryFilter == true)
                                {
                                    if (pro.ProductCategoryId == giftObj.FilterCategoryId)
                                    {
                                        IsCategory = true;
                                    }
                                }
                                if (giftObj.UseSubCategoryFilter == true)
                                {
                                    if (pro.ProductSubCategoryId == giftObj.FilterSubCategoryId)
                                    {
                                        IsSubCategory = true;
                                    }
                                }
                                if (giftObj.UseSizeFilter == true)
                                {
                                    if (pro.Size != null)
                                    {
                                        if (pro.Size == giftObj.FilterSize.ToString())
                                        {
                                            IsSize = true;
                                        }
                                    }
                                }

                                if (giftObj.UseQtyFilter == true)
                                {
                                    if (giftObj.UseProductFilter == IsProduct && giftObj.UseLineFilter == IsLine && giftObj.UseCategoryFilter == IsCategory && giftObj.UseSubCategoryFilter == IsSubCategory && giftObj.UseSizeFilter == IsSize)
                                    {
                                        proCount += Qty;
                                    }

                                    if (proCount >= giftObj.FilterQty)
                                    {
                                        IsFilterQty = true;
                                    }

                                }
                                if (giftObj.UseProductFilter == IsProduct && giftObj.UseLineFilter == IsLine && giftObj.UseCategoryFilter == IsCategory && giftObj.UseSubCategoryFilter == IsSubCategory && giftObj.UseSizeFilter == IsSize && giftObj.UseQtyFilter == IsFilterQty)
                                {
                                    HasGift = true;
                                }
                            }
                        }

                        #endregion
                        if (HasGift == true)
                        {
                            GiftList.Add(giftObj);
                            if (giftObj.UseQtyFilter == true)
                            {
                                proCount = 0;
                            }
                        }
                    }
                }
            }

            if (GiftList.Count > 0)
            {
                plGift.Visible = true;
                chkGiftList.Items.Clear();
                lblGift.Visible = true;

                foreach (GiftSystem gObj in GiftList)
                {
                    if (gObj.Product1 != null)
                    {
                        StockFillingFromSAP sp = entity.StockFillingFromSAPs.Where(x => x.ProductId == gObj.Product1.Id && x.IsActive == true && x.AvailableQty > 0).OrderBy(x => x.ExpireDate).FirstOrDefault();
                        if (sp != null)
                        {
                            if (gObj.PriceForGiftProduct == 0)
                            {
                                chkGiftList.Items.Add(gObj.Product1.Name + " is given for gift");
                            }
                            else
                            {
                                chkGiftList.Items.Add(gObj.Product1.Name + " is purchased with price " + gObj.PriceForGiftProduct);
                            }
                        }
                        else
                        {
                            lblGift.Text = "Gift Sets Out of Stock!";
                            plGift.Visible = false;
                        }
                    }
                    else if (gObj.GiftCashAmount > 0)
                    {
                        chkGiftList.Items.Add("Discount amount " + gObj.GiftCashAmount + " is given for current transaction");
                        plGift.Visible = true;
                    }
                    else if (gObj.DiscountPercentForTransaction > 0)
                    {
                        chkGiftList.Items.Add("Discount percent " + gObj.GiftCashAmount + " is given for current transaction");
                        plGift.Visible = true;
                    }
                }
                plGift.Controls.Add(chkGiftList);
            }
            else
            {
                lblGift.Visible = false;
                plGift.Visible = false;
            }

            #endregion

            CalculateChargesAmount();
        }

        //private decimal getActualCost(Product prod)
        //{
        //    decimal? actualCost = 0;
        //    //decrease discount ammount            
        //    actualCost = prod.Price - ((prod.Price / 100) * prod.DiscountRate);



        //    //add tax ammount            
        //    actualCost = actualCost + ((prod.Price / 100) * prod.Tax.TaxPercent);
        //    return (decimal)actualCost;
        //}

        private decimal getActualCost(Product prod, decimal discountRate)
        {

            decimal? actualCost = 0;
            //decrease discount ammount            
            actualCost = prod.Price - ((prod.Price / 100) * discountRate);
            //add tax ammount            
            actualCost = actualCost + ((prod.Price / 100) * prod.Tax.TaxPercent);
            return (decimal)actualCost;
        }
        private decimal getActualCost(long productPrice, decimal productDiscount, decimal tax)
        {
            decimal? actualCost = 0;
            //decrease discount ammount            
            actualCost = productPrice - ((productPrice / 100) * productDiscount);
            //add tax ammount            
            actualCost = actualCost + ((productPrice / 100) * tax);
            return (decimal)actualCost;
        }
        private decimal getDiscountAmount(long productPrice, decimal productDiscount)
        {
            return (((decimal)productPrice / 100) * productDiscount);
        }

        private decimal getTaxAmount(Product prod)
        {
            return ((prod.Price / 100) * Convert.ToDecimal(prod.Tax.TaxPercent));
        }

        private decimal getTaxAmount(long productPrice, decimal tax)
        {
            return ((productPrice / 100) * Convert.ToDecimal(tax));
        }
        public void LoadDraft(string TransactionId)
        {
            entity = new POSEntities();
            Clear();
            DraftId = TransactionId;
            isload = false;



            Transaction draft = (from ts in entity.Transactions where ts.Id == TransactionId && ts.IsComplete == false && ts.IsDeleted == false select ts).FirstOrDefault<Transaction>();

            if (draft != null)
            {
                //pre add the rows
                //dgvSalesItem.Rows.Insert(0, draft.TransactionDetails.Count());

                var _tranDetails = (from a in entity.TransactionDetails where a.TransactionId == TransactionId select a).ToList();
                dgvSalesItem.Rows.Insert(0, _tranDetails.Count());

                int index = 0;
                //foreach (TransactionDetail detail in draft.TransactionDetails)
                foreach (TransactionDetail detail in _tranDetails)
                {
                    //If product still exist
                    if (detail.Product != null)
                    {
                        Utility.AddProductAvailableQty(entity, (long)detail.ProductId, detail.BatchNo, (int)detail.Qty);
                        List<AvailableProductQtyWithBatch> tempProductControlList = availablePList == null ? null : availablePList.Where(Product => Product.ProductID == detail.ProductId && Product.BatchNo == detail.BatchNo).ToList();
                        if (tempProductControlList == null || tempProductControlList.Count == 0)
                        {
                            AddNew4AvailableProductQtyWithBatch((long)detail.ProductId, detail.BatchNo);
                        }
                        long pid = (long)detail.ProductId;
                        tempProductControlList = availablePList.Where(Product => Product.ProductID == pid && Product.AvailableQty > 0).OrderBy(p => p.ExpireDate).ToList();

                        isload = true;

                        DataGridViewRow row = dgvSalesItem.Rows[index];
                        //fill the current row with the product information                       
                        row.Cells[(int)sCol.BarCode].Value = detail.Product.Barcode;
                        row.Cells[(int)sCol.SKU].Value = detail.Product.ProductCode;
                        BindBatchNo(tempProductControlList, row.Cells[(int)sCol.BatchNo] as DataGridViewComboBoxCell, tempProductControlList.Where(x => x.BatchNo == detail.BatchNo).Select(x => x.BatchNo).FirstOrDefault());

                        row.Cells[(int)sCol.Qty].Value = detail.Qty;
                        row.Cells[(int)sCol.ItemName].Value = detail.Product.Name;
                        row.Cells[(int)sCol.SalePrice].Value = detail.Product.Price;
                        row.Cells[(int)sCol.DisPercent].Value = detail.DiscountRate;
                        row.Cells[(int)sCol.Tax].Value = detail.Product.Tax.TaxPercent;
                        row.Cells[(int)sCol.Cost].Value = getActualCost(detail.Product, detail.DiscountRate) * detail.Qty;
                        row.Cells[(int)sCol.pId].Value = detail.ProductId;
                        index++;

                    }
                }

                //txtAdditionalDiscount.Text = draft.DiscountAmount.ToString();
                txtExtraTax.Text = draft.TaxAmount.ToString();
                if (draft.Customer != null)
                {
                    SetCurrentCustomer((int)draft.CustomerId, true);
                }
                entity = new POSEntities();
                Transaction currentt = entity.Transactions.Where(ts => ts.Id == TransactionId && ts.IsComplete == false).FirstOrDefault();
                foreach (TransactionDetail td in entity.TransactionDetails.Where(x => x.TransactionId == currentt.Id))
                {
                    entity.TransactionDetails.Remove(td);
                }
                entity.Transactions.Remove(currentt);
                entity.SaveChanges();
                //draft = entity.Transactions.Where(ts => ts.Id == TransactionId && ts.IsComplete == false).FirstOrDefault();

                //draft.IsDeleted = true;
                //entity.Entry(draft).State = EntityState.Modified;
                //entity.SaveChanges();

                UpdateTotalCost();
            }
            else
            {
                //no associate transaction
                MessageBox.Show("The item doesn't exist anymore!");
            }

            isDraft = true;
        }

        public void DeleteCopy(string TransactionId)
        {

            Clear();
            DraftId = TransactionId;
            Transaction draft = (from ts in entity.Transactions where ts.Id == TransactionId select ts).FirstOrDefault<Transaction>();
            decimal disTotal = 0, taxTotal = 0;
            //Delete transaction
            draft.IsDeleted = true;
            draft.UpdatedDate = DateTime.Now;

            foreach (TransactionDetail detail in draft.TransactionDetails.Where(x => x.IsDeleted != true))
            {
                detail.IsDeleted = true;
                detail.Product.Qty = detail.Product.Qty + detail.Qty;

                if (detail.Product.IsWrapper == true)
                {
                    List<WrapperItem> wplist = detail.Product.WrapperItems.ToList();

                    foreach (WrapperItem wp in wplist)
                    {
                        wp.Product1.Qty = wp.Product1.Qty + detail.Qty;
                    }
                }
            }
            DeleteLog dl = new DeleteLog();
            dl.DeletedDate = DateTime.Now;
            dl.CounterId = MemberShip.CounterId;
            dl.UserId = MemberShip.UserId;
            dl.IsParent = true;
            dl.TransactionId = draft.Id;
            entity.DeleteLogs.Add(dl);
            entity.SaveChanges(); ////// 3333333

            Transaction parenttransaction = entity.Transactions.Where(x => x.Id == TransactionId).FirstOrDefault();
            foreach (TransactionDetail td in parenttransaction.TransactionDetails)
            {
                parenttransaction.TotalAmount = parenttransaction.TotalAmount - td.TotalAmount;
            }
            entity.SaveChanges(); /////44444444

            //copy transaction
            if (draft != null)
            {
                try
                {
                    AvoidAction();
                    //pre add the rows
                    dgvSalesItem.Rows.Insert(0, draft.TransactionDetails.Count());

                    int index = 0;
                    foreach (TransactionDetail detail in draft.TransactionDetails)
                    {
                        //If product still exist
                        if (detail.Product != null)
                        {
                            Utility.AddProductAvailableQty(entity, (long)detail.ProductId, detail.BatchNo, (int)detail.Qty);

                            List<AvailableProductQtyWithBatch> tempProductControlList = availablePList == null ? null : availablePList.Where(Product => Product.ProductID == detail.ProductId && Product.BatchNo == detail.BatchNo).ToList();
                            if (tempProductControlList == null || tempProductControlList.Count == 0)
                            {
                                AddNew4AvailableProductQtyWithBatch((long)detail.ProductId, detail.BatchNo);
                            }
                            long pid = (long)detail.ProductId;
                            tempProductControlList = availablePList.Where(Product => Product.ProductID == pid && Product.AvailableQty > 0).OrderBy(p => p.ExpireDate).ToList();

                            DataGridViewRow row = dgvSalesItem.Rows[index];
                            //fill the current row with the product information
                            row.Cells[(int)sCol.BarCode].Value = detail.Product.Barcode;
                            row.Cells[(int)sCol.SKU].Value = detail.Product.ProductCode;
                            row.Cells[(int)sCol.Qty].Value = detail.Qty;
                            BindBatchNo(tempProductControlList, row.Cells[(int)sCol.BatchNo] as DataGridViewComboBoxCell, tempProductControlList.Where(x => x.BatchNo == detail.BatchNo).Select(x => x.BatchNo).FirstOrDefault());

                            row.Cells[(int)sCol.ItemName].Value = detail.Product.Name;
                            row.Cells[(int)sCol.SalePrice].Value = detail.UnitPrice;

                            //row.Cells[(int)sCol.DisPercent].ReadOnly = true;
                            row.Cells[(int)sCol.DisPercent].Value = detail.DiscountRate;
                            //row.Cells[(int)sCol.DisPercent].ReadOnly = false;

                            row.Cells[(int)sCol.Tax].Value = detail.TaxRate;
                            row.Cells[(int)sCol.Cost].Value = getActualCost(Convert.ToInt64(detail.UnitPrice), detail.DiscountRate, detail.TaxRate) * detail.Qty;
                            disTotal += Convert.ToInt64(getDiscountAmount(Convert.ToInt64(detail.UnitPrice), detail.DiscountRate) * detail.Qty);
                            taxTotal += Convert.ToInt64(getTaxAmount(Convert.ToInt64(detail.UnitPrice), detail.TaxRate) * detail.Qty);
                            row.Cells[(int)sCol.pId].Value = detail.ProductId;
                            index++;
                            //dgvSalesItem.NotifyCurrentCellDirty(true);

                            //dgvSalesItem.EndEdit();
                        }

                    }

                    //txtAdditionalDiscount.Text = (draft.DiscountAmount - disTotal).ToString();
                    txtExtraTax.Text = (draft.TaxAmount - taxTotal).ToString();
                    if (draft.Customer != null)
                    {
                        SetCurrentCustomer((int)draft.CustomerId, true);
                    }
                    UpdateTotalCost();

                }
                finally
                {
                    ListenAction();
                }
            }


        }
        public void Clear()
        {
            CurrentCustomerId = 0;

            dgvSalesItem.Rows.Clear();
            availablePList.Clear();
            dgvSalesItem.Focus();
            //txtAdditionalDiscount.Text = "0";
            txtExtraTax.Text = "0";
            lblTotal.Text = "0";
            lblTaxTotal.Text = "0";
            lblDiscountTotal.Text = "0";
            isDraft = false;
            DraftId = string.Empty;
            dgvSearchProductList.DataSource = "";
            cboProductName.SelectedIndex = 0;
            List<Product> productList = new List<Product>();
            Product productObj = new Product();
            productObj.Id = 0;
            productObj.Name = "";
            productList.Add(productObj);
            productList.AddRange(iTempP.ToList());
            cboProductName.DataSource = productList;
            cboProductName.DisplayMember = "Name";
            cboProductName.ValueMember = "Id";
            cboProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProductName.AutoCompleteSource = AutoCompleteSource.ListItems;
            //lblGift.Enabled = false;
            lblGift.Visible = false;
            plGift.Visible = false;
            chkGiftList.Items.Clear();
            cboCustomer.SelectedIndex = 0;
            txtVIPID.Text = "";
            ReloadCustomerList();
            txtGiftDiscount.Text = "0";
            lblQty.Text = "0";
            // cboPaymentMethod.SelectedIndex = 0;
            cboPaymentType.SelectedIndex = 0;
            txtAmount.Clear();
            dgvPaymentType.Rows.Clear();
            // cboPaymentMethod.Enabled = true;
            cboPaymentType.Enabled = true;
            txtAmount.Enabled = true;
            btnPaymentAdd.Enabled = true;
            lblChanges.Text = "0";
            cboPaymentMethod.Enabled = true;
            cboPaymentMethod.SelectedIndex = 0;
            lblBDMessage.Visible = false;
            lblbday.BackColor = Color.Transparent;
            IsBirthday = false;
            IsDetected = false;
            disRate = 0;
            lblGift.Text = "Gift Products : ";
            GiftList.Clear();
        }

        public void SetCurrentCustomer(Int32 CustomerId, bool isLoad)
        {
            CurrentCustomerId = CustomerId;
            Customer currentCustomer = entity.Customers.Where(x => x.Id == CustomerId).FirstOrDefault();

            if (currentCustomer != null)
            {
                DateTime dtToday = DateTime.Now.Date;

                if (currentCustomer.Name != "Default" && currentCustomer.PromoteDate != null && currentCustomer.PromoteDate.Value.Date != dtToday && currentCustomer.CustomerTypeId != nonVIPId && currentCustomer.CustomerTypeId != null && (currentCustomer.LatestRevokeDate == null || currentCustomer.LatestRevokeDate < dtToday) && backMonths4Reset > 0)
                {

                    DateTime dtDate = DateTime.Now.AddMonths(0 - backMonths4Reset);
                    var iqTrans = entity.Transactions.Where(x => x.CustomerId == currentCustomer.Id && x.IsDeleted == false && x.IsComplete == true && x.DateTime >= dtDate && x.Type == "Sale").FirstOrDefault();
                    if (iqTrans == null)
                    {
                        DialogResult drs = MessageBox.Show("This customer has no transaction in the last " + backMonths4Reset + " months.", "Do you want to revoke?", MessageBoxButtons.YesNo);
                        if (drs == DialogResult.Yes)
                        {
                            Utility.InsertRevokeHistoryData(currentCustomer, nonVIPId, "Auto revoke from sale from.");
                            currentCustomer.CustomerTypeId = nonVIPId;
                            currentCustomer.VIPMemberId = null;
                        }
                    }
                }
                lblCustomerName.Text = currentCustomer.Title + " " + currentCustomer.Name;
                lblNRIC.Text = currentCustomer.NRC;
                lblPhoneNumber.Text = currentCustomer.PhoneNumber;
                lblEmail.Text = currentCustomer.Email;
                cboCustomer.Text = currentCustomer.Name;
                cboCustomer.SelectedItem = currentCustomer;
                cboCustomer.SelectedValue = currentCustomer.Id;
                lblbday.Text = currentCustomer.Birthday != null ? ((DateTime)currentCustomer.Birthday).ToString("dd-MMM-yyyy") : "-";
                txtVIPID.Text = currentCustomer.VIPMemberId;
                // update 7 dec-2022 khs
                if (currentCustomer.Birthday == null)
                {
                    lblbday.Text = "-";
                    lblBDMessage.ResetText();
                    IsBirthday = false;
                    disRate = 0;
                    lblbday.BackColor = System.Drawing.Color.Transparent;
                    if (dgvSalesItem.Rows.Count > 0)
                    {
                        for (int i = 0; i < dgvSalesItem.Rows.Count - 1; i++)
                        {
                            if (dgvSalesItem.Rows[i].Cells[(int)sCol.pId].Value != null && !string.IsNullOrEmpty(dgvSalesItem.Rows[i].Cells[(int)sCol.pId].Value.ToString()))
                            {
                                string GridProductCOde = (string)dgvSalesItem.Rows[i].Cells[1].Value;
                                Product itemp = iTempP.Where(p => p.ProductCode == GridProductCOde).FirstOrDefault();
                                if (itemp != null && itemp.DiscountRate == 0 && !isLoad)
                                {

                                    dgvSalesItem.Rows[i].Cells[(int)sCol.DisPercent].Value = "0.0";
                                    int qty = Convert.ToInt32(dgvSalesItem.Rows[i].Cells[(int)sCol.Qty].Value);
                                    dgvSalesItem.Rows[i].Cells[(int)sCol.Cost].Value = getActualCost(itemp, itemp.DiscountRate) * qty;
                                }
                            }
                            else
                            {
                                dgvSalesItem.Rows.RemoveAt(i);
                            }
                        }
                        UpdateTotalCost();
                    }
                }
                else
                {
                    var bod = Convert.ToDateTime(currentCustomer.Birthday).ToString("dd-MMM-yyyy");
                    lblbday.Text = bod.ToString();

                    int count = dgvSalesItem.Rows.Count;
                    if (Convert.ToDateTime(lblbday.Text).Month == System.DateTime.Now.Month && !string.IsNullOrEmpty(currentCustomer.VIPMemberId))
                    {
                        Application.DoEvents();
                        //int cusId = Convert.ToInt32(cboCustomer.SelectedValue);
                        //var bdList = (from t in entity.Transactions where t.CustomerId == cusId && t.BDDiscountAmt != 0 select t).ToList();
                        //var bdPeryear = entity.Transactions.Where(t => t.CustomerId == CustomerId && t.DateTime.Year == DateTime.Now.Year && false == t.IsDeleted && t.Loc_IsCalculatePoint == true && t.DiscountAmount > 0).Join(;
                        var bdPeryear = from t in entity.Transactions
                                        join td in entity.TransactionDetails on t.Id equals td.TransactionId
                                        where t.CustomerId == CustomerId && t.DateTime.Year == DateTime.Now.Year && false == t.IsDeleted && t.Loc_IsCalculatePoint == true && t.DiscountAmount > 0
                                        && td.BdDiscounted == true
                                        select t.Id;

                        if ((bdPeryear == null || bdPeryear.Count() == 0) && birthdayDiscount > 0)
                        {
                            //var a=bdPeryear.Where(x=>x.DateTime.Month==DateTime.Now.Month).FirstOrDefault().TransactionDetails
                            lblbday.BackColor = System.Drawing.Color.Yellow;
                            IsBirthday = true;
                            disRate = birthdayDiscount;
                            if (dgvSalesItem.Rows.Count > 0)
                            {

                                for (int i = 0; i < count - 1; i++)
                                {
                                    if (Convert.ToDecimal(dgvSalesItem.Rows[i].Cells[6].Value) == 0)
                                    {
                                        //bool isFoc = false;
                                        //if (dgvSalesItem.Rows[i].Cells[(int)sCol.FOC].Value != null && dgvSalesItem.Rows[i].Cells[(int)sCol.colFOC].Value.ToString() == "FOC")
                                        //{
                                        //    isFoc = true;
                                        //}
                                        dgvSalesItem.Rows[i].Cells[6].Value = birthdayDiscount;
                                        string GridProductCOde = (string)dgvSalesItem.Rows[i].Cells[1].Value;
                                        Product itemp = iTempP.Where(p => p.ProductCode == GridProductCOde).FirstOrDefault();
                                        if (itemp != null && itemp.DiscountRate == 0 && !isLoad)
                                        {
                                            int qty = Convert.ToInt32(dgvSalesItem.Rows[i].Cells[(int)sCol.Qty].Value);
                                            dgvSalesItem.Rows[i].Cells[(int)sCol.Cost].Value = getActualCost(itemp, birthdayDiscount) * qty;
                                        }
                                    }
                                }
                                lblBDMessage.Visible = true;
                                lblBDMessage.Text = "Birthday Discount ( " + birthdayDiscount + "% ) will be discounted for a Transaction.";
                                UpdateTotalCost();
                            }
                        }
                        else
                        {
                            lblBDMessage.ResetText();
                            lblBDMessage.Text = "";
                            lblbday.BackColor = System.Drawing.Color.Transparent;
                            IsBirthday = false;
                            disRate = 0;
                        }
                    }
                    else
                    {
                        lblBDMessage.ResetText();
                        lblBDMessage.Text = "";
                        IsBirthday = false;
                        disRate = 0;
                        lblbday.BackColor = System.Drawing.Color.Transparent;
                        if (dgvSalesItem.Rows.Count > 0)
                        {
                            for (int i = 0; i < count - 1; i++)
                            {
                                string gridProductCode = (string)dgvSalesItem.Rows[i].Cells[1].Value.ToString();
                                if (iTempP.Where(p => p.ProductCode == gridProductCode).FirstOrDefault().DiscountRate == 0)
                                {
                                    dgvSalesItem.Rows[i].Cells[6].Value = "0.0";
                                }
                            }
                            UpdateTotalCost();


                        }
                    }
                }
                //end here khs
                UpdateTotalCost();
            }
        }

        public void ReloadCustomerList()
        {
            try
            {
                //Add Customer List with default option
                entity = new POSEntities();
                List<APP_Data.Customer> customerList = new List<APP_Data.Customer>();
                APP_Data.Customer customer = new APP_Data.Customer();
                customer.Id = 0;
                customer.Name = "None";
                customerList.Add(customer);
                customerList.AddRange(entity.Customers.OrderBy(x => x.Name).ToList());
                cboCustomer.DataSource = customerList;
                cboCustomer.DisplayMember = "Name";
                cboCustomer.ValueMember = "Id";
            }
            catch { }
        }


        private void Cell_ReadOnly()
        {
            if (_rowIndex != -1)
            {
                DataGridViewRow row = dgvSalesItem.Rows[_rowIndex];
                if (_rowIndex > 0)
                {
                    if (row.Cells[1].Value != null)
                    {
                        string currentProductCode = row.Cells[1].Value.ToString();
                        List<string> _productList = dgvSalesItem.Rows
                               .OfType<DataGridViewRow>()
                               .Where(r => r.Cells[1].Value != null)
                               .Select(r => r.Cells[1].Value.ToString())
                               .ToList();

                        List<string> _checkProList = new List<string>();

                        _checkProList = (from p in _productList where p.Contains(currentProductCode) select p).ToList();
                        _checkProList.RemoveAt(_checkProList.Count - 1);
                        if (_checkProList.Count == 0)
                        {
                            dgvSalesItem.Rows[_rowIndex].Cells[0].ReadOnly = true;
                            dgvSalesItem.Rows[_rowIndex].Cells[1].ReadOnly = true;
                        }
                    }
                }
                else if (_rowIndex == 0 && dgvSalesItem.Rows.Count > 1)
                {
                    dgvSalesItem.Rows[_rowIndex].Cells[0].ReadOnly = true;
                    dgvSalesItem.Rows[_rowIndex].Cells[1].ReadOnly = true;
                }

            }


            dgvSalesItem.CurrentCell = dgvSalesItem[0, dgvSalesItem.Rows.Count - 1];

        }
        private int CountProductQtyWithBatchInGrid(string currentProductId, string BatchNo)
        {
            try
            {
                return (from r in dgvSalesItem.Rows.Cast<DataGridViewRow>()
                        where r.Cells[(int)sCol.pId].Value != null && r.Cells[(int)sCol.pId].Value.ToString() == currentProductId
                        && r.Cells[(int)sCol.BatchNo].Value != null && r.Cells[(int)sCol.Qty].Value != null && r.Cells[(int)sCol.BatchNo].Value.ToString() == BatchNo
                        select int.Parse(r.Cells[(int)sCol.Qty].Value.ToString())).Sum();

            }
            catch
            {
                return 0;
            }
        }

        private bool Check_SameProductCode_BatchNo(long currentProductId, string batchNo)
        {
            bool check = false;
            List<int> _indexCount = (from r in dgvSalesItem.Rows.Cast<DataGridViewRow>()
                                     where r.Cells[(int)sCol.pId].Value != null && Convert.ToInt64(r.Cells[(int)sCol.pId].Value.ToString()) == currentProductId &&
                                     r.Cells[(int)sCol.BatchNo].EditedFormattedValue.ToString() == batchNo
                                     select r.Index).ToList();


            if (_indexCount.Count > 1)
            {


                _indexCount.RemoveAt(_indexCount.Count - 1);

                int index = (from r in dgvSalesItem.Rows.Cast<DataGridViewRow>()
                             where r.Cells[(int)sCol.pId].Value != null && Convert.ToInt64(r.Cells[(int)sCol.pId].Value.ToString()) == currentProductId
                              && r.Cells[(int)sCol.BatchNo].Value.ToString() == batchNo
                             select r.Index).FirstOrDefault();


                int newQty = Convert.ToInt32(dgvSalesItem.Rows[index].Cells[(int)sCol.Qty].Value) + 1;
                dgvSalesItem.Rows[index].Cells[(int)sCol.Qty].Value = newQty;
                decimal drate = Convert.ToDecimal(dgvSalesItem.Rows[index].Cells[(int)sCol.DisPercent].Value) / 100;
                int UnitPrice = Convert.ToInt32(dgvSalesItem.Rows[index].Cells[(int)sCol.SalePrice].Value);

                dgvSalesItem.Rows[index].Cells[(int)sCol.Cost].Value = (UnitPrice - (UnitPrice * drate)) * newQty;

                dgvSalesItem.Rows[dgvSalesItem.Rows.Count - 2].Cells[(int)sCol.pId].Value = null; // to not include the last row in updatetotalcost()

                UpdateTotalCost();

                BeginInvoke(new Action(() => dgvSalesItem.EndEd‌​it())); // make row commit before deleting
                                                                         //dgvSalesItem.Rows.RemoveAt(dgvSalesItem.Rows.Count - 2);
                try
                {
                    this.BeginInvoke((MethodInvoker)delegate {
                        if (dgvSalesItem.Rows.Count > 1)
                            dgvSalesItem.Rows.RemoveAt(dgvSalesItem.Rows.Count - 2);
                    });
                }
                catch
                { }

                check = true;

            }
            else
            {
                isload = true;
                check = false;
            }

            return check;
        }

        //private bool Check_ProductCode_Exist(string currentProductCode)
        //{
        //    bool check = false;
        //    List<int> _indexCount = (from r in dgvSalesItem.Rows.Cast<DataGridViewRow>()
        //                             where r.Cells[1].Value != null && r.Cells[1].Value.ToString() == currentProductCode
        //                             select r.Index).ToList();
        //    if (_indexCount.Count > 1)
        //    {
        //        _indexCount.RemoveAt(_indexCount.Count - 1);
        //        int index = (from r in dgvSalesItem.Rows.Cast<DataGridViewRow>()
        //                     where r.Cells[1].Value != null && r.Cells[1].Value.ToString() == currentProductCode
        //                     select r.Index).FirstOrDefault();
        //        dgvSalesItem.Rows[index].Cells[2].Value = Convert.ToInt32(dgvSalesItem.Rows[index].Cells[2].Value) + 1;
        //        BeginInvoke(new Action(delegate { dgvSalesItem.Rows.RemoveAt(dgvSalesItem.Rows.Count - 2); }));
        //        dgvSalesItem.Rows[dgvSalesItem.Rows.Count - 2].Cells[11].Value = "Delete";
        //        check = true;
        //    }
        //    return check;
        //}

        #endregion                                                        
        public enum sCol
        {
            BarCode,
            SKU,
            Qty,
            ItemName,
            BatchNo,
            SalePrice,
            DisPercent,
            Tax,
            Cost,
            Delete,
            pId,
            status
        }
        private void lbAdvanceSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CustomerSearch form = new CustomerSearch();
            form.ShowDialog();
        }
        private void chkGiftList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int i = chkGiftList.SelectedIndex;
            if (i >= 0 && i < GiftList.Count)
            {
                if (chkGiftList.GetItemChecked(i) == false)
                {
                    long total = Convert.ToInt64(lblTotal.Text);
                    int DisAmount = Convert.ToInt32(txtGiftDiscount.Text);
                    if (GiftList[i].Product1 != null)
                    {
                        total += GiftList[i].PriceForGiftProduct;
                    }
                    else if (GiftList[i].GiftCashAmount > 0)
                    {
                        total -= (long)GiftList[i].GiftCashAmount;
                        DisAmount += (int)GiftList[i].GiftCashAmount;
                    }
                    else if (GiftList[i].DiscountPercentForTransaction > 0)
                    {
                        total -= (long)(total * (GiftList[i].GiftCashAmount / 100));
                        DisAmount += (int)(total * (GiftList[i].GiftCashAmount / 100));
                    }
                    // by SYM//TotalAmount
                    lblTotal.Text = total.ToString();
                    txtGiftDiscount.Text = DisAmount.ToString();
                }
                else
                {
                    long total = Convert.ToInt64(lblTotal.Text);
                    int DisAmount = Convert.ToInt32(txtGiftDiscount.Text);
                    if (GiftList[i].Product1 != null)
                    {
                        total -= GiftList[i].PriceForGiftProduct;
                    }
                    else if (GiftList[i].GiftCashAmount > 0)
                    {
                        total += (long)GiftList[i].GiftCashAmount;
                        DisAmount -= (int)GiftList[i].GiftCashAmount;
                    }
                    else if (GiftList[i].DiscountPercentForTransaction > 0)
                    {
                        total += (long)(total * (GiftList[i].GiftCashAmount / 100));
                        DisAmount -= (int)(total * (GiftList[i].GiftCashAmount / 100));
                    }
                    // by SYM//TotalAmount
                    lblTotal.Text = total.ToString();
                    txtGiftDiscount.Text = DisAmount.ToString();
                }
            }
        }


        private void dgvSalesItem_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            // AvoidAction();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSalesItem.Rows[e.RowIndex];
                dgvSalesItem.CommitEdit(new DataGridViewDataErrorContexts());
                if (row.Cells[(int)sCol.BarCode].Value == null && row.Cells[(int)sCol.SKU].Value == null && row.Cells[(int)sCol.Qty].Value == null && row.Cells[(int)sCol.BatchNo].Value == null)
                {
                    if (row.Cells[(int)sCol.status].Value != null)
                    {
                        BeginInvoke(new Action(delegate { dgvSalesItem.Rows.RemoveAt(e.RowIndex); }));
                    }
                }
                else if (mssg == "Wrong")
                {
                    if (row.Cells[(int)sCol.status].Value != null)
                    {
                        BeginInvoke(new Action(delegate { dgvSalesItem.Rows.RemoveAt(e.RowIndex); }));
                        if (row.Cells[(int)sCol.BarCode].Value != null)
                        {
                            dgvSalesItem.CurrentCell = dgvSalesItem[0, e.RowIndex];
                        }
                        else if (row.Cells[(int)sCol.SKU].Value != null)
                        {
                            dgvSalesItem.CurrentCell = dgvSalesItem[1, e.RowIndex];
                        }
                        mssg = "";
                    }
                }
            }
            //ListenAction();
        }

        private void cboCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            cboCustomer.DroppedDown = true;
        }

        private void cboCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboCustomer.DroppedDown = true;
        }

        private void cboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedId = Convert.ToInt32(cboPaymentMethod.SelectedValue);
                cboPaymentType.DataSource = null;
                var paymentType = iTempSubPaymentMethod.Where(x => x.PaymentTypeId == selectedId).ToList();//iTempPaymentMethod.Where(x => x.PaymentParentId == selectedId).ToList();
                if (paymentType.Count == 0)
                {
                    cboPaymentType.DataSource = paymentType;//iTempPaymentMethod.Where(x => x.Id == selectedId).ToList();
                }
                else
                {
                    cboPaymentType.DataSource = paymentType;
                }

                cboPaymentType.DisplayMember = "Name";
                cboPaymentType.ValueMember = "Id";
                cboPaymentType.SelectedIndex = 0;
                txtAmount.Enabled = cboPaymentType.Text.Trim() == "FOC" ? false : true;
            }
            catch
            {

            }
        }
        private void CalculateChargesAmount()
        {
            int paidAmount = 0; bool isFoc = false;
            int discount = 0;
            //if (!String.IsNullOrWhiteSpace(txtAdditionalDiscount.Text))
            //{
            //    discount = Convert.ToInt32(txtAdditionalDiscount.Text);
            //}

            foreach (DataGridViewRow row in dgvPaymentType.Rows)
            {
                if (row.Cells[5].Value == null)
                {
                    paidAmount = 0;
                    isFoc = true;
                }
                else
                {
                    paidAmount += Convert.ToInt32(row.Cells[5].Value);

                }
            }
            int totalAmount = Convert.ToInt32(lblTotal.Text);
            int changesAmount = totalAmount - (paidAmount + discount);
            lblChanges.Text = changesAmount >= 0 ? changesAmount.ToString() : (changesAmount * -1).ToString();
            labelChanges.Text = changesAmount >= 0 ? "Payable Amount" : "Changes";
            if (isFoc)
            {
                lblChanges.Text = "0";
            }
        }
        private bool verifyDiscount()
        {
            int dis = 0;
            int.TryParse(lblDiscountTotal.Text, out dis);
            if (dis > 0)
            {
                MessageBox.Show("Cannot use product discount and gift card at the same time.", "Unable to add/pay!");
                return false;
            }

            return true;
        }
        private void btnPaymentAdd_Click(object sender, EventArgs e)
        {
            if (cboPaymentType.SelectedIndex != -1 && cboPaymentType.Text.Trim() != "FOC")
            {
                if (!string.IsNullOrWhiteSpace(txtAmount.Text))
                {
                    if (cboPaymentType.Text.Trim() == "Gift Card")
                    {
                        if (!verifyDiscount())
                        {
                            return;
                        }
                        Boolean hasError = false;
                        string CardNumber = txtAmount.Text.Trim();
                        GiftCard currentCard = (from gcard in entity.GiftCards where gcard.CardNumber == CardNumber && gcard.IsUsed == false && gcard.IsDeleted == false select gcard).FirstOrDefault<GiftCard>();

                        //GiftCard is invalid
                        if (currentCard == null)
                        {
                            MessageBox.Show("Card is already used or invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            hasError = true;
                        }
                        else if (currentCard.CustomerId != Convert.ToInt32(cboCustomer.SelectedValue))
                        {
                            MessageBox.Show("This card is not belong to current customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            hasError = true;
                        }
                        else
                        {
                            //if GiftCard Already in the list
                            foreach (DataGridViewRow row in dgvPaymentType.Rows)
                            {
                                if (Convert.ToString(row.Cells[1].Value).Trim() == "Gift Card")
                                {
                                    if (Convert.ToString(row.Cells[3].Value).Trim() == currentCard.CardNumber.Trim())
                                    {
                                        MessageBox.Show("Card already in the list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        hasError = true;
                                    }
                                }

                            }
                        }

                        if (!hasError)
                        {
                            dgvPaymentType.Rows.Add(Convert.ToInt32(cboPaymentType.SelectedValue), cboPaymentMethod.Text.Trim(), cboPaymentType.Text.Trim(), txtAmount.Text, "Delete", currentCard.Amount, Convert.ToInt32(cboPaymentMethod.SelectedValue));
                            cboPaymentMethod.SelectedIndex = 0;
                            cboPaymentType.SelectedIndex = 0;
                            txtAmount.Clear();
                            CalculateChargesAmount();
                        }
                    }
                    else
                    {
                        dgvPaymentType.Rows.Add(Convert.ToInt32(cboPaymentType.SelectedValue), cboPaymentMethod.Text.Trim(), cboPaymentType.Text.Trim(), txtAmount.Text, "Delete", txtAmount.Text, Convert.ToInt32(cboPaymentMethod.SelectedValue));
                        cboPaymentMethod.SelectedIndex = 0;
                        cboPaymentType.SelectedIndex = 0;
                        txtAmount.Clear();
                        CalculateChargesAmount();
                    }

                }
            }
            //For FOC
            else
            {
                DialogResult result = MessageBox.Show("Are you sure FOC invoice", "FOC", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {

                    dgvPaymentType.Rows.Clear();
                    dgvPaymentType.Rows.Add(Convert.ToInt32(cboPaymentType.SelectedValue), cboPaymentMethod.Text.Trim(), cboPaymentType.Text.Trim(), txtAmount.Text, "Delete", null, Convert.ToInt32(cboPaymentMethod.SelectedValue));
                    cboPaymentMethod.Enabled = false;
                    cboPaymentType.Enabled = false;
                    btnPaymentAdd.Enabled = false;
                    lblChanges.Text = "0";
                }
            }
            int finalrows = dgvPaymentType.Rows.Count;
        }

        private void cboPaymentMethod_TextChanged(object sender, EventArgs e)
        {
            //UpdateTotalCost();
        }

        private void txtAdditionalDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                // Check_MType();//SD
                UpdateTotalCost();
                SendKeys.Send("{TAB}");

            }
        }

        private void txtAdditionalDiscount_Leave(object sender, EventArgs e)
        {
            UpdateTotalCost();
        }

        private void cboPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAmount.Clear();
        }

        private void dgvPaymentType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                //Delete
                if (e.ColumnIndex == 4)
                {
                    string paymentTypeName = Convert.ToString(dgvPaymentType[1, e.RowIndex].Value);

                    dgvPaymentType.Rows.RemoveAt(e.RowIndex);
                    CalculateChargesAmount();

                    if (paymentTypeName.Trim() == "FOC")
                    {
                        cboPaymentMethod.Enabled = true;
                        cboPaymentMethod.SelectedIndex = 0;
                        cboPaymentType.Enabled = true;
                        cboPaymentType.SelectedIndex = 0;
                        btnPaymentAdd.Enabled = true;
                    }
                }
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                btnPaymentAdd_Click(sender, e);
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboPaymentMethod.Text.Trim() != "Gift Card")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        public class MultiPayment
        {
            public int id;
            public string paymentName;
            public int amount;
        }

        private void cboCustomer_Click(object sender, EventArgs e)
        {
            if (cboCustomer.DataSource == null)
            {
                ReloadCustomerList();
            }
        }



        private void txtVIPID_KeyDown(object sender, KeyEventArgs e)
        {
            this.AcceptButton = null;

            if (e.KeyData == Keys.Enter)
            {
                string VIPID = txtVIPID.Text;
                Customer cus = entity.Customers.Where(x => x.VIPMemberId == VIPID && x.CustomerTypeId == 1).FirstOrDefault();
                if (cus != null)
                {
                    SetCurrentCustomer(cus.Id, false);
                }
                else
                {
                    MessageBox.Show("VIP Member ID not found!", "Cannot find");
                    //Clear customer data
                    CurrentCustomerId = 0;
                    lblCustomerName.Text = "-";
                    lblEmail.Text = "-";
                    lblNRIC.Text = "-";
                    lblPhoneNumber.Text = "-";
                    cboCustomer.SelectedIndex = 0;
                    lblbday.Text = "-";
                }
            }
        }


    }
}
