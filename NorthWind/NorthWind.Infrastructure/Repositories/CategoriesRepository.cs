using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NorthWind.Infrastructure.Repositories
{
    public class CategoriesRepository : ICategoriesRepositry
    {
        private readonly NorthWindContext context;

        public CategoriesRepository(NorthWindContext context)
        {

            this.context = context;

        }

        public List<Categories> GetEntities()
        {
            return this.context.Categories.Where(cm => !cm.Eliminado).ToList();
        }

        public Categories GetEntity(int Id)
        {
            return this.context.Categories.Find(Id);
        }

        public void Remove(Categories entity)
        {
            this.context.Categories.Remove(entity);
        }

        public void Save(Categories entity)
        {
            this.context.Categories.Add(entity);
        }

        public void Update(Categories entity)
        {
            this.context.Categories.Update(entity);
        }
    }
}
