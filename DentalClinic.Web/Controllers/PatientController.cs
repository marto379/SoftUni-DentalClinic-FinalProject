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

        // [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> All()
        {

            var model = await patientService.GetPatientAppointmentsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddAppointment(string Id)
        {
            AddAppointmentViewModel model = await patientService.GetAddAppointmentAsync(Id);

            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(AddEventViewModel model)
        //{
        //    await eventService.EditEventAsync(model);

        //    return RedirectToAction("All", "Event");
        //}


        public async Task<IActionResult> Delete(string id)
        {

            await patientService.RemovePatientAsync(id);

            return RedirectToAction("AllPatients", "Dentist");
        }
    }
}
