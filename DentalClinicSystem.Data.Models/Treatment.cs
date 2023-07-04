using DentalClinicSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Data.Models
{
    public class Treatment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EntityValidationConstants.nameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [MaxLength(EntityValidationConstants.descriptionMaxLength)]
        public string? Description { get; set; }

        public ICollection<Appointment> Treatments { get; set; } = new List<Appointment>();
    }
}
