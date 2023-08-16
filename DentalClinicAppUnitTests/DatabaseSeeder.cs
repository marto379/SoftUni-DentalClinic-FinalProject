using DentalClinicSystem.Data;
using DentalClinicSystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicAppUnitTests
{
    public static class DatabaseSeeder
    {
        private static IdentityUser DentistUser;
        private static Dentist Dentist;
        private static Patient Patient;
        private static DentistPatients dentistPatients;

        public static void SeedDatabase(DentalClinicDbContext dbContext)
        {
            DentistUser = new IdentityUser
            {
                Id = "62c0134c-0b9c-4e54-8fa6-16f605084784",
                UserName = "gosho@abv.bg",
                NormalizedUserName = "GOSHO@ABV.BG",
                Email = "gosho@abv.bg",
                NormalizedEmail = "GOSHO@ABV.BG",
                EmailConfirmed = false,
                PasswordHash = "90cff9cfcd96c794c6d4af5fa95c1a25874d2b367490adf4dc639e27a8418b6d",
                SecurityStamp = "a23d72d8-dba9-49c7-bec7-5bb2cac9f294",
                ConcurrencyStamp = "ea0dd12b-d357-45ad-b744-738e1bf0d907",
                TwoFactorEnabled = false,
            };

            Dentist = new Dentist()
            {
                Id = new Guid("863216EA-D8E2-4916-BD07-FA3312F4BCE2"),
                UserId = "62c0134c-0b9c-4e54-8fa6-16f605084784",
                FirstName = "Gosho",
                LastName = "Georgiev",
                PhoneNumber = "0888888888",
                SpecializationId = 1
            };

            Patient = new Patient()
            {
                Id = new Guid("1AD6E120-1B14-45BD-B9DC-BE06C94D8C68"),
                FirstName = "Pacient",
                LastName = "Pacientov",
                Gender = "male",
                PhoneNumber = "0878777777",
                PersonalId = "7878787878",
                Email = "pacient@abv.bg",
                ImageUrl = "pacient"
            };

            dentistPatients = new DentistPatients()
            {
                Id = new Guid("92CD7286-9D4C-4427-8660-06C38A1A7C65"),
                PatientId = new Guid("1AD6E120-1B14-45BD-B9DC-BE06C94D8C68"),
                DentistId = new Guid("863216EA-D8E2-4916-BD07-FA3312F4BCE2")
            };

            dbContext.Users.Add(DentistUser);
            dbContext.Dentists.Add(Dentist);
            dbContext.Patients.Add(Patient);
            dbContext.DentistPatients.Add(dentistPatients);
            dbContext.SaveChanges();
        }
    }
}
