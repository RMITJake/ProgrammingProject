using Microsoft.AspNetCore.Mvc;
using AdminWebAPI.Models;

namespace AdminWebAPI.Controllers;

public class LoginController : Controller
{
    [Route("/login")]
    public IActionResult Index() => View(); // login page

    [HttpPost]
    public async Task<IActionResult> Index(string loginID, string password)
    {
        // look for admin credentials
        if (!loginID.Equals("admin") || !password.Equals("admin"))
        {
            ModelState.AddModelError("LoginFailed", "Login failed, please try again.");
            return View(new Login { LoginID = loginID });
        }

        // Login admin
        HttpContext.Session.SetString("LoginID", "admin");
        HttpContext.Session.SetString("Name", "Admin");

        return RedirectToAction("Index", "Home");

    }

    public IActionResult Logout()
    {
        // Logout - clear sessions (user id)
        HttpContext.Session.Clear();

        return RedirectToAction("Index", "Home");
    }
}
