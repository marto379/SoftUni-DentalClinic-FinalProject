using DentalClinicSystem.Data.Models;
using DentalClinicSystem.Web.ViewModels.Dentist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Services.Interfaces
{
    public interface IDentistService
    {
        Task<bool> IsDentistExist(string userId);
        Task AddPatientAsync(AddPatientViewModel model, string dentistId);
        Task<ICollection<AddPatientViewModel>> GetAllPatientsByUserIdAsync(string userId);
        Task<Patient> GetPatientAsync(string id);
    }
}
