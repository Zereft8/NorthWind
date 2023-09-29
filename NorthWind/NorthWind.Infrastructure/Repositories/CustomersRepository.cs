
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NorthWind.Infrastructure.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {

        private readonly NorthWindContext context;

        public CustomersRepository(NorthWindContext context) 
        {

            this.context = context;
        
        }

        public List<Customer> GetEntities()
        {
            return this.context.Customers.Where(cm => !cm.Eliminado).ToList();
        }

        public Customer GetEntity(string Id)
        {
            return this.context.Customers.Find(Id);
        }

        public void Remove(Customer entity)
        {
            this.context.Customers.Remove(entity);
        }

        public void Save(Customer entity)
        {
            this.context.Customers.Add(entity);
        }

        public void Update(Customer entity)
        {
            this.context.Customers.Update(entity);
        }
    }
}
