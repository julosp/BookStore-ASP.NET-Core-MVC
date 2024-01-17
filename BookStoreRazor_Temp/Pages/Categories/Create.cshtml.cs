using BookStoreRazor_Temp.Data;
using BookStoreRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;
        
        public Category Category { get; set; }
        public CreateModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()  
        { 
            _db.Categories.Add(Category);
            _db.SaveChanges();
            return RedirectToPage("index");
        }
    }
}
