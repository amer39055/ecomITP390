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
    public class EmployeesController : Controller
    {
        private readonly ecomDBContext _context;

        public EmployeesController(ecomDBContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var ecomDBContext = _context.Employee.Include(e => e.AuthorityLevelNavigation).Include(e => e.SupervisedByNavigation).Include(e => e.User);
            return View(await ecomDBContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.AuthorityLevelNavigation)
                .Include(e => e.SupervisedByNavigation)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["AuthorityLevel"] = new SelectList(_context.AuthorityLevel, "Id", "Title");
            ViewData["SupervisedBy"] = new SelectList(_context.Employee, "EmpId", "Institute");
            ViewData["UserId"] = new SelectList(_context.UserInfo, "NatId", "Email");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,UserId,SocialInsuranceId,Qualfication,Institute,AuthorityLevel,SupervisedBy")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorityLevel"] = new SelectList(_context.AuthorityLevel, "Id", "Title", employee.AuthorityLevel);
            ViewData["SupervisedBy"] = new SelectList(_context.Employee, "EmpId", "Institute", employee.SupervisedBy);
            ViewData["UserId"] = new SelectList(_context.UserInfo, "NatId", "Email", employee.UserId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["AuthorityLevel"] = new SelectList(_context.AuthorityLevel, "Id", "Title", employee.AuthorityLevel);
            ViewData["SupervisedBy"] = new SelectList(_context.Employee, "EmpId", "Institute", employee.SupervisedBy);
            ViewData["UserId"] = new SelectList(_context.UserInfo, "NatId", "Email", employee.UserId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpId,UserId,SocialInsuranceId,Qualfication,Institute,AuthorityLevel,SupervisedBy")] Employee employee)
        {
            if (id != employee.EmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmpId))
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
            ViewData["AuthorityLevel"] = new SelectList(_context.AuthorityLevel, "Id", "Title", employee.AuthorityLevel);
            ViewData["SupervisedBy"] = new SelectList(_context.Employee, "EmpId", "Institute", employee.SupervisedBy);
            ViewData["UserId"] = new SelectList(_context.UserInfo, "NatId", "Email", employee.UserId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.AuthorityLevelNavigation)
                .Include(e => e.SupervisedByNavigation)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmpId == id);
        }
    }
}
