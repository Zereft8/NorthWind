

using Microsoft.Extensions.DependencyInjection;
using NorthWind.Application.Contracts;
using NorthWind.Application.Services;
using NorthWind.Infrastructure.Interfaces;
using NorthWind.Infrastructure.Repositories;

namespace NorthWind.Ioc.Dependencies
{
    public static class CustomerDependency
    {
        public static void AddCustomerDependency(this IServiceCollection service) 
        {
            service.AddScoped<ICustomersRepository, CustomersRepository>();
            service.AddTransient<ICustomerService, CustomerService>();
        }
    }
}
