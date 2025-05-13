using COMP003B.SP25.FinalProject.VillagranR.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.SP25.FinalProject.VillagranR.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Venue> Venues { get; set; }
    }
}
