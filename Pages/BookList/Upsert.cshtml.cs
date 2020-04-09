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
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public UpsertModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Books Books { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Books = new Books();
            if (id == null)
            {
                //create
                return Page();
            }

            //update
            Books = await _context.Books.FindAsync(id);
            if (Books == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Books.ID == 0)
                {
                    _context.Books.Add(Books);
                }
                else
                {
                    _context.Books.Update(Books);
                }
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