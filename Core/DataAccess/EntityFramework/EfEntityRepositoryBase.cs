using Core.DataAccess.EntityFramewok;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : EfEntityRepositoryBase<TEntity> 
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity t)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(t);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity t)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(t);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            using(TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public List<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public void Update(TEntity t)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(t);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
