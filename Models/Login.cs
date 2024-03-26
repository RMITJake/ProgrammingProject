using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PatientConnect.Models;

public class Login
{
    [StringLength(50)]
    public string Email { get; set; }

    public int UserID { get; set; }
    public virtual User User { get; set; }

    [Column(TypeName = "char")]
    [StringLength(94)]
    public string PasswordHash { get; set; }

    public bool Locked { get; set; } = false;
}