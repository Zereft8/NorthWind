
using System.Collections.Generic;

namespace NorthWind.Domain.Repository
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {

        void Save(TEntity entity);
        void Update(TEntity entity);
        void Remove (TEntity entity);
        List<TEntity> GetEntities();
        TEntity GetEntity(TKey Id);


    }
}
