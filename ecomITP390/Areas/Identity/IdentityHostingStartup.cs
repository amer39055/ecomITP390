using System;
using ecomITP390.Areas.Identity.Data;
using ecomITP390.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ecomITP390.Areas.Identity.IdentityHostingStartup))]
namespace ecomITP390.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ecomITP390Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ecomITP390ContextConnection")));

                services.AddDefaultIdentity<AppUser>()
                    .AddEntityFrameworkStores<ecomITP390Context>();
            });
        }
    }
}