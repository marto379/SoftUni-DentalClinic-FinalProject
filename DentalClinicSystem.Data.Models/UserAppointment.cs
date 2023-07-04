using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Data.Models
{
    public class UserAppointment
    {
        [ForeignKey(nameof(Patient))]
        public string PatientId { get; set; } = null!;

        public IdentityUser Patient { get; set; } = null!;

        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; } = null!;
    }
}
