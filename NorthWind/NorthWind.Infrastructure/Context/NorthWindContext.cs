using Microsoft.EntityFrameworkCore;
using NorthWind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Infrastructure.Context
{
    public class NorthWindContext :DbContext
    {
        public NorthWindContext(DbContextOptions<NorthWindContext> options) :base(options)
        {

        }

        public DbSet<Customers> Customers { get; set; }
    }
}
