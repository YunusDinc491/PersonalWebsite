using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Areas.Admin.Filters;
using PersonalWebsite.Context;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminYetkiFilter]
    public class MesajlarController : Controller
    {
        private readonly AppDbContext _context;

        public MesajlarController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var mesajlar = _context.Iletisim.OrderByDescending(m => m.Id).ToList();
            return View(mesajlar);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var mesaj = _context.Iletisim.Find(id);
            if (mesaj != null)
            {
                _context.Iletisim.Remove(mesaj);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}