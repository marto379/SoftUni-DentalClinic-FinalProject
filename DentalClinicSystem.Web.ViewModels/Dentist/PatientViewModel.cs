using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Web.ViewModels.Dentist
{
    public class PatientViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        [MaxLength(10, ErrorMessage = "Personal Id is invalid number")]
        [MinLength(10, ErrorMessage = "Personal Id is invalid number")]
        public string PersonalId { get; set; } = null!;
    }
}
