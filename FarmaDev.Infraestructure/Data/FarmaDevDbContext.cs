using FarmaDev.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace FarmaDev.Infraestructure.Data
{
    public class FarmaDevDbContext : DbContext
    {
        public FarmaDevDbContext(DbContextOptions<FarmaDevDbContext> options) : base(options)
        {
        }

        public DbSet<Pharmacy> Pharmacy { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FarmaDevDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
