using System.ComponentModel.DataAnnotations;

namespace PatientConnect.Models;

public abstract class User
{
    [Key]
    public required string Email { get; set; }
    
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Location { get; set; }

    public required int PostCode { get; set; }

    public required int PhoneNum { get; set; }
}