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
    public class BookReviewService : GenericService<BookReview>, IBookReviewService
    {
        public BookReviewService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public async Task<IEnumerable<BookReview>> GetMyReviews(string userId)
            => await
                    UnitOfWork.BookReviewRepository.FindAll(x => x.UserId.Equals(userId),
                        x => x.OrderByDescending(d => d.Date));


        public IEnumerable<BookReview> GetAllByBookIdSync(int bookId)
            => UnitOfWork.BookReviewRepository.FindAllSync(b => b.BookId == bookId, b => b.OrderByDescending(x => x.Date));


        public async Task<BookReview> GetById(object id)
        => await UnitOfWork.BookReviewRepository.Find(id);


        public async Task Update(BookReview model)
        {
            model.Date = DateTime.Now;
            await UnitOfWork.BookReviewRepository.Update(model);
        }


        public async Task Delete(object id)
        {
            var bookReview = await UnitOfWork.BookReviewRepository.Find(id);
            await UnitOfWork.BookReviewRepository.Remove(bookReview);
        }


        public async Task<ReviewViewModel> PostReview(BookReview review)
        {
            var model = new ReviewViewModel();

            //Jeśli użytkownik już dodał swoją opinie to nie może dodać kolejnej
            //dotyczącej tej samej książki
            var bookReviewByUser =
                await
                    UnitOfWork.BookReviewRepository.FindAll(
                        b => b.BookId == review.BookId && b.UserId.Equals(review.UserId));

            if (bookReviewByUser.Any())
            {
                model.ErrorMessage = "Już dodałeś opinię na temat tej książki. Możesz ją zmienić lub usunąć";
            }
            else
            {
                review.Date = DateTime.Now;
                await UnitOfWork.BookReviewRepository.Add(review);
                model.SuccessMessage = "Twoja opinia została dodana";
            }

            return model;
        }

        public ShowVoteViewModel CalculateVote(int bookId)
        {
            var allBookReviews = UnitOfWork.BookReviewRepository.FindAllSync(b => b.BookId == bookId);
            var bookReviews = allBookReviews as IList<BookReview> ?? allBookReviews.ToList();
            var totalReviewCount = bookReviews.Count;
            var totalVoteSum = Convert.ToDouble(bookReviews.Sum(review => review.ReviewRate));
            var avgVoteVal = totalVoteSum / totalReviewCount;

            var votesInPercent = (avgVoteVal*100)/5;
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