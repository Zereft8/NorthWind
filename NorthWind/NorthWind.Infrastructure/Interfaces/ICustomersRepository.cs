
using NorthWind.Domain.Entities;
using NorthWind.Domain.Repository;

namespace NorthWind.Infrastructure.Interfaces
{
    public interface ICustomersRepository : IBaseRepository<Customer, string>
    {
        // Metodos exclusivos de customers

    }
}
