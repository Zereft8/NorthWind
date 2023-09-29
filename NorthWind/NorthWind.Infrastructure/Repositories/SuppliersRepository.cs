using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Infrastructure.Repositories
{
    public class SuppliersRepository : ISuppliersRepository
    {
        public List<Suppliers> GetSuppliersBySupplierID(int supplierID)
        {
            throw new NotImplementedException();
        }

        public List<Suppliers> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Suppliers GetEntity(int Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Suppliers entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Suppliers entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Suppliers entity)
        {
            throw new NotImplementedException();
        }
    }
}
