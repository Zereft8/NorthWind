using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Interfaces;
using NorthWind.Infrastructure.Repositories;

namespace NorthWind.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepositry categoriesRepositry;

        // GET: CategoriesController/Create
        public CategoriesController(ICategoriesRepositry categoriesRepositry)
        {
            this.categoriesRepositry = categoriesRepositry;
        }

        [HttpGet]
        public List<Categories> Get()
        {

            var categories = this.categoriesRepositry.GetEntities();
            return categories;
        }

        [HttpGet("{id}")]
        public Categories Get(int id)
        {
            var category = this.categoriesRepositry.GetEntity(id);
            return category;
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    var deletionResult = await this.categoriesRepositry.DeleteCategory(id);

        //    if (deletionResult)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return StatusCode(500);
        //    }
        //}

    }
}
