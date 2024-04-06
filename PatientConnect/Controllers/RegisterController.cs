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

    [Route("/RegisterPartial")]
    public IActionResult RegisterPartial() => PartialView();

    [Route("/Register")]
    public IActionResult Register() => View();

    [HttpPost]
    [Route("/Register")]
    public IActionResult Register(UserDto dto)
    {
        if (ModelState.IsValid)
        {
            // Map the DTO to the User model
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                City = dto.City,
                PostCode = dto.PostCode,
                UserType = dto.UserType
            };

            SmtpClient smtpClient = new SmtpClient("smtp.elasticemail.com"){};
            smtpClient.Port = 2525;
            smtpClient.Credentials = new NetworkCredential ("patientconnect@protonmail.com", "2C9A9B05319A440E34267209C87615F5E661");
            smtpClient.EnableSsl = true;

            MailMessage message = new MailMessage{
                From = new MailAddress("patientconnect@protonmail.com"),
                Subject = "Patient Connect Registration Confirmation",
                Body = "Thank you " + dto.Name + " for registering with Patient Connect!"
            };

            message.To.Add(dto.Email);

            smtpClient.Send(message);

            return RedirectToAction("RegistrationSuccess");
        }   

        return View(dto);
    }
}
