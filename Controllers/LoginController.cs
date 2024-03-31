using Microsoft.AspNetCore.Mvc;
using PatientConnect.Data;
using PatientConnect.Models;
using SimpleHashing.Net;

namespace McbaExample.Controllers;

public class LoginController : Controller
{
    private static readonly ISimpleHash s_simpleHash = new SimpleHash();

    private readonly PatientConnectContext _context;

    public LoginController(PatientConnectContext context) => _context = context;

    public IActionResult Index() => View(); // login page

    [HttpPost]
    [Route("SecureLogin")]
    public async Task<IActionResult> Login(string email, string password)
    {
        // look up login ID in the database
        var login = await _context.Logins.FindAsync(email);

        // if login details incorrect or not found - show error
        if (login == null || string.IsNullOrEmpty(password) || !s_simpleHash.Verify(password, login.PasswordHash))
        {
            ModelState.AddModelError("LoginFailed", "Login failed, please try again.");
            return View(new Login { Email = email });
        }

        Console.WriteLine("Login Success!");
        // success - complete login
        HttpContext.Session.SetInt32(nameof(Patient.UserID), login.UserID);
        HttpContext.Session.SetString(nameof(Patient.Firstname), login.User.Firstname);

        return RedirectToAction("Index", "Connect");
    }

    public IActionResult Register() => View(); // Register page

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register(string email, string password)
    {
        // look up login ID in the database
        var login = await _context.Logins.FindAsync(email);

        // if login details incorrect or not found - show error
        if (login == null || string.IsNullOrEmpty(password) || !s_simpleHash.Verify(password, login.PasswordHash))
        {
            ModelState.AddModelError("LoginFailed", "Login failed, please try again.");
            return View(new Login { Email = email });
        }

        // success - complete login
        HttpContext.Session.SetInt32(nameof(Patient.UserID), login.UserID);
        HttpContext.Session.SetString(nameof(Patient.Firstname), login.User.Firstname);

        return RedirectToAction("Index", "Login");
    }

    [Route("LogoutNow")]
    public IActionResult Logout()
    {
        // Logout - clear sessions (customer id)
        HttpContext.Session.Clear();

        return RedirectToAction("Index", "Home");
    }
}