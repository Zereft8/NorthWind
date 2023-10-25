﻿using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NorthWind.Infrastructure.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly NorthWindContext context;

        public OrderDetailsRepository(NorthWindContext context)
        {

            this.context = context;

        }

        public List<OrderDetails> GetEntities()
        {
            return this.context.OrderDetails.ToList();
        }

        public OrderDetails GetEntity(int orderID)
        {
            return this.context.OrderDetails.Find(orderID);
        }
        public OrderDetails GetEntitiesById(int orderID, int productID)
        {
            var entities = this.context.OrderDetails.Find(orderID, productID);
            return entities;
        }

        public void Remove(OrderDetails entity)
        {
            this.context.OrderDetails.Remove(entity);
        }

        public void Save(OrderDetails entity)
        {
            this.context.OrderDetails.Add(entity);
        } 

        public void Update(OrderDetails entity)
        {
            this.context.OrderDetails.Update(entity);
        }
    }
}
