using Microsoft.EntityFrameworkCore;
using NorthWind.Domain.Entities;

namespace NorthWind.Infrastructure.Context
{
    public class NorthWindContext : DbContext
    {
        public NorthWindContext(DbContextOptions<NorthWindContext> options) : base(options)
        {

        }

        //public DbSet<Customers> Customers { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Products> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderDetails>()
                .HasKey(od => new { od.OrderID, od.ProductID });

            modelBuilder.Entity<Products>()
                .HasKey(p => new { p.ProductID, p.SupplierID, p.CategoryID });

            modelBuilder.Entity<Products>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID);

;


            base.OnModelCreating(modelBuilder);
        }

    }
}

