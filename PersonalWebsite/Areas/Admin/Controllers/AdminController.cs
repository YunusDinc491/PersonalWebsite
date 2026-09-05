using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Areas.Admin.Filters;
using PersonalWebsite.Context;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminYetkiFilter]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.ProjeSayisi = _context.Proje.Count();
            ViewBag.MesajSayisi = _context.Iletisim.Count();
            ViewBag.CvVarMi = _context.BeniIseAl.Any();
            return View();
        }
    }
}