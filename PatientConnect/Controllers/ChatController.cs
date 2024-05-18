using Microsoft.AspNetCore.Mvc;
namespace PatientConnect.Controllers;

public class ChatController : Controller
{
    public IActionResult Index()
    {
        ViewData["CurrentUser"] = HttpContext.Session.GetString("Name");
        return View();
    }
}