using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopInCsharp.Models
{
    public class ProductSearchResultModel
    {
        public int Id { get; set;
        }
        [Display(Name = "Name")]
        public string DisplayName { get; set; }

        public string Description { get; set; }

        [Display(Name = "Picture")]
        public string ProductPicture { get; set; }
    }
}
