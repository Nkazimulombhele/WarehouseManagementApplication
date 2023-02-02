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
using WarehouseManagementApplication.Delete;
using WarehouseManagementApplication.Edit;

namespace WarehouseManagementApplication.Manager_Controls
{
    public partial class UC_ManageCategories : UserControl
    {
  
        public UC_ManageCategories()
        {
            InitializeComponent();
            Display();
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
            DisplayAndSearch("Select CategoryName,Description,Picture FROM Categories ", dataGridView1);
        }

        private void btnAddCategories_Click(object sender, EventArgs e)
        {
            Add_Categories ac = new Add_Categories();
            ac.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit_Categories ac = new Edit_Categories();
            ac.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete_Category ac = new Delete_Category();
            ac.ShowDialog();
        }
    }
}
