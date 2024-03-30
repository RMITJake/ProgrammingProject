using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace PatientConnect.Models;

public class PatientConnectDbContext : DbContext
{
    public PatientConnectDbContext(DbContextOptions<PatientConnectDbContext> options) : base (options){}

    public DbSet<Patient> Patient { get; set; }
    public DbSet<Doctor> Doctor { get; set; }
    public DbSet<Login> Login { get; set; }
}
