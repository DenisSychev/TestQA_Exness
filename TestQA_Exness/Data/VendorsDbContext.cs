using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class VendorsDbContext : DbContext
    {
        public VendorsDbContext(DbContextOptions<VendorsDbContext> options):base(options)
        {

        }
        
        public DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(vendor => vendor.id_primary);
                
                entity.Property(vendor => vendor.id);

                entity.Property(vendor => vendor.name);
                
                entity.Property(vendor => vendor.rating);
            });
        }
    }
}