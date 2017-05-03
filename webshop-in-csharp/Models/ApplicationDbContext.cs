using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebshopInCsharp.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopInCsharp.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

    }
}
