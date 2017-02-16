using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.Common.Service.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task AddAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(long id);
    }
}