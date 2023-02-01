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
using BusinessEntityLayer;
using WarehouseManagementApplication.Add_New;

namespace WarehouseManagementApplication.Manager_Controls
{
    public partial class UC_ManageSuppliers : UserControl
    {
        public UC_ManageSuppliers()
        {
            InitializeComponent();
            Display();
        }

        private void btnAddNewSupplier_Click(object sender, EventArgs e)
        {
            Add_Suppliers As = new Add_Suppliers();
            As.ShowDialog();
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
            DisplayAndSearch("Select CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,HomePage FROM Suppliers ", dataGridView);
        }




     

      
    }
}
