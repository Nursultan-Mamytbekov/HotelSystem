using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelSystem;

namespace HotelSystem.Controllers
{
    public class TotalPricesController : Controller
    {
        private readonly HotelSystemContext _context;

        public TotalPricesController(HotelSystemContext context)
        {
            _context = context;
        }

        // GET: TotalPrices
        public async Task<IActionResult> Index()
        {
            var hotelSystemContext = _context.TotalPrices.Include(t => t.ClientNavigation);
            return View(await hotelSystemContext.ToListAsync());
        }

        // GET: TotalPrices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalPrice = await _context.TotalPrices
                .Include(t => t.ClientNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (totalPrice == null)
            {
                return NotFound();
            }

            return View(totalPrice);
        }

        // GET: TotalPrices/Create
        public IActionResult Create()
        {
            ViewData["Client"] = new SelectList(_context.Clients, "Id", "Name");
            return View();
        }

        // POST: TotalPrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Client,SumPrice")] TotalPrice totalPrice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(totalPrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Client"] = new SelectList(_context.Clients, "Id", "Name", totalPrice.Client);
            return View(totalPrice);
        }

        // GET: TotalPrices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalPrice = await _context.TotalPrices.FindAsync(id);
            if (totalPrice == null)
            {
                return NotFound();
            }
            ViewData["Client"] = new SelectList(_context.Clients, "Id", "Name", totalPrice.Client);
            return View(totalPrice);
        }

        // POST: TotalPrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Client,SumPrice")] TotalPrice totalPrice)
        {
            if (id != totalPrice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(totalPrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TotalPriceExists(totalPrice.Id))
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
            ViewData["Client"] = new SelectList(_context.Clients, "Id", "Name", totalPrice.Client);
            return View(totalPrice);
        }

        // GET: TotalPrices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalPrice = await _context.TotalPrices
                .Include(t => t.ClientNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (totalPrice == null)
            {
                return NotFound();
            }

            return View(totalPrice);
        }

        // POST: TotalPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var totalPrice = await _context.TotalPrices.FindAsync(id);
            _context.TotalPrices.Remove(totalPrice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TotalPriceExists(int id)
        {
            return _context.TotalPrices.Any(e => e.Id == id);
        }
    }
}
