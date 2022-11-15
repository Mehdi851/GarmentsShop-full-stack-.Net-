using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarmentShopAPI.Models;

namespace GarmentShopAPI.Controllers
{
    public class GenderController : Controller
    {
        private readonly GarmentStopDbContext _context;

        public GenderController(GarmentStopDbContext context)
        {
            _context = context;
        }

        // GET: Gender
        public async Task<IActionResult> Index()
        {
              return View(await _context.GenderTables.ToListAsync());
        }

       
        // GET: Gender/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gender/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenderId,GenderTitle")] GenderTable genderTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genderTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genderTable);
        }

        // GET: Gender/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GenderTables == null)
            {
                return NotFound();
            }

            var genderTable = await _context.GenderTables.FindAsync(id);
            if (genderTable == null)
            {
                return NotFound();
            }
            return View(genderTable);
        }

        // POST: Gender/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenderId,GenderTitle")] GenderTable genderTable)
        {
            if (id != genderTable.GenderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genderTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenderTableExists(genderTable.GenderId))
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
            return View(genderTable);
        }

        // GET: Gender/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GenderTables == null)
            {
                return NotFound();
            }

            var genderTable = await _context.GenderTables
                .FirstOrDefaultAsync(m => m.GenderId == id);
            if (genderTable == null)
            {
                return NotFound();
            }

            return View(genderTable);
        }

        // POST: Gender/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GenderTables == null)
            {
                return Problem("Entity set 'GarmentStopDbContext.GenderTables'  is null.");
            }
            var genderTable = await _context.GenderTables.FindAsync(id);
            if (genderTable != null)
            {
                _context.GenderTables.Remove(genderTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenderTableExists(int id)
        {
          return _context.GenderTables.Any(e => e.GenderId == id);
        }
    }
}
