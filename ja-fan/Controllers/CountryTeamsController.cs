using ja_fan.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ja_fan.Controllers
{
    public class CountryTeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountryTeamsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null || _context.Country == null)
            {
                return NotFound();
            }
            
            var country = await _context.Country.Include(x=> x.Teams).ThenInclude(x => x.Nicknames)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (country?.Teams == null)
            {
                return NotFound();
            }

            return View(country);
        }
    }
}