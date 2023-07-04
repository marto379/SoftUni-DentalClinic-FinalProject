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
    }
}
