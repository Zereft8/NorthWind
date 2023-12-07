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
            modelBuilder.Entity<OrderDetails>()
                .HasKey(od => new { od.OrderID, od.ProductID }); // Define la clave primaria compuesta

            modelBuilder.Entity<Products>()
                .HasKey(p => new { p.CategoryID, p.SupplierID }); // Define composite primary key


            //modelBuilder.Entity<Categories>()
            //    .HasMany(category => category.Products)
            //    .WithOne(product => product.Category)
            //    .HasForeignKey(product => new { product.CategoryID, product.SupplierID })
            //    .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }
}

