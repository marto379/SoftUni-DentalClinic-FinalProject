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

        public async Task<AddAppointmentViewModel> GetAddAppointmentAsync(string userId)
        {
            var treatements = await dbContext.Treatments
                .Select(t => new TreatmentViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                }).ToListAsync();

            //var currModel = await dbContext.Patients
            //    .Where(p => p.Id.ToString() == userId)
            //    .FirstOrDefaultAsync();

            var returnModel = await dbContext.Patients
                .Where(p => p.Id.ToString() == userId)
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

        public async Task<IEnumerable<BookingViewModel>> GetPatientAppointmentsAsync(string patientId)
        {
            var appointments = await dbContext.Appointments
                .Where(a => a.PatientId.ToString() == patientId)
                .Select(a => new BookingViewModel
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    PhoneNumber = a.Patient.PhoneNumber,
                    PreferredHour = a.PreferredHour.ToString(),
                    Date = a.Date,
                    UserId = a.PatientId.ToString(),
                    DentistId = a.DentistId.ToString(),
                    Treatment = a.Treatment.Name,
                    Dentist = $"{ a.Dentist.FirstName } {a.Dentist.LastName}",
                    Status = a.Date > DateTime.UtcNow ? "coming up" : "done"
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
