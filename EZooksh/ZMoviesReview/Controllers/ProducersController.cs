using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZMoviesReview.Data;

namespace ZMoviesReview.Controllers
{
    public class ProducersConroller : Controller
    {
        private readonly AppDbContext _context;

        public ProducersConroller(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // Injection Of Producers data
            var allProducers = await _context.Producers.ToListAsync();

            return View();
        }
    }
}
