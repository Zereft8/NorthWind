

using Microsoft.Extensions.DependencyInjection;
using NorthWind.Application.Contracts;
using NorthWind.Application.Services;
using NorthWind.Infrastructure.Interfaces;
using NorthWind.Infrastructure.Repositories;


namespace NorthWind.Ioc.Dependencies
{
   public static class OrderDependecy
    {
        public static void AddOrderDependency(this IServiceCollection service)
        {
            service.AddScoped<IOrdersRepository, OrdersRepository>();
            service.AddTransient<IOrderService, OrderService>();

        }
    }
}
