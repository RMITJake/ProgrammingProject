using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientConnect.Models;

public class LoginVM
{
    public String Email { get; set; }

    [Column(TypeName = "char")]
    [Required, StringLength(94)]
    public string Password { get; set; }
}
