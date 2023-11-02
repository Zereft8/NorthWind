
using System.Collections.Generic;

namespace NorthWind.Domain.Repository
{
    public interface IOrdersRepository<Orders> where Orders : class
    {

        void Save(Orders orders);
        void Update(Orders orders);
        void Remove (Orders orders);
        List<Orders> GetOrders();
        Orders GetOrders(int Id);



    }
}
