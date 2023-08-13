using DentalClinic.Web.Infrastructure.Extensions;
using DentalClinicSystem.Data.Models;
using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.Dentist;
using DentalClinicSystem.Web.ViewModels.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static DentalClinicSystem.Common.NotificationMessagesConstants;

namespace DentalClinicSystem.Web.Controllers
{
    [Authorize(Roles = "Dentist, Admin")]
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

            var model = new AddPatientViewModel()
            {
                Id = Guid.NewGuid().ToString()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(AddPatientViewModel model, string id)
        {
            
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                string errosMessage = error.ErrorMessage;
            }
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "Invalid data input";
                return View(model);
            }
            var dentistId = User.GetId();

            await this.dentistService.AddPatientAsync(model, dentistId);

            return RedirectToAction("AllPatients", "Dentist");
        }

        [HttpGet]
        public async Task<IActionResult> AddAppointment(string id)
        {

            Patient patient = await dentistService.GetPatientAsync(id);
            var treatments = await treatmentService.AllTreatmentsAsync();

            var model = new AddAppointmentViewModel()
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Treatments = treatments,
                Date = DateTime.UtcNow,
                PreferredHour = DateTime.Parse(DateTime.Now.ToString("hh:mm"))
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddAppointment(AddAppointmentViewModel model, string id)
        {

            await dentistService.AddPatientAppointmentAsync(model, id);
            return RedirectToAction("PatientAppointments", "Dentist", new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> AllPatients()
        {
            
            ICollection<AddPatientViewModel> model = await dentistService.GetAllPatientsByUserIdAsync(User.GetId());

            return View(model);
        }

        public async Task<IActionResult> PatientAppointments(string id)
        {
            IEnumerable<AppointmentPatientViewModel> model = await dentistService.GetPatientAppointmentsByIdAsync(id);
            return View(model);
        }

        public async Task<IActionResult> AllAppointments()
        {
            var dentistId = User.GetId();
            var model = await dentistService.GetDentistAppointmentsAsync(dentistId);
            return View(model);
        }

        public async Task<IActionResult> Delete(string id)
        {

            await patientService.RemovePatientAsync(id);

            return RedirectToAction("AllPatients", "Dentist");
        }
    }
}
