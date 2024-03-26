using Microsoft.AspNetCore.Mvc;

namespace PatientConnect.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
