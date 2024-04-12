using Microsoft.AspNetCore.Mvc;
using PatientConnect.Filters;
using PatientConnect.Data;
using PatientConnect.Models;

namespace McbaExample.Controllers;

[AuthorizeUser]
public class ConnectController : Controller
{
    private readonly PatientConnectContext _context;

    // ReSharper disable once PossibleInvalidOperationException
    private int UserID => HttpContext.Session.GetInt32(nameof(UserID)).Value;

    public ConnectController(PatientConnectContext context) => _context = context;

    [Route("/connect")]
    public async Task<IActionResult> Index()
    {
        // Lazy loading.
        var customer = await _context.Users.FindAsync(UserID);

        return View(customer);
    }

    
}
