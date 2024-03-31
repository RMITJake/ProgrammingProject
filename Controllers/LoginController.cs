using Microsoft.AspNetCore.Mvc;

namespace PatientConnect.Controllers;

public class LoginController : Controller
{
    public IActionResult Index() => View();

    public IActionResult Register() => View();
}
