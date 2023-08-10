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
    public class PatientAppointmentEntityConfig : IEntityTypeConfiguration<PatientAppointment>
    {
        public void Configure(EntityTypeBuilder<PatientAppointment> builder)
        {
            builder
                .HasKey(x => new { x.PatientId, x.AppointmentId });

            builder
                .HasOne(pa => pa.Patient)
                .WithMany(p => p.PatientsAppointments)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
