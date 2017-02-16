using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookShop.Common.Repository.Interfaces;
using BookShop.Data.Sql;

namespace BookShop.Common.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        protected ApplicationDbContext Context;

        public GenericRepository(ApplicationDbContext context)
        {
            Context = context;
            _dbSet = Context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null) => GetQueryable(null, orderBy, skip, take).ToList();

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null) => await GetQueryable(null, orderBy, skip, take).ToListAsync();

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null) => GetQueryable(filter, orderBy, skip, take).ToList();

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null) => await GetQueryable(filter, orderBy, skip, take).ToListAsync();

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter) => await _dbSet.SingleOrDefaultAsync(filter);

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter) => await _dbSet.FirstOrDefaultAsync(filter);

        public async Task<TEntity> FindAsync(object id) => await _dbSet.FindAsync(id);

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter) => await _dbSet.AnyAsync(filter);

        public void Add(TEntity entity) => _dbSet.Add(entity);

        public virtual void Update(TEntity entity)
        {
            Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        private IQueryable<TEntity> GetQueryable(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        int? skip = null,
        int? take = null)
        {
            IQueryable<TEntity> query = _dbSet;

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

        private void Attach(TEntity entity) => _dbSet.Attach(entity);
    }
}