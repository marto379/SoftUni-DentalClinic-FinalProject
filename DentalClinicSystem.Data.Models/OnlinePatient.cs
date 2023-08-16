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
    public class OnlinePatient
    {
        public OnlinePatient()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(OnlineUser))]
        [Required]
        public string OnlineUserId { get; set; }

        public IdentityUser OnlineUser { get; set; } = null!;

        public ICollection<OnlineAppointment> OnlineAppointments { get; set; } = new List<OnlineAppointment>();

    }
}
