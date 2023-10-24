using Microsoft.AspNetCore.Mvc;
using NorthWind.Api.Models.Modules.Suppliers;
using NorthWind.Domain.Entities;
using NorthWind.Domain.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NorthWind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class SuppliersController : ControllerBase
    {
        private readonly ISuppliersRepository suppliersRepository;

        public SuppliersController(ISuppliersRepository suppliersRepository)
        {
            this.suppliersRepository = suppliersRepository;
        }
        // GET: api/<SuppliersController>
        [HttpGet("GetSuppliers")]
        public IActionResult Get()
        {
            var supplier = this.suppliersRepository.GetEntities()
                                                   .Select(st => new GetSupplierModel()
                                                   {
                                                       CompanyName = st.CompanyName,
                                                       ContactName = st.ContactName,
                                                       ContactTitle = st.ContactTitle,
                                                       Address = st.Address,
                                                       Country = st.Country,
                                                       FechaRegistro = st.FechaRegistro,
                                                       Phone = st.Phone,
                                                       IdUsuarioCreacion = st.IdUsuarioCreacion,
                                                       SupplierId = st.SupplierID


                                                   });
            return Ok(supplier);
        }

        // GET api/<SuppliersController>/5
        [HttpGet("GetSupplier")]
        public IActionResult Get(int SupplierID)
        {
            var supplier = this.suppliersRepository.GetEntity(SupplierID);
            GetSupplierModel suppliermodel = new GetSupplierModel()
            {
                CompanyName = supplier.CompanyName, 
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                Country = supplier.Country,
                FechaRegistro = supplier.FechaRegistro,
                Phone = supplier.Phone,
                IdUsuarioCreacion= supplier.IdUsuarioCreacion,
                SupplierId= supplier.SupplierID
            };    
            return Ok(suppliermodel);
        }

        // POST api/<SuppliersController>
        [HttpPost("SaveSupplier")]
        public IActionResult Post([FromBody] AddSuppliersModel addSuppliers)
        {
            this.suppliersRepository.Save(new Supplier() 
            {
                CompanyName = addSuppliers.CompanyName,
                ContactName = addSuppliers.ContactName,
                ContactTitle = addSuppliers.ContactTitle,
                Address = addSuppliers.Address,
                Country = addSuppliers.Country,
                Phone = addSuppliers.Phone,
                IdUsuarioCreacion = addSuppliers.IdUsuarioCreacion,
                FechaRegistro = addSuppliers.FechaRegistro,
            });
            return Ok(addSuppliers);
        }

        // PUT api/<SuppliersController>/5
        [HttpPut("UpdateSupplier")]
        public IActionResult Put([FromBody] UpdateSuppliersModel updateSuppliers)
        { 
            this.suppliersRepository.Update(new Supplier()
            {
                CompanyName = updateSuppliers.CompanyName,
                ContactName = updateSuppliers.ContactName,
                ContactTitle = updateSuppliers.ContactTitle,
                Address = updateSuppliers.Address,
                City    = updateSuppliers.City,
                Country = updateSuppliers.Country,
                Phone = updateSuppliers.Phone,
                IdUsuarioMod = updateSuppliers.IdUsuarioMod,
                FechaMod = updateSuppliers.FechaMod,
                SupplierID = updateSuppliers.SupplierID,

            });
            return Ok(updateSuppliers);
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
