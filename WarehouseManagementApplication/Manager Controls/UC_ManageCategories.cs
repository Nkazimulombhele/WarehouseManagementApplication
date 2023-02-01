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
    public partial class UC_ManageCategories : UserControl
    {
  
        public UC_ManageCategories()
        {
            InitializeComponent();
        }

        public void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            SqlConnection con = new SqlConnection(sql);
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
        }

        private void btnAddCategories_Click(object sender, EventArgs e)
        {
            Add_Categories ac = new Add_Categories();
            ac.ShowDialog();
        }
    }
}
