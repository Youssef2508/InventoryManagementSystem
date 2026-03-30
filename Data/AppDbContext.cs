using Microsoft.EntityFrameworkCore;
using Project_2.Models;

namespace Project_2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // 🔥 Product Config
            modelBuilder.Entity<Product>(entity => 
            { 
                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100); 

                entity.Property(p => p.Price)
                    .HasColumnType("decimal(18,2)");

                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasOne(p => p.Supplier)
                    .WithMany(s => s.Products)
                    .HasForeignKey(p => p.SupplierId)
                    .OnDelete(DeleteBehavior.Restrict); });
            
            // 🔥 Category Config
            modelBuilder.Entity<Category>(entity => 
            { 
                entity.Property(c => c.Name)
                    .IsRequired() 
                    .HasMaxLength(100);
                
                entity.HasIndex(c => c.Name) 
                    .IsUnique(); });
            
            // 🔥 Supplier Config
            modelBuilder.Entity<Supplier>(entity => 
            { 
                entity.Property(s => s.Name) 
                    .IsRequired() 
                    .HasMaxLength(100); 
                
                entity.Property(s => s.ContactEmail) 
                    .IsRequired() 
                    .HasMaxLength(150);
            }); 
        }
    }
}
