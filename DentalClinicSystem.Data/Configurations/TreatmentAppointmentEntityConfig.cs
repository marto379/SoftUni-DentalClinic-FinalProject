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
    public class TreatmentAppointmentEntityConfig : IEntityTypeConfiguration<TreatmentAppoinment>
    {
        public void Configure(EntityTypeBuilder<TreatmentAppoinment> builder)
        {
            builder
                .HasKey(x => new { x.TreatmentId, x.AppointmentId });
        }
    }
}
