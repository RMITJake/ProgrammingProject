using PatientConnect.Models;
using System.ComponentModel.DataAnnotations;

namespace PatientConnect.DTOs
{
    public class UserDto
    {
        public int UserID { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public UserType UserType { get; set; }

        public SpecialisationType Specialisation { get; set; }

        public int ProviderNumber { get; set; }

        public int Age { get; set; }
    }
}
