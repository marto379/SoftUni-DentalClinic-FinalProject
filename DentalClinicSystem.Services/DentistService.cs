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
            Dentist? dentist = await GetDentistAsync(dpId);

            
            Appointment appointment = new()
            {
                //Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Date = model.Date,
                PreferredHour = model.PreferredHour,
                TreatmentId = model.TreatmentId,
                PatientId = patient.Id,
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
                Gender = model.Gender,
                PersonalId = model.PersonalId
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

            return  dentist.DentistPatients
                .Where(p => p.IsDeleted == false)
                .Select(p => new AddPatientViewModel
                {
                    Id = p.Id.ToString(),
                    FirstName = p.Patient.FirstName,
                    LastName = p.Patient.LastName,
                    PhoneNumber = p.Patient.PhoneNumber,
                    Gender = p.Patient.Gender,
                    PersonalId = p.Patient.PersonalId
                }).ToList();
        }

        public async Task<IEnumerable<AppointmentPatientViewModel>> GetPatientAppointmentsByIdAsync(string id)
        {

            //var CurrDentPatient = await dbContext.DentistPatients
            //    .Where(dp => dp.Id == Guid.Parse(id))
            //    .FirstOrDefaultAsync();

            var patient = await GetPatientAsync(id);

            var result = await dbContext.PatientsAppointments
                .Where(pa => pa.PatientId == patient.Id)
                .Select(pa => new AppointmentPatientViewModel
                {
                    FirstName = pa.Patient.FirstName,
                    LastName = pa.Patient.LastName,
                    Treatment = pa.Appointment.Treatment.Name,
                    Date = pa.Appointment.Date.ToString("yyyy-MM-dd"),
                    Hour = pa.Appointment.PreferredHour.ToString("H:mm")

                }).ToListAsync();

            return result;
        }

        public async Task<Patient?> GetPatientAsync(string id)
        {
            var patient = await dbContext.DentistPatients
                .Where(dp => dp.Id.ToString() == id)
                .Select(db => db.Patient)
                .FirstOrDefaultAsync();
            return patient;
        }

        public async Task<Dentist?> GetDentistAsync(string id)
        {
            var dentist = await dbContext.DentistPatients
                .Where(dp => dp.Id.ToString() == id)
                .Select(db => db.Dentist)
                .FirstOrDefaultAsync();
            return dentist;
        }

        public async Task<bool> IsDentistExist(string userId)
        {
            bool result = await dbContext
                .Dentists
                .AnyAsync(d => d.UserId == userId);

            return result;
        }

        public async Task<IEnumerable<AddAppointmentViewModel>> GetDentistAppointmentsAsync(string id)
        {
            var dentistId = await dbContext.Dentists
                .Where(d => d.UserId == id)
                .Select(d => d.Id)
                .FirstOrDefaultAsync();

            return await dbContext.Appointments
                .Where(a => a.DentistId == dentistId)
                .OrderByDescending(a => a.Date)
                .Select(a => new AddAppointmentViewModel
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    PreferredHour = a.PreferredHour,
                    Date = a.Date,
                    Treatment = a.Treatment.Name,
                })
                .ToListAsync();
        }
    }
}
