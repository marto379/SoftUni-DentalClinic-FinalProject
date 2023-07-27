using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Web.ViewModels.Reservation
{
    public class DentistViewModel
    {
        public string Id { get; set; }
        public string DentistFirstName { get; set; } = null!;

        public string DentistLastName { get; set; }
    }
}
