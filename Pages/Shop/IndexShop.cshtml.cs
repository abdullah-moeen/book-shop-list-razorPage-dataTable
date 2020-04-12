using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Data;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor
{
    public class IndexShopModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexShopModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Shop> Shop { get; set; }

        public async Task OnGet()
        {
            Shop = await _context.Shops.ToListAsync();
        }

    }
}