
using NorthWind.Domain.Entities;
using NorthWind.Domain.Repository;

namespace NorthWind.Infrastructure.Interfaces
{
    public interface ICustomersRepository : IBaseRepository<Customer>
    {
        // Metodos exclusivos de customers

    }
}
