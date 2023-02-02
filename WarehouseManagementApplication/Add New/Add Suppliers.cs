using BusinessAccessLayer;
using BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementApplication.Dashboard;

namespace WarehouseManagementApplication.Add_New
{
    public partial class Add_Suppliers : Form
    {
        public SupplierEntity _supplierEntity = new SupplierEntity();
        public SupplierBusinessAccess _supplierBusinessAccess = new SupplierBusinessAccess();
        public Add_Suppliers()
        {
            InitializeComponent();
        }

        private void btnSaveSupplierDetails_Click(object sender, EventArgs e)
        {
            if (txtCompanyName.Text.Equals(string.Empty))
            {
                MessageBox.Show("CompanyName Name Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtContactName.Text.Equals(string.Empty))
            {
                MessageBox.Show("ContactName Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtContactTitle.Text.Equals(string.Empty))
            {
                MessageBox.Show("ContactTitle Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtAddress.Text.Equals(string.Empty))
            {
                MessageBox.Show("Address Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCity.Text.Equals(string.Empty))
            {
                MessageBox.Show("City Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtRegion.Text.Equals(string.Empty))
            {
                MessageBox.Show("Region Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (txtPostalCode.Text.Equals(string.Empty))
            {
                MessageBox.Show("PostalCode Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCountry.Text.Equals(string.Empty))
            {
                MessageBox.Show("Country Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPhone.Text.Equals(string.Empty))
            {
                MessageBox.Show("Phone Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtFax.Text.Equals(string.Empty))
            {
                MessageBox.Show("Fax Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtHomePage.Text.Equals(string.Empty))
            {
                MessageBox.Show("HomePage Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (btnSaveSupplierDetails.Text == "Save")
            {
                _supplierEntity.companyName = txtCompanyName.Text;
                _supplierEntity.contactName = txtContactName.Text;
                _supplierEntity.contactTitle = txtContactTitle.Text;
                _supplierEntity.address = txtAddress.Text;
                _supplierEntity.city = txtCity.Text;
                _supplierEntity.region = txtRegion.Text;
                _supplierEntity.postalCode = txtPostalCode.Text;
                _supplierEntity.country = txtCountry.Text;
                _supplierEntity.phone = txtPhone.Text;
                _supplierEntity.fax = txtFax.Text;
                _supplierEntity.homePage = txtHomePage.Text;


                if (_supplierBusinessAccess.supplierinsertDetails(_supplierEntity) > 0)
                {
                    MessageBox.Show("Supplier Inserted Successfully");
                }
            }
            Manager_Dashboard home = new Manager_Dashboard();
            home.ShowDialog();
            this.Dispose();



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
