using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopInCsharp.Models
{
    public class ProductCategory : BaseModel
    {
        public string Department { get; set; }

        public List<Product> Products { get; set; }
    }
}
