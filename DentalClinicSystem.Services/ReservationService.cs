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
    public class ReservationService : IReservationService
    {
        private readonly DentalClinicDbContext dbContext;
        public ReservationService(DentalClinicDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BookingViewModel> GetBookingViewModelAsync()
        {
            var model = new BookingViewModel();

            return model;
        }
    }
}
