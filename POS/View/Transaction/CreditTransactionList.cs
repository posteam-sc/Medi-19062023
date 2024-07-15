using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.APP_Data;

namespace POS
{
    public partial class CreditTransactionList : Form
    {
        #region Variables

        private POSEntities entity = new POSEntities();

        #endregion

        #region Event

        public CreditTransactionList()
        {
            InitializeComponent();
        }

        private void CreditTransactionList_Load(object sender, EventArgs e)
        {
            LoadData(); 
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvTransactionList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string currentTransactionId = dgvTransactionList.Rows[e.RowIndex].Cells[0].Value.ToString();
                var isexp = dgvTransactionList.Rows[e.RowIndex].Cells[dgvTransactionList.Columns.Count - 1].Value.ToString();

                //Refund
                if (e.ColumnIndex == ColRefund.Index)
                {
                    RefundTransaction newForm = new RefundTransaction();
                    newForm.transactionId = currentTransactionId;
                    newForm.Show();
                }
               
                //View Detail
                else if (e.ColumnIndex == ColViewDetail.Index)
                {
                    bool bexp = false;
                    bool.TryParse(isexp, out bexp);

                    TransactionDetailForm newForm = new TransactionDetailForm(bexp);

                    newForm.transactionId = currentTransactionId;
                    newForm.ShowDialog();
                }
                //Delete
                else if (e.ColumnIndex == ColDate.Index)
                {
                    if (bool.Parse(isexp.ToString()))
                    {
                        MessageBox.Show("You can't delete SAP exported transaction!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    Transaction ts = entity.Transactions.Where(x => x.Id == currentTransactionId).FirstOrDefault();
                    List<Transaction> rlist = new List<Transaction>();
                    if (ts.Transaction1.Count > 0)
                    {
                        rlist = ts.Transaction1.Where(x => x.IsDeleted == false).ToList();
                    }
                    if (rlist.Count > 0)
                    {
                        MessageBox.Show("This transaction already make refund. So it can't be delete!");
                    }

                    else
                    {

                        DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {
                            Utility.GiftCardIsBack(ts);

                            ts.IsDeleted = true;
                            ts.UpdatedDate = DateTime.Now;
                            foreach (TransactionDetail detail in ts.TransactionDetails)
                            {
                                detail.IsDeleted = true;
                                detail.Product.Qty = detail.Product.Qty + detail.Qty;
                                Utility.AddProductAvailableQty(entity, (long)detail.ProductId, detail.BatchNo, (int)detail.Qty);
                            }

                            DeleteLog dl = new DeleteLog();
                            dl.DeletedDate = DateTime.Now;
                            dl.CounterId = MemberShip.CounterId;
                            dl.UserId = MemberShip.UserId;
                            dl.IsParent = true;
                            dl.TransactionId = ts.Id;
                            entity.DeleteLogs.Add(dl);
                            entity.SaveChanges();
                            LoadData();
                        }
                    }
                }
            }
        }

        private void dgvTransactionList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTransactionList.Rows)
            {
                Transaction currentt = (Transaction)row.DataBoundItem;
                row.Cells[ColTransactionId.Index].Value = currentt.Id;
                row.Cells[ColDate.Index].Value = currentt.DateTime.ToString("dd-MM-yyyy");
                row.Cells[ColTime.Index].Value = currentt.DateTime.ToString("hh:mm");
                row.Cells[ColSalePerson.Index].Value = currentt.User.Name;
                row.Cells[ColCustomerName.Index].Value = (currentt.Customer == null) ? "-" : currentt.Customer.Name;
                row.Cells[ColAmount.Index].Value = currentt.TotalAmount - currentt.UsePrePaidDebts.Sum(x => x.UseAmount).Value - currentt.RecieveAmount;
                row.Cells[dgvTransactionList.ColumnCount - 1].Value = currentt.IsExported;
            }
        }


        #endregion

        #region Function

        public void LoadData()
        {
            List<Transaction> transList = new List<Transaction>();
            dgvTransactionList.DataSource = "";
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date;
            transList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && t.IsActive == true && t.Type == TransactionType.Credit select t).ToList<Transaction>();
            dgvTransactionList.AutoGenerateColumns = false;
            dgvTransactionList.DataSource = transList.Where(x => x.IsDeleted != true).ToList();
        }


        #endregion

        private void dgvTransactionList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
