using DentalClinic.Web.Infrastructure.Extensions;
using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.Dentist;
using DentalClinicSystem.Web.ViewModels.Patient;
using DentalClinicSystem.Web.ViewModels.Reservation;
using Microsoft.AspNetCore.Authorization;
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
            var userId = User.GetId();
            var model = await patientService.GetPatientAppointmentsAsync(userId);
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddAppointment(string Id)
        {
            AddAppointmentViewModel model = await patientService.GetAddAppointmentAsync(Id);

            return View(model);
        }

        
        public async Task<IActionResult> Appointments(string id)
        {
            var model = await patientService.GetPatientAppointmentsAsync(id);
            return View(model);
        }

        public async Task<IActionResult> PatientProfile(string id)
        {
            PatientViewModel model = await patientService.GetUserAsync(id);
            return View(model);
        }


    }
}
