using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthWind.Domain.Repository
{
    public interface ISuppliersRepository : IBaseRepository<Supplier>
    {
       List<SuppliersModel>GetSuppliersBySuppliersID(int SupplierID);
       List<SuppliersModel> GetSuppliers();
       SuppliersModel GetSupplierBySupplierID(int Id);
    }
}
