
using Microsoft.Extensions.DependencyInjection;
using NorthWind.Application.Contracts;
using NorthWind.Application.Services;
using NorthWind.Domain.Repository;
using NorthWind.Infrastructure.Repositories;

namespace NorthWind.Ioc.Dependencies
{
    public static class SupplierDependency
    {
        public static void AddSupplierDependency(this IServiceCollection service)
        {
            service.AddScoped<ISuppliersRepository, SuppliersRepository>();
            service.AddTransient<ISuppliersService, SuppliersService>();
        }
    }
}
