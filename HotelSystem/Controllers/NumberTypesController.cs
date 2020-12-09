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
    public class NumberTypesController : Controller
    {
        private readonly HotelSystemContext _context;

        public NumberTypesController(HotelSystemContext context)
        {
            _context = context;
        }

        // GET: NumberTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.NumberTypes.ToListAsync());
        }

        // GET: NumberTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberType = await _context.NumberTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (numberType == null)
            {
                return NotFound();
            }

            return View(numberType);
        }

        // GET: NumberTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NumberTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] NumberType numberType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(numberType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(numberType);
        }

        // GET: NumberTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberType = await _context.NumberTypes.FindAsync(id);
            if (numberType == null)
            {
                return NotFound();
            }
            return View(numberType);
        }

        // POST: NumberTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] NumberType numberType)
        {
            if (id != numberType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(numberType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumberTypeExists(numberType.Id))
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
            return View(numberType);
        }

        // GET: NumberTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberType = await _context.NumberTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (numberType == null)
            {
                return NotFound();
            }

            return View(numberType);
        }

        // POST: NumberTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var numberType = await _context.NumberTypes.FindAsync(id);
            _context.NumberTypes.Remove(numberType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NumberTypeExists(int id)
        {
            return _context.NumberTypes.Any(e => e.Id == id);
        }
    }
}
