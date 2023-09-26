
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace NorthWind.Infrastructure.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        public List<Customers> GetEntities()
        {
            throw new System.NotImplementedException();
        }

        public Customers GetEntity(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Customers entity)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Customers entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Customers entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
