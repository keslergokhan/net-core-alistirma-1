using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCOGRENME.Core.Abstract;

namespace MVCOGRENME.Core.Conrete
{
    public class FEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public int Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var Entry = context.Entry(entity);
                Entry.State = EntityState.Added;
                return context.SaveChanges();
            }
        }
        public int Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var Entry = context.Entry(entity);
                Entry.State = EntityState.Modified;
                return context.SaveChanges();
            }

        }

        public int Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var Entry = context.Entry(entity);
                Entry.State = EntityState.Deleted;
                return context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        
    }
}
