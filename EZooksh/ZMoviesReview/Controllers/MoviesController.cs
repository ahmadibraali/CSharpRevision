using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZMoviesReview.Data;

namespace ZMoviesReview.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // Injection Of Movies data
            var allMovies = await _context.Movies.ToListAsync();
            return View();
        }
    }
}
