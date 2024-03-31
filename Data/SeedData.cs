using PatientConnect.Models;

namespace PatientConnect.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<PatientConnectContext>();

        // Look for customers.
        if (context.Logins.Any())
            return; // DB has already been seeded.

        // Seed Users
        context.Patients.Add(new Patient
        {
            Email = "matthew.bloger@rmit.edu.au",
            Firstname = "Matthew",
            Lastname = "Bloger",
            Location = "Melbourne",
            UserType =  UserType.Patient,
            Postcode = 3000,
            PhoneNum = "0412 345 676",
            Age = 25
        });

        context.Logins.Add(new Login
        {
            Email = "matthew.bloger@rmit.edu.au",
            PasswordHash = "Rfc2898DeriveBytes$50000$MrW2CQoJvjPMlynGLkGFrg==$x8iV0TiDbEXndl0Fg8V3Rw91j5f5nztWK1zu7eQa0EE="
            // abc123
        });

        context.Patients.Add(new Patient
        {
            Firstname = "Rodney",
            Lastname = "Cocker",
            Email = "rodney.cocker@rmit.edu.au",
            Location = "Brisbane",
            UserType = UserType.Patient,
            Postcode = 4000,
            PhoneNum = "0412 113 676",
            Age = 32
        });

        context.Doctors.Add(new Doctor
        {
            Firstname = "Shekar",
            Lastname = "Kalra",
            Email = "shekar.kalra@rmit.edu.au",
            Location = "Canberra",
            UserType = UserType.Doctor,
            Postcode = 2600,
            PhoneNum = "0412 345 889",
            ProviderNumber = 1245789632,
            Speciality = SpecialityType.Psychiatry
        });

        context.SaveChanges();

    }
}
