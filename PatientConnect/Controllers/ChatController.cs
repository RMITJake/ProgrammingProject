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

    public async Task<IActionResult> NewConnection(int doctorId)
    {
        User currentUser = _context.Users.Where(u => u.UserID == HttpContext.Session.GetInt32("UserID")).FirstOrDefault();
        User doctor = _context.Users.Where(u => u.UserID == doctorId).FirstOrDefault();

        string roomName = $"Dr {doctor.FirstName} {doctor.LastName}, {currentUser.FirstName} {currentUser.LastName}";

        _context.Connections.AddRange(
            new Connection
            {
                UserId = currentUser.UserID.ToString(),
                Room = roomName
            },
            new Connection
            {
                UserId = doctor.UserID.ToString(),
                Room = roomName
            }
        );
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}