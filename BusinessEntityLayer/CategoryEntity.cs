using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class CategoryEntity
    {
        public int categoryId { get; set; }
        public string categoryname { get; set; }
        public string description { get; set; }
        public byte[] picture { get; set; }
    }
}
