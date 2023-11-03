using Microsoft.EntityFrameworkCore;
using NorthWind.Domain.Entities;

namespace NorthWind.Infrastructure.Context
{
    public class NorthWindContext : DbContext
    {
        public NorthWindContext(DbContextOptions<NorthWindContext> options) :base(options)
        {

        }

        public DbSet<Orders> Orders { get; set; }
    }
}
