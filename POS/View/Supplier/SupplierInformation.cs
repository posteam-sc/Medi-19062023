using POS.APP_Data;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class SupplierInformation : Form
    {
        #region Variable

        POSEntities entity = new POSEntities();
        public int supplierId;
        public int OldCreditAmount;

        #endregion
        #region Event

        public SupplierInformation()
        {
            InitializeComponent();
        }

        private void SupplierInformation_Load(object sender, EventArgs e)
        {
            Supplier sp = (from s in entity.Suppliers where s.Id == supplierId select s).FirstOrDefault();
            lblName.Text = sp.Name;
            lblEnail.Text = (sp.Email == null) ? "-" : sp.Email;
            lblPhNo.Text = sp.PhoneNumber;
            lblAddress.Text = sp.Address;
            lblContactPerson.Text = sp.ContactPerson;
            lblCreditAmount.Text = OldCreditAmount.ToString();
        }
        #endregion
    }
}
