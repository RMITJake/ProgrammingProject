using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientConnect.Models;

public class Login
{
    [Key]
    [StringLength(100)]
    public string Email { get; set; }

    [Column(TypeName = "char")]
    [StringLength(94)]
    public string PasswordHash { get; set; }

    public int UserID { get; set; }
    public virtual User User { get; set; }
}
