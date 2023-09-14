using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            // Injection Of Producers data
            var data = _context.Producers.ToList();

            return View();
        }
    }
}
