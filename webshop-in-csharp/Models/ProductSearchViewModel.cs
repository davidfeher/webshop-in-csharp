using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopInCsharp.Models
{
    public class ProductSearchViewModel
    {
        [Display(Name = "Product name")]
        public string Name { get; set; }

        public Supplier Supplier { get; set; }

        [Display(Name = "Category")]
        public ProductCategory Category { get; set; }
    }
}
