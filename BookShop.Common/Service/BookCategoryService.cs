using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Common.Repository.Interfaces;
using BookShop.Common.Service.Interfaces;
using BookShop.Data;

namespace BookShop.Common.Service
{
    public class BookCategoryService : GenericService<BookCategory>, IBookCategoryService
    {
        public BookCategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<IEnumerable<BookCategory>> GetAllAsync()
            => await UnitOfWork.BookCategoryRepository.GetAllAsync();

        public override async Task<BookCategory> GetByIdAsync(object id)
        => await UnitOfWork.BookCategoryRepository.FindAsync(id);

        public override async Task AddAsync(BookCategory model)
        {
            UnitOfWork.BookCategoryRepository.Add(model);
            await UnitOfWork.SaveChangesAsync();
        }

        public override async Task UpdateAsync(BookCategory model)
        {
            UnitOfWork.BookCategoryRepository.Update(model);
            await UnitOfWork.SaveChangesAsync();
        }

        public override async Task DeleteAsync(long id)
        {
            var bookCategory = await GetByIdAsync(id);
            UnitOfWork.BookCategoryRepository.Remove(bookCategory);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}