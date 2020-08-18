using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ecomITP390.Models;

namespace ecomITP390.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AppUser class
    public class AppUser : IdentityUser
    {
        ecomDBContext _context = new ecomDBContext();
        UserInfo user = new UserInfo();
        

    }
}
