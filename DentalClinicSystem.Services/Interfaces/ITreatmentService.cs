using DentalClinicSystem.Web.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Services.Interfaces
{
    public interface ITreatmentService
    {
        Task<IEnumerable<TreatmentViewModel>> AllTreatmentsAsync();
    }
}
