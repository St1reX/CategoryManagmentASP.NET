using CategoryManagmentASP.NET.Data;
using CategoryManagmentASP.NET.Models;
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

        //GET
        public IActionResult Index()
        {
            return View(_db.Categories.ToList());
        }



        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Category name can't match exactly display order");
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                TempData["success"] = "Category added successfully";
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var categoryToEdit = _db.Categories.Find(id);
            if(categoryToEdit == null)
            {
                return NotFound();
            }


            return View(categoryToEdit);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Category name can't match exactly display order");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                TempData["success"] = "Category updated successfully";
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryToDelete = _db.Categories.Find(id);
            if (categoryToDelete == null)
            {
                return NotFound();
            }


            return View(categoryToDelete);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var categoryToDelete = _db.Categories.Find(id);
            _db.Categories.Remove(categoryToDelete);
            TempData["success"] = "Category deleted successfully";
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
