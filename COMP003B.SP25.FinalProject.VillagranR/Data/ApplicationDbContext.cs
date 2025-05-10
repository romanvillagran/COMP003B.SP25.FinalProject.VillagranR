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

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
    }
}
