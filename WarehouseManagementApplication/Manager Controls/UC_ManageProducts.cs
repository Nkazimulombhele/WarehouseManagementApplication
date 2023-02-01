using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementApplication.Add_New;

namespace WarehouseManagementApplication.Manager_Controls
{
    public partial class UC_ManageProducts : UserControl
    {
        public UC_ManageProducts()
        {
            InitializeComponent();
            Display();
        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            Add_Products abn = new Add_Products();
            abn.ShowDialog();
        }
        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WarehouseManagementDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adp.Fill(dataTable);
            dgv.DataSource = dataTable;
            con.Close();
        }
        public void Display()
        {
            DisplayAndSearch("Select ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,discontinued FROM Products ", dataGridView1);
        }

    }
}
