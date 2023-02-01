using BusinessEntityLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer
{
    public class SupplierBusinessAccess
    {
        SupplierEntity supplierEntity = new SupplierEntity();
        SupplierRepository _supplierRepository = new SupplierRepository();


        public int supplierinsertDetails(SupplierEntity supplierEntity)
        {
            return _supplierRepository.supplierinsert(supplierEntity);
        }

        public int supplierUpdateDetails(SupplierEntity supplierEntity, int id)
        {
            return _supplierRepository.supplierUpdate(supplierEntity, id);
        }

        public int supplierDeleteDetails(int id)
        {
            return _supplierRepository.supplierDelete(id);
        }
    }
}
