using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopInCsharp.Models
{
    public class Supplier : BaseModel
    {
        public List<Product> Products { get; set; }
    }
}
