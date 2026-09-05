using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Context;

namespace PersonalWebsite.Controllers
{
    public class ProjelerController : Controller
    {
        private readonly AppDbContext _context;

        public ProjelerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var projeler = _context.Proje.ToList();
            return View(projeler);
        }
    }
}