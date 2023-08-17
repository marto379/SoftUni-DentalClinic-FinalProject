using DentalClinicSystem.Data;
using DentalClinicSystem.Data.Models;
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
    public class ReservationService : IReservationService
    {
        private readonly DentalClinicDbContext dbContext;
        public ReservationService(DentalClinicDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddReservationAsync(OnlineBookingViewModel model, string patientId)
        {
            var patientExist = await dbContext.OnlinePatients
                .AnyAsync(p => p.OnlineUserId == patientId);


            OnlinePatientAppointments OPappointment = new();


            if (patientExist == false)
            {
                OnlinePatient patient = new OnlinePatient()
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    OnlineUserId = patientId,
                    PhoneNumber = model.PhoneNumber
                };
                OPappointment.OnlinePatientId = patient.Id;
                await dbContext.OnlinePatients.AddAsync(patient);
            }
            else
            {
                var patient = await dbContext.OnlinePatients
                    .Where(p => p.OnlineUserId == patientId)
                    .FirstOrDefaultAsync();

                OPappointment.OnlinePatientId = patient.Id;
            }

            OnlineAppointment appointmentToAdd = new OnlineAppointment()
            {

                OnlinePatientId = OPappointment.OnlinePatientId,
                Date = model.Date,
                Hour = DateTime.Parse(model.Hour),
                TreatmentId = model.TreatmentId,
                DentistId = Guid.Parse(model.DentistId)
            };

            OPappointment.OnlineAppointmentId = appointmentToAdd.Id;

            await dbContext.OnlineAppointments.AddAsync(appointmentToAdd);
            await dbContext.OnlinePatientAppointments.AddAsync(OPappointment);
            await dbContext.SaveChangesAsync();
        }

        public async Task<OnlineBookingViewModel> GetBookingViewModelAsync()
        {
            var treatments = await dbContext.Treatments
                .Select(t => new TreatmentViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                }).ToListAsync();

            var dentists = await dbContext.Dentists
                .Select(d => new DentistViewModel
                {
                    Id = d.Id.ToString(),
                    DentistFirstName = d.FirstName,
                    DentistLastName = d.LastName
                }).ToListAsync();

            var model = new OnlineBookingViewModel()
            {
                Date = DateTime.UtcNow,
                Hour = RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)).ToString("hh:mm"),
                Dentists = dentists,
                Treatments = treatments
            };

            return model;
        }

        public async Task<ICollection<OnlineAppointmentsViewModel>> GetUserAppointmentsAsync(string userId)
        {
            return await dbContext.OnlinePatientAppointments
                .Where(op => op.OnlinePatient.OnlineUserId == userId)
                .Select(op => new OnlineAppointmentsViewModel
                {
                    FirstName = op.OnlinePatient.FirstName,
                    LastName = op.OnlinePatient.LastName,
                    Date = op.OnlineAppointment.Date,
                    Hour = op.OnlineAppointment.Hour.ToString("H:mm"),
                    Treatment = op.OnlineAppointment.Treatment.Name,
                    Dentist = $"{op.OnlineAppointment.Dentist.FirstName} {op.OnlineAppointment.Dentist.LastName}"
                }).ToListAsync();
        }

        DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }
    }
}
