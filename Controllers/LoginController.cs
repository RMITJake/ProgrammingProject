using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientConnect.Data;
using PatientConnect.Models;
using PatientConnect.ViewModels;
using SimpleHashing.Net;

namespace McbaExample.Controllers;

public class LoginController : Controller
{
    private static readonly ISimpleHash s_simpleHash = new SimpleHash();

    private void debug(string message) { Console.WriteLine("!>DEBUG: " + message); }


    private readonly PatientConnectContext _context;

    public LoginController(PatientConnectContext context) => _context = context;

    public IActionResult Index() => View(); // login page

    [HttpPost]
    [Route("SecureLogin")]
    public async Task<IActionResult> Login(string email, string password)
    {
        // look up login ID in the database
        var login = await _context.Logins.FindAsync(email);

        // if login details incorrect or not found - show error
        if (login == null || string.IsNullOrEmpty(password) || !s_simpleHash.Verify(password, login.PasswordHash))
        {
            ModelState.AddModelError("LoginFailed", "Login failed, please try again.");
            return View(new Login { Email = email });
        }

        Console.WriteLine("Login Success!");
        // success - complete login
        HttpContext.Session.SetInt32(nameof(Patient.UserID), login.UserID);
        HttpContext.Session.SetString(nameof(Patient.Firstname), login.User.Firstname);

        return RedirectToAction("Index", "Connect");
    }

    public IActionResult Register() => View(); // Register page
                                               // POST: Login/Create
                                               // To protect from overposting attacks, enable the specific properties you want to bind to.
                                               // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Route("Register")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterVM registerVM)
    {
        debug("REGISTER POST RECEIVED");
        if (ModelState.IsValid)
        {
            debug("LOGIN MODEL VALID");
            Login newLogin = await _context.Logins.FirstOrDefaultAsync(x => x.Email == x.Email);
            if (newLogin != null)
            {
                debug("EMAIL ALREADY EXISTS IN DB");
                ModelState.AddModelError("EmailExists", "Email already registered.");
                return View(new RegisterVM { Email = registerVM.Email });
            }
            else if (registerVM.Password != registerVM.PasswordConfirm)
            {
                debug("LOGIN PASSWORD NO MATCH");
                ModelState.AddModelError("PasswordNoMatch", "Passwords do not match.");
                return View(new RegisterVM { Email = registerVM.Email });
            }
            else if (registerVM.Password == null)
            {
                debug("LOGIN PASSWORD NO MATCH");
                ModelState.AddModelError("PasswordBlank", "Passwords can not be blank.");
                return View(new RegisterVM { Email = registerVM.Email });
            }

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                newLogin = new Login
                {
                    Email = registerVM.Email,
                    PasswordHash = s_simpleHash.Compute(registerVM.Password)
                };
                _context.Add(newLogin);
                await _context.SaveChangesAsync();

                if (registerVM.IsDoctor)
                {
                    Doctor newAccount = new Doctor
                    {
                        Email = registerVM.Email,
                        Firstname = registerVM.Firstname,
                        Lastname = registerVM.Lastname,
                        Location = registerVM.Location,
                        Postcode = registerVM.Postcode,
                        PhoneNum = registerVM.PhoneNum,
                        Speciality = SpecialityType.General,
                        ProviderNumber = registerVM.ProviderNumber
                    };
                    _context.Add(newAccount);
                }
                else
                {
                    Patient newAccount = new Patient
                    {
                        Email = registerVM.Email,
                        Firstname = registerVM.Firstname,
                        Lastname = registerVM.Lastname,
                        Location = registerVM.Location,
                        Postcode = registerVM.Postcode,
                        PhoneNum = registerVM.PhoneNum,
                        Age = registerVM.Age
                    };
                    _context.Add(newAccount);
                }
                await _context.SaveChangesAsync();

                transaction.Commit();
            }
            catch
            {
                // handle error
            }
            return RedirectToAction(nameof(Index));
        }
        debug("LOGIN MODEL NOT VALID");
        return View();
    }

    [Route("LogoutNow")]
    public IActionResult Logout()
    {
        // Logout - clear sessions (customer id)
        HttpContext.Session.Clear();

        return RedirectToAction("Index", "Home");
    }
}