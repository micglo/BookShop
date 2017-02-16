using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models.ViewModels;

namespace BookShop.Service.Interfaces
{
    public interface IBookReviewService : IGenericService<BookReview>
    {
        Task<IEnumerable<BookReview>> GetMyReviews(string userId);

        IEnumerable<BookReview> GetAllByBookIdSync(int bookId);

        Task<BookReview> GetById(object id);

        Task Update(BookReview model);

        Task Delete(object id);

        Task<ReviewViewModel> PostReview(BookReview review);

        ShowVoteViewModel CalculateVote(int bookId);
    }
}