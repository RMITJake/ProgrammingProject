using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatientConnect.Models;

namespace PatientConnect.Controllers;

public class AccountController : Controller
{
    private readonly PatientConnectDbContext _context;

    public AccountController(PatientConnectDbContext context)
    {
        _context = context;
    }

    // GET: Account
    public async Task<IActionResult> Index()
    {
        ViewBag.patients = await _context.Patient.ToListAsync();
        ViewBag.doctors = await _context.Doctor.ToListAsync();
        return View();
    }
}
