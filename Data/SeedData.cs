using Microsoft.AspNetCore.Identity;
using PatientConnect.Models;

namespace PatientConnect.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<PatientConnectDbContext>();

        // Look for users.
        if (context.Logins.Any())
            return; // DB has already been seeded.

        // Seed Users
        context.Users.Add(new User
        {
            Email = "matthew.bloger@rmit.edu.au",
            Firstname = "Matthew",
            Lastname = "Bloger",
            Location = "Melbourne",
            Postcode = 3000,
            PhoneNum = "0412 345 676",
            UserType = UserType.Patient
        });

        context.Logins.Add(new Login
        {
            Email = "matthew.bloger@rmit.edu.au",
            PasswordHash = "Rfc2898DeriveBytes$50000$MrW2CQoJvjPMlynGLkGFrg==$x8iV0TiDbEXndl0Fg8V3Rw91j5f5nztWK1zu7eQa0EE="
        });

        context.Users.Add(new User
        {
            Firstname = "Rodney",
            Lastname = "Cocker",
            Email = "rodney.cocker@rmit.edu.au",
            Location = "Brisbane",
            Postcode = 4000,
            PhoneNum = "0412 113 676",
            UserType = UserType.Patient
        });

        context.Users.Add(new User
        {
            Firstname = "Shekar",
            Lastname = "Kalra",
            Email = "shekar.kalra@rmit.edu.au",
            Location = "Canberra",
            Postcode = 2600,
            PhoneNum = "0412 345 889",
            UserType = UserType.Doctor
        });

        context.SaveChanges();

    }
}
