using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PatientConnect.Models;
using System.Security.Principal;
namespace PatientConnect.Data;

public class PatientConnectContext : DbContext
{
    public PatientConnectContext(DbContextOptions<PatientConnectContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Profile> Profiles { get; set; }


    // Fluent-API.
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
