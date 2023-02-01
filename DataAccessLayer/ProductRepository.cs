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
    public class ProductRepository
    {
        public SqlConnection con = new SqlConnection("Data Source=(Localdb)\\MSSQLLocalDB;Initial Catalog=WarehouseManagementDB;Integrated Security=True,MultipleActiveResultSets=true");
        public SqlCommand cmd = new SqlCommand();

        public int productinsert(ProductEntity productEntity)
        {
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insertProduct_sp";

            cmd.Parameters.AddWithValue("@ProductName", productEntity.productName);
            cmd.Parameters.AddWithValue("@SupplierId", productEntity.supplierId);
            cmd.Parameters.AddWithValue("@CategoryId", productEntity.categoryId);
            cmd.Parameters.AddWithValue("@QuantityPerUnit", productEntity.quantityPerUnit);
            cmd.Parameters.AddWithValue("@UnitPrice", productEntity.unitPrice);
            cmd.Parameters.AddWithValue("@UnitsInStock", productEntity.unitsInStock);
            cmd.Parameters.AddWithValue("@UnitsOnOrder", productEntity.unitsOnOrder);
            cmd.Parameters.AddWithValue("@ReorderLevel", productEntity.reorderLevel);
            cmd.Parameters.AddWithValue("@discontinued", productEntity.discontinued);


            int i = cmd.ExecuteNonQuery();
            return i;

        }

        public int productUpdate(ProductEntity productEntity, int id)
        {
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updateProduct_sp";

            cmd.Parameters.AddWithValue("@ProductName", productEntity.productName);
            cmd.Parameters.AddWithValue("@SupplierId", productEntity.supplierId);
            cmd.Parameters.AddWithValue("@CategoryId", productEntity.categoryId);
            cmd.Parameters.AddWithValue("@QuantityPerUnit", productEntity.quantityPerUnit);
            cmd.Parameters.AddWithValue("@UnitPrice", productEntity.unitPrice);
            cmd.Parameters.AddWithValue("@UnitsInStock", productEntity.unitsInStock);
            cmd.Parameters.AddWithValue("@UnitsOnOrder", productEntity.unitsOnOrder);
            cmd.Parameters.AddWithValue("@ReorderLevel", productEntity.reorderLevel);
            cmd.Parameters.AddWithValue("@discontinued", productEntity.discontinued);


            int i = cmd.ExecuteNonQuery();
            return i;




        }

        public int productDelete(int id)
        {
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "deleteProduct_sp";

            cmd.Parameters.AddWithValue("@ProductId", id);

            int i = cmd.ExecuteNonQuery();
            return i;


        }
    }
}
