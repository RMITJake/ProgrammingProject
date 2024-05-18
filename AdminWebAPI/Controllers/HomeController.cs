using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdminWebAPI.Data;
using AdminWebAPI.Models;

namespace AdminWebAPI.Controllers;

// Bonus Material: Implement global authorisation check.
//[AllowAnonymous]
public class HomeController : Controller
{

    private readonly PatientConnectContext _context;

    public HomeController(PatientConnectContext context) => _context = context;

    [Route("/home")]
    public IActionResult Index() => View();

    [Route("/contact")]
    public IActionResult Contact() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
