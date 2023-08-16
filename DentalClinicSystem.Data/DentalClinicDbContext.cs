namespace DentalClinicSystem.Data
{
    using DentalClinicSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class DentalClinicDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DentalClinicDbContext(DbContextOptions<DentalClinicDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Dentist> Dentists { get; set; } = null!;

        public DbSet<Patient> Patients { get; set; } = null!;

        public DbSet<Treatment> Treatments { get; set; } = null!;

        public DbSet<Appointment> Appointments { get; set; } = null!;

        
        public DbSet<DentistPatients> DentistPatients { get; set; }

        public DbSet<PatientAppointment> PatientsAppointments { get; set; }

        public DbSet<OnlinePatient> OnlinePatients { get; set; }

        public DbSet<OnlineAppointment> OnlineAppointments { get; set; }

        public DbSet<OnlinePatientAppointments> OnlinePatientAppointments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssebmly = Assembly.GetAssembly(typeof(DentalClinicDbContext)) ??
                Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssebmly);

            //builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });


            ////a hasher to hash the password before seeding the user to the db
            //var hasher = new PasswordHasher<IdentityUser>();


            ////Seeding the User to AspNetUsers table
            //builder.Entity<IdentityUser>().HasData(
            //    new IdentityUser
            //    {
            //        Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
            //        UserName = "admin@abv.bg",
            //        NormalizedUserName = "ADMIN@ABV.BG",
            //        PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
            //    }
            //);


            ////Seeding the relation between our user and role to AspNetUserRoles table
            //builder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
            //        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            //    }
            //);

           
            base.OnModelCreating(builder);
        }
    }
}