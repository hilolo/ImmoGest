using ImmoGest.Domain.Entities;
using ImmoGest.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ImmoGest.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Office> Offices { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
