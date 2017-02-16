using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models.ViewModels;

namespace BookShop.Service.Interfaces
{
    public interface IAuthorReviewService : IGenericService<AuthorReview>
    {
        IEnumerable<AuthorReview> GetAllByAuthorIdSync(int authorId);

        Task<IEnumerable<AuthorReview>> GetMyReviews(string userId);

        Task<AuthorReview> GetById(object id);

        Task Update(AuthorReview model);

        Task Delete(object id);

        Task<ReviewViewModel> PostReview(AuthorReview review);

        ShowVoteViewModel CalculateVote(int authorId);
    }
}