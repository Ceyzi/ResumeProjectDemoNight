using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;
using System.Linq;

namespace ResumeProjectDemoNight.Controllers
{
    public class EducationController : Controller
    {
        private readonly ResumeContext _context;

        public EducationController(ResumeContext context)
        {
            _context = context;
        }

        // Eğitim Listesi - Sayfa yüklendiğinde verileri getirir
        [HttpGet]
        public IActionResult Index()
        {
            var values = _context.Educations.ToList();
            return View(values);
        }

        // Yeni Eğitim Ekleme Sayfası (Görüntüleme)
        [HttpGet]
        public IActionResult AddEducation()
        {
            return View();
        }

        // Yeni Eğitim Kaydetme İşlemi
        [HttpPost]
        public IActionResult AddEducation(Education education)
        {
            _context.Educations.Add(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}