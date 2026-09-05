using Microsoft.AspNetCore.Mvc;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GirisController : Controller
    {
        private const string DogruSifre = "12345";

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string sifre)
        {
            if (sifre == DogruSifre)
            {
                HttpContext.Session.SetString("AdminGiris", "1");
                return RedirectToAction("Index", "Admin");
            }

            ViewBag.Hata = "Şifre yanlış.";
            return View();
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Remove("AdminGiris");
            return RedirectToAction("Index");
        }
    }
}