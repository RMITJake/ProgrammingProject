using Microsoft.AspNetCore.Mvc;
using PatientConnect.Data;
using PatientConnect.Models;
namespace PatientConnect.Controllers;

public class ChatController : Controller
{
    private readonly PatientConnectContext _context;

    public ChatController(PatientConnectContext context) => _context = context;

    public async Task<IActionResult> Index()
    {
        ViewData["CurrentUser"] = HttpContext.Session.GetString("Name");
        List<Connection> rooms = _context.Connections.Where(u => u.UserId == HttpContext.Session.GetInt32("UserID").ToString()).ToList();
        ViewData["Rooms"] = rooms;
        return View();
    }
}