using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookShop.Common.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null);

        Task<IEnumerable<TEntity>> GetAllAsync(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null);

        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> FindAsync(object id);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}