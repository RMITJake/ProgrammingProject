using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientConnect.Models;

public class Login
{
    [Column(TypeName = "char")]
    [StringLength(8)]
    public string LoginID { get; set; }

    public int UserID { get; set; }
    public virtual User User { get; set; }

    [Column(TypeName = "char")]
    [Required, StringLength(94)]
    public string PasswordHash { get; set; }
}
