using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using POS.APP_Data;

namespace POS
{
    public partial class RefundTransaction : Form
    {
        #region Variables

        public string transactionId { get; set; }
        public int paymentType { get; set; }

        private POSEntities entity = new POSEntities();

        public int DiscountAmount { get; set; }


        Transaction currentTransaction;

        List<Transaction> _RefundTranList = new List<Transaction>();
        int discount = 0;

        #endregion

        #region Events

        public RefundTransaction()
        {
            InitializeComponent();
        }

        private void RefundTransaction_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            currentTransaction = (from c in entity.Transactions where c.Id == transactionId && c.IsDeleted == false select c).FirstOrDefault();
            dgvItemLists.AutoGenerateColumns = false;
            //TransactionDetail tdetail = currentTransaction.TransactionDetails.FirstOrDefault<TransactionDetail>();
            //Boolean delete=(Boolean)tdetail.IsDeleted;

            dgvItemLists.Rows.Clear();
            foreach (TransactionDetail td in currentTransaction.TransactionDetails)
            {
                if (td.IsDeleted != true)
                {
                    int qty = Convert.ToInt32(td.Qty);
                    for (int count = 0; count < qty; count++)
                    {
                        dgvItemLists.AllowUserToAddRows = true;
                        DataGridViewRow row = (DataGridViewRow)dgvItemLists.Rows[count].Clone();

                        int _productId = Convert.ToInt32(td.ProductId);

                        row.Cells[colRefundCheck.Index].Value = false;
                        row.Cells[colSKU.Index].Value = td.Product.ProductCode;
                        row.Cells[colProductName.Index].Value = td.Product.Name;
                        row.Cells[colBatchNo.Index].Value = td.BatchNo;

                        row.Cells[colQty.Index].Value = 1;
                        row.Cells[colPrice.Index].Value = td.UnitPrice;
                        row.Cells[colDiscount.Index].Value = td.DiscountRate;
                        row.Cells[colTax.Index].Value = td.TaxRate;
                        row.Cells[colCost.Index].Value = td.TotalAmount;//getActualCost(td.Product);       
                        row.Cells[colProductId.Index].Value = td.ProductId;
                        row.Cells[ColCount.Index].Value = count + 1;
                        dgvItemLists.Rows.Add(row);


                        //check if there are products that have already been refunded
                        //_RefundTranList = entity.Transactions.Where(x => x.Type == TransactionType.CreditRefund || x.Type == TransactionType.Refund).Where(x => x.ParentId == currentTransaction.Id).ToList().Where(x => x.IsDeleted != true).ToList();
                        _RefundTranList = entity.Transactions.Where(x => x.Type == TransactionType.Refund).Where(x => x.ParentId == currentTransaction.Id).ToList().Where(x => x.IsDeleted != true).ToList();


                        if (_RefundTranList.Count > 0)
                        {
                            var _refundIdList = _RefundTranList.Select(x => x.Id).ToList();

                            var _tempproductIdList = entity.TransactionDetails.Where(x => _refundIdList.Contains(x.TransactionId)).Select(x => x.ProductId).ToList();

                            int productId = Convert.ToInt32(_tempproductIdList.Where(x => x == _productId).Select(x => x).FirstOrDefault());

                            int _refundTotalQty = Convert.ToInt32(_tempproductIdList.Where(x => x == _productId).Select(x => x).Count());


                            int tempcount = Convert.ToInt32(row.Cells[ColCount.Index].Value);
                            if (productId != 0)
                            {
                                if (tempcount <= _refundTotalQty) // if product's total sold count (Qty) <= refunded Qty
                                {
                                    row.Cells[colRefundCheck.Index].ReadOnly = true;
                                    row.Cells[colRefundCheck.Index].Style.BackColor = Color.LightGreen;

                                }
                                else
                                {
                                    row.Cells[colRefundCheck.Index].ReadOnly = false;
                                    row.Cells[colRefundCheck.Index].Style.BackColor = Color.White;


                                }
                            }
                            else // the product has never been refunded before
                            {
                                row.Cells[colRefundCheck.Index].ReadOnly = false;
                                row.Cells[colRefundCheck.Index].Style.BackColor = Color.White;

                            }
                        }

                    }
                }
            }
            dgvItemLists.AllowUserToAddRows = false;
            DiscountAmount = -1;


