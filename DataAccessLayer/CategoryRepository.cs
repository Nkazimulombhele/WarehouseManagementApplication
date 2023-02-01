using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntityLayer;

namespace DataAccessLayer
{
    public class CategoryRepository
    {
        public SqlConnection con = new SqlConnection("Data Source=(Localdb)\\MSSQLLocalDB;Initial Catalog=WarehouseManagementDB;Integrated Security=True");
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


            int i = cmd.ExecuteNonQuery();
            return i;


        }

        public int categoryUpdate(CategoryEntity categoryEntity, int id)
        {
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updateCategory_sp";

            cmd.Parameters.AddWithValue("@CategoryName", categoryEntity.categoryname);
            cmd.Parameters.AddWithValue("@Description", categoryEntity.description);
            cmd.Parameters.AddWithValue("@Picture", categoryEntity.picture);

            int i = cmd.ExecuteNonQuery();
            return i;





        }

        public int categoryDelete(int id)
        {
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "deleteCategory_sp";

            cmd.Parameters.AddWithValue("@CategoryId", id);

            int i = cmd.ExecuteNonQuery();
            return i;



        }
    }
}
