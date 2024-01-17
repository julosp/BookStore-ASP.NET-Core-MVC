using BookStoreRazor_Temp.Data;
using BookStoreRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;

        public Category Category { get; set; }
        public EditModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if(id !=null && id!= 0)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid) { 
                _db.Categories.Update(Category);
                _db.SaveChanges();
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}
