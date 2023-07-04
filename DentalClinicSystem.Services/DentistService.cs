using DentalClinicSystem.Data;
using DentalClinicSystem.Services.Interfaces;
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

        public async Task<bool> IsDentistExist(string userId)
        {
            bool result = await dbContext
                .Dentists
                .AnyAsync(d => d.UserId == userId);

            return result; 
        }
    }
}
