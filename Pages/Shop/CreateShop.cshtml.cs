using BookListRazor.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookListRazor.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookListRazor
{
    public class ShopModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ShopModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Shop Shops { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _context.Shops.AddAsync(Shops);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

    }
}