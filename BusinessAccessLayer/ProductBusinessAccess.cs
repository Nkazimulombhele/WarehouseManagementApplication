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
        public int productupdateDetails(ProductEntity productEntity)
        {
            return _productRepository.productUpdate(productEntity);
        }
        public int productdeleteDetails(ProductEntity productEntity)
        {
            return _productRepository.productDelete(productEntity);
        }
    }
}
