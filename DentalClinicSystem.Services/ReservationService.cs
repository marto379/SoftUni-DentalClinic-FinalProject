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

        public async Task AddReservationAsync(BookingViewModel model, string userId)
        {
           
            Appointment appointmentToAdd = new Appointment()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserId = userId,
                PreferredHour = DateTime.Parse(model.PreferredHour.ToString()),
                Date = model.Date,
                TreatmentId = model.TreatmentId,
                DentistId = Guid.Parse(model.DentistId)
            };

            await dbContext.Appointments.AddAsync(appointmentToAdd);
            await dbContext.SaveChangesAsync();
        }

        public async Task<BookingViewModel> GetBookingViewModelAsync()
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

            var model = new BookingViewModel()
            {
                Date = DateTime.UtcNow,
                PreferredHour = RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)).ToString("hh:mm"),
                Dentists = dentists,
                Treatments = treatments
            };

            return model;
        }

        DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }
    }
}
