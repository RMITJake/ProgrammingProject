using System.ComponentModel.DataAnnotations.Schema;

namespace PatientConnect.Models;

public class Profile
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProfileID { get; set; }

    public List<string> MedicalConditions { get; set; }

    public List<string> CurrentMedications { get; set; }

    public int PatientID { get; set; }
    public virtual User Patient { get; set; }

}
