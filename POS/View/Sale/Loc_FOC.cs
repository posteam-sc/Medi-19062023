﻿using Microsoft.Reporting.WinForms;
using POS.APP_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class Loc_FOC : Form
    {
        #region Variables

        public List<TransactionDetail> DetailList = new List<TransactionDetail>();

        public List<GiftSystem> GiftList = new List<GiftSystem>();

        public int Discount { get; set; }

        public int Tax { get; set; }

        public int ExtraDiscount { get; set; }

        public int ExtraTax { get; set; }

        public Boolean isDraft { get; set; }

        public string DraftId { get; set; }

        public int? CustomerId { get; set; }

        private POSEntities entity = new POSEntities();

        public int Type { get; set; }

        #endregion


        public Loc_FOC()
        {
            InitializeComponent();
        }

        private void Loc_FOC_Load(object sender, EventArgs e)
        {
            long totalCost = (long)DetailList.Sum(x => x.TotalAmount) + ExtraTax - ExtraDiscount;
            Transaction insertedTransaction = new Transaction();
            string resultId = string.Empty;
            string HeaderTitle = string.Empty;
            if (Type == 4)
            {
                HeaderTitle = "FOC Sale";
                System.Data.Objects.ObjectResult<String> Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 4, ExtraTax + Tax, ExtraDiscount + Discount, totalCost, 0, null, CustomerId, SettingController.DefaultShop.ShortCode, SettingController.DefaultShop.Id, false);

                resultId = Id.FirstOrDefault().ToString();
                insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();
                foreach (TransactionDetail detail in DetailList)
                {
                    detail.IsDeleted = false;//Update IsDelete (Null to 0)
                    var detailID = entity.InsertTransactionDetail(insertedTransaction.Id, Convert.ToInt32(detail.ProductId), Convert.ToInt32(detail.Qty), Convert.ToInt32(detail.UnitPrice), Convert.ToDouble(detail.DiscountRate), Convert.ToDouble(detail.TaxRate), Convert.ToInt32(detail.TotalAmount), detail.IsDeleted, Convert.ToDouble(detail.IsDeductedBy), detail.BatchNo,false).SingleOrDefault();
                    detail.Product = (from prod in entity.Products where prod.Id == (long)detail.ProductId select prod).FirstOrDefault();
                    detail.Product.Qty = detail.Product.Qty - detail.Qty;
                    if (detail.Product.Brand != null)
                    {
                        if (detail.Product.Brand.Name == "Special Promotion")
                        {
                            List<WrapperItem> wList = detail.Product.WrapperItems.ToList();
                            if (wList.Count > 0)
                            {
                                foreach (WrapperItem w in wList)
                                {
                                    Product wpObj = (from p in entity.Products where p.Id == w.ChildProductId select p).FirstOrDefault();
                                    wpObj.Qty = wpObj.Qty - detail.Qty;

                                    SPDetail spDetail = new SPDetail();
                                    spDetail.TransactionDetailID = Convert.ToInt32(detailID);
                                    spDetail.DiscountRate = detail.DiscountRate;
                                    spDetail.ParentProductID = w.ParentProductId;
                                    spDetail.ChildProductID = w.ChildProductId;
                                    spDetail.Price = wpObj.Price;
                                    entity.insertSPDetail(spDetail.TransactionDetailID, spDetail.ParentProductID, spDetail.ChildProductID, spDetail.Price, spDetail.DiscountRate, SettingController.DefaultShop.ShortCode);
                                }
                            }
                        }
                    }
                }
            }
            else if (Type == 6)
            {
                HeaderTitle = "Tester";
                System.Data.Objects.ObjectResult<String> Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 6, ExtraTax + Tax, ExtraDiscount + Discount, totalCost, 0, null, CustomerId, SettingController.DefaultShop.ShortCode, SettingController.DefaultShop.Id, false);

                resultId = Id.FirstOrDefault().ToString();
                insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();
                foreach (TransactionDetail detail in DetailList)
                {

                    var detailID = entity.InsertTransactionDetail(insertedTransaction.Id, Convert.ToInt32(detail.ProductId), Convert.ToInt32(detail.Qty), Convert.ToInt32(detail.UnitPrice), Convert.ToDouble(detail.DiscountRate), Convert.ToDouble(detail.TaxRate), Convert.ToInt32(detail.TotalAmount), detail.IsDeleted, Convert.ToDouble(detail.IsDeductedBy), detail.BatchNo,false).SingleOrDefault();
                    detail.Product = (from prod in entity.Products where prod.Id == (long)detail.ProductId select prod).FirstOrDefault();
                    detail.Product.Qty = detail.Product.Qty - detail.Qty;
                    if (detail.Product.Brand.Name == "Special Promotion")
                    {
                        List<WrapperItem> wList = detail.Product.WrapperItems.ToList();
                        if (wList.Count > 0)
                        {
                            foreach (WrapperItem w in wList)
                            {
                                Product wpObj = (from p in entity.Products where p.Id == w.ChildProductId select p).FirstOrDefault();
                                wpObj.Qty = wpObj.Qty - detail.Qty;

                                SPDetail spDetail = new SPDetail();
                                spDetail.TransactionDetailID = Convert.ToInt32(detailID);
                                spDetail.DiscountRate = detail.DiscountRate;
                                spDetail.ParentProductID = w.ParentProductId;
                                spDetail.ChildProductID = w.ChildProductId;
                                spDetail.Price = wpObj.Price;
                                entity.insertSPDetail(spDetail.TransactionDetailID, spDetail.ParentProductID, spDetail.ChildProductID, spDetail.Price, spDetail.DiscountRate, SettingController.DefaultShop.ShortCode);
                            }
                        }
                    }

                }
            }


            if (isDraft)
            {
                Transaction draft = (from trans in entity.Transactions where trans.Id == DraftId select trans).FirstOrDefault<Transaction>();
                if (draft != null)
                {
                    draft.TransactionDetails.Clear();
                    var Detail = entity.TransactionDetails.Where(d => d.TransactionId == draft.Id);
                    foreach (var d in Detail)
                    {
                        entity.TransactionDetails.Remove(d);
                    }
                    entity.Transactions.Remove(draft);
                }
            }

            //Add promotion gift records for this transaction
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
            insertedTransaction.ReceivedCurrencyId = SettingController.DefaultCurrency;
            entity.SaveChanges();
            GiftList.Clear();
            //Print Invoice
            #region [ Print ]

            dsReportTemp dsReport = new dsReportTemp();
            dsReportTemp.ItemListDataTable dtReport = (dsReportTemp.ItemListDataTable)dsReport.Tables["ItemList"];
            int _tAmt = 0;
            foreach (TransactionDetail transaction in DetailList)
            {
                dsReportTemp.ItemListRow newRow = dtReport.NewItemListRow();
                newRow.Name = transaction.Product.Name;
                newRow.Qty = transaction.Qty.ToString();
                newRow.DiscountPercent = transaction.DiscountRate.ToString();
                //newRow.TotalAmount = (int)transaction.TotalAmount; //Edit By ZMH
                newRow.TotalAmount = (int)transaction.UnitPrice * (int)transaction.Qty; //Edit By ZMH
                newRow.UnitPrice = "1@" + transaction.UnitPrice.ToString();
                _tAmt += newRow.TotalAmount;
                dtReport.AddItemListRow(newRow);
            }

            string reportPath = "";
            ReportViewer rv = new ReportViewer();
            ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["ItemList"]);


            ////if (!SettingController.DefaultShop.ShopName.Contains("Mandalay"))
            ////{
            ////    reportPath = Application.StartupPath + "\\HagalReports\\InvoiceFOC.rdlc";
            ////}
            ////else
            ////{
            ////    reportPath = Application.StartupPath + "\\MDY_Reports\\InvoiceFOC.rdlc";
            ////}

            if (DefaultPrinter.SlipPrinter.Contains("EPSON TM-T88IV Receipt"))
            {
                reportPath = Application.StartupPath + "\\Epson\\InvoiceFOC.rdlc";
            }
            else if (DefaultPrinter.SlipPrinter.Contains("XP-80C"))
            {
                reportPath = Application.StartupPath + "\\XP\\InvoiceFOC.rdlc";
            }
            else if (DefaultPrinter.SlipPrinter.Contains("Birch BP-003"))
            {
                reportPath = Application.StartupPath + "\\Birch\\InvoiceFOC.rdlc";
            }
            else
            {
                reportPath = Application.StartupPath + "\\Epson\\InvoiceFOC.rdlc";
            }

            //reportPath = Application.StartupPath + "\\Reports\\InvoiceFOC.rdlc";
            rv.Reset();
            rv.LocalReport.ReportPath = reportPath;
            rv.LocalReport.DataSources.Add(rds);



            APP_Data.Customer cus = entity.Customers.Where(x => x.Id == CustomerId).FirstOrDefault();

            ReportParameter CustomerName = new ReportParameter("CustomerName", cus.Title + " " + cus.Name);
            rv.LocalReport.SetParameters(CustomerName);


            ReportParameter TAmt = new ReportParameter("TAmt", _tAmt.ToString());
            rv.LocalReport.SetParameters(TAmt);



            string _Point = Loc_CustomerPointSystem.GetPointFromCustomerId(Convert.ToInt32(cus.Id)).ToString();
            ReportParameter AvailablePoint = new ReportParameter("AvailablePoint", _Point);
            rv.LocalReport.SetParameters(AvailablePoint);

            ReportParameter ShopName = new ReportParameter("ShopName", SettingController.DefaultShop.ShopName);
            rv.LocalReport.SetParameters(ShopName);


            ReportParameter BranchName = new ReportParameter("BranchName", SettingController.DefaultShop.Address);
            rv.LocalReport.SetParameters(BranchName);

            ReportParameter Title = new ReportParameter("Title", HeaderTitle);
            rv.LocalReport.SetParameters(Title);

            ReportParameter Phone = new ReportParameter("Phone", SettingController.DefaultShop.PhoneNumber);
            rv.LocalReport.SetParameters(Phone);

            ReportParameter OpeningHours = new ReportParameter("OpeningHours", SettingController.DefaultShop.OpeningHours);
            rv.LocalReport.SetParameters(OpeningHours);

            ReportParameter TransactionId = new ReportParameter("TransactionId", resultId.ToString());
            rv.LocalReport.SetParameters(TransactionId);

            APP_Data.Counter c = entity.Counters.FirstOrDefault(x => x.Id == MemberShip.CounterId);

            ReportParameter CounterName = new ReportParameter("CounterName", c.Name);
            rv.LocalReport.SetParameters(CounterName);

            ReportParameter PrintDateTime = new ReportParameter("PrintDateTime", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
            rv.LocalReport.SetParameters(PrintDateTime);

            ReportParameter CasherName = new ReportParameter("CasherName", MemberShip.UserName);
            rv.LocalReport.SetParameters(CasherName);

            // ReportParameter TotalAmount = new ReportParameter("TotalAmount", Convert.ToInt32(insertedTransaction.TotalAmount + insertedTransaction.DiscountAmount).ToString());
            ReportParameter TotalAmount = new ReportParameter("TotalAmount", Convert.ToInt32(insertedTransaction.TotalAmount).ToString());
            rv.LocalReport.SetParameters(TotalAmount);

            ReportParameter TaxAmount = new ReportParameter("TaxAmount", insertedTransaction.TaxAmount.ToString());
            rv.LocalReport.SetParameters(TaxAmount);

            ReportParameter DiscountAmount = new ReportParameter("DiscountAmount", insertedTransaction.DiscountAmount.ToString());
            rv.LocalReport.SetParameters(DiscountAmount);

            ReportParameter PaidAmount = new ReportParameter("PaidAmount", "0");
            rv.LocalReport.SetParameters(PaidAmount);

            ReportParameter Change = new ReportParameter("Change", "0");
            rv.LocalReport.SetParameters(Change);

            for (int i = 0; i <= 1; i++)
            {
                PrintDoc.PrintReport(rv, "Slip");
            }
            #endregion


            //MessageBox.Show("Payment Completed");

            if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
            {
                Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                newForm.Clear();
            }

            this.Dispose();
        }
    }
}