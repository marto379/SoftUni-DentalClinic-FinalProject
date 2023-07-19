namespace DentalClinicSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using DentalClinicSystem.Common;
    using Microsoft.AspNetCore.Identity;
    public class Dentist
    {
        public Dentist()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(EntityValidationConstants.nameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(EntityValidationConstants.nameMaxLength)]
        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        [Required]
        public IdentityUser User { get; set; } = null!;

        public Specialization Specialization { get; set; } = null!;

        [ForeignKey(nameof(Specialization))]
        [Required]
        public int SpecializationId { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public ICollection<DentistPatients> DentistPatients { get; set; } = new List<DentistPatients>();
    }
}
