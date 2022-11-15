using GarmentShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarmentShopAPI.Controllers
{
    public class AdminController : Controller
    {
        private GarmentStopDbContext _dbContext;
        public AdminController(GarmentStopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region UserType
        
        public IActionResult UserTypeList()
        {
            IEnumerable<UserTypeTable> userTypesList = _dbContext.UserTypeTables.ToList();
            return View(userTypesList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserTypeTable userType)
        {
            _dbContext.Add(userType);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(UserTypeList));
        }
        [HttpGet]
        public IActionResult AddOrUpdate(int id=0)
        {
            if (id==0)
            {
                return View(new UserTypeTable());
            }
            else
            {
                return View(_dbContext.UserTypeTables.Find(id));
            }
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(UserTypeTable userType)
        {

            if (ModelState.IsValid)
            {
                if (userType.UserTypeId == 0)
                {
                    _dbContext.Add(userType);
                }
                else
                {
                    _dbContext.Update(userType);
                }
                _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(UserTypeList));
            }
            else
            {
                return View();
            }
            
        }

        #endregion
    }
}
