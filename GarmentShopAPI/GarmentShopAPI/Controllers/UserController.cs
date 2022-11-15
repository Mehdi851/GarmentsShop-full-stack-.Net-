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
    public class UserController : Controller
    {
        private readonly GarmentStopDbContext _context;

        public UserController(GarmentStopDbContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {

            var garmentStopDbContext = _context.UserTables.Include(u => u.Gender).Include(u => u.UserStatus).Include(u => u.UserType);
            return View(await garmentStopDbContext.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserTables == null)
            {
                return NotFound();
            }

            var userTable = await _context.UserTables
                .Include(u => u.Gender)
                .Include(u => u.UserStatus)
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userTable == null)
            {
                return NotFound();
            }

            return View(userTable);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            IEnumerable<GenderTable> GenderList= _context.GenderTables.ToList();
            IEnumerable<UserStatus> UserStatusList = _context.UserStatuses.ToList();
            IEnumerable<UserTypeTable> UserTypesList = _context.UserTypeTables.ToList();

            ViewBag.GenderList = GenderList;
            ViewBag.UserStatusList = UserStatusList;
            ViewBag.UserTypesList = UserTypesList;
            //ViewData["UserStatusList"] =_context.UserStatuses.ToList();
            //ViewData["UserTypeList"] = _context.UserTypeTables.ToList();
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserTypeId,Username,Password,EmailAddress,FirstName,LastName,ContactNo,GenderId,UserStatusId")] UserTable userTable)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(userTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["GenderId"] = new SelectList(_context.GenderTables, "GenderId", "GenderId", userTable.GenderId);
            //ViewData["UserStatusId"] = new SelectList(_context.UserStatuses, "StatusId", "StatusId", userTable.UserStatusId);
            //ViewData["UserTypeId"] = new SelectList(_context.UserTypeTables, "UserTypeId", "UserTypeId", userTable.UserTypeId);
            //return View(userTable);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserTables == null)
            {
                return NotFound();
            }

            var userTable = await _context.UserTables.FindAsync(id);
            if (userTable == null)
            {
                return NotFound();
            }
            IEnumerable<GenderTable> GenderList = _context.GenderTables.ToList();
            IEnumerable<UserStatus> UserStatusList = _context.UserStatuses.ToList();
            IEnumerable<UserTypeTable> UserTypesList = _context.UserTypeTables.ToList();

            ViewBag.GenderList = GenderList;
            ViewBag.UserStatusList = UserStatusList;
            ViewBag.UserTypesList = UserTypesList;
            return View(userTable);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserTypeId,Username,Password,EmailAddress,FirstName,LastName,ContactNo,GenderId,UserStatusId")] UserTable userTable)
        {
            if (id != userTable.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTableExists(userTable.UserId))
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
            ViewData["GenderId"] = new SelectList(_context.GenderTables, "GenderId", "GenderId", userTable.GenderId);
            ViewData["UserStatusId"] = new SelectList(_context.UserStatuses, "StatusId", "StatusId", userTable.UserStatusId);
            ViewData["UserTypeId"] = new SelectList(_context.UserTypeTables, "UserTypeId", "UserTypeId", userTable.UserTypeId);
            return View(userTable);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserTables == null)
            {
                return NotFound();
            }

            var userTable = await _context.UserTables
                .Include(u => u.Gender)
                .Include(u => u.UserStatus)
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userTable == null)
            {
                return NotFound();
            }

            return View(userTable);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserTables == null)
            {
                return Problem("Entity set 'GarmentStopDbContext.UserTables'  is null.");
            }
            var userTable = await _context.UserTables.FindAsync(id);
            if (userTable != null)
            {
                _context.UserTables.Remove(userTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTableExists(int id)
        {
          return _context.UserTables.Any(e => e.UserId == id);
        }
    }
}
