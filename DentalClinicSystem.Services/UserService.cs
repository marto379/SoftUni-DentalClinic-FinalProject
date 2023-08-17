using DentalClinicSystem.Data;
using DentalClinicSystem.Data.Models;
using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Services
{
    public class UserService : IUserService
    {
        private readonly DentalClinicDbContext dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(DentalClinicDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this._userManager = userManager;
        }

        public async Task AddUserToDentists(MakeDentistViewModel model, string id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);

            Dentist dentist = new()
            {
                UserId = user.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                SpecializationId = model.SpecializationId
            };

            await dbContext.Dentists.AddAsync(dentist);
            await dbContext.SaveChangesAsync();
        }

        public async Task<MakeDentistViewModel> GetUserViewModel()
        {
            var specializations = await dbContext.Specializations
                .Select(s => new SpecializationViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToListAsync();

            var model = new MakeDentistViewModel()
            {
                Specializations = specializations
            };

            return model;
        }

        public async Task RemoveFromDentists(string id)
        {
            var dentist = await dbContext.Dentists
                 .FirstOrDefaultAsync(d => d.UserId == id);

            if (dentist != null)
            {
                dbContext.Dentists.Remove(dentist);
                await dbContext.SaveChangesAsync();
            }
            return;
        }
    }
}
