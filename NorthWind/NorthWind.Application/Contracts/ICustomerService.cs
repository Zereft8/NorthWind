

using NorthWind.Application.Core;
using NorthWind.Application.Dtos.Customer;

namespace NorthWind.Application.Contracts
{
    public interface ICustomerService : IBaseService<CustomerDtoAdd, CustomerDtoUpdate, CustomerDtoRemove, string>
    {

    }
}
