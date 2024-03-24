using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PatientConnect.Models;

public class Patient : User
{

    [JsonProperty("Medicare Number")]
    [RegularExpression(@"^(\d{11})$", ErrorMessage = "Medicare Number must be 11 digits")]
    [NotNull]
    public int MedicareNo { get; set; }


    public int Age { get; set; }
    
}
