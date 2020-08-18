using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecomITP390.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ecomITP390.Models
{
    public class ecomITP390Context : IdentityDbContext<AppUser>
    {
        public ecomITP390Context(DbContextOptions<ecomITP390Context> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
