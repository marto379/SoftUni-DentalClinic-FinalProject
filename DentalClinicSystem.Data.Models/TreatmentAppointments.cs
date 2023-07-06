using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Data.Models
{
    public class TreatmentAppointments
    {
        public int TreatmentId { get; set; }

        public Treatment Treatment { get; set; }

        public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; }
    }
}
