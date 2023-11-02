
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace NorthWind.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        public List<Orders> GetEntities()
        {
            throw new System.NotImplementedException();
        }

        public Orders GetEntity(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Orders entity)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Orders entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Orders entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
