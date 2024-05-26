using Microsoft.EntityFrameworkCore;
using WebApplication2.models;

namespace TripAPI.Data
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Client_Trip> Client_Trips { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Country_Trip> Country_Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client_Trip>()
                .HasKey(ct => new { ct.IdClient, ct.IdTrip });

            modelBuilder.Entity<Country_Trip>()
                .HasKey(ct => new { ct.IdCountry, ct.IdTrip });

            base.OnModelCreating(modelBuilder);
        }
    }
}