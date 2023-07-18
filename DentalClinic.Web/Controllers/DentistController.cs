using DentalClinic.Web.Infrastructure.Extensions;
using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.Dentist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicSystem.Web.Controllers
{
    [Authorize]
    public class DentistController : Controller
    {
        IDentistService dentistService;
        public DentistController(
            IDentistService dentistService)
        {
            this.dentistService = dentistService;
        }

        [HttpGet]
        public async Task<IActionResult> AddPatient()
        {
            bool idDentist = await dentistService.IsDentistExist(User.GetId());
            if (!idDentist)
            {
                return RedirectToAction("Index", "Home");
            }

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
            bool idDentist = await dentistService.IsDentistExist(User.GetId());
            if (!idDentist)
            {
                return RedirectToAction("Index", "Home");
            }
            ICollection<AddPatientViewModel> model = await dentistService.GetAllPatientsByUserIdAsync(User.GetId());

            return View(model);
        }
    }
}
