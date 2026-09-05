using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Context;
using PersonalWebsite.Models;

namespace PersonalWebsite.Controllers
{
    public class BeniIseAlController : Controller
    {
        private readonly AppDbContext _context;

        public BeniIseAlController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cv = _context.BeniIseAl.FirstOrDefault();
            return View(cv);
        }

        [HttpPost]
        public IActionResult Gonder(Iletisim model)
        {
            if (ModelState.IsValid)
            {
                _context.Iletisim.Add(model);
                _context.SaveChanges();
                TempData["Basarili"] = "Mesajınız başarıyla gönderildi.";
                return RedirectToAction("Index");
            }

            return View("Index", _context.BeniIseAl.FirstOrDefault());
        }
    }
}