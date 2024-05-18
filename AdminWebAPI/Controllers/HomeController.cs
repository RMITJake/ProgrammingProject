using AdminWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdminWebAPI.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View(); // admin home page

    public IActionResult Contact() => View(); // contact us page

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}