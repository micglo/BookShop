using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Common.Repository.Interfaces;
using BookShop.Common.Service.Interfaces;

namespace BookShop.Common.Service
{
    public abstract class GenericService<T> : IGenericService<T> where T : class
    {
        protected IUnitOfWork UnitOfWork;

        protected GenericService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public abstract Task<IEnumerable<T>> GetAllAsync();
        public abstract Task<T> GetByIdAsync(object id);
        public abstract Task AddAsync(T model);
        public abstract Task UpdateAsync(T model);
        public abstract Task DeleteAsync(long id);

    }
}