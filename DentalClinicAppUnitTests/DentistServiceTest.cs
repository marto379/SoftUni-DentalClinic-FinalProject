using DentalClinicSystem.Data;
using DentalClinicSystem.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicAppUnitTests
{
    public class DentistServiceTest
    {
        private  DbContextOptions<DentalClinicDbContext> dbOptions;
        private  DentalClinicDbContext dbContext;
        private Mock<DentalClinicDbContext> dbMock;
       // private DentistService dentistService;

        public DentistServiceTest()
        {
            
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<DentalClinicDbContext>()
                .UseInMemoryDatabase("DentalClinicInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new DentalClinicDbContext(this.dbOptions);
            this.dbContext.Database.EnsureCreated(); 
        }
    }
}
