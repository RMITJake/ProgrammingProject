using Microsoft.AspNetCore.Mvc;
using PatientConnect.Models;
using System.Diagnostics;

namespace PatientConnect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) => _logger = logger;

        // Home page
        public IActionResult Index() => View();


        // About us page
        public IActionResult AboutUs() => View();

        // How it works page
        public IActionResult HowItWorks() => View();

        // Contact page
        public IActionResult Contact() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
