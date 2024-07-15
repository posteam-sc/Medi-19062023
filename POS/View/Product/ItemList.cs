﻿using POS.APP_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class ItemList : Form
    {
        #region Variable

        private POSEntities entity = new POSEntities();
        private bool IsCategoryId = false;
        private bool IsSubCategoryId = false;
        private bool IsLineId = false;
        private bool Isname = false;
        private int CategoryId;
        private int subCategoryId;
        private int LineId;
        private string name;
        private List<Product> productList = new List<Product>();
        #endregion

        #region Event

        public ItemList()
        {
            InitializeComponent();

        }

        private void ItemList_Load(object sender, EventArgs e)
        {
            dgvItemList.AutoGenerateColumns = false;
            rdbAll.Checked = true;
            gbBarCode.Enabled = false;

            List<APP_Data.Line> LineList = new List<APP_Data.Line>();
            APP_Data.Line lineObj1 = new APP_Data.Line();
            lineObj1.Id = 0;
            lineObj1.Name = "Select";
            APP_Data.Line lineObj2 = new APP_Data.Line();
            lineObj2.Id = 1;
            lineObj2.Name = "None";
            LineList.Add(lineObj1);
            LineList.Add(lineObj2);
            LineList.AddRange((from lList in entity.Lines select lList).ToList());
            cboLine.DataSource = LineList;
            cboLine.DisplayMember = "Name";
            cboLine.ValueMember = "Id";
            cboLine.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboLine.AutoCompleteSource = AutoCompleteSource.ListItems;

            List<APP_Data.ProductSubCategory> pSubCatList = new List<APP_Data.ProductSubCategory>();
            APP_Data.ProductSubCategory SubCategoryObj1 = new APP_Data.ProductSubCategory();
            SubCategoryObj1.Id = 0;
            SubCategoryObj1.Name = "Select";
            APP_Data.ProductSubCategory SubCategory2 = new APP_Data.ProductSubCategory();
            SubCategory2.Id = 1;
            SubCategory2.Name = "None";
            pSubCatList.Add(SubCategoryObj1);
            pSubCatList.Add(SubCategory2);
            //pSubCatList.AddRange((from c in entity.ProductSubCategories where c.ProductCategoryId == Convert.ToInt32(cboMainCategory.SelectedValue) select c).ToList());
            cboSubCategory.DataSource = pSubCatList;
            cboSubCategory.DisplayMember = "Name";
            cboSubCategory.ValueMember = "Id";
            cboSubCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSubCategory.AutoCompleteSource = AutoCompleteSource.ListItems;

            List<APP_Data.ProductCategory> pMainCatList = new List<APP_Data.ProductCategory>();
            APP_Data.ProductCategory MainCategoryObj1 = new APP_Data.ProductCategory();
            MainCategoryObj1.Id = 0;
            MainCategoryObj1.Name = "Select";
            APP_Data.ProductCategory MainCategoryObj2 = new APP_Data.ProductCategory();
            MainCategoryObj2.Id = 1;
            MainCategoryObj2.Name = "None";
            pMainCatList.Add(MainCategoryObj1);
            pMainCatList.Add(MainCategoryObj2);
            pMainCatList.AddRange((from MainCategory in entity.ProductCategories select MainCategory).ToList());
            cboMainCategory.DataSource = pMainCatList;
            cboMainCategory.DisplayMember = "Name";
            cboMainCategory.ValueMember = "Id";
            cboMainCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboMainCategory.AutoCompleteSource = AutoCompleteSource.ListItems;

            DataBind();


        }

        //private void ItemList_Activated(object sender, EventArgs e)
        //{
        //    foundDataBind();
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //Role Management
            RoleManagementController controller = new RoleManagementController();
            controller.Load(MemberShip.UserRoleId);
            if (controller.Product.Add || MemberShip.isAdmin)
            {
                NewProduct newForm = new NewProduct();
                newForm.isEdit = false;
                newForm.Show();
            }
            else
            {
                MessageBox.Show("You are not allowed to add new product", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvItemList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int count = 1;
            foreach (DataGridViewRow row in dgvItemList.Rows)
            {
                Product productObj = (Product)row.DataBoundItem;

                row.Cells[0].Value = productObj.Id;
                row.Cells[1].Value = count.ToString();
                row.Cells[2].Value = productObj.ProductCode;
                row.Cells[3].Value = productObj.Name;
                row.Cells[4].Value = productObj.Qty;
                row.Cells[5].Value = productObj.Price;
                row.Cells[6].Value = productObj.DiscountRate + "%";
                count++;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            IsCategoryId = false;
            CategoryId = 0;
            IsSubCategoryId = false;
            subCategoryId = 0;
            IsLineId = false;
            LineId = 0;
            Isname = false;
            name = string.Empty;
            productList.Clear();
            if (cboMainCategory.SelectedIndex > 1)
            {
                IsCategoryId = true;
                CategoryId = Convert.ToInt32(cboMainCategory.SelectedValue);
            }
            if (cboSubCategory.SelectedIndex > 0)
            {
                IsSubCategoryId = true;
                subCategoryId = Convert.ToInt32(cboSubCategory.SelectedValue);
            }
            if (cboLine.SelectedIndex > 0)
            {
                IsLineId = true;
                LineId = Convert.ToInt32(cboLine.SelectedValue);
            }
            if (txtName.Text.Trim() != string.Empty)
            {
                Isname = true;
                name = txtName.Text;
            }
            // find product code id
            if (IsCategoryId == true && IsSubCategoryId == true && IsLineId == true && Isname == true)
            {
                if (LineId == 0 || LineId == 1)
                {
                    if (subCategoryId == 0)
                    {
                        productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.ProductSubCategoryId == null && p.LineId == null && p.Name.Contains(name) select p).ToList());
                    }
                    else
                    {
                        productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.ProductSubCategoryId == subCategoryId && p.LineId == null && p.Name.Contains(name) select p).ToList());
                    }
                }
                else
                {
                    if (subCategoryId == 0)
                    {
                        productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.ProductSubCategoryId == null && p.LineId == LineId && p.Name.Contains(name) select p).ToList());
                    }
                    else
                    {
                        productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.ProductSubCategoryId == subCategoryId && p.LineId == LineId && p.Name.Contains(name) select p).ToList());
                    }
                }

                foundDataBind();
            }
            else if (IsCategoryId == true && IsSubCategoryId == true && IsLineId == true && Isname == false)
            {
                if (LineId == 0 || LineId == 1)
                {
                    if (subCategoryId == 0)
                    {
                        productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.ProductSubCategoryId == null && p.LineId == null select p).ToList());
                    }
                    else
                    {
                        productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.ProductSubCategoryId == subCategoryId && p.LineId == null select p).ToList());
                    }
                }
                else
                {
                    if (subCategoryId == 0)
                    {
                        productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.ProductSubCategoryId == null && p.LineId == LineId select p).ToList());
                    }
                    else
                    {
                        productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.ProductSubCategoryId == subCategoryId && p.LineId == LineId select p).ToList());
                    }
                }

                foundDataBind();
            }
            else if (IsCategoryId == true && IsSubCategoryId == true && IsLineId == false && Isname == false)
            {
                if (subCategoryId == 0)
                {
                    productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.ProductSubCategoryId == null select p).ToList());
                }
                else
                {
                    productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.ProductSubCategoryId == subCategoryId select p).ToList());
                }

                foundDataBind();
            }
            else if (IsCategoryId == true && IsSubCategoryId == true && IsLineId == false && Isname == true)
            {
                if (subCategoryId == 0)
                {
                    productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.ProductSubCategoryId == null && p.Name.Contains(name) select p).ToList());
                }
                else
                {
                    productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.ProductSubCategoryId == subCategoryId && p.Name.Contains(name) select p).ToList());
                }

                foundDataBind();
            }
            else if (IsCategoryId == false && IsSubCategoryId == false && IsLineId == true && Isname == true)
            {
                if (LineId == 0 || LineId == 1)
                {
                    productList.AddRange((from p in entity.Products where p.LineId == null && p.Name.Contains(name) select p).ToList());
                }
                else
                {
                    productList.AddRange((from p in entity.Products where p.LineId == LineId && p.Name.Contains(name) select p).ToList());
                }

                foundDataBind();
            }
            else if (IsCategoryId == false && IsSubCategoryId == false && IsLineId == true && Isname == false)
            {
                if (LineId == 0 || LineId == 1)
                {
                    productList.AddRange((from p in entity.Products where p.LineId == null select p).ToList());
                }
                else
                {
                    productList.AddRange((from p in entity.Products where p.LineId == LineId select p).ToList());
                }

                foundDataBind();
            }
            else if (IsCategoryId == false && IsSubCategoryId == false && IsLineId == false && Isname == true)
            {
                productList.AddRange((from p in entity.Products where p.Name.Contains(name) select p).ToList());
                foundDataBind();
            }
            else if (IsCategoryId == true && IsSubCategoryId == false && IsLineId == false && Isname == false)
            {
                productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId select p).ToList());
                foundDataBind();
            }
            else if (IsCategoryId == true && IsSubCategoryId == false && IsLineId == true && Isname == true)
            {
                if (LineId == 0 || LineId == 1)
                {
                    productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.LineId == null && p.Name.Contains(name) select p).ToList());
                }
                else
                {
                    productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.LineId == LineId && p.Name.Contains(name) select p).ToList());
                }

                foundDataBind();
            }
            else if (IsCategoryId == true && IsSubCategoryId == false && IsLineId == true && Isname == false)
            {
                if (LineId == 0 || LineId == 1)
                {
                    productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.LineId == null select p).ToList());
                }
                else
                {
                    productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.LineId == LineId select p).ToList());
                }

                foundDataBind();
            }
            else if (IsCategoryId == true && IsSubCategoryId == false && IsLineId == false && Isname == true)
            {
                productList.AddRange((from p in entity.Products where p.ProductCategoryId == CategoryId && p.Name.Contains(name) select p).ToList());
                foundDataBind();
            }
            else if (IsCategoryId == false && IsSubCategoryId == false && IsLineId == false && Isname == false)
            {
                productList.AddRange(entity.Products.ToList());
                foundDataBind();
            }
            //else
            //{
            //    //to show message 
            //    MessageBox.Show("Can't find!", "Cannot find");
            //    dgvItemList.DataSource = "";
            //}
            else
            {
                foundDataBind();
            }
        }

        private void dgvItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                //Role Management
                RoleManagementController controller = new RoleManagementController();
                controller.Load(MemberShip.UserRoleId);
                int currentProductId = Convert.ToInt32(dgvItemList.Rows[e.RowIndex].Cells[0].Value);
                if (e.ColumnIndex == 7)
                {
                    ProductBatchDetail batchdetailForm = new ProductBatchDetail();
                    batchdetailForm.ProductId = currentProductId;
                    batchdetailForm.ProdName = dgvItemList.Rows[e.RowIndex].Cells[3].Value.ToString();
                    batchdetailForm.ShowDialog();
                }

                if (e.ColumnIndex == 8)
                {
                    if (controller.Product.EditOrDelete || MemberShip.isAdmin)
                    {
                        NewProduct newform = new NewProduct();
                        newform.isEdit = true;
                        newform.Text = "Edit Product";
                        newform.ProductId = currentProductId;
                        newform.Show();
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to edit products", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                //Print
                else if (e.ColumnIndex == 9)
                {
                    //to print barcode
                    PrintBarcode newform = new PrintBarcode();
                    newform.productId = currentProductId;
                    newform.Show();
                }
                //Delete
                else if (e.ColumnIndex == 10)
                {
                    if (controller.Product.EditOrDelete || MemberShip.isAdmin == true)
                    {

                        DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {
                            DataGridViewRow row = dgvItemList.Rows[e.RowIndex];
                            Product productObj = (Product)row.DataBoundItem;
                            productObj = (from p in entity.Products where p.Id == productObj.Id select p).FirstOrDefault();
                            List<WrapperItem> wList = entity.WrapperItems.Where(x => x.ChildProductId == productObj.Id).ToList();
                            if (productObj.TransactionDetails.Count > 0)
                            {
                                MessageBox.Show("This product is used in transaction!", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            //Product is used in wrapper Item.                            
                            //else if(productObj.WrapperItems1.Count > 0 || productObj.WrapperItems.Count >0){
                            else if (wList.Count > 0)
                            {
                                MessageBox.Show("This product is used in a wrapper!", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                List<ProductPriceChange> pC = new List<ProductPriceChange>();
                                pC = entity.ProductPriceChanges.Where(x => x.ProductId == productObj.Id).ToList();
                                if (pC.Count > 0)
                                {
                                    foreach (ProductPriceChange p in pC)
                                    {
                                        entity.ProductPriceChanges.Remove(p);
                                    }
                                }

                                if (productObj.IsWrapper == true)
                                {
                                    List<WrapperItem> wL = entity.WrapperItems.Where(x => x.ParentProductId == productObj.Id).ToList();
                                    if (wL.Count > 0)
                                    {
                                        foreach (WrapperItem w in wL)
                                        {
                                            entity.WrapperItems.Remove(w);
                                        }
                                    }
                                }
                                //entity.ProductPriceChanges.de
                                entity.Products.Remove(productObj);

                                entity.SaveChanges();
                                DataBind();
                                MessageBox.Show("Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to delete products", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                //Price Detail
                else if (e.ColumnIndex == 11)
                {
                    ProductDetailPrice newForm = new ProductDetailPrice();
                    newForm.ProductId = currentProductId;
                    newForm.ShowDialog();
                }
            }
        }

        private void cboMainCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboMainCategory.SelectedIndex != 0 && cboMainCategory.SelectedIndex != 1)
            {
                int productCategoryId = Int32.Parse(cboMainCategory.SelectedValue.ToString());
                List<APP_Data.ProductSubCategory> pSubCatList = new List<APP_Data.ProductSubCategory>();
                APP_Data.ProductSubCategory SubCategoryObj1 = new APP_Data.ProductSubCategory();
                SubCategoryObj1.Id = 0;
                SubCategoryObj1.Name = "Select";
                pSubCatList.Add(SubCategoryObj1);
                pSubCatList.AddRange((from c in entity.ProductSubCategories where c.ProductCategoryId == productCategoryId select c).ToList());
                cboSubCategory.DataSource = pSubCatList;
                cboSubCategory.DisplayMember = "Name";
                cboSubCategory.ValueMember = "Id";
                cboSubCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboSubCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
                cboSubCategory.Enabled = true;
            }
            else
            {
                cboSubCategory.SelectedIndex = 0;
                cboSubCategory.Enabled = false;
            }

        }

        private void rdbBarCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBarCode.Checked)
            {
                gbBarCode.Enabled = true;
                dgvItemList.DataSource = "";
                Clear();
            }

        }

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAll.Checked)
            {
                gbType.Enabled = true;
                DataBind();
                Clear();
            }

        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            productList.Clear();

            productList.AddRange((from p in entity.Products where p.Barcode.Trim() == txtBarcode.Text.Trim() select p).ToList());
            foundDataBind();
        }
        //private void ItemList_Activated_1(object sender, EventArgs e)
        //{
        //    foundDataBind();
        //}

        #endregion

        #region Function

        public void DataBind()
        {
            entity = new POSEntities();
            dgvItemList.DataSource = entity.Products.ToList();
        }

        private void foundDataBind()
        {
            dgvItemList.DataSource = "";

            if (productList.Count < 1)
            {
                MessageBox.Show("Item not found!", "Cannot find");
                dgvItemList.DataSource = "";
                return;
            }
            else
            {
                dgvItemList.DataSource = productList;
            }
        }

        private void Clear()
        {
            txtBarcode.Text = "";
            txtName.Text = "";


        }
        #endregion





    }
}