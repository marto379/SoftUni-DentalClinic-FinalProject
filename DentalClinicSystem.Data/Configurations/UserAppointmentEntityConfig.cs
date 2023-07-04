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
    public class UserAppointmentEntityConfig : IEntityTypeConfiguration<UserAppointment>
    {
        public void Configure(EntityTypeBuilder<UserAppointment> builder)
        {
            builder
                .HasKey(x => new { x.PatientId, x.AppointmentId });

            builder
                .HasOne(u => u.Patient)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
