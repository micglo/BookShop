using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models.ViewModels;

namespace BookShop.Service.Interfaces
{
    public interface IPublishingReviewService : IGenericService<PublishingReview>
    {
        Task<IEnumerable<PublishingReview>> GetMyReviews(string userId);

        IEnumerable<PublishingReview> GetAllByPublishingIdSync(int publishingId);

        Task<PublishingReview> GetById(object id);

        Task Update(PublishingReview model);

        Task Delete(object id);

        Task<ReviewViewModel> PostReview(PublishingReview review);

        ShowVoteViewModel CalculateVote(int publishingId);
    }
}