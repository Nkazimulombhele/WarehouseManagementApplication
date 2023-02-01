using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementApplication.Add_New;

namespace WarehouseManagementApplication.Manager_Controls
{
    public partial class UC_ManageSuppliers : UserControl
    {
        public UC_ManageSuppliers()
        {
            InitializeComponent();
        }

        private void btnAddNewSupplier_Click(object sender, EventArgs e)
        {
            Add_Suppliers As = new Add_Suppliers();
            As.ShowDialog();
        }
    }
}
