using Microsoft.AspNetCore.Mvc;
namespace PatientConnect.Controllers;

public class ChatController : Controller
{
    public IActionResult Index(){ return View("ActiveChat"); }
}