using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Data.Models
{
    public class TreatmentAppoinment
    {
        [ForeignKey(nameof(Treatment))]
        public int TreatmentId { get; set; }

        public Treatment Treatment { get; set; } = null!;

        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; } = null!;
    }
}
