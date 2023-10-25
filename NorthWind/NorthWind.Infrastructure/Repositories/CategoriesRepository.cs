using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return this.context.Categories.ToList();
        }

        public Categories GetEntity(int Id)
        {
            return this.context.Categories.Find(Id);
        }

        public void Remove(Categories entity)
        {
            this.context.Categories.Remove(entity);
        }
        public virtual async Task<bool> DeleteCategory(int Id)
        {
            var category = this.context.Categories.Find(Id);
            if(category != null)
                this.context.Categories.Remove(category);
            await this.context.SaveChangesAsync();
            return true;
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
