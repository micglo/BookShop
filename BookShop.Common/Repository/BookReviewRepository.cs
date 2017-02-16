using System.Data.Entity;
using System.Linq;
using BookShop.Common.Repository.Interfaces;
using BookShop.Data;
using BookShop.Data.Sql;

namespace BookShop.Common.Repository
{
    public class BookReviewRepository : GenericRepository<BookReview>, IBookReviewRepository
    {
        public BookReviewRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override void Update(BookReview entity)
        {
            var local = Context.Set<BookReview>()
                .Local
                .FirstOrDefault(b => b.BookReviewId == entity.BookReviewId);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            base.Update(entity);
        }

        public override void Remove(BookReview entity)
        {
            var local = Context.Set<BookReview>()
                .Local
                .FirstOrDefault(b => b.BookReviewId == entity.BookReviewId);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            base.Remove(entity);
        }
    }
}