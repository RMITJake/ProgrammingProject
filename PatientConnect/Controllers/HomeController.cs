using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PatientConnect.Models;

namespace PatientConnect.Controllers;

// Bonus Material: Implement global authorisation check.
//[AllowAnonymous]
public class HomeController : Controller
{
    public IActionResult Index() => View();
    [Route("/alt")]
    public IActionResult Index2() => View();

    [Route("/aboutus")]
    public IActionResult AboutUs() => View();

    [Route("/howitworks")]
    public IActionResult HowItWorks() => View();

    [Route("/contact")]
    public IActionResult Contact() => View();

    [Route("/internalmedicine")]
    public IActionResult Specialty() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
