using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientConnect.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserID { get; set; }

    [Required]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    public string Firstname { get; set; }

    [Required]
    public string Lastname { get; set; }

    [JsonProperty("Location")]
    [StringLength(40)]
    public string Location { get; set; }

    [JsonProperty("PostCode")]
    [RegularExpression(@"^(\d{4})$", ErrorMessage = "Postcode must be 4 digits")]
    public int Postcode { get; set; }

    [StringLength(12)]
    [RegularExpression(@"^(^04([\d]{2}) [\d]{3} [\d]{3})$", ErrorMessage = "Must be of the format: 04xx xxx xxx")]
    [DisplayFormat(NullDisplayText = "")]
    public string PhoneNum { get; set; }

    public virtual Login Login { get; set; }
}
