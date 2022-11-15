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
    public class StatusController : Controller
    {
        private readonly GarmentStopDbContext _context;

        public StatusController(GarmentStopDbContext context)
        {
            _context = context;
        }

        // GET: Status
        public async Task<IActionResult> Index()
        {
              return View(await _context.StatusTables.ToListAsync());
        }

        // GET: Status/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StatusTables == null)
            {
                return NotFound();
            }

            var statusTable = await _context.StatusTables
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (statusTable == null)
            {
                return NotFound();
            }

            return View(statusTable);
        }

        // GET: Status/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusId,StatusTitle")] StatusTable statusTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusTable);
        }

        // GET: Status/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StatusTables == null)
            {
                return NotFound();
            }

            var statusTable = await _context.StatusTables.FindAsync(id);
            if (statusTable == null)
            {
                return NotFound();
            }
            return View(statusTable);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusId,StatusTitle")] StatusTable statusTable)
        {
            if (id != statusTable.StatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusTableExists(statusTable.StatusId))
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
            return View(statusTable);
        }

        // GET: Status/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StatusTables == null)
            {
                return NotFound();
            }

            var statusTable = await _context.StatusTables
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (statusTable == null)
            {
                return NotFound();
            }

            return View(statusTable);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StatusTables == null)
            {
                return Problem("Entity set 'GarmentStopDbContext.StatusTables'  is null.");
            }
            var statusTable = await _context.StatusTables.FindAsync(id);
            if (statusTable != null)
            {
                _context.StatusTables.Remove(statusTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusTableExists(int id)
        {
          return _context.StatusTables.Any(e => e.StatusId == id);
        }
    }
}
