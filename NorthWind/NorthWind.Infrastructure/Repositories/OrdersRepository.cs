
using Microsoft.EntityFrameworkCore.Internal;
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NorthWind.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly NorthWindContext context;
        public OrdersRepository (NorthWindContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<Orders, bool>> filter)
        {
            return this.context.Orders.Any(filter);
        }

      

        public Orders GetEntity(int Id)
        {
            return this.context.Orders.Find(Id);
        }

        public List<Orders> GetOrders()
        {
            return this.context.Orders.Where(or => !or.Eliminado).ToList();
        }

        public Orders GetOrders(int Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Orders orders)
        {
            this.context.Orders.Remove(orders);
        }

        public void Save(Orders orders)
        {
            this.context.Orders.Add(orders);
        }

        public void Update(Orders orders)
        {
            this.context.Orders.Update(orders);
        }
    }
}
