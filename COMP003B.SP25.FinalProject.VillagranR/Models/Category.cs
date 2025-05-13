using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.VillagranR.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Event> Events { get; set; }
    }
}
