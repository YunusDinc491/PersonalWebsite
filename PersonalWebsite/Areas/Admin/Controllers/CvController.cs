using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Areas.Admin.Filters;
using PersonalWebsite.Context;
using PersonalWebsite.Models;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminYetkiFilter]
    public class CvController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CvController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var cv = _context.BeniIseAl.FirstOrDefault();
            return View(cv);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile cvFile)
        {
            if (cvFile != null && cvFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", "cv");
                Directory.CreateDirectory(uploadsFolder);
                var fileName = "cv" + Path.GetExtension(cvFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await cvFile.CopyToAsync(stream);
                }

                var cvPath = "/uploads/cv/" + fileName;
                var existing = _context.BeniIseAl.FirstOrDefault();
                if (existing != null)
                {
                    existing.Cv = cvPath;
                }
                else
                {
                    _context.BeniIseAl.Add(new BeniIseAl { Cv = cvPath });
                }
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}