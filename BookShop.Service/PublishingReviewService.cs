using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models.ViewModels;
using BookShop.Repository.Interfaces;
using BookShop.Service.Interfaces;

namespace BookShop.Service
{
    public class PublishingReviewService : GenericService<PublishingReview>, IPublishingReviewService
    {
        public PublishingReviewService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public async Task<IEnumerable<PublishingReview>> GetMyReviews(string userId)
            => await
                    UnitOfWork.PublishingReviewRepository.FindAll(x => x.UserId.Equals(userId),
                        x => x.OrderByDescending(d => d.Date));


        public IEnumerable<PublishingReview> GetAllByPublishingIdSync(int publishingId)
            => UnitOfWork.PublishingReviewRepository.FindAllSync(p => p.PublishingId == publishingId, a => a.OrderByDescending(x => x.Date));


        public async Task<PublishingReview> GetById(object id)
            => await UnitOfWork.PublishingReviewRepository.Find(id);


        public async Task Update(PublishingReview model)
        {
            model.Date = DateTime.Now;
            await UnitOfWork.PublishingReviewRepository.Update(model);
        }


        public async Task Delete(object id)
        {
            var publishingReview = await UnitOfWork.PublishingReviewRepository.Find(id);
            await UnitOfWork.PublishingReviewRepository.Remove(publishingReview);
        }


        public async Task<ReviewViewModel> PostReview(PublishingReview review)
        {
            var model = new ReviewViewModel();

            //Jeśli użytkownik już dodał swoją opinie to nie może dodać kolejnej
            //dotyczącej tego samego wydawnictwa
            var publishingReviewByUser =
                await
                    UnitOfWork.PublishingReviewRepository.FindAll(
                        p => p.PublishingId == review.PublishingId && p.UserId.Equals(review.UserId));

            if (publishingReviewByUser.Any())
            {
                model.ErrorMessage = "Już dodałeś opinię na temat tej książki. Możesz ją zmienić lub usunąć";
            }
            else
            {
                review.Date = DateTime.Now;
                await UnitOfWork.PublishingReviewRepository.Add(review);
                model.SuccessMessage = "Twoja opinia została dodana";
            }

            return model;
        }


        public ShowVoteViewModel CalculateVote(int publishingId)
        {
            var allPublishingReviews = UnitOfWork.PublishingReviewRepository.FindAllSync(p => p.PublishingId == publishingId);
            var publishingReviews = allPublishingReviews as IList<PublishingReview> ?? allPublishingReviews.ToList();
            var totalReviewCount = publishingReviews.Count;
            var totalVoteSum = Convert.ToDouble(publishingReviews.Sum(review => review.ReviewRate));
            var avgVoteVal = totalVoteSum / totalReviewCount;

            var votesInPercent = (avgVoteVal * 100) / 5;
            var thisVote = "<span style=\"display: block; width: 65px; height: 13px; background: url(/Images/starRating.png) 0 0;\">" +
            "<span style=\"display: block; width: " + votesInPercent + "%; height: 13px; background: url(/images/starRating.png) 0 -13px;\"></span> " +
            "</span>" +
            "<span class=\"smallText\">Ilość głosów: <span itemprop=\"ratingCount\">" + totalReviewCount + "</span> | Ocena: <span itemprop=\"ratingValue\">" + avgVoteVal.ToString("##.##") + "</span>/5 </span>  ";

            return new ShowVoteViewModel
            {
                VoteData = thisVote,
                AverageVoteValue = avgVoteVal
            };
        }
    }
}