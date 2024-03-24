using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientConnect.Models;

public class Doctor : User
{
    public int ProviderNumber { get; init; }

    public string? Specialty { get; set; }

    public virtual List<Patient>? Patients { get; set; }
}