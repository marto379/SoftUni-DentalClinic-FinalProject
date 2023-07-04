using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicSystem.Web.Controllers
{
    public class ReservationController : BaseController
    {
        IReservationService reservationService;
        ITreatmentService treatmentService;
        public ReservationController(IReservationService reservationService, ITreatmentService treatmentService)
        {
            this.reservationService = reservationService;
            this.treatmentService = treatmentService;
        }


        public async Task<IActionResult> Booking()
        {
            BookingViewModel viewModel = new BookingViewModel()
            {
                Treatments = await treatmentService.AllTreatmentsAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Booking(BookingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid data!");
                return View(model);
            }
            try
            {

                var userId = GetUserId();

                await this.reservationService.AddReservationAsync(model, userId);
            }
            catch (InvalidDataException e)
            {
                ModelState.AddModelError("", e.Message);

                return View(model);
            }


            return RedirectToAction("Booking", "Reservation");
        }
    }
}
