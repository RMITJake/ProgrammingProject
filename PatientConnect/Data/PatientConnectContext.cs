using Microsoft.EntityFrameworkCore;
using PatientConnect.Models;

namespace PatientConnect.Data;

public class PatientConnectContext : DbContext
{
    public PatientConnectContext(DbContextOptions<PatientConnectContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Login> Logins { get; set; }

    // Fluent-API.
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Set check constraints (cannot be expressed with data annotations).
        builder.Entity<Login>().ToTable(b =>
        {
            b.HasCheckConstraint("CH_Login_LoginID", "len(LoginID) = 8");
            b.HasCheckConstraint("CH_Login_PasswordHash", "len(PasswordHash) = 94");
        });
    }
}
