using Microsoft.AspNetCore.Mvc;
using PatientConnect.Data;
using PatientConnect.Models;
using SimpleHashing.Net;

namespace PatientConnect.Controllers;

[Route("/PatientConnect/SecureLogin")]
public class LoginController : Controller
{
    private static readonly ISimpleHash s_simpleHash = new SimpleHash();

    private readonly PatientConnectDbContext _context;

    public LoginController(PatientConnectDbContext context) => _context = context;

    public IActionResult Index() => View(); // login page

    [HttpPost]
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

        // success - complete login
        Console.WriteLine("Login Successful");

        return RedirectToAction("Index", "Connect");
    }

    [Route("LogoutNow")]
    public IActionResult Logout()
    {
        // Logout - clear sessions (customer id)
        HttpContext.Session.Clear();

        return RedirectToAction("Index", "Home");
    }
}
