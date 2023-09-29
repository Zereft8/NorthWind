using Microsoft.EntityFrameworkCore.Internal;
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NorthWind.Infrastructure.Repositories
{
    public class SuppliersRepository : ISuppliersRepository 
    {
        private readonly NorthWindContext context;

        public SuppliersRepository(NorthWindContext context) 
        {
            this.context = context;
        }

        public List<Supplier> GetSuppliersBySupplierID(int SupplierID)
        {
            throw new NotImplementedException();
        }

        public List<Supplier> GetEntities()
        {
            return this.context.Suppliers.Where(st => !st.Eliminado).ToList();
        }

        public Supplier GetEntity(int SupplierID)
        {
            return this.context.Suppliers.Find(SupplierID);
        }

        public void Remove(Supplier entity)
        {
            this.context.Suppliers.Remove(entity);
        }

        public void Save(Supplier entity)
        {
            this.context.Suppliers.Add(entity);
        }

        public void Update(Supplier entity)
        {
           this.context.Suppliers.Update(entity);
        }

        public bool Exists(Expression<Func<Supplier, bool>> filter)
        {
            return this.context.Suppliers.Any(filter);
        }
    }
}
