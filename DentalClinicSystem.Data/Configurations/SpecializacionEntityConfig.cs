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
    public class SpecializacionEntityConfig : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.HasData(GenerateSpecializations());

        }
        private Specialization[] GenerateSpecializations()
        {
            ICollection<Specialization> specializations = new List<Specialization>();

            Specialization specialization = new();
            specialization = new Specialization()
            {
                Id = 1,
                Name = "prosthetic"

            };
            specializations.Add(specialization);

            specialization = new Specialization()
            {
                Id = 2,
                Name = "surgeon",

            };
            specializations.Add(specialization);

            return specializations.ToArray();
        }
    }
}
