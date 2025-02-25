using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrecisionFarming.Domain.Entities;
using PrecisionFarming.Domain.Entities.Identity;
using System.Text.Json;

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

        public DbSet<Farm> Farms { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FieldCrop> FieldsCrops { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<CropVariety> CropVarieties { get; set; }
        public DbSet<FarmAccess> FarmAccesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed default roles
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = Guid.Parse("f355d1f0-2c69-4cbb-adb6-ff31c8833972"),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new AppRole
                {
                    Id = Guid.Parse("53728ad8-bda9-419c-95da-f844eaf21e87"),
                    Name = "Farmer",
                    NormalizedName = "FARMER"
                },
                new AppRole
                {
                    Id = Guid.Parse("f788b7ff-bd81-46d9-af7c-b1acfb98a527"),
                    Name = "Agronomist",
                    NormalizedName = "AGRONOMIST"
                }
            );

            // Seed crops and crop varieties
            string cropsJson = File.ReadAllText("Data/crops.json");
            var crops = JsonSerializer.Deserialize<List<Crop>>(cropsJson);
            if (crops != null)
            {
                foreach (var crop in crops)
                {
                    modelBuilder.Entity<Crop>().HasData(crop);
                }
            }

            string cropVarietiesJson = File.ReadAllText("Data/cropVarieties.json");
            var cropVarieties = JsonSerializer.Deserialize<List<CropVariety>>(cropVarietiesJson);
            if (cropVarieties != null)
            {
                foreach (var cropVariety in cropVarieties)
                {
                    modelBuilder.Entity<CropVariety>().HasData(cropVariety);
                }
            }
        }
    }
}
