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

namespace WarehouseManagementApplication.Edit
{
    public partial class Edit_Products : Form
    {
        public ProductEntity _productEntity = new ProductEntity();
        public ProductBusinessAccess _productBusinessAccess = new ProductBusinessAccess();
        public Edit_Products()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Edit_Products_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdateProductDetails_Click(object sender, EventArgs e)
        {
            if (txtProductId.Text.Equals(string.Empty))
            {
                MessageBox.Show("Product Id Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (btnUpdateProductDetails.Text == "Update")
            {
                _productEntity.productId = Convert.ToInt32(txtProductId.Text);
                _productEntity.productName = txtProductName.Text;
                _productEntity.supplierId = Convert.ToInt32(txtSupplierId.Text);
                _productEntity.categoryId = Convert.ToInt32(txtCategoryId.Text);
                _productEntity.quantityPerUnit = txtQuantityPerUnit.Text;
                _productEntity.unitPrice = Convert.ToInt32(txtUnitPrice.Text);
                _productEntity.unitsInStock = Convert.ToInt32(txtUnitInStock.Text);
                _productEntity.unitsOnOrder = Convert.ToInt32(txtUnitsInOrder.Text);
                _productEntity.reorderLevel = Convert.ToInt32(txtReorderLevel.Text);
                _productEntity.discontinued = txtDiscontinued.Text;


                if (_productBusinessAccess.productupdateDetails(_productEntity) != 0)
                {
                    
                    MessageBox.Show("Product Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            Manager_Dashboard home = new Manager_Dashboard();
            home.ShowDialog();
            this.Dispose();

        }
    }
}
