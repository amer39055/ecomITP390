﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ecomITP390.Models;

namespace ecomITP390.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ecomDBContext _context;

        public OrdersController(ecomDBContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var ecomDBContext = _context.Order.Include(o => o.Service).Include(o => o.Shippment).Include(o => o.User);
            return View(await ecomDBContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Service)
                .Include(o => o.Shippment)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Desc");
            ViewData["ShippmentId"] = new SelectList(_context.Shipment, "ShipmentId", "ShipmentId");
            ViewData["UserId"] = new SelectList(_context.UserInfo, "NatId", "Address");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,UserId,ServiceId,ShippmentId,Quantity,OrderStatus,StartDate,FinishDate,CloseCode,RatePoint")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Desc", order.ServiceId);
            ViewData["ShippmentId"] = new SelectList(_context.Shipment, "ShipmentId", "ShipmentId", order.ShippmentId);
            ViewData["UserId"] = new SelectList(_context.UserInfo, "NatId", "Address", order.UserId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Desc", order.ServiceId);
            ViewData["ShippmentId"] = new SelectList(_context.Shipment, "ShipmentId", "ShipmentId", order.ShippmentId);
            ViewData["UserId"] = new SelectList(_context.UserInfo, "NatId", "Address", order.UserId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,UserId,ServiceId,ShippmentId,Quantity,OrderStatus,StartDate,FinishDate,CloseCode,RatePoint")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "Desc", order.ServiceId);
            ViewData["ShippmentId"] = new SelectList(_context.Shipment, "ShipmentId", "ShipmentId", order.ShippmentId);
            ViewData["UserId"] = new SelectList(_context.UserInfo, "NatId", "Address", order.UserId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Service)
                .Include(o => o.Shippment)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }
    }
}
