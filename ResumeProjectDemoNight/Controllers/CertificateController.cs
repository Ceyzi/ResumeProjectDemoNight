using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class CertificateController : Controller
    {
        private readonly ResumeContext _context;

        public CertificateController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult CertificateList()
        {
            var values = _context.Certificates.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCertificate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCertificate(Certificate certificate)
        {
            _context.Certificates.Add(certificate);
            _context.SaveChanges();
            return RedirectToAction("CertificateList");
        }
    }
}