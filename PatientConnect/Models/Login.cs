using System.ComponentModel.DataAnnotations;

namespace PatientConnect.Models;

public class Login
{
    [Key]
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
}