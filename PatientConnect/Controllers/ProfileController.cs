using Microsoft.AspNetCore.Mvc;
using PatientConnect.Data;
using PatientConnect.Models;
using PatientConnect.ViewModels;
using SimpleHashing.Net;
using Microsoft.EntityFrameworkCore;

namespace PatientConnect.Controllers
{
    public class ProfileController : Controller
    {

        private static readonly ISimpleHash s_simpleHash = new SimpleHash();
        private readonly PatientConnectContext _context;
        private int? UserID => HttpContext.Session.GetInt32("UserID").Value;

        public ProfileController(PatientConnectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _context.Users.FindAsync(UserID);

            Console.WriteLine("Inside index");
            Console.WriteLine(user.FirstName);

            if (user != null)
            {
                return View("Index", new RegisterVM
                {
                    UserID = user.UserID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    City = user.City,
                    PostCode = user.PostCode,
                    PhoneNumber = user.PhoneNumber,
                    UserTypeString = user.UserType.ToString(),
                    Specialisation = user.Specialisation,
                    ProviderNumber = user.ProviderNumber,
                    Age = user.Age,
                    ProfilePicture  = user.ProfilePicture,
                    Rating = user.Rating
                });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            //return View();
        }
    }
}
