using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Areas.Admin.Filters;
using PersonalWebsite.Context;
using PersonalWebsite.Models;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminYetkiFilter]
    public class ProjeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProjeController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var projeler = _context.Proje.ToList();
            return View(projeler);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Proje model, IFormFile? projeFotoFile)
        {
            if (projeFotoFile != null && projeFotoFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", "projeler");
                Directory.CreateDirectory(uploadsFolder);
                var fileName = Guid.NewGuid() + Path.GetExtension(projeFotoFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await projeFotoFile.CopyToAsync(stream);
                }

                model.ProjeFoto = "/uploads/projeler/" + fileName;
            }

            _context.Proje.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var proje = _context.Proje.Find(id);
            if (proje != null)
            {
                _context.Proje.Remove(proje);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}