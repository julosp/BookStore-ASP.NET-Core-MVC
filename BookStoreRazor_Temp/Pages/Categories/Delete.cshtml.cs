using BookStoreRazor_Temp.Data;
using BookStoreRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _db;

        public Category Category { get; set; }
        public DeleteModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            
                Category? obj = _db.Categories.Find(Category.Id);
                if (obj == null)
                {
                    return NotFound();
                }
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToPage("index");
            
    
        }
    }
}
