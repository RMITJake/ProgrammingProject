using Microsoft.AspNetCore.Mvc;
using PatientConnect.Data;
using PatientConnect.DTOs;
using PatientConnect.Models;
using SimpleHashing.Net;
using System.Net;
using System.Net.Mail;


namespace PatientConnect.Controllers;

// Bonus Material: Implement global authorisation check.
//[AllowAnonymous]
public class RegisterController : Controller
{
    private static readonly ISimpleHash s_simpleHash = new SimpleHash();

    private readonly PatientConnectContext _context;

    public RegisterController(PatientConnectContext context) => _context = context;

    [Route("/Register")]
    public IActionResult Register() => View();

    [HttpPost]
    [Route("/Register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            // Map the DTO to the User model
            int id = _context.Users.OrderByDescending(id => id.UserID).FirstOrDefault().UserID+1;
            var user = new User
            {
                UserID = id,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                City = newUser.City,
                PostCode = newUser.PostCode,
                PhoneNumber = newUser.PhoneNumber,
                UserType = newUser.UserType,
                Age = newUser.Age,
            };
            if(newUser.UserType == UserType.Doctor){
                user.ProviderNumber = newUser.ProviderNumber;
                user.Specialisation = newUser.Specialisation;
            }

            try{
                _context.Add(user);
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

            return RedirectToAction("Index", "Home");
        }   

        return View(newUser);
    }
}
