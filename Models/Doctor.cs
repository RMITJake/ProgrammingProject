using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace PatientConnect.Models;

public class Doctor : User
{
    [JsonProperty("Provider Number")]
    [StringLength(12)]
    [RegularExpression(@"\d{5}[A-Z]{2}$", ErrorMessage = "Must be of format: 12345AB)")]
    [NotNull]
    public int ProviderNo { get; set; }
    public string Speciality { get; set; }
}
