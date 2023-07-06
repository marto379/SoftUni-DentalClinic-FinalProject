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
    public class TreatmentAppointmentConfig : IEntityTypeConfiguration<TreatmentAppointments>
    {
        public void Configure(EntityTypeBuilder<TreatmentAppointments> builder)
        {
            builder
                .HasKey(x => new { x.TreatmentId, x.AppointmentId });

            builder.HasOne(ta => ta.Treatment)
                .WithMany(t => t.TreatmentAppointments)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
