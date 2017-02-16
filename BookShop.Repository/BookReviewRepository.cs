using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Data.Sql;
using BookShop.Repository.Interfaces;

namespace BookShop.Repository
{
    public class BookReviewRepository : GenericRepository<BookReview>, IBookReviewRepository
    {
        public BookReviewRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task Update(BookReview entity)
        {
            var local = Context.Set<BookReview>()
                .Local
                .FirstOrDefault(b => b.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Update(entity);
        }

        public override async Task Remove(BookReview entity)
        {
            var local = Context.Set<BookReview>()
                .Local
                .FirstOrDefault(b => b.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Remove(entity);
        }


        /// <summary>
        /// Sztywne nie asynchroniczne zapytanie, aby wyświetlic dane synchronicznie
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IEnumerable<BookReview> FindAllSync(Expression<Func<BookReview, bool>> filter,
            Func<IQueryable<BookReview>, IOrderedQueryable<BookReview>> orderBy = null,
            int? skip = null, int? take = null) 
            => GetQueryable(filter, orderBy, skip, take).ToList();
    }
}