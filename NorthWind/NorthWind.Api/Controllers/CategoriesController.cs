using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthWind.Application.Contracts;
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Interfaces;
using NorthWind.Infrastructure.Repositories;

namespace NorthWind.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        // GET: CategoriesController/Create
        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var result = this.categoryService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.categoryService.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromBody] DeleteCategory deleteCategory)
        {
            var result = this.categoryService.Remove(deleteCategory);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

    }
}
