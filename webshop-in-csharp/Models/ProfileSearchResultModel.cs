using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopInCsharp.Models
{
    public class ProfileSearchResultModel
    {
        public int Id { get; set; }

        public Gender Gender { get; set; }

        [Display(Name = "Name")]
        public string DisplayName { get; set; }

        public int Age { get; set; }

        public string Description { get; set; }

        [Display(Name = "Profile picture")]
        public string ProfilePicture { get; set; }
    }
}
