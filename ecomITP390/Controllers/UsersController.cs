using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ecomITP390.Models;

namespace ecomITP390.Controllers
{
    public class UsersController : Controller
    {
        private readonly ecomDBContext _context;

        public UsersController(ecomDBContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var ecomDBContext = _context.UserInfo.Include(u => u.Gov).Include(u => u.UserTypeNavigation);
            return View(await ecomDBContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfo
                .Include(u => u.Gov)
                .Include(u => u.UserTypeNavigation)
                .FirstOrDefaultAsync(m => m.NatId == id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return View(userInfo);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["GovId"] = new SelectList(_context.Governorate, "GovId", "GovId");
            ViewData["UserType"] = new SelectList(_context.UserType, "UserTypeId", "UserTypeId");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NatId,Fname,Fathername,Lname,BirthDate,UserType,Status,RatePoints,Phone,Email,GovId,City,Address,Homelocation,Gender")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GovId"] = new SelectList(_context.Governorate, "GovId", "GovId", userInfo.GovId);
            ViewData["UserType"] = new SelectList(_context.UserType, "UserTypeId", "UserTypeId", userInfo.UserType);
            return View(userInfo);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfo.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }
            ViewData["GovId"] = new SelectList(_context.Governorate, "GovId", "GovId", userInfo.GovId);
            ViewData["UserType"] = new SelectList(_context.UserType, "UserTypeId", "UserTypeId", userInfo.UserType);
            return View(userInfo);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NatId,Fname,Fathername,Lname,BirthDate,UserType,Status,RatePoints,Phone,Email,GovId,City,Address,Homelocation,Gender")] UserInfo userInfo)
        {
            if (id != userInfo.NatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInfoExists(userInfo.NatId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GovId"] = new SelectList(_context.Governorate, "GovId", "GovId", userInfo.GovId);
            ViewData["UserType"] = new SelectList(_context.UserType, "UserTypeId", "UserTypeId", userInfo.UserType);
            return View(userInfo);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfo
                .Include(u => u.Gov)
                .Include(u => u.UserTypeNavigation)
                .FirstOrDefaultAsync(m => m.NatId == id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return View(userInfo);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userInfo = await _context.UserInfo.FindAsync(id);
            _context.UserInfo.Remove(userInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserInfoExists(int id)
        {
            return _context.UserInfo.Any(e => e.NatId == id);
        }
    }
}
