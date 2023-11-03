using Microsoft.EntityFrameworkCore;
using NorthWind.Domain.Entities;
using System;
using System.Collections.Generic;

namespace NorthWind.Infrastructure.Context
{
    public class NorthWindContext : DbContext
    {
        public NorthWindContext(DbContextOptions<NorthWindContext> options) :base(options)
        {

        }

        public DbSet<Supplier> Suppliers { get; set; }

        internal IEnumerable<object> GetEntities()
        {
            throw new NotImplementedException();
        }
    }
}
