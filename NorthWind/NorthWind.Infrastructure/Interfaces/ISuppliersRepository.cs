using NorthWind.Domain.Entities;
using NorthWind.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Infrastructure.Interfaces
{
    public interface ISuppliersRepository : IBaseRepository<Suppliers>
    {
        List<Suppliers> GetSuppliersBySupplierID(int supplierID);
    }
}
