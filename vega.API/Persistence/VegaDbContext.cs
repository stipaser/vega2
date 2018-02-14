using Microsoft.EntityFrameworkCore;
using vega.API.Core.Models;

namespace vega.API.Persistence
{
    public class VegaDbContext : DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {            
        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Photo> Photos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<VehicleFeature>()
            .HasKey(vf => new { vf.VehicleId, vf.FeatureId });   

            modelBuilder.Entity<VehicleFeature>()
            .HasOne(vf => vf.Vehicle)
            .WithMany(vf => vf.VehicleFeatures)
            .HasForeignKey(vf => vf.VehicleId);

            modelBuilder.Entity<VehicleFeature>()
            .HasOne(vf => vf.Feature)
            .WithMany(vf => vf.VehicleFeatures)
            .HasForeignKey(vf => vf.FeatureId);
        }
    }
}