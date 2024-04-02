using Microsoft.AspNetCore.Mvc;
using PatientConnect.Data;
using PatientConnect.Models;
using SimpleHashing.Net;


namespace PatientConnect.Controllers;

// Bonus Material: Implement global authorisation check.
//[AllowAnonymous]
[Route("/Mcba/SecureLogin")]
public class LoginController : Controller
{
    private static readonly ISimpleHash s_simpleHash = new SimpleHash();

    private readonly PatientConnectContext _context;

    public LoginController(PatientConnectContext context) => _context = context;

    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(string loginID, string password)
    {
        var login = await _context.Logins.FindAsync(loginID);
        if(login == null || string.IsNullOrEmpty(password) || !s_simpleHash.Verify(password, login.PasswordHash))
        { 
            ModelState.AddModelError("LoginFailed", "Login failed, please try again.");
            return View(new Login { LoginID = loginID });
        }

        // Login customer.
        HttpContext.Session.SetInt32(nameof(Models.User.UserID), login.UserID);
        HttpContext.Session.SetString(nameof(Models.User.Name), login.User.Name);

        Console.WriteLine("Login Success!");

        return RedirectToAction("Index", "Connect");
    }

    [Route("LogoutNow")]
    public IActionResult Logout()
    {
        // Logout customer.
        HttpContext.Session.Clear();

        return RedirectToAction("Index", "Home");
    }
}
