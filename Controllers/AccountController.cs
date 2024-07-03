using Microsoft.AspNetCore.Mvc;

namespace Batech.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
