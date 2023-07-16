using DentalClinicSystem.Data;
using DentalClinicSystem.Data.Models;
using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.Dentist;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Services
{
    public class DentistService : IDentistService
    {
        private readonly DentalClinicDbContext dbContext;
        public DentistService(DentalClinicDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddPatientAsync(AddPatientViewModel model, string userId)
        {
            var dentist = await dbContext.Dentists
                .Where(d => d.UserId == userId)
                .FirstOrDefaultAsync();

            var dentistId = dentist.Id;
            
            Patient patient = new Patient
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                DentistId = dentistId
            };

            await dbContext.Patients.AddAsync(patient);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<AddPatientViewModel>> GetAllPatientAsync()
        {
            return await dbContext.Patients
                .Select(p => new AddPatientViewModel
                {
                    Id = p.Id.ToString(),
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    PhoneNumber = p.PhoneNumber,
                    Gender = p.Gender
                }).ToListAsync();
        }

        public async Task<bool> IsDentistExist(string userId)
        {
            bool result = await dbContext
                .Dentists
                .AnyAsync(d => d.UserId == userId);

            return result; 
        }
    }
}
