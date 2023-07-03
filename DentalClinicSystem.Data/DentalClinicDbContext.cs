namespace DentalClinicSystem.Data
{
    using DentalClinicSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class DentalClinicDbContext : IdentityDbContext<IdentityUser>
    {
        public DentalClinicDbContext(DbContextOptions<DentalClinicDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dentist> Dentists { get; set; } = null!;

        public DbSet<Patient> Patients { get; set; } = null!;

        public DbSet<Treatment> Treatments { get; set; } = null!;

        public DbSet<Appointment> Appointments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssebmly = Assembly.GetAssembly(typeof(DentalClinicDbContext)) ??
                Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssebmly);

            base.OnModelCreating(builder);
        }
    }
}