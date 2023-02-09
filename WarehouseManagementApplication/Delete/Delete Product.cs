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
    public partial class Delete_Product : Form
    {
        public ProductEntity _productEntity = new ProductEntity();
        public ProductBusinessAccess _productBusinessAccess = new ProductBusinessAccess();
        public Delete_Product()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteProductDetails_Click(object sender, EventArgs e)
        {
            if (txtProductId.Text.Equals(string.Empty))
            {
                MessageBox.Show("Product Id Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Are you sure you want to delete this Product!!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (btnDeleteProductDetails.Text == "Delete")
            {
                _productEntity.productId = Convert.ToInt32(txtProductId.Text);
               


                if (_productBusinessAccess.productdeleteDetails(_productEntity) != 0)
                {
                    MessageBox.Show("Product Deleted Successfully");
                }
            }
            Manager_Dashboard home = new Manager_Dashboard();
            home.ShowDialog();
            this.Dispose();

        }
    }
}
