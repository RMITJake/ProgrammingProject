using System.ComponentModel.DataAnnotations;

namespace PatientConnect.Models;

public class Doctor
{
    [RegularExpression(@"^(\d{10})$", ErrorMessage = "Provider Number must be 10 digits")]
    public int ProviderNumber { get; set; }
}
