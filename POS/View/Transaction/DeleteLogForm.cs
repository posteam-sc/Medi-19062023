using POS.APP_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class DeleteLogForm : Form
    {
        #region Variables

        private POSEntities entity = new POSEntities();

        #endregion

        #region Events

        public DeleteLogForm()
        {
            InitializeComponent();
        }

        private void DeleteLogForm_Load(object sender, EventArgs e)
        {
            Counter_BInd();
            LoadData();
        }

        private void cboCounter_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvDeleteLog_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDeleteLog.Rows)
            {
                DeleteLog current = (DeleteLog)row.DataBoundItem;
                row.Cells[ColCounter.Index].Value = current.Counter.Name;
                row.Cells[ColDeletedUser.Index].Value = current.User.Name;

                row.Cells[dgvDeleteLog.ColumnCount - 1].Value = current.Transaction.IsExported;
            }
        }

        private void dgvDeleteLogPartial_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDeleteLogPartial.Rows)
            {
                DeleteLog current = (DeleteLog)row.DataBoundItem;
                row.Cells[ColCounter2.Index].Value = current.Counter.Name;
                row.Cells[ColDeleteUser2.Index].Value = current.User.Name;
                row.Cells[ColDeletedProduct.Index].Value = current.TransactionDetail.Product.Name;
                row.Cells[ColQty.Index].Value = current.TransactionDetail.Qty;

                row.Cells[dgvDeleteLogPartial.ColumnCount - 1].Value = current.Transaction.IsExported;
            }
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        #endregion

        #region Function
        private void Counter_BInd()
        {
            List<APP_Data.Counter> counterList = new List<APP_Data.Counter>();
            APP_Data.Counter counterObj = new APP_Data.Counter();
            counterObj.Id = 0;
            counterObj.Name = "Select";
            counterList.Add(counterObj);
            counterList.AddRange((from c in entity.Counters orderby c.Id select c).ToList());
            cboCounter.DataSource = counterList;
            cboCounter.DisplayMember = "Name";
            cboCounter.ValueMember = "Id";
        }

        private void LoadData()
        {
            int CounterId = 0;
            if (cboCounter.SelectedIndex > 0)
            {
                CounterId = Convert.ToInt32(cboCounter.SelectedValue);
            }

            DateTime fromDate = dtFrom.Value.Date;
            DateTime toDate = dtTo.Value.Date;

            List<DeleteLog> transList = (from t in entity.DeleteLogs
                                         where System.Data.Objects.EntityFunctions.TruncateTime((DateTime)t.DeletedDate) >= fromDate && System.Data.Objects.EntityFunctions.TruncateTime((DateTime)t.DeletedDate) <= toDate
                 && t.IsParent == true && ((CounterId == 0 && 1 == 1) || (CounterId != 0 && t.CounterId == CounterId))
                                         select t).ToList<DeleteLog>();
            dgvDeleteLog.AutoGenerateColumns = false;
            dgvDeleteLog.DataSource = transList;

            List<DeleteLog> partialTransList = (from t in entity.DeleteLogs
                                                where System.Data.Objects.EntityFunctions.TruncateTime((DateTime)t.DeletedDate) >= fromDate && System.Data.Objects.EntityFunctions.TruncateTime((DateTime)t.DeletedDate) <= toDate
                        && t.IsParent != true && ((CounterId == 0 && 1 == 1) || (CounterId != 0 && t.CounterId == CounterId))
                                                select t).ToList<DeleteLog>();
            dgvDeleteLogPartial.AutoGenerateColumns = false;
            dgvDeleteLogPartial.DataSource = partialTransList;
        }

        #endregion

        private void dgvDeleteLogPartial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == ColViewDetail2.Index)
                {

                    bool isexp = false;
                    if (dgvDeleteLogPartial.Rows[e.RowIndex].Cells[dgvDeleteLogPartial.ColumnCount - 1].Value != null)
                    {
                        bool.TryParse(dgvDeleteLogPartial.Rows[e.RowIndex].Cells[dgvDeleteLogPartial.ColumnCount - 1].Value.ToString(), out isexp);
                    }


                    string currentTransactionId = dgvDeleteLogPartial.Rows[e.RowIndex].Cells[3].Value.ToString();
                    TransactionDetailForm newForm = new TransactionDetailForm(isexp);
                    newForm.transactionId = currentTransactionId;
                    newForm.IsDelelog = true;
                    newForm.ShowDialog();
                }
            }
        }

        private void dgvDeleteLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == ColViewDetail.Index)
                {
                    string currentTransactionId = dgvDeleteLog.Rows[e.RowIndex].Cells[3].Value.ToString();
                    Transaction tObj = entity.Transactions.Where(x => x.Id == currentTransactionId).FirstOrDefault();
                    if (tObj.Type == TransactionType.Refund || tObj.Type == TransactionType.CreditRefund)
                    {
                        RefundDetail newForm = new RefundDetail();
                        newForm.transactionId = currentTransactionId;
                        newForm.IsRefund = false;
                        newForm.ShowDialog();
                    }
                    else
                    {
                        bool isexp = false;
                        if (dgvDeleteLog.Rows[e.RowIndex].Cells[dgvDeleteLog.ColumnCount - 1].Value != null)
                        {
                            bool.TryParse(dgvDeleteLog.Rows[e.RowIndex].Cells[dgvDeleteLog.ColumnCount - 1].Value.ToString(), out isexp);
                        };

                        TransactionDetailForm newForm = new TransactionDetailForm(isexp);
                        newForm.transactionId = currentTransactionId;
                        newForm.IsDelelog = true;
                        newForm.Text = "Transaction Detail For Delete Log";
                        newForm.ShowDialog();
                    }

                }
            }
        }
    }
}
