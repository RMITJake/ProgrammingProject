using Microsoft.AspNetCore.Mvc;
using PatientConnect.Data;
using PatientConnect.Models;
using PatientConnect.ViewModels;
using SimpleHashing.Net;
using Microsoft.EntityFrameworkCore;

namespace PatientConnect.Controllers;

// Bonus Material: Implement global authorisation check.
//[AllowAnonymous]
[Route("/SecureLogin")]
public class LoginController : Controller
{
    private static readonly ISimpleHash _simpleHash = new SimpleHash();

    private readonly PatientConnectContext _context;

    public LoginController(PatientConnectContext context) => _context = context;

    // public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginVM)
    {
        Console.WriteLine("loginvm " + loginVM.Email + " " + loginVM.Password);
        var user = await _context.Users.Where(u => u.Email == loginVM.Email).FirstOrDefaultAsync();
        Console.WriteLine("computed hash " + _simpleHash.Compute(loginVM.Password));
        var login = await _context.Logins.Where(u => u.UserID == user.UserID).FirstOrDefaultAsync();
        Console.WriteLine("comparison hash " + login.PasswordHash);
        Console.WriteLine("comparison " + _simpleHash.Verify(loginVM.Password, login.PasswordHash));
        if (login == null || string.IsNullOrEmpty(loginVM.Password) || !_simpleHash.Verify(loginVM.Password, login.PasswordHash))
        {
            ModelState.AddModelError("LoginFailed", "Login failed, please try again.");
            return View();
        }

        HttpContext.Session.SetInt32("UserID", login.UserID);
        HttpContext.Session.SetString("Name", user.FirstName);

        // return RedirectToAction("Index", "Connect");
        return RedirectToAction("Index", "Home");
    }

    [Route("LogoutNow")]
    public IActionResult Logout()
    {
        // Logout customer.
        HttpContext.Session.Clear();

        return RedirectToAction("Index", "Home");
    }
}
