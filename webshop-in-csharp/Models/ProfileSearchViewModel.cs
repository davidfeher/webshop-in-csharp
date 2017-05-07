using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopInCsharp.Models
{
    public class ProfileSearchViewModel
    {
        [Display(Name = "I'm looking for a ")]
        public Gender Gender { get; set; }

        [Display(Name ="Age from")]
        public int MinAge { get; set; }
        [Display(Name = "to")]
        public int MaxAge { get; set; }
    }
}
