using Microsoft.AspNetCore.Mvc;
using NorthWind.Api.Models.Modules.Customer;
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NorthWind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository customersRepository;

        public CustomersController(ICustomersRepository customersRepository) 
        {

            this.customersRepository = customersRepository;

        }


        [HttpGet ("GetCustomers")]
        public IActionResult Get()
        {

            var customer = this.customersRepository.GetEntities()
                                                   .Select(cm => 
                                                            new GetCustomersModel()
                                                            {
                                                                CompanyName = cm.CompanyName,
                                                                ContactName = cm.ContactName,
                                                                ContactTitle = cm.ContactTitle,
                                                                Address = cm.Address,
                                                                City = cm.City,
                                                                Region = cm.Region,
                                                                PostalCode = cm.PostalCode,
                                                                Country = cm.Country,
                                                                Phone = cm.Phone,
                                                                Fax = cm.Fax,
                                                                FechaRegistro = cm.FechaRegistro,
                                                                CustomerID = cm.CustomerID
                                                            });



            return Ok(customer);
        }


        [HttpGet("GetCustomerById")]
        public IActionResult Get(string id)
        {
            var customer = this.customersRepository.GetEntity(id);

            GetCustomersModel customersModel = new GetCustomersModel()
            {   

                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                Fax = customer.Fax,
                FechaRegistro = customer.FechaRegistro,
                CustomerID = customer.CustomerID

            };

            return Ok(customersModel);
        }


        [HttpPost("SaveCustomer")]
        public IActionResult Post([FromBody] CustomerAppModel customerApp)
        {
            this.customersRepository.Save(new Customer()
            {
                CustomerID = customerApp.CustomerId,
                CompanyName = customerApp.CompanyName,
                ContactName = customerApp.ContactName,
                ContactTitle = customerApp.ContactTitle,
                Address = customerApp.Address,
                City = customerApp.City,
                Region = customerApp.Region,
                PostalCode = customerApp.PostalCode,
                Country = customerApp.Country,
                Phone = customerApp.Phone,
                Fax = customerApp.Fax,
                FechaRegistro = customerApp.ChangeDate,
                IdUsuarioCreacion = customerApp.ChangeUser

            });

            return Ok(); 
        }


        [HttpPost("UpdateCustomer")]
        public IActionResult Put([FromBody] CustomerUpdateModel customerUpdate)
        {

            this.customersRepository.Update(new Customer()
            {

                CompanyName = customerUpdate.CompanyName,
                ContactName = customerUpdate.ContactName,
                ContactTitle = customerUpdate.ContactTitle,
                Address = customerUpdate.Address,
                City = customerUpdate.City,
                Region = customerUpdate.Region,
                PostalCode = customerUpdate.PostalCode,
                Country = customerUpdate.Country,
                Phone = customerUpdate.Phone,
                Fax = customerUpdate.Fax,
                FechaMod = customerUpdate.ChangeDate,
                IdUsuarioMod = customerUpdate.ChangeUser,
                CustomerID = customerUpdate.CustomerID

            });

            return Ok();

        }

    }
}
