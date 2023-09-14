using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZMoviesReview.Data;

namespace ZMoviesReview.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext _context;

        public CinemasController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // Injection Of Cinemas data
            var allCinemas = await _context.Cinemas.ToListAsync();

            return View();
        }
    }
}
