using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicSystem.Web.Controllers
{
    public class PatientController : BaseController
    {
        private IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        public async Task<IActionResult> All()
        {
            var model = await patientService.GetPatientAppointmentsAsync();
            return View(model);
        }

        //[HttpGet]
        //public async Task<IActionResult> Add()
        //{
        //    BookingViewModel model = new();

        //    return View(model);
        //}
    }
}
