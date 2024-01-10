using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if(obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The display order cannot exactly match the name");
            //}
            //if (obj.Name.ToLower() == "test")
            //{
            //    ModelState.AddModelError("", "Test is an invalid value");
            //}
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }
    }
}

