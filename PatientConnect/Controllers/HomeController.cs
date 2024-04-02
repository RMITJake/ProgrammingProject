using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PatientConnect.Models;

namespace PatientConnect.Controllers;

// Bonus Material: Implement global authorisation check.
//[AllowAnonymous]
public class HomeController : Controller
{
    public IActionResult Index() => View();

    public IActionResult AboutUs() => View();

    public IActionResult HowItWorks() => View();

    public IActionResult Contact() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
