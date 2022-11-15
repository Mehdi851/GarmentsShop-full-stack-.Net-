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
    public class UserStatusController : Controller
    {
        private readonly GarmentStopDbContext _context;

        public UserStatusController(GarmentStopDbContext context)
        {
            _context = context;
        }

        // GET: UserStatus
        public async Task<IActionResult> Index()
        {
              return View(await _context.UserStatuses.ToListAsync());
        }

      
        // GET: UserStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusId,StatusTitle")] UserStatus userStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userStatus);
        }

        // GET: UserStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserStatuses == null)
            {
                return NotFound();
            }

            var userStatus = await _context.UserStatuses.FindAsync(id);
            if (userStatus == null)
            {
                return NotFound();
            }
            return View(userStatus);
        }

        // POST: UserStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusId,StatusTitle")] UserStatus userStatus)
        {
            if (id != userStatus.StatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserStatusExists(userStatus.StatusId))
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
            return View(userStatus);
        }

        // GET: UserStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserStatuses == null)
            {
                return NotFound();
            }

            var userStatus = await _context.UserStatuses
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (userStatus == null)
            {
                return NotFound();
            }

            return View(userStatus);
        }

        // POST: UserStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserStatuses == null)
            {
                return Problem("Entity set 'GarmentStopDbContext.UserStatuses'  is null.");
            }
            var userStatus = await _context.UserStatuses.FindAsync(id);
            if (userStatus != null)
            {
                _context.UserStatuses.Remove(userStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserStatusExists(int id)
        {
          return _context.UserStatuses.Any(e => e.StatusId == id);
        }
    }
}
