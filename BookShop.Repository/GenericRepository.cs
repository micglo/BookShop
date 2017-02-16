using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookShop.Data.Common;
using BookShop.Data.Sql;
using BookShop.Repository.Interfaces;

namespace BookShop.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> DbSet;
        protected ApplicationDbContext Context;


        public GenericRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }


        public async Task<IEnumerable<TEntity>> GetAll(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null) => await GetQueryable(null, orderBy, skip, take).ToListAsync();


        public async Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null) => await GetQueryable(filter, orderBy, skip, take).ToListAsync();


        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> filter) 
            => await DbSet.SingleOrDefaultAsync(filter);


        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> filter) 
            => await DbSet.FirstOrDefaultAsync(filter);


        public async Task<TEntity> Find(object id) 
            => await DbSet.FindAsync(id);


        public async Task<bool> Any(Expression<Func<TEntity, bool>> filter) 
            => await DbSet.AnyAsync(filter);


        public virtual async Task<TEntity> Add(TEntity entity)
        {
            var newEntity = DbSet.Add(entity);
            await Context.SaveChangesAsync();
            return newEntity;
        }


        public virtual async Task Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Attach(entity);
            }
            entry.State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }


        public virtual async Task Remove(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Attach(entity);
            }

            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }


        protected IQueryable<TEntity> GetQueryable(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        int? skip = null,
        int? take = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue && take.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }


        #region Helpers

        private void Attach(TEntity entity) => DbSet.Attach(entity);

        #endregion
    }
}