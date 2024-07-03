using Batech.Data;
using Batech.Models;
using Microsoft.AspNetCore.Mvc;

namespace Batech.Controllers
{
    public class FormController : Controller
    {
        private readonly FormContext _context;
        public FormController(FormContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Apply(Form form)
        {

            // Form verilerini işleyin
            ViewBag.Message = "Başvurunuz alındı. Teşekkür ederiz!";
            var forms = _context.Forms.ToList();
            ViewData["Forms"] = forms;

            _context.Forms.Add(form);
            _context.SaveChanges();
            return RedirectToAction("Apply");

        }
    }
}
