using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    // public IActionResult Index() => View();
    public IActionResult Index()
    {
        var doctors = _context.Users.Where(x => x.UserType == UserType.Doctor).Take(6).ToList();
        ViewBag.Doctors = doctors;

        return View();
    }

    public PartialViewResult ChatCards(){
        var doctors = _context.Users.FirstOrDefault();
        return PartialView(doctors);
    }

    [Route("/aboutus")]
    public IActionResult AboutUs() => View();

    [Route("/howitworks")]
    public IActionResult HowItWorks() => View();

    [Route("/contact")]
    public IActionResult Contact() => View();

    [Route("/internalmedicine")]
    public IActionResult Specialty() => View();

    [Route("/doctors/{specialty?}")]
    public IActionResult Doctors(string? specialty){
        int index = 0;
        foreach(int i in Enum.GetValues(typeof(SpecialisationType))){
            if(string.Equals(Enum.GetName(typeof(SpecialisationType), i), specialty, StringComparison.OrdinalIgnoreCase)){
                index = i;
            }
        }
        var doctors = _context.Users.Where(d => d.Specialisation == (SpecialisationType)index).OrderByDescending(d => d.Rating).ToList();
        ViewBag.Doctors = doctors;
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
