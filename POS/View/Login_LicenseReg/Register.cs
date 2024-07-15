﻿using POS.APP_Data;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace POS
{
    public partial class Register : Form
    {
        private POSEntities entity = new POSEntities();

        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var t = cboMacAddress.SelectedValue;
            string macId = Regex.Replace(cboMacAddress.SelectedValue.ToString(), ".{2}", "$0-").Substring(0, 17);

            String Key = txtLicenseKey.Text.Trim();
            Authorize currentKey = new Authorize();
            foreach (Authorize aut in entity.Authorizes)
            {
                if (Utility.DecryptString(aut.licenseKey, "ABCD") == Key)
                    currentKey = aut;
            }

            if (currentKey.Id != 0)
            {
                if (currentKey.macAddress == null)
                {
                    try
                    {
                        currentKey.macAddress = Utility.EncryptString(macId, "ABCD");
                        entity.SaveChanges();
                        MessageBox.Show("Registration complete", "Complete");
                        //((MDIParent)this.ParentForm).menuStrip.Enabled = true ;

                        //Sales form = new Sales();
                        //form.WindowState = FormWindowState.Maximized;
                        //form.MdiParent = ((MDIParent)this.ParentForm);
                        //form.Show();

                        Login newform = new Login();
                        newform.WindowState = FormWindowState.Maximized;
                        newform.MdiParent = ((MDIParent)this.ParentForm);
                        newform.Show();
                        this.Dispose();
                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(exe.Message, "Error");
                    }
                }
                else
                {
                    MessageBox.Show("The Key is already in use");
                }
            }
            else
            {
                MessageBox.Show("Wrong License Key", "Error");
            }
        }

        private void txtLicenseKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.AcceptButton = btnRegister;
        }

        private void BindMac()
        {
            cboMacAddress.DataSource = Utility.ManualGetSystemMACID();
            cboMacAddress.DisplayMember = "MacName";
            cboMacAddress.ValueMember = "MacAddress";
        }

        private void Register_Load(object sender, EventArgs e)
        {
            BindMac();
        }
    }
}