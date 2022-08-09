using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreRazorPage.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoreRazorPage.Pages.BookList
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Book> Books { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var bookFromDb = await _db.Books.FindAsync(id);
            if (bookFromDb == null)
            {
                return NotFound();
            }
            _db.Books.Remove(bookFromDb);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}
