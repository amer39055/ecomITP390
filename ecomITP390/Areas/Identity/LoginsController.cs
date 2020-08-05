using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ecomITP390.Models;

namespace ecomITP390.Areas.Identity.Pages.Account
{
    public class LoginsController : Controller
    {
        private readonly LoginContext _context;
        public IActionResult Index()
        {
            return View();
        }
    }
}