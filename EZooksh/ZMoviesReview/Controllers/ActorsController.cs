using Microsoft.AspNetCore.Mvc;
using ZMoviesReview.Data;

namespace ZMoviesReview.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;

        public ActorsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // Injection Of Actors data
            var data  = _context.Actors.ToList();

            return View(data);
        }
    }
}
