using Microsoft.AspNetCore.Mvc;
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Interfaces;

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
        [HttpGet]
        public IEnumerable<Supplier> Get()
        {
            var supplier = this.suppliersRepository.GetEntities();
            return supplier;
        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")]
        public Supplier Get(int SupplierID)
        {
            return this.suppliersRepository.GetEntity(SupplierID);
        }

        // POST api/<SuppliersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SuppliersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
