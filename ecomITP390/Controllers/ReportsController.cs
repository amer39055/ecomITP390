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
    public class ReportsController : Controller
    {
        private readonly ecomDBContext _context;

        public ReportsController(ecomDBContext context)
        {
            _context = context;
        }

        // GET: Reports
        public async Task<IActionResult> Index()
        {
            var ecomDBContext = _context.Report.Include(r => r.Emp).Include(r => r.TypeNavigation).Include(r => r.User);
            return View(await ecomDBContext.ToListAsync());
        }

        // GET: Reports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report
                .Include(r => r.Emp)
                .Include(r => r.TypeNavigation)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ReportId == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // GET: Reports/Create
        public IActionResult Create()
        {
            ViewData["EmpId"] = new SelectList(_context.Employee, "EmpId", "Institute");
            ViewData["Type"] = new SelectList(_context.ReportTypes, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.UserInfo, "NatId", "Address");
            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportId,UserId,Type,EmpId,Files")] Report report)
        {
            if (ModelState.IsValid)
            {
                _context.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpId"] = new SelectList(_context.Employee, "EmpId", "Institute", report.EmpId);
            ViewData["Type"] = new SelectList(_context.ReportTypes, "Id", "Id", report.Type);
            ViewData["UserId"] = new SelectList(_context.UserInfo, "NatId", "Address", report.UserId);
            return View(report);
        }

        // GET: Reports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            ViewData["EmpId"] = new SelectList(_context.Employee, "EmpId", "Institute", report.EmpId);
            ViewData["Type"] = new SelectList(_context.ReportTypes, "Id", "Id", report.Type);
            ViewData["UserId"] = new SelectList(_context.UserInfo, "NatId", "Address", report.UserId);
            return View(report);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReportId,UserId,Type,EmpId,Files")] Report report)
        {
            if (id != report.ReportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportExists(report.ReportId))
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
            ViewData["EmpId"] = new SelectList(_context.Employee, "EmpId", "Institute", report.EmpId);
            ViewData["Type"] = new SelectList(_context.ReportTypes, "Id", "Id", report.Type);
            ViewData["UserId"] = new SelectList(_context.UserInfo, "NatId", "Address", report.UserId);
            return View(report);
        }

        // GET: Reports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report
                .Include(r => r.Emp)
                .Include(r => r.TypeNavigation)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ReportId == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var report = await _context.Report.FindAsync(id);
            _context.Report.Remove(report);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportExists(int id)
        {
            return _context.Report.Any(e => e.ReportId == id);
        }
    }
}
