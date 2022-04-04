using Microsoft.EntityFrameworkCore;
using VoyagesAPI.Entities;

namespace VoyagesAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Port> Ports { get; set; }

        public DbSet<Ship> Ships { get; set; }

        public DbSet<Voyage> Voyages { get; set; }

    }
}
