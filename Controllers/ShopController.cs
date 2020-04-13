using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookListRazor.Controllers
{
    [Route("api/shop")]
    [ApiController]
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _context.Shops.ToList() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Shops.FindAsync(id);
            if (result == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _context.Shops.Remove(result);
            await _context.SaveChangesAsync();
            return Json(new { success = true, error = "Deleted Successfully" });
        }
    }
}