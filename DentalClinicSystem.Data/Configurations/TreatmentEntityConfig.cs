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
                Description = "Cosmetic teeth whitening uses hydrogen peroxide to gently bleach out stains from the enamel. This is a highly concentrated form that is much stronger than what you can get at the drugstore. This solution is applied as a gel or paste to the teeth.",
                SpecializationId = 1,
            };
            treatments.Add(treatment);

            treatment = new Treatment()
            {
                Id = 2,
                Name = "Tooth Extraction",
                Price = 79.99m,
                Description = "Tooth extraction refers to the complete removal of one or more teeth from the mouth. This is a procedure that is usually performed by a dental surgeon. Milk teeth may be removed from a child's mouth without intervention from the dentist as they loosen as a matter of course to give way to permanent teeth.",
                SpecializationId = 2
            };
            treatments.Add(treatment);

            treatment = new Treatment()
            {
                Id = 3,
                Name = "Root canal treatment",
                Price = 149.99m,
                Description = "Root canal treatment is a dental procedure that relieves pain caused by an infected or abscessed tooth. During the root canal process, the inflamed pulp is removed. The surfaces inside the tooth are then cleaned and disinfected, and a filling is placed to seal the space.",
                SpecializationId = 1
            };
            treatments.Add(treatment);

            treatment = new Treatment()
            {
                Id = 4,
                Name = "Caries treatment",
                Price = 149.99m,
                Description = "The most common and simplest treatment to combat caries is dental filling, which consists of cleaning the affected area until a cavity is formed, in order to eliminate the tissues that have been damaged by bacterial acidity. Once this process has been carried out, the cavity must be filled to return the tooth to its original shape.",
                SpecializationId = 1
            };
            treatments.Add(treatment);

            treatment = new Treatment()
            {
                Id = 5,
                Name = "Teeth cleaning",
                Price = 149.99m,
                Description = "Teeth cleaning (also known as prophylaxis, literally a preventive treatment of a disease) is a procedure for the removal of tartar (mineralized plaque) that may develop even with careful brushing and flossing, especially in areas that are difficult to reach in routine toothbrushing.",
                SpecializationId = 1
            };
            treatments.Add(treatment);

            treatment = new Treatment()
            {
                Id = 6,
                Name = "Prosthodontic treatment",
                Price = 149.99m,
                Description = "Prosthodontic treatments include veneers, crowns, bridges, dental implants and dentures. Treatment can be for a single tooth at a time but it can also be on a more comprehensive scale where it involves several and sometimes all teeth.",
                SpecializationId = 1
            };
            treatments.Add(treatment);

            treatment = new Treatment()
            {
                Id = 7,
                Name = "Orthodontics",
                Price = 149.99m,
                Description = "Orthodontics is a dental specialty focused on aligning your bite and straightening your teeth. You might need to see an orthodontist if you have crooked, overlapped, twisted or gapped teeth. Common orthodontic treatments include traditional braces, clear aligners and removable retainers.",
                SpecializationId = 1
            };
            treatments.Add(treatment);

            return treatments.ToArray();
        }
    }
}
