
using NorthWind.Domain.Entities;
using NorthWind.Domain.Repository;
using System.Collections.Generic;

namespace NorthWind.Infrastructure.Interfaces
{
    public interface ICustomersRepository : IBaseRepository<Customer,string>
    {
        //List<Customer> GetCustomersByPostalCode(string postalCode);
        
    }
}
