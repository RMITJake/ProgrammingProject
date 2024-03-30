namespace PatientConnect.ViewModels;

public class LoginVM
{
    public required string Email { get; set; }
    public string? Password { get; set; }
    public string? PasswordConfirm { get; set; }
}