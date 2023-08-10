namespace DentalClinicSystem.Web.Controllers
{
    using DentalClinic.Web.Infrastructure.Extensions;
    using DentalClinicSystem.Services.Interfaces;
    using DentalClinicSystem.Web.ViewModels.Reservation;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ReservationController : BaseController
    {
        IReservationService reservationService;
        ITreatmentService treatmentService;
        public ReservationController(IReservationService reservationService, ITreatmentService treatmentService)
        {
            this.reservationService = reservationService;
            this.treatmentService = treatmentService;
        }


        [HttpGet]
        public async Task<IActionResult> Booking()
        {
            var viewModel = await reservationService.GetBookingViewModelAsync();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Booking(BookingViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("", "Invalid data!");
            //    return View(model);
            //}
            try
            {

                var userId = User.GetId();

                await this.reservationService.AddReservationAsync(model, userId);
            }
            catch (InvalidDataException e)
            {
                ModelState.AddModelError("", e.Message);

                return View(model);
            }


            return RedirectToAction("All", "Patient");
        }
    }
}
