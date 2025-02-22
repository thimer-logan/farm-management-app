using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrecisionFarming.Domain.Entities.Identity;

namespace PrecisionFarming.Infrastructure.DbContext
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed default roles
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new AppRole
                {
                    Id = Guid.NewGuid(),
                    Name = "Farmer",
                    NormalizedName = "FARMER"
                },
                new AppRole
                {
                    Id = Guid.NewGuid(),
                    Name = "Agronomist",
                    NormalizedName = "AGRONOMIST"
                }
            );
        }
    }
}
