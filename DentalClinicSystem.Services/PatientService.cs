using DentalClinicSystem.Data;
using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Services
{
    public class PatientService : IPatientService
    {
        private readonly DentalClinicDbContext dbContext;

        public PatientService(DentalClinicDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BookingViewModel> GetAddPatientModelAsync()
        {
            var model = new BookingViewModel();

            return model;
        }
    }
}
