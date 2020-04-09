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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Books Books { get; set; }
        public async Task OnGet(int id)
        {
            Books = await _context.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await _context.Books.FindAsync(Books.ID);
                result.Name = Books.Name;
                result.Author = Books.Author;
                result.ISBN = Books.ISBN;
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