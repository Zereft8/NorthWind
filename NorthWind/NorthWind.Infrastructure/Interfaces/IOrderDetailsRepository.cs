using NorthWind.Domain.Entities;
using NorthWind.Domain.Repository;
using System.Collections.Generic;

namespace NorthWind.Infrastructure.Interfaces
{
    public interface IOrderDetailsRepository : IBaseRepository<OrderDetails>
    {
        OrderDetails GetEntitiesById(int orderID, int productID);
    }
}
