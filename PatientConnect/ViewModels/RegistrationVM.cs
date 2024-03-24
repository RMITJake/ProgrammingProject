namespace PatientConnect.ViewModels;

public class RegistrationVM
{
    public required string Email { get; set; }
    public string? Password { get; set; }
    public string? PasswordConfirm { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Location { get; set; }
    public int PostCode { get; set; }
    public int Age { get; set; }
    public int PhoneNum { get; set; }
    public int ProviderNumber { get; set; }
    public string? Specialty { get; set; }
}