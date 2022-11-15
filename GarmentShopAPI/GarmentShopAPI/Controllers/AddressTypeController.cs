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
    public class AddressTypeController : Controller
    {
        private readonly GarmentStopDbContext _context;

        public AddressTypeController(GarmentStopDbContext context)
        {
            _context = context;
        }

        // GET: AddressType
        public async Task<IActionResult> Index()
        {
              return View(await _context.AddressTypeTables.ToListAsync());
        }

       

        // GET: AddressType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddressType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressTypeId,AddressType")] AddressTypeTable addressTypeTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addressTypeTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addressTypeTable);
        }

        // GET: AddressType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AddressTypeTables == null)
            {
                return NotFound();
            }

            var addressTypeTable = await _context.AddressTypeTables.FindAsync(id);
            if (addressTypeTable == null)
            {
                return NotFound();
            }
            return View(addressTypeTable);
        }

        // POST: AddressType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressTypeId,AddressType")] AddressTypeTable addressTypeTable)
        {
            if (id != addressTypeTable.AddressTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addressTypeTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressTypeTableExists(addressTypeTable.AddressTypeId))
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
            return View(addressTypeTable);
        }

        // GET: AddressType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AddressTypeTables == null)
            {
                return NotFound();
            }

            var addressTypeTable = await _context.AddressTypeTables
                .FirstOrDefaultAsync(m => m.AddressTypeId == id);
            if (addressTypeTable == null)
            {
                return NotFound();
            }

            return View(addressTypeTable);
        }

        // POST: AddressType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AddressTypeTables == null)
            {
                return Problem("Entity set 'GarmentStopDbContext.AddressTypeTables'  is null.");
            }
            var addressTypeTable = await _context.AddressTypeTables.FindAsync(id);
            if (addressTypeTable != null)
            {
                _context.AddressTypeTables.Remove(addressTypeTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressTypeTableExists(int id)
        {
          return _context.AddressTypeTables.Any(e => e.AddressTypeId == id);
        }
    }
}
