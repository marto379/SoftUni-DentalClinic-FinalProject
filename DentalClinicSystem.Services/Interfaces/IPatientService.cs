using DentalClinicSystem.Web.ViewModels.Patient;
using DentalClinicSystem.Web.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Services.Interfaces
{
    public interface IPatientService
    {
        Task<BookingViewModel> GetAddPatientModelAsync();
        Task<IEnumerable<BookingViewModel>> GetPatientAppointmentsAsync(string id);
        Task<AddAppointmentViewModel> GetAddAppointmentAsync(string id);
        Task RemovePatientAsync(string id);
    }
}
