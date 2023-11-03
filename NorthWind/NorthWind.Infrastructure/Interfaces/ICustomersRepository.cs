
using NorthWind.Domain.Entities;
using NorthWind.Domain.Repository;
using NorthWind.Infrastructure.Models;
using System.Collections.Generic;

namespace NorthWind.Infrastructure.Interfaces
{
    public interface ICustomersRepository : IBaseRepository<Customer,string>
    {
        List<CustomerModel> GetCustomers();
        CustomerModel GetCustomerById(string Id);
        
    }
}
