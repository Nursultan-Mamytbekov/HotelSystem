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
    public class NumbersController : Controller
    {
        private readonly HotelSystemContext _context;

        public NumbersController(HotelSystemContext context)
        {
            _context = context;
        }

        // GET: Numbers
        public async Task<IActionResult> Index()
        {
            var hotelSystemContext = _context.Numbers.Include(n => n.TypeNavigation);
            return View(await hotelSystemContext.ToListAsync());
        }

        // GET: Numbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var number = await _context.Numbers
                .Include(n => n.TypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (number == null)
            {
                return NotFound();
            }

            return View(number);
        }

        // GET: Numbers/Create
        public IActionResult Create()
        {
            ViewData["Type"] = new SelectList(_context.NumberTypes, "Id", "Name");
            return View();
        }

        // POST: Numbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Price")] Number number)
        {
            if (ModelState.IsValid)
            {
                _context.Add(number);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Type"] = new SelectList(_context.NumberTypes, "Id", "Name", number.Type);
            return View(number);
        }

        // GET: Numbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var number = await _context.Numbers.FindAsync(id);
            if (number == null)
            {
                return NotFound();
            }
            ViewData["Type"] = new SelectList(_context.NumberTypes, "Id", "Name", number.Type);
            return View(number);
        }

        // POST: Numbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Price")] Number number)
        {
            if (id != number.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(number);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumberExists(number.Id))
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
            ViewData["Type"] = new SelectList(_context.NumberTypes, "Id", "Name", number.Type);
            return View(number);
        }

        // GET: Numbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var number = await _context.Numbers
                .Include(n => n.TypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (number == null)
            {
                return NotFound();
            }

            return View(number);
        }

        // POST: Numbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var number = await _context.Numbers.FindAsync(id);
            _context.Numbers.Remove(number);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NumberExists(int id)
        {
            return _context.Numbers.Any(e => e.Id == id);
        }
    }
}
