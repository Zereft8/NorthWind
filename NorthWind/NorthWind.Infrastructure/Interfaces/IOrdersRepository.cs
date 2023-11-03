
using NorthWind.Domain.Entities;
using NorthWind.Domain.Repository;

namespace NorthWind.Infrastructure.Interfaces
{
    public interface IOrdersRepository : IOrdersRepository<Orders>
    {
        // Metodos exclusivos de orders
        Orders GetEntities(int OrderID, int CustomerID);

    }
}
