using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatientConnect.Models;
using PatientConnect.ViewModels;
using SimpleHashing.Net;

namespace PatientConnect.Controllers;
public class LoginController : Controller
{
    private readonly PatientConnectDbContext _context;
    private static readonly ISimpleHash s_simpleHash = new SimpleHash();
    private void debug(string message){ Console.WriteLine("!>DEBUG: " + message); }

    public LoginController(PatientConnectDbContext context)
    {
        _context = context;
    }

    // GET: Login
    public async Task<IActionResult> Index()
    {
        return View(await _context.Login.ToListAsync());
    }

    // GET: Login/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var login = await _context.Login
            .FirstOrDefaultAsync(m => m.Email == id);
        if (login == null)
        {
            return NotFound();
        }

        return View(login);
    }

    // GET: Login/Register
    [Route("Register")]
    public IActionResult Register() { return View(); }

    // POST: Login/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Route("Register")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegistrationVM registrationVM)
    {
        debug("REGISTER POST RECEIVED");
        if (ModelState.IsValid)
        {
            debug("LOGIN MODEL VALID");
            Login? newLogin = await _context.Login.FirstOrDefaultAsync(x => x.Email == registrationVM.Email);
            if(newLogin != null){
                debug("EMAIL ALREADY EXISTS IN DB");
                ModelState.AddModelError("EmailExists", "Email already registered.");
                return View(new RegistrationVM {Email = registrationVM.Email});
            } else if(registrationVM.Password != registrationVM.PasswordConfirm){
                debug("LOGIN PASSWORD NO MATCH");
                ModelState.AddModelError("PasswordNoMatch", "Passwords do not match.");
                return View(new RegistrationVM {Email = registrationVM.Email});
            } else if(registrationVM.Password == null){
                debug("LOGIN PASSWORD NO MATCH");
                ModelState.AddModelError("PasswordBlank", "Passwords can not be blank.");
                return View(new RegistrationVM {Email = registrationVM.Email});
            }

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                newLogin = new Login{
                    Email = registrationVM.Email,
                    PasswordHash = s_simpleHash.Compute(registrationVM.Password)
                };
                _context.Add(newLogin);
                await _context.SaveChangesAsync();

                if(registrationVM.IsDoctor){
                    Doctor newAccount = new Doctor{
                        Email = registrationVM.Email,
                        FirstName = registrationVM.FirstName,
                        LastName = registrationVM.LastName,
                        Location = registrationVM.Location,
                        PostCode = registrationVM.PostCode,
                        PhoneNum = registrationVM.PhoneNum,
                        Specialty = registrationVM.Specialty,
                        ProviderNumber = registrationVM.ProviderNumber
                    };
                    _context.Add(newAccount);
                } else {
                    Patient newAccount = new Patient{
                        Email = registrationVM.Email,
                        FirstName = registrationVM.FirstName,
                        LastName = registrationVM.LastName,
                        Location = registrationVM.Location,
                        PostCode = registrationVM.PostCode,
                        PhoneNum = registrationVM.PhoneNum,
                        Age = registrationVM.Age
                    };
                    _context.Add(newAccount);
                }
                await _context.SaveChangesAsync();

                transaction.Commit();
            } catch
            {
                // handle error
            }
            return RedirectToAction(nameof(Index));
        }
        debug("LOGIN MODEL NOT VALID");
        return View();
    }

    // GET: Login/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var login = await _context.Login.FindAsync(id);
        if (login == null)
        {
            return NotFound();
        }
        return View(login);
    }

    // POST: Login/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("Email,PasswordHash")] Login login)
    {
        if (id != login.Email)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(login);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(login.Email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(login);
    }

    // GET: Login/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var login = await _context.Login
            .FirstOrDefaultAsync(m => m.Email == id);
        if (login == null)
        {
            return NotFound();
        }

        return View(login);
    }

    // POST: Login/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var login = await _context.Login.FindAsync(id);
        if (login != null)
        {
            _context.Login.Remove(login);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LoginExists(string id)
    {
        return _context.Login.Any(e => e.Email == id);
    }
}
