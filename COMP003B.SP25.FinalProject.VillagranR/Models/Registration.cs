namespace COMP003B.SP25.FinalProject.VillagranR.Models
{
    public class Registration
    {
    
        public int Id { get; set; }

        
        public int EventId { get; set; }

       
        public int StudentId { get; set; }

        
        public DateTime RegistrationDate { get; set; }

        
        public Event Event { get; set; }


        public Student Student { get; set; }
    }
}
