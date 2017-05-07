    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebshopInCsharp.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebshopInCsharp.Models;

namespace WebshopInCsharp.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<ProductCategory> Category { get; set; }

        public DbSet<Supplier> Supplier { get; set; }

        public DbSet<WebshopInCsharp.Models.ProductSearchResultModel> ProductSearchResultModel { get; set; }
    }
}
