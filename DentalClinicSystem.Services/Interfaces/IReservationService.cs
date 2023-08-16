using DentalClinicSystem.Web.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Services.Interfaces
{
    public interface IReservationService
    {
        Task<OnlineBookingViewModel> GetBookingViewModelAsync();
        Task AddReservationAsync(OnlineBookingViewModel model, string userId);
        Task<ICollection<OnlineAppointmentsViewModel>> GetUserAppointmentsAsync(string userId);
    }
}
