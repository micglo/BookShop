using System.Threading.Tasks;
using BookShop.Data;

namespace BookShop.Common.Service.Interfaces
{
    public interface IPublishingService : IGenericService<Publishing>
    {
        Task<Publishing> GetByNameAsync(string name);
    }
}