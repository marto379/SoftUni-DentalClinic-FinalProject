using DentalClinicSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicSystem.Web.Controllers
{
    public class ReservationController : Controller
    {
        IReservationService reservationService;
        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }
        public IActionResult Booking()
        {
            var model = reservationService.GetBookingViewModelAsync();
            return View();
        }
    }
}
