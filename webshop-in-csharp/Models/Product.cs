using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopInCsharp.Models
{
    public class Product : BaseModel
    {
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public ProductCategory ProductCategory { get; set; }

        public Supplier Supplier { get; set; }

        [Display(Name = "Product Image")]
        public string Image { get; set; }
    }
}
