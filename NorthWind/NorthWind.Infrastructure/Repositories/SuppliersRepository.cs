using Microsoft.EntityFrameworkCore.Internal;
using NorthWind.Domain.Entities;
using NorthWind.Domain.Repository;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Core;
using NorthWind.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NorthWind.Infrastructure.Repositories
{
    public class SuppliersRepository : BaseRepository<Supplier>, ISuppliersRepository
    {
        private readonly NorthWindContext context;

        public SuppliersRepository(NorthWindContext context) : base(context)
        {
            this.context = context;

        }

        public SuppliersModel GetSupplierBySupplierID(int Id)
        {
            return this.GetSuppliers().SingleOrDefault(co => co.SupplierID == Id);
        }

        public List<SuppliersModel> GetSuppliers()
        {
            var suppliers = this.GetEntities()
                                        .Where(co => !co.Eliminado)
                                        .Select(co => new SuppliersModel()
                                        {
                                            CompanyName = co.CompanyName,
                                            ContactTitle = co.ContactTitle,
                                            ContactName = co.ContactName,
                                            Address = co.Address,
                                            Country = co.Country,
                                            Phone = co.Phone,
                                            SupplierID = co.SupplierID,
                                        }).ToList();
            return suppliers;
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
        public override void Remove(Supplier entity)
        {
            Supplier supplier = this.GetEntity(entity.SupplierID);

            supplier.SupplierID = entity.SupplierID;
            supplier.Eliminado = entity.Eliminado;
            supplier.FechaElimino = entity.FechaElimino;
            supplier.IdUsuarioElimino = entity.IdUsuarioElimino;
            this.context.Suppliers.Update(supplier);
            this.context.SaveChanges();

        }

        List<SuppliersModel> ISuppliersRepository.GetSuppliersBySuppliersID(int SupplierID)
        {
            throw new NotImplementedException();
        }
    }
}
