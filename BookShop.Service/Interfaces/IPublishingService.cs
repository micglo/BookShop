using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models.ViewModels;

namespace BookShop.Service.Interfaces
{
    public interface IPublishingService : IGenericService<Publishing>
    {
        Task<IEnumerable<Publishing>> GetAll();

        Task<Publishing> GetById(int id);

        Task<Publishing> GetByNameAsync(string name);

        Task<InfoViewModel> Create(Publishing publishing);

        Task<InfoViewModel> Edit(Publishing publishing);

        Task<InfoViewModel> Delete(int id);

        Task<IEnumerable<SelectListViewModel>> GetPublishingsForSelect(string searchString);

        Task<bool> Exists(string name);
    }
}