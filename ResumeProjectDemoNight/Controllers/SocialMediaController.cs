using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;
using System.Linq;

namespace ResumeProjectDemoNight.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ResumeContext _context;

        public SocialMediaController(ResumeContext context)
        {
            _context = context;
        }

        // LİSTELEME SAYFASI
        public IActionResult Index()
        {
            var values = _context.SocialMedias.ToList();
            return View(values);
        }

        // EKLEME SAYFASI (Formu Açar)
        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View(new SocialMedia());
        }


        // EKLEME İŞLEMİ (Veriyi Kaydeder)
        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                _context.SocialMedias.Add(socialMedia);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialMedia);
        }

        
    }
}