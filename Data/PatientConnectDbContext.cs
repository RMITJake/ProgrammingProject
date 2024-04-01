using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PatientConnect.Models;
namespace PatientConnect.Data;

public class PatientConnectDbContext : DbContext
{
    public PatientConnectDbContext(DbContextOptions<PatientConnectDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet <Profile> Profiles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
