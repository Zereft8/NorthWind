using Microsoft.Extensions.DependencyInjection;
using NorthWind.Application.Contracts;
using NorthWind.Application.Services;
using NorthWind.Infrastructure.Interfaces;
using NorthWind.Infrastructure.Repositories;

namespace NorthWind.Ioc.Dependencies
{
    public static class CategoryDependency
    {
        public static void AddCategoryDependency(this IServiceCollection service)
        {
            service.AddScoped<ICategoriesRepositry, CategoriesRepository>();
            service.AddTransient<ICategoryService, CategoryService>();
        }
    }
}