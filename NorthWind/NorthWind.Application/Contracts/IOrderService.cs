using NorthWind.Application.Core;
using NorthWind.Application.Dtos.Orders;
using System;
namespace NorthWind.Application.Contracts
{
    public interface IOrderService : IBaseServices<OrderDtoAdd, OrderDtoUpdate, OrderDtoRemove>

    {
       
    }
}