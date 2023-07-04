using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Web.ViewModels.Reservation
{
    public class BookingViewModel
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateTime PreferredHour { get; set; }

        public DateTime Date { get; set; } 

        public int TreatmentId { get; set; }

        public IEnumerable<TreatmentViemModel> Treatments { get; set; } = new List<TreatmentViemModel>();
    }
}
