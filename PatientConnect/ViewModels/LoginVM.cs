using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PatientConnect.Models;

namespace PatientConnect.ViewModels;

public class LoginVM : User
{

    //[Required(ErrorMessage = "Email is required")]
    //[EmailAddress(ErrorMessage = "Invalid Email address")]
    //public String Email { get; set; }

    [Column(TypeName = "char")]
    [Required(ErrorMessage = "Password is required"), StringLength(94)]
    public string Password { get; set; }
}
