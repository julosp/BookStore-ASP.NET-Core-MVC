using BookStoreRazor_Temp.Data;
using BookStoreRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        public List<Category> CategoryList { get; set; }
        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
