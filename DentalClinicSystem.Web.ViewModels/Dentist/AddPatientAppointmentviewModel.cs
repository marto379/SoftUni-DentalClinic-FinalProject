using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Web.ViewModels.Dentist
{
    public class AddPatientAppointmentviewModel
    {
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime Hour { get; set; }

        public int TreatmentId { get; set; }

    }
}
