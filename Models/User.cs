using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace PatientConnect.Models;

public abstract class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerID { get; set; }

    [StringLength(50)]
    public string Name { get; set; }

    [StringLength(50)]
    public string Email { get; set; }

    [JsonProperty("City")]
    [StringLength(40)]
    [DisplayFormat(NullDisplayText = "")]
    [AllowNull]
    public string City { get; set; }

    [JsonProperty("Postcode")]
    [RegularExpression(@"^(\d{4})$", ErrorMessage = "Postcode must be 4 digits")]
    [DisplayFormat(NullDisplayText = "")]
    [AllowNull]
    public int? PostCode { get; set; }

    [StringLength(12)]
    [RegularExpression(@"^(^04([\d]{2}) [\d]{3} [\d]{3})$", ErrorMessage = "Must be of the format: 04xx xxx xxx")]
    [DisplayFormat(NullDisplayText = "")]
    public string Mobile { get; set; }
}
