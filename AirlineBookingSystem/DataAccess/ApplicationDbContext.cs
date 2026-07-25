using AirlineBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingSystem.DataAccess
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<RewardAccount> RewardAccounts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial catalog = AirlineBookingSystem;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        }

        // Relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Flight --> Departure Airport

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.DepartureAirport)
                .WithMany()
                .HasForeignKey(f => f.DepartureAirportId)
                .OnDelete(DeleteBehavior.NoAction);



            // Flight --> Arrival Airport

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.ArrivalAirport)
                .WithMany()
                .HasForeignKey(f => f.ArrivalAirportId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
