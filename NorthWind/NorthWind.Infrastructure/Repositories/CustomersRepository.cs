
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Core;
using NorthWind.Infrastructure.Interfaces;
using NorthWind.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace NorthWind.Infrastructure.Repositories
{
    public class CustomersRepository : BaseRepository<Customer,string> ,ICustomersRepository
    {

        private readonly NorthWindContext context;

        public CustomersRepository(NorthWindContext context): base(context) 
        {

            this.context = context;
        
        }

        public CustomerModel GetCustomerById(string Id)
        {
            return this.GetCustomers().SingleOrDefault(cu => cu.CustomerID == Id);
        }

        public List<CustomerModel> GetCustomers()
        {
            var customers = this.GetEntities()
                                .Where(cu => !cu.Eliminado)
                                .Select(cu => new CustomerModel()
                                {
                                    CustomerID = cu.CustomerID,
                                    CompanyName = cu.CompanyName,
                                    ContactName = cu.ContactName,
                                    ContactTitle = cu.ContactTitle,
                                    Address = cu.Address,
                                    City = cu.City,
                                    Region = cu.Region,
                                    PostalCode = cu.PostalCode,
                                    Country = cu.Country,
                                    Phone = cu.Phone,
                                    Fax = cu.Fax,
                                    FechaRegistro = cu.FechaRegistro
                                }).ToList();

            return customers;
        }

        public override void Save(Customer entity)
        {
            base.Save(entity);
            this.context.SaveChanges();
        }

        public override void Update(Customer entity)
        {
            var customerToUpdae = base.GetEntity(entity.CustomerID);

            customerToUpdae.CompanyName = entity.CompanyName;
            customerToUpdae.ContactName = entity.ContactName;
            customerToUpdae.ContactTitle = entity.ContactTitle;
            customerToUpdae.Address = entity.Address;
            customerToUpdae.City = entity.City;
            customerToUpdae.Region = entity.Region;
            customerToUpdae.PostalCode = entity.PostalCode;
            customerToUpdae.Country = entity.Country;
            customerToUpdae.Phone = entity.Phone;
            customerToUpdae.Fax = entity.Fax;
            customerToUpdae.FechaMod= entity.FechaMod;
            customerToUpdae.IdUsuarioMod= entity.IdUsuarioMod;
            customerToUpdae.CustomerID = entity.CustomerID;

            this.context.Customers.Update(customerToUpdae);
            this.context.SaveChanges();
        }

        public override void Remove(Customer entity)
        {
            Customer customer = this.GetEntity(entity.CustomerID);

            customer.CustomerID= entity.CustomerID;
            customer.Eliminado = entity.Eliminado;
            customer.FechaElimino= entity.FechaElimino;
            customer.IdUsuarioElimino = entity.IdUsuarioElimino;

            this.context.Customers.Update(customer);
            this.context.SaveChanges();
        }

    }
}
