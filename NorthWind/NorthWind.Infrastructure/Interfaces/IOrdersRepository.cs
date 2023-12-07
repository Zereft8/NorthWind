
using NorthWind.Domain.Entities;
using NorthWind.Domain.Repository;
using NorthWind.Infrastructure.Models;
using System.Collections.Generic;

namespace NorthWind.Infrastructure.Interfaces
{
    public interface IOrdersRepository : IBaseRepository<Orders>
    {
        // Metodos exclusivos de orders
        List<OrderModel> GetOrders();
        OrderModel GetOrderById(int OrderID);


    }
}
