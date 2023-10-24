using NorthWind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthWind.Domain.Repository
{
    public interface ISuppliersRepository : IBaseRepository<Supplier>
    {
       List<Supplier>GetSuppliersBySuppliersID(int  SupplierID);
    }
}
