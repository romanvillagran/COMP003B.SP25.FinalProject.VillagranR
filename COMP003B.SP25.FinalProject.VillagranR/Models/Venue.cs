using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.VillagranR.Models
{
    public class Venue
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Venue name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Range(1, 10000, ErrorMessage = "Capacity must be 1-10,000")]
        public int Capacity { get; set; }

        public List<Event> Events { get; set; }
    }
}
