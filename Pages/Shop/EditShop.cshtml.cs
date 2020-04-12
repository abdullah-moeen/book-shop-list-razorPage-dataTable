using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Data;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor
{
    public class EditShopModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditShopModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shop Shops { get; set; }

        public async Task OnGet(int id)
        {
            Shops = await _context.Shops.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await _context.Shops.FindAsync(Shops.ID);
                result.ShopName = Shops.ShopName;
                result.Owner = Shops.Owner;
                result.ISBN = Shops.ISBN;
                await _context.SaveChangesAsync();

                return RedirectToPage("IndexShop");
            }
            else
            {
                return Page();
            }
        }
    }
}