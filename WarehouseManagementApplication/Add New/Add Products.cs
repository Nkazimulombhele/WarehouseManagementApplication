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
    public partial class Add_Products : Form
    {
        public ProductEntity _productEntity = new ProductEntity();
        public ProductBusinessAccess _productBusinessAccess = new ProductBusinessAccess();
        public Add_Products()
        {
            InitializeComponent();
        }

        private void btnSaveProductDetails_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Product Name Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSupplierId.Text.Equals(string.Empty))
            {
                MessageBox.Show("SupplierId Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCategoryId.Text.Equals(string.Empty))
            {
                MessageBox.Show("CategoryId Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtQuantityPerUnit.Text.Equals(string.Empty))
            {
                MessageBox.Show("QuantityPerUnit Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtUnitPrice.Text.Equals(string.Empty))
            {
                MessageBox.Show("UnitPrice Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtUnitsInStock.Text.Equals(string.Empty))
            {
                MessageBox.Show("UnitsInStock Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (txtUnitsOnOrder.Text.Equals(string.Empty))
            {
                MessageBox.Show("UnitsInOrder Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtReorderLevel.Text.Equals(string.Empty))
            {
                MessageBox.Show("ReorderLevel Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDiscontinued.Text.Equals(string.Empty))
            {
                MessageBox.Show("Descontinued Field is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (btnSaveProductDetails.Text == "Save")
            {
                _productEntity.productName = txtProductName.Text;
                _productEntity.supplierId = Convert.ToInt32(txtSupplierId.Text);
                _productEntity.categoryId = Convert.ToInt32(txtCategoryId.Text);
                _productEntity.quantityPerUnit = txtQuantityPerUnit.Text;
                _productEntity.unitPrice = Convert.ToInt32(txtUnitPrice.Text);
                _productEntity.unitsInStock = Convert.ToInt32(txtUnitsInStock.Text);
                _productEntity.unitsOnOrder = Convert.ToInt32(txtUnitsOnOrder.Text);
                _productEntity.reorderLevel = Convert.ToInt32(txtReorderLevel.Text);
                _productEntity.discontinued = txtDiscontinued.Text;


                if (_productBusinessAccess.productinsertDetails(_productEntity) > 0)
                {
                    MessageBox.Show("Product Inserted Successfully");
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

        private void Add_Products_Load(object sender, EventArgs e)
        {

        }
    }
}
