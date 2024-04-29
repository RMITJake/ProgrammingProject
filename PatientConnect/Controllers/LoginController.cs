using Microsoft.AspNetCore.Mvc;
using PatientConnect.Data;
using PatientConnect.Models;
<<<<<<< HEAD
using SimpleHashing.Net;

=======
using PatientConnect.ViewModels;
using SimpleHashing.Net;
using Microsoft.EntityFrameworkCore;
>>>>>>> main

namespace PatientConnect.Controllers;

// Bonus Material: Implement global authorisation check.
//[AllowAnonymous]
[Route("/SecureLogin")]
public class LoginController : Controller
{
<<<<<<< HEAD
    private static readonly ISimpleHash s_simpleHash = new SimpleHash();
=======
    private static readonly ISimpleHash _simpleHash = new SimpleHash();
>>>>>>> main

    private readonly PatientConnectContext _context;

    public LoginController(PatientConnectContext context) => _context = context;

<<<<<<< HEAD
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
        HttpContext.Session.SetString(nameof(Models.User.FirstName), login.User.FirstName);

        Console.WriteLine("Login Success!");

        return RedirectToAction("Index", "Connect");
=======
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
>>>>>>> main
    }

    [Route("LogoutNow")]
    public IActionResult Logout()
    {
        // Logout customer.
        HttpContext.Session.Clear();

        return RedirectToAction("Index", "Home");
    }
}
