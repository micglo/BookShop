using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Common.Repository.Interfaces;
using BookShop.Common.Service.Interfaces;
using BookShop.Data;

namespace BookShop.Common.Service
{
    public class BookReviewService : GenericService<BookReview>, IBookReviewService
    {
        public BookReviewService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<IEnumerable<BookReview>> GetAllAsync()
            => await UnitOfWork.BookReviewRepository.GetAllAsync();

        public override async Task<BookReview> GetByIdAsync(object id)
        => await UnitOfWork.BookReviewRepository.FindAsync(id);

        public override async Task AddAsync(BookReview model)
        {
            UnitOfWork.BookReviewRepository.Add(model);
            await UnitOfWork.SaveChangesAsync();
        }

        public override async Task UpdateAsync(BookReview model)
        {
            UnitOfWork.BookReviewRepository.Update(model);
            await UnitOfWork.SaveChangesAsync();
        }

        public override async Task DeleteAsync(long id)
        {
            var bookReview = await GetByIdAsync(id);
            UnitOfWork.BookReviewRepository.Remove(bookReview);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}