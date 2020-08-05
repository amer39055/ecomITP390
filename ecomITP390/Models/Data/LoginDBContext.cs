using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomITP390.Models.Data
{
    public class LoginDBContext : DbContext
    {
        public LoginDBContext(DbContextOptions<LoginDBContext> options) : base(options)
        {

        }
        public DbSet<Login> Logins{get;set;}
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AuthorityLevel> Authorities{ get; set; }


    }
}
