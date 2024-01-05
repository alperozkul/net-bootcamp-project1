using Microsoft.EntityFrameworkCore;
using NetBootcamp_Project_1.Models;

namespace NetBootcamp_Project_1.Context
{
    public class TechCareerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=NetBootcamp-Project1;Trusted_Connection=True; TrustServerCertificate=True");
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

    }
}
