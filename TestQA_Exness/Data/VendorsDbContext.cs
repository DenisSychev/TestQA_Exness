using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class VendorsDbContext : DbContext
    {
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        
        public VendorsDbContext(DbContextOptions<VendorsDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendor>().HasMany(v => v.Categories);
        }
        
        
    }
}