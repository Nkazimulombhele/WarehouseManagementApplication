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
    public class SupplierRepository
    {
        public SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WarehouseManagementDB;Integrated Security=True");
        public SqlCommand cmd = new SqlCommand();

        public int supplierinsert(SupplierEntity supplierEntity)
        {
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertSuppliers_sp";

            cmd.Parameters.AddWithValue("@CompanyName", supplierEntity.companyName);
            cmd.Parameters.AddWithValue("@ContactName", supplierEntity.contactName);
            cmd.Parameters.AddWithValue("@ContactTitle", supplierEntity.contactTitle);
            cmd.Parameters.AddWithValue("@Address", supplierEntity.address);
            cmd.Parameters.AddWithValue("@City", supplierEntity.city);
            cmd.Parameters.AddWithValue("@Region", supplierEntity.region);
            cmd.Parameters.AddWithValue("@PostalCode", supplierEntity.postalCode);
            cmd.Parameters.AddWithValue("@Country", supplierEntity.country);
            cmd.Parameters.AddWithValue("@Phone", supplierEntity.phone);
            cmd.Parameters.AddWithValue("@Fax", supplierEntity.fax);
            cmd.Parameters.AddWithValue("@HomePage", supplierEntity.homePage);


            int i = cmd.ExecuteNonQuery();
            return i;


        }

        public int supplierUpdate(SupplierEntity supplierEntity)
        {
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updateSuppliers_sp";
            cmd.Parameters.AddWithValue("@SupplierId", supplierEntity.supplierId);
            cmd.Parameters.AddWithValue("@CompanyName", supplierEntity.companyName);
            cmd.Parameters.AddWithValue("@ContactName", supplierEntity.contactName);
            cmd.Parameters.AddWithValue("@ContactTitle", supplierEntity.contactTitle);
            cmd.Parameters.AddWithValue("@Address", supplierEntity.address);
            cmd.Parameters.AddWithValue("@City", supplierEntity.city);
            cmd.Parameters.AddWithValue("@Region", supplierEntity.region);
            cmd.Parameters.AddWithValue("@PostalCode", supplierEntity.postalCode);
            cmd.Parameters.AddWithValue("@Country", supplierEntity.country);
            cmd.Parameters.AddWithValue("@Phone", supplierEntity.phone);
            cmd.Parameters.AddWithValue("@Fax", supplierEntity.fax);
            cmd.Parameters.AddWithValue("@HomePage", supplierEntity.homePage);

            int i = cmd.ExecuteNonQuery();
            return i;




        }

        public int supplierDelete(SupplierEntity supplierEntity)
        {
            cmd.Connection = con;
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "deleteSupplier_sp";

            cmd.Parameters.AddWithValue("@SupplierId", supplierEntity.supplierId);

            int i = cmd.ExecuteNonQuery();
            return i;


        }
    }
}
