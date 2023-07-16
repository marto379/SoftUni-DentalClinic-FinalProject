using DentalClinicSystem.Web.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Web.ViewModels.Patient
{
    public class AddAppointmentViewModel
    {
        public string Id { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int TreatmentId { get; set; }

        public IEnumerable<TreatmentViewModel> Treatments { get; set; } = new List<TreatmentViewModel>();

    }
}
