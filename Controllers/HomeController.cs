using Batech.Data;
using Batech.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Batech.Controllers
{
    public class HomeController : Controller
    {
      
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // Anasayfa
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // Anasayfa
        

        // Hakkımızda
        public IActionResult About()
        {
            return View();
        }

        // Başvuru Ekranı
       

        // İletişim
        public IActionResult Contact()
        {
            return View();
        }
    }
}

