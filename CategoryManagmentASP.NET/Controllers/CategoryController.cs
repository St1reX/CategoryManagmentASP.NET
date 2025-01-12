using CategoryManagmentASP.NET.Data;
using Microsoft.AspNetCore.Mvc;

namespace CategoryManagmentASP.NET.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Categories.ToList());
        }
    }
}
