using Microsoft.AspNetCore.Mvc;
using PatientConnect.Data;
using PatientConnect.Models;
using SimpleHashing.Net;


namespace PatientConnect.Controllers;

// Bonus Material: Implement global authorisation check.
//[AllowAnonymous]
[Route("/Mcba/Register")]
public class RegisterController : Controller
{
    private static readonly ISimpleHash s_simpleHash = new SimpleHash();

    private readonly PatientConnectContext _context;

    public RegisterController(PatientConnectContext context) => _context = context;

    public IActionResult Register() => View();
}
