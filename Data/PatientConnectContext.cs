using Microsoft.EntityFrameworkCore;
using PatientConnect.Models;
namespace PatientConnect.Data;

public class PatientConnectContext : DbContext
{
    public PatientConnectContext(DbContextOptions<PatientConnectContext> options) : base(options) { }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<Profile> Profiles { get; set; }


    // Fluent-API.
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
