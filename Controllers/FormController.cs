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

        [HttpGet]
        public IActionResult Apply()
        {
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Apply(Form form)
        {
            return NotFound();

            _context.Forms.Add(form);
            await _context.SaveChangesAsync();

            ViewBag.Message = "Başvurunuz alındı. Teşekkür ederiz!";
            return View();
        }
    }
}
