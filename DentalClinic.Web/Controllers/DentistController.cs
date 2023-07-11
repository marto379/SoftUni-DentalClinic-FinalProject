using DentalClinic.Web.Infrastructure.Extensions;
using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.Dentist;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicSystem.Web.Controllers
{
    public class DentistController : Controller
    {
        IDentistService dentistService;
        public DentistController(
            IDentistService dentistService)
        {
            this.dentistService = dentistService;
        }

        [HttpGet]
        public IActionResult AddPatient()
        {
            var model = new AddPatientViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(AddPatientViewModel model)
        {
            var dentistId = User.GetId();

            await this.dentistService.AddPatientAsync(model, dentistId);

            return RedirectToAction("AllPatients", "Dentist");
        }

        [HttpGet]
        public async Task<IActionResult> AllPatients()
        {
            ICollection<AddPatientViewModel> model = await dentistService.GetAllPatientAsync();

            return View(model);
        }
    }
}
