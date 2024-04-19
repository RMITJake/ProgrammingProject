using PatientConnect.Models;

namespace PatientConnect.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<PatientConnectContext>();

        // Look for customers.
        if(context.Users.Any())
            return; // DB has already been seeded.

        context.Users.AddRange(
            new User
            {
                UserID = 2100,
                FirstName = "Matthew",
                LastName = "Bolger",
                Email = "matthew.bloger@test.patientconnect.dev",
                City = "Melbourne",
                PostCode = "3000",
                UserType = UserType.Doctor,
                Specialisation = SpecialisationType.InternalMedicine,
                IsAvailable = true
            },
            new User
            {
                UserID = 2200,
                FirstName = "Rodney",
                LastName = "Cocker",
                Email = "Rodney.Cocker@test.patientconnect.dev",
                City = "Melbourne",
                PostCode = "3005",
                UserType = UserType.Doctor,
                Specialisation = SpecialisationType.OBGYN,
                IsAvailable = true
            },
            new User
            {
                UserID = 2300,
                FirstName = "Stephen",
                LastName = "Chung",
                Email = "stephen.chung@test.patientconnect.dev",
                City = "Melbourne",
                PostCode = "3000",
                UserType = UserType.Doctor,
                Specialisation = SpecialisationType.Surgery,
                IsAvailable = true
            },
            new User
            {
                UserID = 2400,
                FirstName = "Gregory",
                LastName = "Lang",
                Email = "gregory.lang@test.patientconnect.dev",
                City = "Brisbane",
                PostCode = "4000",
                UserType = UserType.Doctor,
                Specialisation = SpecialisationType.Pediatrics,
                IsAvailable = true
            });
        context.Logins.AddRange(
            new Login
            {
                LoginID = "12345678",
                UserID = 2100,
                PasswordHash =
                    "Rfc2898DeriveBytes$50000$MrW2CQoJvjPMlynGLkGFrg==$x8iV0TiDbEXndl0Fg8V3Rw91j5f5nztWK1zu7eQa0EE="
            },
            new Login
            {
                LoginID = "38074569",
                UserID = 2200,
                PasswordHash =
                    "Rfc2898DeriveBytes$50000$fB5lteA+LLB0mKVz9EBA7A==$Tx0nXJ8aJjBU/mS2ssFIMs3m7vaiyitRmBRvBAYWauw="
            },
            new Login
            {
                LoginID = "17963428",
                UserID = 2300,
                PasswordHash =
                    "Rfc2898DeriveBytes$50000$jDBijGZNWLh+0MOXnp68Yw==$4bQ9SJGtRQJolToCjFTPsVzRtH8QQUpEsioJ6Y3ewN4="
            });

        context.SaveChanges();
    }
}
