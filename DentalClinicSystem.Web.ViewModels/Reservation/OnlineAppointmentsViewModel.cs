using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Web.ViewModels.Reservation
{
    public class OnlineAppointmentsViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Date { get; set; }

        public string Hour { get; set; }

        public string Treatment { get; set; }
    }
}
