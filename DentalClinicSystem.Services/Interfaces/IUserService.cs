using DentalClinicSystem.Web.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task AddUserToDentists(MakeDentistViewModel model,string id);
        Task<MakeDentistViewModel> GetUserViewModel();
        Task RemoveFromDentists(string id);
    }
}
