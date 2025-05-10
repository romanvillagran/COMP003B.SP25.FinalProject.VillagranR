using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.VillagranR.Models
{
    public class Mechanic
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Specialty { get; set; }

        [Required]
        [Range(0, 50)]
        public int YearsExperience { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
