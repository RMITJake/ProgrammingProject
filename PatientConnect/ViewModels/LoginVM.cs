using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientConnect.Models;

public class LoginVM
{

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email address")]
    public String Email { get; set; }

    [Column(TypeName = "char")]
    [Required(ErrorMessage = "Password is required"), StringLength(94)]
    public string Password { get; set; }
}
