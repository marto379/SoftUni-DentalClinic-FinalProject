using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Web.ViewModels.Dentist
{
    public class AppointmentPatientViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Treatment { get; set; }

        public string Date { get; set; }

        public string Hour { get; set; }
    }
}
