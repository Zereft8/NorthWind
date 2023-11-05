
using Microsoft.EntityFrameworkCore.Internal;
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Core;
using NorthWind.Infrastructure.Interfaces;
using NorthWind.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;




namespace NorthWind.Infrastructure.Repositories
{
    public class OrdersRepository : BaseRepository<Orders>, IOrdersRepository
    {
        private readonly NorthWindContext context;
        public OrdersRepository(NorthWindContext context) : base(context)
        {
            this.context = context;
        }

        public OrderModel GetOrderById(int Id)
        {
            return this.GetOrders().SingleOrDefault(or => or.OrderID == Id);
        }

        public List<OrderModel> GetOrders()
        {
            var orders = this.GetEntities()
                                       .Where(or => !or.Eliminado)
                                        .Select(or => new OrderModel()
                                        {
                                            RequiredDate = or.RequiredDate,
                                            ShipName = or.ShipName,
                                            ShipAddress = or.ShipName,
                                            ShipCity = or.ShipCity,
                                            OrderID = or.OrderID


                                        }).ToList();

            return orders;
        }

        public override void Save(Orders entity)
        {
            context.Orders.Add(entity);
            context.SaveChanges();
        }
        public override void Update(Orders entity)
        {
            Orders orders = this.GetEntity(entity.OrderID);


            orders.OrderDate = entity.OrderDate;
            orders.RequiredDate = entity.RequiredDate;
            orders.ShipName = entity.ShipName;
            orders.ShipAddress = entity.ShipAddress;
            orders.ShipCity = entity.ShipCity;

            context.Orders.Update(orders);
            context.SaveChanges();

        }


        public override void Remove(Orders entity)
        {
            Orders orders = this.GetEntity(entity.OrderID);

            orders.OrderID = entity.OrderID;
            orders.Eliminado = entity.Eliminado;
            orders.FechaElimino = entity.FechaElimino;
            orders.IdUsuarioElimino = entity.IdUsuarioElimino;

            this.context.Orders.Update(orders);
            this.context.SaveChanges();

        }

        public List<OrderModel> GetOrders(int orderID)
        {
            throw new NotImplementedException();
        }
    }
}


    

    

