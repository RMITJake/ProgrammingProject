// Purpose: This file contains the User class, which represents a user in the system. 
// The User class contains the following properties: UserID, FirstName, LastName, Email, City, PostCode, PhoneNumber, and UserType. 
// The User class also contains a list of appointments. The User class also contains a UserType enum, which represents the type of user.
// The User class also contains the following attributes: DatabaseGenerated, Required, StringLength, and RegularExpression.
// The User class is used to represent a user in the system.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientConnect.Models;

public enum UserType
{
    // Patient is a user who is a patient
    Patient = 1,
    // Doctor is a user who is a doctor
    Doctor = 2
}

public enum SpecialisationType
{
    [Display(Name = "Internal Medicine")]
    InternalMedicine = 1,
    Pediatrics = 2,
    Psychiatry = 3,
    Surgery = 4,
    OBGYN = 5
}

// User is a class that represents a user in the system
public class User
{
    // UserID is a unique identifier for the user
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int UserID { get; set; }

    // FirstName is the user's first name
    [Required, StringLength(50)]
    public string FirstName { get; set; }

    // LastName is the user's last name
    [Required, StringLength(50)]
    public string LastName { get; set; }

    // Email is the user's email address
    [StringLength(150)]
    public string Email { get; set; }

    // City is the user's city
    [StringLength(40)]
    public string City { get; set; }

    // PostCode is the user's post code
    [StringLength(4)]
    public string PostCode { get; set; }

    // PhoneNumber is the user's phone number
    [RegularExpression("^(?:\\+?(61))? ?(?:\\((?=.*\\)))?(0?[2-57-8])\\)? ?(\\d\\d(?:[- ](?=\\d{3})|(?!\\d\\d[- ]?\\d[- ]))\\d\\d[- ]?\\d[- ]?\\d{3})$")]
    public string PhoneNumber { get; set; }

    // UserType is the user's type
    public UserType UserType { get; set; }

    // if doctor - Specialisation is doctor's specialisation
    public SpecialisationType? Specialisation { get; set; }

    // if doctor - ProviderNumber is doctor's provider number
    public int? ProviderNumber { get; set; }

    // if patient - Age is patient's age
    public int? Age { get; set; }

    // available -- logged in
    public bool? IsAvailable { get; set; }

    public string? ProfilePicture { get; set; }

    public int? Rating { get; set; }
}
