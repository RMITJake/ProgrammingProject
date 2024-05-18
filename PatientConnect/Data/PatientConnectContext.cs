using Microsoft.EntityFrameworkCore;
using PatientConnect.Models;

namespace PatientConnect.Data;

public class PatientConnectContext : DbContext
{
    public PatientConnectContext(DbContextOptions<PatientConnectContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<Connection> Connections { get; set; }
}
