using Microsoft.EntityFrameworkCore;
using NorthWind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NorthWind.Infrastructure.Context
{
    public class NorthWindContext : DbContext
    {
        public NorthWindContext(DbContextOptions<NorthWindContext> options) :base(options)
        {

        }

        //public DbSet<Customers> Customers { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>()
                .HasKey(od => new { od.OrderID, od.ProductID }); // Define la clave primaria compuesta

            // Otras configuraciones de tu modelo, como relaciones y propiedades, si las tienes.
        }

    }
}
