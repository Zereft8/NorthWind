
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

        public Orders GetEntities(int OrderID, int CustomerID)
        {
            throw new NotImplementedException();
        }

        public Orders GetEntity(int OrderID)
        {
            return this.context.Orders.Find(OrderID);
        }

        public List<Orders> GetOrders()
        {
            return this.context.Orders.ToList();
        }

        public Orders GetOrders(int OrderID)
        {
            return this.context.Orders.Find(OrderID);
        }

        public void Remove(Orders entity)
        {
            this.context.Orders.Remove(entity);
        }

        public void Save(Orders entity)
        {
            this.context.Orders.Add(entity);
        }

        public void Update(Orders entity)
        {
            this.context.Orders.Update(entity);
        }
    }
}
