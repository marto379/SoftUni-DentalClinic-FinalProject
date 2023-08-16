using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Web.ViewModels.Reservation
{
    public class OnlineBookingViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime Date { get; set; }

        public string Hour { get; set; }

        public string DentistId { get; set; } = null!;

        public string Dentist { get; set; } = null!;

        public IEnumerable<DentistViewModel> Dentists { get; set; } = new List<DentistViewModel>();

        public int TreatmentId { get; set; }

        public string Treatment { get; set; } = null!;

        public IEnumerable<TreatmentViewModel> Treatments { get; set; } = new List<TreatmentViewModel>();
    }
}
