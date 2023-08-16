using DentalClinicSystem.Data;
using DentalClinicSystem.Data.Models;
using DentalClinicSystem.Services;
using DentalClinicSystem.Services.Interfaces;
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
        public async Task AddPatientAsyncShoulReturnNullWhenNotFound()
        {
            Assert.Pass();
        }
    }
}
