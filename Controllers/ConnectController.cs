using Microsoft.AspNetCore.Mvc;

namespace PatientConnect.Controllers
{
    public class ConnectController : Controller
    {
        public IActionResult Index() => View(); 
    }
}
