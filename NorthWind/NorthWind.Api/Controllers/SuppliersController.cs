using Microsoft.AspNetCore.Mvc;
using NorthWind.Api.Models.Modules.Suppliers;
using NorthWind.Application.Contracts;
using NorthWind.Application.Dtos.Suppliers;
using NorthWind.Domain.Entities;
using NorthWind.Domain.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NorthWind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class SuppliersController : ControllerBase
    {
        private readonly ISuppliersService suppliersService;

        public SuppliersController(ISuppliersService suppliersService)
        {
            this.suppliersService = suppliersService;
        }
        // GET: api/<SuppliersController>
        [HttpGet("GetSuppliers")]
        public IActionResult GetSuppliers()
        {
            var result = this.suppliersService.GetAll();
            if (!result.Success) 
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<SuppliersController>/5
        [HttpGet("GetSupplier")]
        public IActionResult Get(int SupplierID)
        {
            var result = this.suppliersService.GetById(SupplierID);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<SuppliersController>
        [HttpPost("SaveSupplier")]
        public IActionResult Post([FromBody] SupplierDtoAdd addSuppliers)
        {
            var result = this.suppliersService.Save(addSuppliers);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<SuppliersController>/5
        [HttpPost("UpdateSupplier")]
        public IActionResult Post([FromBody] SupplierDtoUpdate updateSuppliers)
        {
            var result = this.suppliersService.Update(updateSuppliers);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<SuppliersController>/5
        [HttpPost("DeleteSupplier")]
        public IActionResult Post([FromBody] SupplierDtoRemove supplierDtoRemove)
        {
            var result = this.suppliersService.Remove(supplierDtoRemove);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
