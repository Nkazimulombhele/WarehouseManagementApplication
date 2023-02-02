using BusinessEntityLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer
{
    public class CategoryBusinessAccess
    {
        CategoryEntity categoryEntity = new CategoryEntity();
        CategoryRepository _categoryRepository = new CategoryRepository();


        public int categoryinsertDetails(CategoryEntity categoryEntity)
        {
            return _categoryRepository.categoryinsert(categoryEntity);
        }
        public int categoryupdateDetails(CategoryEntity categoryEntity)
        {
            return _categoryRepository.categoryUpdate(categoryEntity);
        }
        public int categorydeleteDetails(CategoryEntity categoryEntity)
        {
            return _categoryRepository.categoryDelete(categoryEntity);
        }
    }
}
