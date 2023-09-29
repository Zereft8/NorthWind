using NorthWind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthWind.Domain.Repository
{
    public class ISuppliersRepository : IBaseRepository<Supplier>
    {
        public List<Supplier> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Supplier GetEntity(int SupplierID)
        {
            throw new NotImplementedException();
        }

        public void Remove(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Supplier entity)
        {
            throw new NotImplementedException();
        }
        public bool Exists(Expression<Func<Supplier, bool>> filter) 
        { 
            throw new NotImplementedException(); 
        }
    }
}
