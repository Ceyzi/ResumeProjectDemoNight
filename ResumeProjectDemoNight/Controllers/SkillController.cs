using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;
using System.Linq;

namespace ResumeProjectDemoNight.Controllers
{
    public class SkillController : Controller
    {
        private readonly ResumeContext _context;

        public SkillController(ResumeContext context)
        {
            _context = context;
        }

        // Listeleme Sayfası
        public IActionResult Index()
        {
            var values = _context.Skills.ToList();
            return View(values);
        }

        // Yeni Ekleme Sayfası (GET)
        [HttpGet]
        public IActionResult AddSkill()
        {
            return View();
        }

        // Yeni Ekleme İşlemi (POST)
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}