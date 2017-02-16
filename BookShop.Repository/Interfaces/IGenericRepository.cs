using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookShop.Data.Common;

namespace BookShop.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null);


        Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null);


        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> filter);


        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> filter);


        Task<TEntity> Find(object id);


        Task<bool> Any(Expression<Func<TEntity, bool>> filter);


        Task<TEntity> Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
    }
}