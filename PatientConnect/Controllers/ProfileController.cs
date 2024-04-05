using Microsoft.AspNetCore.Mvc;
using PatientConnect.Models;
using PatientConnect.Data;

namespace PatientConnect.Controllers
{
    public class ProfileController : Controller
    {
        private readonly PatientConnectContext _context;
        private int UserID => HttpContext.Session.GetInt32("UserID").Value;

        public ProfileController(PatientConnectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Users.FindAsync(UserID));
        }

        // public async Task<IActionResult> ChangePassword() {}
    }
}
