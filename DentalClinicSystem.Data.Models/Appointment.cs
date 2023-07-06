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
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime PreferredHour { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public IdentityUser User { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Treatment))]
        public int TreatmentId { get; set; }

        [Required]
        public Treatment Treatment { get; set; } = null!;

        
    }
}
