using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Data.Models
{
    public class OnlinePatientAppointments
    {
        public OnlinePatientAppointments()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [ForeignKey(nameof(OnlinePatient))]
        public Guid OnlinePatientId { get; set; }

        public OnlinePatient OnlinePatient { get; set; }

        [ForeignKey(nameof(OnlineAppointment))]
        public Guid OnlineAppointmentId { get; set; }

        public OnlineAppointment OnlineAppointment { get; set; }
    }
}
