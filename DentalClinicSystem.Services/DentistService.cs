using DentalClinicSystem.Data;
using DentalClinicSystem.Data.Models;
using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.Dentist;
using DentalClinicSystem.Web.ViewModels.Patient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Services
{
    public class DentistService : IDentistService
    {
        private readonly DentalClinicDbContext dbContext;
        public DentistService(DentalClinicDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddPatientAppointmentAsync(AddAppointmentViewModel model, string dpId)
        {

            Patient? patient = await GetPatientAsync(dpId);
            Dentist? dentist = await dbContext.DentistPatients
                .Where(dp => dp.Id.ToString() == dpId)
                .Select(dp => dp.Dentist)
                .FirstOrDefaultAsync();

            
            Appointment appointment = new()
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Date = model.Date,
                PreferredHour = model.PreferredHour,
                TreatmentId = model.TreatmentId,
                UserId = model.PatientId,
                DentistId = dentist.Id
            };

            await dbContext.Appointments.AddAsync(appointment);
            await dbContext.PatientsAppointments.AddAsync(new()
            {
                PatientId = patient.Id,
                AppointmentId = appointment.Id
            });
            await dbContext.SaveChangesAsync();
        }

        public async Task AddPatientAsync(AddPatientViewModel model, string userId)
        {
            var dentist = await dbContext.Dentists
                .Where(d => d.UserId == userId)
                .FirstOrDefaultAsync();

            if (dentist is null)
            {
                // TO DO, handle when does not exist
                return;
            }

            Patient patient = new()
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender
            };

            await dbContext.Patients.AddAsync(patient);
            await dbContext.DentistPatients.AddAsync(new()
            {
                DentistId = dentist.Id,
                PatientId = patient.Id,
                IsDeleted = false
            });
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<AddPatientViewModel>> GetAllPatientsByUserIdAsync(string userId)
        {
            var dentist = await dbContext.Dentists
                .Include(d => d.DentistPatients)
                .ThenInclude(dp => dp.Patient)
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.UserId == userId);

            if (dentist is null)
            {
                return new List<AddPatientViewModel>();
            }

            return dentist.DentistPatients
                .Where(p => p.IsDeleted == false)
                .Select(p => new AddPatientViewModel
                {
                    Id = p.Id.ToString(),
                    FirstName = p.Patient.FirstName,
                    LastName = p.Patient.LastName,
                    PhoneNumber = p.Patient.PhoneNumber,
                    Gender = p.Patient.Gender
                }).ToList();
        }

        public async Task<IEnumerable<AddAppointmentViewModel>> GetPatientAppointmentsByIdAsync(string id)
        {

            var CurrDentPatient = await dbContext.DentistPatients
                .Where(dp => dp.Id == Guid.Parse(id))
                .FirstOrDefaultAsync();

            var patientId = CurrDentPatient?.Patient.Id.ToString();

            return await dbContext.DentistPatients
                .Where(dp => dp.Id == Guid.Parse(id))
                .Select(p => new AddAppointmentViewModel
                {
                    FirstName = p.Patient.FirstName,
                    LastName = p.Patient.LastName,

                }).ToListAsync();


        }

        public async Task<Patient?> GetPatientAsync(string id)
        {
            var patient = await dbContext.DentistPatients
                .Where(dp => dp.Id.ToString() == id)
                .Select(db => db.Patient)
                .FirstOrDefaultAsync();
            return patient;
        }

        public async Task<bool> IsDentistExist(string userId)
        {
            bool result = await dbContext
                .Dentists
                .AnyAsync(d => d.UserId == userId);

            return result;
        }
    }
}
