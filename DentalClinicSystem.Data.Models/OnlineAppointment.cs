using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalClinicSystem.Data.Models
{
    public class OnlineAppointment
    {
        public OnlineAppointment()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; } 

        [ForeignKey(nameof(OnlinePatient))]
        public Guid OnlinePatientId { get; set; }

        public OnlinePatient OnlinePatient { get; set; } = null!;

        public DateTime Date { get; set; }

        public DateTime Hour { get; set; }

        [ForeignKey(nameof(Treatment))]
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; } = null!;
    }
}