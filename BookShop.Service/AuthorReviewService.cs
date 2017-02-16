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
    public class AuthorReviewService : GenericService<AuthorReview>, IAuthorReviewService
    {
        public AuthorReviewService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public IEnumerable<AuthorReview> GetAllByAuthorIdSync(int authorId)
            => UnitOfWork.AuthorReviewRepository.FindAllSync(a => a.AuthorId == authorId, a => a.OrderByDescending(x => x.Date));


        public async Task<IEnumerable<AuthorReview>> GetMyReviews(string userId)
            => await
                    UnitOfWork.AuthorReviewRepository.FindAll(x => x.UserId.Equals(userId),
                        x => x.OrderByDescending(d => d.Date));


        public async Task<AuthorReview> GetById(object id)
            => await UnitOfWork.AuthorReviewRepository.Find(id);


        public async Task Update(AuthorReview model)
        {
            model.Date = DateTime.Now;
            await UnitOfWork.AuthorReviewRepository.Update(model);
        }


        public async Task Delete(object id)
        {
            var authorReview = await UnitOfWork.AuthorReviewRepository.Find(id);
            await UnitOfWork.AuthorReviewRepository.Remove(authorReview);
        }


        public async Task<ReviewViewModel> PostReview(AuthorReview review)
        {
            var model = new ReviewViewModel();

            //Jeśli użytkownik już dodał swoją opinie to nie może dodać kolejnej
            //dotyczącej tego samego autora
            var authorReviewByUser =
                await
                    UnitOfWork.AuthorReviewRepository.FindAll(
                        a => a.AuthorId == review.AuthorId && a.UserId.Equals(review.UserId));

            if (authorReviewByUser.Any())
            {
                model.ErrorMessage = "Już dodałeś opinię na temat tej książki. Możesz ją zmienić lub usunąć";
            }
            else
            {
                review.Date = DateTime.Now;
                await UnitOfWork.AuthorReviewRepository.Add(review);
                model.SuccessMessage = "Twoja opinia została dodana";
            }

            return model;
        }


        public ShowVoteViewModel CalculateVote(int authorId)
        {
            var allAuthorReviews = UnitOfWork.AuthorReviewRepository.FindAllSync(a => a.AuthorId == authorId);
            var authorReviews = allAuthorReviews as IList<AuthorReview> ?? allAuthorReviews.ToList();
            var totalReviewCount = authorReviews.Count;
            var totalVoteSum = Convert.ToDouble(authorReviews.Sum(review => review.ReviewRate));
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