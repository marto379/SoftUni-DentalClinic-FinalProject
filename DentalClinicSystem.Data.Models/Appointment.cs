using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Data.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        public string PatientName { get; set; } = null!;

        public DateTime PreferredHour { get; set; }

        
        public ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
    }
}
