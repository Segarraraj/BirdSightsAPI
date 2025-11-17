using Microsoft.EntityFrameworkCore;

using RepositoryComponent.Models;

namespace RepositoryComponent
{
    public class BirdSightsDBContext : DbContext
    {
        public DbSet<BirdModel> Birds { get; set; }
        public DbSet<BirdSightModel> BirdSights { get; set; }

        public BirdSightsDBContext(DbContextOptions<BirdSightsDBContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BirdModel>()
                .HasMany(e => e.Sights)
                .WithOne(e => e.Bird)
                .HasForeignKey(e => e.BirdId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
