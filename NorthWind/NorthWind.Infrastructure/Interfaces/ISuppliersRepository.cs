using NorthWind.Domain.Entities;
using NorthWind.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthWind.Infrastructure.Interfaces
{
    public interface ISuppliersRepository : IBaseRepository<Supplier>
    {
        List<Supplier> GetSuppliersBySupplierID(int supplierID);

        bool Exists(Expression<Func<Supplier, bool>> filter);
    }
}
