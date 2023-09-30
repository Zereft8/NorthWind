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

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Create(IFormCollection collection)
        {

        }
        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Edit(int id, IFormCollection collection)
        {

        }

        // GET: CategoriesController/Delete/5
        public void Delete(int id)
        {
           
        }

    }
}
