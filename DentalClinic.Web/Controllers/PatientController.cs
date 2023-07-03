using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicSystem.Web.Controllers
{
    public class PatientController : Controller
    {
        private IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            BookingViewModel model = new();

            return View(model);
        }
    }
}
