using Microsoft.AspNetCore.Mvc;
using NorthWind.Api.Models.Modules.Customer;
using NorthWind.Application.Contracts;
using NorthWind.Application.Dtos.Customer;
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NorthWind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;  

        public CustomersController(ICustomerService customerService) 
        {

            this.customerService = customerService;

        }


        [HttpGet ("GetCustomers")]
        public IActionResult Get()
        {

            var result = this.customerService.GetAll();

            if(!result.Success) 
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpGet("GetCustomerById")]
        public IActionResult Get(string Id)
        {
            var result = this.customerService.GetById(Id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpPost("SaveCustomer")]
        public IActionResult Post([FromBody] CustomerDtoAdd customerAdd)
        {
            var result = this.customerService.Save(customerAdd);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpPost("UpdateCustomer")]
        public IActionResult Put([FromBody] CustomerDtoUpdate customerUpdate)
        {

            var result = this.customerService.Update(customerUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


        [HttpPost("RemoveCustomer")]
        public IActionResult Remove([FromBody] CustomerDtoRemove customerRemove)
        {

            var result = this.customerService.Remove(customerRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

    }
}
