using DentalClinicSystem.Data;
using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.Reservation;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<BookingViewModel>> GetPatientAppointmentsAsync()
        {
            return await dbContext.Appointments
                .Select(a => new BookingViewModel
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    PhoneNumber = a.User.PhoneNumber,
                    PreferredHour = a.PreferredHour,
                    Date = a.Date,
                    TreatmentId = a.TreatmentId
                }).ToListAsync();
        }
    }
}
