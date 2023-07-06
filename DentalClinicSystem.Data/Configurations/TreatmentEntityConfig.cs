using DentalClinicSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicSystem.Data.Configurations
{
    public class TreatmentEntityConfig : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.Property(t => t.Price)
                .HasPrecision(18, 2);

            
            builder.HasData(GenerateTreatments());
        }

        private Treatment[] GenerateTreatments()
        {
            ICollection<Treatment> treatments = new List<Treatment>();

            Treatment treatment = new();
            treatment = new Treatment()
            {
                Id = 1,
                Name = "Whitening",
                Price = 99.00m,
                Description = "Super white teeth"
            };
            treatments.Add(treatment);

            treatment = new Treatment()
            {
                Id = 2,
                Name = "Tooth Extraction",
                Price = 79.99m,
                Description = "Painless extraction"
            };
            treatments.Add(treatment);

            treatment = new Treatment()
            {
                Id = 3,
                Name = "Root canal treatment",
                Price = 149.99m,
                Description = "Dental procedure used to treat infection at the centre of a tooth"
            };
            treatments.Add(treatment);

            return treatments.ToArray();
        }
    }
}
