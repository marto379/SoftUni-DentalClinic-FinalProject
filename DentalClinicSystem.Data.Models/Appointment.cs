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
    public class Appointment
    {
        public Appointment()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime PreferredHour { get; set; }

        [ForeignKey(nameof(Patient))]
        public Guid PatientId { get; set; } 

        public Patient Patient { get; set; } = null!;


        [ForeignKey(nameof(Dentist))]
        [Required]
        public Guid DentistId { get; set; }
        [Required]
        public Dentist Dentist { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Treatment))]
        public int TreatmentId { get; set; }

        [Required]
        public Treatment Treatment { get; set; } = null!;

        
       
    }
}
