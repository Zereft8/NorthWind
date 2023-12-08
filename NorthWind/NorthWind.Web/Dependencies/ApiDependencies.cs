using NorthWind.Web.WebService.Interface;
using NorthWind.Web.WebService.Service;

namespace NorthWind.Web.Dependencies
{
    public static class ApiDependencies
    {
        public static void AddCustomerDependencyApi(this IServiceCollection service)
        {
            service.AddTransient<ICustomerApiService, CustomerApiService>();

        }
    }
}
