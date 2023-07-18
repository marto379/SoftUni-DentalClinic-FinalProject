using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Data.Models
{
    public class DentistPatients
    {
        public DentistPatients()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Dentist))]
        [Required]
        public Guid DentistId { get; set; }

        public Dentist Dentist { get; set; } = null!;

        [ForeignKey(nameof(Patient))]
        [Required]
        public Guid PatientId { get; set; }

        public Patient Patient { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