            dgvRedundedList.AutoGenerateColumns = false;
            //dgvRedundedList.DataSource = entity.Transactions.Where(x => x.Type == TransactionType.CreditRefund || x.Type == TransactionType.Refund).Where(x => x.ParentId == currentTransaction.Id).ToList().Where(x => x.IsDeleted != true).ToList();
            dgvRedundedList.DataSource = entity.Transactions.Where(x => x.Type == TransactionType.Refund).Where(x => x.ParentId == currentTransaction.Id).ToList().Where(x => x.IsDeleted != true).ToList();

            lblSalePerson.Text = currentTransaction.User.Name;
            lblDate.Text = currentTransaction.DateTime.ToString("dd-MM-yyyy");
            lblTime.Text = currentTransaction.DateTime.ToString("hh:mm");
            lblCash.Text = currentTransaction.RecieveAmount.ToString();
            lblTotal.Text = currentTransaction.TotalAmount.ToString();

            foreach (TransactionDetail td in currentTransaction.TransactionDetails)
            {
                discount += Convert.ToInt32(((td.UnitPrice) * (td.DiscountRate / 100)) * td.Qty);
                //tax += Convert.ToInt32((td.UnitPrice * (td.TaxRate / 100)) * td.Qty);
            }
            lblDiscount.Text = (currentTransaction.DiscountAmount - discount).ToString();
            lblMainTransaction.Text = currentTransaction.Id;
            if (currentTransaction.Type == TransactionType.Credit)
            {
                lblChangeGivenTitle.Text = "Payable Credit";
                lblChangeGiven.Text = (currentTransaction.TotalAmount - currentTransaction.RecieveAmount).ToString();
            }
            else
            {
                lblChangeGiven.Text = (currentTransaction.RecieveAmount - currentTransaction.TotalAmount).ToString();
            }
        }
        private decimal getActualCost(Product prod)
        {
            decimal? actualCost = 0;
            //decrease discount ammount            
            actualCost = prod.Price - ((prod.Price / 100) * prod.DiscountRate);
            //add tax ammount            
            actualCost = actualCost + ((prod.Price / 100) * prod.Tax.TaxPercent);
            return (decimal)actualCost;
        }
        private void dgvItemLists_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvItemLists.Rows)
            {
                TransactionDetail transactionDetailObj = (TransactionDetail)row.DataBoundItem;
                row.Cells[colSKU.Index].Value = transactionDetailObj.Product.ProductCode;
                row.Cells[colProductName.Index].Value = transactionDetailObj.Product.Name;

                row.Cells[colQty.Index].Value = transactionDetailObj.Qty;
                row.Cells[colPrice.Index].Value = transactionDetailObj.UnitPrice;
                row.Cells[colDiscount.Index].Value = transactionDetailObj.DiscountRate + "%";
                row.Cells[colTax.Index].Value = transactionDetailObj.TaxRate + "%";
                row.Cells[colCost.Index].Value = transactionDetailObj.TotalAmount;
            }
        }

        private void dgvRedundedList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvRedundedList.Rows)
            {
                Transaction transObj = (Transaction)row.DataBoundItem;
                row.Cells[colRefundId.Index].Value = transObj.Id;
                row.Cells[colDate.Index].Value = transObj.DateTime.ToString("dd-MM-yyyy");
                row.Cells[ColTime.Index].Value = transObj.DateTime.ToString("hh:mm");
                row.Cells[colRefundAmt.Index].Value = transObj.TotalAmount;
                row.Cells[colDiscountAmt.Index].Value = transObj.DiscountAmount;

            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to refund these products?", "Refund", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                List<TransactionDetail> refundItems = new List<TransactionDetail>();
                int totalRefundAmount = 0;
                int totalDiscountAllItem = 0;
                DataGridViewRow rr = dgvItemLists.Rows[0];

                int totalRefundAmt = 0;
                foreach (DataGridViewRow row in dgvItemLists.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[colRefundCheck.Index].Value))
                    {
                        int count = (from AttGift in entity.AttachGiftSystemForTransactions where AttGift.TransactionId == transactionId select AttGift).ToList().Count;
                        if (count > 1)
                        {
                            MessageBox.Show("The product(s) in current Transaction includes in GWP List!", "Unable to Refund", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            totalRefundAmt += Convert.ToInt32(row.Cells[colCost.Index].Value);
                        }
                    }
                }
                int customerId = (int)currentTransaction.CustomerId;
                bool res = Utility.CanRemoveSaleTransaction(currentTransaction,totalRefundAmt.ToString(), (int)currentTransaction.CustomerId, currentTransaction.Customer.Name);
                if (res == false)
                {
                    MessageBox.Show("You can't refund this transaction, the points achieved for this transaction have been used or redeemed!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                foreach (DataGridViewRow row in dgvItemLists.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[colRefundCheck.Index].Value))
                    {
                        //int count = (from AttGift in entity.AttachGiftSystemForTransactions where AttGift.TransactionId == transactionId select AttGift).ToList().Count;
                        //if (count > 1)
                        //{
                        //    MessageBox.Show("The product(s) in current Transaction includes in GWP List!", "Unable to Refund", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}
                        //else
                        //{

                        TransactionDetail refundDetail = new TransactionDetail();
                        refundDetail.ProductId = Convert.ToInt32(row.Cells[colProductId.Index].Value);
                        int currentProductId = Convert.ToInt32(row.Cells[colProductId.Index].Value);
                        Product pro = (from p in entity.Products where p.Id == currentProductId select p).FirstOrDefault<Product>();
                        pro.Qty = pro.Qty + Convert.ToInt32(row.Cells[colQty.Index].Value);
                        refundDetail.BatchNo = Convert.ToString(row.Cells[colBatchNo.Index].Value);
                        refundDetail.Qty = Convert.ToInt32(row.Cells[colQty.Index].Value);
                        refundDetail.UnitPrice = Convert.ToInt32(row.Cells[colPrice.Index].Value);

                        string DiscountRate = row.Cells[colDiscount.Index].Value.ToString();
                        string TaxRate = row.Cells[colTax.Index].Value.ToString();

                        refundDetail.DiscountRate = Convert.ToDecimal(DiscountRate.Replace("%", ""));
                        refundDetail.TaxRate = Convert.ToDecimal(TaxRate.Replace("%", ""));
                        refundDetail.TotalAmount = Convert.ToInt32(row.Cells[colCost.Index].Value);
                        totalRefundAmount += Convert.ToInt32(row.Cells[colCost.Index].Value);
                        totalDiscountAllItem += Convert.ToInt32(((Convert.ToInt32(row.Cells[colPrice.Index].Value)) * (Convert.ToDecimal(DiscountRate.Replace("%", "")) / 100)) * Convert.ToInt32(row.Cells[colQty.Index].Value));

                        refundDetail.IsDeleted = false;
                        refundItems.Add(refundDetail);
                        Utility.AddProductAvailableQty(entity, (long)refundDetail.ProductId, refundDetail.BatchNo, (int)refundDetail.Qty);
                        /// }
                    }
                }

                //User refund more than one items
                if (refundItems.Count > 0)
                {

                    string resultId = string.Empty;
                    string rId = string.Empty;
                    long CurrentDebt = 0;
                    int cusId;

                    if (currentTransaction.PaymentTypeId == 2 && currentTransaction.IsPaid == false)
                    {
                        #region Credit Refund
                        cusId = (int)currentTransaction.CustomerId;
                        CurrentDebt = Convert.ToInt64(entity.Transactions.Where(x => x.PaymentType.Name == "Credit").Where(x => x.Id == currentTransaction.Id).Where(x => x.IsPaid == false).Sum(x => x.TotalAmount - x.RecieveAmount));
                        if (currentTransaction.UsePrePaidDebts != null)
                        {
                            CurrentDebt -= (long)currentTransaction.UsePrePaidDebts.Sum(x => x.UseAmount);
                        }
                        Transaction DiscountTrans = entity.Transactions.Where(x => x.PaymentType.Name == "Credit").Where(x => x.Id == currentTransaction.Id).Where(x => x.IsPaid == false).FirstOrDefault();
                        //long Discount = (long)DiscountTrans.TransactionDetails.Sum(x => (x.UnitPrice * (x.DiscountRate / 100))).Value;
                        //CurrentDebt -= Convert.ToInt64(currentTransaction.DiscountAmount - discount);
                        List<Transaction> DebtList = entity.Transactions.Where(x => x.CustomerId == currentTransaction.CustomerId).ToList();
                        long DebtTotal = Convert.ToInt64(DebtList.Where(x => x.PaymentType.Name == "Credit").Where(x => x.IsPaid == false).Sum(x => x.TotalAmount - x.RecieveAmount));
                        List<Transaction> prePaidTranList = entity.Transactions.Where(tras => tras.Type == TransactionType.Prepaid).Where(x => x.CustomerId == currentTransaction.CustomerId).Where(trans => trans.IsActive == false).ToList();
                        long PrePaidamount = 0;
                        foreach (Transaction PrePaidDebtTrans in prePaidTranList)
                        {
                            int useAmount = (PrePaidDebtTrans.UsePrePaidDebts1 == null) ? 0 : (int)PrePaidDebtTrans.UsePrePaidDebts1.Sum(x => x.UseAmount);
                            PrePaidamount += (long)PrePaidDebtTrans.TotalAmount - useAmount;
                        }
                        long CreditRefundAmount = Convert.ToInt64(entity.Transactions.Where(x => x.ParentId == currentTransaction.Id).Where(x => x.Type == TransactionType.CreditRefund).Sum(x => x.RecieveAmount));
                        CurrentDebt -= CreditRefundAmount;

                        if (totalRefundAmount <= ((currentTransaction.TotalAmount + currentTransaction.DiscountAmount) - totalDiscountAllItem))
                        {

                            if (currentTransaction.DiscountAmount - discount > 0)
                            {
                                if (DiscountAmount < 0)
                                {
                                    RefundDiscount newForm = new RefundDiscount();
                                    newForm.ShowDialog();
                                    return;
                                }
                            }
                            else
                            {
                                DiscountAmount = 0;
                            }
                            // refund amount is smaller than current debt
                            if ((totalRefundAmount - DiscountAmount) < CurrentDebt)
                            {
                                System.Data.Objects.ObjectResult<String> Id = entity.InsertRefundTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.CreditRefund, true, true, 1, 0, DiscountAmount, refundItems.Sum(refund => refund.TotalAmount), refundItems.Sum(refund => refund.TotalAmount) - DiscountAmount, transactionId, null, cusId, SettingController.DefaultShop.ShortCode, SettingController.DefaultShop.Id);
                                resultId = Id.FirstOrDefault().ToString();
                                CurrentDebt -= (totalRefundAmount - DiscountAmount);
                                if (PrePaidamount > 0)
                                {
                                    if (CurrentDebt <= PrePaidamount)
                                    {
                                        Transaction CreditT = (from tr in entity.Transactions where tr.Id == currentTransaction.Id select tr).FirstOrDefault<Transaction>();
                                        CreditT.IsPaid = true;
                                        entity.Entry(CreditT).State = EntityState.Modified;
                                        entity.SaveChanges();
                                        foreach (Transaction PrePaidDebtTrans in prePaidTranList)
                                        {
                                            long CurrentPrePaid = 0;

                                            int useAmount = (PrePaidDebtTrans.UsePrePaidDebts1 == null) ? 0 : (int)PrePaidDebtTrans.UsePrePaidDebts1.Sum(x => x.UseAmount);
                                            CurrentPrePaid = (long)PrePaidDebtTrans.TotalAmount - useAmount;
                                            if (CurrentDebt >= CurrentPrePaid)
                                            {
                                                PrePaidDebtTrans.IsActive = true;
                                                UsePrePaidDebt usePrePaidDObj = new UsePrePaidDebt();
                                                usePrePaidDObj.UseAmount = (int)CurrentPrePaid;
                                                usePrePaidDObj.PrePaidDebtTransactionId = PrePaidDebtTrans.Id;
                                                usePrePaidDObj.CreditTransactionId = currentTransaction.Id;
                                                usePrePaidDObj.CashierId = MemberShip.UserId;
                                                usePrePaidDObj.CounterId = MemberShip.CounterId;
                                                entity.UsePrePaidDebts.Add(usePrePaidDObj);
                                                entity.SaveChanges();
                                                CurrentDebt -= CurrentPrePaid;
                                            }
                                            else
                                            {
                                                UsePrePaidDebt usePrePaidDObj = new UsePrePaidDebt();
                                                usePrePaidDObj.UseAmount = (int)CurrentDebt;
                                                usePrePaidDObj.PrePaidDebtTransactionId = PrePaidDebtTrans.Id;
                                                usePrePaidDObj.CreditTransactionId = currentTransaction.Id;
                                                usePrePaidDObj.CashierId = MemberShip.UserId;
                                                usePrePaidDObj.CounterId = MemberShip.CounterId;
                                                entity.UsePrePaidDebts.Add(usePrePaidDObj);
                                                entity.SaveChanges();
                                                CurrentDebt = 0;
                                            }
                                        }
                                    }
                                }
                            }
                            //refundAmount is equal current debet
                            else if ((totalRefundAmount - DiscountAmount) == CurrentDebt)
                            {
                                System.Data.Objects.ObjectResult<String> Id = entity.InsertRefundTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.CreditRefund, true, true, 1, 0, DiscountAmount, refundItems.Sum(refund => refund.TotalAmount), refundItems.Sum(refund => refund.TotalAmount) - DiscountAmount, transactionId, null, cusId, SettingController.DefaultShop.ShortCode, SettingController.DefaultShop.Id);
                                resultId = Id.FirstOrDefault().ToString();
                                Transaction CreditT = (from tr in entity.Transactions where tr.Id == currentTransaction.Id select tr).FirstOrDefault<Transaction>();
                                CreditT.IsPaid = true;
                                entity.Entry(CreditT).State = EntityState.Modified;
                                entity.SaveChanges();
                            }
                            //if refund amount is greather than current debt, add refund row and credit refund
                            else
                            {
                                System.Data.Objects.ObjectResult<String> Id = entity.InsertRefundTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Refund, true, true, 1, 0, DiscountAmount, totalRefundAmount - CurrentDebt, totalRefundAmount - CurrentDebt - DiscountAmount, transactionId, null, cusId, SettingController.DefaultShop.ShortCode, SettingController.DefaultShop.Id);
                                resultId = Id.FirstOrDefault().ToString();

                                System.Data.Objects.ObjectResult<String> CreditRefundId = entity.InsertRefundTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.CreditRefund, true, true, 1, 0, 0, CurrentDebt, CurrentDebt, transactionId, null, cusId, SettingController.DefaultShop.ShortCode, SettingController.DefaultShop.Id);
                                rId = CreditRefundId.FirstOrDefault().ToString();

                                //currentTransaction.IsPaid = true;
                                entity.Paid(true, currentTransaction.Id);
                                //entity.SaveChanges();
                            }
                        }
                        else
                        {
                            CurrentDebt = 0;
                            if (totalRefundAmount < ((currentTransaction.TotalAmount + currentTransaction.DiscountAmount) - totalDiscountAllItem))
                            {

                                if (currentTransaction.DiscountAmount - discount > 0)
                                {
                                    if (DiscountAmount < 0)
                                    {
                                        RefundDiscount newForm = new RefundDiscount();
                                        newForm.ShowDialog();
                                        return;
                                    }
                                }
                                else
                                {
                                    DiscountAmount = 0;
                                }
                                System.Data.Objects.ObjectResult<String> Id = entity.InsertRefundTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.CreditRefund, true, true, 1, 0, DiscountAmount, refundItems.Sum(refund => refund.TotalAmount), refundItems.Sum(refund => refund.TotalAmount) - DiscountAmount, transactionId, null, cusId, SettingController.DefaultShop.ShortCode, SettingController.DefaultShop.Id);
                                resultId = Id.FirstOrDefault().ToString();
                            }
                            else if (totalRefundAmount == (currentTransaction.TotalAmount + (currentTransaction.DiscountAmount - totalDiscountAllItem)))
                            {
                                System.Data.Objects.ObjectResult<String> Id = entity.InsertRefundTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.CreditRefund, true, true, 1, 0, (currentTransaction.DiscountAmount - totalDiscountAllItem), refundItems.Sum(refund => refund.TotalAmount), refundItems.Sum(refund => refund.TotalAmount) - (currentTransaction.DiscountAmount - totalDiscountAllItem), transactionId, null, cusId, SettingController.DefaultShop.ShortCode, SettingController.DefaultShop.Id);
                                resultId = Id.FirstOrDefault().ToString();
                            }

                        }
                        #endregion                                        

                    }
                    else
                    {

                        if (totalRefundAmount < ((currentTransaction.TotalAmount + currentTransaction.DiscountAmount) - totalDiscountAllItem))
                        {

                            if (currentTransaction.DiscountAmount - discount > 0)
                            {
                                if (DiscountAmount < 0)
                                {
                                    RefundDiscount newForm = new RefundDiscount();
                                    newForm.ShowDialog();
                                    return;
                                }
                            }
                            else
                            {
                                DiscountAmount = 0;
                            }
                            System.Data.Objects.ObjectResult<String> Id = entity.InsertRefundTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Refund, true, true, 1, 0, DiscountAmount, refundItems.Sum(refund => refund.TotalAmount), refundItems.Sum(refund => refund.TotalAmount) - DiscountAmount, transactionId, null, currentTransaction.CustomerId, SettingController.DefaultShop.ShortCode, SettingController.DefaultShop.Id);
                            resultId = Id.FirstOrDefault().ToString();
                        }
                        else if (totalRefundAmount == (currentTransaction.TotalAmount + (currentTransaction.DiscountAmount - totalDiscountAllItem)))
                        {
                            System.Data.Objects.ObjectResult<String> Id = entity.InsertRefundTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Refund, true, true, 1, 0, (currentTransaction.DiscountAmount - totalDiscountAllItem), refundItems.Sum(refund => refund.TotalAmount), refundItems.Sum(refund => refund.TotalAmount) - (currentTransaction.DiscountAmount - totalDiscountAllItem), transactionId, null, currentTransaction.CustomerId, SettingController.DefaultShop.ShortCode, SettingController.DefaultShop.Id);
                            resultId = Id.FirstOrDefault().ToString();
                        }

                    }




                    //Normal Refund's Detail Transactions List
                    Transaction insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();
                    foreach (TransactionDetail detail in refundItems)
                    {
                        detail.Product = (from prod in entity.Products where prod.Id == (long)detail.ProductId select prod).FirstOrDefault();
                        //var batchNo = entity.StockOutTransactions.Where(x => x.ProductId == detail.ProductId && x.TransactionId == transactionId && x.TransactionType == "Sale").Select(x => x.BatchNo).FirstOrDefault();

                        detail.Product.Qty = detail.Product.Qty + detail.Qty;


                        if (detail.Product.IsWrapper == true)
                        {
                            List<WrapperItem> wplist = detail.Product.WrapperItems.ToList();

                            foreach (WrapperItem wp in wplist)
                            {
                                wp.Product1.Qty = wp.Product1.Qty + detail.Qty;
                            }
                        }
                        insertedTransaction.TransactionDetails.Add(detail);


                    }
                    entity.SaveChanges();

                    //Credit refund's Detail Transactions List
                    Transaction ITrans = new Transaction();
                    if (rId != string.Empty)
                    {
                        ITrans = (from trans in entity.Transactions where trans.Id == rId select trans).FirstOrDefault<Transaction>();
                        foreach (TransactionDetail detail in refundItems)
                        {
                            TransactionDetail rftDetail = new TransactionDetail();
                            rftDetail.ProductId = detail.ProductId;
                            rftDetail.Qty = detail.Qty;
                            rftDetail.BatchNo = detail.BatchNo;
                            rftDetail.TaxRate = detail.TaxRate;
                            rftDetail.TotalAmount = detail.TotalAmount;
                            rftDetail.TransactionId = detail.TransactionId;
                            rftDetail.UnitPrice = detail.UnitPrice;
                            rftDetail.DiscountRate = detail.DiscountRate;

                            ITrans.TransactionDetails.Add(rftDetail);
                            Utility.AddProductAvailableQty(entity, (long)detail.ProductId, detail.BatchNo, (int)detail.Qty);

                        }
                    }

                    entity.SaveChanges();

                    MessageBox.Show("Refund process completed!");
                    // this.Dispose();
                    LoadData();


                }
                else
                {
                    MessageBox.Show("Please choose at least one item to refund!");
                }
            }
        }

        private void dgvRedundedList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                string currentTransactionId = dgvRedundedList.Rows[e.RowIndex].Cells[colRefundId.Index].Value.ToString();
                if (e.ColumnIndex == colViewDetail.Index)
                {
                    RefundDetail newForm = new RefundDetail();
                    newForm.transactionId = currentTransactionId;
                    newForm.IsRefund = false;
                    newForm.ShowDialog();
                }
            }
        }

        #endregion

        #region Function

        public void Reload()
        {
            btnSubmit_Click(this, null);
        }

        #endregion


    }
}
