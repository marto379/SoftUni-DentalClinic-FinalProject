using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Web.ViewModels.User
{
    public class MakeDentistViewModel
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Specialization { get; set; }

        public int SpecializationId { get; set; }

        public ICollection<SpecializationViewModel> Specializations { get; set; } = new List<SpecializationViewModel>();
    }
}
