using NorthWind.Domain.Entities;
using NorthWind.Domain.Repository;
using System.Threading.Tasks;

namespace NorthWind.Infrastructure.Interfaces
{
    public interface ICategoriesRepositry : IBaseRepository<Categories>
    {
        Task<bool> DeleteCategory(int Id);
    }
}
