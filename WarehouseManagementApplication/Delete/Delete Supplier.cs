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

namespace WarehouseManagementApplication.Delete
{
    public partial class Delete_Supplier : Form
    {
        public SupplierEntity _supplierEntity = new SupplierEntity();
        public SupplierBusinessAccess _supplierBusinessAccess = new SupplierBusinessAccess();
        public Delete_Supplier()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteSupplierDetails_Click(object sender, EventArgs e)
        {
            if (txtSupplierId.Text.Equals(string.Empty))
            {
                MessageBox.Show("Supplier Id Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Are you sure you want to delete supplier!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (btnDeleteSupplierDetails.Text == "Delete")
            {
                _supplierEntity.supplierId = Convert.ToInt32(txtSupplierId.Text);
              


                if (_supplierBusinessAccess.supplierDeleteDetails(_supplierEntity) != 0)
                {
                    MessageBox.Show("Supplier Deleted Successfully");
                }
            }
            Manager_Dashboard home = new Manager_Dashboard();
            home.ShowDialog();
            this.Dispose();


        }
    }
}
