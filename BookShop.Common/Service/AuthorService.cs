using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Common.Repository.Interfaces;
using BookShop.Common.Service.Interfaces;
using BookShop.Data;

namespace BookShop.Common.Service
{
    public class AuthorService : GenericService<Author>, IAuthorService
    {
        public AuthorService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<IEnumerable<Author>> GetAllAsync()
            => await UnitOfWork.AuthorRepository.GetAllAsync();

        public override async Task<Author> GetByIdAsync(object id)
            => await UnitOfWork.AuthorRepository.FindAsync(id);

        public override async Task AddAsync(Author model)
        {
            UnitOfWork.AuthorRepository.Add(model);
            await UnitOfWork.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Author model)
        {
            UnitOfWork.AuthorRepository.Update(model);
            await UnitOfWork.SaveChangesAsync();
        }

        public override async Task DeleteAsync(long id)
        {
            var author = await GetByIdAsync(id);
            UnitOfWork.AuthorRepository.Remove(author);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}