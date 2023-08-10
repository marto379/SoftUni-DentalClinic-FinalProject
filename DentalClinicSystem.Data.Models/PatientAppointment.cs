using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Data.Models
{
    public class PatientAppointment
    {
        [ForeignKey(nameof(Patient))]
        public Guid PatientId { get; set; }

        public Patient Patient { get; set; } = null!;

        [ForeignKey(nameof(Appointment))]
        public Guid AppointmentId { get; set; }

        public Appointment Appointment { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
