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
    public class DisputesController : Controller
    {
        private readonly ecomDBContext _context;

        public DisputesController(ecomDBContext context)
        {
            _context = context;
        }

        // GET: Disputes
        public async Task<IActionResult> Index()
        {
            var ecomDBContext = _context.Dispute.Include(d => d.Arbiter).Include(d => d.Oreder);
            return View(await ecomDBContext.ToListAsync());
        }

        // GET: Disputes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispute = await _context.Dispute
                .Include(d => d.Arbiter)
                .Include(d => d.Oreder)
                .FirstOrDefaultAsync(m => m.Disputid == id);
            if (dispute == null)
            {
                return NotFound();
            }

            return View(dispute);
        }

        // GET: Disputes/Create
        public IActionResult Create()
        {
            ViewData["ArbiterId"] = new SelectList(_context.Employee, "EmpId", "Institute");
            ViewData["OrederId"] = new SelectList(_context.Order, "OrderId", "OrderId");
            return View();
        }

        // POST: Disputes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Disputid,OrederId,ArbiterId,Result,StartDate,FinishDate,Status,TimeToFinish")] Dispute dispute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dispute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArbiterId"] = new SelectList(_context.Employee, "EmpId", "Institute", dispute.ArbiterId);
            ViewData["OrederId"] = new SelectList(_context.Order, "OrderId", "OrderId", dispute.OrederId);
            return View(dispute);
        }

        // GET: Disputes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispute = await _context.Dispute.FindAsync(id);
            if (dispute == null)
            {
                return NotFound();
            }
            ViewData["ArbiterId"] = new SelectList(_context.Employee, "EmpId", "Institute", dispute.ArbiterId);
            ViewData["OrederId"] = new SelectList(_context.Order, "OrderId", "OrderId", dispute.OrederId);
            return View(dispute);
        }

        // POST: Disputes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Disputid,OrederId,ArbiterId,Result,StartDate,FinishDate,Status,TimeToFinish")] Dispute dispute)
        {
            if (id != dispute.Disputid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dispute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisputeExists(dispute.Disputid))
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
            ViewData["ArbiterId"] = new SelectList(_context.Employee, "EmpId", "Institute", dispute.ArbiterId);
            ViewData["OrederId"] = new SelectList(_context.Order, "OrderId", "OrderId", dispute.OrederId);
            return View(dispute);
        }

        // GET: Disputes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispute = await _context.Dispute
                .Include(d => d.Arbiter)
                .Include(d => d.Oreder)
                .FirstOrDefaultAsync(m => m.Disputid == id);
            if (dispute == null)
            {
                return NotFound();
            }

            return View(dispute);
        }

        // POST: Disputes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dispute = await _context.Dispute.FindAsync(id);
            _context.Dispute.Remove(dispute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisputeExists(int id)
        {
            return _context.Dispute.Any(e => e.Disputid == id);
        }
    }
}
