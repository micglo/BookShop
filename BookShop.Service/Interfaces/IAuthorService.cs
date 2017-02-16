using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models.ViewModels;

namespace BookShop.Service.Interfaces
{
    public interface IAuthorService : IGenericService<Author>
    {
        Task<IEnumerable<Author>> GetAll();

        Task<Author> GetById(object id);

        Task<InfoViewModel> Create(Author author);

        Task<InfoViewModel> Edit(Author author);

        Task<InfoViewModel> Delete(int id);

        Task<IEnumerable<SelectListViewModel>> GetAuthorsForSelect(string searchString);

        Task<bool> Exists(int id, string lastName);
    }
}