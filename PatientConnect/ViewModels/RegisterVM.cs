using PatientConnect.Models;
namespace PatientConnect.ViewModels;

public class RegisterVM : User{
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
}