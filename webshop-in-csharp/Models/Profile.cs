using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebshopInCsharp.Models.Identity;

namespace WebshopInCsharp.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Profile
    {
        public int Id { get; set; }

        public Gender Gender { get; set; }

        [Display(Name = "Profile name")]
        public string DisplayName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Profile picture")]
        public string ProfilePicture { get; set; }

        public User User { get; set; }
    }
}
