using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class VendorsDbContext : DbContext
    {
        public VendorsDbContext(DbContextOptions<VendorsDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasOne(c => c.Vendor)
                .WithMany(v => v.Categories)
                .HasForeignKey(c => c.Id_vendor);
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
    }
}