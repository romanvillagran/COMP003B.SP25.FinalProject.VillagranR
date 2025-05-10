using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.VillagranR.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        public int VehicleId { get; set; }
        public int ServiceId { get; set; }

        public Vehicle? Vehicle { get; set; }
        public Service? Service { get; set; }
    }
}
