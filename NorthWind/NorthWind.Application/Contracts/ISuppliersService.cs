using NorthWind.Application.Core;
using NorthWind.Application.Dtos.Base;
using NorthWind.Application.Dtos.Suppliers;


namespace NorthWind.Application.Contracts
{
    public interface ISuppliersService : IBaseServices<SupplierDtoAdd, SupplierDtoUpdate, SupplierDtoRemove>
    {

    }
}
