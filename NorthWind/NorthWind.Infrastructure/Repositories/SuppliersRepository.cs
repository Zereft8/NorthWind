using Microsoft.EntityFrameworkCore.Internal;
using NorthWind.Domain.Entities;
using NorthWind.Domain.Repository;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NorthWind.Infrastructure.Repositories
{
    public class SuppliersRepository : BaseRepository<Supplier> ,ISuppliersRepository
    {
        private readonly NorthWindContext context;

        public SuppliersRepository(NorthWindContext context) : base(context) 
        {
            this.context = context;

        }
        public List<Supplier> GetSuppliersBySuppliersID(int SupplierID)
            {
                throw new NotImplementedException();
            }

        public override void Save(Supplier entity)
        {
            context.Suppliers.Add(entity);
            context.SaveChanges();
        }
        public override void Update(Supplier entity)
        {
            var supplierToUpdate = base.GetEntity(entity.SupplierID);
            supplierToUpdate.CompanyName = entity.CompanyName;
            supplierToUpdate.Address = entity.Address;
            supplierToUpdate.Country = entity.Country;
            supplierToUpdate.ContactName = entity.ContactName;
            supplierToUpdate.City = entity.City;
            supplierToUpdate.Phone = entity.Phone;
            supplierToUpdate.FechaMod = entity.FechaMod;
            supplierToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
            supplierToUpdate.SupplierID = entity.SupplierID;
            context.Suppliers.Update(supplierToUpdate);
            context.SaveChanges();
        }
    }
}
