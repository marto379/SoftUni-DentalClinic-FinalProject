using DentalClinicSystem.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Data.Models
{
    public class Patient
    {
        public Patient()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(EntityValidationConstants.nameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(EntityValidationConstants.nameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string PersonalId { get; set; } = null!;

        public ICollection<DentistPatients> DentistPatients { get; set; } = new List<DentistPatients>();

        public ICollection<PatientAppointment> PatientsAppointments { get; set; } = new List<PatientAppointment>();

    }
}
