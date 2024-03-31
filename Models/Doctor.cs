using System.ComponentModel.DataAnnotations;

namespace PatientConnect.Models;

public enum SpecialityType
{
    General = 1,
    Pediatrics = 2,
    Surgery = 3,
    Psychiatry = 4,
    ObGyn = 5
}

public class Doctor : User
{
    [RegularExpression(@"^(\d{10})$", ErrorMessage = "Provider Number must be 10 digits")]
    public int ProviderNumber { get; set; }

    public SpecialityType Speciality { get; set; }

    public virtual List<Patient> Patients { get; set; }
}
