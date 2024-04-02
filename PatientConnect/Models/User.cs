using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientConnect.Models;

public enum UserType
{
    Patient = 1,
    Doctor = 2
}
public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int UserID { get; set; }

    [Required, StringLength(50)]
    public string Name { get; set; }

    [StringLength(150)]
    public string Email { get; set; }

    [StringLength(40)]
    public string City { get; set; }

    [StringLength(4)]
    public string PostCode { get; set; }

    public UserType UserType { get; set; }
}
