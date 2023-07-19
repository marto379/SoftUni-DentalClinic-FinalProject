using DentalClinicSystem.Data;
using DentalClinicSystem.Data.Models;
using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.Dentist;
using DentalClinicSystem.Web.ViewModels.Patient;
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

        public async Task<AddAppointmentViewModel> GetAddAppointmentAsync(string id)
        {
            var treatements = await dbContext.Treatments
                .Select(t => new TreatmentViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                }).ToListAsync();

            var currModel = await dbContext.Patients
                .Where(p => p.Id.ToString() == id)
                .FirstOrDefaultAsync();

            var returnModel = await dbContext.Patients
                .Where(p => p.Id.ToString() == id)
                .Select(p => new AddAppointmentViewModel
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    TreatmentId = new()
                }).FirstOrDefaultAsync();

            returnModel.Treatments = treatements;

            return returnModel;
        }

        public async Task<BookingViewModel> GetAddPatientModelAsync()
        {
            var model = new BookingViewModel();

            return model;
        }

        public async Task<IEnumerable<BookingViewModel>> GetPatientAppointmentsAsync()
        {
            var appointments = await dbContext.Appointments
                .Select(a => new BookingViewModel
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    PhoneNumber = a.User.PhoneNumber,
                    PreferredHour = a.PreferredHour,
                    Date = a.Date,
                    Treatment = a.Treatment.Name
                }).ToListAsync();

            return appointments;
        }

        public async Task RemovePatientAsync(string id)
        {
            var dp = await dbContext.DentistPatients
                .FirstOrDefaultAsync(p => p.Id.ToString() == id);

            if (dp is not null && dp.IsDeleted == false)
            {
                dp.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
