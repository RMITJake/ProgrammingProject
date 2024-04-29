using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
=======
using Microsoft.EntityFrameworkCore;
>>>>>>> main
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
<<<<<<< HEAD
    private static readonly ISimpleHash s_simpleHash = new SimpleHash();
=======
    private static readonly ISimpleHash _simpleHash = new SimpleHash();
>>>>>>> main

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
<<<<<<< HEAD
            // Map the DTO to the User model
            int id = _context.Users.OrderByDescending(id => id.UserID).FirstOrDefault().UserID+1;
            var user = new User
            {
                UserID = id,
=======
            var userCheck = _context.Users.Where(u => u.Email == newUser.Email).FirstOrDefault();
            if(userCheck != null){
                return View();
            }

            // Map the DTO to the User model
            int userId = _context.Users.OrderByDescending(id => id.UserID).FirstOrDefault().UserID+1;
            var user = new User
            {
                UserID = userId,
>>>>>>> main
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                City = newUser.City,
                PostCode = newUser.PostCode,
                PhoneNumber = newUser.PhoneNumber,
<<<<<<< HEAD
                UserType = newUser.UserType
=======
                UserType = newUser.UserType,
                Age = newUser.Age,
            };
            if(newUser.UserType == UserType.Doctor){
                user.ProviderNumber = newUser.ProviderNumber;
                user.Specialisation = newUser.Specialisation;
            }

            String rawPassword = "123456";

            int loginId = _context.Logins.OrderByDescending(id => id.LoginID).FirstOrDefault().LoginID+1;
            var login = new Login
            {
                LoginID = loginId,
                UserID = userId,
                PasswordHash = _simpleHash.Compute(rawPassword)
>>>>>>> main
            };

            try{
                _context.Add(user);
<<<<<<< HEAD
=======
                _context.Add(login);
>>>>>>> main
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

<<<<<<< HEAD
            return RedirectToAction("RegistrationSuccess");
=======
            // login.PasswordHash = rawPassword;
            // return RedirectToAction("Login", "Login", login);
            return RedirectToAction("Index", "Home");
>>>>>>> main
        }   

        return View(newUser);
    }
}
