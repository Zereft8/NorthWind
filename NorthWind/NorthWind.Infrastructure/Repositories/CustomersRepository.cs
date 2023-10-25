
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Core;
using NorthWind.Infrastructure.Interfaces;


namespace NorthWind.Infrastructure.Repositories
{
    public class CustomersRepository : BaseRepository<Customer,string> ,ICustomersRepository
    {

        private readonly NorthWindContext context;

        public CustomersRepository(NorthWindContext context): base(context) 
        {

            this.context = context;
        
        }

        public override void Save(Customer entity)
        {
            context.Customers.Add(entity);
            context.SaveChanges();
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

            context.Customers.Update(customerToUpdae);
            context.SaveChanges();
        }

    }
}
