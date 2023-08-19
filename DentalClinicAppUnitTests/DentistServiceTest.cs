using DentalClinicSystem.Data;
using DentalClinicSystem.Data.Models;
using DentalClinicSystem.Services;
using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.Dentist;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DentalClinicAppUnitTests.DatabaseSeeder;

namespace DentalClinicAppUnitTests
{
    [TestFixture]
    public class DentistServiceTest
    {
        private DbContextOptions<DentalClinicDbContext> dbOptions;
        private DentalClinicDbContext dbContext;
        private IDentistService dentistService;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<DentalClinicDbContext>()
                .UseInMemoryDatabase("DentalClinicInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new DentalClinicDbContext(this.dbOptions);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.dentistService = new DentistService(this.dbContext);
        }

        [Test]
        public async Task GetDentistAsyncShouldRerturnCorrectData()
        {
            Dentist dentist = await dentistService.GetDentistAsync("92CD7286-9D4C-4427-8660-06C38A1A7C65");
            string expectedFirsName = "Gosho";
            string actualFirstName = dentist.FirstName;

            Assert.IsNotNull(dentist);
            Assert.AreEqual(expectedFirsName, actualFirstName);
        }

        [Test]
        public async Task GetDentistAsyncShouldRerturnNullWhenNotFound()
        {
            var dentist = await dentistService.GetDentistAsync("92CD7286-9D4C-4427-8660-06C38A1A7C66");

            Assert.IsNull(dentist);
        }

        [Test]
        public async Task GetPatientAsyncShouldRerturnNullWhenNotFound()
        {
            var patient = await dentistService.GetPatientAsync("92CD7286-9D4C-4427-8660-06C38A1A7C66");

            Assert.IsNull(patient);
        }

        [Test]
        public async Task GetPatientAsyncShouldRerturnCorrectData()
        {
            Patient patient = await dentistService.GetPatientAsync("92CD7286-9D4C-4427-8660-06C38A1A7C65");
            string expectedFirsName = "Pacient";
            string actualFirstName = patient.FirstName;

            string expectedLastName = "Pacientov";
            string actualLastName = patient.LastName;

            string expectedGender = "male";
            string actualGender = patient.Gender;

            Assert.IsNotNull(patient);
            Assert.That(actualFirstName, Is.EqualTo(expectedFirsName));
            Assert.That(actualLastName, Is.EqualTo(expectedLastName));
            Assert.That(actualGender, Is.EqualTo(expectedGender));
        }

        [Test]

        public async Task AddPatientAsyncShouldSaveCoorectDataInDatabase()
        {
            var userId = "62c0134c-0b9c-4e54-8fa6-16f605084784";

            AddPatientViewModel model = new()
            {
                FirstName = "Test",
                LastName = "Testov",
                PhoneNumber = "0878787878",
                Gender = "Male",
                Email = "test@abv.bg",
                ImageUrl = "test",
                PersonalId = "7812124556"
            };

            dentistService.AddPatientAsync(model, userId);

            Assert.IsTrue(dbContext.Patients.Count() == 2);
            Assert.IsTrue(dbContext.DentistPatients.Any());
            Assert.IsTrue(dbContext.Patients.Any(p => p.FirstName == "Test"));
        }

        [Test]
        public async Task AddPatientAppointmentAsyncShouldAddCorrectData()
        {
            var dpId = "92CD7286-9D4C-4427-8660-06C38A1A7C65";
            AddPatientAppointmentviewModel model = new()
            {
                Date = DateTime.UtcNow,
                Hour = DateTime.UtcNow,
                TreatmentId = 1
            };

            dentistService.AddPatientAppointmentAsync(model, dpId);

            Assert.IsTrue(dbContext.PatientsAppointments.Any(pa => pa.PatientId.ToString().ToUpper() == "1AD6E120-1B14-45BD-B9DC-BE06C94D8C68"));
        }
    }
}
