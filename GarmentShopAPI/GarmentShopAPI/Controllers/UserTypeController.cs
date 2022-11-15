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
    public class UserTypeController : Controller
    {
        private readonly GarmentStopDbContext _context;

        public UserTypeController(GarmentStopDbContext context)
        {
            _context = context;
        }

        // GET: UserType
        public async Task<IActionResult> Index()
        {
              return View(await _context.UserTypeTables.ToListAsync());
        }

        

        // GET: UserType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserTypeId,UserType")] UserTypeTable userTypeTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTypeTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userTypeTable);
        }

        // GET: UserType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserTypeTables == null)
            {
                return NotFound();
            }

            var userTypeTable = await _context.UserTypeTables.FindAsync(id);
            if (userTypeTable == null)
            {
                return NotFound();
            }
            return View(userTypeTable);
        }

        // POST: UserType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserTypeId,UserType")] UserTypeTable userTypeTable)
        {
            if (id != userTypeTable.UserTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTypeTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTypeTableExists(userTypeTable.UserTypeId))
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
            return View(userTypeTable);
        }

        // GET: UserType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserTypeTables == null)
            {
                return NotFound();
            }

            var userTypeTable = await _context.UserTypeTables
                .FirstOrDefaultAsync(m => m.UserTypeId == id);
            if (userTypeTable == null)
            {
                return NotFound();
            }

            return View(userTypeTable);
        }

        // POST: UserType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserTypeTables == null)
            {
                return Problem("Entity set 'GarmentStopDbContext.UserTypeTables'  is null.");
            }
            var userTypeTable = await _context.UserTypeTables.FindAsync(id);
            if (userTypeTable != null)
            {
                _context.UserTypeTables.Remove(userTypeTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTypeTableExists(int id)
        {
          return _context.UserTypeTables.Any(e => e.UserTypeId == id);
        }
    }
}
