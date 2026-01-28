using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using System.Linq;

namespace ResumeProjectDemoNight.Controllers
{
    public class AboutController : Controller
    {
        private readonly ResumeContext _context;

        public AboutController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // 1. Üst Panel Sayaçları (Dinamik İstatistikler)
            ViewBag.ProjectCount = _context.Portfolios.Count();
            ViewBag.SkillCount = _context.Skills.Count();
            ViewBag.MessageCount = _context.Messages.Count();
            ViewBag.CertificateCount = _context.Certificates.Count();

            // 2. Sistem Durumu (Sağ Alt Panel)
            // Bu veriler dashboard üzerindeki "Sistem Durumu" tablosunu doldurur.
            ViewBag.EducationCount = _context.Educations.Count();
            ViewBag.ExperienceCount = _context.Experiences.Count();
            ViewBag.ServiceCount = _context.Services.Count();

            // 3. Son Mesajlar (Sol Alt Panel)
            // Veritabanındaki en son gelen 2 veya 3 mesajı listeler.
            ViewBag.LastMessages = _context.Messages
                .OrderByDescending(x => x.MessageId)
                .Take(2)
                .ToList();

            // 4. Hakkımda Bilgisi (Orta Panel)
            // Profil resmi, isim ve açıklama metnini getirir.
            var value = _context.Abouts.FirstOrDefault();

            return View(value);
        }
    }
}