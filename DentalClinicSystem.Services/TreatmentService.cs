using DentalClinicSystem.Data;
using DentalClinicSystem.Services.Interfaces;
using DentalClinicSystem.Web.ViewModels.Reservation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Services
{
    
    
    public class TreatmentService : ITreatmentService
    {
        private readonly DentalClinicDbContext dbContext;

        public TreatmentService(DentalClinicDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TreatmentViemModel>> AllTreatmentsAsync()
        {
            IEnumerable<TreatmentViemModel> allTreatments = await dbContext
                 .Treatments
                 .AsNoTracking()
                 .Select(t => new TreatmentViemModel
                 {
                     Id = t.Id,
                     Name = t.Name
                 }).ToArrayAsync();

            return allTreatments;
        }
    }
}
