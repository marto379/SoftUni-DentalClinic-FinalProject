using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Data.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        
        public decimal TotalPrice { get; set; }

        [Required]
        [ForeignKey(nameof(Patient))]
        public Guid PatientId { get; set; }

        [Required]
        public Patient Patient { get; set; } = null!;

        public ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();

    }
}
