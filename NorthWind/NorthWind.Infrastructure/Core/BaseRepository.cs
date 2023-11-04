﻿using Microsoft.EntityFrameworkCore;
using NorthWind.Domain.Repository;
using NorthWind.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NorthWind.Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly NorthWindContext context;
        private DbSet<TEntity> entities;
        public BaseRepository(NorthWindContext context)
        {
            this.context = context;
            this.entities = this.context.Set<TEntity>();
        }
        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Any(filter);
        }

        public virtual List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Where(filter).ToList();
   
        }

        public virtual List<TEntity> GetEntities()
        {
            return entities.ToList();
        }

        public virtual TEntity GetEntity(int Id)
        {
            return this.entities.Find(Id);
        }

        public virtual void Remove(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public virtual void Save(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this.entities.Update(entity);
        }
    }
}
