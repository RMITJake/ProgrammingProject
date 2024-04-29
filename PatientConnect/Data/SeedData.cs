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
<<<<<<< HEAD
                FirstName = "Matthew",
                LastName = "Bolger",
                Email = "matthew.bloger@test.patientconnect.dev",
                City = "Melbourne",
                PostCode = "3000",
                UserType = UserType.Patient
            },
            new User
            {
                UserID = 2200,
                FirstName = "Rodney",
                LastName = "Cocker",
                Email = "Rodney.Cocker@test.patientconnect.dev",
                City = "Melbourne",
                PostCode = "3005",
                UserType = UserType.Doctor
            },
            new User
            {
                UserID = 2300,
                FirstName = "Shekhar",
                LastName = "Kalra",
                UserType = UserType.Doctor
            });

        context.Logins.AddRange(
            new Login
            {
                LoginID = "12345678",
=======
                FirstName = "Jake",
                LastName = "Kent",
                Email = "jake.kent@test.patientconnect.dev",
                City = "Sydney",
                PostCode = "2000",
                UserType = UserType.Doctor,
                Specialisation = SpecialisationType.InternalMedicine,
                IsAvailable = true,
                ProfilePicture = "/img/profilepicture/profile1.png",
                Rating = 95
            },
            new User
            {
                UserID = 2101,
                FirstName = "Vignesh",
                LastName = "Menon",
                Email = "vignesh.menon@test.patientconnect.dev",
                City = "Melbourne",
                PostCode = "3005",
                UserType = UserType.Doctor,
                Specialisation = SpecialisationType.InternalMedicine,
                IsAvailable = true,
                ProfilePicture = "/img/profilepicture/profile2.png",
                Rating = 97
            },
            new User
            {
                UserID = 2102,
                FirstName = "Stephen",
                LastName = "Chung",
                Email = "stephen.chung@test.patientconnect.dev",
                City = "Melbourne",
                PostCode = "3000",
                UserType = UserType.Doctor,
                Specialisation = SpecialisationType.Surgery,
                IsAvailable = true,
                ProfilePicture = "/img/profilepicture/profile3.png",
                Rating = 100
            },
            new User
            {
                UserID = 2103,
                FirstName = "Gregory",
                LastName = "Lang",
                Email = "gregory.lang@test.patientconnect.dev",
                City = "Brisbane",
                PostCode = "4000",
                UserType = UserType.Doctor,
                Specialisation = SpecialisationType.Pediatrics,
                IsAvailable = true,
                ProfilePicture = "/img/profilepicture/profile4.png",
                Rating = 97
            },
            new User
            {
                UserID = 2104,
                FirstName = "Harrison",
                LastName = "Tang",
                Email = "harrison.tang@test.patientconnect.dev",
                City = "Melbourne",
                PostCode = "3000",
                UserType = UserType.Doctor,
                Specialisation = SpecialisationType.Psychiatry,
                IsAvailable = true,
                ProfilePicture = "/img/profilepicture/profile5.png",
                Rating = 98
            },
            new User
            {
                UserID = 2105,
                FirstName = "Tae",
                LastName = "Yoon Park",
                Email = "tae.yoon.park@test.patientconnect.dev",
                City = "Melbourne",
                PostCode = "3000",
                UserType = UserType.Doctor,
                Specialisation = SpecialisationType.Surgery,
                IsAvailable = true,
                ProfilePicture = "/img/profilepicture/profile6.png",
                Rating = 98
            },
            new User
            {
                UserID = 2106,
                FirstName = "Michael",
                LastName = "Austin",
                Email = "michael.austin@test.patientconnect.dev",
                City = "Melbourne",
                PostCode = "3000",
                UserType = UserType.Doctor,
                Specialisation = SpecialisationType.Psychiatry,
                IsAvailable = true,
                ProfilePicture = "/img/profilepicture/profile7.png",
                Rating = 92
            },
            new User
            {
                UserID = 2107,
                FirstName = "Steve",
                LastName = "Gentry",
                Email = "steve.gentry@test.patientconnect.dev",
                City = "Melbourne",
                PostCode = "3000",
                UserType = UserType.Doctor,
                Specialisation = SpecialisationType.Pediatrics,
                IsAvailable = true,
                ProfilePicture = "/img/profilepicture/profile8.png",
                Rating = 90
            },
            new User
            {
                UserID = 2108,
                FirstName = "Heidi",
                LastName = "Parish",
                Email = "heidi.parish@test.patientconnect.dev",
                City = "Melbourne",
                PostCode = "3000",
                UserType = UserType.Doctor,
                Specialisation = SpecialisationType.OBGYN,
                IsAvailable = true,
                ProfilePicture = "/img/profilepicture/profile9.png",
                Rating = 90
            },
            new User
            {
                UserID = 2109,
                FirstName = "Lily",
                LastName = "Hwangbo",
                Email = "lily.hwangbo@test.patientconnect.dev",
                City = "Adelaide",
                PostCode = "5000",
                UserType = UserType.Doctor,
                Specialisation = SpecialisationType.OBGYN,
                IsAvailable = true,
                ProfilePicture = "/img/profilepicture/profile10.png",
                Rating = 90
            });
        context.Logins.AddRange(
            new Login
            {
                LoginID = 13005700,
>>>>>>> main
                UserID = 2100,
                PasswordHash =
                    "Rfc2898DeriveBytes$50000$MrW2CQoJvjPMlynGLkGFrg==$x8iV0TiDbEXndl0Fg8V3Rw91j5f5nztWK1zu7eQa0EE="
            },
            new Login
            {
<<<<<<< HEAD
                LoginID = "38074569",
                UserID = 2200,
=======
                LoginID = 13005701,
                UserID = 2101,
>>>>>>> main
                PasswordHash =
                    "Rfc2898DeriveBytes$50000$fB5lteA+LLB0mKVz9EBA7A==$Tx0nXJ8aJjBU/mS2ssFIMs3m7vaiyitRmBRvBAYWauw="
            },
            new Login
            {
<<<<<<< HEAD
                LoginID = "17963428",
                UserID = 2300,
=======
                LoginID = 13005702,
                UserID = 2102,
                PasswordHash =
                    "Rfc2898DeriveBytes$50000$jDBijGZNWLh+0MOXnp68Yw==$4bQ9SJGtRQJolToCjFTPsVzRtH8QQUpEsioJ6Y3ewN4="
            },
            new Login
            {
                LoginID = 13005703,
                UserID = 2103,
                PasswordHash =
                    "Rfc2898DeriveBytes$50000$jDBijGZNWLh+0MOXnp68Yw==$4bQ9SJGtRQJolToCjFTPsVzRtH8QQUpEsioJ6Y3ewN4="
            },
            new Login
            {
                LoginID = 13005704,
                UserID = 2104,
                PasswordHash =
                    "Rfc2898DeriveBytes$50000$jDBijGZNWLh+0MOXnp68Yw==$4bQ9SJGtRQJolToCjFTPsVzRtH8QQUpEsioJ6Y3ewN4="
            },
            new Login
            {
                LoginID = 13005705,
                UserID = 2105,
                PasswordHash =
                    "Rfc2898DeriveBytes$50000$jDBijGZNWLh+0MOXnp68Yw==$4bQ9SJGtRQJolToCjFTPsVzRtH8QQUpEsioJ6Y3ewN4="
            },
            new Login
            {
                LoginID = 13005706,
                UserID = 2106,
                PasswordHash =
                    "Rfc2898DeriveBytes$50000$jDBijGZNWLh+0MOXnp68Yw==$4bQ9SJGtRQJolToCjFTPsVzRtH8QQUpEsioJ6Y3ewN4="
            },
            new Login
            {
                LoginID = 13005707,
                UserID = 2107,
                PasswordHash =
                    "Rfc2898DeriveBytes$50000$jDBijGZNWLh+0MOXnp68Yw==$4bQ9SJGtRQJolToCjFTPsVzRtH8QQUpEsioJ6Y3ewN4="
            },
            new Login
            {
                LoginID = 13005708,
                UserID = 2108,
                PasswordHash =
                    "Rfc2898DeriveBytes$50000$jDBijGZNWLh+0MOXnp68Yw==$4bQ9SJGtRQJolToCjFTPsVzRtH8QQUpEsioJ6Y3ewN4="
            },
            new Login
            {
                LoginID = 13005709,
                UserID = 2109,
>>>>>>> main
                PasswordHash =
                    "Rfc2898DeriveBytes$50000$jDBijGZNWLh+0MOXnp68Yw==$4bQ9SJGtRQJolToCjFTPsVzRtH8QQUpEsioJ6Y3ewN4="
            });

        context.SaveChanges();
    }
}
