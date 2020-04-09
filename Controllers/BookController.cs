using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookListRazor.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _context.Books.ToList() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _context.Books.FirstOrDefault(x => x.ID == id);
            if (result == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            _context.Books.Remove(result);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Deleting Successfyl" });
        }
    }
}