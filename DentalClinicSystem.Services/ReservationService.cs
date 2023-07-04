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
            //var preferredHour = DateTime.TryParse(model.PreferredHour, out DateTime PreferredHour);

            Appointment appointmentToAdd = new Appointment()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserId = userId,
                PreferredHour = DateTime.Parse(model.PreferredHour.ToString("t")),
                Date = DateTime.Parse(model.Date.ToString("d")),
                TreatmentId = model.TreatmentId,
            };

            await dbContext.Appointments.AddAsync(appointmentToAdd);
            await dbContext.SaveChangesAsync();
        }

        public async Task<BookingViewModel> GetBookingViewModelAsync()
        {
            var treatments = await dbContext.Treatments
                .Select(t => new TreatmentViemModel
                {
                    Id = t.Id,
                    Name = t.Name,
                }).ToListAsync();

            var model = new BookingViewModel()
            {
                Treatments = treatments
            };

            return model;
        }
    }
}
