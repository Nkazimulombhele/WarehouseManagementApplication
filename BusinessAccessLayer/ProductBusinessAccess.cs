using BusinessEntityLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer
{
    public class ProductBusinessAccess
    {
        ProductEntity _productEntity = new ProductEntity();
        ProductRepository _productRepository = new ProductRepository();


        public int productinsertDetails(ProductEntity productEntity)
        {
            return _productRepository.productinsert(productEntity);
        }
        public int productupdateDetails(ProductEntity productEntity, int id)
        {
            return _productRepository.productUpdate(productEntity, id);
        }
        public int productdeleteDetails(int id)
        {
            return _productRepository.productDelete(id);
        }
    }
}
