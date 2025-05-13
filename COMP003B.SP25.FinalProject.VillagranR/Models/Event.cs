using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.VillagranR.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, StringLength(200)]
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int VenueId { get; set; }
        public Venue? Venue { get; set; }

        public ICollection<Registration>? Registrations { get; set; }
    }
}
