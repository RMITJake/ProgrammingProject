using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientConnect.Data;
using PatientConnect.ViewModels;
using PatientConnect.Models;
using SimpleHashing.Net;
using System.Net;
using System.Net.Mail;


namespace PatientConnect.Controllers;

// Bonus Material: Implement global authorisation check.
//[AllowAnonymous]
public class RegisterController : Controller
{
    private static readonly ISimpleHash _simpleHash = new SimpleHash();

    private readonly PatientConnectContext _context;

    public RegisterController(PatientConnectContext context) => _context = context;

    [Route("/Register")]
    public IActionResult Register() => View();

    
    [Route("/Register")]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM newUser)
    {

        Console.WriteLine("In post register");
        if (ModelState.IsValid)
        {
            if (newUser.Password != newUser.PasswordConfirm) {

                Console.WriteLine("Passwords do not match");
                ModelState.AddModelError("PasswordMismatch", "Passwords do not match");
                //return View(newUser);
                return View();

            }

            var userCheck = await _context.Users.Where(u => u.Email == newUser.Email).FirstOrDefaultAsync();
            if (userCheck != null) {

                Console.WriteLine("Email already in use");
                ModelState.AddModelError("EmailError", "Email already in use");
                return View();
            }

            // Map the DTO to the User model
            int userId = _context.Users.OrderByDescending(id => id.UserID).FirstOrDefault().UserID+1;
            var user = new User
            {
                UserID = userId,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                City = newUser.City,
                PostCode = newUser.PostCode,
                PhoneNumber = newUser.PhoneNumber,
                UserType = newUser.UserType,
                Age = newUser.Age,
            };

            if (newUser.UserType == UserType.Doctor){
                user.ProviderNumber = newUser.ProviderNumber;
                user.Specialisation = newUser.Specialisation;
            }

            int loginId = _context.Logins.OrderByDescending(id => id.LoginID).FirstOrDefault().LoginID+1;
            var login = new Login
            {
                LoginID = loginId,
                UserID = userId,
                PasswordHash = _simpleHash.Compute(newUser.Password)
            };

            try{
                _context.Add(user);
                _context.Add(login);
                _context.SaveChanges();
            } catch(Exception e){
                Console.WriteLine(e);
            }

            SmtpClient smtpClient = new SmtpClient("smtp.elasticemail.com"){};
            smtpClient.Port = 2525;
            smtpClient.Credentials = new NetworkCredential ("patientconnect@protonmail.com", "2C9A9B05319A440E34267209C87615F5E661");
            smtpClient.EnableSsl = true;

            MailMessage message = new MailMessage{
                From = new MailAddress("patientconnect@protonmail.com"),
                Subject = "Patient Connect Registration Confirmation",
                Body = "Thank you " + user.FirstName + " for registering with Patient Connect!"
            };

            message.To.Add(user.Email);

            smtpClient.Send(message);

            // login.PasswordHash = rawPassword;
            // return RedirectToAction("Login", "Login", login);
            return RedirectToAction("Index", "Home");
        }   

        return View(newUser);
        // return RedirectToAction("Index", "Home");
    }
}
