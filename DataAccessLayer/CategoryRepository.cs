using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntityLayer;
using System.IO;

namespace DataAccessLayer
{
    public class CategoryRepository
    {
        public SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WarehouseManagementDB;Integrated Security=True");
        public SqlCommand cmd = new SqlCommand();

     
        
        public int categoryinsert(CategoryEntity categoryEntity)
        {
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insertCategory_sp";

            cmd.Parameters.AddWithValue("@CategoryName", categoryEntity.categoryname);
            cmd.Parameters.AddWithValue("@Description", categoryEntity.description);
            cmd.Parameters.AddWithValue("@Picture", categoryEntity.picture);


           return cmd.ExecuteNonQuery();
            

        }

        public int categoryUpdate(CategoryEntity categoryEntity)
        {
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updateCategory_sp";
            cmd.Parameters.AddWithValue("@CategoryId", categoryEntity.categoryId);
            cmd.Parameters.AddWithValue("@CategoryName", categoryEntity.categoryname);
            cmd.Parameters.AddWithValue("@Description", categoryEntity.description);
            cmd.Parameters.AddWithValue("@Picture", categoryEntity.picture);

            int i = cmd.ExecuteNonQuery();
            return i;

        }

        public int categoryDelete(CategoryEntity categoryEntity)
        {
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "deleteCategory_sp";

            cmd.Parameters.AddWithValue("@CategoryId", categoryEntity.categoryId);

            int i = cmd.ExecuteNonQuery();
            return i;



        }
    }
}
