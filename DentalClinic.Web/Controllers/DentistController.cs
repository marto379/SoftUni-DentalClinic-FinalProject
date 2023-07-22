using DentalClinic.Web.Infrastructure.Extensions;
using DentalClinicSystem.Data.Models;
using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.Dentist;
using DentalClinicSystem.Web.ViewModels.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicSystem.Web.Controllers
{
    [Authorize]
    public class DentistController : Controller
    {
        IDentistService dentistService;
        IPatientService patientService;
        ITreatmentService treatmentService;
        public DentistController(
            IDentistService dentistService, IPatientService patientService, ITreatmentService treatmentService)
        {
            this.dentistService = dentistService;
            this.patientService = patientService;
            this.treatmentService = treatmentService;
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
        [Authorize(Roles = "Dentist")]
        public async Task<IActionResult> AddAppointment(string id)
        {

            Patient patient = await dentistService.GetPatientAsync(id);
            var treatments = await treatmentService.AllTreatmentsAsync();

            var model = new AddAppointmentViewModel()
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Treatments = treatments
            };
            return View(model);
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

        public async Task<IActionResult> Delete(string id)
        {

            await patientService.RemovePatientAsync(id);

            return RedirectToAction("AllPatients", "Dentist");
        }
    }
}
