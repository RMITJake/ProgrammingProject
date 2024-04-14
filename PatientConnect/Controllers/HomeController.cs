using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PatientConnect.Data;
using PatientConnect.Models;
using PatientConnect.ViewModels;

namespace PatientConnect.Controllers;

// Bonus Material: Implement global authorisation check.
//[AllowAnonymous]
public class HomeController : Controller
{

    private readonly PatientConnectContext _context;

    public HomeController(PatientConnectContext context) => _context = context;

    public IActionResult Index()
    {
        // Get the list of available doctors from your data source
        List<User> availableDoctors = _context.Users.Where(u => u.UserType == UserType.Doctor && u.IsAvailable == true).ToList();

        // Create an instance of HomeViewModel and set the AvailableDoctors property
        var viewModel = new HomeViewModel
        {
            AvailableDoctors = availableDoctors
        };

        // Pass the viewModel object to the view
        return View(viewModel);
    }

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
