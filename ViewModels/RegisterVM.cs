namespace PatientConnect.ViewModels;
public class RegisterVM
{
    public required string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Location { get; set; }
    public int Postcode { get; set; }
    public int Age { get; set; }
    public string PhoneNum { get; set; }
    public int ProviderNumber { get; set; }
    public string Speciality { get; set; }
    public bool IsDoctor { get; set; }
}
